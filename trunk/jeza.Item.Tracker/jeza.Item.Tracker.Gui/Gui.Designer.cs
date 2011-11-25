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
            this.tabPageItems = new System.Windows.Forms.TabPage();
            this.groupBoxItems = new System.Windows.Forms.GroupBox();
            this.labelItemsImage = new System.Windows.Forms.Label();
            this.textBoxItemsImage = new System.Windows.Forms.TextBox();
            this.buttonItemsPictureBoxSelect = new System.Windows.Forms.Button();
            this.pictureBoxItems = new System.Windows.Forms.PictureBox();
            this.buttonItemsSelect = new System.Windows.Forms.Button();
            this.labelItemsItemType = new System.Windows.Forms.Label();
            this.comboBoxItemsItemType = new System.Windows.Forms.ComboBox();
            this.listBoxItems = new System.Windows.Forms.ListBox();
            this.buttonItemsSave = new System.Windows.Forms.Button();
            this.labelItemsNew = new System.Windows.Forms.Label();
            this.textBoxItemsNew = new System.Windows.Forms.TextBox();
            this.labelItemsType = new System.Windows.Forms.Label();
            this.groupBoxItemsType = new System.Windows.Forms.GroupBox();
            this.buttonItemsTypeSelect = new System.Windows.Forms.Button();
            this.labelItemsTypeExisting = new System.Windows.Forms.Label();
            this.comboBoxItemsTypeExisting = new System.Windows.Forms.ComboBox();
            this.buttonItemsTypeSave = new System.Windows.Forms.Button();
            this.labelItemsTypeNew = new System.Windows.Forms.Label();
            this.textBoxItemsTypeNew = new System.Windows.Forms.TextBox();
            this.groupBoxItemsStatus = new System.Windows.Forms.GroupBox();
            this.buttonItemsStatusSelect = new System.Windows.Forms.Button();
            this.labelItemsStatusExisting = new System.Windows.Forms.Label();
            this.comboBoxItemsStatusExisting = new System.Windows.Forms.ComboBox();
            this.buttonItemsStatusSave = new System.Windows.Forms.Button();
            this.labelItemsStatusNew = new System.Windows.Forms.Label();
            this.textBoxItemsStatusNew = new System.Windows.Forms.TextBox();
            this.tabPageOrder = new System.Windows.Forms.TabPage();
            this.groupBoxOrderCalculation = new System.Windows.Forms.GroupBox();
            this.labelOrderCalculationTotalValue = new System.Windows.Forms.Label();
            this.buttonOrderCalculation = new System.Windows.Forms.Button();
            this.labelOrderCalculation = new System.Windows.Forms.Label();
            this.groupBoxOrderItem = new System.Windows.Forms.GroupBox();
            this.buttonOrderItemSave = new System.Windows.Forms.Button();
            this.textBoxOrderItemPostage = new System.Windows.Forms.TextBox();
            this.labelOrderItemPostage = new System.Windows.Forms.Label();
            this.comboBoxOrderItemStatus = new System.Windows.Forms.ComboBox();
            this.checkBoxOrderItemLegalEntity = new System.Windows.Forms.CheckBox();
            this.labelOrderItemStatus = new System.Windows.Forms.Label();
            this.labelOrderItemLegalEntity = new System.Windows.Forms.Label();
            this.textBoxOrderItemPriceNeto = new System.Windows.Forms.TextBox();
            this.labelOrderItemPriceNeto = new System.Windows.Forms.Label();
            this.textBoxOrderItemPriceGross = new System.Windows.Forms.TextBox();
            this.labelOrderItemPriceGross = new System.Windows.Forms.Label();
            this.textBoxOrderItemNumber = new System.Windows.Forms.TextBox();
            this.labelOrderItemCount = new System.Windows.Forms.Label();
            this.labelOrderItemPicture = new System.Windows.Forms.Label();
            this.comboBoxOrderItem = new System.Windows.Forms.ComboBox();
            this.labelOrderItem = new System.Windows.Forms.Label();
            this.pictureBoxOrderItem = new System.Windows.Forms.PictureBox();
            this.groupBoxOrderPersonInfo = new System.Windows.Forms.GroupBox();
            this.buttonOrderSubscriberPersonInfoSelect = new System.Windows.Forms.Button();
            this.buttonOrderPersonInfoSave = new System.Windows.Forms.Button();
            this.comboBoxOrderSubscriberPersonInfo = new System.Windows.Forms.ComboBox();
            this.textBoxOrderPersonInfoFaxNumber = new System.Windows.Forms.TextBox();
            this.labelOrderSubscriberPersonInfo = new System.Windows.Forms.Label();
            this.labelOrderPersonInfoFax = new System.Windows.Forms.Label();
            this.textBoxOrderPersonInfoTelephoneMobile = new System.Windows.Forms.TextBox();
            this.labelOrderPersonInfoTelephoneMobile = new System.Windows.Forms.Label();
            this.textBoxOrderPersonInfoTelephone = new System.Windows.Forms.TextBox();
            this.labelOrderPersonInfoTelephone = new System.Windows.Forms.Label();
            this.textBoxOrderPersonInfoEmail = new System.Windows.Forms.TextBox();
            this.labelOrderPersonInfoEmail = new System.Windows.Forms.Label();
            this.textBoxOrderPersonInfoPopstNumber = new System.Windows.Forms.TextBox();
            this.labelOrderPersonInfoPostNumber = new System.Windows.Forms.Label();
            this.textBoxOrderPersonInfoCity = new System.Windows.Forms.TextBox();
            this.labelOrderPersonInfoCity = new System.Windows.Forms.Label();
            this.textBoxOrderPersonInfoAddress = new System.Windows.Forms.TextBox();
            this.labelOrderPersonInfoAddress = new System.Windows.Forms.Label();
            this.textBoxOrderPersonInfoDescription = new System.Windows.Forms.TextBox();
            this.labelOrderPersonInfoDescription = new System.Windows.Forms.Label();
            this.textBoxOrderPersonInfoNickName = new System.Windows.Forms.TextBox();
            this.labelOrderPersonInfoNickName = new System.Windows.Forms.Label();
            this.textBoxOrderPersonInfoSurName = new System.Windows.Forms.TextBox();
            this.labelOrderPersonInfoSurName = new System.Windows.Forms.Label();
            this.textBoxOrderPersonInfoName = new System.Windows.Forms.TextBox();
            this.labelOrderPersonInfoName = new System.Windows.Forms.Label();
            this.tabPageReports = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.tabPageItems.SuspendLayout();
            this.groupBoxItems.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItems)).BeginInit();
            this.groupBoxItemsType.SuspendLayout();
            this.groupBoxItemsStatus.SuspendLayout();
            this.tabPageOrder.SuspendLayout();
            this.groupBoxOrderCalculation.SuspendLayout();
            this.groupBoxOrderItem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrderItem)).BeginInit();
            this.groupBoxOrderPersonInfo.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.tabPageItems);
            this.tabControl.Controls.Add(this.tabPageOrder);
            this.tabControl.Controls.Add(this.tabPageReports);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(1000, 600);
            this.tabControl.TabIndex = 2;
            // 
            // tabPageItems
            // 
            this.tabPageItems.Controls.Add(this.groupBoxItems);
            this.tabPageItems.Controls.Add(this.groupBoxItemsType);
            this.tabPageItems.Controls.Add(this.groupBoxItemsStatus);
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
            this.groupBoxItems.Controls.Add(this.labelItemsImage);
            this.groupBoxItems.Controls.Add(this.textBoxItemsImage);
            this.groupBoxItems.Controls.Add(this.buttonItemsPictureBoxSelect);
            this.groupBoxItems.Controls.Add(this.pictureBoxItems);
            this.groupBoxItems.Controls.Add(this.buttonItemsSelect);
            this.groupBoxItems.Controls.Add(this.labelItemsItemType);
            this.groupBoxItems.Controls.Add(this.comboBoxItemsItemType);
            this.groupBoxItems.Controls.Add(this.listBoxItems);
            this.groupBoxItems.Controls.Add(this.buttonItemsSave);
            this.groupBoxItems.Controls.Add(this.labelItemsNew);
            this.groupBoxItems.Controls.Add(this.textBoxItemsNew);
            this.groupBoxItems.Controls.Add(this.labelItemsType);
            this.groupBoxItems.Location = new System.Drawing.Point(8, 122);
            this.groupBoxItems.Name = "groupBoxItems";
            this.groupBoxItems.Size = new System.Drawing.Size(966, 444);
            this.groupBoxItems.TabIndex = 6;
            this.groupBoxItems.TabStop = false;
            this.groupBoxItems.Text = "Items";
            // 
            // labelItemsImage
            // 
            this.labelItemsImage.AutoSize = true;
            this.labelItemsImage.Location = new System.Drawing.Point(494, 96);
            this.labelItemsImage.Name = "labelItemsImage";
            this.labelItemsImage.Size = new System.Drawing.Size(36, 13);
            this.labelItemsImage.TabIndex = 17;
            this.labelItemsImage.Text = "Image";
            // 
            // textBoxItemsImage
            // 
            this.textBoxItemsImage.Location = new System.Drawing.Point(494, 112);
            this.textBoxItemsImage.Name = "textBoxItemsImage";
            this.textBoxItemsImage.Size = new System.Drawing.Size(300, 20);
            this.textBoxItemsImage.TabIndex = 16;
            // 
            // buttonItemsPictureBoxSelect
            // 
            this.buttonItemsPictureBoxSelect.Location = new System.Drawing.Point(800, 111);
            this.buttonItemsPictureBoxSelect.Name = "buttonItemsPictureBoxSelect";
            this.buttonItemsPictureBoxSelect.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsPictureBoxSelect.TabIndex = 15;
            this.buttonItemsPictureBoxSelect.Text = "Select";
            this.buttonItemsPictureBoxSelect.UseVisualStyleBackColor = true;
            this.buttonItemsPictureBoxSelect.Click += new System.EventHandler(this.buttonItemsPictureBoxSelect_Click);
            // 
            // pictureBoxItems
            // 
            this.pictureBoxItems.Location = new System.Drawing.Point(494, 138);
            this.pictureBoxItems.Name = "pictureBoxItems";
            this.pictureBoxItems.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxItems.TabIndex = 14;
            this.pictureBoxItems.TabStop = false;
            // 
            // buttonItemsSelect
            // 
            this.buttonItemsSelect.Location = new System.Drawing.Point(312, 32);
            this.buttonItemsSelect.Name = "buttonItemsSelect";
            this.buttonItemsSelect.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsSelect.TabIndex = 13;
            this.buttonItemsSelect.Text = "Select";
            this.buttonItemsSelect.UseVisualStyleBackColor = true;
            // 
            // labelItemsItemType
            // 
            this.labelItemsItemType.AutoSize = true;
            this.labelItemsItemType.Location = new System.Drawing.Point(494, 56);
            this.labelItemsItemType.Name = "labelItemsItemType";
            this.labelItemsItemType.Size = new System.Drawing.Size(54, 13);
            this.labelItemsItemType.TabIndex = 12;
            this.labelItemsItemType.Text = "Item Type";
            // 
            // comboBoxItemsItemType
            // 
            this.comboBoxItemsItemType.FormattingEnabled = true;
            this.comboBoxItemsItemType.Location = new System.Drawing.Point(494, 72);
            this.comboBoxItemsItemType.Name = "comboBoxItemsItemType";
            this.comboBoxItemsItemType.Size = new System.Drawing.Size(300, 21);
            this.comboBoxItemsItemType.TabIndex = 11;
            // 
            // listBoxItems
            // 
            this.listBoxItems.FormattingEnabled = true;
            this.listBoxItems.Location = new System.Drawing.Point(6, 33);
            this.listBoxItems.Name = "listBoxItems";
            this.listBoxItems.ScrollAlwaysVisible = true;
            this.listBoxItems.Size = new System.Drawing.Size(300, 407);
            this.listBoxItems.TabIndex = 10;
            // 
            // buttonItemsSave
            // 
            this.buttonItemsSave.Location = new System.Drawing.Point(800, 32);
            this.buttonItemsSave.Name = "buttonItemsSave";
            this.buttonItemsSave.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsSave.TabIndex = 9;
            this.buttonItemsSave.Text = "Save";
            this.buttonItemsSave.UseVisualStyleBackColor = true;
            this.buttonItemsSave.Click += new System.EventHandler(this.buttonItemsSave_Click);
            // 
            // labelItemsNew
            // 
            this.labelItemsNew.AutoSize = true;
            this.labelItemsNew.Location = new System.Drawing.Point(494, 17);
            this.labelItemsNew.Name = "labelItemsNew";
            this.labelItemsNew.Size = new System.Drawing.Size(35, 13);
            this.labelItemsNew.TabIndex = 8;
            this.labelItemsNew.Text = "Name";
            // 
            // textBoxItemsNew
            // 
            this.textBoxItemsNew.Location = new System.Drawing.Point(494, 33);
            this.textBoxItemsNew.Name = "textBoxItemsNew";
            this.textBoxItemsNew.Size = new System.Drawing.Size(300, 20);
            this.textBoxItemsNew.TabIndex = 7;
            // 
            // labelItemsType
            // 
            this.labelItemsType.AutoSize = true;
            this.labelItemsType.Location = new System.Drawing.Point(6, 17);
            this.labelItemsType.Name = "labelItemsType";
            this.labelItemsType.Size = new System.Drawing.Size(35, 13);
            this.labelItemsType.TabIndex = 6;
            this.labelItemsType.Text = "Name";
            // 
            // groupBoxItemsType
            // 
            this.groupBoxItemsType.Controls.Add(this.buttonItemsTypeSelect);
            this.groupBoxItemsType.Controls.Add(this.labelItemsTypeExisting);
            this.groupBoxItemsType.Controls.Add(this.comboBoxItemsTypeExisting);
            this.groupBoxItemsType.Controls.Add(this.buttonItemsTypeSave);
            this.groupBoxItemsType.Controls.Add(this.labelItemsTypeNew);
            this.groupBoxItemsType.Controls.Add(this.textBoxItemsTypeNew);
            this.groupBoxItemsType.Location = new System.Drawing.Point(8, 6);
            this.groupBoxItemsType.Name = "groupBoxItemsType";
            this.groupBoxItemsType.Size = new System.Drawing.Size(480, 110);
            this.groupBoxItemsType.TabIndex = 5;
            this.groupBoxItemsType.TabStop = false;
            this.groupBoxItemsType.Text = "Type";
            // 
            // buttonItemsTypeSelect
            // 
            this.buttonItemsTypeSelect.Location = new System.Drawing.Point(312, 32);
            this.buttonItemsTypeSelect.Name = "buttonItemsTypeSelect";
            this.buttonItemsTypeSelect.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsTypeSelect.TabIndex = 5;
            this.buttonItemsTypeSelect.Text = "Select";
            this.buttonItemsTypeSelect.UseVisualStyleBackColor = true;
            // 
            // labelItemsTypeExisting
            // 
            this.labelItemsTypeExisting.AutoSize = true;
            this.labelItemsTypeExisting.Location = new System.Drawing.Point(6, 16);
            this.labelItemsTypeExisting.Name = "labelItemsTypeExisting";
            this.labelItemsTypeExisting.Size = new System.Drawing.Size(35, 13);
            this.labelItemsTypeExisting.TabIndex = 4;
            this.labelItemsTypeExisting.Text = "Name";
            // 
            // comboBoxItemsTypeExisting
            // 
            this.comboBoxItemsTypeExisting.FormattingEnabled = true;
            this.comboBoxItemsTypeExisting.Location = new System.Drawing.Point(6, 32);
            this.comboBoxItemsTypeExisting.Name = "comboBoxItemsTypeExisting";
            this.comboBoxItemsTypeExisting.Size = new System.Drawing.Size(300, 21);
            this.comboBoxItemsTypeExisting.TabIndex = 3;
            // 
            // buttonItemsTypeSave
            // 
            this.buttonItemsTypeSave.Location = new System.Drawing.Point(312, 72);
            this.buttonItemsTypeSave.Name = "buttonItemsTypeSave";
            this.buttonItemsTypeSave.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsTypeSave.TabIndex = 2;
            this.buttonItemsTypeSave.Text = "Save";
            this.buttonItemsTypeSave.UseVisualStyleBackColor = true;
            this.buttonItemsTypeSave.Click += new System.EventHandler(this.buttonItemsTypeSave_Click);
            // 
            // labelItemsTypeNew
            // 
            this.labelItemsTypeNew.AutoSize = true;
            this.labelItemsTypeNew.Location = new System.Drawing.Point(6, 56);
            this.labelItemsTypeNew.Name = "labelItemsTypeNew";
            this.labelItemsTypeNew.Size = new System.Drawing.Size(35, 13);
            this.labelItemsTypeNew.TabIndex = 1;
            this.labelItemsTypeNew.Text = "Name";
            // 
            // textBoxItemsTypeNew
            // 
            this.textBoxItemsTypeNew.Location = new System.Drawing.Point(6, 72);
            this.textBoxItemsTypeNew.Name = "textBoxItemsTypeNew";
            this.textBoxItemsTypeNew.Size = new System.Drawing.Size(300, 20);
            this.textBoxItemsTypeNew.TabIndex = 0;
            // 
            // groupBoxItemsStatus
            // 
            this.groupBoxItemsStatus.Controls.Add(this.buttonItemsStatusSelect);
            this.groupBoxItemsStatus.Controls.Add(this.labelItemsStatusExisting);
            this.groupBoxItemsStatus.Controls.Add(this.comboBoxItemsStatusExisting);
            this.groupBoxItemsStatus.Controls.Add(this.buttonItemsStatusSave);
            this.groupBoxItemsStatus.Controls.Add(this.labelItemsStatusNew);
            this.groupBoxItemsStatus.Controls.Add(this.textBoxItemsStatusNew);
            this.groupBoxItemsStatus.Location = new System.Drawing.Point(494, 6);
            this.groupBoxItemsStatus.Name = "groupBoxItemsStatus";
            this.groupBoxItemsStatus.Size = new System.Drawing.Size(480, 110);
            this.groupBoxItemsStatus.TabIndex = 0;
            this.groupBoxItemsStatus.TabStop = false;
            this.groupBoxItemsStatus.Text = "Status";
            // 
            // buttonItemsStatusSelect
            // 
            this.buttonItemsStatusSelect.Location = new System.Drawing.Point(314, 32);
            this.buttonItemsStatusSelect.Name = "buttonItemsStatusSelect";
            this.buttonItemsStatusSelect.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsStatusSelect.TabIndex = 5;
            this.buttonItemsStatusSelect.Text = "Select";
            this.buttonItemsStatusSelect.UseVisualStyleBackColor = true;
            // 
            // labelItemsStatusExisting
            // 
            this.labelItemsStatusExisting.AutoSize = true;
            this.labelItemsStatusExisting.Location = new System.Drawing.Point(6, 16);
            this.labelItemsStatusExisting.Name = "labelItemsStatusExisting";
            this.labelItemsStatusExisting.Size = new System.Drawing.Size(35, 13);
            this.labelItemsStatusExisting.TabIndex = 4;
            this.labelItemsStatusExisting.Text = "Name";
            // 
            // comboBoxItemsStatusExisting
            // 
            this.comboBoxItemsStatusExisting.FormattingEnabled = true;
            this.comboBoxItemsStatusExisting.Location = new System.Drawing.Point(8, 32);
            this.comboBoxItemsStatusExisting.Name = "comboBoxItemsStatusExisting";
            this.comboBoxItemsStatusExisting.Size = new System.Drawing.Size(300, 21);
            this.comboBoxItemsStatusExisting.TabIndex = 3;
            // 
            // buttonItemsStatusSave
            // 
            this.buttonItemsStatusSave.Location = new System.Drawing.Point(314, 73);
            this.buttonItemsStatusSave.Name = "buttonItemsStatusSave";
            this.buttonItemsStatusSave.Size = new System.Drawing.Size(80, 21);
            this.buttonItemsStatusSave.TabIndex = 2;
            this.buttonItemsStatusSave.Text = "Save";
            this.buttonItemsStatusSave.UseVisualStyleBackColor = true;
            this.buttonItemsStatusSave.Click += new System.EventHandler(this.buttonItemsStatusSave_Click);
            // 
            // labelItemsStatusNew
            // 
            this.labelItemsStatusNew.AutoSize = true;
            this.labelItemsStatusNew.Location = new System.Drawing.Point(8, 56);
            this.labelItemsStatusNew.Name = "labelItemsStatusNew";
            this.labelItemsStatusNew.Size = new System.Drawing.Size(35, 13);
            this.labelItemsStatusNew.TabIndex = 1;
            this.labelItemsStatusNew.Text = "Name";
            // 
            // textBoxItemsStatusNew
            // 
            this.textBoxItemsStatusNew.Location = new System.Drawing.Point(8, 75);
            this.textBoxItemsStatusNew.Name = "textBoxItemsStatusNew";
            this.textBoxItemsStatusNew.Size = new System.Drawing.Size(300, 20);
            this.textBoxItemsStatusNew.TabIndex = 0;
            // 
            // tabPageOrder
            // 
            this.tabPageOrder.Controls.Add(this.groupBoxOrderCalculation);
            this.tabPageOrder.Controls.Add(this.groupBoxOrderItem);
            this.tabPageOrder.Controls.Add(this.groupBoxOrderPersonInfo);
            this.tabPageOrder.Location = new System.Drawing.Point(4, 22);
            this.tabPageOrder.Name = "tabPageOrder";
            this.tabPageOrder.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageOrder.Size = new System.Drawing.Size(992, 574);
            this.tabPageOrder.TabIndex = 2;
            this.tabPageOrder.Text = "Order";
            this.tabPageOrder.UseVisualStyleBackColor = true;
            // 
            // groupBoxOrderCalculation
            // 
            this.groupBoxOrderCalculation.Controls.Add(this.labelOrderCalculationTotalValue);
            this.groupBoxOrderCalculation.Controls.Add(this.buttonOrderCalculation);
            this.groupBoxOrderCalculation.Controls.Add(this.labelOrderCalculation);
            this.groupBoxOrderCalculation.Location = new System.Drawing.Point(644, 237);
            this.groupBoxOrderCalculation.Name = "groupBoxOrderCalculation";
            this.groupBoxOrderCalculation.Size = new System.Drawing.Size(340, 329);
            this.groupBoxOrderCalculation.TabIndex = 3;
            this.groupBoxOrderCalculation.TabStop = false;
            this.groupBoxOrderCalculation.Text = "Calculation";
            // 
            // labelOrderCalculationTotalValue
            // 
            this.labelOrderCalculationTotalValue.AutoSize = true;
            this.labelOrderCalculationTotalValue.Location = new System.Drawing.Point(164, 59);
            this.labelOrderCalculationTotalValue.Name = "labelOrderCalculationTotalValue";
            this.labelOrderCalculationTotalValue.Size = new System.Drawing.Size(0, 13);
            this.labelOrderCalculationTotalValue.TabIndex = 1;
            // 
            // buttonOrderCalculation
            // 
            this.buttonOrderCalculation.Location = new System.Drawing.Point(9, 19);
            this.buttonOrderCalculation.Name = "buttonOrderCalculation";
            this.buttonOrderCalculation.Size = new System.Drawing.Size(140, 21);
            this.buttonOrderCalculation.TabIndex = 29;
            this.buttonOrderCalculation.Text = "Calculate";
            this.buttonOrderCalculation.UseVisualStyleBackColor = true;
            // 
            // labelOrderCalculation
            // 
            this.labelOrderCalculation.AutoSize = true;
            this.labelOrderCalculation.Location = new System.Drawing.Point(6, 59);
            this.labelOrderCalculation.Name = "labelOrderCalculation";
            this.labelOrderCalculation.Size = new System.Drawing.Size(31, 13);
            this.labelOrderCalculation.TabIndex = 0;
            this.labelOrderCalculation.Text = "Total";
            // 
            // groupBoxOrderItem
            // 
            this.groupBoxOrderItem.Controls.Add(this.buttonOrderItemSave);
            this.groupBoxOrderItem.Controls.Add(this.textBoxOrderItemPostage);
            this.groupBoxOrderItem.Controls.Add(this.labelOrderItemPostage);
            this.groupBoxOrderItem.Controls.Add(this.comboBoxOrderItemStatus);
            this.groupBoxOrderItem.Controls.Add(this.checkBoxOrderItemLegalEntity);
            this.groupBoxOrderItem.Controls.Add(this.labelOrderItemStatus);
            this.groupBoxOrderItem.Controls.Add(this.labelOrderItemLegalEntity);
            this.groupBoxOrderItem.Controls.Add(this.textBoxOrderItemPriceNeto);
            this.groupBoxOrderItem.Controls.Add(this.labelOrderItemPriceNeto);
            this.groupBoxOrderItem.Controls.Add(this.textBoxOrderItemPriceGross);
            this.groupBoxOrderItem.Controls.Add(this.labelOrderItemPriceGross);
            this.groupBoxOrderItem.Controls.Add(this.textBoxOrderItemNumber);
            this.groupBoxOrderItem.Controls.Add(this.labelOrderItemCount);
            this.groupBoxOrderItem.Controls.Add(this.labelOrderItemPicture);
            this.groupBoxOrderItem.Controls.Add(this.comboBoxOrderItem);
            this.groupBoxOrderItem.Controls.Add(this.labelOrderItem);
            this.groupBoxOrderItem.Controls.Add(this.pictureBoxOrderItem);
            this.groupBoxOrderItem.Location = new System.Drawing.Point(8, 237);
            this.groupBoxOrderItem.Name = "groupBoxOrderItem";
            this.groupBoxOrderItem.Size = new System.Drawing.Size(630, 331);
            this.groupBoxOrderItem.TabIndex = 2;
            this.groupBoxOrderItem.TabStop = false;
            this.groupBoxOrderItem.Text = "Item";
            // 
            // buttonOrderItemSave
            // 
            this.buttonOrderItemSave.Location = new System.Drawing.Point(9, 264);
            this.buttonOrderItemSave.Name = "buttonOrderItemSave";
            this.buttonOrderItemSave.Size = new System.Drawing.Size(140, 21);
            this.buttonOrderItemSave.TabIndex = 30;
            this.buttonOrderItemSave.Text = "Save";
            this.buttonOrderItemSave.UseVisualStyleBackColor = true;
            // 
            // textBoxOrderItemPostage
            // 
            this.textBoxOrderItemPostage.Location = new System.Drawing.Point(9, 236);
            this.textBoxOrderItemPostage.Name = "textBoxOrderItemPostage";
            this.textBoxOrderItemPostage.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderItemPostage.TabIndex = 15;
            this.textBoxOrderItemPostage.Text = "0";
            // 
            // labelOrderItemPostage
            // 
            this.labelOrderItemPostage.AutoSize = true;
            this.labelOrderItemPostage.Location = new System.Drawing.Point(6, 219);
            this.labelOrderItemPostage.Name = "labelOrderItemPostage";
            this.labelOrderItemPostage.Size = new System.Drawing.Size(46, 13);
            this.labelOrderItemPostage.TabIndex = 14;
            this.labelOrderItemPostage.Text = "Postage";
            // 
            // comboBoxOrderItemStatus
            // 
            this.comboBoxOrderItemStatus.FormattingEnabled = true;
            this.comboBoxOrderItemStatus.Location = new System.Drawing.Point(9, 75);
            this.comboBoxOrderItemStatus.Name = "comboBoxOrderItemStatus";
            this.comboBoxOrderItemStatus.Size = new System.Drawing.Size(308, 21);
            this.comboBoxOrderItemStatus.TabIndex = 13;
            // 
            // checkBoxOrderItemLegalEntity
            // 
            this.checkBoxOrderItemLegalEntity.AutoSize = true;
            this.checkBoxOrderItemLegalEntity.Location = new System.Drawing.Point(225, 119);
            this.checkBoxOrderItemLegalEntity.Name = "checkBoxOrderItemLegalEntity";
            this.checkBoxOrderItemLegalEntity.Size = new System.Drawing.Size(15, 14);
            this.checkBoxOrderItemLegalEntity.TabIndex = 1;
            this.checkBoxOrderItemLegalEntity.UseVisualStyleBackColor = true;
            // 
            // labelOrderItemStatus
            // 
            this.labelOrderItemStatus.AutoSize = true;
            this.labelOrderItemStatus.Location = new System.Drawing.Point(6, 59);
            this.labelOrderItemStatus.Name = "labelOrderItemStatus";
            this.labelOrderItemStatus.Size = new System.Drawing.Size(37, 13);
            this.labelOrderItemStatus.TabIndex = 12;
            this.labelOrderItemStatus.Text = "Status";
            // 
            // labelOrderItemLegalEntity
            // 
            this.labelOrderItemLegalEntity.AutoSize = true;
            this.labelOrderItemLegalEntity.Location = new System.Drawing.Point(222, 99);
            this.labelOrderItemLegalEntity.Name = "labelOrderItemLegalEntity";
            this.labelOrderItemLegalEntity.Size = new System.Drawing.Size(62, 13);
            this.labelOrderItemLegalEntity.TabIndex = 0;
            this.labelOrderItemLegalEntity.Text = "Legal Entity";
            // 
            // textBoxOrderItemPriceNeto
            // 
            this.textBoxOrderItemPriceNeto.Location = new System.Drawing.Point(9, 196);
            this.textBoxOrderItemPriceNeto.Name = "textBoxOrderItemPriceNeto";
            this.textBoxOrderItemPriceNeto.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderItemPriceNeto.TabIndex = 11;
            // 
            // labelOrderItemPriceNeto
            // 
            this.labelOrderItemPriceNeto.AutoSize = true;
            this.labelOrderItemPriceNeto.Location = new System.Drawing.Point(6, 179);
            this.labelOrderItemPriceNeto.Name = "labelOrderItemPriceNeto";
            this.labelOrderItemPriceNeto.Size = new System.Drawing.Size(57, 13);
            this.labelOrderItemPriceNeto.TabIndex = 10;
            this.labelOrderItemPriceNeto.Text = "Price Neto";
            // 
            // textBoxOrderItemPriceGross
            // 
            this.textBoxOrderItemPriceGross.Location = new System.Drawing.Point(9, 156);
            this.textBoxOrderItemPriceGross.Name = "textBoxOrderItemPriceGross";
            this.textBoxOrderItemPriceGross.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderItemPriceGross.TabIndex = 9;
            // 
            // labelOrderItemPriceGross
            // 
            this.labelOrderItemPriceGross.AutoSize = true;
            this.labelOrderItemPriceGross.Location = new System.Drawing.Point(6, 139);
            this.labelOrderItemPriceGross.Name = "labelOrderItemPriceGross";
            this.labelOrderItemPriceGross.Size = new System.Drawing.Size(61, 13);
            this.labelOrderItemPriceGross.TabIndex = 8;
            this.labelOrderItemPriceGross.Text = "Price Gross";
            // 
            // textBoxOrderItemNumber
            // 
            this.textBoxOrderItemNumber.Location = new System.Drawing.Point(9, 116);
            this.textBoxOrderItemNumber.Name = "textBoxOrderItemNumber";
            this.textBoxOrderItemNumber.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderItemNumber.TabIndex = 7;
            this.textBoxOrderItemNumber.Text = "1";
            // 
            // labelOrderItemCount
            // 
            this.labelOrderItemCount.AutoSize = true;
            this.labelOrderItemCount.Location = new System.Drawing.Point(6, 99);
            this.labelOrderItemCount.Name = "labelOrderItemCount";
            this.labelOrderItemCount.Size = new System.Drawing.Size(44, 13);
            this.labelOrderItemCount.TabIndex = 6;
            this.labelOrderItemCount.Text = "Number";
            // 
            // labelOrderItemPicture
            // 
            this.labelOrderItemPicture.AutoSize = true;
            this.labelOrderItemPicture.Location = new System.Drawing.Point(320, 16);
            this.labelOrderItemPicture.Name = "labelOrderItemPicture";
            this.labelOrderItemPicture.Size = new System.Drawing.Size(40, 13);
            this.labelOrderItemPicture.TabIndex = 5;
            this.labelOrderItemPicture.Text = "Picture";
            // 
            // comboBoxOrderItem
            // 
            this.comboBoxOrderItem.FormattingEnabled = true;
            this.comboBoxOrderItem.Location = new System.Drawing.Point(9, 35);
            this.comboBoxOrderItem.Name = "comboBoxOrderItem";
            this.comboBoxOrderItem.Size = new System.Drawing.Size(308, 21);
            this.comboBoxOrderItem.TabIndex = 4;
            // 
            // labelOrderItem
            // 
            this.labelOrderItem.AutoSize = true;
            this.labelOrderItem.Location = new System.Drawing.Point(6, 19);
            this.labelOrderItem.Name = "labelOrderItem";
            this.labelOrderItem.Size = new System.Drawing.Size(27, 13);
            this.labelOrderItem.TabIndex = 1;
            this.labelOrderItem.Text = "Item";
            // 
            // pictureBoxOrderItem
            // 
            this.pictureBoxOrderItem.Location = new System.Drawing.Point(323, 35);
            this.pictureBoxOrderItem.Name = "pictureBoxOrderItem";
            this.pictureBoxOrderItem.Size = new System.Drawing.Size(250, 250);
            this.pictureBoxOrderItem.TabIndex = 0;
            this.pictureBoxOrderItem.TabStop = false;
            // 
            // groupBoxOrderPersonInfo
            // 
            this.groupBoxOrderPersonInfo.Controls.Add(this.buttonOrderSubscriberPersonInfoSelect);
            this.groupBoxOrderPersonInfo.Controls.Add(this.buttonOrderPersonInfoSave);
            this.groupBoxOrderPersonInfo.Controls.Add(this.comboBoxOrderSubscriberPersonInfo);
            this.groupBoxOrderPersonInfo.Controls.Add(this.textBoxOrderPersonInfoFaxNumber);
            this.groupBoxOrderPersonInfo.Controls.Add(this.labelOrderSubscriberPersonInfo);
            this.groupBoxOrderPersonInfo.Controls.Add(this.labelOrderPersonInfoFax);
            this.groupBoxOrderPersonInfo.Controls.Add(this.textBoxOrderPersonInfoTelephoneMobile);
            this.groupBoxOrderPersonInfo.Controls.Add(this.labelOrderPersonInfoTelephoneMobile);
            this.groupBoxOrderPersonInfo.Controls.Add(this.textBoxOrderPersonInfoTelephone);
            this.groupBoxOrderPersonInfo.Controls.Add(this.labelOrderPersonInfoTelephone);
            this.groupBoxOrderPersonInfo.Controls.Add(this.textBoxOrderPersonInfoEmail);
            this.groupBoxOrderPersonInfo.Controls.Add(this.labelOrderPersonInfoEmail);
            this.groupBoxOrderPersonInfo.Controls.Add(this.textBoxOrderPersonInfoPopstNumber);
            this.groupBoxOrderPersonInfo.Controls.Add(this.labelOrderPersonInfoPostNumber);
            this.groupBoxOrderPersonInfo.Controls.Add(this.textBoxOrderPersonInfoCity);
            this.groupBoxOrderPersonInfo.Controls.Add(this.labelOrderPersonInfoCity);
            this.groupBoxOrderPersonInfo.Controls.Add(this.textBoxOrderPersonInfoAddress);
            this.groupBoxOrderPersonInfo.Controls.Add(this.labelOrderPersonInfoAddress);
            this.groupBoxOrderPersonInfo.Controls.Add(this.textBoxOrderPersonInfoDescription);
            this.groupBoxOrderPersonInfo.Controls.Add(this.labelOrderPersonInfoDescription);
            this.groupBoxOrderPersonInfo.Controls.Add(this.textBoxOrderPersonInfoNickName);
            this.groupBoxOrderPersonInfo.Controls.Add(this.labelOrderPersonInfoNickName);
            this.groupBoxOrderPersonInfo.Controls.Add(this.textBoxOrderPersonInfoSurName);
            this.groupBoxOrderPersonInfo.Controls.Add(this.labelOrderPersonInfoSurName);
            this.groupBoxOrderPersonInfo.Controls.Add(this.textBoxOrderPersonInfoName);
            this.groupBoxOrderPersonInfo.Controls.Add(this.labelOrderPersonInfoName);
            this.groupBoxOrderPersonInfo.Location = new System.Drawing.Point(8, 6);
            this.groupBoxOrderPersonInfo.Name = "groupBoxOrderPersonInfo";
            this.groupBoxOrderPersonInfo.Size = new System.Drawing.Size(976, 225);
            this.groupBoxOrderPersonInfo.TabIndex = 1;
            this.groupBoxOrderPersonInfo.TabStop = false;
            this.groupBoxOrderPersonInfo.Text = "PersonInfo";
            // 
            // buttonOrderSubscriberPersonInfoSelect
            // 
            this.buttonOrderSubscriberPersonInfoSelect.Location = new System.Drawing.Point(645, 32);
            this.buttonOrderSubscriberPersonInfoSelect.Name = "buttonOrderSubscriberPersonInfoSelect";
            this.buttonOrderSubscriberPersonInfoSelect.Size = new System.Drawing.Size(140, 21);
            this.buttonOrderSubscriberPersonInfoSelect.TabIndex = 4;
            this.buttonOrderSubscriberPersonInfoSelect.Text = "Select";
            this.buttonOrderSubscriberPersonInfoSelect.UseVisualStyleBackColor = true;
            // 
            // buttonOrderPersonInfoSave
            // 
            this.buttonOrderPersonInfoSave.Location = new System.Drawing.Point(645, 73);
            this.buttonOrderPersonInfoSave.Name = "buttonOrderPersonInfoSave";
            this.buttonOrderPersonInfoSave.Size = new System.Drawing.Size(140, 21);
            this.buttonOrderPersonInfoSave.TabIndex = 28;
            this.buttonOrderPersonInfoSave.Text = "Save";
            this.buttonOrderPersonInfoSave.UseVisualStyleBackColor = true;
            // 
            // comboBoxOrderSubscriberPersonInfo
            // 
            this.comboBoxOrderSubscriberPersonInfo.FormattingEnabled = true;
            this.comboBoxOrderSubscriberPersonInfo.Location = new System.Drawing.Point(9, 32);
            this.comboBoxOrderSubscriberPersonInfo.Name = "comboBoxOrderSubscriberPersonInfo";
            this.comboBoxOrderSubscriberPersonInfo.Size = new System.Drawing.Size(618, 21);
            this.comboBoxOrderSubscriberPersonInfo.TabIndex = 3;
            // 
            // textBoxOrderPersonInfoFaxNumber
            // 
            this.textBoxOrderPersonInfoFaxNumber.Location = new System.Drawing.Point(428, 193);
            this.textBoxOrderPersonInfoFaxNumber.Name = "textBoxOrderPersonInfoFaxNumber";
            this.textBoxOrderPersonInfoFaxNumber.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderPersonInfoFaxNumber.TabIndex = 27;
            // 
            // labelOrderSubscriberPersonInfo
            // 
            this.labelOrderSubscriberPersonInfo.AutoSize = true;
            this.labelOrderSubscriberPersonInfo.Location = new System.Drawing.Point(6, 16);
            this.labelOrderSubscriberPersonInfo.Name = "labelOrderSubscriberPersonInfo";
            this.labelOrderSubscriberPersonInfo.Size = new System.Drawing.Size(43, 13);
            this.labelOrderSubscriberPersonInfo.TabIndex = 2;
            this.labelOrderSubscriberPersonInfo.Text = "Existing";
            // 
            // labelOrderPersonInfoFax
            // 
            this.labelOrderPersonInfoFax.AutoSize = true;
            this.labelOrderPersonInfoFax.Location = new System.Drawing.Point(425, 176);
            this.labelOrderPersonInfoFax.Name = "labelOrderPersonInfoFax";
            this.labelOrderPersonInfoFax.Size = new System.Drawing.Size(64, 13);
            this.labelOrderPersonInfoFax.TabIndex = 26;
            this.labelOrderPersonInfoFax.Text = "Fax Number";
            // 
            // textBoxOrderPersonInfoTelephoneMobile
            // 
            this.textBoxOrderPersonInfoTelephoneMobile.Location = new System.Drawing.Point(428, 153);
            this.textBoxOrderPersonInfoTelephoneMobile.Name = "textBoxOrderPersonInfoTelephoneMobile";
            this.textBoxOrderPersonInfoTelephoneMobile.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderPersonInfoTelephoneMobile.TabIndex = 25;
            // 
            // labelOrderPersonInfoTelephoneMobile
            // 
            this.labelOrderPersonInfoTelephoneMobile.AutoSize = true;
            this.labelOrderPersonInfoTelephoneMobile.Location = new System.Drawing.Point(425, 136);
            this.labelOrderPersonInfoTelephoneMobile.Name = "labelOrderPersonInfoTelephoneMobile";
            this.labelOrderPersonInfoTelephoneMobile.Size = new System.Drawing.Size(92, 13);
            this.labelOrderPersonInfoTelephoneMobile.TabIndex = 24;
            this.labelOrderPersonInfoTelephoneMobile.Text = "Mobile Telephone";
            // 
            // textBoxOrderPersonInfoTelephone
            // 
            this.textBoxOrderPersonInfoTelephone.Location = new System.Drawing.Point(428, 113);
            this.textBoxOrderPersonInfoTelephone.Name = "textBoxOrderPersonInfoTelephone";
            this.textBoxOrderPersonInfoTelephone.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderPersonInfoTelephone.TabIndex = 23;
            // 
            // labelOrderPersonInfoTelephone
            // 
            this.labelOrderPersonInfoTelephone.AutoSize = true;
            this.labelOrderPersonInfoTelephone.Location = new System.Drawing.Point(425, 96);
            this.labelOrderPersonInfoTelephone.Name = "labelOrderPersonInfoTelephone";
            this.labelOrderPersonInfoTelephone.Size = new System.Drawing.Size(58, 13);
            this.labelOrderPersonInfoTelephone.TabIndex = 22;
            this.labelOrderPersonInfoTelephone.Text = "Telephone";
            // 
            // textBoxOrderPersonInfoEmail
            // 
            this.textBoxOrderPersonInfoEmail.Location = new System.Drawing.Point(427, 73);
            this.textBoxOrderPersonInfoEmail.Name = "textBoxOrderPersonInfoEmail";
            this.textBoxOrderPersonInfoEmail.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderPersonInfoEmail.TabIndex = 21;
            // 
            // labelOrderPersonInfoEmail
            // 
            this.labelOrderPersonInfoEmail.AutoSize = true;
            this.labelOrderPersonInfoEmail.Location = new System.Drawing.Point(424, 56);
            this.labelOrderPersonInfoEmail.Name = "labelOrderPersonInfoEmail";
            this.labelOrderPersonInfoEmail.Size = new System.Drawing.Size(32, 13);
            this.labelOrderPersonInfoEmail.TabIndex = 20;
            this.labelOrderPersonInfoEmail.Text = "Email";
            // 
            // textBoxOrderPersonInfoPopstNumber
            // 
            this.textBoxOrderPersonInfoPopstNumber.Location = new System.Drawing.Point(219, 153);
            this.textBoxOrderPersonInfoPopstNumber.Name = "textBoxOrderPersonInfoPopstNumber";
            this.textBoxOrderPersonInfoPopstNumber.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderPersonInfoPopstNumber.TabIndex = 15;
            // 
            // labelOrderPersonInfoPostNumber
            // 
            this.labelOrderPersonInfoPostNumber.AutoSize = true;
            this.labelOrderPersonInfoPostNumber.Location = new System.Drawing.Point(216, 136);
            this.labelOrderPersonInfoPostNumber.Name = "labelOrderPersonInfoPostNumber";
            this.labelOrderPersonInfoPostNumber.Size = new System.Drawing.Size(68, 13);
            this.labelOrderPersonInfoPostNumber.TabIndex = 14;
            this.labelOrderPersonInfoPostNumber.Text = "Post Number";
            // 
            // textBoxOrderPersonInfoCity
            // 
            this.textBoxOrderPersonInfoCity.Location = new System.Drawing.Point(219, 113);
            this.textBoxOrderPersonInfoCity.Name = "textBoxOrderPersonInfoCity";
            this.textBoxOrderPersonInfoCity.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderPersonInfoCity.TabIndex = 13;
            // 
            // labelOrderPersonInfoCity
            // 
            this.labelOrderPersonInfoCity.AutoSize = true;
            this.labelOrderPersonInfoCity.Location = new System.Drawing.Point(216, 96);
            this.labelOrderPersonInfoCity.Name = "labelOrderPersonInfoCity";
            this.labelOrderPersonInfoCity.Size = new System.Drawing.Size(24, 13);
            this.labelOrderPersonInfoCity.TabIndex = 12;
            this.labelOrderPersonInfoCity.Text = "City";
            // 
            // textBoxOrderPersonInfoAddress
            // 
            this.textBoxOrderPersonInfoAddress.Location = new System.Drawing.Point(219, 73);
            this.textBoxOrderPersonInfoAddress.Name = "textBoxOrderPersonInfoAddress";
            this.textBoxOrderPersonInfoAddress.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderPersonInfoAddress.TabIndex = 11;
            // 
            // labelOrderPersonInfoAddress
            // 
            this.labelOrderPersonInfoAddress.AutoSize = true;
            this.labelOrderPersonInfoAddress.Location = new System.Drawing.Point(216, 56);
            this.labelOrderPersonInfoAddress.Name = "labelOrderPersonInfoAddress";
            this.labelOrderPersonInfoAddress.Size = new System.Drawing.Size(45, 13);
            this.labelOrderPersonInfoAddress.TabIndex = 10;
            this.labelOrderPersonInfoAddress.Text = "Address";
            // 
            // textBoxOrderPersonInfoDescription
            // 
            this.textBoxOrderPersonInfoDescription.Location = new System.Drawing.Point(9, 193);
            this.textBoxOrderPersonInfoDescription.Name = "textBoxOrderPersonInfoDescription";
            this.textBoxOrderPersonInfoDescription.Size = new System.Drawing.Size(410, 20);
            this.textBoxOrderPersonInfoDescription.TabIndex = 7;
            // 
            // labelOrderPersonInfoDescription
            // 
            this.labelOrderPersonInfoDescription.AutoSize = true;
            this.labelOrderPersonInfoDescription.Location = new System.Drawing.Point(6, 176);
            this.labelOrderPersonInfoDescription.Name = "labelOrderPersonInfoDescription";
            this.labelOrderPersonInfoDescription.Size = new System.Drawing.Size(60, 13);
            this.labelOrderPersonInfoDescription.TabIndex = 6;
            this.labelOrderPersonInfoDescription.Text = "Description";
            // 
            // textBoxOrderPersonInfoNickName
            // 
            this.textBoxOrderPersonInfoNickName.Location = new System.Drawing.Point(9, 153);
            this.textBoxOrderPersonInfoNickName.Name = "textBoxOrderPersonInfoNickName";
            this.textBoxOrderPersonInfoNickName.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderPersonInfoNickName.TabIndex = 5;
            // 
            // labelOrderPersonInfoNickName
            // 
            this.labelOrderPersonInfoNickName.AutoSize = true;
            this.labelOrderPersonInfoNickName.Location = new System.Drawing.Point(6, 136);
            this.labelOrderPersonInfoNickName.Name = "labelOrderPersonInfoNickName";
            this.labelOrderPersonInfoNickName.Size = new System.Drawing.Size(55, 13);
            this.labelOrderPersonInfoNickName.TabIndex = 4;
            this.labelOrderPersonInfoNickName.Text = "Nickname";
            // 
            // textBoxOrderPersonInfoSurName
            // 
            this.textBoxOrderPersonInfoSurName.Location = new System.Drawing.Point(9, 113);
            this.textBoxOrderPersonInfoSurName.Name = "textBoxOrderPersonInfoSurName";
            this.textBoxOrderPersonInfoSurName.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderPersonInfoSurName.TabIndex = 3;
            // 
            // labelOrderPersonInfoSurName
            // 
            this.labelOrderPersonInfoSurName.AutoSize = true;
            this.labelOrderPersonInfoSurName.Location = new System.Drawing.Point(6, 96);
            this.labelOrderPersonInfoSurName.Name = "labelOrderPersonInfoSurName";
            this.labelOrderPersonInfoSurName.Size = new System.Drawing.Size(49, 13);
            this.labelOrderPersonInfoSurName.TabIndex = 2;
            this.labelOrderPersonInfoSurName.Text = "Surname";
            // 
            // textBoxOrderPersonInfoName
            // 
            this.textBoxOrderPersonInfoName.Location = new System.Drawing.Point(9, 73);
            this.textBoxOrderPersonInfoName.Name = "textBoxOrderPersonInfoName";
            this.textBoxOrderPersonInfoName.Size = new System.Drawing.Size(200, 20);
            this.textBoxOrderPersonInfoName.TabIndex = 1;
            // 
            // labelOrderPersonInfoName
            // 
            this.labelOrderPersonInfoName.AutoSize = true;
            this.labelOrderPersonInfoName.Location = new System.Drawing.Point(6, 56);
            this.labelOrderPersonInfoName.Name = "labelOrderPersonInfoName";
            this.labelOrderPersonInfoName.Size = new System.Drawing.Size(35, 13);
            this.labelOrderPersonInfoName.TabIndex = 0;
            this.labelOrderPersonInfoName.Text = "Name";
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
            this.tabPageItems.ResumeLayout(false);
            this.groupBoxItems.ResumeLayout(false);
            this.groupBoxItems.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxItems)).EndInit();
            this.groupBoxItemsType.ResumeLayout(false);
            this.groupBoxItemsType.PerformLayout();
            this.groupBoxItemsStatus.ResumeLayout(false);
            this.groupBoxItemsStatus.PerformLayout();
            this.tabPageOrder.ResumeLayout(false);
            this.groupBoxOrderCalculation.ResumeLayout(false);
            this.groupBoxOrderCalculation.PerformLayout();
            this.groupBoxOrderItem.ResumeLayout(false);
            this.groupBoxOrderItem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxOrderItem)).EndInit();
            this.groupBoxOrderPersonInfo.ResumeLayout(false);
            this.groupBoxOrderPersonInfo.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage tabPageItems;
        private System.Windows.Forms.GroupBox groupBoxItemsStatus;
        private System.Windows.Forms.Label labelItemsStatusNew;
        private System.Windows.Forms.TextBox textBoxItemsStatusNew;
        private System.Windows.Forms.Button buttonItemsStatusSave;
        private System.Windows.Forms.Label labelItemsStatusExisting;
        private System.Windows.Forms.ComboBox comboBoxItemsStatusExisting;
        private System.Windows.Forms.GroupBox groupBoxItemsType;
        private System.Windows.Forms.Label labelItemsTypeExisting;
        private System.Windows.Forms.ComboBox comboBoxItemsTypeExisting;
        private System.Windows.Forms.Button buttonItemsTypeSave;
        private System.Windows.Forms.Label labelItemsTypeNew;
        private System.Windows.Forms.TextBox textBoxItemsTypeNew;
        private System.Windows.Forms.GroupBox groupBoxItems;
        private System.Windows.Forms.Button buttonItemsSave;
        private System.Windows.Forms.Label labelItemsNew;
        private System.Windows.Forms.TextBox textBoxItemsNew;
        private System.Windows.Forms.Label labelItemsType;
        private System.Windows.Forms.ListBox listBoxItems;
        private System.Windows.Forms.TabPage tabPageOrder;
        private System.Windows.Forms.TabPage tabPageReports;
        private System.Windows.Forms.GroupBox groupBoxOrderPersonInfo;
        private System.Windows.Forms.Label labelOrderItemLegalEntity;
        private System.Windows.Forms.CheckBox checkBoxOrderItemLegalEntity;
        private System.Windows.Forms.GroupBox groupBoxOrderItem;
        private System.Windows.Forms.ComboBox comboBoxOrderSubscriberPersonInfo;
        private System.Windows.Forms.Label labelOrderSubscriberPersonInfo;
        private System.Windows.Forms.GroupBox groupBoxOrderCalculation;
        private System.Windows.Forms.Button buttonOrderSubscriberPersonInfoSelect;
        private System.Windows.Forms.Button buttonItemsSelect;
        private System.Windows.Forms.Label labelItemsItemType;
        private System.Windows.Forms.ComboBox comboBoxItemsItemType;
        private System.Windows.Forms.Button buttonItemsTypeSelect;
        private System.Windows.Forms.Button buttonItemsStatusSelect;
        private System.Windows.Forms.Button buttonItemsPictureBoxSelect;
        private System.Windows.Forms.PictureBox pictureBoxItems;
        private System.Windows.Forms.TextBox textBoxItemsImage;
        private System.Windows.Forms.Label labelItemsImage;
        private System.Windows.Forms.TextBox textBoxOrderPersonInfoName;
        private System.Windows.Forms.Label labelOrderPersonInfoName;
        private System.Windows.Forms.TextBox textBoxOrderPersonInfoDescription;
        private System.Windows.Forms.Label labelOrderPersonInfoDescription;
        private System.Windows.Forms.TextBox textBoxOrderPersonInfoNickName;
        private System.Windows.Forms.Label labelOrderPersonInfoNickName;
        private System.Windows.Forms.TextBox textBoxOrderPersonInfoSurName;
        private System.Windows.Forms.Label labelOrderPersonInfoSurName;
        private System.Windows.Forms.TextBox textBoxOrderPersonInfoPopstNumber;
        private System.Windows.Forms.Label labelOrderPersonInfoPostNumber;
        private System.Windows.Forms.TextBox textBoxOrderPersonInfoCity;
        private System.Windows.Forms.Label labelOrderPersonInfoCity;
        private System.Windows.Forms.TextBox textBoxOrderPersonInfoAddress;
        private System.Windows.Forms.Label labelOrderPersonInfoAddress;
        private System.Windows.Forms.TextBox textBoxOrderPersonInfoFaxNumber;
        private System.Windows.Forms.Label labelOrderPersonInfoFax;
        private System.Windows.Forms.TextBox textBoxOrderPersonInfoTelephoneMobile;
        private System.Windows.Forms.Label labelOrderPersonInfoTelephoneMobile;
        private System.Windows.Forms.TextBox textBoxOrderPersonInfoTelephone;
        private System.Windows.Forms.Label labelOrderPersonInfoTelephone;
        private System.Windows.Forms.TextBox textBoxOrderPersonInfoEmail;
        private System.Windows.Forms.Label labelOrderPersonInfoEmail;
        private System.Windows.Forms.Button buttonOrderPersonInfoSave;
        private System.Windows.Forms.PictureBox pictureBoxOrderItem;
        private System.Windows.Forms.ComboBox comboBoxOrderItemStatus;
        private System.Windows.Forms.Label labelOrderItemStatus;
        private System.Windows.Forms.TextBox textBoxOrderItemPriceNeto;
        private System.Windows.Forms.Label labelOrderItemPriceNeto;
        private System.Windows.Forms.TextBox textBoxOrderItemPriceGross;
        private System.Windows.Forms.Label labelOrderItemPriceGross;
        private System.Windows.Forms.TextBox textBoxOrderItemNumber;
        private System.Windows.Forms.Label labelOrderItemCount;
        private System.Windows.Forms.Label labelOrderItemPicture;
        private System.Windows.Forms.ComboBox comboBoxOrderItem;
        private System.Windows.Forms.Label labelOrderItem;
        private System.Windows.Forms.TextBox textBoxOrderItemPostage;
        private System.Windows.Forms.Label labelOrderItemPostage;
        private System.Windows.Forms.Label labelOrderCalculationTotalValue;
        private System.Windows.Forms.Label labelOrderCalculation;
        private System.Windows.Forms.Button buttonOrderItemSave;
        private System.Windows.Forms.Button buttonOrderCalculation;
    }
}

