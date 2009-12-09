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

public partial class Default : Page
{
    protected void Page_Load
        (object sender,
         EventArgs e)
    {
        if (!IsPostBack)
        {
            PopulateSettings();
            PopulateExcludedPlayers();
            PopulateExcludedAlliances((int) AllianceExcludedType.Ally, DropDownListAlly);
            PopulateExcludedAlliances((int) AllianceExcludedType.Nap, DropDownListNap);
            PopulateExcludedAlliances((int) AllianceExcludedType.Friend, DropDownListAllyFriends);
            UpdateGui();
            ClearTextFields();
        }
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

    private void UpdateGui()
    {
        PanelGraphs.Visible = false;
        PopulateGridView();
        ClearTextFields();
    }

    private void CreateGraph(TableRow row)
    {
        PanelGraphs.Visible = true;
        VillagePie.RenderGraph += ((webobject,
                                    g,
                                    pane) => OnRenderGraphVillagePie(webobject, g, pane, row));
    }

    private void PopulateSettings()
    {
        DataBase dataBase = new DataBase();
        WebGuiSettings settings = dataBase.GetSettings();
        if (settings == null)
        {
            LabelStatus.Text = "Can't read settings from DataBase!";
        }
        else
        {
            TextBoxCoordinateX.Text = settings.CoordinatesX.ToString();
            TextBoxCoordinateY.Text = settings.CoordinatesY.ToString();
            TextBoxNextFarm.Text = settings.NextFarm;
            TextBoxDistanceX.Text = settings.DistanceX.ToString();
            TextBoxDistanceY.Text = settings.DistanceY.ToString();
        }
    }

    private void PopulateExcludedAlliances
        (int type,
         BaseDataBoundControl list)
    {
        const string srcTable = "ExcludedAlliances";
        DataBase dataBase = new DataBase();
        DataSet dataSet = dataBase.GetExcludedAlliances(srcTable, type);
        if (dataSet == null)
        {
            LabelStatus.Text = "Can't get list of excluded alliances!";
        }
        else
        {
            list.DataSource = dataSet.Tables[srcTable].DefaultView;
            list.DataBind();
            ClearTextFields();
        }
    }

    private void PopulateExcludedPlayers()
    {
        const string srcTable = "ExcludedPlayers";
        DataBase dataBase = new DataBase();
        DataSet dataSet = dataBase.GetExcludedPlayers(srcTable);
        if (dataSet == null)
        {
            LabelStatus.Text = "Can't get list of excluded players!";
        }
        else
        {
            DropDownListExcludedPlayers.DataSource = dataSet.Tables[srcTable].DefaultView;
            DropDownListExcludedPlayers.DataBind();
            ClearTextFields();
        }
    }

    private void PopulateGridView()
    {
        LabelStatus.Text = "";
        if (!CheckInputData())
        {
            return;
        }
        DataBase dataBase = new DataBase();
        const string srcTable = "Map";
        DataSet dataSet = dataBase.PopulateGridView(srcTable);
        if (dataSet == null)
        {
            LabelStatus.Text = "Can't get list of villages!";
        }
        else
        {
            GridViewVillages.DataSource = dataSet.Tables[srcTable].DefaultView;
            GridViewVillages.DataBind();
        }
    }

    private bool CheckInputData()
    {
        if (!Misc.IsNumber(TextBoxCoordinateX.Text) ||
            !Misc.IsNumber(TextBoxCoordinateX.Text) ||
            !Misc.IsNumber(TextBoxCoordinateX.Text) ||
            !Misc.IsNumber(TextBoxCoordinateX.Text))
        {
            LabelStatus.Text = "Incorrect values specified...";
            return false;
        }
        return true;
    }

    protected void GridViewVillages_PageIndexChanging
        (object sender,
         GridViewPageEventArgs e)
    {
        GridViewVillages.PageIndex = e.NewPageIndex;
        UpdateGui();
    }

    protected void GridViewVillages_RowCancelingEdit
        (object sender,
         GridViewCancelEditEventArgs e)
    {
        GridViewVillages.EditIndex = -1;
        UpdateGui();
    }

    protected void GridViewVillages_RowEditing
        (object sender,
         GridViewEditEventArgs e)
    {
        GridViewVillages.EditIndex = e.NewEditIndex;
        UpdateGui();
    }

    protected void GridViewVillages_RowUpdating
        (object sender,
         GridViewUpdateEventArgs e)
    {
        GridViewRow row = GridViewVillages.Rows[e.RowIndex];
        int coordinates = Int32.Parse(((TextBox) row.Cells[0].Controls[0]).Text);
        string notes = ((TextBox) row.Cells[7].Controls[0]).Text;
        DataBase dataBase = new DataBase();
        dataBase.UpdateNotes(coordinates, notes);
        GridViewVillages.EditIndex = -1;
        UpdateGui();
    }

    protected void GridViewVillages_SelectedIndexChanged
        (object sender,
         EventArgs e)
    {
        GridViewRow row = GridViewVillages.SelectedRow;
    }

    protected void GridViewVillages_SelectedIndexChanging
        (object sender,
         GridViewSelectEventArgs e)
    {
        GridViewRow row = GridViewVillages.Rows[e.NewSelectedIndex];
        CreateGraph(row);
    }

    protected void LinkButtonPopulate_Click
        (object sender,
         EventArgs e)
    {
        UpdateGui();
    }

    protected void LinkButtonAddExcludedPlayer_Click
        (object sender,
         EventArgs e)
    {
        string id = TextBoxAddExcludedPlayerId.Text;
        string name = TextBoxAddExcludedPlayerName.Text;
        if (!Misc.IsNumber(id) || (name.Length < 1))
        {
            LabelStatus.Text = "Specify correct values...";
            return;
        }
        DataBase dataBase = new DataBase();
        if (dataBase.AddExcludedPlayer(id, name))
        {
            PopulateExcludedPlayers();
        }
        else
        {
            LabelStatus.Text = "Can't save excluded Player!";
        }
    }

    protected void LinkButtonSave_Click
        (object sender,
         EventArgs e)
    {
        string nextFarm = TextBoxNextFarm.Text;
        if (!CheckInputData())
        {
            return;
        }
        DataBase dataBase = new DataBase();
        WebGuiSettings webGuiSettings = new WebGuiSettings
                                        {
                                            CoordinatesX = Int32.Parse(TextBoxCoordinateX.Text),
                                            CoordinatesY = Int32.Parse(TextBoxCoordinateY.Text),
                                            NextFarm = nextFarm.Length < 1 ? "-" : nextFarm,
                                            DistanceX = Int32.Parse(TextBoxDistanceX.Text),
                                            DistanceY = Int32.Parse(TextBoxDistanceY.Text)
                                        };
        if (!dataBase.SaveSettings(webGuiSettings))
        {
            LabelStatus.Text = "Can't save settings to DataBase!";
        }
    }

    protected void LinkButtonRemoveExcludedPlayer_Click
        (object sender,
         EventArgs e)
    {
        string selectedValue = DropDownListExcludedPlayers.SelectedValue;
        DataBase dataBase = new DataBase();
        if (dataBase.RemoveExcludedPlayer(selectedValue))
        {
            PopulateExcludedPlayers();
        }
        else
        {
            LabelStatus.Text = "Can't remove excluded Player!";
        }
    }

    protected void LinkButtonRemoveAlly_Click
        (object sender,
         EventArgs e)
    {
        if (DropDownListAlly.Items.Count == 0)
        {
            return;
        }
        RemoveAllianceFromExcludedList(DropDownListAlly.SelectedValue);
    }

    protected void LinkButtonRemoveNap_Click
        (object sender,
         EventArgs e)
    {
        if (DropDownListNap.Items.Count == 0)
        {
            return;
        }
        RemoveAllianceFromExcludedList(DropDownListNap.SelectedValue);
    }

    protected void LinkButtonRemoveAllyFriends_Click
        (object sender,
         EventArgs e)
    {
        if (DropDownListAllyFriends.Items.Count == 0)
        {
            return;
        }
        RemoveAllianceFromExcludedList(DropDownListAllyFriends.SelectedValue);
    }

    private void ClearTextFields()
    {
        const string empty = "";
        TextBoxAddExcludedPlayerId.Text = empty;
        TextBoxAddExcludedPlayerName.Text = empty;
        TextBoxAddAllyId.Text = empty;
        TextBoxAddAllyName.Text = empty;
        TextBoxAddNapId.Text = empty;
        TextBoxAddNapName.Text = empty;
        TextBoxAddFriendsId.Text = empty;
        TextBoxAddFriendsName.Text = empty;
    }

    private void RemoveAllianceFromExcludedList(string selectedValue)
    {
        DataBase dataBase = new DataBase();
        if (!dataBase.RemoveExcludedAlliance(selectedValue))
        {
            LabelStatus.Text = "Can't remove excluded Alliance!";
        }
        else
        {
            ClearTextFields();
        }
    }

    private void AddAlliance
        (ITextControl allyId,
         ITextControl allyName,
         int type,
         BaseDataBoundControl downListAlly)
    {
        string id = allyId.Text;
        string name = allyName.Text;
        if (!Misc.IsNumber(id) || (name.Length < 1))
        {
            LabelStatus.Text = "Specify correct values...";
            return;
        }
        DataBase dataBase = new DataBase();
        if (dataBase.AddExcludedAlliance(id, name, type))
        {
            PopulateExcludedAlliances(type, downListAlly);
        }
        else
        {
            LabelStatus.Text = "Can't save excluded Alliance!";
        }
    }

    protected void LinkButtonAddAlly_Click
        (object sender,
         EventArgs e)
    {
        AddAlliance(TextBoxAddAllyId, TextBoxAddAllyName, (int) AllianceExcludedType.Ally, DropDownListAlly);
    }

    protected void LinkButtonAddNap_Click
        (object sender,
         EventArgs e)
    {
        AddAlliance(TextBoxAddNapId, TextBoxAddNapName, (int) AllianceExcludedType.Nap, DropDownListNap);
    }

    protected void LinkButtonAddFriends_Click
        (object sender,
         EventArgs e)
    {
        AddAlliance(TextBoxAddFriendsId, TextBoxAddFriendsName, (int) AllianceExcludedType.Friend,
                    DropDownListAllyFriends);
    }
}