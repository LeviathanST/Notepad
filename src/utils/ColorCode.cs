namespace Utils {
    public enum Color {
        RED,
        YELLOW,
        NORMAL
    }

    public class LoggerCode {
        public static string Pick (Color color) {
            switch (color)
            {
                case Color.YELLOW:
                    return "\x1b[93m";
                case Color.RED:
                    return "\x1b[91m";
                default:
                    return "\x1b[39m";

            }
        }
    }
}
