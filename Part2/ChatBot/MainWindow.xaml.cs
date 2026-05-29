using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ChatBot
{
    delegate string Chat(string message);
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        // Memory for user name and current topic
        private string currentTopic = "";
        private string userName = "";
        private string favoriteTopic = "";
        public MainWindow()
        {
            
            Sound wav = new Sound();
            wav.PlaySound();
            InitializeComponent();

            ASCII(@"

   _____      _                                        _ _                                                             
  / ____|    | |                                      (_) |             /\                                             
 | |    _   _| |__   ___ _ __ ___  ___  ___ _   _ _ __ _| |_ _   _     /  \__      ____ _ _ __ ___ _ __   ___  ___ ___ 
 | |   | | | | '_ \ / _ \ '__/ __|/ _ \/ __| | | | '__| | __| | | |   / /\ \ \ /\ / / _` | '__/ _ \ '_ \ / _ \/ __/ __|
 | |___| |_| | |_) |  __/ |  \__ \  __/ (__| |_| | |  | | |_| |_| |  / ____ \ V  V / (_| | | |  __/ | | |  __/\__ \__ \
  \_____\__, |_.__/ \___|_|  |___/\___|\___|\__,_|_|  |_|\__|\__, | /_/    \_\_/\_/ \__,_|_|  \___|_| |_|\___||___/___/
         __/ |                                                __/ |                                                    
        |___/                                                |___/                                                     

");


            addBotMessage(
                "Welcome to the Cybersecurity Awareness Bot! Type 'exit' to quit."
            );

            addBotMessage(
                "Please Type your Name: "
            );
        }

        
        private void addUserMessage(string message)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = "You: " + message;
            item.Background = Brushes.MediumSeaGreen;
            item.Foreground = Brushes.White;
            item.Width = 500;
            item.Padding = new Thickness(10);
            item.HorizontalAlignment = HorizontalAlignment.Right;

            Listchat.Items.Add(item);
        }
        private void addBotMessage(string message)
        {
            ListBoxItem item = new ListBoxItem();
            item.Content = "ChatBot: " + message;
            item.Background = Brushes.DarkViolet;
            item.Foreground = Brushes.White;
            item.Width = 700;
            item.Padding = new Thickness(10);
            item.HorizontalAlignment = HorizontalAlignment.Left;

            Listchat.Items.Add(item);
        }
        private void ASCII(string message)
        {
            ListBoxItem item = new ListBoxItem();

            item.Content = message;

            item.FontFamily = new FontFamily("Consolas");
            item.FontSize = 10;

            item.Foreground = Brushes.Black;
            item.Background = Brushes.AliceBlue;

            item.Width = 700;

            item.HorizontalContentAlignment = HorizontalAlignment.Center;

            Listchat.Items.Add(item);
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            string message = txtMessage.Text.Trim().ToLower();

            if (string.IsNullOrWhiteSpace(message))
            {
                MessageBox.Show("Please type a message");
                return;
            }
            addUserMessage(message);

            // EXIT FEATURE
            if (message.ToLower() == "exit")
            {
                addBotMessage(
                    "Goodbye! Stay safe online."
                );

                Application.Current.Shutdown();

                return;
            }
            // SAVE USER NAME
            if (string.IsNullOrWhiteSpace(userName))
            {
                userName = message;
               

                addBotMessage(
                    "Hello " +
                    userName + "!"
                );

                txtMessage.Clear();

                return;
            }

            // CONVERSATION FLOW
            if (message.ToLower()
                .Contains("tell me more") || message.ToLower().Contains("Give me another tip"))
            {
                if (currentTopic == "password")
                {
                    addBotMessage(
                        "Another password tip is to never reuse passwords."
                    );
                }
                else if (currentTopic == "privacy")
                {
                    addBotMessage(
                        "Another privacy tip is to avoid oversharing online."
                    );
                }
                else if (currentTopic == "phishing")
                {
                    addBotMessage(
                        "Always verify suspicious email senders. "
                    );
                }
                else
                {
                    addBotMessage(
                        "Please ask about a cybersecurity topic first. Password, privacy, or phishing."
                    );
                }

                txtMessage.Clear();
                return;
            }

            // SAVE CURRENT TOPIC
            if (message.ToLower().Contains("password"))
            {
                currentTopic = "password";
            }

            if (message.ToLower().Contains("privacy"))
            {
                currentTopic = "privacy";
            }

            if (message.ToLower().Contains("phishing"))
            {
                currentTopic = "phishing";
            }
            // SAVE FAVORITE TOPIC
            if (message.ToLower().Contains("interested in"))
            {
                favoriteTopic =
          message.Replace(
              "interested in",
              ""
          ).Trim();
                addBotMessage(
                    "Great! I'll remember that you're interested in " + favoriteTopic + ". It's crucial a part of staying safe online."
                );
            }

            // CHATBOT RESPONSE
            string botReply =
     ChatMessage.BotReply(message);
            addBotMessage(botReply);
            txtMessage.Clear(); txtMessage.Focus();
        }
        private void ClearButtonClick(object sender, RoutedEventArgs e)
        {
            Listchat.Items.Clear();
        }
    }
    }
    


