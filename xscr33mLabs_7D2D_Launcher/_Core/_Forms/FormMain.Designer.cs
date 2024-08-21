namespace xscr33mLabs_7D2D_Launcher
{
    partial class FormMain
    {
        /// <summary>
        /// Erforderliche Designervariable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Verwendete Ressourcen bereinigen.
        /// </summary>
        /// <param name="disposing">True, wenn verwaltete Ressourcen gelöscht werden sollen; andernfalls False.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Vom Windows Form-Designer generierter Code

        /// <summary>
        /// Erforderliche Methode für die Designerunterstützung.
        /// Der Inhalt der Methode darf nicht mit dem Code-Editor geändert werden.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.PanelTitle = new System.Windows.Forms.Panel();
            this.PanelHeader = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.PanelLauncher = new System.Windows.Forms.Panel();
            this.PanelFooter = new System.Windows.Forms.Panel();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelButtons = new System.Windows.Forms.Panel();
            this.ButtonMods = new FontAwesome.Sharp.IconButton();
            this.ButtonJoin = new FontAwesome.Sharp.IconButton();
            this.PanelTextBoxes = new System.Windows.Forms.Panel();
            this.ButtonShowPass = new FontAwesome.Sharp.IconButton();
            this.LabelPassword = new System.Windows.Forms.Label();
            this.TextBoxPass = new System.Windows.Forms.TextBox();
            this.LabelGamePath = new System.Windows.Forms.Label();
            this.TextBoxGamePath = new System.Windows.Forms.TextBox();
            this.LabelPort = new System.Windows.Forms.Label();
            this.TextBoxPort = new System.Windows.Forms.TextBox();
            this.LabelIP = new System.Windows.Forms.Label();
            this.TextBoxIP = new System.Windows.Forms.TextBox();
            this.PanelTitle.SuspendLayout();
            this.PanelHeader.SuspendLayout();
            this.PanelLauncher.SuspendLayout();
            this.PanelFooter.SuspendLayout();
            this.PanelButtons.SuspendLayout();
            this.PanelTextBoxes.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelTitle
            // 
            this.PanelTitle.Controls.Add(this.PanelHeader);
            this.PanelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTitle.Location = new System.Drawing.Point(0, 0);
            this.PanelTitle.Margin = new System.Windows.Forms.Padding(4);
            this.PanelTitle.Name = "PanelTitle";
            this.PanelTitle.Padding = new System.Windows.Forms.Padding(5);
            this.PanelTitle.Size = new System.Drawing.Size(380, 115);
            this.PanelTitle.TabIndex = 1;
            // 
            // PanelHeader
            // 
            this.PanelHeader.BackgroundImage = global::xscr33mLabs_7D2D_Launcher.Properties.Resources.Header;
            this.PanelHeader.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.PanelHeader.Controls.Add(this.label1);
            this.PanelHeader.Controls.Add(this.label3);
            this.PanelHeader.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelHeader.Location = new System.Drawing.Point(5, 5);
            this.PanelHeader.Margin = new System.Windows.Forms.Padding(4);
            this.PanelHeader.Name = "PanelHeader";
            this.PanelHeader.Size = new System.Drawing.Size(370, 105);
            this.PanelHeader.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Noto Sans", 9F);
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(131)))), ((int)(((byte)(115)))));
            this.label1.Location = new System.Drawing.Point(97, 70);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(174, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "Launcher for modded Servers";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Noto Sans", 8F);
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(131)))), ((int)(((byte)(115)))));
            this.label3.Location = new System.Drawing.Point(324, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "v1.0.0.0";
            // 
            // PanelLauncher
            // 
            this.PanelLauncher.Controls.Add(this.PanelFooter);
            this.PanelLauncher.Controls.Add(this.PanelButtons);
            this.PanelLauncher.Controls.Add(this.PanelTextBoxes);
            this.PanelLauncher.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelLauncher.Location = new System.Drawing.Point(0, 115);
            this.PanelLauncher.Name = "PanelLauncher";
            this.PanelLauncher.Size = new System.Drawing.Size(380, 342);
            this.PanelLauncher.TabIndex = 2;
            // 
            // PanelFooter
            // 
            this.PanelFooter.Controls.Add(this.label4);
            this.PanelFooter.Controls.Add(this.label2);
            this.PanelFooter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelFooter.Location = new System.Drawing.Point(0, 306);
            this.PanelFooter.Name = "PanelFooter";
            this.PanelFooter.Size = new System.Drawing.Size(380, 36);
            this.PanelFooter.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Noto Sans", 8F);
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(131)))), ((int)(((byte)(115)))));
            this.label4.Location = new System.Drawing.Point(255, 12);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(113, 15);
            this.label4.TabIndex = 3;
            this.label4.Text = "© xscr33mLabs 2024";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Noto Sans", 8F);
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(152)))), ((int)(((byte)(131)))), ((int)(((byte)(115)))));
            this.label2.Location = new System.Drawing.Point(12, 12);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Made with ♥";
            // 
            // PanelButtons
            // 
            this.PanelButtons.Controls.Add(this.ButtonMods);
            this.PanelButtons.Controls.Add(this.ButtonJoin);
            this.PanelButtons.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelButtons.Location = new System.Drawing.Point(0, 141);
            this.PanelButtons.Name = "PanelButtons";
            this.PanelButtons.Padding = new System.Windows.Forms.Padding(5);
            this.PanelButtons.Size = new System.Drawing.Size(380, 165);
            this.PanelButtons.TabIndex = 14;
            // 
            // ButtonMods
            // 
            this.ButtonMods.BackColor = System.Drawing.Color.Transparent;
            this.ButtonMods.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.ButtonMods.Enabled = false;
            this.ButtonMods.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ButtonMods.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ButtonMods.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ButtonMods.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonMods.Font = new System.Drawing.Font("Noto Sans", 14F);
            this.ButtonMods.ForeColor = System.Drawing.Color.White;
            this.ButtonMods.IconChar = FontAwesome.Sharp.IconChar.Sync;
            this.ButtonMods.IconColor = System.Drawing.Color.Khaki;
            this.ButtonMods.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ButtonMods.IconSize = 70;
            this.ButtonMods.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ButtonMods.Location = new System.Drawing.Point(5, 85);
            this.ButtonMods.Name = "ButtonMods";
            this.ButtonMods.Size = new System.Drawing.Size(370, 75);
            this.ButtonMods.TabIndex = 3;
            this.ButtonMods.Text = "Mods aktualisieren";
            this.ButtonMods.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonMods.UseVisualStyleBackColor = false;
            this.ButtonMods.Click += new System.EventHandler(this.LoadServerMods);
            // 
            // ButtonJoin
            // 
            this.ButtonJoin.BackColor = System.Drawing.Color.Transparent;
            this.ButtonJoin.Dock = System.Windows.Forms.DockStyle.Top;
            this.ButtonJoin.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ButtonJoin.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ButtonJoin.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ButtonJoin.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonJoin.Font = new System.Drawing.Font("Noto Sans", 14F);
            this.ButtonJoin.ForeColor = System.Drawing.Color.White;
            this.ButtonJoin.IconChar = FontAwesome.Sharp.IconChar.Play;
            this.ButtonJoin.IconColor = System.Drawing.Color.MediumSeaGreen;
            this.ButtonJoin.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ButtonJoin.IconSize = 70;
            this.ButtonJoin.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.ButtonJoin.Location = new System.Drawing.Point(5, 5);
            this.ButtonJoin.Name = "ButtonJoin";
            this.ButtonJoin.Size = new System.Drawing.Size(370, 75);
            this.ButtonJoin.TabIndex = 2;
            this.ButtonJoin.Text = "Server beitreten";
            this.ButtonJoin.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonJoin.UseVisualStyleBackColor = false;
            this.ButtonJoin.Click += new System.EventHandler(this.ButtonJoin_Click);
            // 
            // PanelTextBoxes
            // 
            this.PanelTextBoxes.Controls.Add(this.ButtonShowPass);
            this.PanelTextBoxes.Controls.Add(this.LabelPassword);
            this.PanelTextBoxes.Controls.Add(this.TextBoxPass);
            this.PanelTextBoxes.Controls.Add(this.LabelGamePath);
            this.PanelTextBoxes.Controls.Add(this.TextBoxGamePath);
            this.PanelTextBoxes.Controls.Add(this.LabelPort);
            this.PanelTextBoxes.Controls.Add(this.TextBoxPort);
            this.PanelTextBoxes.Controls.Add(this.LabelIP);
            this.PanelTextBoxes.Controls.Add(this.TextBoxIP);
            this.PanelTextBoxes.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelTextBoxes.Location = new System.Drawing.Point(0, 0);
            this.PanelTextBoxes.Name = "PanelTextBoxes";
            this.PanelTextBoxes.Size = new System.Drawing.Size(380, 141);
            this.PanelTextBoxes.TabIndex = 15;
            // 
            // ButtonShowPass
            // 
            this.ButtonShowPass.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ButtonShowPass.BackColor = System.Drawing.Color.Transparent;
            this.ButtonShowPass.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ButtonShowPass.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(30)))), ((int)(((byte)(30)))));
            this.ButtonShowPass.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(20)))), ((int)(((byte)(20)))), ((int)(((byte)(20)))));
            this.ButtonShowPass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ButtonShowPass.Font = new System.Drawing.Font("Noto Sans", 14F);
            this.ButtonShowPass.ForeColor = System.Drawing.Color.White;
            this.ButtonShowPass.IconChar = FontAwesome.Sharp.IconChar.LowVision;
            this.ButtonShowPass.IconColor = System.Drawing.Color.White;
            this.ButtonShowPass.IconFont = FontAwesome.Sharp.IconFont.Auto;
            this.ButtonShowPass.IconSize = 20;
            this.ButtonShowPass.Location = new System.Drawing.Point(342, 71);
            this.ButtonShowPass.Name = "ButtonShowPass";
            this.ButtonShowPass.Size = new System.Drawing.Size(26, 26);
            this.ButtonShowPass.TabIndex = 21;
            this.ButtonShowPass.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.ButtonShowPass.UseVisualStyleBackColor = false;
            this.ButtonShowPass.MouseDown += new System.Windows.Forms.MouseEventHandler(this.ButtonShowPass_MouseDown);
            this.ButtonShowPass.MouseLeave += new System.EventHandler(this.ButtonShowPass_MouseLeave);
            this.ButtonShowPass.MouseUp += new System.Windows.Forms.MouseEventHandler(this.ButtonShowPass_MouseUp);
            // 
            // LabelPassword
            // 
            this.LabelPassword.AutoSize = true;
            this.LabelPassword.ForeColor = System.Drawing.Color.White;
            this.LabelPassword.Location = new System.Drawing.Point(12, 74);
            this.LabelPassword.Name = "LabelPassword";
            this.LabelPassword.Size = new System.Drawing.Size(73, 19);
            this.LabelPassword.TabIndex = 20;
            this.LabelPassword.Text = "Passwort:";
            // 
            // TextBoxPass
            // 
            this.TextBoxPass.Location = new System.Drawing.Point(105, 71);
            this.TextBoxPass.Name = "TextBoxPass";
            this.TextBoxPass.Size = new System.Drawing.Size(235, 26);
            this.TextBoxPass.TabIndex = 19;
            this.TextBoxPass.UseSystemPasswordChar = true;
            this.TextBoxPass.TextChanged += new System.EventHandler(this.TextBoxFields_TextChanged);
            // 
            // LabelGamePath
            // 
            this.LabelGamePath.AutoSize = true;
            this.LabelGamePath.ForeColor = System.Drawing.Color.White;
            this.LabelGamePath.Location = new System.Drawing.Point(12, 106);
            this.LabelGamePath.Name = "LabelGamePath";
            this.LabelGamePath.Size = new System.Drawing.Size(84, 19);
            this.LabelGamePath.TabIndex = 18;
            this.LabelGamePath.Text = "7D2D-Pfad:";
            // 
            // TextBoxGamePath
            // 
            this.TextBoxGamePath.Location = new System.Drawing.Point(105, 103);
            this.TextBoxGamePath.Name = "TextBoxGamePath";
            this.TextBoxGamePath.Size = new System.Drawing.Size(263, 26);
            this.TextBoxGamePath.TabIndex = 17;
            this.TextBoxGamePath.Click += new System.EventHandler(this.SearchGameFolder_Click);
            this.TextBoxGamePath.TextChanged += new System.EventHandler(this.TextBoxFields_TextChanged);
            // 
            // LabelPort
            // 
            this.LabelPort.AutoSize = true;
            this.LabelPort.ForeColor = System.Drawing.Color.White;
            this.LabelPort.Location = new System.Drawing.Point(12, 42);
            this.LabelPort.Name = "LabelPort";
            this.LabelPort.Size = new System.Drawing.Size(88, 19);
            this.LabelPort.TabIndex = 16;
            this.LabelPort.Text = "Server-Port:";
            // 
            // TextBoxPort
            // 
            this.TextBoxPort.Location = new System.Drawing.Point(105, 39);
            this.TextBoxPort.Name = "TextBoxPort";
            this.TextBoxPort.Size = new System.Drawing.Size(263, 26);
            this.TextBoxPort.TabIndex = 15;
            this.TextBoxPort.TextChanged += new System.EventHandler(this.TextBoxFields_TextChanged);
            // 
            // LabelIP
            // 
            this.LabelIP.AutoSize = true;
            this.LabelIP.ForeColor = System.Drawing.Color.White;
            this.LabelIP.Location = new System.Drawing.Point(12, 10);
            this.LabelIP.Name = "LabelIP";
            this.LabelIP.Size = new System.Drawing.Size(74, 19);
            this.LabelIP.TabIndex = 14;
            this.LabelIP.Text = "Server-IP:";
            // 
            // TextBoxIP
            // 
            this.TextBoxIP.Location = new System.Drawing.Point(105, 7);
            this.TextBoxIP.Name = "TextBoxIP";
            this.TextBoxIP.Size = new System.Drawing.Size(263, 26);
            this.TextBoxIP.TabIndex = 13;
            this.TextBoxIP.TextChanged += new System.EventHandler(this.TextBoxFields_TextChanged);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(380, 457);
            this.Controls.Add(this.PanelLauncher);
            this.Controls.Add(this.PanelTitle);
            this.Font = new System.Drawing.Font("Noto Sans", 10F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormMain";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.PanelTitle.ResumeLayout(false);
            this.PanelHeader.ResumeLayout(false);
            this.PanelHeader.PerformLayout();
            this.PanelLauncher.ResumeLayout(false);
            this.PanelFooter.ResumeLayout(false);
            this.PanelFooter.PerformLayout();
            this.PanelButtons.ResumeLayout(false);
            this.PanelTextBoxes.ResumeLayout(false);
            this.PanelTextBoxes.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelHeader;
        private System.Windows.Forms.Panel PanelTitle;
        private System.Windows.Forms.Panel PanelLauncher;
        private FontAwesome.Sharp.IconButton ButtonJoin;
        private FontAwesome.Sharp.IconButton ButtonMods;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel PanelTextBoxes;
        private FontAwesome.Sharp.IconButton ButtonShowPass;
        private System.Windows.Forms.Label LabelPassword;
        private System.Windows.Forms.TextBox TextBoxPass;
        private System.Windows.Forms.Label LabelGamePath;
        private System.Windows.Forms.TextBox TextBoxGamePath;
        private System.Windows.Forms.Label LabelPort;
        private System.Windows.Forms.TextBox TextBoxPort;
        private System.Windows.Forms.Label LabelIP;
        private System.Windows.Forms.TextBox TextBoxIP;
        private System.Windows.Forms.Panel PanelButtons;
        private System.Windows.Forms.Panel PanelFooter;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
    }
}

