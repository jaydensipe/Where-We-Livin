using System;
using System.Windows.Forms;

namespace WhereWeLivin.Pages
{
    public partial class ServerEnter : Form
    {
        private Form _hostForm;
        
        public ServerEnter()
        {
            InitializeComponent();
        }

        private void connectButton_Click(object sender, EventArgs e)
        {
            throw new System.NotImplementedException();
        }

        private void hostButton_Click(object sender, EventArgs e)
        {
            if (_hostForm == null)
            {
                _hostForm = new HostEnter();
            }
            
            Hide();
            _hostForm.Show();
        }
    }
}