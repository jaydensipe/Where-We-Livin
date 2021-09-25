using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Remoting.Messaging;

namespace WhereWeLivin.Network
{
    public class Client
    {
        public readonly string ID;
        public readonly IPEndPoint EndPoint;
        private readonly Socket _clientSocket;

        public Client(Socket accepted)
        {
            _clientSocket = accepted;
            ID = Guid.NewGuid().ToString();
            EndPoint = (IPEndPoint)accepted.RemoteEndPoint;

            _clientSocket.BeginReceive(new byte[] { 0 }, 0, 0, 0, Callback, null);
        }

        void Callback(IAsyncResult asyncResult)
        {
            try
            {
                _clientSocket.EndReceive(asyncResult);
               
                byte[] buffer = new byte[8192];
                int rec = _clientSocket.Receive(buffer, buffer.Length, 0);

                if (rec == 0)
                {
                    throw new SocketException();
                }

                if (rec < buffer.Length)
                {
                    Array.Resize(ref buffer, rec);
                }
                
                

                Received?.Invoke(this, buffer);
                _clientSocket.BeginReceive(new byte[] { 0 }, 0, 0, 0, Callback, null);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        public void Close()
        {
            _clientSocket.Close();
            _clientSocket.Dispose();
        }

        public delegate void ClientReceivedHandler(Client sender, byte[] data);
        public delegate void ClientDisconnectedHandler(Client sender);

        public event ClientReceivedHandler Received;
        public event ClientDisconnectedHandler Disconnected;

    }
}