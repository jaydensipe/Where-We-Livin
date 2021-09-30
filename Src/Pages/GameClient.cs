using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using WhereWeLivin.Network;

namespace WhereWeLivin.Pages
{
    public partial class GameClient : Form
    {
        private readonly Client _client;
        private Form _endScreenForm;
        private string _topAndLeastJson;
        
        private bool _waitingForHostStartGame = true;

        public GameClient()
        {
            _client = new Client();
            _client.Connect();
            
            _client.IncomingServerMessage += ClientOnIncomingServerMessage;
            
            InitializeComponent();

            Task.Run(() =>
            {
                while (true)
                {
                    _client.ReadFromServer();
                }
            });
        }
        
        // https://stackoverflow.com/questions/14977848/how-to-make-sure-that-string-is-valid-json-using-json-net
        private static bool IsValidJson(string strInput)
        {
            if (string.IsNullOrWhiteSpace(strInput)) { return false;}
            strInput = strInput.Trim();
            if ((strInput.StartsWith("{") && strInput.EndsWith("}")) || //For object
                (strInput.StartsWith("[") && strInput.EndsWith("]"))) //For array
            {
                try
                {
                    var obj = JToken.Parse(strInput);
                    return true;
                }
                catch (JsonReaderException jex)
                {
                    //Exception in parsing json
                    Console.WriteLine(jex.Message);
                    return false;
                }
                catch (Exception ex) //some other exception
                {
                    Console.WriteLine(ex.ToString());
                    return false;
                }
            }
            else
            {
                return false;
            }
        }

        // Handles incoming outputs from server
        private void ClientOnIncomingServerMessage(string serverOutput)
        {
            
            // If JSON is valid, this means this is our pure JSON input string for showing the list at the end
            if (IsValidJson(serverOutput))
            {
                _topAndLeastJson = serverOutput;
            }

            // Determine if server is starting new round and handle
            var processedOutput = JsonConvert.DeserializeObject(serverOutput);
            switch (processedOutput)
            {
                case GameInformation.NewRound when _waitingForHostStartGame:
                    hidePanel.Hide();
                    waitingForHostText.Hide();
                    _waitingForHostStartGame = false;
                    ShowButtonsAndHideText(true);
                    return;
                case GameInformation.NewRound:
                    ShowButtonsAndHideText(true);
                    return;
                case GameInformation.End:
                    BeginInvoke(new MethodInvoker(() => EndGame(_topAndLeastJson)));
                    return;
                default:
                    stateContainer.Text = processedOutput + @"?";
                    break;
            }
            
        }

        private void EndGame(string jsonList)
        {
            
            _endScreenForm = new EndScreen(jsonList);
            _endScreenForm.Closed += (s, ev) =>
            {
                Application.ExitThread();
                Environment.Exit(0);
            };
                
            _endScreenForm.FormClosed += (s, ev) =>
            {
                Application.ExitThread();
                Environment.Exit(0);
            };
            
            Hide();
            _endScreenForm.Show();
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