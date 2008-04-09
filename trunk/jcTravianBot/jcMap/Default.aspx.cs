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

	protected void Page_Load(object sender, EventArgs e)
    {

    }
	protected void linkButtonImportData_Click(object sender, EventArgs e)
	{

	}
	protected void linkButtonRefreshMap_Click(object sender, EventArgs e)
	{
		//distance = Int32.Parse(textBoxDistance.Text);
		distance = 4;
		size = distance * 2 + 5;
		CreateTable();
		FillTable();
	}

	private void CreateTable()
	{
		for (int i = 0; i < size; i++)
		{
			TableRow row = new TableRow();
			for (int j = 0; j < size; j++)
			{
				TableCell cell = new TableCell();
				cell.BorderWidth = 1;
				row.Cells.Add(cell);
			}
			tableMap.Rows.Add(row);
		}
	}

	private void FillTable()
	{
		//int x = Int32.Parse(textBoxX.ToString());
		//int y = Int32.Parse(textBoxY.ToString());
		int x = -27;
		int y = -71;
		//int x = 0;
		//int y = 0;
		int xmin = x - distance;
		int xmax = x + distance;
		int ymin = y - distance;
		int ymax = y + distance;

		String sqlConnection = ConfigurationManager.ConnectionStrings["TravianMapConnectionString"].ToString();
		
		string sql = string.Format(@"
SELECT [x], [y], [tid], [village], [player], [aliance], [population] FROM [si_s3] 
WHERE (([x] > {0}) AND ([x] < {1}) AND ([y] < {2}) AND ([y] > {3}))", 
				xmin, xmax, ymax, ymin);

		SqlConnection conn = new SqlConnection(sqlConnection);

		try
		{
			conn.Open();
			SqlCommand cmd = new SqlCommand(sql, conn);
			SqlDataReader reader = cmd.ExecuteReader();
			while (reader.Read())
			{
				//labelErrorMSG.Text = ;
				Int32 xCor = Int32.Parse(reader[0].ToString());
				Int32 yCor = Int32.Parse(reader[1].ToString());
				//tableMap.Rows[distance + 1 + yCor].Cells[distance + 1 + xCor].Text = xCor + "/" + yCor;
				tableMap.Rows[distance + 1 + yCor].Cells[distance + 1 + xCor].Text = reader[4].ToString();
			}
			reader.Close();
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
