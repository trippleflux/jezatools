namespace TravianBot.Gui
{
    partial class Gui
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
            this.tabControlGui = new System.Windows.Forms.TabControl();
            this.tabPageAliance = new System.Windows.Forms.TabPage();
            this.dataGridViewAliance = new System.Windows.Forms.DataGridView();
            this.labelAlianceName = new System.Windows.Forms.Label();
            this.tabPageStatus = new System.Windows.Forms.TabPage();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelAlianceId = new System.Windows.Forms.Label();
            this.textBoxAlianceId = new System.Windows.Forms.TextBox();
            this.buttonGetInfoAliance = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.buttonGetInfoUid = new System.Windows.Forms.Button();
            this.textBoxUid = new System.Windows.Forms.TextBox();
            this.labelUid = new System.Windows.Forms.Label();
            this.panelData = new System.Windows.Forms.Panel();
            this.tabControlGui.SuspendLayout();
            this.tabPageAliance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAliance)).BeginInit();
            this.tabPageStatus.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.panelData.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlGui
            // 
            this.tabControlGui.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlGui.Controls.Add(this.tabPageAliance);
            this.tabControlGui.Controls.Add(this.tabPageStatus);
            this.tabControlGui.Location = new System.Drawing.Point(3, 3);
            this.tabControlGui.Name = "tabControlGui";
            this.tabControlGui.SelectedIndex = 0;
            this.tabControlGui.Size = new System.Drawing.Size(825, 668);
            this.tabControlGui.TabIndex = 0;
            // 
            // tabPageAliance
            // 
            this.tabPageAliance.Controls.Add(this.dataGridViewAliance);
            this.tabPageAliance.Controls.Add(this.labelAlianceName);
            this.tabPageAliance.Location = new System.Drawing.Point(4, 22);
            this.tabPageAliance.Name = "tabPageAliance";
            this.tabPageAliance.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAliance.Size = new System.Drawing.Size(817, 642);
            this.tabPageAliance.TabIndex = 0;
            this.tabPageAliance.Text = "Aliance";
            this.tabPageAliance.UseVisualStyleBackColor = true;
            // 
            // dataGridViewAliance
            // 
            this.dataGridViewAliance.AllowUserToAddRows = false;
            this.dataGridViewAliance.AllowUserToDeleteRows = false;
            this.dataGridViewAliance.AllowUserToOrderColumns = true;
            this.dataGridViewAliance.AllowUserToResizeRows = false;
            this.dataGridViewAliance.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dataGridViewAliance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAliance.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewAliance.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewAliance.Name = "dataGridViewAliance";
            this.dataGridViewAliance.ReadOnly = true;
            this.dataGridViewAliance.Size = new System.Drawing.Size(811, 636);
            this.dataGridViewAliance.TabIndex = 1;
            // 
            // labelAlianceName
            // 
            this.labelAlianceName.AutoSize = true;
            this.labelAlianceName.Location = new System.Drawing.Point(7, 7);
            this.labelAlianceName.Name = "labelAlianceName";
            this.labelAlianceName.Size = new System.Drawing.Size(0, 13);
            this.labelAlianceName.TabIndex = 0;
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Controls.Add(this.textBoxStatus);
            this.tabPageStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Size = new System.Drawing.Size(817, 642);
            this.tabPageStatus.TabIndex = 1;
            this.tabPageStatus.Text = "Status";
            this.tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Dock = System.Windows.Forms.DockStyle.Fill;
            this.textBoxStatus.Location = new System.Drawing.Point(0, 0);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxStatus.Size = new System.Drawing.Size(817, 642);
            this.textBoxStatus.TabIndex = 0;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(19, 19);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(38, 13);
            this.labelServer.TabIndex = 1;
            this.labelServer.Text = "Server";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(19, 41);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Username";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(19, 65);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(102, 11);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(164, 20);
            this.textBoxServer.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(102, 58);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(164, 20);
            this.textBoxPassword.TabIndex = 5;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(102, 34);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(164, 20);
            this.textBoxUsername.TabIndex = 6;
            // 
            // labelAlianceId
            // 
            this.labelAlianceId.AutoSize = true;
            this.labelAlianceId.Location = new System.Drawing.Point(283, 41);
            this.labelAlianceId.Name = "labelAlianceId";
            this.labelAlianceId.Size = new System.Drawing.Size(54, 13);
            this.labelAlianceId.TabIndex = 7;
            this.labelAlianceId.Text = "Aliance Id";
            // 
            // textBoxAlianceId
            // 
            this.textBoxAlianceId.Location = new System.Drawing.Point(343, 34);
            this.textBoxAlianceId.Name = "textBoxAlianceId";
            this.textBoxAlianceId.Size = new System.Drawing.Size(164, 20);
            this.textBoxAlianceId.TabIndex = 8;
            // 
            // buttonGetInfoAliance
            // 
            this.buttonGetInfoAliance.Location = new System.Drawing.Point(529, 31);
            this.buttonGetInfoAliance.Name = "buttonGetInfoAliance";
            this.buttonGetInfoAliance.Size = new System.Drawing.Size(75, 23);
            this.buttonGetInfoAliance.TabIndex = 9;
            this.buttonGetInfoAliance.Text = "GetInfo";
            this.buttonGetInfoAliance.UseVisualStyleBackColor = true;
            // 
            // panelInfo
            // 
            this.panelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInfo.Controls.Add(this.buttonGetInfoUid);
            this.panelInfo.Controls.Add(this.textBoxUid);
            this.panelInfo.Controls.Add(this.labelUid);
            this.panelInfo.Controls.Add(this.labelServer);
            this.panelInfo.Controls.Add(this.buttonGetInfoAliance);
            this.panelInfo.Controls.Add(this.labelUsername);
            this.panelInfo.Controls.Add(this.textBoxAlianceId);
            this.panelInfo.Controls.Add(this.labelPassword);
            this.panelInfo.Controls.Add(this.labelAlianceId);
            this.panelInfo.Controls.Add(this.textBoxServer);
            this.panelInfo.Controls.Add(this.textBoxUsername);
            this.panelInfo.Controls.Add(this.textBoxPassword);
            this.panelInfo.Location = new System.Drawing.Point(12, 12);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(826, 94);
            this.panelInfo.TabIndex = 10;
            // 
            // buttonGetInfoUid
            // 
            this.buttonGetInfoUid.Location = new System.Drawing.Point(529, 55);
            this.buttonGetInfoUid.Name = "buttonGetInfoUid";
            this.buttonGetInfoUid.Size = new System.Drawing.Size(75, 23);
            this.buttonGetInfoUid.TabIndex = 12;
            this.buttonGetInfoUid.Text = "GetInfo";
            this.buttonGetInfoUid.UseVisualStyleBackColor = true;
            this.buttonGetInfoUid.Click += new System.EventHandler(this.buttonGetInfoUid_Click);
            // 
            // textBoxUid
            // 
            this.textBoxUid.Location = new System.Drawing.Point(343, 58);
            this.textBoxUid.Name = "textBoxUid";
            this.textBoxUid.Size = new System.Drawing.Size(164, 20);
            this.textBoxUid.TabIndex = 11;
            // 
            // labelUid
            // 
            this.labelUid.AutoSize = true;
            this.labelUid.Location = new System.Drawing.Point(283, 65);
            this.labelUid.Name = "labelUid";
            this.labelUid.Size = new System.Drawing.Size(55, 13);
            this.labelUid.TabIndex = 10;
            this.labelUid.Text = "Username";
            // 
            // panelData
            // 
            this.panelData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelData.Controls.Add(this.tabControlGui);
            this.panelData.Location = new System.Drawing.Point(12, 112);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(826, 668);
            this.panelData.TabIndex = 11;
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(850, 792);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelInfo);
            this.Name = "Gui";
            this.Text = "TravianBot.Gui";
            this.Load += new System.EventHandler(this.Gui_Load);
            this.tabControlGui.ResumeLayout(false);
            this.tabPageAliance.ResumeLayout(false);
            this.tabPageAliance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAliance)).EndInit();
            this.tabPageStatus.ResumeLayout(false);
            this.tabPageStatus.PerformLayout();
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.panelData.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlGui;
        private System.Windows.Forms.TabPage tabPageAliance;
        private System.Windows.Forms.Label labelServer;
        private System.Windows.Forms.Label labelUsername;
        private System.Windows.Forms.Label labelPassword;
        private System.Windows.Forms.TextBox textBoxServer;
        private System.Windows.Forms.TextBox textBoxPassword;
        private System.Windows.Forms.TextBox textBoxUsername;
        private System.Windows.Forms.Label labelAlianceId;
        private System.Windows.Forms.TextBox textBoxAlianceId;
        private System.Windows.Forms.Button buttonGetInfoAliance;
        private System.Windows.Forms.TabPage tabPageStatus;
        private System.Windows.Forms.Label labelAlianceName;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.DataGridView dataGridViewAliance;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Button buttonGetInfoUid;
        private System.Windows.Forms.TextBox textBoxUid;
        private System.Windows.Forms.Label labelUid;
    }
}

