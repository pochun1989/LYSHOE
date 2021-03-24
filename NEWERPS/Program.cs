using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace NEWERPS
{
    static class Program
    {
        /// <summary>
        /// 應用程式的主要進入點。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new ERPLogin());


        }
        static LanguageType _languageType = new LanguageType();

        internal static LanguageType LanguageType { get => _languageType; set => _languageType = value; }

        static User _user = new User();

        internal static User User { get => _user; set => _user = value; }

        static Modifytype _modifys = new Modifytype();

        internal static Modifytype Modifytype { get => _modifys; set => _modifys = value; }
    }
}
