namespace Utils{

public class Logger {
    public static void Debug (string content) {
        System.Console.WriteLine($"{LoggerCode.Pick(Color.YELLOW)}[DEBUG]:\r\n{content}{LoggerCode.Pick(Color.NORMAL)}");
    }

    public static void Warn (string content) {
        System.Console.WriteLine($"{LoggerCode.Pick(Color.RED)}[WARN]:\r\n {content}{LoggerCode.Pick(Color.NORMAL)}");
    }
}
}