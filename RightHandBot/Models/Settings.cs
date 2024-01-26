

namespace RightHandBot.Models
{
    public class Settings
    {
        public List<Bot> Bots { get; set; }
    }

    public class Bot
    {
        public string BotName { get; set; }
        public string APIToken { get; set; }
    }
}
