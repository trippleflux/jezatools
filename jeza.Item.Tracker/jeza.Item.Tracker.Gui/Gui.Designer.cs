using System.Configuration;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gui));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.buttonOrdersSum = new System.Windows.Forms.Button();
            this.labelOrdersSumNumber = new System.Windows.Forms.Label();
            this.labelOrdersId = new System.Windows.Forms.Label();
            this.buttonOrdersUpdate = new System.Windows.Forms.Button();
            this.buttonOrdersDelete = new System.Windows.Forms.Button();
            this.buttonOrderSave = new System.Windows.Forms.Button();
            this.listBoxOrdersList = new System.Windows.Forms.ListBox();
            this.labelOrdersList = new System.Windows.Forms.Label();
            this.comboBoxOrderItemType = new System.Windows.Forms.ComboBox();
            this.labelOrderItemType = new System.Windows.Forms.Label();
            this.comboBoxOrderPersonInfo = new System.Windows.Forms.ComboBox();
            this.labelOrderPersonInfo = new System.Windows.Forms.Label();
            this.buttonOrderSelect = new System.Windows.Forms.Button();
            this.textBoxOrderPostage = new System.Windows.Forms.TextBox();
            this.labelOrderPostage = new System.Windows.Forms.Label();
            this.comboBoxOrderItemStatus = new System.Windows.Forms.ComboBox();
            this.checkBoxOrderItemLegalEntity = new System.Windows.Forms.CheckBox();
            this.labelOrderItemStatus = new System.Windows.Forms.Label();
            this.labelOrderItemLegalEntity = new System.Windows.Forms.Label();
            this.textBoxOrderTax = new System.Windows.Forms.TextBox();
            this.labelOrderTax = new System.Windows.Forms.Label();
            this.textBoxOrderPrice = new System.Windows.Forms.TextBox();
            this.labelOrderPrice = new System.Windows.Forms.Label();
            this.textBoxOrderItemNumber = new System.Windows.Forms.TextBox();
            this.labelOrderItemCount = new System.Windows.Forms.Label();
            this.labelOrdersPicture = new System.Windows.Forms.Label();
            this.comboBoxOrderItem = new System.Windows.Forms.ComboBox();
            this.labelOrderItem = new System.Windows.Forms.Label();
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
            this.labelItemTypeId = new System.Windows.Forms.Label();
            this.labelItemTypeList = new System.Windows.Forms.Label();
            this.textBoxItemTypeName = new System.Windows.Forms.TextBox();
            this.buttonItemTypeUpdate = new System.Windows.Forms.Button();
            this.buttonItemTypeDelete = new System.Windows.Forms.Button();
            this.listBoxItemTypeList = new System.Windows.Forms.ListBox();
            this.buttonItemTypeListSelect = new System.Windows.Forms.Button();
            this.labelItemTypeName = new System.Windows.Forms.Label();
            this.buttonItemTypeSave = new System.Windows.Forms.Button();
            this.labelItemTypeDescription = new System.Windows.Forms.Label();
            this.textBoxItemTypeDescription = new System.Windows.Forms.TextBox();
            this.tabPageItemStatus = new System.Windows.Forms.TabPage();
            this.groupBoxItemsStatus = new System.Windows.Forms.GroupBox();
            this.labelItemStatusId = new System.Windows.Forms.Label();
            this.labelItemStatusList = new System.Windows.Forms.Label();
            this.labelItemStatusDescription = new System.Windows.Forms.Label();
            this.textBoxItemStatusDescription = new System.Windows.Forms.TextBox();
            this.buttonItemStatusUpdate = new System.Windows.Forms.Button();
            this.buttonItemStatusDelete = new System.Windows.Forms.Button();
            this.listBoxItemStatusList = new System.Windows.Forms.ListBox();
            this.buttonItemsStatusSelect = new System.Windows.Forms.Button();
            this.buttonItemsStatusSave = new System.Windows.Forms.Button();
            this.labelItemsStatusNew = new System.Windows.Forms.Label();
            this.textBoxItemStatusName = new System.Windows.Forms.TextBox();
            this.tabPagePersonInfo = new System.Windows.Forms.TabPage();
            this.groupBoxPersonInfo = new System.Windows.Forms.GroupBox();
            this.labelPersonInfoId = new System.Windows.Forms.Label();
            this.buttonPersonInfoListSelect = new System.Windows.Forms.Button();
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
            this.tabControl.SuspendLayout();
            this.tabPageOrders.SuspendLayout();
            this.groupBoxOrder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrders)).BeginInit();
            this.tabPageItems.SuspendLayout();
            this.groupBoxItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItems)).BeginInit();
            this.tabPageItemType.SuspendLayout();
            this.groupBoxItemType.SuspendLayout();
            this.tabPageItemStatus.SuspendLayout();
            this.groupBoxItemsStatus.SuspendLayout();
            this.tabPagePersonInfo.SuspendLayout();
            this.groupBoxPersonInfo.SuspendLayout();
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
            resources.ApplyResources(this.tabControl, "tabControl");
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.groupBoxOrder);
            resources.ApplyResources(this.tabPageOrders, "tabPageOrders");
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Controls.Add(this.buttonOrdersSum);
            this.groupBoxOrder.Controls.Add(this.labelOrdersSumNumber);
            this.groupBoxOrder.Controls.Add(this.labelOrdersId);
            this.groupBoxOrder.Controls.Add(this.buttonOrdersUpdate);
            this.groupBoxOrder.Controls.Add(this.buttonOrdersDelete);
            this.groupBoxOrder.Controls.Add(this.buttonOrderSave);
            this.groupBoxOrder.Controls.Add(this.listBoxOrdersList);
            this.groupBoxOrder.Controls.Add(this.labelOrdersList);
            this.groupBoxOrder.Controls.Add(this.comboBoxOrderItemType);
            this.groupBoxOrder.Controls.Add(this.labelOrderItemType);
            this.groupBoxOrder.Controls.Add(this.comboBoxOrderPersonInfo);
            this.groupBoxOrder.Controls.Add(this.labelOrderPersonInfo);
            this.groupBoxOrder.Controls.Add(this.buttonOrderSelect);
            this.groupBoxOrder.Controls.Add(this.textBoxOrderPostage);
            this.groupBoxOrder.Controls.Add(this.labelOrderPostage);
            this.groupBoxOrder.Controls.Add(this.comboBoxOrderItemStatus);
            this.groupBoxOrder.Controls.Add(this.checkBoxOrderItemLegalEntity);
            this.groupBoxOrder.Controls.Add(this.labelOrderItemStatus);
            this.groupBoxOrder.Controls.Add(this.labelOrderItemLegalEntity);
            this.groupBoxOrder.Controls.Add(this.textBoxOrderTax);
            this.groupBoxOrder.Controls.Add(this.labelOrderTax);
            this.groupBoxOrder.Controls.Add(this.textBoxOrderPrice);
            this.groupBoxOrder.Controls.Add(this.labelOrderPrice);
            this.groupBoxOrder.Controls.Add(this.textBoxOrderItemNumber);
            this.groupBoxOrder.Controls.Add(this.labelOrderItemCount);
            this.groupBoxOrder.Controls.Add(this.labelOrdersPicture);
            this.groupBoxOrder.Controls.Add(this.comboBoxOrderItem);
            this.groupBoxOrder.Controls.Add(this.labelOrderItem);
            this.groupBoxOrder.Controls.Add(this.pictureBoxOrders);
            resources.ApplyResources(this.groupBoxOrder, "groupBoxOrder");
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.TabStop = false;
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
            // buttonOrderSave
            // 
            resources.ApplyResources(this.buttonOrderSave, "buttonOrderSave");
            this.buttonOrderSave.Name = "buttonOrderSave";
            this.buttonOrderSave.UseVisualStyleBackColor = true;
            this.buttonOrderSave.Click += new System.EventHandler(this.ButtonOrderSaveClick);
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
            // comboBoxOrderItemType
            // 
            this.comboBoxOrderItemType.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxOrderItemType, "comboBoxOrderItemType");
            this.comboBoxOrderItemType.Name = "comboBoxOrderItemType";
            this.comboBoxOrderItemType.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOrderItemTypeSelectedIndexChanged);
            // 
            // labelOrderItemType
            // 
            resources.ApplyResources(this.labelOrderItemType, "labelOrderItemType");
            this.labelOrderItemType.Name = "labelOrderItemType";
            // 
            // comboBoxOrderPersonInfo
            // 
            this.comboBoxOrderPersonInfo.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxOrderPersonInfo, "comboBoxOrderPersonInfo");
            this.comboBoxOrderPersonInfo.Name = "comboBoxOrderPersonInfo";
            // 
            // labelOrderPersonInfo
            // 
            resources.ApplyResources(this.labelOrderPersonInfo, "labelOrderPersonInfo");
            this.labelOrderPersonInfo.Name = "labelOrderPersonInfo";
            // 
            // buttonOrderSelect
            // 
            resources.ApplyResources(this.buttonOrderSelect, "buttonOrderSelect");
            this.buttonOrderSelect.Name = "buttonOrderSelect";
            this.buttonOrderSelect.UseVisualStyleBackColor = true;
            this.buttonOrderSelect.Click += new System.EventHandler(this.ButtonOrderSelectClick);
            // 
            // textBoxOrderPostage
            // 
            resources.ApplyResources(this.textBoxOrderPostage, "textBoxOrderPostage");
            this.textBoxOrderPostage.Name = "textBoxOrderPostage";
            // 
            // labelOrderPostage
            // 
            resources.ApplyResources(this.labelOrderPostage, "labelOrderPostage");
            this.labelOrderPostage.Name = "labelOrderPostage";
            // 
            // comboBoxOrderItemStatus
            // 
            this.comboBoxOrderItemStatus.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxOrderItemStatus, "comboBoxOrderItemStatus");
            this.comboBoxOrderItemStatus.Name = "comboBoxOrderItemStatus";
            // 
            // checkBoxOrderItemLegalEntity
            // 
            resources.ApplyResources(this.checkBoxOrderItemLegalEntity, "checkBoxOrderItemLegalEntity");
            this.checkBoxOrderItemLegalEntity.Name = "checkBoxOrderItemLegalEntity";
            this.checkBoxOrderItemLegalEntity.UseVisualStyleBackColor = true;
            // 
            // labelOrderItemStatus
            // 
            resources.ApplyResources(this.labelOrderItemStatus, "labelOrderItemStatus");
            this.labelOrderItemStatus.Name = "labelOrderItemStatus";
            // 
            // labelOrderItemLegalEntity
            // 
            resources.ApplyResources(this.labelOrderItemLegalEntity, "labelOrderItemLegalEntity");
            this.labelOrderItemLegalEntity.Name = "labelOrderItemLegalEntity";
            // 
            // textBoxOrderTax
            // 
            resources.ApplyResources(this.textBoxOrderTax, "textBoxOrderTax");
            this.textBoxOrderTax.Name = "textBoxOrderTax";
            // 
            // labelOrderTax
            // 
            resources.ApplyResources(this.labelOrderTax, "labelOrderTax");
            this.labelOrderTax.Name = "labelOrderTax";
            // 
            // textBoxOrderPrice
            // 
            resources.ApplyResources(this.textBoxOrderPrice, "textBoxOrderPrice");
            this.textBoxOrderPrice.Name = "textBoxOrderPrice";
            // 
            // labelOrderPrice
            // 
            resources.ApplyResources(this.labelOrderPrice, "labelOrderPrice");
            this.labelOrderPrice.Name = "labelOrderPrice";
            // 
            // textBoxOrderItemNumber
            // 
            resources.ApplyResources(this.textBoxOrderItemNumber, "textBoxOrderItemNumber");
            this.textBoxOrderItemNumber.Name = "textBoxOrderItemNumber";
            // 
            // labelOrderItemCount
            // 
            resources.ApplyResources(this.labelOrderItemCount, "labelOrderItemCount");
            this.labelOrderItemCount.Name = "labelOrderItemCount";
            // 
            // labelOrdersPicture
            // 
            resources.ApplyResources(this.labelOrdersPicture, "labelOrdersPicture");
            this.labelOrdersPicture.Name = "labelOrdersPicture";
            // 
            // comboBoxOrderItem
            // 
            this.comboBoxOrderItem.FormattingEnabled = true;
            resources.ApplyResources(this.comboBoxOrderItem, "comboBoxOrderItem");
            this.comboBoxOrderItem.Name = "comboBoxOrderItem";
            this.comboBoxOrderItem.SelectedIndexChanged += new System.EventHandler(this.ComboBoxOrderItemSelectedIndexChanged);
            // 
            // labelOrderItem
            // 
            resources.ApplyResources(this.labelOrderItem, "labelOrderItem");
            this.labelOrderItem.Name = "labelOrderItem";
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
            this.groupBoxItemType.Controls.Add(this.labelItemTypeId);
            this.groupBoxItemType.Controls.Add(this.labelItemTypeList);
            this.groupBoxItemType.Controls.Add(this.textBoxItemTypeName);
            this.groupBoxItemType.Controls.Add(this.buttonItemTypeUpdate);
            this.groupBoxItemType.Controls.Add(this.buttonItemTypeDelete);
            this.groupBoxItemType.Controls.Add(this.listBoxItemTypeList);
            this.groupBoxItemType.Controls.Add(this.buttonItemTypeListSelect);
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
            // listBoxItemTypeList
            // 
            this.listBoxItemTypeList.FormattingEnabled = true;
            resources.ApplyResources(this.listBoxItemTypeList, "listBoxItemTypeList");
            this.listBoxItemTypeList.Name = "listBoxItemTypeList";
            // 
            // buttonItemTypeListSelect
            // 
            resources.ApplyResources(this.buttonItemTypeListSelect, "buttonItemTypeListSelect");
            this.buttonItemTypeListSelect.Name = "buttonItemTypeListSelect";
            this.buttonItemTypeListSelect.UseVisualStyleBackColor = true;
            this.buttonItemTypeListSelect.Click += new System.EventHandler(this.ButtonItemTypeListSelectClick);
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
            this.tabPageItemStatus.Controls.Add(this.groupBoxItemsStatus);
            resources.ApplyResources(this.tabPageItemStatus, "tabPageItemStatus");
            this.tabPageItemStatus.Name = "tabPageItemStatus";
            this.tabPageItemStatus.UseVisualStyleBackColor = true;
            // 
            // groupBoxItemsStatus
            // 
            resources.ApplyResources(this.groupBoxItemsStatus, "groupBoxItemsStatus");
            this.groupBoxItemsStatus.Controls.Add(this.labelItemStatusId);
            this.groupBoxItemsStatus.Controls.Add(this.labelItemStatusList);
            this.groupBoxItemsStatus.Controls.Add(this.labelItemStatusDescription);
            this.groupBoxItemsStatus.Controls.Add(this.textBoxItemStatusDescription);
            this.groupBoxItemsStatus.Controls.Add(this.buttonItemStatusUpdate);
            this.groupBoxItemsStatus.Controls.Add(this.buttonItemStatusDelete);
            this.groupBoxItemsStatus.Controls.Add(this.listBoxItemStatusList);
            this.groupBoxItemsStatus.Controls.Add(this.buttonItemsStatusSelect);
            this.groupBoxItemsStatus.Controls.Add(this.buttonItemsStatusSave);
            this.groupBoxItemsStatus.Controls.Add(this.labelItemsStatusNew);
            this.groupBoxItemsStatus.Controls.Add(this.textBoxItemStatusName);
            this.groupBoxItemsStatus.Name = "groupBoxItemsStatus";
            this.groupBoxItemsStatus.TabStop = false;
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
            // buttonItemsStatusSelect
            // 
            resources.ApplyResources(this.buttonItemsStatusSelect, "buttonItemsStatusSelect");
            this.buttonItemsStatusSelect.Name = "buttonItemsStatusSelect";
            this.buttonItemsStatusSelect.UseVisualStyleBackColor = true;
            this.buttonItemsStatusSelect.Click += new System.EventHandler(this.ButtonItemsStatusSelectClick);
            // 
            // buttonItemsStatusSave
            // 
            resources.ApplyResources(this.buttonItemsStatusSave, "buttonItemsStatusSave");
            this.buttonItemsStatusSave.Name = "buttonItemsStatusSave";
            this.buttonItemsStatusSave.UseVisualStyleBackColor = true;
            this.buttonItemsStatusSave.Click += new System.EventHandler(this.ButtonItemsStatusSaveClick);
            // 
            // labelItemsStatusNew
            // 
            resources.ApplyResources(this.labelItemsStatusNew, "labelItemsStatusNew");
            this.labelItemsStatusNew.Name = "labelItemsStatusNew";
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
            this.groupBoxPersonInfo.Controls.Add(this.buttonPersonInfoListSelect);
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
            // buttonPersonInfoListSelect
            // 
            resources.ApplyResources(this.buttonPersonInfoListSelect, "buttonPersonInfoListSelect");
            this.buttonPersonInfoListSelect.Name = "buttonPersonInfoListSelect";
            this.buttonPersonInfoListSelect.UseVisualStyleBackColor = true;
            this.buttonPersonInfoListSelect.Click += new System.EventHandler(this.ButtonPersonInfoListSelectClick);
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
            resources.ApplyResources(this.tabPageReports, "tabPageReports");
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.UseVisualStyleBackColor = true;
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
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrders)).EndInit();
            this.tabPageItems.ResumeLayout(false);
            this.groupBoxItems.ResumeLayout(false);
            this.groupBoxItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItems)).EndInit();
            this.tabPageItemType.ResumeLayout(false);
            this.groupBoxItemType.ResumeLayout(false);
            this.groupBoxItemType.PerformLayout();
            this.tabPageItemStatus.ResumeLayout(false);
            this.tabPageItemStatus.PerformLayout();
            this.groupBoxItemsStatus.ResumeLayout(false);
            this.groupBoxItemsStatus.PerformLayout();
            this.tabPagePersonInfo.ResumeLayout(false);
            this.groupBoxPersonInfo.ResumeLayout(false);
            this.groupBoxPersonInfo.PerformLayout();
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
        private System.Windows.Forms.Label labelOrderItemLegalEntity;
        private System.Windows.Forms.CheckBox checkBoxOrderItemLegalEntity;
        private System.Windows.Forms.GroupBox groupBoxOrder;
        private System.Windows.Forms.ComboBox comboBoxOrderPersonInfo;
        private System.Windows.Forms.Label labelOrderPersonInfo;
        private System.Windows.Forms.Button buttonItemsSelect;
        private System.Windows.Forms.Label labelItemsType;
        private System.Windows.Forms.ComboBox comboBoxItemsType;
        private System.Windows.Forms.Button buttonItemsPictureBoxSelect;
        private System.Windows.Forms.PictureBox pictureBoxItems;
        private System.Windows.Forms.Label labelItemsImage;
        private System.Windows.Forms.PictureBox pictureBoxOrders;
        private System.Windows.Forms.ComboBox comboBoxOrderItemStatus;
        private System.Windows.Forms.Label labelOrderItemStatus;
        private System.Windows.Forms.TextBox textBoxOrderTax;
        private System.Windows.Forms.Label labelOrderTax;
        private System.Windows.Forms.TextBox textBoxOrderPrice;
        private System.Windows.Forms.Label labelOrderPrice;
        private System.Windows.Forms.TextBox textBoxOrderItemNumber;
        private System.Windows.Forms.Label labelOrderItemCount;
        private System.Windows.Forms.Label labelOrdersPicture;
        private System.Windows.Forms.ComboBox comboBoxOrderItem;
        private System.Windows.Forms.Label labelOrderItem;
        private System.Windows.Forms.TextBox textBoxOrderPostage;
        private System.Windows.Forms.Label labelOrderPostage;
        private System.Windows.Forms.Button buttonOrderSelect;
        private System.Windows.Forms.Label labelItemsDescription;
        private System.Windows.Forms.TextBox textBoxItemsDescription;
        private System.Windows.Forms.TabPage tabPageItemType;
        private System.Windows.Forms.TabPage tabPageItemStatus;
        private System.Windows.Forms.TabPage tabPagePersonInfo;
        private System.Windows.Forms.GroupBox groupBoxPersonInfo;
        private System.Windows.Forms.Button buttonPersonInfoListSelect;
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
        private System.Windows.Forms.Button buttonItemTypeListSelect;
        private System.Windows.Forms.Label labelItemTypeName;
        private System.Windows.Forms.Button buttonItemTypeSave;
        private System.Windows.Forms.Label labelItemTypeDescription;
        private System.Windows.Forms.TextBox textBoxItemTypeDescription;
        private System.Windows.Forms.GroupBox groupBoxItemsStatus;
        private System.Windows.Forms.Button buttonItemsStatusSelect;
        private System.Windows.Forms.Button buttonItemsStatusSave;
        private System.Windows.Forms.Label labelItemsStatusNew;
        private System.Windows.Forms.TextBox textBoxItemStatusName;
        private System.Windows.Forms.Button buttonItemTypeUpdate;
        private System.Windows.Forms.Button buttonItemTypeDelete;
        private System.Windows.Forms.ListBox listBoxItemTypeList;
        private System.Windows.Forms.Button buttonItemStatusUpdate;
        private System.Windows.Forms.Button buttonItemStatusDelete;
        private System.Windows.Forms.ListBox listBoxItemStatusList;
        private System.Windows.Forms.Label labelItemStatusList;
        private System.Windows.Forms.Label labelItemStatusDescription;
        private System.Windows.Forms.TextBox textBoxItemStatusDescription;
        private System.Windows.Forms.Label labelItemTypeList;
        private System.Windows.Forms.TextBox textBoxItemTypeName;
        private System.Windows.Forms.ComboBox comboBoxOrderItemType;
        private System.Windows.Forms.Label labelOrderItemType;
        private System.Windows.Forms.Label labelItemsId;
        private System.Windows.Forms.Label labelItemTypeId;
        private System.Windows.Forms.Label labelItemStatusId;
        private System.Windows.Forms.Label labelPersonInfoId;
        private System.Windows.Forms.ListBox listBoxOrdersList;
        private System.Windows.Forms.Label labelOrdersList;
        private System.Windows.Forms.Button buttonOrderSave;
        private System.Windows.Forms.Label labelOrdersId;
        private System.Windows.Forms.Button buttonOrdersUpdate;
        private System.Windows.Forms.Button buttonOrdersDelete;
        private System.Windows.Forms.Button buttonOrdersSum;
        private System.Windows.Forms.Label labelOrdersSumNumber;
    }
}

