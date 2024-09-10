using Model;

namespace Interface {
    public interface ISettingController {
        public void InitDefaultSetting();
        public void SaveSetting(Setting s);
    }
}