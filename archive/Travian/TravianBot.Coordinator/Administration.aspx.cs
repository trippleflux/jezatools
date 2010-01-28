#region

using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Web.Security;
using System.Web.UI;

#endregion

public partial class Administration : Page
{
    protected void Page_Load
        (object sender,
         EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateGridView();
        }
    }

    private void PopulateGridView()
    {
        SqlConnection sqlConnection =
            new SqlConnection(ConfigurationManager.ConnectionStrings["Coordinator"].ConnectionString);
        try
        {
            sqlConnection.Open();
            SqlCommand cmd = sqlConnection.CreateCommand();
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = "SelectUsers";
            SqlDataAdapter dataAdapter = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            const string srcTable = "Users";
            dataAdapter.Fill(ds, srcTable);
            GridViewUsers.DataSource = ds.Tables[srcTable].DefaultView;
            GridViewUsers.DataBind();
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

    protected void LinkButtonLogout_Click
        (object sender,
         EventArgs e)
    {
        FormsAuthentication.SignOut();
        FormsAuthentication.RedirectToLoginPage();
    }
}