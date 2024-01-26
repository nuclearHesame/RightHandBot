using RightHandBot.Models;
using RightHandBot.SettingJson;
using Telegram.Bot;

namespace RightHandBot
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private static string BotToken;
        private Thread BotThread;
        private TelegramBotClient Bot;

        private void Form1_Load(object sender, EventArgs e)
        {
            Settings settings = Serializer.ReadSettingJson();

            cmxToken.DataSource = settings.Bots.Select(bot => bot.APIToken).ToList();
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            
        }

        void runBot()
        {

        }
    }
}