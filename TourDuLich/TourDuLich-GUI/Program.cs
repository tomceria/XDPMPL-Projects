using System;
using System.Collections.Generic;
using System.Windows.Forms;
using TourDuLich_GUI.DAL;
using TourDuLich_GUI.GUI;
using TourDuLich_GUI.BUS;

namespace TourDuLich_GUI
{
    static class Program {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main() {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainView());
        }
    }
}