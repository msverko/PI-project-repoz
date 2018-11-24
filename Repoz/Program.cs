using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Repoz
{
    static class glob //place to put global variables (no instance on static class needed)
    {
        public static string loggedUser;
        public static string role;
        public static int passLevel;
        public static string ProjectName; //Active project
    }


static class Program
    {
        public static FormLogin formInstance;

    [STAThread]
        static void Main()
        {

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(formInstance = new FormLogin());
            
            

        }
    }
}
