using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Text;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : Page
{
	private int size;
	private int distance;

	protected void Page_Load(object sender, EventArgs e)
	{
	}

	protected void linkButtonImportData_Click(object sender, EventArgs e)
	{
	}

	protected void linkButtonRefreshMap_Click(object sender, EventArgs e)
	{
		distance = Int32.Parse(textBoxDistance.Text);
		//distance = 20;
		size = distance*2 + 1;
		CreateTable();
		FillTable();
	}

	private void CreateTable()
	{
		tableMap.Rows.Clear();
		for (int i = 0; i < size; i++)
		{
			TableRow row = new TableRow();
			for (int j = 0; j < size; j++)
			{
				TableCell cell = new TableCell();
				cell.BorderWidth = 1;
				//cell.BackColor = System.Drawing.Color.Yellow;
				cell.Width = 30;
				row.Cells.Add(cell);
			}
			tableMap.Rows.Add(row);
		}
	}

	private void FillTable()
	{
		int x = Int32.Parse(textBoxX.Text);
		int y = Int32.Parse(textBoxY.Text);
		//int x = -27;
		//int y = -71;
		//int x = 0;
		//int y = 0;
		int xmin = x - distance;
		int xmax = x + distance;
		int ymin = y - distance;
		int ymax = y + distance;

		String sqlConnection = ConfigurationManager.ConnectionStrings["TravianMapConnectionString"].ToString();
		//(323074,-130,-3,2,81313,'Muta01',17696,'jezonsky',0,'',237);
		string sql =
			string.Format(
				@"
SELECT [x], [y], [tid], [village], [player], [aliance], [population], [uid] FROM [si_s3] 
WHERE (([x] > {0}) AND ([x] < {1}) AND ([y] < {2}) AND ([y] > {3}))
ORDER BY [x] DESC",
				xmin, xmax, ymax, ymin);

		String allyList = TextBoxAlly.Text;
		String napList = TextBoxNap.Text;
		String warList = TextBoxWar.Text;
		String aliance = textBoxAliance.Text;

		SqlConnection conn = new SqlConnection(sqlConnection);

		try
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader != null)
			{
				StringBuilder sb = new StringBuilder();
				while (reader.Read())
				{
					//labelErrorMSG.Text = ;
					Int32 xCor = Int32.Parse(reader[0].ToString().Trim());
					Int32 yCor = Int32.Parse(reader[1].ToString().Trim());
					String villageName = reader[3].ToString().Trim();
					String playerName = reader[4].ToString().Trim();
					String alianceName = reader[5].ToString().Trim();
					Int32 population = Int32.Parse(reader[6].ToString().Trim());
					Int32 uid = Int32.Parse(reader[7].ToString().Trim());
					int row = ymax > 0 ? Math.Abs((-yCor + Math.Abs(ymax))) : Math.Abs((-yCor - Math.Abs(ymax)));
					Int32 cell = (xCor - xmin);
					tableMap.Rows[row].Cells[cell].Text =
						String.Format(@"<a href=""http://s3.travian.si/spieler.php?uid={0}"">{1}</a>", uid, population);
					tableMap.Rows[row].Cells[cell].ToolTip =
						String.Format("({0})|({1})/{2}/{3}/{4}", xCor, yCor, villageName, playerName, alianceName);
					//player is in aliance
					if (alianceName.Length > 0)
					{
						if (allyList.IndexOf(alianceName) > -1)
						{
							tableMap.Rows[row].Cells[cell].BackColor = Color.Orange;
						}
						else if (napList.IndexOf(alianceName) > -1)
						{
							tableMap.Rows[row].Cells[cell].BackColor = Color.Yellow;
						}
						else if (warList.IndexOf(alianceName) > -1)
						{
							tableMap.Rows[row].Cells[cell].BackColor = Color.Green;
						}
						else if (aliance.Equals(alianceName))
						{
							tableMap.Rows[row].Cells[cell].BackColor = Color.Red;
						}
					}
					else
					{
						sb.AppendFormat("{0}|{1}|3|0,200,0,100,0,0,0,0,0,0,0,0|?newdid=10902|2|1|[{2}][V:{3}][P:{4}][A:{5}]\n",
							xCor, yCor, playerName, villageName, population, alianceName);
					}

					if ((xCor == x) && (yCor == y))
					{
						tableMap.Rows[row].Cells[cell].BackColor = Color.Blue;
					}
				}
				reader.Close();

				using (StreamWriter sw = new StreamWriter(@"C:\svn\jezaTools\jcTravianBot\jcMap\villages.txt"))
				{
					sw.WriteLine(sb);
					sw.Close();
				}
			}
		}
		catch (Exception e)
		{
			labelErrorMSG.Text = e.Message;
		}
		finally
		{
			conn.Close();
		}
	}
}
