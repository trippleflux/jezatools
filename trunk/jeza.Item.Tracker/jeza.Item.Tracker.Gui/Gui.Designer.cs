using System.Configuration;
using jeza.Item.Tracker.Settings;

namespace jeza.Item.Tracker.Gui
{
    partial class Gui
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        private Language language = Misc.GetLanguageSlovenian();

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        /// <param name="language1"></param>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gui));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.groupBoxOrders = new System.Windows.Forms.GroupBox();
            this.comboBoxOrersBank = new System.Windows.Forms.ComboBox();
            this.labelOrdersBank = new System.Windows.Forms.Label();
            this.buttonOrdersSum = new System.Windows.Forms.Button();
            this.labelOrdersSumNumber = new System.Windows.Forms.Label();
            this.labelOrdersId = new System.Windows.Forms.Label();
            this.buttonOrdersUpdate = new System.Windows.Forms.Button();
            this.buttonOrdersDelete = new System.Windows.Forms.Button();
            this.buttonOrdersSave = new System.Windows.Forms.Button();
            this.listBoxOrdersList = new System.Windows.Forms.ListBox();
            this.labelOrdersList = new System.Windows.Forms.Label();
            this.comboBoxOrdersItemType = new System.Windows.Forms.ComboBox();
            this.labelOrdersItemType = new System.Windows.Forms.Label();
            this.comboBoxOrdersPersonInfo = new System.Windows.Forms.ComboBox();
            this.labelOrdersPersonInfo = new System.Windows.Forms.Label();
            this.buttonOrdersSelect = new System.Windows.Forms.Button();
            this.textBoxOrdersPostage = new System.Windows.Forms.TextBox();
            this.labelOrdersPostage = new System.Windows.Forms.Label();
            this.comboBoxOrdersItemStatus = new System.Windows.Forms.ComboBox();
            this.checkBoxOrdersLegalEntity = new System.Windows.Forms.CheckBox();
            this.labelOrdersItemStatus = new System.Windows.Forms.Label();
            this.labelOrdersLegalEntity = new System.Windows.Forms.Label();
            this.textBoxOrdersTax = new System.Windows.Forms.TextBox();
            this.labelOrdersTax = new System.Windows.Forms.Label();
            this.textBoxOrdersPrice = new System.Windows.Forms.TextBox();
            this.labelOrdersPrice = new System.Windows.Forms.Label();
            this.textBoxOrdersItemCount = new System.Windows.Forms.TextBox();
            this.labelOrdersItemCount = new System.Windows.Forms.Label();
            this.labelOrdersPicture = new System.Windows.Forms.Label();
            this.comboBoxOrdersItem = new System.Windows.Forms.ComboBox();
            this.labelOrdersItem = new System.Windows.Forms.Label();
            this.pictureBoxOrders = new System.Windows.Forms.PictureBox();
            this.tabPageItems = new System.Windows.Forms.TabPage();
            this.groupBoxItems = new System.Windows.Forms.GroupBox();
            this.labelItemsId = new System.Windows.Forms.Label();
            this.buttonItemsUpdate = new System.Windows.Forms.Button();
            this.buttonItemsDelete = new System.Windows.Forms.Button();
            this.labelItemsDescription = new System.Windows.Forms.Label();
            this.textBoxItemsDescription = new System.Windows.Forms.TextBox();
            this.labelItemsImage = new System.Windows.Forms.Label();
            this.buttonItemsPictureBoxSelect = new System.Windows.Forms.Button();
            this.pictureBoxItems = new System.Windows.Forms.PictureBox();
            this.buttonItemsSelect = new System.Windows.Forms.Button();
            this.labelItemsType = new System.Windows.Forms.Label();
            this.comboBoxItemsType = new System.Windows.Forms.ComboBox();
            this.listBoxItemsList = new System.Windows.Forms.ListBox();
            this.buttonItemsSave = new System.Windows.Forms.Button();
            this.labelItemsName = new System.Windows.Forms.Label();
            this.textBoxItemsName = new System.Windows.Forms.TextBox();
            this.labelItemsList = new System.Windows.Forms.Label();
            this.tabPageItemType = new System.Windows.Forms.TabPage();
            this.groupBoxItemType = new System.Windows.Forms.GroupBox();
            this.dataGridViewItemType = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.labelItemTypeId = new System.Windows.Forms.Label();
            this.labelItemTypeList = new System.Windows.Forms.Label();
            this.textBoxItemTypeName = new System.Windows.Forms.TextBox();
            this.buttonItemTypeUpdate = new System.Windows.Forms.Button();
            this.buttonItemTypeDelete = new System.Windows.Forms.Button();
            this.labelItemTypeName = new System.Windows.Forms.Label();
            this.buttonItemTypeSave = new System.Windows.Forms.Button();
            this.labelItemTypeDescription = new System.Windows.Forms.Label();
            this.textBoxItemTypeDescription = new System.Windows.Forms.TextBox();
            this.tabPageItemStatus = new System.Windows.Forms.TabPage();
            this.groupBoxItemStatus = new System.Windows.Forms.GroupBox();
            this.labelItemStatusId = new System.Windows.Forms.Label();
            this.labelItemStatusList = new System.Windows.Forms.Label();
            this.labelItemStatusDescription = new System.Windows.Forms.Label();
            this.textBoxItemStatusDescription = new System.Windows.Forms.TextBox();
            this.buttonItemStatusUpdate = new System.Windows.Forms.Button();
            this.buttonItemStatusDelete = new System.Windows.Forms.Button();
            this.listBoxItemStatusList = new System.Windows.Forms.ListBox();
            this.buttonItemStatusSelect = new System.Windows.Forms.Button();
            this.buttonItemStatusSave = new System.Windows.Forms.Button();
            this.labelItemStatusName = new System.Windows.Forms.Label();
            this.textBoxItemStatusName = new System.Windows.Forms.TextBox();
            this.tabPagePersonInfo = new System.Windows.Forms.TabPage();
            this.groupBoxPersonInfo = new System.Windows.Forms.GroupBox();
            this.labelPersonInfoId = new System.Windows.Forms.Label();
            this.buttonPersonInfoSelect = new System.Windows.Forms.Button();
            this.buttonPersonInfoDelete = new System.Windows.Forms.Button();
            this.buttonPersonInfoUpdate = new System.Windows.Forms.Button();
            this.labelPersonInfoList = new System.Windows.Forms.Label();
            this.listBoxPersonInfoList = new System.Windows.Forms.ListBox();
            this.buttonPersonInfoSave = new System.Windows.Forms.Button();
            this.textBoxPersonInfoFaxNumber = new System.Windows.Forms.TextBox();
            this.labelPersonInfoFax = new System.Windows.Forms.Label();
            this.textBoxPersonInfoTelephoneMobile = new System.Windows.Forms.TextBox();
            this.labelPersonInfoTelephoneMobile = new System.Windows.Forms.Label();
            this.textBoxPersonInfoTelephone = new System.Windows.Forms.TextBox();
            this.labelPersonInfoTelephone = new System.Windows.Forms.Label();
            this.textBoxPersonInfoEmail = new System.Windows.Forms.TextBox();
            this.labelPersonInfoEmail = new System.Windows.Forms.Label();
            this.textBoxPersonInfoPopstNumber = new System.Windows.Forms.TextBox();
            this.labelPersonInfoPostNumber = new System.Windows.Forms.Label();
            this.textBoxPersonInfoCity = new System.Windows.Forms.TextBox();
            this.labelPersonInfoCity = new System.Windows.Forms.Label();
            this.textBoxPersonInfoAddress = new System.Windows.Forms.TextBox();
            this.labelPersonInfoAddress = new System.Windows.Forms.Label();
            this.textBoxPersonInfoDescription = new System.Windows.Forms.TextBox();
            this.labelPersonInfoDescription = new System.Windows.Forms.Label();
            this.textBoxPersonInfoNickName = new System.Windows.Forms.TextBox();
            this.labelPersonInfoNickName = new System.Windows.Forms.Label();
            this.textBoxPersonInfoSurName = new System.Windows.Forms.TextBox();
            this.labelPersonInfoSurName = new System.Windows.Forms.Label();
            this.textBoxPersonInfoName = new System.Windows.Forms.TextBox();
            this.labelPersonInfoName = new System.Windows.Forms.Label();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.groupBoxReports = new System.Windows.Forms.GroupBox();
            this.tabPageBank = new System.Windows.Forms.TabPage();
            this.groupBoxBank = new System.Windows.Forms.GroupBox();
            this.labelBankId = new System.Windows.Forms.Label();
            this.labelBankList = new System.Windows.Forms.Label();
            this.labelBankAccountNumber = new System.Windows.Forms.Label();
            this.textBoxBankAccountNumber = new System.Windows.Forms.TextBox();
            this.buttonBankUpdate = new System.Windows.Forms.Button();
            this.buttonBankDelete = new System.Windows.Forms.Button();
            this.listBoxBankList = new System.Windows.Forms.ListBox();
            this.buttonBankSelect = new System.Windows.Forms.Button();
            this.buttonBankSave = new System.Windows.Forms.Button();
            this.labelBankName = new System.Windows.Forms.Label();
            this.textBoxBankName = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            this.groupBoxOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrders)).BeginInit();
            this.tabPageItems.SuspendLayout();
            this.groupBoxItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItems)).BeginInit();
            this.tabPageItemType.SuspendLayout();
            this.groupBoxItemType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTypeBindingSource)).BeginInit();
            this.tabPageItemStatus.SuspendLayout();
            this.groupBoxItemStatus.SuspendLayout();
            this.tabPagePersonInfo.SuspendLayout();
            this.groupBoxPersonInfo.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.tabPageBank.SuspendLayout();
            this.groupBoxBank.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageOrders);
            this.tabControl.Controls.Add(this.tabPageItems);
            this.tabControl.Controls.Add(this.tabPageItemType);
            this.tabControl.Controls.Add(this.tabPageItemStatus);
            this.tabControl.Controls.Add(this.tabPagePersonInfo);
            this.tabControl.Controls.Add(this.tabPageReports);
            this.tabControl.Controls.Add(this.tabPageBank);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.groupBoxOrders);
            resources.ApplyResources(this.tabPageOrders, "tabPageOrders");
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // groupBoxOrders
            // 
            this.groupBoxOrders.Controls.Add(this.comboBoxOrersBank);
            this.groupBoxOrders.Controls.Add(this.labelOrdersBank);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersSum);
            this.groupBoxOrders.Controls.Add(this.labelOrdersSumNumber);
            this.groupBoxOrders.Controls.Add(this.labelOrdersId);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersUpdate);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersDelete);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersSave);
            this.groupBoxOrders.Controls.Add(this.listBoxOrdersList);
            this.groupBoxOrders.Controls.Add(this.labelOrdersList);
            this.groupBoxOrders.Controls.Add(this.comboBoxOrdersItemType);
            this.groupBoxOrders.Controls.Add(this.labelOrdersItemType);
            this.groupBoxOrders.Controls.Add(this.comboBoxOrdersPersonInfo);
            this.groupBoxOrders.Controls.Add(this.labelOrdersPersonInfo);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersSelect);
            this.groupBoxOrders.Controls.Add(this.textBoxOrdersPostage);
            this.groupBoxOrders.Controls.Add(this.labelOrdersPostage);
            this.groupBoxOrders.Controls.Add(this.comboBoxOrdersItemStatus);
            this.groupBoxOrders.Controls.Add(this.checkBoxOrdersLegalEntity);
            this.groupBoxOrders.Controls.Add(this.labelOrdersItemStatus);
            this.groupBoxOrders.Controls.Add(this.labelOrdersLegalEntity);
            this.groupBoxOrders.Controls.Add(this.textBoxOrdersTax);
            this.groupBoxOrders.Controls.Add(this.labelOrdersTax);
            this.groupBoxOrders.Controls.Add(this.textBoxOrdersPrice);
            this.groupBoxOrders.Controls.Add(this.labelOrdersPrice);
            this.groupBoxOrders.Controls.Add(this.textBoxOrdersItemCount);
            this.groupBoxOrders.Controls.Add(this.labelOrdersItemCount);
            this.groupBoxOrders.Controls.Add(this.labelOrdersPicture);
            this.groupBoxOrders.Controls.Add(this.comboBoxOrdersItem);
            this.groupBoxOrders.Controls.Add(this.labelOrdersItem);
            this.groupBoxOrders.Controls.Add(this.pictureBoxOrders);
            resources.ApplyResources(this.groupBoxOrders, "groupBoxOrders");
            this.groupBoxOrders.Name = "groupBoxOrders";
            this.groupBoxOrders.TabStop = false;
            // 
            // comboBoxOrersBank
            // 
            resources.ApplyResources(this.comboBoxOrersBank, "comboBoxOrersBank");
            this.comboBoxOrersBank.FormattingEnabled = true;
            this.comboBoxOrersBank.Name = "comboBoxOrersBank";
            // 
            // labelOrdersBank
            // 
            resources.ApplyResources(this.labelOrdersBank, "labelOrdersBank");
            this.labelOrdersBank.Name = "labelOrdersBank";
            // 
            // buttonOrdersSum
            // 
            resources.ApplyResources(this.buttonOrdersSum, "buttonOrdersSum");
            this.buttonOrdersSum.Name = "buttonOrdersSum";
            this.buttonOrdersSum.UseVisualStyleBackColor = true;
            this.buttonOrdersSum.Click += new System.EventHandler(this.ButtonOrdersSumClick);
            // 
            // labelOrdersSumNumber
            // 
            resources.ApplyResources(this.labelOrdersSumNumber, "labelOrdersSumNumber");
            this.labelOrdersSumNumber.Name = "labelOrdersSumNumber";
            // 
            // labelOrdersId
            // 
            resources.ApplyResources(this.labelOrdersId, "labelOrdersId");
            this.labelOrdersId.Name = "labelOrdersId";
            // 
            // buttonOrdersUpdate
            // 
            resources.ApplyResources(this.buttonOrdersUpdate, "buttonOrdersUpdate");
            this.buttonOrdersUpdate.Name = "buttonOrdersUpdate";
            this.buttonOrdersUpdate.UseVisualStyleBackColor = true;
            this.buttonOrdersUpdate.Click += new System.EventHandler(this.ButtonOrdersUpdateClick);
            // 
            // buttonOrdersDelete
            // 
            resources.ApplyResources(this.buttonOrdersDelete, "buttonOrdersDelete");
            this.buttonOrdersDelete.Name = "buttonOrdersDelete";
            this.buttonOrdersDelete.UseVisualStyleBackColor = true;
            this.buttonOrdersDelete.Click += new System.EventHandler(this.ButtonOrdersDeleteClick);
            // 
            // buttonOrdersSave
            // 
            resources.ApplyResources(this.buttonOrdersSave, "buttonOrdersSave");
            this.buttonOrdersSave.Name = "buttonOrdersSave";
            this.buttonOrdersSave.UseVisualStyleBackColor = true;
            this.buttonOrdersSave.Click += new System.EventHandler(this.ButtonOrderSaveClick);
            // 
            // listBoxOrdersList
            // 
            this.listBoxOrdersList.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxOrdersList, "listBoxOrdersList");
            this.listBoxOrdersList.Name = "listBoxOrdersList";
            // 
            // labelOrdersList
            // 
            resources.ApplyResources(this.labelOrdersList, "labelOrdersList");
            this.labelOrdersList.Name = "labelOrdersList";
            // 
            // comboBoxOrdersItemType
            // 
            this.comboBoxOrdersItemType.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxOrdersItemType, "comboBoxOrdersItemType");
            this.comboBoxOrdersItemType.Name = "comboBoxOrdersItemType";
            this.comboBoxOrdersItemType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOrderItemTypeSelectedIndexChanged);
            // 
            // labelOrdersItemType
            // 
            resources.ApplyResources(this.labelOrdersItemType, "labelOrdersItemType");
            this.labelOrdersItemType.Name = "labelOrdersItemType";
            // 
            // comboBoxOrdersPersonInfo
            // 
            this.comboBoxOrdersPersonInfo.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxOrdersPersonInfo, "comboBoxOrdersPersonInfo");
            this.comboBoxOrdersPersonInfo.Name = "comboBoxOrdersPersonInfo";
            // 
            // labelOrdersPersonInfo
            // 
            resources.ApplyResources(this.labelOrdersPersonInfo, "labelOrdersPersonInfo");
            this.labelOrdersPersonInfo.Name = "labelOrdersPersonInfo";
            // 
            // buttonOrdersSelect
            // 
            resources.ApplyResources(this.buttonOrdersSelect, "buttonOrdersSelect");
            this.buttonOrdersSelect.Name = "buttonOrdersSelect";
            this.buttonOrdersSelect.UseVisualStyleBackColor = true;
            this.buttonOrdersSelect.Click += new System.EventHandler(this.ButtonOrderSelectClick);
            // 
            // textBoxOrdersPostage
            // 
            resources.ApplyResources(this.textBoxOrdersPostage, "textBoxOrdersPostage");
            this.textBoxOrdersPostage.Name = "textBoxOrdersPostage";
            // 
            // labelOrdersPostage
            // 
            resources.ApplyResources(this.labelOrdersPostage, "labelOrdersPostage");
            this.labelOrdersPostage.Name = "labelOrdersPostage";
            // 
            // comboBoxOrdersItemStatus
            // 
            this.comboBoxOrdersItemStatus.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxOrdersItemStatus, "comboBoxOrdersItemStatus");
            this.comboBoxOrdersItemStatus.Name = "comboBoxOrdersItemStatus";
            // 
            // checkBoxOrdersLegalEntity
            // 
            resources.ApplyResources(this.checkBoxOrdersLegalEntity, "checkBoxOrdersLegalEntity");
            this.checkBoxOrdersLegalEntity.Name = "checkBoxOrdersLegalEntity";
            this.checkBoxOrdersLegalEntity.UseVisualStyleBackColor = true;
            // 
            // labelOrdersItemStatus
            // 
            resources.ApplyResources(this.labelOrdersItemStatus, "labelOrdersItemStatus");
            this.labelOrdersItemStatus.Name = "labelOrdersItemStatus";
            // 
            // labelOrdersLegalEntity
            // 
            resources.ApplyResources(this.labelOrdersLegalEntity, "labelOrdersLegalEntity");
            this.labelOrdersLegalEntity.Name = "labelOrdersLegalEntity";
            // 
            // textBoxOrdersTax
            // 
            resources.ApplyResources(this.textBoxOrdersTax, "textBoxOrdersTax");
            this.textBoxOrdersTax.Name = "textBoxOrdersTax";
            // 
            // labelOrdersTax
            // 
            resources.ApplyResources(this.labelOrdersTax, "labelOrdersTax");
            this.labelOrdersTax.Name = "labelOrdersTax";
            // 
            // textBoxOrdersPrice
            // 
            resources.ApplyResources(this.textBoxOrdersPrice, "textBoxOrdersPrice");
            this.textBoxOrdersPrice.Name = "textBoxOrdersPrice";
            // 
            // labelOrdersPrice
            // 
            resources.ApplyResources(this.labelOrdersPrice, "labelOrdersPrice");
            this.labelOrdersPrice.Name = "labelOrdersPrice";
            // 
            // textBoxOrdersItemCount
            // 
            resources.ApplyResources(this.textBoxOrdersItemCount, "textBoxOrdersItemCount");
            this.textBoxOrdersItemCount.Name = "textBoxOrdersItemCount";
            // 
            // labelOrdersItemCount
            // 
            resources.ApplyResources(this.labelOrdersItemCount, "labelOrdersItemCount");
            this.labelOrdersItemCount.Name = "labelOrdersItemCount";
            // 
            // labelOrdersPicture
            // 
            resources.ApplyResources(this.labelOrdersPicture, "labelOrdersPicture");
            this.labelOrdersPicture.Name = "labelOrdersPicture";
            // 
            // comboBoxOrdersItem
            // 
            this.comboBoxOrdersItem.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxOrdersItem, "comboBoxOrdersItem");
            this.comboBoxOrdersItem.Name = "comboBoxOrdersItem";
            this.comboBoxOrdersItem.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOrderItemSelectedIndexChanged);
            // 
            // labelOrdersItem
            // 
            resources.ApplyResources(this.labelOrdersItem, "labelOrdersItem");
            this.labelOrdersItem.Name = "labelOrdersItem";
            // 
            // pictureBoxOrders
            // 
            resources.ApplyResources(this.pictureBoxOrders, "pictureBoxOrders");
            this.pictureBoxOrders.Name = "pictureBoxOrders";
            this.pictureBoxOrders.TabStop = false;
            // 
            // tabPageItems
            // 
            this.tabPageItems.Controls.Add(this.groupBoxItems);
            resources.ApplyResources(this.tabPageItems, "tabPageItems");
            this.tabPageItems.Name = "tabPageItems";
            this.tabPageItems.UseVisualStyleBackColor = true;
            // 
            // groupBoxItems
            // 
            this.groupBoxItems.Controls.Add(this.labelItemsId);
            this.groupBoxItems.Controls.Add(this.buttonItemsUpdate);
            this.groupBoxItems.Controls.Add(this.buttonItemsDelete);
            this.groupBoxItems.Controls.Add(this.labelItemsDescription);
            this.groupBoxItems.Controls.Add(this.textBoxItemsDescription);
            this.groupBoxItems.Controls.Add(this.labelItemsImage);
            this.groupBoxItems.Controls.Add(this.buttonItemsPictureBoxSelect);
            this.groupBoxItems.Controls.Add(this.pictureBoxItems);
            this.groupBoxItems.Controls.Add(this.buttonItemsSelect);
            this.groupBoxItems.Controls.Add(this.labelItemsType);
            this.groupBoxItems.Controls.Add(this.comboBoxItemsType);
            this.groupBoxItems.Controls.Add(this.listBoxItemsList);
            this.groupBoxItems.Controls.Add(this.buttonItemsSave);
            this.groupBoxItems.Controls.Add(this.labelItemsName);
            this.groupBoxItems.Controls.Add(this.textBoxItemsName);
            this.groupBoxItems.Controls.Add(this.labelItemsList);
            resources.ApplyResources(this.groupBoxItems, "groupBoxItems");
            this.groupBoxItems.Name = "groupBoxItems";
            this.groupBoxItems.TabStop = false;
            // 
            // labelItemsId
            // 
            resources.ApplyResources(this.labelItemsId, "labelItemsId");
            this.labelItemsId.Name = "labelItemsId";
            // 
            // buttonItemsUpdate
            // 
            resources.ApplyResources(this.buttonItemsUpdate, "buttonItemsUpdate");
            this.buttonItemsUpdate.Name = "buttonItemsUpdate";
            this.buttonItemsUpdate.UseVisualStyleBackColor = true;
            this.buttonItemsUpdate.Click += new System.EventHandler(this.ButtonItemsUpdateClick);
            // 
            // buttonItemsDelete
            // 
            resources.ApplyResources(this.buttonItemsDelete, "buttonItemsDelete");
            this.buttonItemsDelete.Name = "buttonItemsDelete";
            this.buttonItemsDelete.UseVisualStyleBackColor = true;
            this.buttonItemsDelete.Click += new System.EventHandler(this.ButtonItemsDeleteClick);
            // 
            // labelItemsDescription
            // 
            resources.ApplyResources(this.labelItemsDescription, "labelItemsDescription");
            this.labelItemsDescription.Name = "labelItemsDescription";
            // 
            // textBoxItemsDescription
            // 
            resources.ApplyResources(this.textBoxItemsDescription, "textBoxItemsDescription");
            this.textBoxItemsDescription.Name = "textBoxItemsDescription";
            // 
            // labelItemsImage
            // 
            resources.ApplyResources(this.labelItemsImage, "labelItemsImage");
            this.labelItemsImage.Name = "labelItemsImage";
            // 
            // buttonItemsPictureBoxSelect
            // 
            resources.ApplyResources(this.buttonItemsPictureBoxSelect, "buttonItemsPictureBoxSelect");
            this.buttonItemsPictureBoxSelect.Name = "buttonItemsPictureBoxSelect";
            this.buttonItemsPictureBoxSelect.UseVisualStyleBackColor = true;
            this.buttonItemsPictureBoxSelect.Click += new System.EventHandler(this.ButtonItemsPictureBoxSelectClick);
            // 
            // pictureBoxItems
            // 
            resources.ApplyResources(this.pictureBoxItems, "pictureBoxItems");
            this.pictureBoxItems.Name = "pictureBoxItems";
            this.pictureBoxItems.TabStop = false;
            // 
            // buttonItemsSelect
            // 
            resources.ApplyResources(this.buttonItemsSelect, "buttonItemsSelect");
            this.buttonItemsSelect.Name = "buttonItemsSelect";
            this.buttonItemsSelect.UseVisualStyleBackColor = true;
            this.buttonItemsSelect.Click += new System.EventHandler(this.ButtonItemsSelectClick);
            // 
            // labelItemsType
            // 
            resources.ApplyResources(this.labelItemsType, "labelItemsType");
            this.labelItemsType.Name = "labelItemsType";
            // 
            // comboBoxItemsType
            // 
            this.comboBoxItemsType.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxItemsType, "comboBoxItemsType");
            this.comboBoxItemsType.Name = "comboBoxItemsType";
            // 
            // listBoxItemsList
            // 
            this.listBoxItemsList.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxItemsList, "listBoxItemsList");
            this.listBoxItemsList.Name = "listBoxItemsList";
            // 
            // buttonItemsSave
            // 
            resources.ApplyResources(this.buttonItemsSave, "buttonItemsSave");
            this.buttonItemsSave.Name = "buttonItemsSave";
            this.buttonItemsSave.UseVisualStyleBackColor = true;
            this.buttonItemsSave.Click += new System.EventHandler(this.ButtonItemsSaveClick);
            // 
            // labelItemsName
            // 
            resources.ApplyResources(this.labelItemsName, "labelItemsName");
            this.labelItemsName.Name = "labelItemsName";
            // 
            // textBoxItemsName
            // 
            resources.ApplyResources(this.textBoxItemsName, "textBoxItemsName");
            this.textBoxItemsName.Name = "textBoxItemsName";
            // 
            // labelItemsList
            // 
            resources.ApplyResources(this.labelItemsList, "labelItemsList");
            this.labelItemsList.Name = "labelItemsList";
            // 
            // tabPageItemType
            // 
            this.tabPageItemType.Controls.Add(this.groupBoxItemType);
            resources.ApplyResources(this.tabPageItemType, "tabPageItemType");
            this.tabPageItemType.Name = "tabPageItemType";
            this.tabPageItemType.UseVisualStyleBackColor = true;
            // 
            // groupBoxItemType
            // 
            this.groupBoxItemType.Controls.Add(this.dataGridViewItemType);
            this.groupBoxItemType.Controls.Add(this.labelItemTypeId);
            this.groupBoxItemType.Controls.Add(this.labelItemTypeList);
            this.groupBoxItemType.Controls.Add(this.textBoxItemTypeName);
            this.groupBoxItemType.Controls.Add(this.buttonItemTypeUpdate);
            this.groupBoxItemType.Controls.Add(this.buttonItemTypeDelete);
            this.groupBoxItemType.Controls.Add(this.labelItemTypeName);
            this.groupBoxItemType.Controls.Add(this.buttonItemTypeSave);
            this.groupBoxItemType.Controls.Add(this.labelItemTypeDescription);
            this.groupBoxItemType.Controls.Add(this.textBoxItemTypeDescription);
            resources.ApplyResources(this.groupBoxItemType, "groupBoxItemType");
            this.groupBoxItemType.Name = "groupBoxItemType";
            this.groupBoxItemType.TabStop = false;
            // 
            // dataGridViewItemType
            // 
            this.dataGridViewItemType.AllowUserToAddRows = false;
            this.dataGridViewItemType.AllowUserToDeleteRows = false;
            this.dataGridViewItemType.AutoGenerateColumns = false;
            this.dataGridViewItemType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dataGridViewItemType.DataSource = this.itemTypeBindingSource;
            resources.ApplyResources(this.dataGridViewItemType, "dataGridViewItemType");
            this.dataGridViewItemType.MultiSelect = false;
            this.dataGridViewItemType.Name = "dataGridViewItemType";
            this.dataGridViewItemType.ReadOnly = true;
            this.dataGridViewItemType.SelectionChanged += new System.EventHandler(this.DataGridViewItemTypeSelectionChanged);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            resources.ApplyResources(this.nameDataGridViewTextBoxColumn, "nameDataGridViewTextBoxColumn");
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "Description";
            resources.ApplyResources(this.descriptionDataGridViewTextBoxColumn, "descriptionDataGridViewTextBoxColumn");
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // itemTypeBindingSource
            // 
            this.itemTypeBindingSource.DataSource = typeof(jeza.Item.Tracker.ItemType);
            // 
            // labelItemTypeId
            // 
            resources.ApplyResources(this.labelItemTypeId, "labelItemTypeId");
            this.labelItemTypeId.Name = "labelItemTypeId";
            // 
            // labelItemTypeList
            // 
            resources.ApplyResources(this.labelItemTypeList, "labelItemTypeList");
            this.labelItemTypeList.Name = "labelItemTypeList";
            // 
            // textBoxItemTypeName
            // 
            resources.ApplyResources(this.textBoxItemTypeName, "textBoxItemTypeName");
            this.textBoxItemTypeName.Name = "textBoxItemTypeName";
            // 
            // buttonItemTypeUpdate
            // 
            resources.ApplyResources(this.buttonItemTypeUpdate, "buttonItemTypeUpdate");
            this.buttonItemTypeUpdate.Name = "buttonItemTypeUpdate";
            this.buttonItemTypeUpdate.UseVisualStyleBackColor = true;
            this.buttonItemTypeUpdate.Click += new System.EventHandler(this.ButtonItemTypeUpdateClick);
            // 
            // buttonItemTypeDelete
            // 
            resources.ApplyResources(this.buttonItemTypeDelete, "buttonItemTypeDelete");
            this.buttonItemTypeDelete.Name = "buttonItemTypeDelete";
            this.buttonItemTypeDelete.UseVisualStyleBackColor = true;
            this.buttonItemTypeDelete.Click += new System.EventHandler(this.ButtonItemTypeDeleteClick);
            // 
            // labelItemTypeName
            // 
            resources.ApplyResources(this.labelItemTypeName, "labelItemTypeName");
            this.labelItemTypeName.Name = "labelItemTypeName";
            // 
            // buttonItemTypeSave
            // 
            resources.ApplyResources(this.buttonItemTypeSave, "buttonItemTypeSave");
            this.buttonItemTypeSave.Name = "buttonItemTypeSave";
            this.buttonItemTypeSave.UseVisualStyleBackColor = true;
            this.buttonItemTypeSave.Click += new System.EventHandler(this.ButtonItemTypeSaveClick);
            // 
            // labelItemTypeDescription
            // 
            resources.ApplyResources(this.labelItemTypeDescription, "labelItemTypeDescription");
            this.labelItemTypeDescription.Name = "labelItemTypeDescription";
            // 
            // textBoxItemTypeDescription
            // 
            resources.ApplyResources(this.textBoxItemTypeDescription, "textBoxItemTypeDescription");
            this.textBoxItemTypeDescription.Name = "textBoxItemTypeDescription";
            // 
            // tabPageItemStatus
            // 
            this.tabPageItemStatus.Controls.Add(this.groupBoxItemStatus);
            resources.ApplyResources(this.tabPageItemStatus, "tabPageItemStatus");
            this.tabPageItemStatus.Name = "tabPageItemStatus";
            this.tabPageItemStatus.UseVisualStyleBackColor = true;
            // 
            // groupBoxItemStatus
            // 
            resources.ApplyResources(this.groupBoxItemStatus, "groupBoxItemStatus");
            this.groupBoxItemStatus.Controls.Add(this.labelItemStatusId);
            this.groupBoxItemStatus.Controls.Add(this.labelItemStatusList);
            this.groupBoxItemStatus.Controls.Add(this.labelItemStatusDescription);
            this.groupBoxItemStatus.Controls.Add(this.textBoxItemStatusDescription);
            this.groupBoxItemStatus.Controls.Add(this.buttonItemStatusUpdate);
            this.groupBoxItemStatus.Controls.Add(this.buttonItemStatusDelete);
            this.groupBoxItemStatus.Controls.Add(this.listBoxItemStatusList);
            this.groupBoxItemStatus.Controls.Add(this.buttonItemStatusSelect);
            this.groupBoxItemStatus.Controls.Add(this.buttonItemStatusSave);
            this.groupBoxItemStatus.Controls.Add(this.labelItemStatusName);
            this.groupBoxItemStatus.Controls.Add(this.textBoxItemStatusName);
            this.groupBoxItemStatus.Name = "groupBoxItemStatus";
            this.groupBoxItemStatus.TabStop = false;
            // 
            // labelItemStatusId
            // 
            resources.ApplyResources(this.labelItemStatusId, "labelItemStatusId");
            this.labelItemStatusId.Name = "labelItemStatusId";
            // 
            // labelItemStatusList
            // 
            resources.ApplyResources(this.labelItemStatusList, "labelItemStatusList");
            this.labelItemStatusList.Name = "labelItemStatusList";
            // 
            // labelItemStatusDescription
            // 
            resources.ApplyResources(this.labelItemStatusDescription, "labelItemStatusDescription");
            this.labelItemStatusDescription.Name = "labelItemStatusDescription";
            // 
            // textBoxItemStatusDescription
            // 
            resources.ApplyResources(this.textBoxItemStatusDescription, "textBoxItemStatusDescription");
            this.textBoxItemStatusDescription.Name = "textBoxItemStatusDescription";
            // 
            // buttonItemStatusUpdate
            // 
            resources.ApplyResources(this.buttonItemStatusUpdate, "buttonItemStatusUpdate");
            this.buttonItemStatusUpdate.Name = "buttonItemStatusUpdate";
            this.buttonItemStatusUpdate.UseVisualStyleBackColor = true;
            this.buttonItemStatusUpdate.Click += new System.EventHandler(this.ButtonItemStatusUpdateClick);
            // 
            // buttonItemStatusDelete
            // 
            resources.ApplyResources(this.buttonItemStatusDelete, "buttonItemStatusDelete");
            this.buttonItemStatusDelete.Name = "buttonItemStatusDelete";
            this.buttonItemStatusDelete.UseVisualStyleBackColor = true;
            this.buttonItemStatusDelete.Click += new System.EventHandler(this.ButtonItemStatusDeleteClick);
            // 
            // listBoxItemStatusList
            // 
            this.listBoxItemStatusList.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxItemStatusList, "listBoxItemStatusList");
            this.listBoxItemStatusList.Name = "listBoxItemStatusList";
            // 
            // buttonItemStatusSelect
            // 
            resources.ApplyResources(this.buttonItemStatusSelect, "buttonItemStatusSelect");
            this.buttonItemStatusSelect.Name = "buttonItemStatusSelect";
            this.buttonItemStatusSelect.UseVisualStyleBackColor = true;
            this.buttonItemStatusSelect.Click += new System.EventHandler(this.ButtonItemsStatusSelectClick);
            // 
            // buttonItemStatusSave
            // 
            resources.ApplyResources(this.buttonItemStatusSave, "buttonItemStatusSave");
            this.buttonItemStatusSave.Name = "buttonItemStatusSave";
            this.buttonItemStatusSave.UseVisualStyleBackColor = true;
            this.buttonItemStatusSave.Click += new System.EventHandler(this.ButtonItemsStatusSaveClick);
            // 
            // labelItemStatusName
            // 
            resources.ApplyResources(this.labelItemStatusName, "labelItemStatusName");
            this.labelItemStatusName.Name = "labelItemStatusName";
            // 
            // textBoxItemStatusName
            // 
            resources.ApplyResources(this.textBoxItemStatusName, "textBoxItemStatusName");
            this.textBoxItemStatusName.Name = "textBoxItemStatusName";
            // 
            // tabPagePersonInfo
            // 
            this.tabPagePersonInfo.Controls.Add(this.groupBoxPersonInfo);
            resources.ApplyResources(this.tabPagePersonInfo, "tabPagePersonInfo");
            this.tabPagePersonInfo.Name = "tabPagePersonInfo";
            this.tabPagePersonInfo.UseVisualStyleBackColor = true;
            // 
            // groupBoxPersonInfo
            // 
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoId);
            this.groupBoxPersonInfo.Controls.Add(this.buttonPersonInfoSelect);
            this.groupBoxPersonInfo.Controls.Add(this.buttonPersonInfoDelete);
            this.groupBoxPersonInfo.Controls.Add(this.buttonPersonInfoUpdate);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoList);
            this.groupBoxPersonInfo.Controls.Add(this.listBoxPersonInfoList);
            this.groupBoxPersonInfo.Controls.Add(this.buttonPersonInfoSave);
            this.groupBoxPersonInfo.Controls.Add(this.textBoxPersonInfoFaxNumber);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoFax);
            this.groupBoxPersonInfo.Controls.Add(this.textBoxPersonInfoTelephoneMobile);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoTelephoneMobile);
            this.groupBoxPersonInfo.Controls.Add(this.textBoxPersonInfoTelephone);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoTelephone);
            this.groupBoxPersonInfo.Controls.Add(this.textBoxPersonInfoEmail);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoEmail);
            this.groupBoxPersonInfo.Controls.Add(this.textBoxPersonInfoPopstNumber);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoPostNumber);
            this.groupBoxPersonInfo.Controls.Add(this.textBoxPersonInfoCity);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoCity);
            this.groupBoxPersonInfo.Controls.Add(this.textBoxPersonInfoAddress);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoAddress);
            this.groupBoxPersonInfo.Controls.Add(this.textBoxPersonInfoDescription);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoDescription);
            this.groupBoxPersonInfo.Controls.Add(this.textBoxPersonInfoNickName);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoNickName);
            this.groupBoxPersonInfo.Controls.Add(this.textBoxPersonInfoSurName);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoSurName);
            this.groupBoxPersonInfo.Controls.Add(this.textBoxPersonInfoName);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoName);
            resources.ApplyResources(this.groupBoxPersonInfo, "groupBoxPersonInfo");
            this.groupBoxPersonInfo.Name = "groupBoxPersonInfo";
            this.groupBoxPersonInfo.TabStop = false;
            // 
            // labelPersonInfoId
            // 
            resources.ApplyResources(this.labelPersonInfoId, "labelPersonInfoId");
            this.labelPersonInfoId.Name = "labelPersonInfoId";
            // 
            // buttonPersonInfoSelect
            // 
            resources.ApplyResources(this.buttonPersonInfoSelect, "buttonPersonInfoSelect");
            this.buttonPersonInfoSelect.Name = "buttonPersonInfoSelect";
            this.buttonPersonInfoSelect.UseVisualStyleBackColor = true;
            this.buttonPersonInfoSelect.Click += new System.EventHandler(this.ButtonPersonInfoListSelectClick);
            // 
            // buttonPersonInfoDelete
            // 
            resources.ApplyResources(this.buttonPersonInfoDelete, "buttonPersonInfoDelete");
            this.buttonPersonInfoDelete.Name = "buttonPersonInfoDelete";
            this.buttonPersonInfoDelete.UseVisualStyleBackColor = true;
            this.buttonPersonInfoDelete.Click += new System.EventHandler(this.ButtonPersonInfoDeleteClick);
            // 
            // buttonPersonInfoUpdate
            // 
            resources.ApplyResources(this.buttonPersonInfoUpdate, "buttonPersonInfoUpdate");
            this.buttonPersonInfoUpdate.Name = "buttonPersonInfoUpdate";
            this.buttonPersonInfoUpdate.UseVisualStyleBackColor = true;
            this.buttonPersonInfoUpdate.Click += new System.EventHandler(this.ButtonPersonInfoUpdateClick);
            // 
            // labelPersonInfoList
            // 
            resources.ApplyResources(this.labelPersonInfoList, "labelPersonInfoList");
            this.labelPersonInfoList.Name = "labelPersonInfoList";
            // 
            // listBoxPersonInfoList
            // 
            this.listBoxPersonInfoList.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxPersonInfoList, "listBoxPersonInfoList");
            this.listBoxPersonInfoList.Name = "listBoxPersonInfoList";
            // 
            // buttonPersonInfoSave
            // 
            resources.ApplyResources(this.buttonPersonInfoSave, "buttonPersonInfoSave");
            this.buttonPersonInfoSave.Name = "buttonPersonInfoSave";
            this.buttonPersonInfoSave.UseVisualStyleBackColor = true;
            this.buttonPersonInfoSave.Click += new System.EventHandler(this.ButtonPersonInfoSaveClick);
            // 
            // textBoxPersonInfoFaxNumber
            // 
            resources.ApplyResources(this.textBoxPersonInfoFaxNumber, "textBoxPersonInfoFaxNumber");
            this.textBoxPersonInfoFaxNumber.Name = "textBoxPersonInfoFaxNumber";
            // 
            // labelPersonInfoFax
            // 
            resources.ApplyResources(this.labelPersonInfoFax, "labelPersonInfoFax");
            this.labelPersonInfoFax.Name = "labelPersonInfoFax";
            // 
            // textBoxPersonInfoTelephoneMobile
            // 
            resources.ApplyResources(this.textBoxPersonInfoTelephoneMobile, "textBoxPersonInfoTelephoneMobile");
            this.textBoxPersonInfoTelephoneMobile.Name = "textBoxPersonInfoTelephoneMobile";
            // 
            // labelPersonInfoTelephoneMobile
            // 
            resources.ApplyResources(this.labelPersonInfoTelephoneMobile, "labelPersonInfoTelephoneMobile");
            this.labelPersonInfoTelephoneMobile.Name = "labelPersonInfoTelephoneMobile";
            // 
            // textBoxPersonInfoTelephone
            // 
            resources.ApplyResources(this.textBoxPersonInfoTelephone, "textBoxPersonInfoTelephone");
            this.textBoxPersonInfoTelephone.Name = "textBoxPersonInfoTelephone";
            // 
            // labelPersonInfoTelephone
            // 
            resources.ApplyResources(this.labelPersonInfoTelephone, "labelPersonInfoTelephone");
            this.labelPersonInfoTelephone.Name = "labelPersonInfoTelephone";
            // 
            // textBoxPersonInfoEmail
            // 
            resources.ApplyResources(this.textBoxPersonInfoEmail, "textBoxPersonInfoEmail");
            this.textBoxPersonInfoEmail.Name = "textBoxPersonInfoEmail";
            // 
            // labelPersonInfoEmail
            // 
            resources.ApplyResources(this.labelPersonInfoEmail, "labelPersonInfoEmail");
            this.labelPersonInfoEmail.Name = "labelPersonInfoEmail";
            // 
            // textBoxPersonInfoPopstNumber
            // 
            resources.ApplyResources(this.textBoxPersonInfoPopstNumber, "textBoxPersonInfoPopstNumber");
            this.textBoxPersonInfoPopstNumber.Name = "textBoxPersonInfoPopstNumber";
            // 
            // labelPersonInfoPostNumber
            // 
            resources.ApplyResources(this.labelPersonInfoPostNumber, "labelPersonInfoPostNumber");
            this.labelPersonInfoPostNumber.Name = "labelPersonInfoPostNumber";
            // 
            // textBoxPersonInfoCity
            // 
            resources.ApplyResources(this.textBoxPersonInfoCity, "textBoxPersonInfoCity");
            this.textBoxPersonInfoCity.Name = "textBoxPersonInfoCity";
            // 
            // labelPersonInfoCity
            // 
            resources.ApplyResources(this.labelPersonInfoCity, "labelPersonInfoCity");
            this.labelPersonInfoCity.Name = "labelPersonInfoCity";
            // 
            // textBoxPersonInfoAddress
            // 
            resources.ApplyResources(this.textBoxPersonInfoAddress, "textBoxPersonInfoAddress");
            this.textBoxPersonInfoAddress.Name = "textBoxPersonInfoAddress";
            // 
            // labelPersonInfoAddress
            // 
            resources.ApplyResources(this.labelPersonInfoAddress, "labelPersonInfoAddress");
            this.labelPersonInfoAddress.Name = "labelPersonInfoAddress";
            // 
            // textBoxPersonInfoDescription
            // 
            resources.ApplyResources(this.textBoxPersonInfoDescription, "textBoxPersonInfoDescription");
            this.textBoxPersonInfoDescription.Name = "textBoxPersonInfoDescription";
            // 
            // labelPersonInfoDescription
            // 
            resources.ApplyResources(this.labelPersonInfoDescription, "labelPersonInfoDescription");
            this.labelPersonInfoDescription.Name = "labelPersonInfoDescription";
            // 
            // textBoxPersonInfoNickName
            // 
            resources.ApplyResources(this.textBoxPersonInfoNickName, "textBoxPersonInfoNickName");
            this.textBoxPersonInfoNickName.Name = "textBoxPersonInfoNickName";
            // 
            // labelPersonInfoNickName
            // 
            resources.ApplyResources(this.labelPersonInfoNickName, "labelPersonInfoNickName");
            this.labelPersonInfoNickName.Name = "labelPersonInfoNickName";
            // 
            // textBoxPersonInfoSurName
            // 
            resources.ApplyResources(this.textBoxPersonInfoSurName, "textBoxPersonInfoSurName");
            this.textBoxPersonInfoSurName.Name = "textBoxPersonInfoSurName";
            // 
            // labelPersonInfoSurName
            // 
            resources.ApplyResources(this.labelPersonInfoSurName, "labelPersonInfoSurName");
            this.labelPersonInfoSurName.Name = "labelPersonInfoSurName";
            // 
            // textBoxPersonInfoName
            // 
            resources.ApplyResources(this.textBoxPersonInfoName, "textBoxPersonInfoName");
            this.textBoxPersonInfoName.Name = "textBoxPersonInfoName";
            // 
            // labelPersonInfoName
            // 
            resources.ApplyResources(this.labelPersonInfoName, "labelPersonInfoName");
            this.labelPersonInfoName.Name = "labelPersonInfoName";
            // 
            // tabPageReports
            // 
            this.tabPageReports.Controls.Add(this.groupBoxReports);
            resources.ApplyResources(this.tabPageReports, "tabPageReports");
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // groupBoxReports
            // 
            resources.ApplyResources(this.groupBoxReports, "groupBoxReports");
            this.groupBoxReports.Name = "groupBoxReports";
            this.groupBoxReports.TabStop = false;
            // 
            // tabPageBank
            // 
            this.tabPageBank.Controls.Add(this.groupBoxBank);
            resources.ApplyResources(this.tabPageBank, "tabPageBank");
            this.tabPageBank.Name = "tabPageBank";
            this.tabPageBank.UseVisualStyleBackColor = true;
            // 
            // groupBoxBank
            // 
            this.groupBoxBank.Controls.Add(this.labelBankId);
            this.groupBoxBank.Controls.Add(this.labelBankList);
            this.groupBoxBank.Controls.Add(this.labelBankAccountNumber);
            this.groupBoxBank.Controls.Add(this.textBoxBankAccountNumber);
            this.groupBoxBank.Controls.Add(this.buttonBankUpdate);
            this.groupBoxBank.Controls.Add(this.buttonBankDelete);
            this.groupBoxBank.Controls.Add(this.listBoxBankList);
            this.groupBoxBank.Controls.Add(this.buttonBankSelect);
            this.groupBoxBank.Controls.Add(this.buttonBankSave);
            this.groupBoxBank.Controls.Add(this.labelBankName);
            this.groupBoxBank.Controls.Add(this.textBoxBankName);
            resources.ApplyResources(this.groupBoxBank, "groupBoxBank");
            this.groupBoxBank.Name = "groupBoxBank";
            this.groupBoxBank.TabStop = false;
            // 
            // labelBankId
            // 
            resources.ApplyResources(this.labelBankId, "labelBankId");
            this.labelBankId.Name = "labelBankId";
            // 
            // labelBankList
            // 
            resources.ApplyResources(this.labelBankList, "labelBankList");
            this.labelBankList.Name = "labelBankList";
            // 
            // labelBankAccountNumber
            // 
            resources.ApplyResources(this.labelBankAccountNumber, "labelBankAccountNumber");
            this.labelBankAccountNumber.Name = "labelBankAccountNumber";
            // 
            // textBoxBankAccountNumber
            // 
            resources.ApplyResources(this.textBoxBankAccountNumber, "textBoxBankAccountNumber");
            this.textBoxBankAccountNumber.Name = "textBoxBankAccountNumber";
            // 
            // buttonBankUpdate
            // 
            resources.ApplyResources(this.buttonBankUpdate, "buttonBankUpdate");
            this.buttonBankUpdate.Name = "buttonBankUpdate";
            this.buttonBankUpdate.UseVisualStyleBackColor = true;
            this.buttonBankUpdate.Click += new System.EventHandler(this.buttonBankUpdate_Click);
            // 
            // buttonBankDelete
            // 
            resources.ApplyResources(this.buttonBankDelete, "buttonBankDelete");
            this.buttonBankDelete.Name = "buttonBankDelete";
            this.buttonBankDelete.UseVisualStyleBackColor = true;
            this.buttonBankDelete.Click += new System.EventHandler(this.buttonBankDelete_Click);
            // 
            // listBoxBankList
            // 
            this.listBoxBankList.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxBankList, "listBoxBankList");
            this.listBoxBankList.Name = "listBoxBankList";
            // 
            // buttonBankSelect
            // 
            resources.ApplyResources(this.buttonBankSelect, "buttonBankSelect");
            this.buttonBankSelect.Name = "buttonBankSelect";
            this.buttonBankSelect.UseVisualStyleBackColor = true;
            this.buttonBankSelect.Click += new System.EventHandler(this.buttonBankSelect_Click);
            // 
            // buttonBankSave
            // 
            resources.ApplyResources(this.buttonBankSave, "buttonBankSave");
            this.buttonBankSave.Name = "buttonBankSave";
            this.buttonBankSave.UseVisualStyleBackColor = true;
            this.buttonBankSave.Click += new System.EventHandler(this.buttonBankSave_Click);
            // 
            // labelBankName
            // 
            resources.ApplyResources(this.labelBankName, "labelBankName");
            this.labelBankName.Name = "labelBankName";
            // 
            // textBoxBankName
            // 
            resources.ApplyResources(this.textBoxBankName, "textBoxBankName");
            this.textBoxBankName.Name = "textBoxBankName";
            // 
            // Gui
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.HelpButton = true;
            this.IsMdiContainer = true;
            this.MaximizeBox = false;
            this.Name = "Gui";
            this.tabControl.ResumeLayout(false);
            this.tabPageOrders.ResumeLayout(false);
            this.groupBoxOrders.ResumeLayout(false);
            this.groupBoxOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrders)).EndInit();
            this.tabPageItems.ResumeLayout(false);
            this.groupBoxItems.ResumeLayout(false);
            this.groupBoxItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItems)).EndInit();
            this.tabPageItemType.ResumeLayout(false);
            this.groupBoxItemType.ResumeLayout(false);
            this.groupBoxItemType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTypeBindingSource)).EndInit();
            this.tabPageItemStatus.ResumeLayout(false);
            this.tabPageItemStatus.PerformLayout();
            this.groupBoxItemStatus.ResumeLayout(false);
            this.groupBoxItemStatus.PerformLayout();
            this.tabPagePersonInfo.ResumeLayout(false);
            this.groupBoxPersonInfo.ResumeLayout(false);
            this.groupBoxPersonInfo.PerformLayout();
            this.tabPageReports.ResumeLayout(false);
            this.tabPageBank.ResumeLayout(false);
            this.groupBoxBank.ResumeLayout(false);
            this.groupBoxBank.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageItems;
        private System.Windows.Forms.GroupBox groupBoxItems;
        private System.Windows.Forms.Button buttonItemsSave;
        private System.Windows.Forms.Label labelItemsName;
        private System.Windows.Forms.TextBox textBoxItemsName;
        private System.Windows.Forms.Label labelItemsList;
        private System.Windows.Forms.ListBox listBoxItemsList;
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.Label labelOrdersLegalEntity;
        private System.Windows.Forms.CheckBox checkBoxOrdersLegalEntity;
        private System.Windows.Forms.GroupBox groupBoxOrders;
        private System.Windows.Forms.ComboBox comboBoxOrdersPersonInfo;
        private System.Windows.Forms.Label labelOrdersPersonInfo;
        private System.Windows.Forms.Button buttonItemsSelect;
        private System.Windows.Forms.Label labelItemsType;
        private System.Windows.Forms.ComboBox comboBoxItemsType;
        private System.Windows.Forms.Button buttonItemsPictureBoxSelect;
        private System.Windows.Forms.PictureBox pictureBoxItems;
        private System.Windows.Forms.Label labelItemsImage;
        private System.Windows.Forms.PictureBox pictureBoxOrders;
        private System.Windows.Forms.ComboBox comboBoxOrdersItemStatus;
        private System.Windows.Forms.Label labelOrdersItemStatus;
        private System.Windows.Forms.TextBox textBoxOrdersTax;
        private System.Windows.Forms.Label labelOrdersTax;
        private System.Windows.Forms.TextBox textBoxOrdersPrice;
        private System.Windows.Forms.Label labelOrdersPrice;
        private System.Windows.Forms.TextBox textBoxOrdersItemCount;
        private System.Windows.Forms.Label labelOrdersItemCount;
        private System.Windows.Forms.Label labelOrdersPicture;
        private System.Windows.Forms.ComboBox comboBoxOrdersItem;
        private System.Windows.Forms.Label labelOrdersItem;
        private System.Windows.Forms.TextBox textBoxOrdersPostage;
        private System.Windows.Forms.Label labelOrdersPostage;
        private System.Windows.Forms.Button buttonOrdersSelect;
        private System.Windows.Forms.Label labelItemsDescription;
        private System.Windows.Forms.TextBox textBoxItemsDescription;
        private System.Windows.Forms.TabPage tabPageItemType;
        private System.Windows.Forms.TabPage tabPageItemStatus;
        private System.Windows.Forms.TabPage tabPagePersonInfo;
        private System.Windows.Forms.GroupBox groupBoxPersonInfo;
        private System.Windows.Forms.Button buttonPersonInfoSelect;
        private System.Windows.Forms.Button buttonPersonInfoDelete;
        private System.Windows.Forms.Button buttonPersonInfoUpdate;
        private System.Windows.Forms.Label labelPersonInfoList;
        private System.Windows.Forms.ListBox listBoxPersonInfoList;
        private System.Windows.Forms.Button buttonPersonInfoSave;
        private System.Windows.Forms.TextBox textBoxPersonInfoFaxNumber;
        private System.Windows.Forms.Label labelPersonInfoFax;
        private System.Windows.Forms.TextBox textBoxPersonInfoTelephoneMobile;
        private System.Windows.Forms.Label labelPersonInfoTelephoneMobile;
        private System.Windows.Forms.TextBox textBoxPersonInfoTelephone;
        private System.Windows.Forms.Label labelPersonInfoTelephone;
        private System.Windows.Forms.TextBox textBoxPersonInfoEmail;
        private System.Windows.Forms.Label labelPersonInfoEmail;
        private System.Windows.Forms.TextBox textBoxPersonInfoPopstNumber;
        private System.Windows.Forms.Label labelPersonInfoPostNumber;
        private System.Windows.Forms.TextBox textBoxPersonInfoCity;
        private System.Windows.Forms.Label labelPersonInfoCity;
        private System.Windows.Forms.TextBox textBoxPersonInfoAddress;
        private System.Windows.Forms.Label labelPersonInfoAddress;
        private System.Windows.Forms.TextBox textBoxPersonInfoDescription;
        private System.Windows.Forms.Label labelPersonInfoDescription;
        private System.Windows.Forms.TextBox textBoxPersonInfoNickName;
        private System.Windows.Forms.Label labelPersonInfoNickName;
        private System.Windows.Forms.TextBox textBoxPersonInfoSurName;
        private System.Windows.Forms.Label labelPersonInfoSurName;
        private System.Windows.Forms.TextBox textBoxPersonInfoName;
        private System.Windows.Forms.Label labelPersonInfoName;
        private System.Windows.Forms.Button buttonItemsUpdate;
        private System.Windows.Forms.Button buttonItemsDelete;
        private System.Windows.Forms.GroupBox groupBoxItemType;
        private System.Windows.Forms.Label labelItemTypeName;
        private System.Windows.Forms.Button buttonItemTypeSave;
        private System.Windows.Forms.Label labelItemTypeDescription;
        private System.Windows.Forms.TextBox textBoxItemTypeDescription;
        private System.Windows.Forms.GroupBox groupBoxItemStatus;
        private System.Windows.Forms.Button buttonItemStatusSelect;
        private System.Windows.Forms.Button buttonItemStatusSave;
        private System.Windows.Forms.Label labelItemStatusName;
        private System.Windows.Forms.TextBox textBoxItemStatusName;
        private System.Windows.Forms.Button buttonItemTypeUpdate;
        private System.Windows.Forms.Button buttonItemTypeDelete;
        private System.Windows.Forms.Button buttonItemStatusUpdate;
        private System.Windows.Forms.Button buttonItemStatusDelete;
        private System.Windows.Forms.ListBox listBoxItemStatusList;
        private System.Windows.Forms.Label labelItemStatusList;
        private System.Windows.Forms.Label labelItemStatusDescription;
        private System.Windows.Forms.TextBox textBoxItemStatusDescription;
        private System.Windows.Forms.Label labelItemTypeList;
        private System.Windows.Forms.TextBox textBoxItemTypeName;
        private System.Windows.Forms.ComboBox comboBoxOrdersItemType;
        private System.Windows.Forms.Label labelOrdersItemType;
        private System.Windows.Forms.Label labelItemsId;
        private System.Windows.Forms.Label labelItemTypeId;
        private System.Windows.Forms.Label labelItemStatusId;
        private System.Windows.Forms.Label labelPersonInfoId;
        private System.Windows.Forms.ListBox listBoxOrdersList;
        private System.Windows.Forms.Label labelOrdersList;
        private System.Windows.Forms.Button buttonOrdersSave;
        private System.Windows.Forms.Label labelOrdersId;
        private System.Windows.Forms.Button buttonOrdersUpdate;
        private System.Windows.Forms.Button buttonOrdersDelete;
        private System.Windows.Forms.Button buttonOrdersSum;
        private System.Windows.Forms.Label labelOrdersSumNumber;
        private System.Windows.Forms.GroupBox groupBoxReports;
        private System.Windows.Forms.TabPage tabPageBank;
        private System.Windows.Forms.GroupBox groupBoxBank;
        private System.Windows.Forms.Label labelBankId;
        private System.Windows.Forms.Label labelBankList;
        private System.Windows.Forms.Label labelBankAccountNumber;
        private System.Windows.Forms.TextBox textBoxBankAccountNumber;
        private System.Windows.Forms.Button buttonBankUpdate;
        private System.Windows.Forms.Button buttonBankDelete;
        private System.Windows.Forms.ListBox listBoxBankList;
        private System.Windows.Forms.Button buttonBankSelect;
        private System.Windows.Forms.Button buttonBankSave;
        private System.Windows.Forms.Label labelBankName;
        private System.Windows.Forms.TextBox textBoxBankName;
        private System.Windows.Forms.ComboBox comboBoxOrersBank;
        private System.Windows.Forms.Label labelOrdersBank;
        private System.Windows.Forms.DataGridView dataGridViewItemType;
        private System.Windows.Forms.BindingSource itemTypeBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    }
}

