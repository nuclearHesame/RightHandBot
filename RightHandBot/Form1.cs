using RightHandBot.Models;
using RightHandBot.JsonSerializer;
using System.Text;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

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
        Settings settings;

        private void Form1_Load(object sender, EventArgs e)
        {
            settings = (Settings) Serializer.ReadJson("Settings");

            cmxToken.Items.AddRange(settings.Bots.Select(bot => bot.APIToken).ToArray());
            ltxChatMemberShip.Items.AddRange(settings.Memberships.ToArray());
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

        void UpdateTokens(string botName, string token)
        {
            bool isTokenExixst = settings.Bots.Any(bot => bot.APIToken == token);
            if (!isTokenExixst)
            {
                settings.Bots.Add(new Bot
                {
                    APIToken = Token,
                    BotName = botName,
                });

                Serializer.WriteJson(settings);
            }
        }

        void RunBot(CancellationToken cancellationToken)
        {
            Bot = new TelegramBotClient(Token);

            User botInfo = Bot.GetMeAsync().Result;
            UpdateTokens(botInfo.FirstName, Token);

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

                    if (type == "Text")
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
                            case "/memberships":
                                {
                                    //member
                                }
                                break;
                            default:
                                {

                                }
                                break;
                        }
                    }
                    else if (type == "Audio")
                    {
                        InlineKeyboardMarkup vote = new InlineKeyboardMarkup(new[]
                        {
                            new[]
                            {
                                new InlineKeyboardButton("VoteKeyboardButton")
                                {

                                }
                            },
                            new[]
                            {
                                new InlineKeyboardButton("VoteKeyboardButton")
                                {

                                }
                            },
                            new[]
                            {
                                new InlineKeyboardButton("VoteKeyboardButton")
                                {

                                }
                            }
                        });

                        //Bot.SendTextMessageAsync(ChatID, "Enter:", replyMarkup: vote);
                    }



                }

            }
        }

        #region Chat

        private void btnAddChat_Click(object sender, EventArgs e)
        {
            string chatUsername = txtChat.Text.Trim();

            if (chatUsername.Length > 1)
            {
                if (chatUsername.StartsWith("@"))
                {
                    txtChat.Text = "@";
                    settings.Memberships.Add(chatUsername);
                    ltxChatMemberShip.Items.Add(chatUsername);

                    Serializer.WriteJson(settings);
                }
                else
                {
                    // message
                }
            }
            else
            {
                // message
            }
        }

        private void btnDeleteChat_Click(object sender, EventArgs e)
        {
            if (ltxChatMemberShip.SelectedItem != null)
            {
                string? selectedItem = ltxChatMemberShip.SelectedItem.ToString();

                if (selectedItem != null)
                {
                    settings.Memberships.Remove(selectedItem);
                    ltxChatMemberShip.Items.Remove(selectedItem);

                    Serializer.WriteJson(settings);
                }
            }
            else
            {
                // message
            }
        }

        #endregion


    }
}