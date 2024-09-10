using System.Text.Json;
using Model;
using Utils;

namespace Service {
    public class SettingHandler {
        public static void InitSettingFile () {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "setting.json");
            using(File.Create(path)){};
            Setting s = new();
            string json = JsonSerializer.Serialize<Setting>(s);
            DocumentHandler.WriteToFile(path, json);
            Logger.Debug("Write!");
        }

        public static Setting DeserializedFromSettingFile () {
            string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "setting.json");
            if (!File.Exists(path)){
                InitSettingFile();
            };

            string json = DocumentHandler.LoadFromFile(path);
            Setting? s = JsonSerializer.Deserialize<Setting>(json);
            if (s == null) {

                throw new Exception("Cannot deserialize your setting file");
            }

            Logger.Debug("Load your setting successfully!");

            return s;
        }

        public static void SerializedToSettingFile (Setting s) {
            string pathFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "setting.json");
            using (StreamWriter sw = new StreamWriter(pathFile)) {
                string json = JsonSerializer.Serialize<Setting>(s);
                sw.WriteLine(json);
                Logger.Debug("Save your setting successfully!");
            }
        }
    }
}