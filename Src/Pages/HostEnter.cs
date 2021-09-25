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
        private HashSet<Client> _clients;

        public HostEnter(IPAddress serverAddress, int port)
        {
            var server = new Server(serverAddress, port);
            server.SocketAccepted += ServerSocketAccepted;

            server.Start();

            InitializeComponent();
        }

        // Server accepts client connection and lists them
        private void ServerSocketAccepted(Socket socket)
        {
            var client = new Client(socket);
            client.Received += ClientOnReceived;
            client.Disconnected += ClientOnDisconnected;

            Invoke((MethodInvoker)delegate
            {
                var viewItem = new ListViewItem
                {
                    Text = client.EndPoint.ToString(),
                    Tag = client.ID,
                    Group = new ListViewGroup("Connected Clients")
                };

                connectedClientList.Items.Add(viewItem);
            });
        }

        // Handles and delete client from list of connected users
        private void ClientOnDisconnected(Client sender)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < connectedClientList.Items.Count; i++)
                {
                    if (ReferenceEquals(sender.ID, connectedClientList.Items[i].Tag))
                    {
                        connectedClientList.Items.RemoveAt(i);
                        break;
                    }
                }
            });
        }

        // Handles and adds client from list of connected users
        private void ClientOnReceived(Client sender, byte[] data)
        {
            Invoke((MethodInvoker)delegate
            {
                for (int i = 0; i < connectedClientList.Items.Count; i++)
                {
                    if (ReferenceEquals(sender.ID, connectedClientList.Items[i].Tag))
                    {
                        // hashset add to variable for client
                        Console.WriteLine(Encoding.Default.GetString(data));
                        break;
                    }
                }
            });
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }
    }
}