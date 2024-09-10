using Controller;
using Model;

namespace app;

static class Program
{

    // Entry point
    [STAThread]
    static void Main()
    {

        SettingController sc = new SettingController();
        DocumentController dc = new DocumentController(sc.s);

        System.Console.WriteLine("Hello World!");
    }    
}