using System;
using System.Windows.Forms;

namespace PacMeaw
{
    internal static class Program
    {
        /// <summary>
        ///  The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            // To customize application configuration such as set high DPI settings or default font,
            // see https://aka.ms/applicationconfiguration.
            //ApplicationConfiguration.Initialize();
            //new Game().GameMain();

            ApplicationConfiguration.Initialize();

            // ���ҧ����ʴ�˹�� Home
            Home home = new Home();
            Application.Run(home);

        }
    }
}