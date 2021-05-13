using Craftplacer.ClassicSuite.Wizards.Enums;
using Craftplacer.ClassicSuite.Wizards.Pages;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace Craftplacer.ClassicSuite.Wizards.Forms
{
    public partial class WizardForm : Form
    {
        private readonly WizardPage initialPage;

        /// <summary>
        /// The navigation stack, it contains previous and current pages.
        /// </summary>
        private readonly Stack<WizardPage> pages = new Stack<WizardPage>();

        public WizardForm(WizardPage initialPage)
        {
            InitializeComponent();
            Icon = Properties.Resources.Wizard;
            this.initialPage = initialPage;
        }

        /// <summary>
        /// Default image used for pages that have their <see cref="WizardPage.PageParts"/> set to <see cref="PagePart.Header"/>.
        /// </summary>
        [Category("Appearance")]
        public Image DefaultHeaderImage { get; set; }

        /// <summary>
        /// Default image used for pages that have their <see cref="WizardPage.PageParts"/> set to <see cref="PagePart.Sidebar"/>.
        /// </summary>
        [Category("Appearance")]
        public Image DefaultSidebarImage { get; set; }

        /// <summary>
        /// The last page in the navigation stack, this is usually the current page that the user can see.
        /// </summary>
        private WizardPage LastPage => pages.Peek();

        public static WizardForm FromList(IEnumerable<WizardPage> pages)
        {
            if (pages is null)
            {
                throw new ArgumentNullException(nameof(pages));
            }

            var array = pages.ToArray();

            if (array.Length < 2)
            {
                throw new ArgumentException("The enumerable must have at least two pages.", nameof(pages));
            }

            for (int i = 1; i < array.Length; i++)
            {
                array[i - 1].NextPage = array[i];
            }

            return new WizardForm(array[0]);
        }

        /// <summary>
        /// Navigates to the previous page, this is equivalent to pressing the "Back" button.
        /// </summary>
        public void NavigateBackwards()
        {
            if (pages.Count < 2)
            {
                throw new InvalidOperationException("There are not enough pages in the page stack to be able to navigate backwards.");
            }

            PopPage();
            EnterPage(LastPage);
        }

        /// <summary>
        /// Navigates to the next page, this is equivalent to pressing the "Next" button.
        /// </summary>
        public void NavigateForwards()
        {
            Debug.WriteLine("Navigating to next page", "Wizard");
            var nextPage = LastPage.NextPage;
            if (nextPage == null)
            {
                Close();
            }
            else
            {
                LeavePage(LastPage);
                PushPage(nextPage);
            }
        }

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (pages.Count > 0)
            {
                NavigateBackwards();
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            CancelEventArgs args = new CancelEventArgs();

            LastPage.OnCancelRequested(args);

            if (args.Cancel)
            {
                return;
            }

            Close();
        }

        /// <summary>
        /// Subscribes a page and puts it into the foreground.
        /// </summary>
        private void EnterPage(WizardPage page)
        {
            Debug.WriteLine($"Entering {page}", "Wizard");

            page.BringToFront();

            // Update graphics
            UpdateSidebar(page);
            UpdateHeader(page);

            footerLabel.Text = page.FooterText ?? string.Empty;

            // Update buttons
            UpdateButtons();

            // Subscribe to events
            page.AllowedButtonsChanged += Page_AllowedButtonsChanged;
            page.ButtonTextChanged += Page_ButtonTextChanged;

            // Inform this page about the focus switch
            page.OnPageEnter();
        }

        /// <summary>
        /// Unsubscribes a page
        /// </summary>
        private void LeavePage(WizardPage page)
        {
            Debug.WriteLine($"Leaving {page}", "Wizard");
            page.OnPageLeave();

            // Unsubscribe from button changes from previous page
            page.AllowedButtonsChanged -= Page_AllowedButtonsChanged;
            page.ButtonTextChanged -= Page_ButtonTextChanged;
        }

        private void NextButton_Click(object sender, EventArgs e) => NavigateForwards();

        private void Page_AllowedButtonsChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void Page_ButtonTextChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        /// <summary>
        /// Leaves a page and removes it from the navigation stack afterwards.
        /// </summary>
        private void PopPage()
        {
            var page = pages.Pop();

            LeavePage(page);

            Debug.WriteLine($"Removing {page}", "Wizard");
            if (pagePanel.Controls.Contains(page))
            {
                pagePanel.Controls.Remove(page);
            }
        }

        /// <summary>
        /// Adds a page to the wizard and navigates to it.
        /// </summary>
        private void PushPage(WizardPage page)
        {
            Debug.WriteLine($"Adding {page}", "Wizard");

            pages.Push(page);

            // Add control if missing
            if (!pagePanel.Controls.Contains(page))
            {
                pagePanel.Controls.Add(page);
            }

            EnterPage(page);
        }

        private void UpdateBackButton()
        {
            var hasPreviousPage = pages.Count > 1;
            var buttonAllowed = LastPage.AllowedButtons.HasFlag(AllowedButton.Back);
            backButton.Enabled = hasPreviousPage && buttonAllowed;

            if (string.IsNullOrWhiteSpace(LastPage.BackButtonText))
            {
                cancelButton.Text = Properties.Resources.Back;
            }
            else
            {
                cancelButton.Text = LastPage.BackButtonText;
            }
        }

        private void UpdateButtons()
        {
            UpdateBackButton();
            UpdateNextButton();
            UpdateCancelButton();
        }

        private void UpdateCancelButton()
        {
            cancelButton.Enabled = LastPage.AllowedButtons.HasFlag(AllowedButton.Cancel);

            if (string.IsNullOrWhiteSpace(LastPage.CancelButtonText))
            {
                cancelButton.Text = Properties.Resources.Cancel;
            }
            else
            {
                cancelButton.Text = LastPage.CancelButtonText;
            }
        }

        private void UpdateHeader(WizardPage page)
        {
            var hasHeader = page.PageParts == PagePart.Header;

            if (header.Visible = hasHeader)
            {
                header.Title = page.Title;
                header.Subtitle = page.Subtitle ?? string.Empty;
                header.Image = page.HeaderImage ?? DefaultHeaderImage;
            }
        }

        private void UpdateNextButton()
        {
            nextButton.Enabled = LastPage.AllowedButtons.HasFlag(AllowedButton.Next);

            if (!string.IsNullOrWhiteSpace(LastPage.NextButtonText))
            {
                nextButton.Text = LastPage.NextButtonText;
            }
            else if (LastPage.NextPage == null)
            {
                nextButton.Text = Properties.Resources.Finish;
            }
            else
            {
                nextButton.Text = Properties.Resources.Next;
            }
        }

        private void UpdateSidebar(WizardPage page)
        {
            var hasSidebar = page.PageParts == PagePart.Sidebar;

            if (sidebarPictureBox.Visible = hasSidebar)
            {
                sidebarPictureBox.Image = page.SidebarImage ?? DefaultSidebarImage;
            }
        }

        private void WizardForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            // Clean up..?
            while (pages.Count > 0)
            {
                PopPage();
            }
        }

        private void WizardForm_Load(object sender, EventArgs e)
        {
            PushPage(initialPage);
        }
    }
}