using Craftplacer.ClassicSuite.Wizards.Pages;

using System.ComponentModel;
using System.Threading;

namespace Craftplacer.ClassicSuite.Wizards.Example.Pages
{
    public partial class FirstPage : WizardPage
    {
        public FirstPage()
        {
            InitializeComponent();
            NextPage = new SecondPage();
        }

        private void Button_Click(object sender, System.EventArgs e)
        {
            // Disable buttons
            AllowedButtons = Enums.AllowedButtons.None;

            // Make sure our button is disabled too
            button.Enabled = false;

            // Run our work in the background
            backgroundWorker.RunWorkerAsync();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // Tells WizardForm to navigate forwards, basically click "Next" for us.
            OnNextPageRequested();
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            // Very important work.
            Thread.Sleep(3 * 1000);
        }
    }
}