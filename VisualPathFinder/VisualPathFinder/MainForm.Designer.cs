namespace VisualPathFinder
{
    partial class MainForm
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
            this.newFieldBtn = new System.Windows.Forms.Button();
            this.findPathBtn = new System.Windows.Forms.Button();
            this.optionBox = new System.Windows.Forms.ListBox();
            this.drawingPanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // newFieldBtn
            // 
            this.newFieldBtn.Location = new System.Drawing.Point(698, 45);
            this.newFieldBtn.Name = "newFieldBtn";
            this.newFieldBtn.Size = new System.Drawing.Size(120, 49);
            this.newFieldBtn.TabIndex = 1;
            this.newFieldBtn.Text = "New Field";
            this.newFieldBtn.UseVisualStyleBackColor = true;
            this.newFieldBtn.Click += new System.EventHandler(this.newFieldBtn_Click);
            // 
            // findPathBtn
            // 
            this.findPathBtn.Location = new System.Drawing.Point(830, 45);
            this.findPathBtn.Name = "findPathBtn";
            this.findPathBtn.Size = new System.Drawing.Size(120, 49);
            this.findPathBtn.TabIndex = 2;
            this.findPathBtn.Text = "Find Path";
            this.findPathBtn.UseVisualStyleBackColor = true;
            this.findPathBtn.Click += new System.EventHandler(this.findPathBtn_Click);
            // 
            // optionBox
            // 
            this.optionBox.FormattingEnabled = true;
            this.optionBox.ItemHeight = 16;
            this.optionBox.Location = new System.Drawing.Point(698, 128);
            this.optionBox.Name = "optionBox";
            this.optionBox.Size = new System.Drawing.Size(252, 132);
            this.optionBox.TabIndex = 3;
            this.optionBox.SelectedIndexChanged += new System.EventHandler(this.optionBox_SelectedIndexChanged);
            // 
            // drawingPanel
            // 
            this.drawingPanel.Location = new System.Drawing.Point(12, 12);
            this.drawingPanel.Name = "drawingPanel";
            this.drawingPanel.Size = new System.Drawing.Size(456, 448);
            this.drawingPanel.TabIndex = 4;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(990, 619);
            this.Controls.Add(this.drawingPanel);
            this.Controls.Add(this.optionBox);
            this.Controls.Add(this.findPathBtn);
            this.Controls.Add(this.newFieldBtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "PathFinder";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button newFieldBtn;
        private System.Windows.Forms.Button findPathBtn;
        private System.Windows.Forms.ListBox optionBox;
        private System.Windows.Forms.Panel drawingPanel;
    }
}

