
namespace Craftplacer.ClassicSuite.Wizards.Controls
{
    partial class PageHeader
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.titleLabel = new System.Windows.Forms.Label();
            this.subtitleLabel = new System.Windows.Forms.Label();
            this.divider = new Craftplacer.ClassicSuite.Wizards.Controls.Divider();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.titleLabel.Location = new System.Drawing.Point(19, 9);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(32, 13);
            this.titleLabel.TabIndex = 2;
            this.titleLabel.Text = "Title";
            // 
            // subtitleLabel
            // 
            this.subtitleLabel.AutoSize = true;
            this.subtitleLabel.Location = new System.Drawing.Point(40, 24);
            this.subtitleLabel.Name = "subtitleLabel";
            this.subtitleLabel.Size = new System.Drawing.Size(0, 13);
            this.subtitleLabel.TabIndex = 5;
            // 
            // divider
            // 
            this.divider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.divider.Location = new System.Drawing.Point(0, 58);
            this.divider.MaximumSize = new System.Drawing.Size(0, 2);
            this.divider.MinimumSize = new System.Drawing.Size(0, 2);
            this.divider.Name = "divider";
            this.divider.Size = new System.Drawing.Size(497, 2);
            this.divider.TabIndex = 4;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(440, 8);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(49, 49);
            this.pictureBox.TabIndex = 3;
            this.pictureBox.TabStop = false;
            // 
            // PageHeader
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.Controls.Add(this.subtitleLabel);
            this.Controls.Add(this.divider);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.titleLabel);
            this.MinimumSize = new System.Drawing.Size(497, 58);
            this.Name = "PageHeader";
            this.Size = new System.Drawing.Size(497, 60);
            this.SizeChanged += new System.EventHandler(this.PageHeader_SizeChanged);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label titleLabel;
        private Divider divider;
        private System.Windows.Forms.Label subtitleLabel;
    }
}
