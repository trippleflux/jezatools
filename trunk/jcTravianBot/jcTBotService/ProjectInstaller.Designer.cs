namespace jcTBotService
{
	partial class ProjectInstaller
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

		#region Component Designer generated code

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.serviceProcessInstallerjcTBot = new System.ServiceProcess.ServiceProcessInstaller();
			this.serviceInstallerjcTBot = new System.ServiceProcess.ServiceInstaller();
			// 
			// serviceProcessInstallerjcTBot
			// 
			this.serviceProcessInstallerjcTBot.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
			this.serviceProcessInstallerjcTBot.Password = null;
			this.serviceProcessInstallerjcTBot.Username = null;
			// 
			// serviceInstallerjcTBot
			// 
			this.serviceInstallerjcTBot.Description = "Travian Bot";
			this.serviceInstallerjcTBot.DisplayName = "jcTBot";
			this.serviceInstallerjcTBot.ServiceName = "jcTBot";
			this.serviceInstallerjcTBot.StartType = System.ServiceProcess.ServiceStartMode.Automatic;
			// 
			// ProjectInstaller
			// 
			this.Installers.AddRange(new System.Configuration.Install.Installer[] {
            this.serviceProcessInstallerjcTBot,
            this.serviceInstallerjcTBot});

		}

		#endregion

		private System.ServiceProcess.ServiceProcessInstaller serviceProcessInstallerjcTBot;
		private System.ServiceProcess.ServiceInstaller serviceInstallerjcTBot;
	}
}