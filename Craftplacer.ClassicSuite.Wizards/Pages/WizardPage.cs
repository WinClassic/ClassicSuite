using Craftplacer.ClassicSuite.Wizards.Enums;
using Craftplacer.ClassicSuite.Wizards.Exceptions;
using Craftplacer.ClassicSuite.Wizards.Forms;

using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Craftplacer.ClassicSuite.Wizards.Pages
{
    public class WizardPage : UserControl
    {
        private AllowedButton allowedButtons = AllowedButton.All;
        private string backButtonText;
        private string cancelButtonText;
        private string nextButtonText;
        private PagePart pageParts = PagePart.None;

        /// <summary>
        /// Occurs when the <see cref="AllowedButtons"/> property changes.
        /// </summary>
        [Description("Occurs when the AllowedButtons property changes.")]
        public event EventHandler<EventArgs> AllowedButtonsChanged;

        /// <summary>
        /// Occurs when either the <see cref="BackButtonText"/>, <see cref="NextButtonText"/> or <see cref="CancelButtonText"/> property changes.
        /// </summary>
        public event EventHandler<EventArgs> ButtonTextChanged;

        /// <summary>
        /// Occurs when the parent <see cref="WizardForm"/> tries to cancel the wizard process.
        /// </summary>
        [Description("Occurs when the parent WizardForm tries to cancel the wizard process.")]
        public event CancelEventHandler CancellationRequested;

        /// <summary>
        /// Occurs when the parent <see cref="WizardForm"/> navigates to this page.
        /// </summary>
        [Description("Occurs when the parent WizardForm navigates to this page.")]
        public event EventHandler<EventArgs> PageEnter;

        /// <summary>
        /// Occurs when the parent <see cref="WizardForm"/> navigates away from this page.
        /// </summary>
        [Description("Occurs when the parent WizardForm navigates away from this page.")]
        public event EventHandler<EventArgs> PageLeave;

        /// <summary>
        /// Indicates what buttons are enabled. This can be updated at runtime and can be used for asynchronous operations.
        /// </summary>
        [Category("Behavior")]
        [Description("Indicates what buttons are enabled. This can be updated at runtime and can be used for asynchronous operations.")]
        public virtual AllowedButton AllowedButtons
        {
            get => allowedButtons;
            set
            {
                allowedButtons = value;
                AllowedButtonsChanged?.Invoke(this, EventArgs.Empty);
            }
        }

        public override bool AutoSize => true;

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

        public override DockStyle Dock => DockStyle.Fill;

        /// <summary>
        /// The text that appears in the footer beside the buttons.
        /// </summary>
        [Category("Appearance")]
        [Description("The text that appears in the footer beside the buttons.")]
        public virtual string FooterText { get; set; }

        /// <summary>
        /// The image used for the header when <see cref="PageParts"/> is set to <see cref="PagePart.Header"/>.
        /// </summary>
        [Category("Appearance")]
        [Description("The image used for the header when PageParts is set to Header.")]
        public Image HeaderImage { get; set; }

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
        /// The next page that will be displayed when the user clicks the next button. If set to <see cref="null"/>, the next button will be set to "Finish" and will cause the wizard to close.
        /// </summary>
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public WizardPage NextPage { get; set; }

        /// <summary>
        /// What extra parts to show, this can range from sidebar imagery to a small header displaying the title.
        /// </summary>
        [Category("Appearance")]
        [DefaultValue(PagePart.None)]
        [Description("What extra parts to show, this can range from sidebar imagery to a small header displaying the title.")]
        public PagePart PageParts
        {
            get => pageParts;
            set
            {
                pageParts = value;
                Size = GetSize();
            }
        }

        /// <summary>
        /// The image used for the sidebar when <see cref="PageParts"/> is set to <see cref="PagePart.Sidebar"/>.
        /// </summary>
        [Category("Appearance")]
        [Description("The image used for the sidebar when PageParts is set to Sidebar.")]
        public Image SidebarImage { get; set; }

        /// <summary>
        /// The subtitle that appears under the title in the header.
        /// </summary>
        [Category("Appearance")]
        [Description("The subtitle that appears under the title in the header.")]
        public virtual string Subtitle { get; set; }

        /// <summary>
        /// The title that appears in the header.
        /// </summary>
        [Category("Appearance")]
        [Description("The title that appears in the header.")]
        public virtual string Title { get; set; }

        public override Size GetPreferredSize(Size proposedSize)
        {
            return GetSize();
        }

        /// <summary>
        /// Raises the <see cref="WizardPage.CancellationRequested"/> event.
        /// </summary>
        public void OnCancelRequested(CancelEventArgs e)
        {
            CancellationRequested?.Invoke(this, e);
        }

        /// <summary>
        /// Raises the <see cref="WizardPage.PageEnter"/> event.
        /// </summary>
        public void OnPageEnter()
        {
            PageEnter?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Raises the <see cref="WizardPage.PageLeave"/> event.
        /// </summary>
        public void OnPageLeave()
        {
            PageLeave?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>
        /// Invokes the ParentForm to navigate forwards.
        /// </summary>
        protected void OnNextPageRequested()
        {
            if (ParentForm is WizardForm wizard)
            {
                wizard.NavigateForwards();
            }
            else
            {
                throw new InvalidParentFormException($"The operation is invalid because the {nameof(ParentForm)} is not of type {typeof(WizardForm)}");
            }
        }

        /// <summary>
        /// Invokes the ParentForm to navigate backwards.
        /// </summary>
        protected void OnPreviousPageRequested()
        {
            if (ParentForm is WizardForm wizard)
            {
                wizard.NavigateBackwards();
            }
            else
            {
                throw new InvalidParentFormException($"The operation is invalid because the {nameof(ParentForm)} is not of type {typeof(WizardForm)}");
            }
        }

        private Size GetSize()
        {
            switch (PageParts)
            {
                case PagePart.Header:
                    return new Size(497, 253);

                case PagePart.Sidebar:
                    return new Size(333, 313);

                default:
                    return new Size(497, 313);
            }
        }
    }
}