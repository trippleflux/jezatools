#region

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TW.Helper;

#endregion

public partial class Reports : Page
{
    protected void Page_Load
        (object sender,
         EventArgs e)
    {
        if (!IsPostBack)
        {
            Populate();
        }
    }

    private void Populate()
    {
        LabelStatus.Text = "";
        DataBase dataBase = new DataBase();
        const string srcTable = "Reports";
        DataSet dataSet = dataBase.PopulateGridViewReports(srcTable);
        if (dataSet == null)
        {
            LabelStatus.Text = "Can't get list of reports!";
        }
        else
        {
            GridViewReports.DataSource = dataSet.Tables[srcTable].DefaultView;
            GridViewReports.DataBind();
        }
    }

    protected void LinkButtonPopulate_Click
        (object sender,
         EventArgs e)
    {
        Populate();
    }

    protected void GridViewReports_PageIndexChanging
        (object sender,
         GridViewPageEventArgs e)
    {
        GridViewReports.PageIndex = e.NewPageIndex;
        Populate();
    }
}