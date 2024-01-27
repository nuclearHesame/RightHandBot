using Newtonsoft.Json;
using RightHandBot.Models;

namespace RightHandBot.JsonSerializer
{
    public static class Serializer
    {
        public static void WriteJson(object values)
        {
            string jsonFileName = values.GetType().Name + ".json";

            string json = Newtonsoft.Json.JsonConvert.SerializeObject(values);

            using (var fileStream = new FileStream(jsonFileName, FileMode.Create))
            using (var streamWriter = new StreamWriter(fileStream))
            using (var jsonWriter = new JsonTextWriter(streamWriter))
            {
                jsonWriter.WriteRaw(json);
            }
        }

        public static object ReadJson(string type)
        {
            string jsonFileName = type + ".json";


            string jsonText = File.ReadAllText(jsonFileName);
            Settings loadedSettings = Newtonsoft.Json.JsonConvert.DeserializeObject<Settings>(jsonText);

            return loadedSettings;
        }
    }
}
