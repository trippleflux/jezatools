#region

using System;
using System.Data;
using System.Drawing;
using System.Web.UI;
using System.Web.UI.WebControls;
using TW.Helper;
using ZedGraph;
using ZedGraph.Web;

#endregion

public partial class Reports : Page
{
    protected void Page_Load
        (object sender,
         EventArgs e)
    {
        PanelGraphs.Visible = false;
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

    private void CreateGraph(TableRow row)
    {
        PanelGraphs.Visible = true;
        VillagePie.RenderGraph += ((webobject,
                                    g,
                                    pane) => OnRenderGraphVillagePie(webobject, g, pane, row));
    }

    /// <summary>
    /// This method is where you generate your graph.
    /// </summary>
    /// <param name="masterPane">You are provided with a MasterPane instance that
    /// contains one GraphPane by default (accessible via masterPane[0]).</param>
    /// <param name="g">A graphics instance so you can easily make the call to AxisChange()</param>
    /// <param name="z">And a ZedGraphWeb instance because the event handler requires it</param>
    /// <param name="row">Selected row n gridview.</param>
    private static void OnRenderGraphVillagePie
        (ZedGraphWeb z,
         Graphics g,
         MasterPane masterPane,
         TableRow row)
    {
        // Get the GraphPane so we can work with it
        GraphPane myPane = masterPane[0];

        // Fill the pane background with a color gradient
        myPane.Fill = new Fill(Color.White, Color.White, 45.0f);
        // No fill for the chart background
        myPane.Chart.Fill.Type = FillType.None;

        myPane.Legend.IsVisible = false;
        myPane.Legend.IsShowLegendSymbols = true;
        myPane.Legend.IsHStack = false;

        // Add some pie slices
        const string srcTable = "Goods";
        DataBase dataBase = new DataBase();
        DataSet dataSet = dataBase.GetGoods(srcTable, Misc.String2Number(row.Cells[0].Text.Trim()));
        DataRow dataRow = dataSet.Tables[srcTable].Rows[0];
        int wood = Misc.String2Number(dataRow.ItemArray[0].ToString());
        int clay = Misc.String2Number(dataRow.ItemArray[1].ToString());
        int iron = Misc.String2Number(dataRow.ItemArray[2].ToString());
        int crop = Misc.String2Number(dataRow.ItemArray[3].ToString());

        PieItem segmentWood = myPane.AddPieSlice(wood, Color.Green, Color.Green, 45f, 0, wood.ToString());
        PieItem segmentClay = myPane.AddPieSlice(clay, Color.OrangeRed, Color.OrangeRed, 45f, .0, clay.ToString());
        PieItem segmentIron = myPane.AddPieSlice(iron, Color.Blue, Color.Blue, 45f, 0, iron.ToString());
        PieItem segmentCrop = myPane.AddPieSlice(crop, Color.Yellow, Color.Yellow, 45f, 0.2, crop.ToString());

        segmentWood.LabelDetail.FontSpec.Size = 20f;
        segmentClay.LabelDetail.FontSpec.Size = 20f;
        segmentIron.LabelDetail.FontSpec.Size = 20f;
        segmentCrop.LabelDetail.FontSpec.Size = 20f;

        // Sum up the pie values                                                               
        CurveList curves = myPane.CurveList;
        double total = 0;
        for (int x = 0; x < curves.Count; x++)
        {
            total += ((PieItem) curves[x]).Value;
        }

        // Set the GraphPane title
        //myPane.Title.Text = String.Format("Total Goods : {0}\nWood : {1}\nClay : {2}\nIron : {3}\nCrop : {4}", total,
        //                                  wood, clay, iron, crop);
        myPane.Title.Text = String.Format("Total Goods : {0}", total);
        myPane.Title.FontSpec.IsItalic = true;
        myPane.Title.FontSpec.Size = 24f;
        myPane.Title.FontSpec.Family = "Times New Roman";

        masterPane.AxisChange(g);
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