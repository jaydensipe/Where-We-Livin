using System;
using System.IO;
using System.Net.Sockets;
using System.Windows.Forms;

namespace WhereWeLivin.Network
{
    public class Client
    {
        private TcpClient _tcpClient;
        private NetworkStream _networkStream;
        private StreamReader _streamReader;
        private StreamWriter _streamWriter;
        private string _serverOutput;

        // Connects to hosting server
        public void Connect()
        {
            
            try
            {
                _tcpClient = new TcpClient(NetworkInformation.IpAddress.ToString(), NetworkInformation.Port);
            }
            catch(Exception)
            {
                MessageBox.Show(@"Could not connect to server!", @"ERROR", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
            
            _networkStream = _tcpClient.GetStream();
            _streamReader = new StreamReader(_networkStream);
            _streamWriter = new StreamWriter(_networkStream);
        }

        // Sends desired message to server from client
        public void WriteToServer(string message)
        {
            _streamWriter.WriteLine(message);
            _streamWriter.Flush();
        }

        // Reads incoming messages from server
        public void ReadFromServer()
        {
            _serverOutput = _streamReader.ReadLine();
            
            if (_serverOutput != null && _streamReader != null)
            {
                IncomingServerMessage?.Invoke(_serverOutput);
            }
        }

        public delegate void IncomingServerMessageHandler(string serverInput);
        public event IncomingServerMessageHandler IncomingServerMessage;
        
    }
}