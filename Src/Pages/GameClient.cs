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
        private readonly Client _client;
        private bool _waitingForHostStartGame = true;
        
        public GameClient()
        {
            _client = new Client();
            _client.Connect();
            
            _client.IncomingServerMessage += ClientOnIncomingServerMessage;

            Task.Run(() =>
            {
                while (true)
                {
                    _client.ReadFromServer();
                }
            });
            
            InitializeComponent();
        }

        // Handles incoming outputs from server
        private void ClientOnIncomingServerMessage(string serverOutput)
        {
            // Determine if server is starting new round and handle
            switch (serverOutput)
            {
                case GameInformation.NewRound when _waitingForHostStartGame:
                    hidePanel.Hide();
                    waitingForHostText.Hide();
                    ShowButtonsAndHideText(true);
                    return;
                case GameInformation.NewRound:
                    ShowButtonsAndHideText(true);
                    return;
                default:
                    stateContainer.Text = serverOutput + @"?";
                    // connectionLabel.Hide();
                    MessageBox.Show(serverOutput);
                    break;
            }
        }
        
        // Hides/Shows choice buttons and waiting for host text depending on bool
        private void ShowButtonsAndHideText(bool opposite)
        {
            if (!opposite)
            {
                yesButton.Hide();
                maybeButton.Hide();
                noButton.Hide();
                waitLabel.Show();
                
                return;
            }
            
            yesButton.Show();
            maybeButton.Show();
            noButton.Show();
            waitLabel.Hide();
        }

        // Determines what happens when users hit "Yes"
        private void yesButton_Click(object sender, EventArgs e)
        {
            _client.WriteToServer("1.0");
            waitLabel.Text = @"You chose ""Yes!"". Waiting for host...";
            ShowButtonsAndHideText(false);
        }

        // Determines what happens when users hit "Maybe"
        private void maybeButton_Click(object sender, EventArgs e)
        {
            _client.WriteToServer("0.5");
            waitLabel.Text = @"You chose ""Maybe!"". Waiting for host...";
            ShowButtonsAndHideText(false);
        }

        // Determines what happens when users hit "No"
        private void noButton_Click(object sender, EventArgs e)
        {
            _client.WriteToServer("-1.0");
            waitLabel.Text = @"You chose ""No!"". Waiting for host...";
            ShowButtonsAndHideText(false);
        }
    }
}