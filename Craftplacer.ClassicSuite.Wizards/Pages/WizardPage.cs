using Craftplacer.ClassicSuite.Wizards.Enums;
using Craftplacer.ClassicSuite.Wizards.Forms;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Craftplacer.ClassicSuite.Wizards.Pages
{
    public class WizardPage : UserControl
    {
        public override DockStyle Dock => DockStyle.Fill;

        /// <summary>
        /// The image that will be displayed in the header.
        /// </summary>
        [Category("Appearance")]
        public Image HeaderImage { get; set; }

        [Category("Appearance")]
        public virtual string Title { get; set; }

        [Category("Appearance")]
        public virtual string Subtitle { get; set; }

        #region Button Texts

        /// <summary>
        /// Text displayed on the back button of the wizard. If empty, it will display the default text.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("Text displayed on the back button of the wizard. If empty, it will display the default text.")]
        public virtual string BackButtonText
        {
            get => backButtonText;
            set
            {
                backButtonText = value;
                ButtonTextChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Text displayed on the next button of the wizard. If empty, it will display the default text.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("Text displayed on the next button of the wizard. If empty, it will display the default text.")]
        public virtual string NextButtonText
        {
            get => nextButtonText;
            set
            {
                nextButtonText = value;
                ButtonTextChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        /// <summary>
        /// Text displayed on the cancel button of the wizard. If empty, it will display the default text.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(null)]
        [Description("Text displayed on the cancel button of the wizard. If empty, it will display the default text.")]
        public virtual string CancelButtonText
        {
            get => cancelButtonText;
            set
            {
                cancelButtonText = value;
                ButtonTextChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        private string cancelButtonText;
        private string nextButtonText;
        private string backButtonText;

        public event EventHandler<EventArgs> ButtonTextChanged;

        #endregion Button Texts

        private PageParts pageParts = PageParts.None;

        // This will intentionally break code if pages are put into wrong Forms.
        public new WizardForm ParentForm => (WizardForm)base.ParentForm;

        /// <summary>
        /// What extra parts to show, this can range from sidebar imagery to a small header displaying the title.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(PageParts.None)]
        [Description("What extra parts to show, this can range from sidebar imagery to a small header displaying the title.")]
        public PageParts PageParts
        {
            get => pageParts;
            set
            {
                pageParts = value;
                Size = GetSize();
            }
        }

        /// <summary>
        /// The image that will be displayed in the sidebar.
        /// </summary>
        [Category("Appearance")]
        public Image SidebarImage { get; set; }

        #region Next Page

        /// <summary>
        /// The next page that will be displayed when the user clicks the next button. If set to <see cref="null"/>, the next button will be set to "Finish" and will cause the wizard to close.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WizardPage NextPage { get; set; }

        /// <summary>
        /// Occurs when this page requests its parent WizardForm to show the next page.
        /// </summary>
        public event EventHandler<EventArgs> NextPageRequested;

        /// <summary>
        /// Raises the <see cref="NextPageRequested"/> event.
        /// </summary>
        protected void OnNextPageRequested()
        {
            NextPageRequested?.Invoke(this, EventArgs.Empty);
        }

        #endregion Next Page

        #region Navigation Events

        /// <summary>
        /// Occurs when the parent WizardForm navigates to this page.
        /// </summary>
        public event EventHandler<EventArgs> EnterPage;

        /// <summary>
        /// Occurs when the parent WizardForm navigates away from this page.
        /// </summary>
        public event EventHandler<EventArgs> LeavePage;

        public void OnEnterPage()
        {
            EnterPage?.Invoke(this, EventArgs.Empty);
        }

        public void OnLeavePage()
        {
            LeavePage?.Invoke(this, EventArgs.Empty);
        }

        #endregion Navigation Events

        #region Buttons

        /// <summary>
        /// What buttons to enable, this can be updated at runtime and can be used for asynchronous operations.
        /// </summary>
        private AllowedButtons allowedButtons = AllowedButtons.All;

        [Category("Behavior")]
        public virtual AllowedButtons AllowedButtons
        {
            get => allowedButtons;
            set
            {
                allowedButtons = value;
                AllowedButtonsChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public event EventHandler<EventArgs> AllowedButtonsChanged;

        #endregion Buttons

        #region Sizing

        private Size GetSize()
        {
            switch (PageParts)
            {
                case PageParts.Header:
                    return new Size(497, 253);

                case PageParts.Sidebar:
                    return new Size(333, 313);

                default:
                    return new Size(497, 313);
            }
        }

        public override bool AutoSize => true;

        public override Size GetPreferredSize(Size proposedSize)
        {
            return GetSize();
        }

        #endregion Sizing
    }
}