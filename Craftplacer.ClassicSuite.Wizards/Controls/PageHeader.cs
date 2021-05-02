using System.Drawing;
using System.Windows.Forms;

namespace Craftplacer.ClassicSuite.Wizards.Controls
{
    public partial class PageHeader : UserControl
    {
        public string Title
        {
            get => titleLabel.Text;
            set => titleLabel.Text = value;
        }

        public string Subtitle
        {
            get => subtitleLabel.Text;
            set => subtitleLabel.Text = value;
        }

        public Image Image
        {
            get => pictureBox.Image;
            set => pictureBox.Image = value;
        }

        public PageHeader()
        {
            InitializeComponent();
        }

        private void PageHeader_SizeChanged(object sender, System.EventArgs e)
        {
            pictureBox.Left = Width - 5 - pictureBox.Width;
            pictureBox.Top = 5;
        }
    }
}
