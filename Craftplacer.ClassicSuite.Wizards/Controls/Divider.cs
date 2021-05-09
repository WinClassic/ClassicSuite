using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Craftplacer.ClassicSuite.Wizards.Controls
{
    public class Divider : Control
    {
        private Orientation orientation = Orientation.Horizontal;

        public override Size MaximumSize
        {
            get
            {
                switch (Orientation)
                {
                    case Orientation.Horizontal:
                        return new Size(0, 2);

                    case Orientation.Vertical:
                        return new Size(2, 0);

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        public override Size MinimumSize
        {
            get
            {
                switch (Orientation)
                {
                    case Orientation.Horizontal:
                        return new Size(0, 2);

                    case Orientation.Vertical:
                        return new Size(2, 0);

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        [Category("Appearance")]
        [DefaultValue(Orientation.Horizontal)]
        public Orientation Orientation
        {
            get => orientation;
            set
            {
                orientation = value;
                Size = new Size(Size.Height, Size.Width);
            }
        }

        #region Hidden Properties

        [Bindable(false)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override Font Font => base.Font;

        [Bindable(false)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public override string Text => null;

        #endregion Hidden Properties

        protected override Size DefaultSize => new Size(16, 2);

        protected override void OnPaint(PaintEventArgs e)
        {
            var lightBrush = SystemBrushes.ControlLightLight;
            var darkBrush = SystemBrushes.ControlDark;

            e.Graphics.FillRectangle(lightBrush, 0, 0, Width, Height);
            e.Graphics.FillRectangle(darkBrush, 0, 0, Width - 1, Height - 1);
        }
    }
}