namespace MailCleaner.Gui
{
	partial class MailCleaner
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
			this.buttonCheckMail = new System.Windows.Forms.Button();
			this.buttonAddDomainToBlackList = new System.Windows.Forms.Button();
			this.dataGridViewMailList = new System.Windows.Forms.DataGridView();
			this.dataGridViewBlackList = new System.Windows.Forms.DataGridView();
			this.textBoxMailMessage = new System.Windows.Forms.TextBox();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMailList)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlackList)).BeginInit();
			this.SuspendLayout();
			// 
			// buttonCheckMail
			// 
			this.buttonCheckMail.Location = new System.Drawing.Point(12, 12);
			this.buttonCheckMail.Name = "buttonCheckMail";
			this.buttonCheckMail.Size = new System.Drawing.Size(75, 23);
			this.buttonCheckMail.TabIndex = 0;
			this.buttonCheckMail.Text = "Check Mail";
			this.buttonCheckMail.UseVisualStyleBackColor = true;
			// 
			// buttonAddDomainToBlackList
			// 
			this.buttonAddDomainToBlackList.Location = new System.Drawing.Point(93, 12);
			this.buttonAddDomainToBlackList.Name = "buttonAddDomainToBlackList";
			this.buttonAddDomainToBlackList.Size = new System.Drawing.Size(75, 23);
			this.buttonAddDomainToBlackList.TabIndex = 4;
			this.buttonAddDomainToBlackList.Text = "BlackList";
			this.buttonAddDomainToBlackList.UseVisualStyleBackColor = true;
			// 
			// dataGridViewMailList
			// 
			this.dataGridViewMailList.AllowUserToAddRows = false;
			this.dataGridViewMailList.AllowUserToDeleteRows = false;
			this.dataGridViewMailList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewMailList.Location = new System.Drawing.Point(13, 42);
			this.dataGridViewMailList.Name = "dataGridViewMailList";
			this.dataGridViewMailList.ReadOnly = true;
			this.dataGridViewMailList.Size = new System.Drawing.Size(1132, 180);
			this.dataGridViewMailList.TabIndex = 5;
			// 
			// dataGridViewBlackList
			// 
			this.dataGridViewBlackList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
			this.dataGridViewBlackList.Location = new System.Drawing.Point(727, 228);
			this.dataGridViewBlackList.Name = "dataGridViewBlackList";
			this.dataGridViewBlackList.Size = new System.Drawing.Size(418, 240);
			this.dataGridViewBlackList.TabIndex = 6;
			// 
			// textBoxMailMessage
			// 
			this.textBoxMailMessage.Location = new System.Drawing.Point(12, 228);
			this.textBoxMailMessage.Multiline = true;
			this.textBoxMailMessage.Name = "textBoxMailMessage";
			this.textBoxMailMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxMailMessage.Size = new System.Drawing.Size(709, 240);
			this.textBoxMailMessage.TabIndex = 7;
			// 
			// MailCleaner
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(1157, 480);
			this.Controls.Add(this.textBoxMailMessage);
			this.Controls.Add(this.dataGridViewBlackList);
			this.Controls.Add(this.dataGridViewMailList);
			this.Controls.Add(this.buttonAddDomainToBlackList);
			this.Controls.Add(this.buttonCheckMail);
			this.Name = "MailCleaner";
			this.Text = "MailCleaner";
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewMailList)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlackList)).EndInit();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCheckMail;
		private System.Windows.Forms.Button buttonAddDomainToBlackList;
		private System.Windows.Forms.DataGridView dataGridViewMailList;
		private System.Windows.Forms.DataGridView dataGridViewBlackList;
		private System.Windows.Forms.TextBox textBoxMailMessage;
	}
}

