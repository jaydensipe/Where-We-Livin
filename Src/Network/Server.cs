using System;
using System.Net;
using System.Net.Sockets;

namespace WhereWeLivin.Network
{
    public class Server
    {
        private Socket _socket;
        private bool _isListening;
        private readonly int _port;
        private readonly IPAddress _serverAddress;

        public Server(IPAddress serverAddress, int port)
        {
            _port = port;
            _serverAddress = serverAddress;
            
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
        }

        public void Start()
        {
            if (_isListening)
                return;
            
            // Binds socket to passed in IP address and port
            _socket.Bind(new IPEndPoint(_serverAddress, _port));
            _socket.Listen(0);

            _socket.BeginAccept(Callback, null);
            _isListening = true;
        }

        public void Stop()
        {
            if (!_isListening)
                return;
            
            _socket.Close();
            _socket.Dispose();
            
            _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

        }

        void Callback(IAsyncResult asyncResult)
        {
            try
            {
                var connection = _socket.EndAccept(asyncResult);

                SocketAccepted?.Invoke(connection);
                
                _socket.BeginAccept(Callback, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
        }

        public delegate void SocketAcceptHandler(Socket socket);
        public event SocketAcceptHandler SocketAccepted;
    }
}