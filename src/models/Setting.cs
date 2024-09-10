using System.Text.Json.Serialization;

namespace Model {
        public class Setting {
        
        [JsonPropertyName("workingDirectory")]
        public string WorkingDirectory{get; set;}

        [JsonPropertyName("isAlwaysAskWorkingDirectory")]
        public bool IsAlwaysAskWorkingDirectory {get; set;}

        public Setting () {
            this.WorkingDirectory = "Desktop";
            this.IsAlwaysAskWorkingDirectory = false;
        }
    }
}