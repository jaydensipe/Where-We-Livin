using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace WhereWeLivin.Pages
{
    public partial class GameClient : Form
    {
        public GameClient(IPAddress serverAddress, int port)
        {
            Socket s = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            s.Connect(serverAddress, port);
            s.Send(Encoding.Default.GetBytes(@"heyryeye"));
            
            InitializeComponent();
        }
        
    }
}