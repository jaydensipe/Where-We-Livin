using System;
using System.Collections.Generic;
using System.Drawing;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization.Formatters.Binary;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhereWeLivin.Network;

namespace WhereWeLivin.Pages
{
    public partial class HostEnter : Form
    {
        private readonly Server _server;
        private bool _gameStarted;
        
        public HostEnter()
        {
            _server = new Server();
            _server.Start();
            
            _server.OnClientJoin += ServerOnClientJoin;
            _server.OnClientDisconnect += ServerOnClientDisconnect;
            _server.OnClientServerReceieveMessage += ServerOnClientServerReceieveMessage;
            GameInformation.OnEndGame += GameInformationOnEndGame;

            InitializeComponent();
        }

        private void GameInformationOnEndGame()
        {
            _server.WriteToAllClient(GameInformation.ReturnTopMostWantedStates());
            _server.WriteToAllClient(GameInformation.End);
        }

        private void ServerOnClientServerReceieveMessage(TcpClient tcpClient)
        {
            ClientHasChosen(tcpClient.Client.RemoteEndPoint);
        }
        
        // Resets all connect client's names back to Red to indicate they haven't chosen
        private void ResetClientChoice()
        {
            foreach (ListViewItem item in connectedClientList.Items)
            {
                item.ForeColor = Color.Red;
            }
        }

        // Changes a clients name to green if they have chosen
        private void ClientHasChosen(EndPoint endPoint)
        {
            foreach (ListViewItem item in connectedClientList.Items)
            {
                if (item.Text.Equals(endPoint.ToString()))
                {
                    item.ForeColor = Color.Green;
                }
            }
        }

        // Handles and deletes client from list of connected clients
        private void ServerOnClientDisconnect(TcpClient tcpClient)
        {
            for (var i = 0; i < connectedClientList.Items.Count; i++)
            {
                if (tcpClient.Client.RemoteEndPoint.ToString().Equals(connectedClientList.Items[i].Text))
                {
                    connectedClientList.Items.RemoveAt(i);
                    break;
                }
            }
        }

        // Event for handling adding connected client to list
        private void ServerOnClientJoin(TcpClient tcpClient)
        {
            var viewItem = new ListViewItem
            {
                Text = tcpClient.Client.RemoteEndPoint.ToString()
            };
            
            connectedClientList.Items.Add(viewItem);
        }

        // Starts a new round sending to the client to start a new round and sending the client a new state
        private void NewRound()
        {
            if (!_server.ChosenState.IsNull())
            {
                GameInformation.RemovePickedState(_server.ChosenState);
            }
            
            string response = GameInformation.NewRound;
            _server.WriteToAllClient(response);

            var state = _server.ReturnChosenState();
            _server.WriteToAllClient(state.Key);
        }
        
        private void startButton_Click(object sender, EventArgs e)
        {
            if (!_gameStarted)
            {
                startButton.Text = @"Next Round";
                _gameStarted = true;
            }
            
            ResetClientChoice();
            NewRound();
        }
    }
}