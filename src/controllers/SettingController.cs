using Interface;
using Model;
using Service;

namespace Controller {
    public class SettingController : ISettingController {
        public Setting s;

        public SettingController () {
            this.s = SettingHandler.DeserializedFromSettingFile();
        }

        public void InitDefaultSetting() {
            SettingHandler.InitSettingFile();
        }

        public void SaveSetting(Setting s) {
            SettingHandler.SerializedToSettingFile(s);
        }
    }
}