using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Threading;

namespace WhereWeLivin.Network
{
    public class Server
    {
        private static readonly TcpListener TcpServer = new TcpListener(NetworkInformation.IpAddress, NetworkInformation.Port);
        NetworkStream _networkStream;
        StreamWriter _streamWriter;
        StreamReader _streamReader;

        private List<Socket> clientConnections = new List<Socket>();

        private void Listening()
        {
            Socket connectedClientSocket = TcpServer.AcceptSocket();
            clientConnections.Add(connectedClientSocket);

            if (connectedClientSocket.Connected)
            {
                Console.WriteLine(@"Client:" + connectedClientSocket.RemoteEndPoint + @" now connected to server.");
                OnClientJoin?.Invoke(connectedClientSocket.RemoteEndPoint);
            }
        }

        public void Start()
        {
            TcpServer.Start();
            
            for (int i = 0; i < 2; i++)
            {
                Thread thread = new Thread(Listening);
                thread.Start();
            }
        }

        public void WriteToAllClient()
        {
            foreach (var socket in clientConnections)
            { 
                _networkStream = new NetworkStream(socket);
                _streamWriter = new StreamWriter(_networkStream);
                
                _streamWriter.WriteLine("START");
                _streamWriter.Flush();
            } 
        }

        public void ReadFromAllClient()
        {
            foreach (var socket in clientConnections)
            { 
                _networkStream = new NetworkStream(socket);
                _streamReader = new StreamReader(_networkStream);

                if (_streamReader != null && _streamReader.ReadLine().Equals("EXIT"))
                {
                    OnClientDisconnect?.Invoke(socket.RemoteEndPoint);
                    break;
                }

            } 
        }
        
        public delegate void ClientJoinHandler(EndPoint endPoint);
        public event ClientJoinHandler OnClientJoin;
        
        public delegate void ClientDisconnectHandler(EndPoint endPoint);
        public event ClientDisconnectHandler OnClientDisconnect;
    }
}