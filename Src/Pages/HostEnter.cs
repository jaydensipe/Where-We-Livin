using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhereWeLivin.Network;

namespace WhereWeLivin.Pages
{
    public partial class HostEnter : Form
    {
        private readonly Server _server;
        
        public HostEnter()
        {
            _server = new Server();
            _server.Start();
            
            _server.OnClientJoin += ServerOnClientJoin;
            _server.OnClientDisconnect += ServerOnClientDisconnect;
            
            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    _server.ReadFromAllClient();
                }
            });
            
            InitializeComponent();
        }

        // Handles and deletes client from list of connected clients
        private void ServerOnClientDisconnect(EndPoint endpoint)
        {
            for (int i = 0; i < connectedClientList.Items.Count; i++)
            {
                if (ReferenceEquals(endpoint.ToString(), connectedClientList.Items[i].Text))
                {
                    connectedClientList.Items.RemoveAt(i);
                    break;
                }
            }
        }

        // Event for handling adding connected client to list
        private void ServerOnClientJoin(EndPoint endpoint)
        {
            var viewItem = new ListViewItem
            {
                Text = endpoint.ToString(),
            };
            
            connectedClientList.Items.Add(viewItem);
        }
        
        private void startButton_Click(object sender, EventArgs e)
        {
            _server.WriteToAllClient();
        }
    }
}