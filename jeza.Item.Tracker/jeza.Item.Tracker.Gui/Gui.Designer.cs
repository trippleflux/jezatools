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
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.comboBoxOrersBank = new System.Windows.Forms.ComboBox();
            this.labelOrdersBank = new System.Windows.Forms.Label();
            this.buttonOrdersSum = new System.Windows.Forms.Button();
            this.labelOrdersSumNumber = new System.Windows.Forms.Label();
            this.labelOrdersId = new System.Windows.Forms.Label();
            this.buttonOrdersUpdate = new System.Windows.Forms.Button();
            this.buttonOrdersDelete = new System.Windows.Forms.Button();
            this.buttonOrdersSave = new System.Windows.Forms.Button();
            this.labelOrdersList = new System.Windows.Forms.Label();
            this.comboBoxOrdersItemType = new System.Windows.Forms.ComboBox();
            this.labelOrdersItemType = new System.Windows.Forms.Label();
            this.comboBoxOrdersPersonInfo = new System.Windows.Forms.ComboBox();
            this.labelOrdersPersonInfo = new System.Windows.Forms.Label();
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
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.columnItemItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelItemsId = new System.Windows.Forms.Label();
            this.buttonItemsUpdate = new System.Windows.Forms.Button();
            this.buttonItemsDelete = new System.Windows.Forms.Button();
            this.labelItemsDescription = new System.Windows.Forms.Label();
            this.textBoxItemsDescription = new System.Windows.Forms.TextBox();
            this.labelItemsImage = new System.Windows.Forms.Label();
            this.buttonItemsPictureBoxSelect = new System.Windows.Forms.Button();
            this.pictureBoxItems = new System.Windows.Forms.PictureBox();
            this.labelItemsType = new System.Windows.Forms.Label();
            this.comboBoxItemsType = new System.Windows.Forms.ComboBox();
            this.buttonItemsSave = new System.Windows.Forms.Button();
            this.labelItemsName = new System.Windows.Forms.Label();
            this.textBoxItemsName = new System.Windows.Forms.TextBox();
            this.labelItemsList = new System.Windows.Forms.Label();
            this.tabPageItemType = new System.Windows.Forms.TabPage();
            this.groupBoxItemType = new System.Windows.Forms.GroupBox();
            this.dataGridViewItemType = new System.Windows.Forms.DataGridView();
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
            this.dataGridViewItemStatus = new System.Windows.Forms.DataGridView();
            this.labelItemStatusId = new System.Windows.Forms.Label();
            this.labelItemStatusList = new System.Windows.Forms.Label();
            this.labelItemStatusDescription = new System.Windows.Forms.Label();
            this.textBoxItemStatusDescription = new System.Windows.Forms.TextBox();
            this.buttonItemStatusUpdate = new System.Windows.Forms.Button();
            this.buttonItemStatusDelete = new System.Windows.Forms.Button();
            this.buttonItemStatusSave = new System.Windows.Forms.Button();
            this.labelItemStatusName = new System.Windows.Forms.Label();
            this.textBoxItemStatusName = new System.Windows.Forms.TextBox();
            this.tabPagePersonInfo = new System.Windows.Forms.TabPage();
            this.groupBoxPersonInfo = new System.Windows.Forms.GroupBox();
            this.dataGridViewPersonInfo = new System.Windows.Forms.DataGridView();
            this.columnPersonInfoSurName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPersonInfoNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPersonInfoAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPersonInfoCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPersonInfoEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.labelPersonInfoId = new System.Windows.Forms.Label();
            this.buttonPersonInfoDelete = new System.Windows.Forms.Button();
            this.buttonPersonInfoUpdate = new System.Windows.Forms.Button();
            this.labelPersonInfoList = new System.Windows.Forms.Label();
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
            this.textBoxBankOwner = new System.Windows.Forms.TextBox();
            this.labelBankOwner = new System.Windows.Forms.Label();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.labelBankId = new System.Windows.Forms.Label();
            this.labelBankList = new System.Windows.Forms.Label();
            this.labelBankAccountNumber = new System.Windows.Forms.Label();
            this.textBoxBankAccountNumber = new System.Windows.Forms.TextBox();
            this.buttonBankUpdate = new System.Windows.Forms.Button();
            this.buttonBankDelete = new System.Windows.Forms.Button();
            this.buttonBankSave = new System.Windows.Forms.Button();
            this.labelBankName = new System.Windows.Forms.Label();
            this.textBoxBankName = new System.Windows.Forms.TextBox();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.columnItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.columnItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnItemTypeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.columnItemStatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnItemStatusDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.columnPersonInfoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.columnOrdersDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOrdersPersonInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOrdersItemStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOrdersItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOrdersCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOrdersPriceTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOrdersLegalEntity = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.tabControl.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            this.groupBoxOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrders)).BeginInit();
            this.tabPageItems.SuspendLayout();
            this.groupBoxItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItems)).BeginInit();
            this.tabPageItemType.SuspendLayout();
            this.groupBoxItemType.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemType)).BeginInit();
            this.tabPageItemStatus.SuspendLayout();
            this.groupBoxItemStatus.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemStatus)).BeginInit();
            this.tabPagePersonInfo.SuspendLayout();
            this.groupBoxPersonInfo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersonInfo)).BeginInit();
            this.tabPageReports.SuspendLayout();
            this.tabPageBank.SuspendLayout();
            this.groupBoxBank.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemStatusBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personInfoBindingSource)).BeginInit();
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
            this.groupBoxOrders.Controls.Add(this.dataGridViewOrders);
            this.groupBoxOrders.Controls.Add(this.comboBoxOrersBank);
            this.groupBoxOrders.Controls.Add(this.labelOrdersBank);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersSum);
            this.groupBoxOrders.Controls.Add(this.labelOrdersSumNumber);
            this.groupBoxOrders.Controls.Add(this.labelOrdersId);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersUpdate);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersDelete);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersSave);
            this.groupBoxOrders.Controls.Add(this.labelOrdersList);
            this.groupBoxOrders.Controls.Add(this.comboBoxOrdersItemType);
            this.groupBoxOrders.Controls.Add(this.labelOrdersItemType);
            this.groupBoxOrders.Controls.Add(this.comboBoxOrdersPersonInfo);
            this.groupBoxOrders.Controls.Add(this.labelOrdersPersonInfo);
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
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToDeleteRows = false;
            resources.ApplyResources(this.dataGridViewOrders, "dataGridViewOrders");
            this.dataGridViewOrders.AutoGenerateColumns = false;
            this.dataGridViewOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewOrders.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnOrdersDateTime,
            this.columnOrdersPersonInfo,
            this.columnOrdersItemStatus,
            this.columnOrdersItem,
            this.columnOrdersCount,
            this.columnOrdersPriceTotal,
            this.columnOrdersLegalEntity});
            this.dataGridViewOrders.DataSource = this.orderBindingSource;
            this.dataGridViewOrders.MultiSelect = false;
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.SelectionChanged += new System.EventHandler(this.DataGridViewOrdersSelectionChanged);
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
            this.groupBoxItems.Controls.Add(this.dataGridViewItems);
            this.groupBoxItems.Controls.Add(this.labelItemsId);
            this.groupBoxItems.Controls.Add(this.buttonItemsUpdate);
            this.groupBoxItems.Controls.Add(this.buttonItemsDelete);
            this.groupBoxItems.Controls.Add(this.labelItemsDescription);
            this.groupBoxItems.Controls.Add(this.textBoxItemsDescription);
            this.groupBoxItems.Controls.Add(this.labelItemsImage);
            this.groupBoxItems.Controls.Add(this.buttonItemsPictureBoxSelect);
            this.groupBoxItems.Controls.Add(this.pictureBoxItems);
            this.groupBoxItems.Controls.Add(this.labelItemsType);
            this.groupBoxItems.Controls.Add(this.comboBoxItemsType);
            this.groupBoxItems.Controls.Add(this.buttonItemsSave);
            this.groupBoxItems.Controls.Add(this.labelItemsName);
            this.groupBoxItems.Controls.Add(this.textBoxItemsName);
            this.groupBoxItems.Controls.Add(this.labelItemsList);
            resources.ApplyResources(this.groupBoxItems, "groupBoxItems");
            this.groupBoxItems.Name = "groupBoxItems";
            this.groupBoxItems.TabStop = false;
            // 
            // dataGridViewItems
            // 
            this.dataGridViewItems.AllowUserToAddRows = false;
            this.dataGridViewItems.AllowUserToDeleteRows = false;
            this.dataGridViewItems.AutoGenerateColumns = false;
            this.dataGridViewItems.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItems.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnItemName,
            this.columnItemDescription,
            this.columnItemItemTypeName});
            this.dataGridViewItems.DataSource = this.itemBindingSource;
            resources.ApplyResources(this.dataGridViewItems, "dataGridViewItems");
            this.dataGridViewItems.MultiSelect = false;
            this.dataGridViewItems.Name = "dataGridViewItems";
            this.dataGridViewItems.ReadOnly = true;
            this.dataGridViewItems.SelectionChanged += new System.EventHandler(this.DataGridViewItemsSelectionChanged);
            // 
            // columnItemItemTypeName
            // 
            this.columnItemItemTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnItemItemTypeName.DataPropertyName = "ItemTypeName";
            resources.ApplyResources(this.columnItemItemTypeName, "columnItemItemTypeName");
            this.columnItemItemTypeName.Name = "columnItemItemTypeName";
            this.columnItemItemTypeName.ReadOnly = true;
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
            resources.ApplyResources(this.dataGridViewItemType, "dataGridViewItemType");
            this.dataGridViewItemType.AutoGenerateColumns = false;
            this.dataGridViewItemType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnItemTypeName,
            this.columnItemTypeDescription});
            this.dataGridViewItemType.DataSource = this.itemTypeBindingSource;
            this.dataGridViewItemType.MultiSelect = false;
            this.dataGridViewItemType.Name = "dataGridViewItemType";
            this.dataGridViewItemType.ReadOnly = true;
            this.dataGridViewItemType.SelectionChanged += new System.EventHandler(this.DataGridViewItemTypeSelectionChanged);
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
            this.groupBoxItemStatus.Controls.Add(this.dataGridViewItemStatus);
            this.groupBoxItemStatus.Controls.Add(this.labelItemStatusId);
            this.groupBoxItemStatus.Controls.Add(this.labelItemStatusList);
            this.groupBoxItemStatus.Controls.Add(this.labelItemStatusDescription);
            this.groupBoxItemStatus.Controls.Add(this.textBoxItemStatusDescription);
            this.groupBoxItemStatus.Controls.Add(this.buttonItemStatusUpdate);
            this.groupBoxItemStatus.Controls.Add(this.buttonItemStatusDelete);
            this.groupBoxItemStatus.Controls.Add(this.buttonItemStatusSave);
            this.groupBoxItemStatus.Controls.Add(this.labelItemStatusName);
            this.groupBoxItemStatus.Controls.Add(this.textBoxItemStatusName);
            resources.ApplyResources(this.groupBoxItemStatus, "groupBoxItemStatus");
            this.groupBoxItemStatus.Name = "groupBoxItemStatus";
            this.groupBoxItemStatus.TabStop = false;
            // 
            // dataGridViewItemStatus
            // 
            this.dataGridViewItemStatus.AllowUserToAddRows = false;
            this.dataGridViewItemStatus.AllowUserToDeleteRows = false;
            this.dataGridViewItemStatus.AutoGenerateColumns = false;
            this.dataGridViewItemStatus.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemStatus.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnItemStatusName,
            this.columnItemStatusDescription});
            this.dataGridViewItemStatus.DataSource = this.itemStatusBindingSource;
            resources.ApplyResources(this.dataGridViewItemStatus, "dataGridViewItemStatus");
            this.dataGridViewItemStatus.MultiSelect = false;
            this.dataGridViewItemStatus.Name = "dataGridViewItemStatus";
            this.dataGridViewItemStatus.ReadOnly = true;
            this.dataGridViewItemStatus.SelectionChanged += new System.EventHandler(this.DataGridViewItemStatusSelectionChanged);
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
            this.groupBoxPersonInfo.Controls.Add(this.dataGridViewPersonInfo);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoId);
            this.groupBoxPersonInfo.Controls.Add(this.buttonPersonInfoDelete);
            this.groupBoxPersonInfo.Controls.Add(this.buttonPersonInfoUpdate);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoList);
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
            // dataGridViewPersonInfo
            // 
            this.dataGridViewPersonInfo.AllowUserToAddRows = false;
            this.dataGridViewPersonInfo.AllowUserToDeleteRows = false;
            this.dataGridViewPersonInfo.AutoGenerateColumns = false;
            this.dataGridViewPersonInfo.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewPersonInfo.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnPersonInfoName,
            this.columnPersonInfoSurName,
            this.columnPersonInfoNickName,
            this.columnPersonInfoAddress,
            this.columnPersonInfoCity,
            this.columnPersonInfoEmail});
            this.dataGridViewPersonInfo.DataSource = this.personInfoBindingSource;
            resources.ApplyResources(this.dataGridViewPersonInfo, "dataGridViewPersonInfo");
            this.dataGridViewPersonInfo.MultiSelect = false;
            this.dataGridViewPersonInfo.Name = "dataGridViewPersonInfo";
            this.dataGridViewPersonInfo.ReadOnly = true;
            this.dataGridViewPersonInfo.SelectionChanged += new System.EventHandler(this.DataGridViewPersonInfoSelectionChanged);
            // 
            // columnPersonInfoSurName
            // 
            this.columnPersonInfoSurName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnPersonInfoSurName.DataPropertyName = "SurName";
            resources.ApplyResources(this.columnPersonInfoSurName, "columnPersonInfoSurName");
            this.columnPersonInfoSurName.Name = "columnPersonInfoSurName";
            this.columnPersonInfoSurName.ReadOnly = true;
            // 
            // columnPersonInfoNickName
            // 
            this.columnPersonInfoNickName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnPersonInfoNickName.DataPropertyName = "NickName";
            resources.ApplyResources(this.columnPersonInfoNickName, "columnPersonInfoNickName");
            this.columnPersonInfoNickName.Name = "columnPersonInfoNickName";
            this.columnPersonInfoNickName.ReadOnly = true;
            // 
            // columnPersonInfoAddress
            // 
            this.columnPersonInfoAddress.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnPersonInfoAddress.DataPropertyName = "Address";
            resources.ApplyResources(this.columnPersonInfoAddress, "columnPersonInfoAddress");
            this.columnPersonInfoAddress.Name = "columnPersonInfoAddress";
            this.columnPersonInfoAddress.ReadOnly = true;
            // 
            // columnPersonInfoCity
            // 
            this.columnPersonInfoCity.DataPropertyName = "City";
            resources.ApplyResources(this.columnPersonInfoCity, "columnPersonInfoCity");
            this.columnPersonInfoCity.Name = "columnPersonInfoCity";
            this.columnPersonInfoCity.ReadOnly = true;
            // 
            // columnPersonInfoEmail
            // 
            this.columnPersonInfoEmail.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnPersonInfoEmail.DataPropertyName = "Email";
            resources.ApplyResources(this.columnPersonInfoEmail, "columnPersonInfoEmail");
            this.columnPersonInfoEmail.Name = "columnPersonInfoEmail";
            this.columnPersonInfoEmail.ReadOnly = true;
            // 
            // labelPersonInfoId
            // 
            resources.ApplyResources(this.labelPersonInfoId, "labelPersonInfoId");
            this.labelPersonInfoId.Name = "labelPersonInfoId";
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
            this.groupBoxBank.Controls.Add(this.textBoxBankOwner);
            this.groupBoxBank.Controls.Add(this.labelBankOwner);
            this.groupBoxBank.Controls.Add(this.dataGridView1);
            this.groupBoxBank.Controls.Add(this.labelBankId);
            this.groupBoxBank.Controls.Add(this.labelBankList);
            this.groupBoxBank.Controls.Add(this.labelBankAccountNumber);
            this.groupBoxBank.Controls.Add(this.textBoxBankAccountNumber);
            this.groupBoxBank.Controls.Add(this.buttonBankUpdate);
            this.groupBoxBank.Controls.Add(this.buttonBankDelete);
            this.groupBoxBank.Controls.Add(this.buttonBankSave);
            this.groupBoxBank.Controls.Add(this.labelBankName);
            this.groupBoxBank.Controls.Add(this.textBoxBankName);
            resources.ApplyResources(this.groupBoxBank, "groupBoxBank");
            this.groupBoxBank.Name = "groupBoxBank";
            this.groupBoxBank.TabStop = false;
            // 
            // textBoxBankOwner
            // 
            resources.ApplyResources(this.textBoxBankOwner, "textBoxBankOwner");
            this.textBoxBankOwner.Name = "textBoxBankOwner";
            // 
            // labelBankOwner
            // 
            resources.ApplyResources(this.labelBankOwner, "labelBankOwner");
            this.labelBankOwner.Name = "labelBankOwner";
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resources.ApplyResources(this.dataGridView1, "dataGridView1");
            this.dataGridView1.MultiSelect = false;
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
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
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(jeza.Item.Tracker.Order);
            // 
            // columnItemName
            // 
            this.columnItemName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnItemName.DataPropertyName = "Name";
            resources.ApplyResources(this.columnItemName, "columnItemName");
            this.columnItemName.Name = "columnItemName";
            this.columnItemName.ReadOnly = true;
            // 
            // columnItemDescription
            // 
            this.columnItemDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnItemDescription.DataPropertyName = "Description";
            resources.ApplyResources(this.columnItemDescription, "columnItemDescription");
            this.columnItemDescription.Name = "columnItemDescription";
            this.columnItemDescription.ReadOnly = true;
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(jeza.Item.Tracker.Item);
            // 
            // columnItemTypeName
            // 
            this.columnItemTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnItemTypeName.DataPropertyName = "Name";
            resources.ApplyResources(this.columnItemTypeName, "columnItemTypeName");
            this.columnItemTypeName.Name = "columnItemTypeName";
            this.columnItemTypeName.ReadOnly = true;
            // 
            // columnItemTypeDescription
            // 
            this.columnItemTypeDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnItemTypeDescription.DataPropertyName = "Description";
            resources.ApplyResources(this.columnItemTypeDescription, "columnItemTypeDescription");
            this.columnItemTypeDescription.Name = "columnItemTypeDescription";
            this.columnItemTypeDescription.ReadOnly = true;
            // 
            // itemTypeBindingSource
            // 
            this.itemTypeBindingSource.DataSource = typeof(jeza.Item.Tracker.ItemType);
            // 
            // columnItemStatusName
            // 
            this.columnItemStatusName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnItemStatusName.DataPropertyName = "Name";
            resources.ApplyResources(this.columnItemStatusName, "columnItemStatusName");
            this.columnItemStatusName.Name = "columnItemStatusName";
            this.columnItemStatusName.ReadOnly = true;
            // 
            // columnItemStatusDescription
            // 
            this.columnItemStatusDescription.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnItemStatusDescription.DataPropertyName = "Description";
            resources.ApplyResources(this.columnItemStatusDescription, "columnItemStatusDescription");
            this.columnItemStatusDescription.Name = "columnItemStatusDescription";
            this.columnItemStatusDescription.ReadOnly = true;
            // 
            // itemStatusBindingSource
            // 
            this.itemStatusBindingSource.DataSource = typeof(jeza.Item.Tracker.ItemStatus);
            // 
            // columnPersonInfoName
            // 
            this.columnPersonInfoName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnPersonInfoName.DataPropertyName = "Name";
            resources.ApplyResources(this.columnPersonInfoName, "columnPersonInfoName");
            this.columnPersonInfoName.Name = "columnPersonInfoName";
            this.columnPersonInfoName.ReadOnly = true;
            // 
            // personInfoBindingSource
            // 
            this.personInfoBindingSource.DataSource = typeof(jeza.Item.Tracker.PersonInfo);
            // 
            // columnOrdersDateTime
            // 
            this.columnOrdersDateTime.DataPropertyName = "DateTime";
            resources.ApplyResources(this.columnOrdersDateTime, "columnOrdersDateTime");
            this.columnOrdersDateTime.Name = "columnOrdersDateTime";
            this.columnOrdersDateTime.ReadOnly = true;
            // 
            // columnOrdersPersonInfo
            // 
            this.columnOrdersPersonInfo.DataPropertyName = "PersonInfoText";
            resources.ApplyResources(this.columnOrdersPersonInfo, "columnOrdersPersonInfo");
            this.columnOrdersPersonInfo.Name = "columnOrdersPersonInfo";
            this.columnOrdersPersonInfo.ReadOnly = true;
            // 
            // columnOrdersItemStatus
            // 
            this.columnOrdersItemStatus.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnOrdersItemStatus.DataPropertyName = "ItemStatusText";
            resources.ApplyResources(this.columnOrdersItemStatus, "columnOrdersItemStatus");
            this.columnOrdersItemStatus.Name = "columnOrdersItemStatus";
            this.columnOrdersItemStatus.ReadOnly = true;
            // 
            // columnOrdersItem
            // 
            this.columnOrdersItem.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnOrdersItem.DataPropertyName = "ItemText";
            resources.ApplyResources(this.columnOrdersItem, "columnOrdersItem");
            this.columnOrdersItem.Name = "columnOrdersItem";
            this.columnOrdersItem.ReadOnly = true;
            // 
            // columnOrdersCount
            // 
            this.columnOrdersCount.DataPropertyName = "Count";
            resources.ApplyResources(this.columnOrdersCount, "columnOrdersCount");
            this.columnOrdersCount.Name = "columnOrdersCount";
            this.columnOrdersCount.ReadOnly = true;
            // 
            // columnOrdersPriceTotal
            // 
            this.columnOrdersPriceTotal.DataPropertyName = "PriceTotal";
            resources.ApplyResources(this.columnOrdersPriceTotal, "columnOrdersPriceTotal");
            this.columnOrdersPriceTotal.Name = "columnOrdersPriceTotal";
            this.columnOrdersPriceTotal.ReadOnly = true;
            // 
            // columnOrdersLegalEntity
            // 
            this.columnOrdersLegalEntity.DataPropertyName = "LegalEntity";
            resources.ApplyResources(this.columnOrdersLegalEntity, "columnOrdersLegalEntity");
            this.columnOrdersLegalEntity.Name = "columnOrdersLegalEntity";
            this.columnOrdersLegalEntity.ReadOnly = true;
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
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrders)).EndInit();
            this.tabPageItems.ResumeLayout(false);
            this.groupBoxItems.ResumeLayout(false);
            this.groupBoxItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItems)).EndInit();
            this.tabPageItemType.ResumeLayout(false);
            this.groupBoxItemType.ResumeLayout(false);
            this.groupBoxItemType.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemType)).EndInit();
            this.tabPageItemStatus.ResumeLayout(false);
            this.groupBoxItemStatus.ResumeLayout(false);
            this.groupBoxItemStatus.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemStatus)).EndInit();
            this.tabPagePersonInfo.ResumeLayout(false);
            this.groupBoxPersonInfo.ResumeLayout(false);
            this.groupBoxPersonInfo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersonInfo)).EndInit();
            this.tabPageReports.ResumeLayout(false);
            this.tabPageBank.ResumeLayout(false);
            this.groupBoxBank.ResumeLayout(false);
            this.groupBoxBank.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemStatusBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personInfoBindingSource)).EndInit();
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
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.Label labelItemsType;
        private System.Windows.Forms.ComboBox comboBoxItemsType;
        private System.Windows.Forms.Button buttonItemsPictureBoxSelect;
        private System.Windows.Forms.PictureBox pictureBoxItems;
        private System.Windows.Forms.Label labelItemsImage;
        private System.Windows.Forms.Label labelItemsDescription;
        private System.Windows.Forms.TextBox textBoxItemsDescription;
        private System.Windows.Forms.TabPage tabPageItemType;
        private System.Windows.Forms.TabPage tabPageItemStatus;
        private System.Windows.Forms.TabPage tabPagePersonInfo;
        private System.Windows.Forms.GroupBox groupBoxPersonInfo;
        private System.Windows.Forms.Button buttonPersonInfoDelete;
        private System.Windows.Forms.Button buttonPersonInfoUpdate;
        private System.Windows.Forms.Label labelPersonInfoList;
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
        private System.Windows.Forms.Button buttonItemStatusSave;
        private System.Windows.Forms.Label labelItemStatusName;
        private System.Windows.Forms.TextBox textBoxItemStatusName;
        private System.Windows.Forms.Button buttonItemTypeUpdate;
        private System.Windows.Forms.Button buttonItemTypeDelete;
        private System.Windows.Forms.Button buttonItemStatusUpdate;
        private System.Windows.Forms.Button buttonItemStatusDelete;
        private System.Windows.Forms.Label labelItemStatusList;
        private System.Windows.Forms.Label labelItemStatusDescription;
        private System.Windows.Forms.TextBox textBoxItemStatusDescription;
        private System.Windows.Forms.Label labelItemTypeList;
        private System.Windows.Forms.TextBox textBoxItemTypeName;
        private System.Windows.Forms.Label labelItemsId;
        private System.Windows.Forms.Label labelItemTypeId;
        private System.Windows.Forms.Label labelItemStatusId;
        private System.Windows.Forms.Label labelPersonInfoId;
        private System.Windows.Forms.GroupBox groupBoxReports;
        private System.Windows.Forms.TabPage tabPageBank;
        private System.Windows.Forms.GroupBox groupBoxBank;
        private System.Windows.Forms.Label labelBankId;
        private System.Windows.Forms.Label labelBankList;
        private System.Windows.Forms.Label labelBankAccountNumber;
        private System.Windows.Forms.TextBox textBoxBankAccountNumber;
        private System.Windows.Forms.Button buttonBankUpdate;
        private System.Windows.Forms.Button buttonBankDelete;
        private System.Windows.Forms.Button buttonBankSave;
        private System.Windows.Forms.Label labelBankName;
        private System.Windows.Forms.TextBox textBoxBankName;
        private System.Windows.Forms.DataGridView dataGridViewItemType;
        private System.Windows.Forms.BindingSource itemTypeBindingSource;
        private System.Windows.Forms.BindingSource orderBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewItems;
        private System.Windows.Forms.BindingSource itemBindingSource;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnItemTypeDescription;
        private System.Windows.Forms.DataGridView dataGridViewItemStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnItemStatusName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnItemStatusDescription;
        private System.Windows.Forms.BindingSource itemStatusBindingSource;
        private System.Windows.Forms.DataGridView dataGridViewPersonInfo;
        private System.Windows.Forms.BindingSource personInfoBindingSource;
        private System.Windows.Forms.GroupBox groupBoxOrders;
        private System.Windows.Forms.DataGridView dataGridViewOrders;
        private System.Windows.Forms.ComboBox comboBoxOrersBank;
        private System.Windows.Forms.Label labelOrdersBank;
        private System.Windows.Forms.Button buttonOrdersSum;
        private System.Windows.Forms.Label labelOrdersSumNumber;
        private System.Windows.Forms.Label labelOrdersId;
        private System.Windows.Forms.Button buttonOrdersUpdate;
        private System.Windows.Forms.Button buttonOrdersDelete;
        private System.Windows.Forms.Button buttonOrdersSave;
        private System.Windows.Forms.Label labelOrdersList;
        private System.Windows.Forms.ComboBox comboBoxOrdersItemType;
        private System.Windows.Forms.Label labelOrdersItemType;
        private System.Windows.Forms.ComboBox comboBoxOrdersPersonInfo;
        private System.Windows.Forms.Label labelOrdersPersonInfo;
        private System.Windows.Forms.TextBox textBoxOrdersPostage;
        private System.Windows.Forms.Label labelOrdersPostage;
        private System.Windows.Forms.ComboBox comboBoxOrdersItemStatus;
        private System.Windows.Forms.CheckBox checkBoxOrdersLegalEntity;
        private System.Windows.Forms.Label labelOrdersItemStatus;
        private System.Windows.Forms.Label labelOrdersLegalEntity;
        private System.Windows.Forms.TextBox textBoxOrdersTax;
        private System.Windows.Forms.Label labelOrdersTax;
        private System.Windows.Forms.TextBox textBoxOrdersPrice;
        private System.Windows.Forms.Label labelOrdersPrice;
        private System.Windows.Forms.TextBox textBoxOrdersItemCount;
        private System.Windows.Forms.Label labelOrdersItemCount;
        private System.Windows.Forms.Label labelOrdersPicture;
        private System.Windows.Forms.ComboBox comboBoxOrdersItem;
        private System.Windows.Forms.Label labelOrdersItem;
        private System.Windows.Forms.PictureBox pictureBoxOrders;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox textBoxBankOwner;
        private System.Windows.Forms.Label labelBankOwner;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnItemName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnItemDescription;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnItemItemTypeName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPersonInfoName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPersonInfoSurName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPersonInfoNickName;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPersonInfoAddress;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPersonInfoCity;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnPersonInfoEmail;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOrdersDateTime;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOrdersPersonInfo;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOrdersItemStatus;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOrdersItem;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOrdersCount;
        private System.Windows.Forms.DataGridViewTextBoxColumn columnOrdersPriceTotal;
        private System.Windows.Forms.DataGridViewCheckBoxColumn columnOrdersLegalEntity;
    }
}

