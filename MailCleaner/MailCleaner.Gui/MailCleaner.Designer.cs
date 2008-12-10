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
            this.dataGridViewBlackList = new System.Windows.Forms.DataGridView();
            this.textBoxMailMessage = new System.Windows.Forms.TextBox();
            this.labelStatus = new System.Windows.Forms.Label();
            this.listViewStatus = new System.Windows.Forms.ListView();
            this.Number = new System.Windows.Forms.ColumnHeader();
            this.From = new System.Windows.Forms.ColumnHeader();
            this.Subject = new System.Windows.Forms.ColumnHeader();
            this.Date = new System.Windows.Forms.ColumnHeader();
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
            this.buttonCheckMail.Click += new System.EventHandler(this.buttonCheckMail_Click);
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
            // dataGridViewBlackList
            // 
            this.dataGridViewBlackList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBlackList.Location = new System.Drawing.Point(645, 228);
            this.dataGridViewBlackList.Name = "dataGridViewBlackList";
            this.dataGridViewBlackList.Size = new System.Drawing.Size(256, 240);
            this.dataGridViewBlackList.TabIndex = 6;
            // 
            // textBoxMailMessage
            // 
            this.textBoxMailMessage.Location = new System.Drawing.Point(12, 228);
            this.textBoxMailMessage.Multiline = true;
            this.textBoxMailMessage.Name = "textBoxMailMessage";
            this.textBoxMailMessage.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxMailMessage.Size = new System.Drawing.Size(627, 240);
            this.textBoxMailMessage.TabIndex = 7;
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(174, 12);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(727, 23);
            this.labelStatus.TabIndex = 8;
            // 
            // listViewStatus
            // 
            this.listViewStatus.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.Number,
            this.From,
            this.Subject,
            this.Date});
            this.listViewStatus.Location = new System.Drawing.Point(13, 42);
            this.listViewStatus.Name = "listViewStatus";
            this.listViewStatus.Size = new System.Drawing.Size(888, 180);
            this.listViewStatus.TabIndex = 9;
            this.listViewStatus.UseCompatibleStateImageBehavior = false;
            this.listViewStatus.View = System.Windows.Forms.View.Details;
            // 
            // Number
            // 
            this.Number.Text = "Item";
            // 
            // From
            // 
            this.From.Text = "From";
            this.From.Width = 208;
            // 
            // Subject
            // 
            this.Subject.Text = "Subject";
            this.Subject.Width = 412;
            // 
            // Date
            // 
            this.Date.Text = "Date";
            this.Date.Width = 203;
            // 
            // MailCleaner
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(913, 480);
            this.Controls.Add(this.listViewStatus);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.textBoxMailMessage);
            this.Controls.Add(this.dataGridViewBlackList);
            this.Controls.Add(this.buttonAddDomainToBlackList);
            this.Controls.Add(this.buttonCheckMail);
            this.Name = "MailCleaner";
            this.Text = "MailCleaner";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBlackList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		private System.Windows.Forms.Button buttonCheckMail;
        private System.Windows.Forms.Button buttonAddDomainToBlackList;
		private System.Windows.Forms.DataGridView dataGridViewBlackList;
		private System.Windows.Forms.TextBox textBoxMailMessage;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.ListView listViewStatus;
        private System.Windows.Forms.ColumnHeader Number;
        private System.Windows.Forms.ColumnHeader From;
        private System.Windows.Forms.ColumnHeader Subject;
        private System.Windows.Forms.ColumnHeader Date;
	}
}

