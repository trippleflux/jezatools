using System.Configuration;
using System.Drawing;
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
            this.groupBoxOrdersList = new System.Windows.Forms.GroupBox();
            this.dataGridViewOrders = new System.Windows.Forms.DataGridView();
            this.columnOrdersDateTime = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOrdersPersonInfo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOrdersItemStatus = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOrdersItem = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOrdersCount = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOrdersPriceTotal = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnOrdersLegalEntity = new System.Windows.Forms.DataGridViewCheckBoxColumn();
            this.orderBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxOrders = new System.Windows.Forms.GroupBox();
            this.comboBoxOrdersBank = new System.Windows.Forms.ComboBox();
            this.labelOrdersBank = new System.Windows.Forms.Label();
            this.buttonOrdersSum = new System.Windows.Forms.Button();
            this.labelOrdersSumNumber = new System.Windows.Forms.Label();
            this.labelOrdersId = new System.Windows.Forms.Label();
            this.buttonOrdersUpdate = new System.Windows.Forms.Button();
            this.buttonOrdersDelete = new System.Windows.Forms.Button();
            this.buttonOrdersSave = new System.Windows.Forms.Button();
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
            this.groupBoxItemsList = new System.Windows.Forms.GroupBox();
            this.dataGridViewItems = new System.Windows.Forms.DataGridView();
            this.columnItemName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnItemDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnItemItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxItems = new System.Windows.Forms.GroupBox();
            this.textBoxItemsPrice = new System.Windows.Forms.TextBox();
            this.labelItemsPrice = new System.Windows.Forms.Label();
            this.labelItemsId = new System.Windows.Forms.Label();
            this.buttonItemsUpdate = new System.Windows.Forms.Button();
            this.buttonItemsDelete = new System.Windows.Forms.Button();
            this.labelItemsDescription = new System.Windows.Forms.Label();
            this.textBoxItemsDescription = new System.Windows.Forms.TextBox();
            this.buttonItemsPictureBoxSelect = new System.Windows.Forms.Button();
            this.pictureBoxItems = new System.Windows.Forms.PictureBox();
            this.labelItemsType = new System.Windows.Forms.Label();
            this.comboBoxItemsType = new System.Windows.Forms.ComboBox();
            this.buttonItemsSave = new System.Windows.Forms.Button();
            this.labelItemsName = new System.Windows.Forms.Label();
            this.textBoxItemsName = new System.Windows.Forms.TextBox();
            this.tabPageItemType = new System.Windows.Forms.TabPage();
            this.groupBoxItemTypeList = new System.Windows.Forms.GroupBox();
            this.dataGridViewItemType = new System.Windows.Forms.DataGridView();
            this.columnItemTypeName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnItemTypeDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxItemType = new System.Windows.Forms.GroupBox();
            this.labelItemTypeId = new System.Windows.Forms.Label();
            this.textBoxItemTypeName = new System.Windows.Forms.TextBox();
            this.buttonItemTypeUpdate = new System.Windows.Forms.Button();
            this.buttonItemTypeDelete = new System.Windows.Forms.Button();
            this.labelItemTypeName = new System.Windows.Forms.Label();
            this.buttonItemTypeSave = new System.Windows.Forms.Button();
            this.labelItemTypeDescription = new System.Windows.Forms.Label();
            this.textBoxItemTypeDescription = new System.Windows.Forms.TextBox();
            this.tabPageItemStatus = new System.Windows.Forms.TabPage();
            this.groupBoxStatusList = new System.Windows.Forms.GroupBox();
            this.dataGridViewItemStatus = new System.Windows.Forms.DataGridView();
            this.columnItemStatusName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnItemStatusDescription = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.itemStatusBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxItemStatus = new System.Windows.Forms.GroupBox();
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
            this.groupBoxPersonInfoList = new System.Windows.Forms.GroupBox();
            this.dataGridViewPersonInfo = new System.Windows.Forms.DataGridView();
            this.columnPersonInfoName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPersonInfoSurName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPersonInfoNickName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPersonInfoAddress = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPersonInfoCity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.columnPersonInfoEmail = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.personInfoBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxPersonInfo = new System.Windows.Forms.GroupBox();
            this.labelPersonInfoId = new System.Windows.Forms.Label();
            this.buttonPersonInfoDelete = new System.Windows.Forms.Button();
            this.buttonPersonInfoUpdate = new System.Windows.Forms.Button();
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
            this.groupBoxReportsList = new System.Windows.Forms.GroupBox();
            this.groupBoxReports = new System.Windows.Forms.GroupBox();
            this.tabPageBank = new System.Windows.Forms.TabPage();
            this.groupBoxBankList = new System.Windows.Forms.GroupBox();
            this.dataGridViewBank = new System.Windows.Forms.DataGridView();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ownerDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.accountNumberDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.bankBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBoxBank = new System.Windows.Forms.GroupBox();
            this.textBoxBankOwner = new System.Windows.Forms.TextBox();
            this.labelBankOwner = new System.Windows.Forms.Label();
            this.labelBankId = new System.Windows.Forms.Label();
            this.labelBankList = new System.Windows.Forms.Label();
            this.labelBankAccountNumber = new System.Windows.Forms.Label();
            this.textBoxBankAccountNumber = new System.Windows.Forms.TextBox();
            this.buttonBankUpdate = new System.Windows.Forms.Button();
            this.buttonBankDelete = new System.Windows.Forms.Button();
            this.buttonBankSave = new System.Windows.Forms.Button();
            this.labelBankName = new System.Windows.Forms.Label();
            this.textBoxBankName = new System.Windows.Forms.TextBox();
            this.tabPageExport = new System.Windows.Forms.TabPage();
            this.groupBoxExportList = new System.Windows.Forms.GroupBox();
            this.pagePreviewExport = new PdfSharp.Forms.PagePreview();
            this.toolBarExport = new System.Windows.Forms.ToolBar();
            this.toolBarButtonExportSmaller = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonExportLarger = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonExportSeparator = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonExportPrint = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonExportPdf = new System.Windows.Forms.ToolBarButton();
            this.toolBarButtonEXportEmail = new System.Windows.Forms.ToolBarButton();
            this.imageList = new System.Windows.Forms.ImageList(this.components);
            this.groupBoxExport = new System.Windows.Forms.GroupBox();
            this.buttonExportPreview = new System.Windows.Forms.Button();
            this.textBoxExportWork = new System.Windows.Forms.TextBox();
            this.labelExportWork = new System.Windows.Forms.Label();
            this.comboBoxExportErders = new System.Windows.Forms.ComboBox();
            this.labelExportOrders = new System.Windows.Forms.Label();
            this.textBoxItemsFilter = new System.Windows.Forms.TextBox();
            this.tabControl.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            this.groupBoxOrdersList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).BeginInit();
            this.groupBoxOrders.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrders)).BeginInit();
            this.tabPageItems.SuspendLayout();
            this.groupBoxItemsList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).BeginInit();
            this.groupBoxItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItems)).BeginInit();
            this.tabPageItemType.SuspendLayout();
            this.groupBoxItemTypeList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemType)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTypeBindingSource)).BeginInit();
            this.groupBoxItemType.SuspendLayout();
            this.tabPageItemStatus.SuspendLayout();
            this.groupBoxStatusList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemStatus)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemStatusBindingSource)).BeginInit();
            this.groupBoxItemStatus.SuspendLayout();
            this.tabPagePersonInfo.SuspendLayout();
            this.groupBoxPersonInfoList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersonInfo)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personInfoBindingSource)).BeginInit();
            this.groupBoxPersonInfo.SuspendLayout();
            this.tabPageReports.SuspendLayout();
            this.tabPageBank.SuspendLayout();
            this.groupBoxBankList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBank)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankBindingSource)).BeginInit();
            this.groupBoxBank.SuspendLayout();
            this.tabPageExport.SuspendLayout();
            this.groupBoxExportList.SuspendLayout();
            this.groupBoxExport.SuspendLayout();
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
            this.tabControl.Controls.Add(this.tabPageExport);
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.groupBoxOrdersList);
            this.tabPageOrders.Controls.Add(this.groupBoxOrders);
            resources.ApplyResources(this.tabPageOrders, "tabPageOrders");
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // groupBoxOrdersList
            // 
            this.groupBoxOrdersList.Controls.Add(this.dataGridViewOrders);
            resources.ApplyResources(this.groupBoxOrdersList, "groupBoxOrdersList");
            this.groupBoxOrdersList.Name = "groupBoxOrdersList";
            this.groupBoxOrdersList.TabStop = false;
            // 
            // dataGridViewOrders
            // 
            this.dataGridViewOrders.AllowUserToAddRows = false;
            this.dataGridViewOrders.AllowUserToDeleteRows = false;
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
            resources.ApplyResources(this.dataGridViewOrders, "dataGridViewOrders");
            this.dataGridViewOrders.MultiSelect = false;
            this.dataGridViewOrders.Name = "dataGridViewOrders";
            this.dataGridViewOrders.ReadOnly = true;
            this.dataGridViewOrders.SelectionChanged += new System.EventHandler(this.DataGridViewOrdersSelectionChanged);
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
            // orderBindingSource
            // 
            this.orderBindingSource.DataSource = typeof(jeza.Item.Tracker.Order);
            // 
            // groupBoxOrders
            // 
            this.groupBoxOrders.Controls.Add(this.comboBoxOrdersBank);
            this.groupBoxOrders.Controls.Add(this.labelOrdersBank);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersSum);
            this.groupBoxOrders.Controls.Add(this.labelOrdersSumNumber);
            this.groupBoxOrders.Controls.Add(this.labelOrdersId);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersUpdate);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersDelete);
            this.groupBoxOrders.Controls.Add(this.buttonOrdersSave);
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
            // comboBoxOrdersBank
            // 
            this.comboBoxOrdersBank.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxOrdersBank, "comboBoxOrdersBank");
            this.comboBoxOrdersBank.Name = "comboBoxOrdersBank";
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
            this.tabPageItems.Controls.Add(this.groupBoxItemsList);
            this.tabPageItems.Controls.Add(this.groupBoxItems);
            resources.ApplyResources(this.tabPageItems, "tabPageItems");
            this.tabPageItems.Name = "tabPageItems";
            this.tabPageItems.UseVisualStyleBackColor = true;
            // 
            // groupBoxItemsList
            // 
            this.groupBoxItemsList.Controls.Add(this.dataGridViewItems);
            this.groupBoxItemsList.Controls.Add(this.textBoxItemsFilter);
            resources.ApplyResources(this.groupBoxItemsList, "groupBoxItemsList");
            this.groupBoxItemsList.Name = "groupBoxItemsList";
            this.groupBoxItemsList.TabStop = false;
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
            this.dataGridViewItems.StandardTab = true;
            this.dataGridViewItems.SelectionChanged += new System.EventHandler(this.DataGridViewItemsSelectionChanged);
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
            // columnItemItemTypeName
            // 
            this.columnItemItemTypeName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnItemItemTypeName.DataPropertyName = "ItemTypeName";
            resources.ApplyResources(this.columnItemItemTypeName, "columnItemItemTypeName");
            this.columnItemItemTypeName.Name = "columnItemItemTypeName";
            this.columnItemItemTypeName.ReadOnly = true;
            // 
            // itemBindingSource
            // 
            this.itemBindingSource.DataSource = typeof(jeza.Item.Tracker.Item);
            // 
            // groupBoxItems
            // 
            this.groupBoxItems.Controls.Add(this.textBoxItemsPrice);
            this.groupBoxItems.Controls.Add(this.labelItemsPrice);
            this.groupBoxItems.Controls.Add(this.labelItemsId);
            this.groupBoxItems.Controls.Add(this.buttonItemsUpdate);
            this.groupBoxItems.Controls.Add(this.buttonItemsDelete);
            this.groupBoxItems.Controls.Add(this.labelItemsDescription);
            this.groupBoxItems.Controls.Add(this.textBoxItemsDescription);
            this.groupBoxItems.Controls.Add(this.buttonItemsPictureBoxSelect);
            this.groupBoxItems.Controls.Add(this.pictureBoxItems);
            this.groupBoxItems.Controls.Add(this.labelItemsType);
            this.groupBoxItems.Controls.Add(this.comboBoxItemsType);
            this.groupBoxItems.Controls.Add(this.buttonItemsSave);
            this.groupBoxItems.Controls.Add(this.labelItemsName);
            this.groupBoxItems.Controls.Add(this.textBoxItemsName);
            resources.ApplyResources(this.groupBoxItems, "groupBoxItems");
            this.groupBoxItems.Name = "groupBoxItems";
            this.groupBoxItems.TabStop = false;
            // 
            // textBoxItemsPrice
            // 
            resources.ApplyResources(this.textBoxItemsPrice, "textBoxItemsPrice");
            this.textBoxItemsPrice.Name = "textBoxItemsPrice";
            // 
            // labelItemsPrice
            // 
            resources.ApplyResources(this.labelItemsPrice, "labelItemsPrice");
            this.labelItemsPrice.Name = "labelItemsPrice";
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
            // tabPageItemType
            // 
            this.tabPageItemType.Controls.Add(this.groupBoxItemTypeList);
            this.tabPageItemType.Controls.Add(this.groupBoxItemType);
            resources.ApplyResources(this.tabPageItemType, "tabPageItemType");
            this.tabPageItemType.Name = "tabPageItemType";
            this.tabPageItemType.UseVisualStyleBackColor = true;
            // 
            // groupBoxItemTypeList
            // 
            this.groupBoxItemTypeList.Controls.Add(this.dataGridViewItemType);
            resources.ApplyResources(this.groupBoxItemTypeList, "groupBoxItemTypeList");
            this.groupBoxItemTypeList.Name = "groupBoxItemTypeList";
            this.groupBoxItemTypeList.TabStop = false;
            // 
            // dataGridViewItemType
            // 
            this.dataGridViewItemType.AllowUserToAddRows = false;
            this.dataGridViewItemType.AllowUserToDeleteRows = false;
            this.dataGridViewItemType.AutoGenerateColumns = false;
            this.dataGridViewItemType.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewItemType.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.columnItemTypeName,
            this.columnItemTypeDescription});
            this.dataGridViewItemType.DataSource = this.itemTypeBindingSource;
            resources.ApplyResources(this.dataGridViewItemType, "dataGridViewItemType");
            this.dataGridViewItemType.MultiSelect = false;
            this.dataGridViewItemType.Name = "dataGridViewItemType";
            this.dataGridViewItemType.ReadOnly = true;
            this.dataGridViewItemType.SelectionChanged += new System.EventHandler(this.DataGridViewItemTypeSelectionChanged);
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
            // groupBoxItemType
            // 
            this.groupBoxItemType.Controls.Add(this.labelItemTypeId);
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
            // labelItemTypeId
            // 
            resources.ApplyResources(this.labelItemTypeId, "labelItemTypeId");
            this.labelItemTypeId.Name = "labelItemTypeId";
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
            this.tabPageItemStatus.Controls.Add(this.groupBoxStatusList);
            this.tabPageItemStatus.Controls.Add(this.groupBoxItemStatus);
            resources.ApplyResources(this.tabPageItemStatus, "tabPageItemStatus");
            this.tabPageItemStatus.Name = "tabPageItemStatus";
            this.tabPageItemStatus.UseVisualStyleBackColor = true;
            // 
            // groupBoxStatusList
            // 
            this.groupBoxStatusList.Controls.Add(this.dataGridViewItemStatus);
            resources.ApplyResources(this.groupBoxStatusList, "groupBoxStatusList");
            this.groupBoxStatusList.Name = "groupBoxStatusList";
            this.groupBoxStatusList.TabStop = false;
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
            // groupBoxItemStatus
            // 
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
            this.tabPagePersonInfo.Controls.Add(this.groupBoxPersonInfoList);
            this.tabPagePersonInfo.Controls.Add(this.groupBoxPersonInfo);
            resources.ApplyResources(this.tabPagePersonInfo, "tabPagePersonInfo");
            this.tabPagePersonInfo.Name = "tabPagePersonInfo";
            this.tabPagePersonInfo.UseVisualStyleBackColor = true;
            // 
            // groupBoxPersonInfoList
            // 
            this.groupBoxPersonInfoList.Controls.Add(this.dataGridViewPersonInfo);
            resources.ApplyResources(this.groupBoxPersonInfoList, "groupBoxPersonInfoList");
            this.groupBoxPersonInfoList.Name = "groupBoxPersonInfoList";
            this.groupBoxPersonInfoList.TabStop = false;
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
            // columnPersonInfoName
            // 
            this.columnPersonInfoName.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.columnPersonInfoName.DataPropertyName = "Name";
            resources.ApplyResources(this.columnPersonInfoName, "columnPersonInfoName");
            this.columnPersonInfoName.Name = "columnPersonInfoName";
            this.columnPersonInfoName.ReadOnly = true;
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
            // personInfoBindingSource
            // 
            this.personInfoBindingSource.DataSource = typeof(jeza.Item.Tracker.PersonInfo);
            // 
            // groupBoxPersonInfo
            // 
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoId);
            this.groupBoxPersonInfo.Controls.Add(this.buttonPersonInfoDelete);
            this.groupBoxPersonInfo.Controls.Add(this.buttonPersonInfoUpdate);
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
            this.tabPageReports.Controls.Add(this.groupBoxReportsList);
            this.tabPageReports.Controls.Add(this.groupBoxReports);
            resources.ApplyResources(this.tabPageReports, "tabPageReports");
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // groupBoxReportsList
            // 
            resources.ApplyResources(this.groupBoxReportsList, "groupBoxReportsList");
            this.groupBoxReportsList.Name = "groupBoxReportsList";
            this.groupBoxReportsList.TabStop = false;
            // 
            // groupBoxReports
            // 
            resources.ApplyResources(this.groupBoxReports, "groupBoxReports");
            this.groupBoxReports.Name = "groupBoxReports";
            this.groupBoxReports.TabStop = false;
            // 
            // tabPageBank
            // 
            this.tabPageBank.Controls.Add(this.groupBoxBankList);
            this.tabPageBank.Controls.Add(this.groupBoxBank);
            resources.ApplyResources(this.tabPageBank, "tabPageBank");
            this.tabPageBank.Name = "tabPageBank";
            this.tabPageBank.UseVisualStyleBackColor = true;
            // 
            // groupBoxBankList
            // 
            this.groupBoxBankList.Controls.Add(this.dataGridViewBank);
            resources.ApplyResources(this.groupBoxBankList, "groupBoxBankList");
            this.groupBoxBankList.Name = "groupBoxBankList";
            this.groupBoxBankList.TabStop = false;
            // 
            // dataGridViewBank
            // 
            this.dataGridViewBank.AllowUserToAddRows = false;
            this.dataGridViewBank.AllowUserToDeleteRows = false;
            this.dataGridViewBank.AutoGenerateColumns = false;
            this.dataGridViewBank.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridViewBank.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nameDataGridViewTextBoxColumn,
            this.ownerDataGridViewTextBoxColumn,
            this.accountNumberDataGridViewTextBoxColumn});
            this.dataGridViewBank.DataSource = this.bankBindingSource;
            resources.ApplyResources(this.dataGridViewBank, "dataGridViewBank");
            this.dataGridViewBank.MultiSelect = false;
            this.dataGridViewBank.Name = "dataGridViewBank";
            this.dataGridViewBank.ReadOnly = true;
            this.dataGridViewBank.SelectionChanged += new System.EventHandler(this.DataGridViewBankSelectionChanged);
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            resources.ApplyResources(this.nameDataGridViewTextBoxColumn, "nameDataGridViewTextBoxColumn");
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // ownerDataGridViewTextBoxColumn
            // 
            this.ownerDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.ownerDataGridViewTextBoxColumn.DataPropertyName = "Owner";
            resources.ApplyResources(this.ownerDataGridViewTextBoxColumn, "ownerDataGridViewTextBoxColumn");
            this.ownerDataGridViewTextBoxColumn.Name = "ownerDataGridViewTextBoxColumn";
            this.ownerDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // accountNumberDataGridViewTextBoxColumn
            // 
            this.accountNumberDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.accountNumberDataGridViewTextBoxColumn.DataPropertyName = "AccountNumber";
            resources.ApplyResources(this.accountNumberDataGridViewTextBoxColumn, "accountNumberDataGridViewTextBoxColumn");
            this.accountNumberDataGridViewTextBoxColumn.Name = "accountNumberDataGridViewTextBoxColumn";
            this.accountNumberDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // bankBindingSource
            // 
            this.bankBindingSource.DataSource = typeof(jeza.Item.Tracker.Bank);
            // 
            // groupBoxBank
            // 
            this.groupBoxBank.Controls.Add(this.textBoxBankOwner);
            this.groupBoxBank.Controls.Add(this.labelBankOwner);
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
            this.buttonBankUpdate.Click += new System.EventHandler(this.ButtonBankUpdateClick);
            // 
            // buttonBankDelete
            // 
            resources.ApplyResources(this.buttonBankDelete, "buttonBankDelete");
            this.buttonBankDelete.Name = "buttonBankDelete";
            this.buttonBankDelete.UseVisualStyleBackColor = true;
            this.buttonBankDelete.Click += new System.EventHandler(this.ButtonBankDeleteClick);
            // 
            // buttonBankSave
            // 
            resources.ApplyResources(this.buttonBankSave, "buttonBankSave");
            this.buttonBankSave.Name = "buttonBankSave";
            this.buttonBankSave.UseVisualStyleBackColor = true;
            this.buttonBankSave.Click += new System.EventHandler(this.ButtonBankSaveClick);
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
            // tabPageExport
            // 
            this.tabPageExport.Controls.Add(this.groupBoxExportList);
            this.tabPageExport.Controls.Add(this.groupBoxExport);
            resources.ApplyResources(this.tabPageExport, "tabPageExport");
            this.tabPageExport.Name = "tabPageExport";
            this.tabPageExport.UseVisualStyleBackColor = true;
            // 
            // groupBoxExportList
            // 
            this.groupBoxExportList.Controls.Add(this.pagePreviewExport);
            this.groupBoxExportList.Controls.Add(this.toolBarExport);
            resources.ApplyResources(this.groupBoxExportList, "groupBoxExportList");
            this.groupBoxExportList.Name = "groupBoxExportList";
            this.groupBoxExportList.TabStop = false;
            // 
            // pagePreviewExport
            // 
            this.pagePreviewExport.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pagePreviewExport.DesktopColor = System.Drawing.SystemColors.ControlDark;
            resources.ApplyResources(this.pagePreviewExport, "pagePreviewExport");
            this.pagePreviewExport.Name = "pagePreviewExport";
            this.pagePreviewExport.PageColor = System.Drawing.Color.GhostWhite;
            this.pagePreviewExport.PageSize = ((PdfSharp.Drawing.XSize)(resources.GetObject("pagePreviewExport.PageSize")));
            this.pagePreviewExport.PageSizeF = new System.Drawing.Size(595, 842);
            this.pagePreviewExport.Zoom = PdfSharp.Forms.Zoom.Percent100;
            this.pagePreviewExport.ZoomPercent = 100;
            // 
            // toolBarExport
            // 
            this.toolBarExport.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
            this.toolBarButtonExportSmaller,
            this.toolBarButtonExportLarger,
            this.toolBarButtonExportSeparator,
            this.toolBarButtonExportPrint,
            this.toolBarButtonExportPdf,
            this.toolBarButtonEXportEmail});
            resources.ApplyResources(this.toolBarExport, "toolBarExport");
            this.toolBarExport.ImageList = this.imageList;
            this.toolBarExport.Name = "toolBarExport";
            // 
            // toolBarButtonExportSmaller
            // 
            resources.ApplyResources(this.toolBarButtonExportSmaller, "toolBarButtonExportSmaller");
            this.toolBarButtonExportSmaller.Name = "toolBarButtonExportSmaller";
            // 
            // toolBarButtonExportLarger
            // 
            resources.ApplyResources(this.toolBarButtonExportLarger, "toolBarButtonExportLarger");
            this.toolBarButtonExportLarger.Name = "toolBarButtonExportLarger";
            // 
            // toolBarButtonExportSeparator
            // 
            this.toolBarButtonExportSeparator.Name = "toolBarButtonExportSeparator";
            this.toolBarButtonExportSeparator.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
            // 
            // toolBarButtonExportPrint
            // 
            resources.ApplyResources(this.toolBarButtonExportPrint, "toolBarButtonExportPrint");
            this.toolBarButtonExportPrint.Name = "toolBarButtonExportPrint";
            // 
            // toolBarButtonExportPdf
            // 
            resources.ApplyResources(this.toolBarButtonExportPdf, "toolBarButtonExportPdf");
            this.toolBarButtonExportPdf.Name = "toolBarButtonExportPdf";
            // 
            // toolBarButtonEXportEmail
            // 
            resources.ApplyResources(this.toolBarButtonEXportEmail, "toolBarButtonEXportEmail");
            this.toolBarButtonEXportEmail.Name = "toolBarButtonEXportEmail";
            // 
            // imageList
            // 
            this.imageList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList.ImageStream")));
            this.imageList.TransparentColor = System.Drawing.Color.Transparent;
            this.imageList.Images.SetKeyName(0, "Printer-2-icon.png");
            this.imageList.Images.SetKeyName(1, "Mail-icon.png");
            this.imageList.Images.SetKeyName(2, "Adobe-PDF-Document-icon.png");
            this.imageList.Images.SetKeyName(3, "zoom-in-icon.png");
            this.imageList.Images.SetKeyName(4, "zoom-out-icon.png");
            // 
            // groupBoxExport
            // 
            this.groupBoxExport.Controls.Add(this.buttonExportPreview);
            this.groupBoxExport.Controls.Add(this.textBoxExportWork);
            this.groupBoxExport.Controls.Add(this.labelExportWork);
            this.groupBoxExport.Controls.Add(this.comboBoxExportErders);
            this.groupBoxExport.Controls.Add(this.labelExportOrders);
            resources.ApplyResources(this.groupBoxExport, "groupBoxExport");
            this.groupBoxExport.Name = "groupBoxExport";
            this.groupBoxExport.TabStop = false;
            // 
            // buttonExportPreview
            // 
            resources.ApplyResources(this.buttonExportPreview, "buttonExportPreview");
            this.buttonExportPreview.Name = "buttonExportPreview";
            this.buttonExportPreview.UseVisualStyleBackColor = true;
            this.buttonExportPreview.Click += new System.EventHandler(this.ButtonExportPreviewClick);
            // 
            // textBoxExportWork
            // 
            resources.ApplyResources(this.textBoxExportWork, "textBoxExportWork");
            this.textBoxExportWork.Name = "textBoxExportWork";
            // 
            // labelExportWork
            // 
            resources.ApplyResources(this.labelExportWork, "labelExportWork");
            this.labelExportWork.Name = "labelExportWork";
            // 
            // comboBoxExportErders
            // 
            this.comboBoxExportErders.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxExportErders, "comboBoxExportErders");
            this.comboBoxExportErders.Name = "comboBoxExportErders";
            // 
            // labelExportOrders
            // 
            resources.ApplyResources(this.labelExportOrders, "labelExportOrders");
            this.labelExportOrders.Name = "labelExportOrders";
            // 
            // textBoxItemsFilter
            // 
            resources.ApplyResources(this.textBoxItemsFilter, "textBoxItemsFilter");
            this.textBoxItemsFilter.Name = "textBoxItemsFilter";
            // 
            // Gui
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tabControl);
            this.HelpButton = true;
            this.Name = "Gui";
            this.tabControl.ResumeLayout(false);
            this.tabPageOrders.ResumeLayout(false);
            this.groupBoxOrdersList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.orderBindingSource)).EndInit();
            this.groupBoxOrders.ResumeLayout(false);
            this.groupBoxOrders.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrders)).EndInit();
            this.tabPageItems.ResumeLayout(false);
            this.groupBoxItemsList.ResumeLayout(false);
            this.groupBoxItemsList.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItems)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemBindingSource)).EndInit();
            this.groupBoxItems.ResumeLayout(false);
            this.groupBoxItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItems)).EndInit();
            this.tabPageItemType.ResumeLayout(false);
            this.groupBoxItemTypeList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemType)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemTypeBindingSource)).EndInit();
            this.groupBoxItemType.ResumeLayout(false);
            this.groupBoxItemType.PerformLayout();
            this.tabPageItemStatus.ResumeLayout(false);
            this.groupBoxStatusList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewItemStatus)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.itemStatusBindingSource)).EndInit();
            this.groupBoxItemStatus.ResumeLayout(false);
            this.groupBoxItemStatus.PerformLayout();
            this.tabPagePersonInfo.ResumeLayout(false);
            this.groupBoxPersonInfoList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewPersonInfo)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personInfoBindingSource)).EndInit();
            this.groupBoxPersonInfo.ResumeLayout(false);
            this.groupBoxPersonInfo.PerformLayout();
            this.tabPageReports.ResumeLayout(false);
            this.tabPageBank.ResumeLayout(false);
            this.groupBoxBankList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridViewBank)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.bankBindingSource)).EndInit();
            this.groupBoxBank.ResumeLayout(false);
            this.groupBoxBank.PerformLayout();
            this.tabPageExport.ResumeLayout(false);
            this.groupBoxExportList.ResumeLayout(false);
            this.groupBoxExportList.PerformLayout();
            this.groupBoxExport.ResumeLayout(false);
            this.groupBoxExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageItems;
        private System.Windows.Forms.GroupBox groupBoxItems;
        private System.Windows.Forms.Button buttonItemsSave;
        private System.Windows.Forms.Label labelItemsName;
        private System.Windows.Forms.TextBox textBoxItemsName;
        private System.Windows.Forms.TabPage tabPageOrders;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.Label labelItemsType;
        private System.Windows.Forms.ComboBox comboBoxItemsType;
        private System.Windows.Forms.Button buttonItemsPictureBoxSelect;
        private System.Windows.Forms.PictureBox pictureBoxItems;
        private System.Windows.Forms.Label labelItemsDescription;
        private System.Windows.Forms.TextBox textBoxItemsDescription;
        private System.Windows.Forms.TabPage tabPageItemType;
        private System.Windows.Forms.TabPage tabPageItemStatus;
        private System.Windows.Forms.TabPage tabPagePersonInfo;
        private System.Windows.Forms.GroupBox groupBoxPersonInfo;
        private System.Windows.Forms.Button buttonPersonInfoDelete;
        private System.Windows.Forms.Button buttonPersonInfoUpdate;
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
        private System.Windows.Forms.ComboBox comboBoxOrdersBank;
        private System.Windows.Forms.Label labelOrdersBank;
        private System.Windows.Forms.Button buttonOrdersSum;
        private System.Windows.Forms.Label labelOrdersSumNumber;
        private System.Windows.Forms.Label labelOrdersId;
        private System.Windows.Forms.Button buttonOrdersUpdate;
        private System.Windows.Forms.Button buttonOrdersDelete;
        private System.Windows.Forms.Button buttonOrdersSave;
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
        private System.Windows.Forms.DataGridView dataGridViewBank;
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
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn ownerDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn accountNumberDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource bankBindingSource;
        private System.Windows.Forms.GroupBox groupBoxOrdersList;
        private System.Windows.Forms.GroupBox groupBoxItemsList;
        private System.Windows.Forms.GroupBox groupBoxItemTypeList;
        private System.Windows.Forms.GroupBox groupBoxPersonInfoList;
        private System.Windows.Forms.GroupBox groupBoxReportsList;
        private System.Windows.Forms.GroupBox groupBoxBankList;
        private System.Windows.Forms.GroupBox groupBoxStatusList;
        private System.Windows.Forms.TabPage tabPageExport;
        private System.Windows.Forms.GroupBox groupBoxExportList;
        private System.Windows.Forms.GroupBox groupBoxExport;
        private System.Windows.Forms.ComboBox comboBoxExportErders;
        private System.Windows.Forms.Label labelExportOrders;
        private System.Windows.Forms.TextBox textBoxExportWork;
        private System.Windows.Forms.Label labelExportWork;
        private PdfSharp.Forms.PagePreview pagePreviewExport;
        private System.Windows.Forms.ToolBar toolBarExport;
        private System.Windows.Forms.ToolBarButton toolBarButtonExportSmaller;
        private System.Windows.Forms.ToolBarButton toolBarButtonExportLarger;
        private System.Windows.Forms.ToolBarButton toolBarButtonExportSeparator;
        private System.Windows.Forms.ToolBarButton toolBarButtonExportPrint;
        private System.Windows.Forms.ToolBarButton toolBarButtonExportPdf;
        private System.Windows.Forms.ToolBarButton toolBarButtonEXportEmail;
        private System.Windows.Forms.Button buttonExportPreview;
        private Renderer renderer;
        private System.Windows.Forms.ImageList imageList;
        private System.Windows.Forms.TextBox textBoxItemsPrice;
        private System.Windows.Forms.Label labelItemsPrice;
        private System.Windows.Forms.TextBox textBoxItemsFilter;
    }
}

