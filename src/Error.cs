using Utils;
namespace Error{
    public class IsDirectoryException : Exception {
        public IsDirectoryException (string content) {
            Logger.Warn($"[EXCEPTION] {content}");
        } 
    }

    public class MissingSettingFileException : Exception {
        public MissingSettingFileException () {
            Logger.Warn($"[EXCEPTION] Your setting file is missed");
        }
    }
}
