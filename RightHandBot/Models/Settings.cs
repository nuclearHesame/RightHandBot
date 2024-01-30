

namespace RightHandBot.Models
{
    public class Settings
    {
        public List<Bot> Bots { get; set; }
        public List<string> Memberships { get; set; }
        public List<string> Hashtags { get; set; }
    }

    public class Bot
    {
        public string BotName { get; set; }
        public string APIToken { get; set; }
    }
}
