using System;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using WhereWeLivin.Network;

namespace WhereWeLivin.Pages
{
    public partial class GameClient : Form
    {
        public GameClient()
        {
            Client client = new Client();
            client.Connect();
            
            client.IncomingServerMessage += ClientOnIncomingServerMessage;

            Task.Factory.StartNew(() =>
            {
                while (true)
                {
                    client.ReadFromServer();
                }
            });
            
            InitializeComponent();
        }

        private void ClientOnIncomingServerMessage()
        {
            Application.Exit();
        }
    }
}