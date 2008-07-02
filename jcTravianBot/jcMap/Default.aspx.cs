using System;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class _Default : System.Web.UI.Page 
{
	private int size;
	private int distance;
	private string myAlly = @"TSF";
	private string ally = @"SWAT,United 2,Horde™,Horde²™,BZP,United";
	private string nap = @"X Legija";
	private string war = "o.O";

	protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void linkButtonImportData_Click(object sender, EventArgs e)
	{

	}
	protected void linkButtonRefreshMap_Click(object sender, EventArgs e)
	{
		distance = Int32.Parse(textBoxDistance.Text);
		//distance = 10;
		size = distance * 2 + 1;
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
				cell.BackColor = System.Drawing.Color.Yellow;
				cell.Width = 30;
				row.Cells.Add(cell);
			}
			tableMap.Rows.Add(row);
		}
	}

	private void FillTable()
	{
		int x = Int32.Parse(textBoxX.Text.ToString());
		int y = Int32.Parse(textBoxY.Text.ToString());
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
		string sql = string.Format(@"
SELECT [x], [y], [tid], [village], [player], [aliance], [population], [uid] FROM [si_s1] 
WHERE (([x] > {0}) AND ([x] < {1}) AND ([y] < {2}) AND ([y] > {3}))", 
				xmin, xmax, ymax, ymin);

		SqlConnection conn = new SqlConnection(sqlConnection);

		try
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			if (reader != null)
			{
				while (reader.Read())
				{
					//labelErrorMSG.Text = ;
					Int32 xCor = Int32.Parse(reader[0].ToString());
					Int32 yCor = Int32.Parse(reader[1].ToString());
					tableMap.Rows[Math.Abs((yCor + Math.Abs(ymax)))].Cells[(xCor - xmin)].Text =
						String.Format(@"<a href=""http://s1.travian.si/spieler.php?uid={0}"">{1}</a>", reader[7].ToString().Trim(), reader[6].ToString().Trim());
					tableMap.Rows[Math.Abs((yCor + Math.Abs(ymax)))].Cells[(xCor - xmin)].ToolTip = "(" + reader[0].ToString().Trim() +
					                                                                                ")|(" + reader[1].ToString().Trim() +
					                                                                                ")/" + reader[3].ToString().Trim() +
					                                                                                "/" + reader[4].ToString().Trim() +
					                                                                                "/" +
					                                                                                reader[5].ToString().Trim();
					if (reader[4].ToString().ToLower().IndexOf("jezonsky") > -1)
					{
						tableMap.Rows[Math.Abs((yCor + Math.Abs(ymax)))].Cells[(xCor - xmin)].BackColor = System.Drawing.Color.Green;
					}
					//if (reader[5].ToString().ToLower().IndexOf(myAlly.ToLower()) > -1)
					//{
					//    tableMap.Rows[Math.Abs((yCor + Math.Abs(ymax)))].Cells[(xCor - xmin)].BackColor = System.Drawing.Color.GreenYellow;
					//}
					//if (reader[5].ToString().ToLower().IndexOf("BZP".ToLower()) > -1)
					//{
					//    tableMap.Rows[Math.Abs((yCor + Math.Abs(ymax)))].Cells[(xCor - xmin)].BackColor = System.Drawing.Color.SkyBlue;
					//}
					//if (reader[5].ToString().ToLower().IndexOf(war.ToLower()) > -1)
					//{
					//    tableMap.Rows[Math.Abs((yCor + Math.Abs(ymax)))].Cells[(xCor - xmin)].BackColor = System.Drawing.Color.Red;
					//}
				}
				reader.Close();
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
