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
            this.tabControl = new System.Windows.Forms.TabControl();
            this.tabPageOrders = new System.Windows.Forms.TabPage();
            this.groupBoxOrder = new System.Windows.Forms.GroupBox();
            this.comboBoxOrderItemType = new System.Windows.Forms.ComboBox();
            this.labelOrderItemType = new System.Windows.Forms.Label();
            this.buttonOrderitemSelect = new System.Windows.Forms.Button();
            this.comboBoxOrderPersonInfo = new System.Windows.Forms.ComboBox();
            this.labelOrderPersonInfo = new System.Windows.Forms.Label();
            this.buttonOrderSave = new System.Windows.Forms.Button();
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
            this.labelOrderItemPicture = new System.Windows.Forms.Label();
            this.comboBoxOrderItem = new System.Windows.Forms.ComboBox();
            this.labelOrderItem = new System.Windows.Forms.Label();
            this.pictureBoxOrder = new System.Windows.Forms.PictureBox();
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
            this.buttonPersonInfoListSelect = new System.Windows.Forms.Button();
            this.buttonPersonInfoDelete = new System.Windows.Forms.Button();
            this.buttonPersonInfoUpdate = new System.Windows.Forms.Button();
            this.labelPersonInfoList = new System.Windows.Forms.Label();
            this.listBoxPersonInfoList = new System.Windows.Forms.ListBox();
            this.buttonOrderPersonInfoSave = new System.Windows.Forms.Button();
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
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrder)).BeginInit();
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
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 600);
            this.tabControl.TabIndex = 2;
            // 
            // tabPageOrders
            // 
            this.tabPageOrders.Controls.Add(this.groupBoxOrder);
            this.tabPageOrders.Location = new System.Drawing.Point(4, 22);
            this.tabPageOrders.Name = "tabPageOrders";
            this.tabPageOrders.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrders.Size = new System.Drawing.Size(992, 574);
            this.tabPageOrders.TabIndex = 2;
            this.tabPageOrders.Text = "Orders";
            this.tabPageOrders.UseVisualStyleBackColor = true;
            // 
            // groupBoxOrder
            // 
            this.groupBoxOrder.Controls.Add(this.comboBoxOrderItemType);
            this.groupBoxOrder.Controls.Add(this.labelOrderItemType);
            this.groupBoxOrder.Controls.Add(this.buttonOrderitemSelect);
            this.groupBoxOrder.Controls.Add(this.comboBoxOrderPersonInfo);
            this.groupBoxOrder.Controls.Add(this.labelOrderPersonInfo);
            this.groupBoxOrder.Controls.Add(this.buttonOrderSave);
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
            this.groupBoxOrder.Controls.Add(this.labelOrderItemPicture);
            this.groupBoxOrder.Controls.Add(this.comboBoxOrderItem);
            this.groupBoxOrder.Controls.Add(this.labelOrderItem);
            this.groupBoxOrder.Controls.Add(this.pictureBoxOrder);
            this.groupBoxOrder.Location = new System.Drawing.Point(3, 6);
            this.groupBoxOrder.Name = "groupBoxOrder";
            this.groupBoxOrder.Size = new System.Drawing.Size(981, 560);
            this.groupBoxOrder.TabIndex = 2;
            this.groupBoxOrder.TabStop = false;
            this.groupBoxOrder.Text = "Order";
            // 
            // comboBoxOrderItemType
            // 
            this.comboBoxOrderItemType.FormattingEnabled = true;
            this.comboBoxOrderItemType.Location = new System.Drawing.Point(15, 72);
            this.comboBoxOrderItemType.Name = "comboBoxOrderItemType";
            this.comboBoxOrderItemType.Size = new System.Drawing.Size(308, 21);
            this.comboBoxOrderItemType.TabIndex = 33;
            // 
            // labelOrderItemType
            // 
            this.labelOrderItemType.AutoSize = true;
            this.labelOrderItemType.Location = new System.Drawing.Point(12, 56);
            this.labelOrderItemType.Name = "labelOrderItemType";
            this.labelOrderItemType.Size = new System.Drawing.Size(54, 13);
            this.labelOrderItemType.TabIndex = 32;
            this.labelOrderItemType.Text = "Item Type";
            // 
            // buttonOrderitemSelect
            // 
            this.buttonOrderitemSelect.Location = new System.Drawing.Point(565, 56);
            this.buttonOrderitemSelect.Name = "buttonOrderitemSelect";
            this.buttonOrderitemSelect.Size = new System.Drawing.Size(140, 21);
            this.buttonOrderitemSelect.TabIndex = 31;
            this.buttonOrderitemSelect.Text = "Select";
            this.buttonOrderitemSelect.UseVisualStyleBackColor = true;
            this.buttonOrderitemSelect.Click += new System.EventHandler(this.ButtonOrderitemSelectClick);
            // 
            // comboBoxOrderPersonInfo
            // 
            this.comboBoxOrderPersonInfo.FormattingEnabled = true;
            this.comboBoxOrderPersonInfo.Location = new System.Drawing.Point(15, 32);
            this.comboBoxOrderPersonInfo.Name = "comboBoxOrderPersonInfo";
            this.comboBoxOrderPersonInfo.Size = new System.Drawing.Size(308, 21);
            this.comboBoxOrderPersonInfo.TabIndex = 3;
            // 
            // labelOrderPersonInfo
            // 
            this.labelOrderPersonInfo.AutoSize = true;
            this.labelOrderPersonInfo.Location = new System.Drawing.Point(12, 16);
            this.labelOrderPersonInfo.Name = "labelOrderPersonInfo";
            this.labelOrderPersonInfo.Size = new System.Drawing.Size(61, 13);
            this.labelOrderPersonInfo.TabIndex = 2;
            this.labelOrderPersonInfo.Text = "Person Info";
            // 
            // buttonOrderSave
            // 
            this.buttonOrderSave.Location = new System.Drawing.Point(565, 83);
            this.buttonOrderSave.Name = "buttonOrderSave";
            this.buttonOrderSave.Size = new System.Drawing.Size(140, 21);
            this.buttonOrderSave.TabIndex = 30;
            this.buttonOrderSave.Text = "Save";
            this.buttonOrderSave.UseVisualStyleBackColor = true;
            // 
            // textBoxOrderPostage
            // 
            this.textBoxOrderPostage.Location = new System.Drawing.Point(349, 153);
            this.textBoxOrderPostage.Name = "textBoxOrderPostage";
            this.textBoxOrderPostage.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderPostage.TabIndex = 15;
            this.textBoxOrderPostage.Text = "0";
            // 
            // labelOrderPostage
            // 
            this.labelOrderPostage.AutoSize = true;
            this.labelOrderPostage.Location = new System.Drawing.Point(346, 136);
            this.labelOrderPostage.Name = "labelOrderPostage";
            this.labelOrderPostage.Size = new System.Drawing.Size(46, 13);
            this.labelOrderPostage.TabIndex = 14;
            this.labelOrderPostage.Text = "Postage";
            // 
            // comboBoxOrderItemStatus
            // 
            this.comboBoxOrderItemStatus.FormattingEnabled = true;
            this.comboBoxOrderItemStatus.Location = new System.Drawing.Point(15, 151);
            this.comboBoxOrderItemStatus.Name = "comboBoxOrderItemStatus";
            this.comboBoxOrderItemStatus.Size = new System.Drawing.Size(308, 21);
            this.comboBoxOrderItemStatus.TabIndex = 13;
            // 
            // checkBoxOrderItemLegalEntity
            // 
            this.checkBoxOrderItemLegalEntity.AutoSize = true;
            this.checkBoxOrderItemLegalEntity.Location = new System.Drawing.Point(565, 36);
            this.checkBoxOrderItemLegalEntity.Name = "checkBoxOrderItemLegalEntity";
            this.checkBoxOrderItemLegalEntity.Size = new System.Drawing.Size(15, 14);
            this.checkBoxOrderItemLegalEntity.TabIndex = 1;
            this.checkBoxOrderItemLegalEntity.UseVisualStyleBackColor = true;
            // 
            // labelOrderItemStatus
            // 
            this.labelOrderItemStatus.AutoSize = true;
            this.labelOrderItemStatus.Location = new System.Drawing.Point(12, 135);
            this.labelOrderItemStatus.Name = "labelOrderItemStatus";
            this.labelOrderItemStatus.Size = new System.Drawing.Size(37, 13);
            this.labelOrderItemStatus.TabIndex = 12;
            this.labelOrderItemStatus.Text = "Status";
            // 
            // labelOrderItemLegalEntity
            // 
            this.labelOrderItemLegalEntity.AutoSize = true;
            this.labelOrderItemLegalEntity.Location = new System.Drawing.Point(562, 16);
            this.labelOrderItemLegalEntity.Name = "labelOrderItemLegalEntity";
            this.labelOrderItemLegalEntity.Size = new System.Drawing.Size(62, 13);
            this.labelOrderItemLegalEntity.TabIndex = 0;
            this.labelOrderItemLegalEntity.Text = "Legal Entity";
            // 
            // textBoxOrderTax
            // 
            this.textBoxOrderTax.Location = new System.Drawing.Point(349, 113);
            this.textBoxOrderTax.Name = "textBoxOrderTax";
            this.textBoxOrderTax.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderTax.TabIndex = 11;
            // 
            // labelOrderTax
            // 
            this.labelOrderTax.AutoSize = true;
            this.labelOrderTax.Location = new System.Drawing.Point(346, 96);
            this.labelOrderTax.Name = "labelOrderTax";
            this.labelOrderTax.Size = new System.Drawing.Size(25, 13);
            this.labelOrderTax.TabIndex = 10;
            this.labelOrderTax.Text = "Tax";
            // 
            // textBoxOrderPrice
            // 
            this.textBoxOrderPrice.Location = new System.Drawing.Point(349, 73);
            this.textBoxOrderPrice.Name = "textBoxOrderPrice";
            this.textBoxOrderPrice.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderPrice.TabIndex = 9;
            // 
            // labelOrderPrice
            // 
            this.labelOrderPrice.AutoSize = true;
            this.labelOrderPrice.Location = new System.Drawing.Point(346, 56);
            this.labelOrderPrice.Name = "labelOrderPrice";
            this.labelOrderPrice.Size = new System.Drawing.Size(31, 13);
            this.labelOrderPrice.TabIndex = 8;
            this.labelOrderPrice.Text = "Price";
            // 
            // textBoxOrderItemNumber
            // 
            this.textBoxOrderItemNumber.Location = new System.Drawing.Point(349, 33);
            this.textBoxOrderItemNumber.Name = "textBoxOrderItemNumber";
            this.textBoxOrderItemNumber.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderItemNumber.TabIndex = 7;
            this.textBoxOrderItemNumber.Text = "1";
            // 
            // labelOrderItemCount
            // 
            this.labelOrderItemCount.AutoSize = true;
            this.labelOrderItemCount.Location = new System.Drawing.Point(346, 16);
            this.labelOrderItemCount.Name = "labelOrderItemCount";
            this.labelOrderItemCount.Size = new System.Drawing.Size(44, 13);
            this.labelOrderItemCount.TabIndex = 6;
            this.labelOrderItemCount.Text = "Number";
            // 
            // labelOrderItemPicture
            // 
            this.labelOrderItemPicture.AutoSize = true;
            this.labelOrderItemPicture.Location = new System.Drawing.Point(12, 175);
            this.labelOrderItemPicture.Name = "labelOrderItemPicture";
            this.labelOrderItemPicture.Size = new System.Drawing.Size(40, 13);
            this.labelOrderItemPicture.TabIndex = 5;
            this.labelOrderItemPicture.Text = "Picture";
            // 
            // comboBoxOrderItem
            // 
            this.comboBoxOrderItem.FormattingEnabled = true;
            this.comboBoxOrderItem.Location = new System.Drawing.Point(15, 111);
            this.comboBoxOrderItem.Name = "comboBoxOrderItem";
            this.comboBoxOrderItem.Size = new System.Drawing.Size(308, 21);
            this.comboBoxOrderItem.TabIndex = 4;
            // 
            // labelOrderItem
            // 
            this.labelOrderItem.AutoSize = true;
            this.labelOrderItem.Location = new System.Drawing.Point(12, 95);
            this.labelOrderItem.Name = "labelOrderItem";
            this.labelOrderItem.Size = new System.Drawing.Size(27, 13);
            this.labelOrderItem.TabIndex = 1;
            this.labelOrderItem.Text = "Item";
            // 
            // pictureBoxOrder
            // 
            this.pictureBoxOrder.Location = new System.Drawing.Point(15, 194);
            this.pictureBoxOrder.Name = "pictureBoxOrder";
            this.pictureBoxOrder.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxOrder.TabIndex = 0;
            this.pictureBoxOrder.TabStop = false;
            // 
            // tabPageItems
            // 
            this.tabPageItems.Controls.Add(this.groupBoxItems);
            this.tabPageItems.Location = new System.Drawing.Point(4, 22);
            this.tabPageItems.Name = "tabPageItems";
            this.tabPageItems.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItems.Size = new System.Drawing.Size(992, 574);
            this.tabPageItems.TabIndex = 0;
            this.tabPageItems.Text = "Items";
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
            this.groupBoxItems.Location = new System.Drawing.Point(3, 6);
            this.groupBoxItems.Name = "groupBoxItems";
            this.groupBoxItems.Size = new System.Drawing.Size(981, 560);
            this.groupBoxItems.TabIndex = 6;
            this.groupBoxItems.TabStop = false;
            this.groupBoxItems.Text = "Items";
            // 
            // labelItemsId
            // 
            this.labelItemsId.AutoSize = true;
            this.labelItemsId.Enabled = false;
            this.labelItemsId.Location = new System.Drawing.Point(746, 32);
            this.labelItemsId.Name = "labelItemsId";
            this.labelItemsId.Size = new System.Drawing.Size(16, 13);
            this.labelItemsId.TabIndex = 20;
            this.labelItemsId.Text = "-1";
            this.labelItemsId.Visible = false;
            // 
            // buttonItemsUpdate
            // 
            this.buttonItemsUpdate.Enabled = false;
            this.buttonItemsUpdate.Location = new System.Drawing.Point(660, 86);
            this.buttonItemsUpdate.Name = "buttonItemsUpdate";
            this.buttonItemsUpdate.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsUpdate.TabIndex = 8;
            this.buttonItemsUpdate.Text = "Update";
            this.buttonItemsUpdate.UseVisualStyleBackColor = true;
            this.buttonItemsUpdate.Click += new System.EventHandler(this.ButtonItemsUpdateClick);
            // 
            // buttonItemsDelete
            // 
            this.buttonItemsDelete.Enabled = false;
            this.buttonItemsDelete.Location = new System.Drawing.Point(660, 113);
            this.buttonItemsDelete.Name = "buttonItemsDelete";
            this.buttonItemsDelete.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsDelete.TabIndex = 9;
            this.buttonItemsDelete.Text = "Delete";
            this.buttonItemsDelete.UseVisualStyleBackColor = true;
            this.buttonItemsDelete.Click += new System.EventHandler(this.ButtonItemsDeleteClick);
            // 
            // labelItemsDescription
            // 
            this.labelItemsDescription.AutoSize = true;
            this.labelItemsDescription.Location = new System.Drawing.Point(6, 56);
            this.labelItemsDescription.Name = "labelItemsDescription";
            this.labelItemsDescription.Size = new System.Drawing.Size(60, 13);
            this.labelItemsDescription.TabIndex = 19;
            this.labelItemsDescription.Text = "Description";
            // 
            // textBoxItemsDescription
            // 
            this.textBoxItemsDescription.Location = new System.Drawing.Point(6, 72);
            this.textBoxItemsDescription.Name = "textBoxItemsDescription";
            this.textBoxItemsDescription.Size = new System.Drawing.Size(300, 20);
            this.textBoxItemsDescription.TabIndex = 2;
            // 
            // labelItemsImage
            // 
            this.labelItemsImage.AutoSize = true;
            this.labelItemsImage.Location = new System.Drawing.Point(6, 136);
            this.labelItemsImage.Name = "labelItemsImage";
            this.labelItemsImage.Size = new System.Drawing.Size(36, 13);
            this.labelItemsImage.TabIndex = 17;
            this.labelItemsImage.Text = "Image";
            // 
            // buttonItemsPictureBoxSelect
            // 
            this.buttonItemsPictureBoxSelect.Enabled = false;
            this.buttonItemsPictureBoxSelect.Location = new System.Drawing.Point(6, 152);
            this.buttonItemsPictureBoxSelect.Name = "buttonItemsPictureBoxSelect";
            this.buttonItemsPictureBoxSelect.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsPictureBoxSelect.TabIndex = 4;
            this.buttonItemsPictureBoxSelect.Text = "Select Image";
            this.buttonItemsPictureBoxSelect.UseVisualStyleBackColor = true;
            this.buttonItemsPictureBoxSelect.Click += new System.EventHandler(this.ButtonItemsPictureBoxSelectClick);
            // 
            // pictureBoxItems
            // 
            this.pictureBoxItems.Location = new System.Drawing.Point(6, 176);
            this.pictureBoxItems.Name = "pictureBoxItems";
            this.pictureBoxItems.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxItems.TabIndex = 14;
            this.pictureBoxItems.TabStop = false;
            // 
            // buttonItemsSelect
            // 
            this.buttonItemsSelect.Location = new System.Drawing.Point(660, 32);
            this.buttonItemsSelect.Name = "buttonItemsSelect";
            this.buttonItemsSelect.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsSelect.TabIndex = 6;
            this.buttonItemsSelect.Text = "Select";
            this.buttonItemsSelect.UseVisualStyleBackColor = true;
            this.buttonItemsSelect.Click += new System.EventHandler(this.ButtonItemsSelectClick);
            // 
            // labelItemsType
            // 
            this.labelItemsType.AutoSize = true;
            this.labelItemsType.Location = new System.Drawing.Point(6, 96);
            this.labelItemsType.Name = "labelItemsType";
            this.labelItemsType.Size = new System.Drawing.Size(54, 13);
            this.labelItemsType.TabIndex = 12;
            this.labelItemsType.Text = "Item Type";
            // 
            // comboBoxItemsType
            // 
            this.comboBoxItemsType.FormattingEnabled = true;
            this.comboBoxItemsType.Location = new System.Drawing.Point(6, 112);
            this.comboBoxItemsType.Name = "comboBoxItemsType";
            this.comboBoxItemsType.Size = new System.Drawing.Size(300, 21);
            this.comboBoxItemsType.TabIndex = 3;
            // 
            // listBoxItemsList
            // 
            this.listBoxItemsList.FormattingEnabled = true;
            this.listBoxItemsList.Location = new System.Drawing.Point(310, 32);
            this.listBoxItemsList.Name = "listBoxItemsList";
            this.listBoxItemsList.ScrollAlwaysVisible = true;
            this.listBoxItemsList.Size = new System.Drawing.Size(345, 511);
            this.listBoxItemsList.TabIndex = 5;
            // 
            // buttonItemsSave
            // 
            this.buttonItemsSave.Location = new System.Drawing.Point(660, 59);
            this.buttonItemsSave.Name = "buttonItemsSave";
            this.buttonItemsSave.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsSave.TabIndex = 7;
            this.buttonItemsSave.Text = "Save";
            this.buttonItemsSave.UseVisualStyleBackColor = true;
            this.buttonItemsSave.Click += new System.EventHandler(this.ButtonItemsSaveClick);
            // 
            // labelItemsName
            // 
            this.labelItemsName.AutoSize = true;
            this.labelItemsName.Location = new System.Drawing.Point(6, 16);
            this.labelItemsName.Name = "labelItemsName";
            this.labelItemsName.Size = new System.Drawing.Size(35, 13);
            this.labelItemsName.TabIndex = 8;
            this.labelItemsName.Text = "Name";
            // 
            // textBoxItemsName
            // 
            this.textBoxItemsName.Location = new System.Drawing.Point(6, 32);
            this.textBoxItemsName.Name = "textBoxItemsName";
            this.textBoxItemsName.Size = new System.Drawing.Size(300, 20);
            this.textBoxItemsName.TabIndex = 1;
            // 
            // labelItemsList
            // 
            this.labelItemsList.AutoSize = true;
            this.labelItemsList.Location = new System.Drawing.Point(310, 16);
            this.labelItemsList.Name = "labelItemsList";
            this.labelItemsList.Size = new System.Drawing.Size(23, 13);
            this.labelItemsList.TabIndex = 6;
            this.labelItemsList.Text = "List";
            // 
            // tabPageItemType
            // 
            this.tabPageItemType.Controls.Add(this.groupBoxItemType);
            this.tabPageItemType.Location = new System.Drawing.Point(4, 22);
            this.tabPageItemType.Name = "tabPageItemType";
            this.tabPageItemType.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItemType.Size = new System.Drawing.Size(992, 574);
            this.tabPageItemType.TabIndex = 4;
            this.tabPageItemType.Text = "Item Type";
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
            this.groupBoxItemType.Location = new System.Drawing.Point(3, 6);
            this.groupBoxItemType.Name = "groupBoxItemType";
            this.groupBoxItemType.Size = new System.Drawing.Size(981, 560);
            this.groupBoxItemType.TabIndex = 6;
            this.groupBoxItemType.TabStop = false;
            this.groupBoxItemType.Text = "Type";
            // 
            // labelItemTypeId
            // 
            this.labelItemTypeId.AutoSize = true;
            this.labelItemTypeId.Enabled = false;
            this.labelItemTypeId.Location = new System.Drawing.Point(746, 36);
            this.labelItemTypeId.Name = "labelItemTypeId";
            this.labelItemTypeId.Size = new System.Drawing.Size(16, 13);
            this.labelItemTypeId.TabIndex = 21;
            this.labelItemTypeId.Text = "-1";
            this.labelItemTypeId.Visible = false;
            // 
            // labelItemTypeList
            // 
            this.labelItemTypeList.AutoSize = true;
            this.labelItemTypeList.Location = new System.Drawing.Point(310, 16);
            this.labelItemTypeList.Name = "labelItemTypeList";
            this.labelItemTypeList.Size = new System.Drawing.Size(23, 13);
            this.labelItemTypeList.TabIndex = 10;
            this.labelItemTypeList.Text = "List";
            // 
            // textBoxItemTypeName
            // 
            this.textBoxItemTypeName.Location = new System.Drawing.Point(6, 32);
            this.textBoxItemTypeName.Name = "textBoxItemTypeName";
            this.textBoxItemTypeName.Size = new System.Drawing.Size(300, 20);
            this.textBoxItemTypeName.TabIndex = 1;
            // 
            // buttonItemTypeUpdate
            // 
            this.buttonItemTypeUpdate.Enabled = false;
            this.buttonItemTypeUpdate.Location = new System.Drawing.Point(660, 86);
            this.buttonItemTypeUpdate.Name = "buttonItemTypeUpdate";
            this.buttonItemTypeUpdate.Size = new System.Drawing.Size(80, 21);
            this.buttonItemTypeUpdate.TabIndex = 6;
            this.buttonItemTypeUpdate.Text = "Update";
            this.buttonItemTypeUpdate.UseVisualStyleBackColor = true;
            this.buttonItemTypeUpdate.Click += new System.EventHandler(this.ButtonItemTypeUpdateClick);
            // 
            // buttonItemTypeDelete
            // 
            this.buttonItemTypeDelete.Enabled = false;
            this.buttonItemTypeDelete.Location = new System.Drawing.Point(660, 113);
            this.buttonItemTypeDelete.Name = "buttonItemTypeDelete";
            this.buttonItemTypeDelete.Size = new System.Drawing.Size(80, 21);
            this.buttonItemTypeDelete.TabIndex = 7;
            this.buttonItemTypeDelete.Text = "Delete";
            this.buttonItemTypeDelete.UseVisualStyleBackColor = true;
            this.buttonItemTypeDelete.Click += new System.EventHandler(this.ButtonItemTypeDeleteClick);
            // 
            // listBoxItemTypeList
            // 
            this.listBoxItemTypeList.FormattingEnabled = true;
            this.listBoxItemTypeList.Location = new System.Drawing.Point(310, 32);
            this.listBoxItemTypeList.Name = "listBoxItemTypeList";
            this.listBoxItemTypeList.ScrollAlwaysVisible = true;
            this.listBoxItemTypeList.Size = new System.Drawing.Size(345, 511);
            this.listBoxItemTypeList.TabIndex = 3;
            // 
            // buttonItemTypeListSelect
            // 
            this.buttonItemTypeListSelect.Location = new System.Drawing.Point(660, 32);
            this.buttonItemTypeListSelect.Name = "buttonItemTypeListSelect";
            this.buttonItemTypeListSelect.Size = new System.Drawing.Size(80, 21);
            this.buttonItemTypeListSelect.TabIndex = 4;
            this.buttonItemTypeListSelect.Text = "Select";
            this.buttonItemTypeListSelect.UseVisualStyleBackColor = true;
            this.buttonItemTypeListSelect.Click += new System.EventHandler(this.ButtonItemTypeListSelectClick);
            // 
            // labelItemTypeName
            // 
            this.labelItemTypeName.AutoSize = true;
            this.labelItemTypeName.Location = new System.Drawing.Point(6, 16);
            this.labelItemTypeName.Name = "labelItemTypeName";
            this.labelItemTypeName.Size = new System.Drawing.Size(35, 13);
            this.labelItemTypeName.TabIndex = 4;
            this.labelItemTypeName.Text = "Name";
            // 
            // buttonItemTypeSave
            // 
            this.buttonItemTypeSave.Location = new System.Drawing.Point(660, 59);
            this.buttonItemTypeSave.Name = "buttonItemTypeSave";
            this.buttonItemTypeSave.Size = new System.Drawing.Size(80, 21);
            this.buttonItemTypeSave.TabIndex = 5;
            this.buttonItemTypeSave.Text = "Save";
            this.buttonItemTypeSave.UseVisualStyleBackColor = true;
            this.buttonItemTypeSave.Click += new System.EventHandler(this.ButtonItemTypeSaveClick);
            // 
            // labelItemTypeDescription
            // 
            this.labelItemTypeDescription.AutoSize = true;
            this.labelItemTypeDescription.Location = new System.Drawing.Point(6, 56);
            this.labelItemTypeDescription.Name = "labelItemTypeDescription";
            this.labelItemTypeDescription.Size = new System.Drawing.Size(60, 13);
            this.labelItemTypeDescription.TabIndex = 1;
            this.labelItemTypeDescription.Text = "Description";
            // 
            // textBoxItemTypeDescription
            // 
            this.textBoxItemTypeDescription.Location = new System.Drawing.Point(6, 72);
            this.textBoxItemTypeDescription.Name = "textBoxItemTypeDescription";
            this.textBoxItemTypeDescription.Size = new System.Drawing.Size(300, 20);
            this.textBoxItemTypeDescription.TabIndex = 2;
            // 
            // tabPageItemStatus
            // 
            this.tabPageItemStatus.Controls.Add(this.groupBoxItemsStatus);
            this.tabPageItemStatus.Location = new System.Drawing.Point(4, 22);
            this.tabPageItemStatus.Name = "tabPageItemStatus";
            this.tabPageItemStatus.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageItemStatus.Size = new System.Drawing.Size(992, 574);
            this.tabPageItemStatus.TabIndex = 5;
            this.tabPageItemStatus.Text = "Item Status";
            this.tabPageItemStatus.UseVisualStyleBackColor = true;
            // 
            // groupBoxItemsStatus
            // 
            this.groupBoxItemsStatus.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBoxItemsStatus.AutoSize = true;
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
            this.groupBoxItemsStatus.Location = new System.Drawing.Point(3, 6);
            this.groupBoxItemsStatus.Name = "groupBoxItemsStatus";
            this.groupBoxItemsStatus.Size = new System.Drawing.Size(981, 565);
            this.groupBoxItemsStatus.TabIndex = 1;
            this.groupBoxItemsStatus.TabStop = false;
            this.groupBoxItemsStatus.Text = "Status";
            // 
            // labelItemStatusId
            // 
            this.labelItemStatusId.AutoSize = true;
            this.labelItemStatusId.Enabled = false;
            this.labelItemStatusId.Location = new System.Drawing.Point(747, 38);
            this.labelItemStatusId.Name = "labelItemStatusId";
            this.labelItemStatusId.Size = new System.Drawing.Size(16, 13);
            this.labelItemStatusId.TabIndex = 13;
            this.labelItemStatusId.Text = "-1";
            this.labelItemStatusId.Visible = false;
            // 
            // labelItemStatusList
            // 
            this.labelItemStatusList.AutoSize = true;
            this.labelItemStatusList.Location = new System.Drawing.Point(310, 16);
            this.labelItemStatusList.Name = "labelItemStatusList";
            this.labelItemStatusList.Size = new System.Drawing.Size(23, 13);
            this.labelItemStatusList.TabIndex = 12;
            this.labelItemStatusList.Text = "List";
            // 
            // labelItemStatusDescription
            // 
            this.labelItemStatusDescription.AutoSize = true;
            this.labelItemStatusDescription.Location = new System.Drawing.Point(6, 56);
            this.labelItemStatusDescription.Name = "labelItemStatusDescription";
            this.labelItemStatusDescription.Size = new System.Drawing.Size(60, 13);
            this.labelItemStatusDescription.TabIndex = 11;
            this.labelItemStatusDescription.Text = "Description";
            // 
            // textBoxItemStatusDescription
            // 
            this.textBoxItemStatusDescription.Location = new System.Drawing.Point(6, 72);
            this.textBoxItemStatusDescription.Name = "textBoxItemStatusDescription";
            this.textBoxItemStatusDescription.Size = new System.Drawing.Size(300, 20);
            this.textBoxItemStatusDescription.TabIndex = 2;
            // 
            // buttonItemStatusUpdate
            // 
            this.buttonItemStatusUpdate.Enabled = false;
            this.buttonItemStatusUpdate.Location = new System.Drawing.Point(660, 86);
            this.buttonItemStatusUpdate.Name = "buttonItemStatusUpdate";
            this.buttonItemStatusUpdate.Size = new System.Drawing.Size(80, 21);
            this.buttonItemStatusUpdate.TabIndex = 6;
            this.buttonItemStatusUpdate.Text = "Update";
            this.buttonItemStatusUpdate.UseVisualStyleBackColor = true;
            this.buttonItemStatusUpdate.Click += new System.EventHandler(this.ButtonItemStatusUpdateClick);
            // 
            // buttonItemStatusDelete
            // 
            this.buttonItemStatusDelete.Enabled = false;
            this.buttonItemStatusDelete.Location = new System.Drawing.Point(660, 113);
            this.buttonItemStatusDelete.Name = "buttonItemStatusDelete";
            this.buttonItemStatusDelete.Size = new System.Drawing.Size(80, 21);
            this.buttonItemStatusDelete.TabIndex = 7;
            this.buttonItemStatusDelete.Text = "Delete";
            this.buttonItemStatusDelete.UseVisualStyleBackColor = true;
            this.buttonItemStatusDelete.Click += new System.EventHandler(this.ButtonItemStatusDeleteClick);
            // 
            // listBoxItemStatusList
            // 
            this.listBoxItemStatusList.FormattingEnabled = true;
            this.listBoxItemStatusList.Location = new System.Drawing.Point(310, 32);
            this.listBoxItemStatusList.Name = "listBoxItemStatusList";
            this.listBoxItemStatusList.ScrollAlwaysVisible = true;
            this.listBoxItemStatusList.Size = new System.Drawing.Size(345, 511);
            this.listBoxItemStatusList.TabIndex = 3;
            // 
            // buttonItemsStatusSelect
            // 
            this.buttonItemsStatusSelect.Location = new System.Drawing.Point(660, 32);
            this.buttonItemsStatusSelect.Name = "buttonItemsStatusSelect";
            this.buttonItemsStatusSelect.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsStatusSelect.TabIndex = 4;
            this.buttonItemsStatusSelect.Text = "Select";
            this.buttonItemsStatusSelect.UseVisualStyleBackColor = true;
            this.buttonItemsStatusSelect.Click += new System.EventHandler(this.ButtonItemsStatusSelectClick);
            // 
            // buttonItemsStatusSave
            // 
            this.buttonItemsStatusSave.Location = new System.Drawing.Point(660, 59);
            this.buttonItemsStatusSave.Name = "buttonItemsStatusSave";
            this.buttonItemsStatusSave.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsStatusSave.TabIndex = 5;
            this.buttonItemsStatusSave.Text = "Save";
            this.buttonItemsStatusSave.UseVisualStyleBackColor = true;
            this.buttonItemsStatusSave.Click += new System.EventHandler(this.ButtonItemsStatusSaveClick);
            // 
            // labelItemsStatusNew
            // 
            this.labelItemsStatusNew.AutoSize = true;
            this.labelItemsStatusNew.Location = new System.Drawing.Point(6, 16);
            this.labelItemsStatusNew.Name = "labelItemsStatusNew";
            this.labelItemsStatusNew.Size = new System.Drawing.Size(35, 13);
            this.labelItemsStatusNew.TabIndex = 1;
            this.labelItemsStatusNew.Text = "Name";
            // 
            // textBoxItemStatusName
            // 
            this.textBoxItemStatusName.Location = new System.Drawing.Point(6, 32);
            this.textBoxItemStatusName.Name = "textBoxItemStatusName";
            this.textBoxItemStatusName.Size = new System.Drawing.Size(300, 20);
            this.textBoxItemStatusName.TabIndex = 1;
            // 
            // tabPagePersonInfo
            // 
            this.tabPagePersonInfo.Controls.Add(this.groupBoxPersonInfo);
            this.tabPagePersonInfo.Location = new System.Drawing.Point(4, 22);
            this.tabPagePersonInfo.Name = "tabPagePersonInfo";
            this.tabPagePersonInfo.Padding = new System.Windows.Forms.Padding(3);
            this.tabPagePersonInfo.Size = new System.Drawing.Size(992, 574);
            this.tabPagePersonInfo.TabIndex = 6;
            this.tabPagePersonInfo.Text = "Person Info";
            this.tabPagePersonInfo.UseVisualStyleBackColor = true;
            // 
            // groupBoxPersonInfo
            // 
            this.groupBoxPersonInfo.Controls.Add(this.buttonPersonInfoListSelect);
            this.groupBoxPersonInfo.Controls.Add(this.buttonPersonInfoDelete);
            this.groupBoxPersonInfo.Controls.Add(this.buttonPersonInfoUpdate);
            this.groupBoxPersonInfo.Controls.Add(this.labelPersonInfoList);
            this.groupBoxPersonInfo.Controls.Add(this.listBoxPersonInfoList);
            this.groupBoxPersonInfo.Controls.Add(this.buttonOrderPersonInfoSave);
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
            this.groupBoxPersonInfo.Location = new System.Drawing.Point(3, 6);
            this.groupBoxPersonInfo.Name = "groupBoxPersonInfo";
            this.groupBoxPersonInfo.Size = new System.Drawing.Size(981, 565);
            this.groupBoxPersonInfo.TabIndex = 0;
            this.groupBoxPersonInfo.TabStop = false;
            this.groupBoxPersonInfo.Text = "Person Info";
            // 
            // buttonPersonInfoListSelect
            // 
            this.buttonPersonInfoListSelect.Location = new System.Drawing.Point(660, 32);
            this.buttonPersonInfoListSelect.Name = "buttonPersonInfoListSelect";
            this.buttonPersonInfoListSelect.Size = new System.Drawing.Size(80, 21);
            this.buttonPersonInfoListSelect.TabIndex = 13;
            this.buttonPersonInfoListSelect.Text = "Select";
            this.buttonPersonInfoListSelect.UseVisualStyleBackColor = true;
            this.buttonPersonInfoListSelect.Click += new System.EventHandler(this.ButtonPersonInfoListSelectClick);
            // 
            // buttonPersonInfoDelete
            // 
            this.buttonPersonInfoDelete.Enabled = false;
            this.buttonPersonInfoDelete.Location = new System.Drawing.Point(660, 113);
            this.buttonPersonInfoDelete.Name = "buttonPersonInfoDelete";
            this.buttonPersonInfoDelete.Size = new System.Drawing.Size(80, 21);
            this.buttonPersonInfoDelete.TabIndex = 16;
            this.buttonPersonInfoDelete.Text = "Delete";
            this.buttonPersonInfoDelete.UseVisualStyleBackColor = true;
            // 
            // buttonPersonInfoUpdate
            // 
            this.buttonPersonInfoUpdate.Enabled = false;
            this.buttonPersonInfoUpdate.Location = new System.Drawing.Point(660, 86);
            this.buttonPersonInfoUpdate.Name = "buttonPersonInfoUpdate";
            this.buttonPersonInfoUpdate.Size = new System.Drawing.Size(80, 21);
            this.buttonPersonInfoUpdate.TabIndex = 15;
            this.buttonPersonInfoUpdate.Text = "Update";
            this.buttonPersonInfoUpdate.UseVisualStyleBackColor = true;
            // 
            // labelPersonInfoList
            // 
            this.labelPersonInfoList.AutoSize = true;
            this.labelPersonInfoList.Location = new System.Drawing.Point(310, 16);
            this.labelPersonInfoList.Name = "labelPersonInfoList";
            this.labelPersonInfoList.Size = new System.Drawing.Size(23, 13);
            this.labelPersonInfoList.TabIndex = 53;
            this.labelPersonInfoList.Text = "List";
            // 
            // listBoxPersonInfoList
            // 
            this.listBoxPersonInfoList.FormattingEnabled = true;
            this.listBoxPersonInfoList.Location = new System.Drawing.Point(310, 32);
            this.listBoxPersonInfoList.Name = "listBoxPersonInfoList";
            this.listBoxPersonInfoList.ScrollAlwaysVisible = true;
            this.listBoxPersonInfoList.Size = new System.Drawing.Size(345, 511);
            this.listBoxPersonInfoList.TabIndex = 12;
            // 
            // buttonOrderPersonInfoSave
            // 
            this.buttonOrderPersonInfoSave.Location = new System.Drawing.Point(660, 59);
            this.buttonOrderPersonInfoSave.Name = "buttonOrderPersonInfoSave";
            this.buttonOrderPersonInfoSave.Size = new System.Drawing.Size(80, 21);
            this.buttonOrderPersonInfoSave.TabIndex = 14;
            this.buttonOrderPersonInfoSave.Text = "Save";
            this.buttonOrderPersonInfoSave.UseVisualStyleBackColor = true;
            this.buttonOrderPersonInfoSave.Click += new System.EventHandler(this.ButtonOrderPersonInfoSaveClick);
            // 
            // textBoxPersonInfoFaxNumber
            // 
            this.textBoxPersonInfoFaxNumber.Location = new System.Drawing.Point(6, 432);
            this.textBoxPersonInfoFaxNumber.Name = "textBoxPersonInfoFaxNumber";
            this.textBoxPersonInfoFaxNumber.Size = new System.Drawing.Size(300, 20);
            this.textBoxPersonInfoFaxNumber.TabIndex = 11;
            // 
            // labelPersonInfoFax
            // 
            this.labelPersonInfoFax.AutoSize = true;
            this.labelPersonInfoFax.Location = new System.Drawing.Point(6, 416);
            this.labelPersonInfoFax.Name = "labelPersonInfoFax";
            this.labelPersonInfoFax.Size = new System.Drawing.Size(64, 13);
            this.labelPersonInfoFax.TabIndex = 49;
            this.labelPersonInfoFax.Text = "Fax Number";
            // 
            // textBoxPersonInfoTelephoneMobile
            // 
            this.textBoxPersonInfoTelephoneMobile.Location = new System.Drawing.Point(6, 392);
            this.textBoxPersonInfoTelephoneMobile.Name = "textBoxPersonInfoTelephoneMobile";
            this.textBoxPersonInfoTelephoneMobile.Size = new System.Drawing.Size(300, 20);
            this.textBoxPersonInfoTelephoneMobile.TabIndex = 10;
            // 
            // labelPersonInfoTelephoneMobile
            // 
            this.labelPersonInfoTelephoneMobile.AutoSize = true;
            this.labelPersonInfoTelephoneMobile.Location = new System.Drawing.Point(6, 376);
            this.labelPersonInfoTelephoneMobile.Name = "labelPersonInfoTelephoneMobile";
            this.labelPersonInfoTelephoneMobile.Size = new System.Drawing.Size(92, 13);
            this.labelPersonInfoTelephoneMobile.TabIndex = 47;
            this.labelPersonInfoTelephoneMobile.Text = "Mobile Telephone";
            // 
            // textBoxPersonInfoTelephone
            // 
            this.textBoxPersonInfoTelephone.Location = new System.Drawing.Point(6, 352);
            this.textBoxPersonInfoTelephone.Name = "textBoxPersonInfoTelephone";
            this.textBoxPersonInfoTelephone.Size = new System.Drawing.Size(300, 20);
            this.textBoxPersonInfoTelephone.TabIndex = 9;
            // 
            // labelPersonInfoTelephone
            // 
            this.labelPersonInfoTelephone.AutoSize = true;
            this.labelPersonInfoTelephone.Location = new System.Drawing.Point(6, 336);
            this.labelPersonInfoTelephone.Name = "labelPersonInfoTelephone";
            this.labelPersonInfoTelephone.Size = new System.Drawing.Size(58, 13);
            this.labelPersonInfoTelephone.TabIndex = 45;
            this.labelPersonInfoTelephone.Text = "Telephone";
            // 
            // textBoxPersonInfoEmail
            // 
            this.textBoxPersonInfoEmail.Location = new System.Drawing.Point(6, 312);
            this.textBoxPersonInfoEmail.Name = "textBoxPersonInfoEmail";
            this.textBoxPersonInfoEmail.Size = new System.Drawing.Size(300, 20);
            this.textBoxPersonInfoEmail.TabIndex = 8;
            // 
            // labelPersonInfoEmail
            // 
            this.labelPersonInfoEmail.AutoSize = true;
            this.labelPersonInfoEmail.Location = new System.Drawing.Point(6, 296);
            this.labelPersonInfoEmail.Name = "labelPersonInfoEmail";
            this.labelPersonInfoEmail.Size = new System.Drawing.Size(32, 13);
            this.labelPersonInfoEmail.TabIndex = 43;
            this.labelPersonInfoEmail.Text = "Email";
            // 
            // textBoxPersonInfoPopstNumber
            // 
            this.textBoxPersonInfoPopstNumber.Location = new System.Drawing.Point(6, 272);
            this.textBoxPersonInfoPopstNumber.Name = "textBoxPersonInfoPopstNumber";
            this.textBoxPersonInfoPopstNumber.Size = new System.Drawing.Size(300, 20);
            this.textBoxPersonInfoPopstNumber.TabIndex = 7;
            // 
            // labelPersonInfoPostNumber
            // 
            this.labelPersonInfoPostNumber.AutoSize = true;
            this.labelPersonInfoPostNumber.Location = new System.Drawing.Point(6, 256);
            this.labelPersonInfoPostNumber.Name = "labelPersonInfoPostNumber";
            this.labelPersonInfoPostNumber.Size = new System.Drawing.Size(68, 13);
            this.labelPersonInfoPostNumber.TabIndex = 41;
            this.labelPersonInfoPostNumber.Text = "Post Number";
            // 
            // textBoxPersonInfoCity
            // 
            this.textBoxPersonInfoCity.Location = new System.Drawing.Point(6, 232);
            this.textBoxPersonInfoCity.Name = "textBoxPersonInfoCity";
            this.textBoxPersonInfoCity.Size = new System.Drawing.Size(300, 20);
            this.textBoxPersonInfoCity.TabIndex = 6;
            // 
            // labelPersonInfoCity
            // 
            this.labelPersonInfoCity.AutoSize = true;
            this.labelPersonInfoCity.Location = new System.Drawing.Point(6, 216);
            this.labelPersonInfoCity.Name = "labelPersonInfoCity";
            this.labelPersonInfoCity.Size = new System.Drawing.Size(24, 13);
            this.labelPersonInfoCity.TabIndex = 39;
            this.labelPersonInfoCity.Text = "City";
            // 
            // textBoxPersonInfoAddress
            // 
            this.textBoxPersonInfoAddress.Location = new System.Drawing.Point(6, 192);
            this.textBoxPersonInfoAddress.Name = "textBoxPersonInfoAddress";
            this.textBoxPersonInfoAddress.Size = new System.Drawing.Size(300, 20);
            this.textBoxPersonInfoAddress.TabIndex = 5;
            // 
            // labelPersonInfoAddress
            // 
            this.labelPersonInfoAddress.AutoSize = true;
            this.labelPersonInfoAddress.Location = new System.Drawing.Point(6, 176);
            this.labelPersonInfoAddress.Name = "labelPersonInfoAddress";
            this.labelPersonInfoAddress.Size = new System.Drawing.Size(45, 13);
            this.labelPersonInfoAddress.TabIndex = 37;
            this.labelPersonInfoAddress.Text = "Address";
            // 
            // textBoxPersonInfoDescription
            // 
            this.textBoxPersonInfoDescription.Location = new System.Drawing.Point(6, 152);
            this.textBoxPersonInfoDescription.Name = "textBoxPersonInfoDescription";
            this.textBoxPersonInfoDescription.Size = new System.Drawing.Size(300, 20);
            this.textBoxPersonInfoDescription.TabIndex = 4;
            // 
            // labelPersonInfoDescription
            // 
            this.labelPersonInfoDescription.AutoSize = true;
            this.labelPersonInfoDescription.Location = new System.Drawing.Point(6, 136);
            this.labelPersonInfoDescription.Name = "labelPersonInfoDescription";
            this.labelPersonInfoDescription.Size = new System.Drawing.Size(60, 13);
            this.labelPersonInfoDescription.TabIndex = 35;
            this.labelPersonInfoDescription.Text = "Description";
            // 
            // textBoxPersonInfoNickName
            // 
            this.textBoxPersonInfoNickName.Location = new System.Drawing.Point(6, 112);
            this.textBoxPersonInfoNickName.Name = "textBoxPersonInfoNickName";
            this.textBoxPersonInfoNickName.Size = new System.Drawing.Size(300, 20);
            this.textBoxPersonInfoNickName.TabIndex = 3;
            // 
            // labelPersonInfoNickName
            // 
            this.labelPersonInfoNickName.AutoSize = true;
            this.labelPersonInfoNickName.Location = new System.Drawing.Point(6, 96);
            this.labelPersonInfoNickName.Name = "labelPersonInfoNickName";
            this.labelPersonInfoNickName.Size = new System.Drawing.Size(55, 13);
            this.labelPersonInfoNickName.TabIndex = 33;
            this.labelPersonInfoNickName.Text = "Nickname";
            // 
            // textBoxPersonInfoSurName
            // 
            this.textBoxPersonInfoSurName.Location = new System.Drawing.Point(6, 72);
            this.textBoxPersonInfoSurName.Name = "textBoxPersonInfoSurName";
            this.textBoxPersonInfoSurName.Size = new System.Drawing.Size(300, 20);
            this.textBoxPersonInfoSurName.TabIndex = 2;
            // 
            // labelPersonInfoSurName
            // 
            this.labelPersonInfoSurName.AutoSize = true;
            this.labelPersonInfoSurName.Location = new System.Drawing.Point(6, 56);
            this.labelPersonInfoSurName.Name = "labelPersonInfoSurName";
            this.labelPersonInfoSurName.Size = new System.Drawing.Size(49, 13);
            this.labelPersonInfoSurName.TabIndex = 31;
            this.labelPersonInfoSurName.Text = "Surname";
            // 
            // textBoxPersonInfoName
            // 
            this.textBoxPersonInfoName.Location = new System.Drawing.Point(6, 32);
            this.textBoxPersonInfoName.Name = "textBoxPersonInfoName";
            this.textBoxPersonInfoName.Size = new System.Drawing.Size(300, 20);
            this.textBoxPersonInfoName.TabIndex = 1;
            // 
            // labelPersonInfoName
            // 
            this.labelPersonInfoName.AutoSize = true;
            this.labelPersonInfoName.Location = new System.Drawing.Point(6, 16);
            this.labelPersonInfoName.Name = "labelPersonInfoName";
            this.labelPersonInfoName.Size = new System.Drawing.Size(35, 13);
            this.labelPersonInfoName.TabIndex = 29;
            this.labelPersonInfoName.Text = "Name";
            // 
            // tabPageReports
            // 
            this.tabPageReports.Location = new System.Drawing.Point(4, 22);
            this.tabPageReports.Name = "tabPageReports";
            this.tabPageReports.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageReports.Size = new System.Drawing.Size(992, 574);
            this.tabPageReports.TabIndex = 3;
            this.tabPageReports.Text = "Reports";
            this.tabPageReports.UseVisualStyleBackColor = true;
            // 
            // Gui
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1000, 600);
            this.Controls.Add(this.tabControl);
            this.IsMdiContainer = true;
            this.Name = "Gui";
            this.Text = "Item Tracker";
            this.tabControl.ResumeLayout(false);
            this.tabPageOrders.ResumeLayout(false);
            this.groupBoxOrder.ResumeLayout(false);
            this.groupBoxOrder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrder)).EndInit();
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
        private System.Windows.Forms.PictureBox pictureBoxOrder;
        private System.Windows.Forms.ComboBox comboBoxOrderItemStatus;
        private System.Windows.Forms.Label labelOrderItemStatus;
        private System.Windows.Forms.TextBox textBoxOrderTax;
        private System.Windows.Forms.Label labelOrderTax;
        private System.Windows.Forms.TextBox textBoxOrderPrice;
        private System.Windows.Forms.Label labelOrderPrice;
        private System.Windows.Forms.TextBox textBoxOrderItemNumber;
        private System.Windows.Forms.Label labelOrderItemCount;
        private System.Windows.Forms.Label labelOrderItemPicture;
        private System.Windows.Forms.ComboBox comboBoxOrderItem;
        private System.Windows.Forms.Label labelOrderItem;
        private System.Windows.Forms.TextBox textBoxOrderPostage;
        private System.Windows.Forms.Label labelOrderPostage;
        private System.Windows.Forms.Button buttonOrderSave;
        private System.Windows.Forms.Label labelItemsDescription;
        private System.Windows.Forms.TextBox textBoxItemsDescription;
        private System.Windows.Forms.Button buttonOrderitemSelect;
        private System.Windows.Forms.TabPage tabPageItemType;
        private System.Windows.Forms.TabPage tabPageItemStatus;
        private System.Windows.Forms.TabPage tabPagePersonInfo;
        private System.Windows.Forms.GroupBox groupBoxPersonInfo;
        private System.Windows.Forms.Button buttonPersonInfoListSelect;
        private System.Windows.Forms.Button buttonPersonInfoDelete;
        private System.Windows.Forms.Button buttonPersonInfoUpdate;
        private System.Windows.Forms.Label labelPersonInfoList;
        private System.Windows.Forms.ListBox listBoxPersonInfoList;
        private System.Windows.Forms.Button buttonOrderPersonInfoSave;
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
    }
}

