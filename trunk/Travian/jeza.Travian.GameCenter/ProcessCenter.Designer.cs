using System;
using System.Drawing;
using System.Windows.Forms;

namespace jeza.Travian.GameCenter
{
    partial class ProcessCenter
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
            this.panelMain = new System.Windows.Forms.Panel();
            this.panelHead = new System.Windows.Forms.Panel();
            this.textBoxServer = new System.Windows.Forms.TextBox();
            this.labelServer = new System.Windows.Forms.Label();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonRun = new System.Windows.Forms.Button();
            this.textBoxPassword = new System.Windows.Forms.TextBox();
            this.labelPassword = new System.Windows.Forms.Label();
            this.textBoxUsername = new System.Windows.Forms.TextBox();
            this.labelUsername = new System.Windows.Forms.Label();
            this.panelTabs = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOverview = new System.Windows.Forms.TabPage();
            this.tabPageRallyPoint = new System.Windows.Forms.TabPage();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.textBoxStatus = new System.Windows.Forms.TextBox();
            this.dataGridViewOverview = new System.Windows.Forms.DataGridView();
            this.panelMain.SuspendLayout();
            this.panelHead.SuspendLayout();
            this.panelTabs.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.tabPageOverview.SuspendLayout();
            this.panelStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOverview)).BeginInit();
            this.SuspendLayout();
            // 
            // panelMain
            // 
            this.panelMain.AutoSize = true;
            this.panelMain.Controls.Add(this.panelTabs);
            this.panelMain.Controls.Add(this.panelHead);
            this.panelMain.Controls.Add(this.panelStatus);
            this.panelMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelMain.Location = new System.Drawing.Point(0, 0);
            this.panelMain.Name = "panelMain";
            this.panelMain.Size = new System.Drawing.Size(1027, 865);
            this.panelMain.TabIndex = 0;
            // 
            // panelHead
            // 
            this.panelHead.AutoSize = true;
            this.panelHead.Controls.Add(this.textBoxServer);
            this.panelHead.Controls.Add(this.labelServer);
            this.panelHead.Controls.Add(this.labelStatus);
            this.panelHead.Controls.Add(this.buttonRun);
            this.panelHead.Controls.Add(this.textBoxPassword);
            this.panelHead.Controls.Add(this.labelPassword);
            this.panelHead.Controls.Add(this.textBoxUsername);
            this.panelHead.Controls.Add(this.labelUsername);
            this.panelHead.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelHead.Location = new System.Drawing.Point(0, 0);
            this.panelHead.Name = "panelHead";
            this.panelHead.Size = new System.Drawing.Size(1027, 31);
            this.panelHead.TabIndex = 2;
            // 
            // textBoxServer
            // 
            this.textBoxServer.Location = new System.Drawing.Point(69, 7);
            this.textBoxServer.Name = "textBoxServer";
            this.textBoxServer.Size = new System.Drawing.Size(150, 20);
            this.textBoxServer.TabIndex = 7;
            // 
            // labelServer
            // 
            this.labelServer.AutoSize = true;
            this.labelServer.Location = new System.Drawing.Point(8, 10);
            this.labelServer.Name = "labelServer";
            this.labelServer.Size = new System.Drawing.Size(38, 13);
            this.labelServer.TabIndex = 6;
            this.labelServer.Text = "Server";
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(719, 10);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(24, 13);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "Idle";
            // 
            // buttonRun
            // 
            this.buttonRun.Location = new System.Drawing.Point(629, 5);
            this.buttonRun.Name = "buttonRun";
            this.buttonRun.Size = new System.Drawing.Size(75, 23);
            this.buttonRun.TabIndex = 4;
            this.buttonRun.Text = "Start";
            this.buttonRun.UseVisualStyleBackColor = true;
            // 
            // textBoxPassword
            // 
            this.textBoxPassword.Location = new System.Drawing.Point(523, 7);
            this.textBoxPassword.Name = "textBoxPassword";
            this.textBoxPassword.Size = new System.Drawing.Size(100, 20);
            this.textBoxPassword.TabIndex = 3;
            // 
            // labelPassword
            // 
            this.labelPassword.AutoSize = true;
            this.labelPassword.Location = new System.Drawing.Point(451, 10);
            this.labelPassword.Name = "labelPassword";
            this.labelPassword.Size = new System.Drawing.Size(53, 13);
            this.labelPassword.TabIndex = 2;
            this.labelPassword.Text = "Password";
            // 
            // textBoxUsername
            // 
            this.textBoxUsername.Location = new System.Drawing.Point(295, 7);
            this.textBoxUsername.Name = "textBoxUsername";
            this.textBoxUsername.Size = new System.Drawing.Size(150, 20);
            this.textBoxUsername.TabIndex = 1;
            // 
            // labelUsername
            // 
            this.labelUsername.AutoSize = true;
            this.labelUsername.Location = new System.Drawing.Point(234, 10);
            this.labelUsername.Name = "labelUsername";
            this.labelUsername.Size = new System.Drawing.Size(55, 13);
            this.labelUsername.TabIndex = 0;
            this.labelUsername.Text = "Username";
            // 
            // panelTabs
            // 
            this.panelTabs.Controls.Add(this.tabControl);
            this.panelTabs.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelTabs.Location = new System.Drawing.Point(0, 31);
            this.panelTabs.Name = "panelTabs";
            this.panelTabs.Size = new System.Drawing.Size(1027, 622);
            this.panelTabs.TabIndex = 1;
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageOverview);
            this.tabControl.Controls.Add(this.tabPageRallyPoint);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1027, 622);
            this.tabControl.TabIndex = 0;
            // 
            // tabPageOverview
            // 
            this.tabPageOverview.Controls.Add(this.dataGridViewOverview);
            this.tabPageOverview.Location = new System.Drawing.Point(4, 22);
            this.tabPageOverview.Name = "tabPageOverview";
            this.tabPageOverview.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOverview.Size = new System.Drawing.Size(1019, 596);
            this.tabPageOverview.TabIndex = 0;
            this.tabPageOverview.Text = "Overview";
            this.tabPageOverview.UseVisualStyleBackColor = true;
            // 
            // tabPageRallyPoint
            // 
            this.tabPageRallyPoint.Location = new System.Drawing.Point(4, 22);
            this.tabPageRallyPoint.Name = "tabPageRallyPoint";
            this.tabPageRallyPoint.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageRallyPoint.Size = new System.Drawing.Size(1019, 596);
            this.tabPageRallyPoint.TabIndex = 1;
            this.tabPageRallyPoint.Text = "Rally Point";
            this.tabPageRallyPoint.UseVisualStyleBackColor = true;
            // 
            // panelStatus
            // 
            this.panelStatus.AutoSize = true;
            this.panelStatus.Controls.Add(this.textBoxStatus);
            this.panelStatus.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelStatus.Location = new System.Drawing.Point(0, 653);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(1027, 212);
            this.panelStatus.TabIndex = 0;
            // 
            // textBoxStatus
            // 
            this.textBoxStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxStatus.Location = new System.Drawing.Point(4, 4);
            this.textBoxStatus.Multiline = true;
            this.textBoxStatus.Name = "textBoxStatus";
            this.textBoxStatus.Size = new System.Drawing.Size(1019, 205);
            this.textBoxStatus.TabIndex = 0;
            // 
            // dataGridViewOverview
            // 
            this.dataGridViewOverview.AllowUserToAddRows = false;
            this.dataGridViewOverview.AllowUserToDeleteRows = false;
            this.dataGridViewOverview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOverview.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridViewOverview.Location = new System.Drawing.Point(3, 3);
            this.dataGridViewOverview.Name = "dataGridViewOverview";
            this.dataGridViewOverview.ReadOnly = true;
            this.dataGridViewOverview.Size = new System.Drawing.Size(1013, 590);
            this.dataGridViewOverview.TabIndex = 0;
            // 
            // ProcessCenter
            // 
            this.ClientSize = new System.Drawing.Size(1027, 865);
            this.Controls.Add(this.panelMain);
            this.Name = "ProcessCenter";
            this.Load += new System.EventHandler(this.ProcessCenter_Load);
            this.panelMain.ResumeLayout(false);
            this.panelMain.PerformLayout();
            this.panelHead.ResumeLayout(false);
            this.panelHead.PerformLayout();
            this.panelTabs.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.tabPageOverview.ResumeLayout(false);
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOverview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Panel panelMain;
        private Panel panelTabs;
        private TabControl tabControl;
        private TabPage tabPageOverview;
        private TabPage tabPageRallyPoint;
        private Panel panelStatus;
        private Panel panelHead;
        private Label labelStatus;
        private Button buttonRun;
        private TextBox textBoxPassword;
        private Label labelPassword;
        private TextBox textBoxUsername;
        private Label labelUsername;
        private TextBox textBoxStatus;
        private TextBox textBoxServer;
        private Label labelServer;
        private DataGridView dataGridViewOverview;

    }
}

