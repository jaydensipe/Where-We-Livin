using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhereWeLivin.Pages;

namespace WhereWeLivin.Network
{
    public class Server
    {
        private static readonly TcpListener TcpServer = new TcpListener(NetworkInformation.IpAddress, NetworkInformation.Port);
        private readonly List<TcpClient> _clientConnections = new List<TcpClient>();

        public KeyValuePair<string, double> ChosenState;
        public KeyValuePair<string, double> UpdatedState;
        private double _stateScore = 0;

        private void Listening()
        {
            var connectedClientSocket = TcpServer.AcceptTcpClient();
            _clientConnections.Add(connectedClientSocket);

            if (connectedClientSocket.Connected)
            {
                Console.WriteLine(@"Client:" + connectedClientSocket.Client.RemoteEndPoint + @" now connected to server.");
                OnClientJoin?.Invoke(connectedClientSocket);
            }

            ReadFromAllClient(connectedClientSocket);
        }

        // Starts server and makes a new thread for each client
        public void Start()
        {
            TcpServer.Start();
            
            for (var i = 0; i < 3; i++)
            {
                Task.Run(Listening);
            }
        }

        // Sends desired message to ALL clients from server
        public void WriteToAllClient(string message)
        {
            foreach (var streamWriter in _clientConnections.Select(socket => socket.GetStream()).Select(networkStream => new StreamWriter(networkStream)))
            {
                streamWriter.WriteLine(message);
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
                
                // Handles if client sends back disconnect
                if (clientInput != null && clientInput.Equals(GameInformation.Exit))
                {
                    _clientConnections.Remove(socket);
                    OnClientDisconnect?.Invoke(socket);
                    
                    return;
                }

                if (!ChosenState.IsNull())
                {
                    _stateScore += Convert.ToDouble(clientInput);
                    var updatedState = new KeyValuePair<string, double>(ChosenState.Key, _stateScore);
                    ChosenState = updatedState;
                }

                Console.WriteLine(Convert.ToDouble(clientInput));
                OnClientServerReceieveMessage?.Invoke(socket);
            }
        }

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