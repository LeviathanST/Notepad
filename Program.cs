using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Controller;
using Model;
using Service;
using Interface;
using System.Windows.Forms;

namespace app
{
    static class Program
    {
        // Entry point
        [STAThread]
        static void Main()
        {
            //SettingController sc = new SettingController();
            //DocumentController dc = new DocumentController(sc.s);
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}