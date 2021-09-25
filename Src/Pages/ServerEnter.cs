using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WhereWeLivin.Pages
{
    public partial class ServerEnter : Form
    {
        private Form _hostForm;
        private Form _gameClientForm;
        
        public ServerEnter()
        {
            InitializeComponent();
        }

        // Checks if input fields are non-empty (valid)
        private bool AreInputsValid()
        {
            if (portTextBox.Text.Equals("") || serverTextBox.Text.Equals(""))
            {
                MessageBox.Show(@"Ensure Server Address and Port fields are non-empty!", @"ERROR", 
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            return true;
        }

        // Handles connect button click
        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!AreInputsValid())
                return;

            if (_gameClientForm == null)
            {
                _gameClientForm = new GameClient(IPAddress.Parse(serverTextBox.Text), int.Parse(portTextBox.Text));
                _gameClientForm.Closed += (j, ev) => Application.Exit();
                _gameClientForm.FormClosed += (j, ev) => Application.Exit();
            }
            
            Hide();
            _gameClientForm.Show();
        }

        // Handles host button click
        private void hostButton_Click(object sender, EventArgs e)
        {
            if (!AreInputsValid())
                return;

            if (_hostForm == null)
            {

                _hostForm = new HostEnter(IPAddress.Parse(serverTextBox.Text), int.Parse(portTextBox.Text));
                _hostForm.Closed += (s, ev) => Application.Exit();
                _hostForm.FormClosed += (s, ev) => Application.Exit();
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