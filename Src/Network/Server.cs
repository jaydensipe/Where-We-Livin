using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using WhereWeLivin.Pages;

namespace WhereWeLivin.Network
{
    public class Server
    {
        private static readonly TcpListener TcpServer = new TcpListener(NetworkInformation.IpAddress, NetworkInformation.Port);
        public readonly List<TcpClient> ClientConnections = new List<TcpClient>();

        public KeyValuePair<string, double> ChosenState;
        private double _stateScore;
        
        // Starts server and makes a new thread for a client
        public void Start()
        {
            try
            {
                TcpServer.Start();
                Task.Run(Listening);
            }
            catch (SocketException)
            {
                MessageBox.Show(@"Could not host server, ensure server address and port are typed correctly!", @"ERROR", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }

        // Begins listening for clients and adds them to connected clients list, then creates a new thread for another
        // incoming client
        private void Listening()
        {
            var connectedClientSocket = TcpServer.AcceptTcpClient();
            ClientConnections.Add(connectedClientSocket);

            if (!connectedClientSocket.Connected) return;
            
            Console.WriteLine(@"Client:" + connectedClientSocket.Client.RemoteEndPoint + @" now connected to server.");
            OnClientJoin?.Invoke(connectedClientSocket);
            Task.Run(Listening);
               
            // Start reading from all clients
            ReadFromAllClient(connectedClientSocket);
        }

        // Sends desired "object" message to ALL clients from server as JSON
        public void WriteToAllClient(object message)
        {
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var socket in ClientConnections)
            {
                var networkStream = socket.GetStream();
                var streamWriter = new StreamWriter(networkStream);
                
                streamWriter.WriteLine(JsonConvert.SerializeObject(message));
                streamWriter.Flush();
            }
        }

        // Reads inputs from ALL clients
        private void ReadFromAllClient(TcpClient socket)
        {
            var networkStream = socket.GetStream();
            var streamReader = new StreamReader(networkStream);
            
            while (socket.Connected)
            {
                string clientInput = streamReader.ReadLine();
                
                HandleDisconnects(clientInput, socket);
                UpdateState(clientInput);

                OnClientServerReceieveMessage?.Invoke(socket);
            }
        }

        private void HandleDisconnects(string clientInput, TcpClient socket)
        {
            // Handles if client sends back disconnect
            if (clientInput == null || !clientInput.Equals(GameInformation.Exit)) return;
            
            ClientConnections.Remove(socket);
            OnClientDisconnect?.Invoke(socket);
        }

        private void UpdateState(string clientInput)
        {
            // Updates the chosen state's score everytime a user inputs
            if (ChosenState.IsNull()) return;
            
            _stateScore += Convert.ToDouble(clientInput);
            var updatedState = new KeyValuePair<string, double>(ChosenState.Key, _stateScore);
            ChosenState = updatedState;
        }

        // Picks a random state and returns it
        public KeyValuePair<string, double> ReturnChosenState()
        {
            ChosenState = GameInformation.RandomPickState();
            _stateScore = 0;
            return ChosenState;
        }
        
        public delegate void ClientJoinHandler(TcpClient tcpClient);
        public event ClientJoinHandler OnClientJoin;
        
        public delegate void ClientDisconnectHandler(TcpClient tcpClient);
        public event ClientDisconnectHandler OnClientDisconnect;
        
        public delegate void ClientServerReceivedMessage(TcpClient tcpClient);
        public event ClientServerReceivedMessage OnClientServerReceieveMessage;
    }
}