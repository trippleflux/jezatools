﻿namespace TravianBot.Gui
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
            this.tabPageStatus = new System.Windows.Forms.TabPage();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.tabPageStats = new System.Windows.Forms.TabPage();
            this.dataGridViewAliance = new System.Windows.Forms.DataGridView();
            this.labelAlianceName = new System.Windows.Forms.Label();
            this.panelData = new System.Windows.Forms.Panel();
            this.labelAlianceId = new System.Windows.Forms.Label();
            this.textBoxAlianceId = new System.Windows.Forms.TextBox();
            this.buttonGetInfoAliance = new System.Windows.Forms.Button();
            this.labelUid = new System.Windows.Forms.Label();
            this.textBoxUid = new System.Windows.Forms.TextBox();
            this.buttonGetInfoUid = new System.Windows.Forms.Button();
            this.panelInfo = new System.Windows.Forms.Panel();
            this.textBoxSaveStats = new System.Windows.Forms.TextBox();
            this.buttonSaveStats = new System.Windows.Forms.Button();
            this.progressBarStatus = new System.Windows.Forms.ProgressBar();
            this.comboBoxDelay = new System.Windows.Forms.ComboBox();
            this.labelDelay = new System.Windows.Forms.Label();
            this.tabControlGui.SuspendLayout();
            this.tabPageStatus.SuspendLayout();
            this.tabPageStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAliance)).BeginInit();
            this.panelData.SuspendLayout();
            this.panelInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControlGui
            // 
            this.tabControlGui.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlGui.Controls.Add(this.tabPageStatus);
            this.tabControlGui.Controls.Add(this.tabPageStats);
            this.tabControlGui.Location = new System.Drawing.Point(3, 3);
            this.tabControlGui.Name = "tabControlGui";
            this.tabControlGui.SelectedIndex = 0;
            this.tabControlGui.Size = new System.Drawing.Size(981, 668);
            this.tabControlGui.TabIndex = 0;
            // 
            // tabPageStatus
            // 
            this.tabPageStatus.Controls.Add(this.textBoxStatus);
            this.tabPageStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageStatus.Name = "tabPageStatus";
            this.tabPageStatus.Size = new System.Drawing.Size(973, 642);
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
            this.textBoxStatus.Size = new System.Drawing.Size(973, 642);
            this.textBoxStatus.TabIndex = 0;
            // 
            // tabPageStats
            // 
            this.tabPageStats.Controls.Add(this.dataGridViewAliance);
            this.tabPageStats.Controls.Add(this.labelAlianceName);
            this.tabPageStats.Location = new System.Drawing.Point(4, 22);
            this.tabPageStats.Name = "tabPageStats";
            this.tabPageStats.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageStats.Size = new System.Drawing.Size(973, 642);
            this.tabPageStats.TabIndex = 0;
            this.tabPageStats.Text = "Stats";
            this.tabPageStats.UseVisualStyleBackColor = true;
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
            this.dataGridViewAliance.Size = new System.Drawing.Size(967, 636);
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
            // panelData
            // 
            this.panelData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelData.Controls.Add(this.tabControlGui);
            this.panelData.Location = new System.Drawing.Point(12, 112);
            this.panelData.Name = "panelData";
            this.panelData.Size = new System.Drawing.Size(982, 668);
            this.panelData.TabIndex = 11;
            // 
            // labelAlianceId
            // 
            this.labelAlianceId.AutoSize = true;
            this.labelAlianceId.Location = new System.Drawing.Point(14, 17);
            this.labelAlianceId.Name = "labelAlianceId";
            this.labelAlianceId.Size = new System.Drawing.Size(54, 13);
            this.labelAlianceId.TabIndex = 7;
            this.labelAlianceId.Text = "Aliance Id";
            // 
            // textBoxAlianceId
            // 
            this.textBoxAlianceId.Location = new System.Drawing.Point(74, 10);
            this.textBoxAlianceId.Name = "textBoxAlianceId";
            this.textBoxAlianceId.Size = new System.Drawing.Size(164, 20);
            this.textBoxAlianceId.TabIndex = 8;
            this.textBoxAlianceId.Text = "18";
            // 
            // buttonGetInfoAliance
            // 
            this.buttonGetInfoAliance.Location = new System.Drawing.Point(244, 7);
            this.buttonGetInfoAliance.Name = "buttonGetInfoAliance";
            this.buttonGetInfoAliance.Size = new System.Drawing.Size(91, 23);
            this.buttonGetInfoAliance.TabIndex = 9;
            this.buttonGetInfoAliance.Text = "Aliance Stats";
            this.buttonGetInfoAliance.UseVisualStyleBackColor = true;
            this.buttonGetInfoAliance.Click += new System.EventHandler(this.buttonGetInfoAliance_Click);
            // 
            // labelUid
            // 
            this.labelUid.AutoSize = true;
            this.labelUid.Location = new System.Drawing.Point(13, 60);
            this.labelUid.Name = "labelUid";
            this.labelUid.Size = new System.Drawing.Size(55, 13);
            this.labelUid.TabIndex = 10;
            this.labelUid.Text = "Username";
            // 
            // textBoxUid
            // 
            this.textBoxUid.Location = new System.Drawing.Point(73, 53);
            this.textBoxUid.Name = "textBoxUid";
            this.textBoxUid.Size = new System.Drawing.Size(164, 20);
            this.textBoxUid.TabIndex = 11;
            // 
            // buttonGetInfoUid
            // 
            this.buttonGetInfoUid.Location = new System.Drawing.Point(244, 50);
            this.buttonGetInfoUid.Name = "buttonGetInfoUid";
            this.buttonGetInfoUid.Size = new System.Drawing.Size(90, 23);
            this.buttonGetInfoUid.TabIndex = 12;
            this.buttonGetInfoUid.Text = "User Stats";
            this.buttonGetInfoUid.UseVisualStyleBackColor = true;
            this.buttonGetInfoUid.Click += new System.EventHandler(this.buttonGetInfoUid_Click);
            // 
            // panelInfo
            // 
            this.panelInfo.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.panelInfo.Controls.Add(this.textBoxSaveStats);
            this.panelInfo.Controls.Add(this.buttonSaveStats);
            this.panelInfo.Controls.Add(this.progressBarStatus);
            this.panelInfo.Controls.Add(this.comboBoxDelay);
            this.panelInfo.Controls.Add(this.labelDelay);
            this.panelInfo.Controls.Add(this.buttonGetInfoUid);
            this.panelInfo.Controls.Add(this.textBoxUid);
            this.panelInfo.Controls.Add(this.labelUid);
            this.panelInfo.Controls.Add(this.buttonGetInfoAliance);
            this.panelInfo.Controls.Add(this.textBoxAlianceId);
            this.panelInfo.Controls.Add(this.labelAlianceId);
            this.panelInfo.Location = new System.Drawing.Point(12, 12);
            this.panelInfo.Name = "panelInfo";
            this.panelInfo.Size = new System.Drawing.Size(982, 94);
            this.panelInfo.TabIndex = 10;
            // 
            // textBoxSaveStats
            // 
            this.textBoxSaveStats.Location = new System.Drawing.Point(591, 9);
            this.textBoxSaveStats.Name = "textBoxSaveStats";
            this.textBoxSaveStats.Size = new System.Drawing.Size(193, 20);
            this.textBoxSaveStats.TabIndex = 17;
            this.textBoxSaveStats.Text = "Stats.xml";
            // 
            // buttonSaveStats
            // 
            this.buttonSaveStats.Location = new System.Drawing.Point(790, 8);
            this.buttonSaveStats.Name = "buttonSaveStats";
            this.buttonSaveStats.Size = new System.Drawing.Size(71, 23);
            this.buttonSaveStats.TabIndex = 16;
            this.buttonSaveStats.Text = "Save Stats";
            this.buttonSaveStats.UseVisualStyleBackColor = true;
            this.buttonSaveStats.Click += new System.EventHandler(this.buttonSaveStats_Click);
            // 
            // progressBarStatus
            // 
            this.progressBarStatus.Location = new System.Drawing.Point(392, 49);
            this.progressBarStatus.Name = "progressBarStatus";
            this.progressBarStatus.Size = new System.Drawing.Size(585, 23);
            this.progressBarStatus.Step = 1;
            this.progressBarStatus.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBarStatus.TabIndex = 15;
            // 
            // comboBoxDelay
            // 
            this.comboBoxDelay.FormattingEnabled = true;
            this.comboBoxDelay.Items.AddRange(new object[] {
            "1000",
            "2000",
            "3000",
            "4000",
            "5000"});
            this.comboBoxDelay.Location = new System.Drawing.Point(444, 8);
            this.comboBoxDelay.Name = "comboBoxDelay";
            this.comboBoxDelay.Size = new System.Drawing.Size(121, 21);
            this.comboBoxDelay.TabIndex = 14;
            this.comboBoxDelay.Text = "1000";
            // 
            // labelDelay
            // 
            this.labelDelay.AutoSize = true;
            this.labelDelay.Location = new System.Drawing.Point(389, 16);
            this.labelDelay.Name = "labelDelay";
            this.labelDelay.Size = new System.Drawing.Size(34, 13);
            this.labelDelay.TabIndex = 13;
            this.labelDelay.Text = "Delay";
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1006, 792);
            this.Controls.Add(this.panelData);
            this.Controls.Add(this.panelInfo);
            this.Name = "Gui";
            this.Text = "TravianBot.Gui";
            this.Load += new System.EventHandler(this.Gui_Load);
            this.tabControlGui.ResumeLayout(false);
            this.tabPageStatus.ResumeLayout(false);
            this.tabPageStatus.PerformLayout();
            this.tabPageStats.ResumeLayout(false);
            this.tabPageStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewAliance)).EndInit();
            this.panelData.ResumeLayout(false);
            this.panelInfo.ResumeLayout(false);
            this.panelInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControlGui;
        private System.Windows.Forms.TabPage tabPageStats;
        private System.Windows.Forms.TabPage tabPageStatus;
        private System.Windows.Forms.Label labelAlianceName;
        private System.Windows.Forms.TextBox textBoxStatus;
        private System.Windows.Forms.DataGridView dataGridViewAliance;
        private System.Windows.Forms.Panel panelData;
        private System.Windows.Forms.Label labelAlianceId;
        private System.Windows.Forms.TextBox textBoxAlianceId;
        private System.Windows.Forms.Button buttonGetInfoAliance;
        private System.Windows.Forms.Label labelUid;
        private System.Windows.Forms.TextBox textBoxUid;
        private System.Windows.Forms.Button buttonGetInfoUid;
        private System.Windows.Forms.Panel panelInfo;
        private System.Windows.Forms.ComboBox comboBoxDelay;
        private System.Windows.Forms.Label labelDelay;
        private System.Windows.Forms.ProgressBar progressBarStatus;
        private System.Windows.Forms.Button buttonSaveStats;
        private System.Windows.Forms.TextBox textBoxSaveStats;
    }
}

