namespace WhereWeLivin.Pages
{
    partial class HostEnter
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(HostEnter));
            this.connectedClientList = new System.Windows.Forms.ListView();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.startButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // connectedClientList
            // 
            this.connectedClientList.Alignment = System.Windows.Forms.ListViewAlignment.Left;
            this.connectedClientList.BackColor = System.Drawing.SystemColors.Window;
            this.connectedClientList.Font = new System.Drawing.Font("Century Gothic", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.connectedClientList.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
            this.connectedClientList.ImeMode = System.Windows.Forms.ImeMode.Off;
            this.connectedClientList.LabelWrap = false;
            this.connectedClientList.Location = new System.Drawing.Point(93, 152);
            this.connectedClientList.Name = "connectedClientList";
            this.connectedClientList.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.connectedClientList.Size = new System.Drawing.Size(339, 222);
            this.connectedClientList.TabIndex = 0;
            this.connectedClientList.Tag = "";
            this.connectedClientList.UseCompatibleStateImageBehavior = false;
            this.connectedClientList.View = System.Windows.Forms.View.SmallIcon;
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
            this.label1.Size = new System.Drawing.Size(527, 109);
            this.label1.TabIndex = 1;
            this.label1.Text = "WhereWeLivin?";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Century Gothic", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(0, 126);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(527, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Connected Clients";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // startButton
            // 
            this.startButton.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.startButton.FlatAppearance.BorderColor = System.Drawing.SystemColors.ButtonFace;
            this.startButton.FlatAppearance.BorderSize = 0;
            this.startButton.FlatAppearance.MouseDownBackColor = System.Drawing.SystemColors.ActiveCaption;
            this.startButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.startButton.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.startButton.ForeColor = System.Drawing.SystemColors.ControlText;
            this.startButton.Image = ((System.Drawing.Image)(resources.GetObject("startButton.Image")));
            this.startButton.ImageAlign = System.Drawing.ContentAlignment.TopRight;
            this.startButton.Location = new System.Drawing.Point(160, 409);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(206, 53);
            this.startButton.TabIndex = 6;
            this.startButton.Text = "Start Game";
            this.startButton.UseVisualStyleBackColor = false;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // HostEnter
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 505);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.connectedClientList);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "HostEnter";
            this.Text = "WhereWeLivin";
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.Button startButton;

        private System.Windows.Forms.Button connectButton;

        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Label label1;

        private System.Windows.Forms.ListView connectedClientList;

        private System.Windows.Forms.ListView listView1;

        private System.Windows.Forms.Button confirmButton;

        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.Button button1;

        private System.Windows.Forms.TextBox textBox1;

        #endregion
    }
}