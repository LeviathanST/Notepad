using Interface;
using Model;
using Service;

namespace Controller {
    public class SettingController : ISettingController {
        public void Init() {
            SettingHandler.InitSettingFile();
        }
        public void Deserialized() {
            SettingHandler.DeserializedFromSettingFile();
        }
        public void Serialized() {
            Setting s = new Setting();

            // TODO: logic when setting is changed

            SettingHandler.SerializedToSettingFile(s);
        }
    }
}