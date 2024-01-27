using RightHandBot.Models;
using RightHandBot.SettingJson;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace RightHandBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string Token;
        private TelegramBotClient Bot;
        private CancellationTokenSource cancellationTokenSource;

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings settings = Serializer.ReadSettingJson();

            cmxToken.DataSource = settings.Bots.Select(bot => bot.APIToken).ToList();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmxToken.Text.Trim().Length >= 46)
            {
                Token = cmxToken.Text.Trim();
                cancellationTokenSource = new CancellationTokenSource();
                Thread BotThread = new Thread(() => RunBot(cancellationTokenSource.Token));
                BotThread.Start();
            }
            else
            {
                // message
            }
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            cancellationTokenSource?.Cancel();
            lblStatus.Text = "offline";
            lblStatus.ForeColor = System.Drawing.Color.Red;
        }

        void RunBot(CancellationToken cancellationToken)
        {
            Bot = new TelegramBotClient(Token);

            this.Invoke(new Action(() =>
            {
                lblStatus.Text = "Online";
                lblStatus.ForeColor = System.Drawing.Color.Green;
            }));

            int offset = 0;

            while (!cancellationToken.IsCancellationRequested)
            {
                Update[] Commands = Bot.GetUpdatesAsync(offset).Result;

                foreach (var Command in Commands)
                {
                    offset = Command.Id + 1;

                    if (Command.Message == null)
                        continue;

                    string id = Command.Id.ToString();

                    string type = Command.Message.Type.ToString();
                    int messageId = Command.Message.MessageId;
                    string? command = Command.Message.Text?.ToLower();
                    //DateTime dateTime = Command.Message.Date.ToString("yyyy/MM/dd - HH:mm");

                    string senderName = Command.Message.Chat.FirstName + Command.Message.Chat.LastName;
                    string? senderUsername = Command.Message.Chat.Username.ToString();
                    string chatID = Command.Message.Chat.Id.ToString();

                    if (type == "Message")
                    {
                        switch (command)
                        {
                            case "/start":
                                {
                                    StringBuilder sb = new();
                                    sb.Append("Hello there *").Append(senderName).Append("*✨");
                                    sb.Append("\n\n");
                                    sb.Append("How i can Help You⁉️");
                                    Bot.SendTextMessageAsync(chatID, sb.ToString(), parseMode: Telegram.Bot.Types.Enums.ParseMode.MarkdownV2);
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }
                    }
                    else if( type == "Audio")
                    {
                         
                    }



                }

            }
        }


    }
}