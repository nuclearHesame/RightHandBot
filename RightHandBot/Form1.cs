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

        string SelectedChannel = "";
        string SelectedHashtag = "";
        int audioMessageId = 0;

        #region forming

        private void Form1_Load(object sender, EventArgs e)
        {
            settings = (Settings)Serializer.ReadJson("Settings");

            cmxToken.Items.AddRange(settings.Bots.Select(bot => bot.APIToken).ToArray());
            ltxChatMemberShip.Items.AddRange(settings.Memberships.ToArray());
            ltxHashtags.Items.AddRange(settings.Hashtags.ToArray());
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            cancellationTokenSource?.Cancel();
        }

        #endregion

        #region Buttons

        private void btnStart_Click(object sender, EventArgs e)
        {
            if (cmxToken.Text.Trim().Length >= 46)
            {
                Token = cmxToken.Text.Trim();
                cancellationTokenSource = new CancellationTokenSource();
                Thread BotThread = new Thread(() => RunBot(cancellationTokenSource.Token));
                BotThread.Start();

                btnStart.Enabled = false;
                btnStop.Enabled = true;
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

            btnStart.Enabled = true;
            btnStop.Enabled = false;
        }

        #endregion

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

                    string Id = Command.Id.ToString();


                    if (Command.CallbackQuery != null)
                    {
                        string id = Command.CallbackQuery.Id.ToString();
                        string? data = Command.CallbackQuery.Data.ToString();
                        string dateTime = Command.CallbackQuery.Message.Date.ToString("yyyy/MM/dd - HH:mm");

                        string name = Command.CallbackQuery.From.FirstName.ToString();
                        string chatId = Command.CallbackQuery.From.Id.ToString();
                        string username = Command.CallbackQuery.From.Username.ToString();

                        //selected channel
                        if (settings.Memberships.Any(channel => channel == data))
                        {
                            SelectedChannel = data;

                            int buttonCount = settings.Hashtags.Count;

                            var buttons = new InlineKeyboardButton[buttonCount][];
                            for (int i = 0; i < buttonCount; i++)
                            {
                                buttons[i] = new[]
                                {
                                    InlineKeyboardButton.WithCallbackData(settings.Hashtags[i], settings.Hashtags[i]),
                                };
                            }

                            var hashtag = new InlineKeyboardMarkup(buttons);

                            Bot.DeleteMessageAsync(chatId,audioMessageId+1);
                            Bot.SendTextMessageAsync(chatId, "Select the Hashtag you want:", replyMarkup: hashtag);
                        }
                        else if(settings.Hashtags.Any(hashtag => hashtag == data))
                        {
                            StringBuilder sb = new();
                            sb.AppendLine(data);
                            sb.AppendLine("");
                            sb.AppendLine(SelectedChannel);

                            Bot.EditMessageCaptionAsync(chatId,audioMessageId,sb.ToString());
                            Bot.ForwardMessageAsync(SelectedChannel,chatId,audioMessageId);
                        }

                    }

                    if (Command.Message != null)
                    {
                        int messageId = Command.Message.MessageId;
                        string type = Command.Message.Type.ToString();
                        string? command = Command.Message.Text?.ToLower();
                        string dateTime = Command.Message.Date.ToString("yyyy/MM/dd - HH:mm");

                        string chatID = Command.Message.Chat.Id.ToString();
                        string name = Command.Message.Chat.FirstName;
                        string? username = Command.Message.Chat.Username.ToString();


                        if (type == "Text")
                        {
                            switch (command)
                            {
                                case "/start":
                                    {
                                        StringBuilder sb = new();
                                        sb.Append("Hello there *").Append(name).Append("*✨");
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
                            int buttonCount = settings.Memberships.Count;

                            var buttons = new InlineKeyboardButton[buttonCount][];
                            for (int i = 0; i < buttonCount; i++)
                            {
                                buttons[i] = new[]
                                {
                                InlineKeyboardButton.WithCallbackData(settings.Memberships[i], settings.Memberships[i]),
                            };
                            }

                            var Channel = new InlineKeyboardMarkup(buttons);

                            audioMessageId = messageId;
                            Bot.SendTextMessageAsync(chatID, "Select the channel you want to send to.\n(The bot must be an administrator):", replyMarkup: Channel);
                        }

                    }

                }

            }
        }

        #region Chats

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

        #region Hashtags

        private void btnAddHashtag_Click(object sender, EventArgs e)
        {
            string hashtag = txtHashtag.Text.Trim();

            if (hashtag.Length > 1)
            {
                if (hashtag.StartsWith("#"))
                {
                    txtHashtag.Text = "#";
                    settings.Hashtags.Add(hashtag);
                    ltxHashtags.Items.Add(hashtag);

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

        private void btnDeleteHashtag_Click(object sender, EventArgs e)
        {
            if (ltxHashtags.SelectedItem != null)
            {
                string? selectedItem = ltxHashtags.SelectedItem.ToString();

                if (selectedItem != null)
                {
                    settings.Hashtags.Remove(selectedItem);
                    ltxHashtags.Items.Remove(selectedItem);

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