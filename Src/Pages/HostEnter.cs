using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;
using WhereWeLivin.Network;

namespace WhereWeLivin.Pages
{
    public partial class HostEnter : Form
    {
        private static Server _server;
        private List<Client> _clients;
        private readonly int _port;
        private readonly IPAddress _serverAddress;

        public HostEnter(IPAddress serverAddress, int port)
        {
            _serverAddress = serverAddress;
            _port = port;
            
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            // Initialize Server Host
            _server = new Server(_serverAddress, _port);
            _server.SocketAccepted += ServerSocketAccepted;
            
            _server.Start();
        }

        private void ServerSocketAccepted(Socket socket)
        {
            var client = new Client(socket);
            client.Received += ClientOnReceived;
            client.Disconnected += ClientOnDisconnected;
            
            Invoke((MethodInvoker)delegate
            {
                var viewItem = new ListViewItem
                {
                    Text = client.EndPoint.ToString()
                };
                viewItem.SubItems.Add(client.ID);
                connectedClientList.Items.Add(viewItem);

            });
        }

        private void ClientOnDisconnected(Client sender)
        {
            Console.WriteLine("yoo dis");
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < connectedClientList.Items.Count; i++)
                {
                    if (connectedClientList.Items[i].Tag is Client client && client.ID == sender.ID)
                    {
                        connectedClientList.Items.RemoveAt(i);
                        break;
                    }
                }
            });
        }

        private void ClientOnReceived(Client sender, byte[] data)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < connectedClientList.Items.Count; i++)
                {
                    if (connectedClientList.Items[i].Tag is Client client && client.ID == sender.ID)
                    {
                        Console.WriteLine("yo");
                        Console.WriteLine(Encoding.Default.GetString(data));
                        break;
                    }
                }
            });
        }
    }
}