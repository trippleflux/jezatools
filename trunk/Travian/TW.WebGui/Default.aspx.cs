#region

using System;
using System.Data;
using System.Web.UI;
using System.Web.UI.WebControls;
using TW.Helper;

#endregion

public partial class Default : Page
{
    protected void Page_Load
        (object sender,
         EventArgs e)
    {
        PanelStats.Visible = false;
        TotalStats.Visible = false;
        if (!IsPostBack)
        {
            PopulateSettings();
            PopulateExcludedPlayers();
            PopulateNoGoods();
            PopulateExcludedAlliances((int)AllianceExcludedType.Ally, DropDownListAlly);
            PopulateExcludedAlliances((int) AllianceExcludedType.Nap, DropDownListNap);
            PopulateExcludedAlliances((int) AllianceExcludedType.Friend, DropDownListAllyFriends);
            UpdateGui();
            ClearTextFields();
        }
    }

    private void UpdateGui()
    {
        PopulateGridView();
        ClearTextFields();
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

    private void PopulateNoGoods()
    {
        const string srcTable = "NoGoods";
        DataBase dataBase = new DataBase();
        DataSet dataSet = dataBase.GetNoGoodsPlayers(srcTable);
        if (dataSet == null)
        {
            LabelStatus.Text = "Can't get list of NoGoods players!";
        }
        else
        {
            DropDownListNoGoods.DataSource = dataSet.Tables[srcTable].DefaultView;
            DropDownListNoGoods.DataBind();
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
        string notes = ((TextBox) row.Cells[8].Controls[0]).Text;
        DataBase dataBase = new DataBase();
        dataBase.UpdateNotes(coordinates, notes);
        GridViewVillages.EditIndex = -1;
        UpdateGui();
    }

    protected void GridViewVillages_SelectedIndexChanged
        (object sender,
         EventArgs e)
    {
        //GridViewRow row = GridViewVillages.SelectedRow;
    }

    protected void GridViewVillages_SelectedIndexChanging
        (object sender,
         GridViewSelectEventArgs e)
    {
        GridViewRow row = GridViewVillages.Rows[e.NewSelectedIndex];
        int villageId = Misc.String2Number(row.Cells[0].Text.Trim());
        PanelStats.Visible = true;
        TotalStats.Visible = true;
        string srcTable = "Goods";
        DataBase dataBase = new DataBase();
        DataSet dataSet = dataBase.GetGoods(srcTable, villageId);
        DataRow dataRow = dataSet.Tables[srcTable].Rows[0];
        string inputWood = dataRow.ItemArray[0].ToString();
        string inputClay = dataRow.ItemArray[1].ToString();
        string inputIron = dataRow.ItemArray[2].ToString();
        string inputCrop = dataRow.ItemArray[3].ToString();
        string inputVillageName = dataRow.ItemArray[4].ToString();
        LabelGoodsWood.Text = inputWood;
        LabelGoodsClay.Text = inputClay;
        LabelGoodsIron.Text = inputIron;
        LabelGoodsCrop.Text = inputCrop;
        int wood = Misc.String2Number(inputWood);
        int clay = Misc.String2Number(inputClay);
        int iron = Misc.String2Number(inputIron);
        int crop = Misc.String2Number(inputIron);
        int total = wood + clay + iron + crop;
        LabelGoodsTotal.Text = total.ToString();
        LabelVillageName.Text = inputVillageName;

        srcTable = "Reports";
        dataBase = new DataBase();
        dataSet = dataBase.GetLast5Reports(srcTable, villageId);
        RepeaterReports.DataSource = dataSet;
        RepeaterReports.DataMember = srcTable;
        RepeaterReports.DataBind();
    }

    protected void LinkButtonPopulate_Click
        (object sender,
         EventArgs e)
    {
        UpdateGui();
    }

    protected void LinkButtonNoGoodsAdd_Click(object sender, EventArgs e)
    {
        string id = TextBoxNoGoodsId.Text;
        string name = TextBoxNoGoodsName.Text;
        if (!Misc.IsNumber(id) || (name.Length < 1))
        {
            LabelStatus.Text = "Specify correct values...";
            return;
        }
        DataBase dataBase = new DataBase();
        if (dataBase.AddNoGoods(id, name))
        {
            PopulateNoGoods();
        }
        else
        {
            LabelStatus.Text = "Can't save excluded Player!";
        }
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

    protected void LinkButtonNoGoodsRemove_Click(object sender, EventArgs e)
    {
        string selectedValue = DropDownListNoGoods.SelectedValue;
        DataBase dataBase = new DataBase();
        if (dataBase.RemoveExcludedPlayer(selectedValue))
        {
            PopulateNoGoods();
        }
        else
        {
            LabelStatus.Text = "Can't remove excluded Player!";
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