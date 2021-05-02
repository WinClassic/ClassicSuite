using Craftplacer.ClassicSuite.Wizards.Example.Pages;
using Craftplacer.ClassicSuite.Wizards.Forms;
using Craftplacer.ClassicSuite.Wizards.Pages;

using System;
using System.Windows.Forms;

namespace Craftplacer.ClassicSuite.Wizards.Example
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        private static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            var wizard = WizardForm.FromList(new WizardPage[]
            {
    new StartPage(),
    new FirstPage(),
    new SecondPage(),
            });

            wizard.DefaultSidebarImage = Properties.Resources.sidebar;
            wizard.DefaultHeaderImage = Properties.Resources.head;

            Application.Run(wizard);
        }
    }
}