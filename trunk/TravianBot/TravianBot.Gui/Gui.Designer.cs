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
            this.tabPageStatus = new System.Windows.Forms.TabPage();
            this.labelServer = new System.Windows.Forms.Label();
            this.labelUsername = new System.Windows.Forms.Label();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelAlianceId = new System.Windows.Forms.Label();
            this.textBoxAlianceId = new System.Windows.Forms.TextBox();
            this.buttonGetInfo = new System.Windows.Forms.Button();
            this.labelAlianceName = new System.Windows.Forms.Label();
            this.dataGridViewAliance = new System.Windows.Forms.DataGridView();
            this.tabControlGui.SuspendLayout();
            this.tabPageAliance.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAliance)).BeginInit();
            this.SuspendLayout();
            // 
            // tabControlGui
            // 
            this.tabControlGui.Controls.Add(this.tabPageAliance);
            this.tabControlGui.Controls.Add(this.tabPageStatus);
            this.tabControlGui.Location = new System.Drawing.Point(13, 71);
            this.tabControlGui.Name = "tabControlGui";
            this.tabControlGui.SelectedIndex = 0;
            this.tabControlGui.Size = new System.Drawing.Size(856, 709);
            this.tabControlGui.TabIndex = 0;
            // 
            // tabPageAliance
            // 
            this.tabPageAliance.Controls.Add(this.dataGridViewAliance);
            this.tabPageAliance.Controls.Add(this.labelAlianceName);
            this.tabPageAliance.Location = new System.Drawing.Point(4, 22);
            this.tabPageAliance.Name = "tabPageAliance";
            this.tabPageAliance.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAliance.Size = new System.Drawing.Size(848, 683);
            this.tabPageAliance.TabIndex = 0;
            this.tabPageAliance.Text = "Aliance";
            this.tabPageAliance.UseVisualStyleBackColor = true;
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Size = new System.Drawing.Size(848, 683);
            this.tabPageStatus.TabIndex = 1;
            this.tabPageStatus.Text = "Status";
            this.tabPageStatus.UseVisualStyleBackColor = true;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(10, 9);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(38, 13);
            this.labelServer.TabIndex = 1;
            this.labelServer.Text = "Server";
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(10, 31);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 2;
            this.labelUsername.Text = "Username";
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(10, 55);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 3;
            this.labelPassword.Text = "Password";
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(93, 1);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(164, 20);
            this.textBoxServer.TabIndex = 4;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(93, 48);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(164, 20);
            this.textBoxPassword.TabIndex = 5;
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(93, 24);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(164, 20);
            this.textBoxUsername.TabIndex = 6;
            // 
            // labelAlianceId
            // 
            this.labelAlianceId.AutoSize = true;
            this.labelAlianceId.Location = new System.Drawing.Point(294, 8);
            this.labelAlianceId.Name = "labelAlianceId";
            this.labelAlianceId.Size = new System.Drawing.Size(54, 13);
            this.labelAlianceId.TabIndex = 7;
            this.labelAlianceId.Text = "Aliance Id";
            // 
            // textBoxAlianceId
            // 
            this.textBoxAlianceId.Location = new System.Drawing.Point(365, 1);
            this.textBoxAlianceId.Name = "textBoxAlianceId";
            this.textBoxAlianceId.Size = new System.Drawing.Size(164, 20);
            this.textBoxAlianceId.TabIndex = 8;
            // 
            // buttonGetInfo
            // 
            this.buttonGetInfo.Location = new System.Drawing.Point(565, 45);
            this.buttonGetInfo.Name = "buttonGetInfo";
            this.buttonGetInfo.Size = new System.Drawing.Size(75, 23);
            this.buttonGetInfo.TabIndex = 9;
            this.buttonGetInfo.Text = "GetInfo";
            this.buttonGetInfo.UseVisualStyleBackColor = true;
            // 
            // labelAlianceName
            // 
            this.labelAlianceName.AutoSize = true;
            this.labelAlianceName.Location = new System.Drawing.Point(7, 7);
            this.labelAlianceName.Name = "labelAlianceName";
            this.labelAlianceName.Size = new System.Drawing.Size(0, 13);
            this.labelAlianceName.TabIndex = 0;
            // 
            // dataGridViewAliance
            // 
            this.dataGridViewAliance.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewAliance.Location = new System.Drawing.Point(6, 36);
            this.dataGridViewAliance.Name = "dataGridViewAliance";
            this.dataGridViewAliance.Size = new System.Drawing.Size(836, 641);
            this.dataGridViewAliance.TabIndex = 1;
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(881, 792);
            this.Controls.Add(this.buttonGetInfo);
            this.Controls.Add(this.textBoxAlianceId);
            this.Controls.Add(this.labelAlianceId);
            this.Controls.Add(this.textBoxUsername);
            this.Controls.Add(this.textBoxPassword);
            this.Controls.Add(this.textBoxServer);
            this.Controls.Add(this.labelPassword);
            this.Controls.Add(this.labelUsername);
            this.Controls.Add(this.labelServer);
            this.Controls.Add(this.tabControlGui);
            this.Name = "Gui";
            this.Text = "TravianBot.Gui";
            this.Load += new System.EventHandler(this.Gui_Load);
            this.tabControlGui.ResumeLayout(false);
            this.tabPageAliance.ResumeLayout(false);
            this.tabPageAliance.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAliance)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

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
        private System.Windows.Forms.Button buttonGetInfo;
        private System.Windows.Forms.TabPage tabPageStatus;
        private System.Windows.Forms.DataGridView dataGridViewAliance;
        private System.Windows.Forms.Label labelAlianceName;
    }
}

