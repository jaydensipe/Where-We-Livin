using System;
using System.Diagnostics;
using System.IO;
using System.Net;
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
        private String _serverInput;

        public void Connect()
        {
            try
            {
                _tcpClient = new TcpClient(NetworkInformation.IpAddress.ToString(), NetworkInformation.Port);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }
            
            _networkStream = _tcpClient.GetStream();
            _streamReader = new StreamReader(_networkStream);
            _streamWriter = new StreamWriter(_networkStream);
            
            Application.ApplicationExit += OnApplicationExit;

        }

        private void OnApplicationExit(object sender, EventArgs e)
        {
           WriteToServer("EXIT");
        }

        public void WriteToServer(String message)
        {
            _streamWriter.WriteLine(message);
            _streamWriter.Flush();
        }

        public void ReadFromServer()
        {
            _serverInput = _streamReader.ReadLine();
            
            if (_serverInput != null && _streamReader != null && _serverInput.Equals("START"))
            {
                IncomingServerMessage?.Invoke();
            }
        }

        public delegate void IncomingServerMessageHandler();
        public event IncomingServerMessageHandler IncomingServerMessage;
        
    }
}