#region

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Text;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;

#endregion

public partial class Main : Page
{
    private readonly SqlConnection sqlConnection =
        new SqlConnection(ConfigurationManager.ConnectionStrings["Coordinator"].ConnectionString);

    protected void Page_Load
        (object sender,
         EventArgs e)
    {
        if (!IsPostBack)
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "SELECT * FROM [Settings]";
            SqlDataReader reader = cmd.ExecuteReader();
            if (reader != null)
            {
                while (reader.Read())
                {
                    TextBoxDistanceX.Text = (reader["DistanceX"].ToString());
                    TextBoxDistanceY.Text = (reader["DistanceY"].ToString());
                    TextBoxNextFarm.Text = (reader["NextFarm"].ToString());
                    TextBoxAlly.Text = (reader["Ally"].ToString());
                    TextBoxNap.Text = (reader["Nap"].ToString());
                    TextBoxExcludedPlayers.Text = (reader["ExcludedPlayers"].ToString());
                    TextBoxExcludedAlliances.Text = (reader["ExcludedAlliances"].ToString());
                }
                reader.Close();
            }
            sqlConnection.Close();

            PopulateGridView();
        }
    }

    private void PopulateGridView()
    {
        try
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@CoordinateX", SqlDbType.Int).Value = -13;
            cmd.Parameters.Add("@CoordinateY", SqlDbType.Int).Value = 6;
            cmd.Parameters.Add("@DistanceX", SqlDbType.Int).Value = TextBoxDistanceX.Text;
            cmd.Parameters.Add("@DistanceY", SqlDbType.Int).Value = TextBoxDistanceY.Text;
            cmd.Parameters.Add("@CultureInfo", SqlDbType.NVarChar).Value = "sl-SI";
            //cmd.CommandText = "SelectMap";
            cmd.CommandText = String.Format(CultureInfo.InvariantCulture, 
                @"SELECT [Id]
      ,[CoordinateX]
      ,[CoordinateY]
      ,(SELECT [TribeName] FROM [Tribes] WHERE [Map].[TribeId]=[Tribes].[TribeId] AND [CultureInfo]=@CultureInfo) AS Tribe
      ,[VillageId]
      ,[VillageName]
      ,[UserId]
      ,[UserName]
      ,[AllianceId]
      ,[AllianceName]
      ,[Population]
      ,( ROUND(SQRT((@CoordinateX-[CoordinateX])*(@CoordinateX-[CoordinateX]) + (@CoordinateY-[CoordinateY])*(@CoordinateY-[CoordinateY])), 0) ) AS Distance
      ,(SELECT [Notes] FROM [Notes] WHERE [Map].[Id]=[Notes].[VillageCoordinates]) AS Notes
  FROM [Map]
WHERE (([CoordinateX] > @CoordinateX-@DistanceX) AND ([CoordinateX] < @CoordinateX+@DistanceX) AND ([CoordinateY] > @CoordinateY-@DistanceY) AND ([CoordinateY] < @CoordinateY+@DistanceY)) {0} {1} {2} {3}
ORDER BY Distance ASC", GetAlly(), GetNap(), GetExcludedUsers(), GetExcludedAlliances());
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet dataSet = new DataSet();
            const string srcTable = "Map";
            dataAdapter.Fill(dataSet, srcTable);
            gridViewFarms.DataSource = dataSet.Tables[srcTable].DefaultView;
            gridViewFarms.DataBind();
        }
        catch (SqlException ex)
        {
            LabelStatus.Text = ex.ToString();
        }
        finally
        {
            sqlConnection.Close();
        }
    }

    private string GetExcludedAlliances()
    {
        string text = TextBoxExcludedAlliances.Text;
        return ParseExcludedList(text, " AND NOT [AllianceId] = {0}");
    }

    private string GetExcludedUsers()
    {
        string text = TextBoxExcludedPlayers.Text;
        return ParseExcludedList(text, " AND NOT [UserId] = {0}");
    }

    private string GetNap()
    {
        string text = TextBoxNap.Text;
        return ParseExcludedList(text, " AND NOT [AllianceId] = {0}");
    }

    private string GetAlly()
    {
        string text = TextBoxAlly.Text;
        return ParseExcludedList(text, " AND NOT [AllianceId] = {0}");
    }

    private static string ParseExcludedList(string text,
                             string field)
    {
        if (text.Length > 0)
        {
            StringBuilder stringBuilder = new StringBuilder();
            if (text.IndexOf(',') > -1)
            {
                string[] aliances = text.Split(',');
                foreach (string alianceId in aliances)
                {
                    stringBuilder.AppendFormat(field, alianceId);
                }
                return stringBuilder.ToString();
            }
            return String.Format(CultureInfo.InvariantCulture, field, text);
        }
        return "";
    }

    protected void LinkButtonLogout_Click
        (object sender,
         EventArgs e)
    {
        FormsAuthentication.SignOut();
        FormsAuthentication.RedirectToLoginPage();
    }

    protected void gridViewFarms_PageIndexChanging
        (object sender,
         GridViewPageEventArgs e)
    {
        gridViewFarms.PageIndex = e.NewPageIndex;
        PopulateGridView();
    }

    protected void gridViewFarms_RowEditing
        (object sender,
         GridViewEditEventArgs e)
    {
        gridViewFarms.EditIndex = e.NewEditIndex;
        PopulateGridView();
    }

    protected void gridViewFarms_RowCancelingEdit
        (object sender,
         GridViewCancelEditEventArgs e)
    {
        gridViewFarms.EditIndex = -1;
        PopulateGridView();
    }

    protected void gridViewFarms_RowUpdating
        (object sender,
         GridViewUpdateEventArgs e)
    {
        GridViewRow row = gridViewFarms.Rows[e.RowIndex];
        try
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "UpdateNotes";
            cmd.Parameters.Add("@VillageCoordinates", SqlDbType.Int).Value = ((TextBox) row.Cells[0].Controls[0]).Text;
            cmd.Parameters.Add("@Notes", SqlDbType.NVarChar).Value = ((TextBox) row.Cells[7].Controls[0]).Text;
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            LabelStatus.Text = ex.ToString();
        }
        finally
        {
            sqlConnection.Close();
        }
        gridViewFarms.EditIndex = -1;
        PopulateGridView();
    }

    protected void LinkButtonUpdate_Click
        (object sender,
         EventArgs e)
    {
        try
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("@Server", SqlDbType.NVarChar).Value = "si1";
            cmd.Parameters.Add("@CoordinatesX", SqlDbType.Int).Value = -13;
            cmd.Parameters.Add("@CoordinatesY", SqlDbType.Int).Value = 6;
            cmd.Parameters.Add("@NextFarm", SqlDbType.NVarChar).Value = TextBoxNextFarm.Text;
            cmd.Parameters.Add("@DistanceX", SqlDbType.Int).Value = TextBoxDistanceX.Text;
            cmd.Parameters.Add("@DistanceY", SqlDbType.Int).Value = TextBoxDistanceY.Text;
            cmd.Parameters.Add("@Ally", SqlDbType.NVarChar).Value = TextBoxAlly.Text;
            cmd.Parameters.Add("@Nap", SqlDbType.NVarChar).Value = TextBoxNap.Text;
            cmd.Parameters.Add("@ExcludedPlayers", SqlDbType.NVarChar).Value = TextBoxExcludedPlayers.Text;
            cmd.Parameters.Add("@ExcludedAlliances", SqlDbType.NVarChar).Value = TextBoxExcludedAlliances.Text;
            cmd.CommandText =
                @"UPDATE [Settings]
   SET [Server] = @Server
      ,[CoordinatesX] = @CoordinatesX
      ,[CoordinatesY] = @CoordinatesY
      ,[NextFarm] = @NextFarm
      ,[DistanceX] = @DistanceX
      ,[DistanceY] = @DistanceY
      ,[Ally] = @Ally
      ,[Nap] = @Nap
      ,[ExcludedPlayers] = @ExcludedPlayers
      ,[ExcludedAlliances] = @ExcludedAlliances";
            cmd.ExecuteNonQuery();
        }
        catch (SqlException ex)
        {
            LabelStatus.Text = ex.ToString();
        }
        finally
        {
            sqlConnection.Close();
        }
    }
}