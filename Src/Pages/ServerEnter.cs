using System;
using System.Net;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using WhereWeLivin.Network;

namespace WhereWeLivin.Pages
{
    public partial class ServerEnter : Form
    {
        private Form _hostForm;
        private Form _gameClientForm;
        
        public ServerEnter()
        {
            Closed += (s, ev) =>
            {
                Application.ExitThread();
                Environment.Exit(0);
            };

            FormClosed += (s, ev) =>
            {
                Application.ExitThread();
                Environment.Exit(0);
            };
            
            InitializeComponent();
        }

        // Checks if input fields are non-empty and in valid format
        private bool AreInputsValid()
        {
            if (portTextBox.Text.Equals("") || serverTextBox.Text.Equals(""))
            {
                MessageBox.Show(@"Ensure server address and port fields are non-empty!", @"ERROR", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            
            // Checks if IP Address is in valid format
            if (!Regex.IsMatch(serverTextBox.Text, "^((25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\\.){3}(25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)$"))
            {
                MessageBox.Show(@"Please enter a valid Server Address!", @"ERROR", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            // Sets IPAddress and Port global variables
            NetworkInformation.IpAddress = IPAddress.Parse(serverTextBox.Text);
            NetworkInformation.Port = int.Parse(portTextBox.Text);

            return true;
        }

        // Handles connect button click (client)
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!AreInputsValid())
                return;

            if (_gameClientForm == null)
            {
                _gameClientForm = new GameClient();
                _gameClientForm.Closed += (s, ev) =>
                {
                    Application.ExitThread();
                    Environment.Exit(0);
                };
                
                _gameClientForm.FormClosed += (s, ev) =>
                {
                    Application.ExitThread();
                    Environment.Exit(0);
                };
            }
            
            Hide();
            _gameClientForm.Show();
        }

        // Handles host button click (host)
        private void hostButton_Click(object sender, EventArgs e)
        {
            if (!AreInputsValid())
                return;

            if (_hostForm == null)
            {
                _hostForm = new HostEnter();
                _hostForm.Closed += (s, ev) =>
                {
                    Application.ExitThread();
                };
                
                _hostForm.FormClosed += (s, ev) =>
                {
                    Application.ExitThread();
                };
            }
            
            Hide();
            _hostForm.Show();
        }

        private void Debug_Click(object sender, EventArgs e)
        {
            portTextBox.Text = "8";
            serverTextBox.Text = "127.0.0.1";
        }
    }
}