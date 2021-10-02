namespace WhereWeLivin.Pages
{
    partial class GameClient
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GameClient));
            this.label1 = new System.Windows.Forms.Label();
            this.stateContainer = new System.Windows.Forms.Label();
            this.yesButton = new System.Windows.Forms.Button();
            this.maybeButton = new System.Windows.Forms.Button();
            this.noButton = new System.Windows.Forms.Button();
            this.waitLabel = new System.Windows.Forms.Label();
            this.hidePanel = new System.Windows.Forms.Panel();
            this.waitingForHostText = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.hidePanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.BackColor = System.Drawing.Color.Gainsboro;
            this.label1.Dock = System.Windows.Forms.DockStyle.Top;
            this.label1.Font = new System.Drawing.Font("Forte", 48F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.SystemColors.MenuText;
            this.label1.Image = ((System.Drawing.Image)(resources.GetObject("label1.Image")));
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(1082, 109);
            this.label1.TabIndex = 2;
            this.label1.Text = "WhereWeLivin?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // stateContainer
            // 
            this.stateContainer.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stateContainer.Location = new System.Drawing.Point(392, 482);
            this.stateContainer.Name = "stateContainer";
            this.stateContainer.Size = new System.Drawing.Size(288, 103);
            this.stateContainer.TabIndex = 3;
            this.stateContainer.Text = "Massachussets";
            this.stateContainer.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // yesButton
            // 
            this.yesButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.yesButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.yesButton.FlatAppearance.BorderSize = 0;
            this.yesButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.yesButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.yesButton.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.yesButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.yesButton.Image = ((System.Drawing.Image)(resources.GetObject("yesButton.Image")));
            this.yesButton.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.yesButton.Location = new System.Drawing.Point(73, 588);
            this.yesButton.Name = "yesButton";
            this.yesButton.Size = new System.Drawing.Size(206, 53);
            this.yesButton.TabIndex = 6;
            this.yesButton.Text = "Yes";
            this.yesButton.UseVisualStyleBackColor = false;
            this.yesButton.Click += new System.EventHandler(this.yesButton_Click);
            // 
            // maybeButton
            // 
            this.maybeButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.maybeButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.maybeButton.FlatAppearance.BorderSize = 0;
            this.maybeButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.maybeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.maybeButton.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.maybeButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.maybeButton.Image = ((System.Drawing.Image)(resources.GetObject("maybeButton.Image")));
            this.maybeButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.maybeButton.Location = new System.Drawing.Point(428, 588);
            this.maybeButton.Name = "maybeButton";
            this.maybeButton.Size = new System.Drawing.Size(206, 53);
            this.maybeButton.TabIndex = 7;
            this.maybeButton.Text = "Maybe";
            this.maybeButton.UseVisualStyleBackColor = false;
            this.maybeButton.Click += new System.EventHandler(this.maybeButton_Click);
            // 
            // noButton
            // 
            this.noButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.noButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.noButton.FlatAppearance.BorderSize = 0;
            this.noButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.noButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.noButton.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.noButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.noButton.Image = ((System.Drawing.Image)(resources.GetObject("noButton.Image")));
            this.noButton.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.noButton.Location = new System.Drawing.Point(784, 588);
            this.noButton.Name = "noButton";
            this.noButton.Size = new System.Drawing.Size(206, 53);
            this.noButton.TabIndex = 8;
            this.noButton.Text = "No";
            this.noButton.UseVisualStyleBackColor = false;
            this.noButton.Click += new System.EventHandler(this.noButton_Click);
            // 
            // waitLabel
            // 
            this.waitLabel.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitLabel.Location = new System.Drawing.Point(255, 565);
            this.waitLabel.Name = "waitLabel";
            this.waitLabel.Size = new System.Drawing.Size(566, 103);
            this.waitLabel.TabIndex = 9;
            this.waitLabel.Text = "You chose \"Yes!\". Waiting for host...";
            this.waitLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.waitLabel.Visible = false;
            // 
            // hidePanel
            // 
            this.hidePanel.Controls.Add(this.waitingForHostText);
            this.hidePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.hidePanel.Location = new System.Drawing.Point(0, 109);
            this.hidePanel.Name = "hidePanel";
            this.hidePanel.Size = new System.Drawing.Size(1082, 626);
            this.hidePanel.TabIndex = 11;
            // 
            // waitingForHostText
            // 
            this.waitingForHostText.Font = new System.Drawing.Font("Century Gothic", 21.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.waitingForHostText.Location = new System.Drawing.Point(86, 236);
            this.waitingForHostText.Name = "waitingForHostText";
            this.waitingForHostText.Size = new System.Drawing.Size(888, 103);
            this.waitingForHostText.TabIndex = 10;
            this.waitingForHostText.Text = "Connection Successful! Waiting for host to begin...";
            this.waitingForHostText.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureBox.Location = new System.Drawing.Point(187, 137);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(685, 353);
            this.pictureBox.TabIndex = 12;
            this.pictureBox.TabStop = false;
            this.pictureBox.Controls.Add(hidePanel);
            // 
            // GameClient
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1082, 735);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.hidePanel);
            this.Controls.Add(this.waitLabel);
            this.Controls.Add(this.noButton);
            this.Controls.Add(this.maybeButton);
            this.Controls.Add(this.yesButton);
            this.Controls.Add(this.stateContainer);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "GameClient";
            this.Text = "WhereWeLivin";
            this.hidePanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pictureBox;

        private System.Windows.Forms.Label waitingForHostText;

        private System.Windows.Forms.Panel hidePanel;
        
        private System.Windows.Forms.Label waitLabel;

        private System.Windows.Forms.Button yesButton;
        private System.Windows.Forms.Button noButton;

        private System.Windows.Forms.Label stateContainer;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button maybeButton;

        private System.Windows.Forms.TextBox textBox1;

        #endregion
    }
}