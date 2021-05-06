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
    // TODO: Add Windows 9x style, see WizardStyle.cs
    public partial class WizardForm : Form
    {
        /// <summary>
        /// The navigation stack, it contains previous and current pages.
        /// </summary>
        private readonly Stack<WizardPage> pages = new Stack<WizardPage>();

        private readonly WizardPage initialPage;

        [Category("Appearance")]
        public Image DefaultSidebarImage { get; set; }

        [Category("Appearance")]
        public Image DefaultHeaderImage { get; set; }

        public WizardForm(WizardPage initialPage)
        {
            InitializeComponent();
            Icon = Properties.Resources.Wizard;
            this.initialPage = initialPage;
        }

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
        /// The last page in the navigation stack, this is usually the current page that the user can see.
        /// </summary>
        private WizardPage LastPage => pages.Peek();

        #region Page Management Methods

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

            // Update buttons
            UpdateButtons();

            // Subscribe to events
            page.AllowedButtonsChanged += Page_AllowedButtonsChanged;
            page.NextPageRequested += Page_NextPageRequested;

            // Inform this page about the focus switch
            page.OnEnterPage();
        }

        /// <summary>
        /// Unsubscribes a page
        /// </summary>
        private void LeavePage(WizardPage page)
        {
            Debug.WriteLine($"Leaving {page}", "Wizard");
            page.OnLeavePage();

            // Unsubscribe from button changes from previous page
            page.AllowedButtonsChanged -= Page_AllowedButtonsChanged;
            page.NextPageRequested -= Page_NextPageRequested;
        }

        /// <summary>
        /// Navigates to the next page, this is equivalent to pressing the "Next" button.
        /// </summary>
        private void NavigateToNextPage()
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

        #endregion Page Management Methods

        #region Page Events

        private void Page_AllowedButtonsChanged(object sender, EventArgs e)
        {
            UpdateButtons();
        }

        private void UpdateButtons()
        {
            UpdateBackButton();
            UpdateNextButton();
            UpdateCancelButton();
        }

        private void Page_NextPageRequested(object sender, EventArgs e)
        {
            Debug.WriteLine($"{LastPage} requested to navigate forward", "Wizard");
            NavigateToNextPage();
        }

        #endregion Page Events

        #region Form Events

        private void BackButton_Click(object sender, EventArgs e)
        {
            if (pages.Count > 0)
            {
                PopPage();
                EnterPage(LastPage);
            }
        }

        private void CancelButton_Click(object sender, EventArgs e) => Close();

        private void NextButton_Click(object sender, EventArgs e) => NavigateToNextPage();

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

        #endregion Form Events

        #region Update Methods

        private void UpdateBackButton()
        {
            var hasPreviousPage = pages.Count > 1;
            var buttonAllowed = LastPage.AllowedButtons.HasFlag(AllowedButtons.Back);
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

        private void UpdateCancelButton()
        {
            cancelButton.Enabled = LastPage.AllowedButtons.HasFlag(AllowedButtons.Cancel);

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
            var hasHeader = page.PageParts == PageParts.Header;

            if (header.Visible = hasHeader)
            {
                header.Title = page.Title;
                header.Subtitle = page.Subtitle ?? string.Empty;
                header.Image = page.HeaderImage ?? DefaultHeaderImage;
            }
        }

        private void UpdateNextButton()
        {
            nextButton.Enabled = LastPage.AllowedButtons.HasFlag(AllowedButtons.Next);

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
            var hasSidebar = page.PageParts == PageParts.Sidebar;

            if (sidebarPictureBox.Visible = hasSidebar)
            {
                sidebarPictureBox.Image = page.SidebarImage ?? DefaultSidebarImage;
            }
        }

        #endregion Update Methods
    }
}