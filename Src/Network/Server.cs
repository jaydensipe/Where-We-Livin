using System;
using System.Collections.Generic;
using System.IO;
using System.Net.Sockets;
using System.Threading.Tasks;
using Newtonsoft.Json;
using WhereWeLivin.Pages;

namespace WhereWeLivin.Network
{
    public class Server
    {
        private static readonly TcpListener TcpServer = new TcpListener(NetworkInformation.IpAddress, NetworkInformation.Port);
        private readonly List<TcpClient> _clientConnections = new List<TcpClient>();

        public KeyValuePair<string, double> ChosenState;
        private double _stateScore;
        
        // Starts server and makes a new thread for each client
        public void Start()
        {
            TcpServer.Start();
            
            // TODO: FINISH THIS
            for (var i = 0; i < 3; i++)
            {
                Task.Run(Listening);
            }
        }

        // Begins listening for clients and adds them to connected clients list
        private void Listening()
        {
            var connectedClientSocket = TcpServer.AcceptTcpClient();
            _clientConnections.Add(connectedClientSocket);

            if (connectedClientSocket.Connected)
            {
                Console.WriteLine(@"Client:" + connectedClientSocket.Client.RemoteEndPoint + @" now connected to server.");
                OnClientJoin?.Invoke(connectedClientSocket);
            }

            // Start reading from all clients
            ReadFromAllClient(connectedClientSocket);
        }

        // Sends desired "object" message to ALL clients from server as JSON
        public void WriteToAllClient(object message)
        {
            // ReSharper disable once ForeachCanBePartlyConvertedToQueryUsingAnotherGetEnumerator
            foreach (var socket in _clientConnections)
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
            
            _clientConnections.Remove(socket);
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