using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;
using System.Net.Sockets;
using System.Windows.Forms;
using WhereWeLivin.Network;

namespace WhereWeLivin.Pages
{
    public partial class ServerEnter : Form
    {
        private Form _hostForm;
        
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

        private void connectButton_Click(object sender, EventArgs e)
        {
            if (!AreInputsValid())
                return;
        }

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
    }
}