
namespace Craftplacer.ClassicSuite.Wizards.Forms
{
    partial class WizardForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonFlowPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.cancelButton = new System.Windows.Forms.Button();
            this.nextButton = new System.Windows.Forms.Button();
            this.backButton = new System.Windows.Forms.Button();
            this.pagePanel = new System.Windows.Forms.Panel();
            this.header = new Craftplacer.ClassicSuite.Wizards.Controls.PageHeader();
            this.divider = new Craftplacer.ClassicSuite.Wizards.Controls.Divider();
            this.sidebarPictureBox = new System.Windows.Forms.PictureBox();
            this.buttonFlowPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.sidebarPictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonFlowPanel
            // 
            this.buttonFlowPanel.Controls.Add(this.cancelButton);
            this.buttonFlowPanel.Controls.Add(this.nextButton);
            this.buttonFlowPanel.Controls.Add(this.backButton);
            this.buttonFlowPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.buttonFlowPanel.FlowDirection = System.Windows.Forms.FlowDirection.RightToLeft;
            this.buttonFlowPanel.Location = new System.Drawing.Point(0, 315);
            this.buttonFlowPanel.Name = "buttonFlowPanel";
            this.buttonFlowPanel.Padding = new System.Windows.Forms.Padding(0, 12, 10, 5);
            this.buttonFlowPanel.Size = new System.Drawing.Size(497, 45);
            this.buttonFlowPanel.TabIndex = 0;
            // 
            // cancelButton
            // 
            this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.cancelButton.Location = new System.Drawing.Point(412, 12);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 1;
            this.cancelButton.Text = global::Craftplacer.ClassicSuite.Wizards.Properties.Resources.Cancel;
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // nextButton
            // 
            this.nextButton.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.nextButton.Location = new System.Drawing.Point(327, 12);
            this.nextButton.Margin = new System.Windows.Forms.Padding(0);
            this.nextButton.Name = "nextButton";
            this.nextButton.Size = new System.Drawing.Size(75, 23);
            this.nextButton.TabIndex = 0;
            this.nextButton.Text = global::Craftplacer.ClassicSuite.Wizards.Properties.Resources.Next;
            this.nextButton.UseVisualStyleBackColor = true;
            this.nextButton.Click += new System.EventHandler(this.NextButton_Click);
            // 
            // backButton
            // 
            this.backButton.Location = new System.Drawing.Point(252, 12);
            this.backButton.Margin = new System.Windows.Forms.Padding(0);
            this.backButton.Name = "backButton";
            this.backButton.Size = new System.Drawing.Size(75, 23);
            this.backButton.TabIndex = 2;
            this.backButton.Text = global::Craftplacer.ClassicSuite.Wizards.Properties.Resources.Back;
            this.backButton.UseVisualStyleBackColor = true;
            this.backButton.Click += new System.EventHandler(this.BackButton_Click);
            // 
            // pagePanel
            // 
            this.pagePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pagePanel.Location = new System.Drawing.Point(164, 60);
            this.pagePanel.Name = "pagePanel";
            this.pagePanel.Size = new System.Drawing.Size(333, 253);
            this.pagePanel.TabIndex = 2;
            // 
            // header
            // 
            this.header.BackColor = System.Drawing.SystemColors.Window;
            this.header.Dock = System.Windows.Forms.DockStyle.Top;
            this.header.Image = null;
            this.header.Location = new System.Drawing.Point(164, 0);
            this.header.MaximumSize = new System.Drawing.Size(0, 60);
            this.header.MinimumSize = new System.Drawing.Size(0, 60);
            this.header.Name = "header";
            this.header.Size = new System.Drawing.Size(333, 60);
            this.header.Subtitle = "";
            this.header.TabIndex = 3;
            this.header.Title = "Title";
            // 
            // divider
            // 
            this.divider.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.divider.Location = new System.Drawing.Point(0, 313);
            this.divider.MaximumSize = new System.Drawing.Size(0, 2);
            this.divider.MinimumSize = new System.Drawing.Size(0, 2);
            this.divider.Name = "divider";
            this.divider.Size = new System.Drawing.Size(497, 2);
            this.divider.TabIndex = 1;
            // 
            // sidebarPictureBox
            // 
            this.sidebarPictureBox.Dock = System.Windows.Forms.DockStyle.Left;
            this.sidebarPictureBox.Location = new System.Drawing.Point(0, 0);
            this.sidebarPictureBox.Name = "sidebarPictureBox";
            this.sidebarPictureBox.Size = new System.Drawing.Size(164, 313);
            this.sidebarPictureBox.TabIndex = 4;
            this.sidebarPictureBox.TabStop = false;
            // 
            // WizardForm
            // 
            this.AcceptButton = this.nextButton;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.cancelButton;
            this.ClientSize = new System.Drawing.Size(497, 360);
            this.ControlBox = false;
            this.Controls.Add(this.pagePanel);
            this.Controls.Add(this.header);
            this.Controls.Add(this.sidebarPictureBox);
            this.Controls.Add(this.divider);
            this.Controls.Add(this.buttonFlowPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "WizardForm";
            this.ShowIcon = false;
            this.Text = "WizardForm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.WizardForm_FormClosed);
            this.Load += new System.EventHandler(this.WizardForm_Load);
            this.buttonFlowPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.sidebarPictureBox)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel buttonFlowPanel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button nextButton;
        private System.Windows.Forms.Button backButton;
        private Controls.Divider divider;
        private System.Windows.Forms.Panel pagePanel;
        private Controls.PageHeader header;
        private System.Windows.Forms.PictureBox sidebarPictureBox;
    }
}