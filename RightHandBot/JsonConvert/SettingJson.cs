using Newtonsoft.Json;
using RightHandBot.Models;

namespace tdic.SettingJson
{
    public static class Serializer
    {
        public static void WriteSettingJson(Settings settingItem)
        {
            string jsonFileName = "Settings.json";

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(settingItem);

            using (var fileStream = new FileStream(jsonFileName, FileMode.Create))
            using (var streamWriter = new StreamWriter(fileStream))
            using (var jsonWriter = new JsonTextWriter(streamWriter))
            {
                jsonWriter.WriteRaw(json);
            }
        }

        public static Settings ReadSettingJson()
        {
            string jsonFileName = "Settings.json";

            string jsonText = File.ReadAllText(jsonFileName);
            Settings loadedSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(jsonText);

            return loadedSettings;
        }
    }
}
