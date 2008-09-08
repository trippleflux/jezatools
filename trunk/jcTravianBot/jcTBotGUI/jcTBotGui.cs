using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace jcTBotGUI
{
	public partial class jcTBotGui : Form
	{
		public jcTBotGui()
		{
			InitializeComponent();
		}

		private void jcTBotGui_Load(object sender, EventArgs e)
		{
			// TODO: This line of code loads data into the 'jcTBotDataSet1.Buildings' table. You can move, or remove it, as needed.
			this.buildingsTableAdapter.Fill(this.jcTBotDataSet1.Buildings);
			// TODO: This line of code loads data into the 'jcTBotDataSetResources.Resources' table. You can move, or remove it, as needed.
			this.resourcesTableAdapter.Fill(this.jcTBotDataSetResources.Resources);
			// TODO: This line of code loads data into the 'jcTBotDataSet.Villages' table. You can move, or remove it, as needed.
			this.villagesTableAdapter.Fill(this.jcTBotDataSet.Villages);
		}
	}
}