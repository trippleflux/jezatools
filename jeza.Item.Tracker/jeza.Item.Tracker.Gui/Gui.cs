using System;
using System.Collections.Generic;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using Equin.ApplicationFramework;
using jeza.Item.Tracker.Settings;
using NLog;
using PdfSharp;
using PdfSharp.Forms;

namespace jeza.Item.Tracker.Gui
{
    public partial class Gui : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly DataBase dataBase = new DataBase();

        public Gui()
        {
            InitializeComponent();
            
            pagePreviewExport.PageSize = PageSizeConverter.ToSize(PageSize.A4);
            renderer = new Renderer();

            FillItemTypes();
            FillItemStatus();
            FillItems();
            FillPersonInfo();
            FillBank();
            FillOrders();
            FillLanguage();
        }

        private void FillLanguage()
        {
            try
            {
                XmlSerialization xmlSerialization = new XmlSerialization();
                Settings.Settings settings = xmlSerialization.Deserialize(new Settings.Settings(), "settings.xml");
                string setting = ConfigurationManager.AppSettings["language"];
                language = settings.Languages.Find(l => l.Culture.Equals(setting)) ?? Misc.GetLanguageSlovenian();
                //Orders
                TabOrders tabOrders = language.TabOrders;
                tabPageOrders.Text = tabOrders.Name;
                labelOrdersPersonInfo.Text = tabOrders.LabelOrdersPersonInfo;
                labelOrdersItemType.Text = tabOrders.LabelOrdersItemType;
                labelOrdersItem.Text = tabOrders.LabelOrdersItem;
                labelOrdersItemStatus.Text = tabOrders.LabelOrdersItemStatus;
                labelOrdersItemCount.Text = tabOrders.LabelOrdersItemCount;
                labelOrdersPrice.Text = tabOrders.LabelOrdersPrice;
                labelOrdersPostage.Text = tabOrders.LabelOrdersPostage;
                labelOrdersTax.Text = tabOrders.LabelOrdersTax;
                labelOrdersLegalEntity.Text = tabOrders.LabelOrdersLegalEntity;
                labelOrdersPicture.Text = tabOrders.LabelOrdersPicture;
                //groupBoxOrders.Text = tabOrders.
                groupBoxOrdersList.Text = tabOrders.LabelOrdersList;
                buttonOrdersSum.Text = tabOrders.ButtonOrdersSum;
                buttonOrdersSave.Text = tabOrders.ButtonOrdersSave;
                buttonOrdersUpdate.Text = tabOrders.ButtonOrdersUpdate;
                buttonOrdersDelete.Text = tabOrders.ButtonOrdersDelete;
                //Items
                TabItems tabItems = language.TabItems;
                tabPageItems.Text = tabItems.Name;
                labelItemsName.Text = tabItems.LabelItemsName;
                labelItemsDescription.Text = tabItems.LabelItemsDescription;
                labelItemsType.Text = tabItems.LabelItemsType;
                //labelItemsImage.Text = tabItems.LabelItemsImage;
                groupBoxItemsList.Text = tabItems.LabelItemsList;
                buttonItemsPictureBoxSelect.Text = tabItems.ButtonItemsPictureBoxSelect;
                buttonItemsSave.Text = tabItems.ButtonItemsSave;
                buttonItemsUpdate.Text = tabItems.ButtonItemsUpdate;
                buttonItemsDelete.Text = tabItems.ButtonItemsDelete;
                //Item Type
                TabItemTypes tabItemTypes = language.TabItemTypes;
                tabPageItemType.Text = tabItemTypes.Name;
                labelItemTypeName.Text = tabItemTypes.LabelItemTypeName;
                labelItemTypeDescription.Text = tabItemTypes.LabelItemTypeDescription;
                groupBoxItemTypeList.Text = tabItemTypes.LabelItemTypeList;
                buttonItemTypeSave.Text = tabItemTypes.ButtonItemTypeListSave;
                buttonItemTypeUpdate.Text = tabItemTypes.ButtonItemTypeListUpdate;
                buttonItemTypeDelete.Text = tabItemTypes.ButtonItemTypeListDelete;
                //Item Status
                TabItemStatus tabItemStatus = language.TabItemStatus;
                tabPageItemStatus.Text = tabItemStatus.Name;
                labelItemStatusName.Text = tabItemStatus.LabelItemsStatusName;
                labelItemStatusDescription.Text = tabItemStatus.LabelItemStatusDescription;
                labelItemStatusList.Text = tabItemStatus.LabelItemStatusList;
                buttonItemStatusSave.Text = tabItemStatus.ButtonItemStatusSave;
                buttonItemStatusUpdate.Text = tabItemStatus.ButtonItemStatusUpdate;
                buttonItemStatusDelete.Text = tabItemStatus.ButtonItemStatusDelete;
                //Person Info
                TabPersonInfo tabPersonInfo = language.TabPersonInfo;
                tabPagePersonInfo.Text = tabPersonInfo.Name;
                labelPersonInfoName.Text = tabPersonInfo.LabelPersonInfoName;
                labelPersonInfoSurName.Text = tabPersonInfo.LabelPersonInfoSurName;
                labelPersonInfoNickName.Text = tabPersonInfo.LabelPersonInfoNickName;
                labelPersonInfoDescription.Text = tabPersonInfo.LabelPersonInfoDescription;
                labelPersonInfoAddress.Text = tabPersonInfo.LabelPersonInfoAddress;
                labelPersonInfoCity.Text = tabPersonInfo.LabelPersonInfoCity;
                labelPersonInfoPostNumber.Text = tabPersonInfo.LabelPersonInfoPostNumber;
                labelPersonInfoEmail.Text = tabPersonInfo.LabelPersonInfoEmail;
                labelPersonInfoTelephone.Text = tabPersonInfo.LabelPersonInfoTelephone;
                labelPersonInfoTelephoneMobile.Text = tabPersonInfo.LabelPersonInfoTelephoneMobile;
                labelPersonInfoFax.Text = tabPersonInfo.LabelPersonInfoFax;
                groupBoxPersonInfoList.Text = tabPersonInfo.LabelPersonInfoList;
                buttonPersonInfoSave.Text = tabPersonInfo.ButtonPersonInfoSave;
                buttonPersonInfoUpdate.Text = tabPersonInfo.ButtonPersonInfoUpdate;
                buttonPersonInfoDelete.Text = tabPersonInfo.ButtonPersonInfoDelete;
                //Reports
                tabPageReports.Text = language.TabReports.Name;
                //Bank
                TabBank tabBank = language.TabBank;
                tabPageBank.Text = tabBank.Name;
                labelBankName.Text = tabBank.LabelBankName;
                labelBankOwner.Text = tabBank.LabelBankOwner;
                labelBankAccountNumber.Text = tabBank.LabelBankAccountNumber;
                labelBankList.Text = tabBank.LabelBankList;
                buttonBankSave.Text = tabBank.ButtonBankSave;
                buttonBankDelete.Text = tabBank.ButtonBankDelete;
                buttonBankUpdate.Text = tabBank.ButtonBankUpdate;
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
            }
        }

        private void FillBank()
        {
            Logger.Debug("Fill bank");
            List<Bank> list = dataBase.BankGetAll();
            comboBoxOrdersBank.Items.Clear();
            if (list == null)
            {
                return;
            }
            //Bank tab
            dataGridViewBank.DataSource = list;
            //Order tab
            comboBoxOrdersBank.Items.AddRange(list.ToArray());
            comboBoxOrdersBank.SelectedItem = comboBoxOrdersBank.Items[0];
        }

        private void FillOrders()
        {
            Logger.Debug("Fill orders");
            comboBoxExportErders.Items.Clear();
            List<Order> list = dataBase.OrderGetAll();
            if (list == null)
            {
                return;
            }
            //Order tab
            dataGridViewOrders.DataSource = list;
            //export tab
            comboBoxExportErders.Items.AddRange(list.ToArray());
            comboBoxExportErders.SelectedItem = comboBoxExportErders.Items[0];
        }

        private void FillPersonInfo()
        {
            Logger.Debug("Fill person info");
            comboBoxOrdersPersonInfo.Items.Clear();
            List<PersonInfo> list = dataBase.PersonInfoGetAll();
            if (list == null)
            {
                return;
            }
            //Order tab
            comboBoxOrdersPersonInfo.Items.AddRange(list.ToArray());
            comboBoxOrdersPersonInfo.SelectedItem = comboBoxOrdersPersonInfo.Items[0];
            //PersonInfo tab
            dataGridViewPersonInfo.DataSource = list;
        }

        private void FillItems()
        {
            Logger.Debug("Fill Items");
            List<Item> items = dataBase.ItemGetAll();
            if (items == null)
            {
                return;
            }
            BindingListView<Item> view = new BindingListView<Item>(items);
            dataGridViewItems.DataSource = view;
            textBoxItemsFilter.TextChanged += delegate
                                              {
                                                  view.ApplyFilter(item => item.Name.Contains(textBoxItemsFilter.Text));
                                              };
        }

        private void FillItemTypes()
        {
            Logger.Info("Fill Item Types...");
            comboBoxOrdersItemType.Items.Clear();
            comboBoxItemsType.Items.Clear();
            //listBoxItemTypeList.Items.Clear();
            List<ItemType> itemTypes = dataBase.ItemTypeGetAll();
            if (itemTypes == null)
            {
                Logger.Warn("ItemTypes is empty");
                return;
            }
            //order tab
            comboBoxOrdersItemType.Items.AddRange(itemTypes.ToArray());
            comboBoxOrdersItemType.SelectedItem = comboBoxOrdersItemType.Items[0];
            FillOrderItems(itemTypes[0]);
            //items tab
            comboBoxItemsType.Items.AddRange(itemTypes.ToArray());
            comboBoxItemsType.SelectedItem = comboBoxItemsType.Items[0];
            //item type tab
            //listBoxItemTypeList.Items.AddRange(itemTypes.ToArray());
            dataGridViewItemType.DataSource = itemTypes;
        }

        private void FillItemStatus()
        {
            Logger.Debug("Fill Item Status");
            comboBoxOrdersItemStatus.Items.Clear();
            List<ItemStatus> list = dataBase.ItemStatusGetAll();
            if (list == null)
            {
                return;
            }
            //Order tab
            comboBoxOrdersItemStatus.Items.AddRange(list.ToArray());
            comboBoxOrdersItemStatus.SelectedItem = comboBoxOrdersItemStatus.Items[0];
            //Item Status tab
            dataGridViewItemStatus.DataSource = list;
        }

        private void ButtonItemsSaveClick
            (object sender,
             EventArgs e)
        {
            if (buttonItemsSave.Text == language.TabItems.ButtonItemsNew)
            {
                ClearItems();
                return;
            }
            Logger.Info("Save item...");
            try
            {
                if (textBoxItemsName.Text.Length > 1)
                {
                    Item item = new Item
                                {
                                    Name = textBoxItemsName.Text.Trim(),
                                    Description = textBoxItemsDescription.Text.Trim(),
                                    Price = textBoxItemsPrice.Text.Trim().String2Decimal(),
                                };
                    Item existingItem = dataBase.ItemGet(item.Name);
                    if (existingItem != null)
                    {
                        MessageBox.Show(@"Item with that name already exists!", @"Warn", MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                        return;
                    }
                    ItemType selectedItem = (ItemType) comboBoxItemsType.SelectedItem;
                    if (selectedItem != null)
                    {
                        item.ItemTypeId = selectedItem.Id;
                    }
                    if (pictureBoxItems.Image == null)
                    {
                        item.Image = new byte[] {};
                    }
                    else
                    {
                        MemoryStream memoryStream = new MemoryStream();
                        pictureBoxItems.Image.Save(memoryStream, ImageFormat.Jpeg);
                        item.Image = memoryStream.ToArray();
                    }
                    int rowsInserted = dataBase.ItemInsert(item);
                    if (rowsInserted < 1)
                    {
                        MessageBox.Show(@"Failed to insert Item!", @"Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        FillItems();
                        ClearItems();
                    }
                }
                else
                {
                    MessageBox.Show(@"Insert Items Name!", @"Info", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ClearItems()
        {
            Logger.Debug("ClearItems");
            EnableItemsSaveButton();
            textBoxItemsName.Text = String.Empty;
            textBoxItemsDescription.Text = String.Empty;
            textBoxItemsPrice.Text = String.Empty;
            pictureBoxItems.Image = new Bitmap(1, 1);
            SetItemId(-1);
        }

        private void ButtonItemTypeSaveClick
            (object sender,
             EventArgs e)
        {
            if (buttonItemTypeSave.Text == language.TabItemTypes.ButtonItemTypeListNew)
            {
                ClearItemType();
                return;
            }
            Logger.Info("Save item type...");
            try
            {
                if (textBoxItemTypeName.Text.Length > 1)
                {
                    ItemType itemType = new ItemType
                                        {
                                            Name = textBoxItemTypeName.Text,
                                            Description = textBoxItemTypeDescription.Text
                                        };
                    ItemType existingItemType = dataBase.ItemTypeGet(itemType.Name);
                    if (existingItemType != null)
                    {
                        const string text = @"ItemType with that name already exists!";
                        Logger.Warn(text);
                        MessageBox.Show(text, @"Warn", MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                        return;
                    }
                    int rowsUpdated = dataBase.ItemTypeInsert(itemType);
                    if (rowsUpdated < 1)
                    {
                        const string text = @"Failed to insert Item type!";
                        Logger.Error(text);
                        MessageBox.Show(text, @"Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        FillItemTypes();
                        ClearItemType();
                    }
                }
                else
                {
                    const string text = @"Insert ItemType Name!";
                    Logger.Info(text);
                    MessageBox.Show(text, @"Info", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ClearItemType()
        {
            Logger.Debug("ClearItemType");
            EnableItemTypeSaveButton();
            textBoxItemTypeName.Text = String.Empty;
            textBoxItemTypeDescription.Text = String.Empty;
            SetItemTypeId(-1);
        }

        private static void ShowError(Exception exception)
        {
            Logger.Error(exception.ToString);
            MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ButtonItemsPictureBoxSelectClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Select image...");
            try
            {
                OpenFileDialog open = new OpenFileDialog
                                      {
                                          Filter =
                                              @"Image Files(*.jpg; *.jpeg)|*.jpg; *.jpeg"
                                      };
                if (open.ShowDialog() == DialogResult.OK)
                {
                    pictureBoxItems.SizeMode = PictureBoxSizeMode.StretchImage;
                    Bitmap bitmap = new Bitmap(open.FileName);
                    pictureBoxItems.Image = bitmap;
                    Logger.Debug("Selected image is '{0}'", open.FileName);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void SetItemStatusId(int itemStatusId)
        {
            labelItemStatusId.Text = itemStatusId.ToString();
        }

        private void SetItemTypeId(int itemId)
        {
            labelItemTypeId.Text = itemId.ToString();
        }

        private void SetPersonInfoId(int personInfoId)
        {
            labelPersonInfoId.Text = personInfoId.ToString();
        }

        private void SetItemId(int itemId)
        {
            labelItemsId.Text = itemId.ToString();
        }

        private void SetOrderId(int orderId)
        {
            labelOrdersId.Text = orderId.ToString();
        }

        private void SetBankId(int bankId)
        {
            labelBankId.Text = bankId.ToString();
        }

        private void ButtonItemsStatusSaveClick
            (object sender,
             EventArgs e)
        {
            if (buttonItemStatusSave.Text == language.TabItemStatus.ButtonItemStatusNew)
            {
                ClearItemStatus();
                return;
            }
            Logger.Info("Save item status...");
            try
            {
                if (textBoxItemStatusName.Text.Length > 1)
                {
                    ItemStatus itemStatus = new ItemStatus
                                            {
                                                Name = textBoxItemStatusName.Text.Trim(),
                                                Description = textBoxItemStatusDescription.Text.Trim(),
                                            };
                    ItemStatus existingItemStatus = dataBase.ItemStatusGet(itemStatus.Name);
                    if (existingItemStatus != null)
                    {
                        MessageBox.Show(@"ItemStatus with that name already exists!", @"Warn", MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                        return;
                    }
                    int rowsUpdated = dataBase.ItemStatusInsert(itemStatus);
                    if (rowsUpdated < 1)
                    {
                        MessageBox.Show(@"Failed to insert Item status!", @"Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        FillItemStatus();
                        ClearItemStatus();
                    }
                }
                else
                {
                    MessageBox.Show(@"Insert ItemStatus Name!", @"Info", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ClearItemStatus()
        {
            Logger.Debug("ClearItemStatus");
            textBoxItemStatusName.Text = String.Empty;
            textBoxItemStatusDescription.Text = String.Empty;
            SetItemStatusId(-1);
            EnableItemStatusSaveButton();
        }

        private void ClearBank()
        {
            Logger.Debug("ClearBank");
            textBoxBankAccountNumber.Text = String.Empty;
            textBoxBankName.Text = String.Empty;
            textBoxBankOwner.Text = String.Empty;
            SetBankId(-1);
            EnableBankSaveButton();
        }

        private void ButtonItemStatusUpdateClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Update Item Status...");
            int itemStatusId = Misc.String2Number(labelItemStatusId.Text);
            if (itemStatusId > -1)
            {
                ItemStatus itemStatus = new ItemStatus
                                        {
                                            Id = itemStatusId,
                                            Name = textBoxItemStatusName.Text,
                                            Description = textBoxItemStatusDescription.Text
                                        };
                int rowsUpdated = dataBase.ItemStatusUpdate(itemStatus);
                if (rowsUpdated < 1)
                {
                    MessageBox.Show(@"Failed to update Item Status!", @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    ClearItemStatus();
                }
                FillItemStatus();
            }
            else
            {
                MessageBox.Show(@"Select Item Status!", @"Info", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void ButtonItemStatusDeleteClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Delete Item Status...");
            int itemStatusId = Misc.String2Number(labelItemStatusId.Text);
            if (itemStatusId > -1)
            {
                int rowsUpdated = dataBase.ItemStatusDelete(itemStatusId);
                if (rowsUpdated < 1)
                {
                    MessageBox.Show(@"Failed to delete Item Status!", @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    ClearItemStatus();
                }
                FillItemStatus();
            }
            else
            {
                MessageBox.Show(@"Select Item Status!", @"Info", MessageBoxButtons.OK,
                                MessageBoxIcon.Information);
            }
        }

        private void ButtonItemsUpdateClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Update Item...");
            int itemId = Misc.String2Number(labelItemsId.Text);
            if (itemId > -1)
            {
                Item item = new Item
                            {
                                Id = itemId,
                                Name = textBoxItemsName.Text,
                                Description = textBoxItemsDescription.Text,
                                Price = textBoxItemsPrice.Text.Trim().String2Decimal(),
                            };
                ItemType selectedItem = (ItemType) comboBoxItemsType.SelectedItem;
                if (selectedItem != null)
                {
                    item.ItemTypeId = selectedItem.Id;
                }
                if (pictureBoxItems.Image == null)
                {
                    item.Image = new byte[] {};
                }
                else
                {
                    MemoryStream memoryStream = new MemoryStream();
                    pictureBoxItems.Image.Save(memoryStream, ImageFormat.Jpeg);
                    item.Image = memoryStream.ToArray();
                }
                int rowsUpdated = dataBase.ItemUpdate(item);
                if (rowsUpdated < 1)
                {
                    MessageBox.Show(@"Failed to update Item!", @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    ClearItems();
                }
                FillItems();
            }
            else
            {
                MessageBox.Show(@"Failed to update Item!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void EnablePersonInfoSaveButton()
        {
            Logger.Info("EnablePersonInfoSaveButton");
            ChangePersonInfoButtonStatus(true);
        }

        private void DisablePersonInfoSaveButton()
        {
            Logger.Info("DisablePersonInfoSaveButton");
            ChangePersonInfoButtonStatus(false);
        }

        private void EnableItemsSaveButton()
        {
            Logger.Info("EnableItemsSaveButton");
            ChangeItemsButtonStatus(true);
        }

        private void DisableItemsSaveButton()
        {
            Logger.Info("DisableItemsSaveButton");
            ChangeItemsButtonStatus(false);
        }

        private void EnableOrdersSaveButton()
        {
            Logger.Info("EnableOrdersSaveButton");
            ChangeOrdersButtonStatus(true);
        }

        private void DisableOrdersSaveButton()
        {
            Logger.Info("DisableOrdersSaveButton");
            ChangeOrdersButtonStatus(false);
        }

        private void EnableBankSaveButton()
        {
            Logger.Info("EnableBankSaveButton");
            ChangeBankButtonStatus(true);
        }

        private void DisableBankSaveButton()
        {
            Logger.Info("DisableBankSaveButton");
            ChangeBankButtonStatus(false);
        }

        private void EnableItemTypeSaveButton()
        {
            Logger.Info("EnableItemTypeSaveButton");
            ChangeItemTypeButtonStatus(true);
        }

        private void DisableItemTypeSaveButton()
        {
            Logger.Info("DisableItemTypeSaveButton");
            ChangeItemTypeButtonStatus(false);
        }

        private void EnableItemStatusSaveButton()
        {
            Logger.Info("EnableItemStatusSaveButton");
            ChangeItemStatusButtonStatus(true);
        }

        private void DisableItemStatusSaveButton()
        {
            Logger.Info("DisableItemStatusSaveButton");
            ChangeItemStatusButtonStatus(false);
        }

        private void ChangePersonInfoButtonStatus(bool enabled)
        {
            buttonPersonInfoSave.Text = enabled
                                            ? language.TabPersonInfo.ButtonPersonInfoSave
                                            : language.TabPersonInfo.ButtonPersonInfoNew;
            buttonPersonInfoUpdate.Enabled = !enabled;
            buttonPersonInfoDelete.Enabled = !enabled;
        }

        private void ChangeItemStatusButtonStatus(bool enabled)
        {
            buttonItemStatusSave.Text = enabled
                                            ? language.TabItemStatus.ButtonItemStatusSave
                                            : language.TabItemStatus.ButtonItemStatusNew;
            buttonItemStatusUpdate.Enabled = !enabled;
            buttonItemStatusDelete.Enabled = !enabled;
        }

        private void ChangeItemsButtonStatus(bool enabled)
        {
            buttonItemsSave.Text = enabled ? language.TabItems.ButtonItemsSave : language.TabItems.ButtonItemsNew;
            buttonItemsUpdate.Enabled = !enabled;
            buttonItemsDelete.Enabled = !enabled;
        }

        private void ChangeItemTypeButtonStatus(bool enabled)
        {
            buttonItemTypeSave.Text = enabled
                                          ? language.TabItemTypes.ButtonItemTypeListSave
                                          : language.TabItemTypes.ButtonItemTypeListNew;
            buttonItemTypeUpdate.Enabled = !enabled;
            buttonItemTypeDelete.Enabled = !enabled;
        }

        private void ChangeOrdersButtonStatus(bool enabled)
        {
            buttonOrdersSave.Text = enabled ? language.TabOrders.ButtonOrdersSave : language.TabOrders.ButtonOrdersNew;
            buttonOrdersUpdate.Enabled = !enabled;
            buttonOrdersDelete.Enabled = !enabled;
        }

        private void ChangeBankButtonStatus(bool enabled)
        {
            buttonBankSave.Text = enabled ? language.TabBank.ButtonBankSave : language.TabBank.ButtonBankNew;
            buttonBankUpdate.Enabled = !enabled;
            buttonBankDelete.Enabled = !enabled;
        }

        private void ButtonItemsDeleteClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Delete Item...");
            int itemId = Misc.String2Number(labelItemsId.Text);
            if (itemId > -1)
            {
                int rowsDeleted = dataBase.ItemDelete(itemId);
                if (rowsDeleted < 1)
                {
                    MessageBox.Show(@"Failed to delete Item!", @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    ClearItems();
                }
                FillItems();
            }
            else
            {
                MessageBox.Show(@"Failed to delete Item!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ButtonItemTypeUpdateClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Update Item Type...");
            int itemTypeId = Misc.String2Number(labelItemTypeId.Text);
            if (itemTypeId > -1)
            {
                ItemType itemType = new ItemType
                                    {
                                        Id = itemTypeId,
                                        Name = textBoxItemTypeName.Text,
                                        Description = textBoxItemTypeDescription.Text
                                    };
                int rowsUpdated = dataBase.ItemTypeUpdate(itemType);
                if (rowsUpdated < 1)
                {
                    MessageBox.Show(@"Failed to update ItemType!", @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    ClearItemType();
                }
                FillItemTypes();
            }
            else
            {
                MessageBox.Show(@"Failed to update ItemType!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ButtonItemTypeDeleteClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Delete Item Type...");
            int itemTypeId = Misc.String2Number(labelItemTypeId.Text);
            if (itemTypeId > -1)
            {
                int rowsDeleted = dataBase.ItemTypeDelete(itemTypeId);
                if (rowsDeleted < 1)
                {
                    MessageBox.Show(@"Failed to delete ItemType!", @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    ClearItemType();
                }
                FillItemTypes();
            }
            else
            {
                MessageBox.Show(@"Failed to delete ItemType!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ButtonPersonInfoSaveClick
            (object sender,
             EventArgs e)
        {
            if (buttonPersonInfoSave.Text == language.TabPersonInfo.ButtonPersonInfoNew)
            {
                ClearPersonInfoTextBoxes();
                return;
            }
            try
            {
                string name = textBoxPersonInfoName.Text.Trim();
                string surName = textBoxPersonInfoSurName.Text.Trim();
                if (name.Length > 1)
                {
                    PersonInfo personInfoExisting = dataBase.PersonInfoGet(name, surName);
                    if (personInfoExisting != null)
                    {
                        DialogResult dialogResult =
                            MessageBox.Show(@"PersonInfo with that name already exists! Do you wanna save it anyway?",
                                            @"Question", MessageBoxButtons.YesNo,
                                            MessageBoxIcon.Question);
                        if (dialogResult == DialogResult.No)
                        {
                            return;
                        }
                    }
                    PersonInfo personInfo = GetPersonInfo();
                    int rowsInserted = dataBase.PersonInfoInsert(personInfo);
                    if (rowsInserted < 1)
                    {
                        MessageBox.Show(@"Failed to insert PersonInfo!", @"Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        FillPersonInfo();
                        ClearPersonInfoTextBoxes();
                    }
                }
                else
                {
                    MessageBox.Show(@"Insert Persons Name!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private PersonInfo GetPersonInfo()
        {
            return new PersonInfo
                   {
                       Name = textBoxPersonInfoName.Text.Trim(),
                       SurName = textBoxPersonInfoSurName.Text,
                       NickName = textBoxPersonInfoNickName.Text,
                       Description = textBoxPersonInfoDescription.Text,
                       Address = textBoxPersonInfoAddress.Text,
                       PostNumber = Misc.String2Number(textBoxPersonInfoPopstNumber.Text),
                       City = textBoxPersonInfoCity.Text,
                       Email = textBoxPersonInfoEmail.Text,
                       Telephone = textBoxPersonInfoTelephone.Text,
                       TelephoneMobile = textBoxPersonInfoTelephoneMobile.Text,
                       Fax = textBoxPersonInfoFaxNumber.Text,
                   };
        }

        private void ClearPersonInfoTextBoxes()
        {
            Logger.Debug("ClearPersonInfoTextBoxes");
            textBoxPersonInfoName.Text = String.Empty;
            textBoxPersonInfoSurName.Text = String.Empty;
            textBoxPersonInfoNickName.Text = String.Empty;
            textBoxPersonInfoDescription.Text = String.Empty;
            textBoxPersonInfoAddress.Text = String.Empty;
            textBoxPersonInfoPopstNumber.Text = String.Empty;
            textBoxPersonInfoCity.Text = String.Empty;
            textBoxPersonInfoEmail.Text = String.Empty;
            textBoxPersonInfoTelephone.Text = String.Empty;
            textBoxPersonInfoTelephoneMobile.Text = String.Empty;
            textBoxPersonInfoFaxNumber.Text = String.Empty;
            EnablePersonInfoSaveButton();
            SetPersonInfoId(-1);
        }

        private void ButtonPersonInfoUpdateClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Update Person info...");
            int personInfoId = GetPersonInfoId();
            if (personInfoId > -1)
            {
                PersonInfo personInfo = GetPersonInfo();
                personInfo.Id = personInfoId;
                int rowsUpdated = dataBase.PersonInfoUpdate(personInfo);
                if (rowsUpdated < 1)
                {
                    MessageBox.Show(@"Failed to update PersonInfo!", @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    ClearPersonInfoTextBoxes();
                }
                FillPersonInfo();
            }
            else
            {
                MessageBox.Show(@"Failed to update PersonInfo!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ButtonPersonInfoDeleteClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Delete Person info...");
            int personInfoId = GetPersonInfoId();
            if (personInfoId > -1)
            {
                int rowsDeleted = dataBase.PersonInfoDelete(personInfoId);
                if (rowsDeleted < 1)
                {
                    MessageBox.Show(@"Failed to delete PersonInfo!", @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    ClearPersonInfoTextBoxes();
                }
                FillPersonInfo();
            }
            else
            {
                MessageBox.Show(@"Failed to delete PersonInfo!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ComboBoxOrderItemTypeSelectedIndexChanged
            (object sender,
             EventArgs e)
        {
            Logger.Info("Item type was changed...");
            ComboBox comboBox = (ComboBox) sender;
            ItemType selectedItemType = (ItemType) comboBox.SelectedItem;
            if (selectedItemType == null)
            {
                Logger.Warn("Failed to ge Item Type!");
                return;
            }
            FillOrderItems(selectedItemType);
        }

        private void FillOrderItems(ItemType selectedItemType)
        {
            comboBoxOrdersItem.Items.Clear();
            comboBoxOrdersItem.Text = String.Empty;
            List<Item> items = dataBase.ItemGetByType(selectedItemType.Id);
            if (items.Count > 0)
            {
                comboBoxOrdersItem.Items.AddRange(items.ToArray());
                comboBoxOrdersItem.SelectedItem = comboBoxOrdersItem.Items[0];
            }
            else
            {
                Logger.Warn("No items for selected Type were found!");
            }
        }

        private static void ShowPicture
            (Item item,
             PictureBox pictureBox)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox.Image = new Bitmap(1, 1);
            try
            {
                if (item.Image != null)
                {
                    if (item.Image.Length > 0)
                    {
                        MemoryStream memoryStream = new MemoryStream(item.Image);
                        Bitmap bitmap = new Bitmap(memoryStream);
                        pictureBox.Image = bitmap;
                    }
                }
            }
            catch (Exception exception)
            {
                Logger.Error("Failed to show picture! \r\n{0}", exception.ToString());
            }
        }

        private void ButtonOrderSaveClick
            (object sender,
             EventArgs e)
        {
            if (buttonOrdersSave.Text == language.TabOrders.ButtonOrdersNew)
            {
                ClearOrdersTextBoxes();
                return;
            }
            Logger.Info("Order save...");
            try
            {
                Item selectedItem = (Item) comboBoxOrdersItem.SelectedItem;
                if (selectedItem == null)
                {
                    const string text = "Failed to get Item!";
                    Logger.Error(text);
                    MessageBox.Show(text, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                ItemStatus selectedItemStatus = (ItemStatus) comboBoxOrdersItemStatus.SelectedItem;
                if (selectedItemStatus == null)
                {
                    const string text = "Failed to get ItemStatus!";
                    Logger.Error(text);
                    MessageBox.Show(text, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                PersonInfo selectedPersonInfo = (PersonInfo) comboBoxOrdersPersonInfo.SelectedItem;
                if (selectedPersonInfo == null)
                {
                    const string text = "Failed to get PersonInfo!";
                    Logger.Error(text);
                    MessageBox.Show(text, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                Bank selectedBank = (Bank) comboBoxOrdersBank.SelectedItem ?? new Bank {Id = -1,};
                string count = textBoxOrdersItemCount.Text.Trim();
                if (count.Length < 1)
                {
                    const string text = @"Specify number of items!";
                    Logger.Error(text);
                    MessageBox.Show(text, @"Info", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                string priceBox = textBoxOrdersPrice.Text.Trim();
                if (priceBox.Length < 1)
                {
                    const string text = @"Specify price!";
                    Logger.Error(text);
                    MessageBox.Show(text, @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                decimal price = priceBox.String2Decimal();
                string postageTextBox = textBoxOrdersPostage.Text.Trim();
                if (postageTextBox.Length < 1)
                {
                    const string text = @"Specify postage!";
                    Logger.Error(text);
                    MessageBox.Show(text, @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                decimal postage = postageTextBox.String2Decimal();
                string tax = textBoxOrdersTax.Text.Trim();
                if (tax.Length < 1)
                {
                    const string text = @"Specify tax!";
                    Logger.Error(text);
                    MessageBox.Show(text, @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Order order = new Order
                              {
                                  ItemId = selectedItem.Id,
                                  Count = Misc.String2Number(count),
                                  ItemStatusId = selectedItemStatus.Id,
                                  PersonInfoId = selectedPersonInfo.Id,
                                  LegalEntity = checkBoxOrdersLegalEntity.Checked,
                                  Postage = postage.DecimalToString(),
                                  Price = price.DecimalToString(),
                                  Tax = tax,
                                  BankId = selectedBank.Id,
                              };
                int rowsInserted = dataBase.OrderInsert(order);
                if (rowsInserted != 1)
                {
                    const string text = @"Failed to insert Order!";
                    Logger.Error(text);
                    MessageBox.Show(text, @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                FillOrders();
                ClearOrdersTextBoxes();
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private int GetPersonInfoId()
        {
            return Misc.String2Number(labelPersonInfoId.Text);
        }

        private void ButtonOrdersUpdateClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Order update...");
            int orderId = GetOrderId();
            if (orderId > -1)
            {
                Item selectedItem = (Item) comboBoxOrdersItem.SelectedItem;
                if (selectedItem == null)
                {
                    Logger.Error("Failed to get Item!");
                    return;
                }
                ItemStatus selectedItemStatus = (ItemStatus) comboBoxOrdersItemStatus.SelectedItem;
                if (selectedItemStatus == null)
                {
                    Logger.Error("Failed to get ItemStatus!");
                    return;
                }
                PersonInfo selectedPersonInfo = (PersonInfo) comboBoxOrdersPersonInfo.SelectedItem;
                if (selectedPersonInfo == null)
                {
                    Logger.Error("Failed to get PersonInfo!");
                    return;
                }
                string count = textBoxOrdersItemCount.Text.Trim();
                if (count.Length < 1)
                {
                    MessageBox.Show(@"Specify number of items!", @"Info", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                    return;
                }
                string priceBox = textBoxOrdersPrice.Text.Trim();
                if (priceBox.Length < 1)
                {
                    MessageBox.Show(@"Specify price!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                decimal price = priceBox.String2Decimal();
                string postageTextBox = textBoxOrdersPostage.Text.Trim();
                if (postageTextBox.Length < 1)
                {
                    MessageBox.Show(@"Specify postage!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                decimal postage = postageTextBox.String2Decimal();
                string tax = textBoxOrdersTax.Text.Trim();
                if (tax.Length < 1)
                {
                    MessageBox.Show(@"Specify tax!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                Bank selectedBank = (Bank) comboBoxOrdersBank.SelectedItem ?? new Bank {Id = -1,};
                Order order = new Order
                              {
                                  Id = orderId,
                                  ItemId = selectedItem.Id,
                                  Count = Misc.String2Number(count),
                                  ItemStatusId = selectedItemStatus.Id,
                                  PersonInfoId = selectedPersonInfo.Id,
                                  LegalEntity = checkBoxOrdersLegalEntity.Checked,
                                  Postage = postage.DecimalToString(),
                                  Price = price.DecimalToString(),
                                  Tax = tax,
                                  BankId = selectedBank.Id,
                              };
                int rowsUpdated = dataBase.OrderUpdate(order);
                if (rowsUpdated < 1)
                {
                    MessageBox.Show(@"Failed to update Order!", @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    ClearOrdersTextBoxes();
                }
                FillOrders();
            }
            else
            {
                MessageBox.Show(@"Failed to update Order!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
            SetOrderId(-1);
        }

        private void ButtonOrdersDeleteClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Order delete...");
            int orderId = GetOrderId();
            if (orderId > -1)
            {
                int rowsDeleted = dataBase.OrderDelete(orderId);
                if (rowsDeleted < 1)
                {
                    MessageBox.Show(@"Failed to delete Order!", @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    ClearOrdersTextBoxes();
                }
                FillOrders();
            }
            else
            {
                MessageBox.Show(@"Failed to delete Order!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ClearOrdersTextBoxes()
        {
            Logger.Debug("ClearOrdersTextBoxes");
            textBoxOrdersItemCount.Text = @"1";
            textBoxOrdersPrice.Text = String.Empty;
            textBoxOrdersPostage.Text = @"0";
            textBoxOrdersTax.Text = @"0";
            SetOrderId(-1);
            EnableOrdersSaveButton();
        }

        private int GetOrderId()
        {
            return Misc.String2Number(labelOrdersId.Text.Trim());
        }

        private void ButtonOrdersSumClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Calculate Sum...");
            string count = textBoxOrdersItemCount.Text.Trim();
            if (count.Length < 1)
            {
                MessageBox.Show(@"Specify number of items!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            string priceBox = textBoxOrdersPrice.Text.Trim();
            if (priceBox.Length < 1)
            {
                MessageBox.Show(@"Specify price!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            decimal price = priceBox.String2Decimal();
            string postageTextBox = textBoxOrdersPostage.Text.Trim();
            if (postageTextBox.Length < 1)
            {
                MessageBox.Show(@"Specify postage!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            decimal postage = postageTextBox.String2Decimal();
            //string tax = GetTax();
            try
            {
                labelOrdersSumNumber.Text = string.Format("{0} {1}", (Misc.String2Number(count)*price + postage),
                                                          ConfigurationManager.AppSettings["defaultCurrency"]);
            }
            catch (Exception exception)
            {
                Logger.Error(exception);
            }
        }

        private void ComboBoxOrderItemSelectedIndexChanged
            (object sender,
             EventArgs e)
        {
            Logger.Info("Item was changed...");
            ComboBox comboBox = (ComboBox) sender;
            Item selectedItem = (Item) comboBox.SelectedItem;
            if (selectedItem == null)
            {
                Logger.Warn("Failed to ge Item!");
                return;
            }
            ShowPicture(selectedItem, pictureBoxOrders);
            textBoxOrdersPrice.Text = selectedItem.Price.ToString();
        }

        private void DataGridViewItemTypeSelectionChanged
            (object sender,
             EventArgs e)
        {
            DataGridView dataGridView = (DataGridView) sender;
            if (dataGridView.SelectedRows.Count < 1)
            {
                return;
            }
            try
            {
                List<ItemType> list = (List<ItemType>) dataGridViewItemType.DataSource;
                if (list == null)
                {
                    Logger.Warn("Failed to get itemTypes binded to the control 'dataGridViewItemType'.");
                    return;
                }
                Logger.Info("Selected ItemType changed...");
                ItemType itemType = (ItemType) dataGridViewItemType.SelectedRows[0].DataBoundItem;
                if (itemType != null)
                {
                    Logger.Info("Selected ItemType: {0}", itemType.Format());
                    textBoxItemTypeName.Text = itemType.Name;
                    textBoxItemTypeDescription.Text = itemType.Description;
                    DisableItemTypeSaveButton();
                    SetItemTypeId(itemType.Id);
                }
                else
                {
                    Logger.Debug("ItemType not selected");
                    MessageBox.Show(@"Select an Item!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void DataGridViewItemsSelectionChanged
            (object sender,
             EventArgs e)
        {
            DataGridView dataGridView = (DataGridView) sender;
            if (dataGridView.SelectedRows.Count < 1)
            {
                return;
            }
            BindingListView<Item> list = (BindingListView<Item>)dataGridViewItems.DataSource;
            if (list == null)
            {
                Logger.Warn("Failed to get Items binded to the control 'dataGridViewItems'.");
                return;
            }
            Logger.Info("Selected item changed...");
            try
            {
                //http://blw.sourceforge.net/
                Item selectedItem = ((ObjectView<Item>) dataGridViewItems.SelectedRows[0].DataBoundItem).Object;
                if (selectedItem != null)
                {
                    Logger.Info("Selected item: '{0}'", selectedItem.Format());
                    Item item = dataBase.ItemGet(selectedItem.Id);
                    if (item != null)
                    {
                        textBoxItemsName.Text = item.Name;
                        textBoxItemsDescription.Text = item.Description;
                        ItemType itemType = (from ItemType t in comboBoxItemsType.Items
                                             where t.Id == item.ItemTypeId
                                             select t).FirstOrDefault();
                        comboBoxItemsType.SelectedItem = itemType;
                        ShowPicture(item, pictureBoxItems);
                        DisableItemsSaveButton();
                        SetItemId(selectedItem.Id);
                    }
                }
                else
                {
                    Logger.Debug("Item not selected");
                    MessageBox.Show(@"Select an Item!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void DataGridViewItemStatusSelectionChanged
            (object sender,
             EventArgs e)
        {
            DataGridView dataGridView = (DataGridView) sender;
            if (dataGridView.SelectedRows.Count < 1)
            {
                return;
            }
            List<ItemStatus> list = (List<ItemStatus>) dataGridViewItemStatus.DataSource;
            if (list == null)
            {
                Logger.Warn("Failed to get ItemStatus binded to the control 'dataGridViewItemStatus'.");
                return;
            }
            Logger.Info("Selected item status changed...");
            try
            {
                ItemStatus itemStatus = (ItemStatus) dataGridViewItemStatus.SelectedRows[0].DataBoundItem;
                if (itemStatus != null)
                {
                    Logger.Info("Selected item status: '{0}'", itemStatus.FormatItemStatus());
                    textBoxItemStatusName.Text = itemStatus.Name;
                    textBoxItemStatusDescription.Text = itemStatus.Description;
                    DisableItemStatusSaveButton();
                    SetItemStatusId(itemStatus.Id);
                }
                else
                {
                    Logger.Debug("Item Status was not selected.");
                    MessageBox.Show(@"Select an Item Status!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void DataGridViewPersonInfoSelectionChanged
            (object sender,
             EventArgs e)
        {
            DataGridView dataGridView = (DataGridView) sender;
            if (dataGridView.SelectedRows.Count < 1)
            {
                return;
            }
            List<PersonInfo> list = (List<PersonInfo>) dataGridViewPersonInfo.DataSource;
            if (list == null)
            {
                Logger.Warn("Failed to get personInfo binded to the control 'dataGridViewPersonInfo'.");
                return;
            }
            try
            {
                Logger.Info("Selected PersonInfo changed...");
                PersonInfo personInfo = (PersonInfo) dataGridViewPersonInfo.SelectedRows[0].DataBoundItem;
                if (personInfo != null)
                {
                    Logger.Info("Selected PersonInfo : '{0}'", personInfo.Format());
                    textBoxPersonInfoName.Text = personInfo.Name;
                    textBoxPersonInfoSurName.Text = personInfo.SurName;
                    textBoxPersonInfoNickName.Text = personInfo.NickName;
                    textBoxPersonInfoDescription.Text = personInfo.Description;
                    textBoxPersonInfoAddress.Text = personInfo.Address;
                    textBoxPersonInfoPopstNumber.Text = personInfo.PostNumber.ToString();
                    textBoxPersonInfoCity.Text = personInfo.City;
                    textBoxPersonInfoEmail.Text = personInfo.Email;
                    textBoxPersonInfoTelephone.Text = personInfo.Telephone;
                    textBoxPersonInfoTelephoneMobile.Text = personInfo.TelephoneMobile;
                    textBoxPersonInfoFaxNumber.Text = personInfo.Fax;
                    SetPersonInfoId(personInfo.Id);
                    DisablePersonInfoSaveButton();
                }
                else
                {
                    Logger.Debug("PersonInfo was not selected.");
                    MessageBox.Show(@"Select an Person!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void DataGridViewOrdersSelectionChanged
            (object sender,
             EventArgs e)
        {
            DataGridView dataGridView = (DataGridView) sender;
            if (dataGridView.SelectedRows.Count < 1)
            {
                return;
            }
            List<Order> list = (List<Order>) dataGridViewOrders.DataSource;
            if (list == null)
            {
                Logger.Warn("Failed to get orders binded to the control 'dataGridViewOrders'.");
                return;
            }
            Logger.Info("Selected Order changed...");
            try
            {
                Order order = (Order) dataGridViewOrders.SelectedRows[0].DataBoundItem;
                if (order != null)
                {
                    Logger.Info("Selected Order : '{0}'", order.Format());
                    comboBoxOrdersPersonInfo.SelectedItem = (from PersonInfo p in comboBoxOrdersPersonInfo.Items
                                                             where p.Id == order.PersonInfoId
                                                             select p).FirstOrDefault();
                    Item item = dataBase.ItemGet(order.ItemId);
                    if (item == null)
                    {
                        Logger.Warn("Failed to get Item!");
                    }
                    else
                    {
                        ItemType itemType = (from ItemType t in comboBoxOrdersItemType.Items
                                             where t.Id == item.ItemTypeId
                                             select t).FirstOrDefault();
                        if (itemType == null)
                        {
                            Logger.Warn("Failed to get ItemType!");
                            comboBoxOrdersItemType.SelectedItem = String.Empty;
                        }
                        else
                        {
                            comboBoxOrdersItemType.SelectedItem = itemType;
                            FillOrderItems(itemType);
                            if (comboBoxOrdersItem.Items.Count > 0)
                            {
                                Item itm = (from Item i in comboBoxOrdersItem.Items
                                            where i.Id == order.ItemId
                                            select i).FirstOrDefault();
                                comboBoxOrdersItem.Text = itm.Name;
                            }
                        }
                    }
                    ItemStatus itemStatus = (from ItemStatus s in comboBoxOrdersItemStatus.Items
                                             where s.Id == order.ItemStatusId
                                             select s).FirstOrDefault();
                    if (itemStatus == null)
                    {
                        Logger.Warn("Failed to get ItemStatus!");
                        comboBoxOrdersItemStatus.Text = String.Empty;
                    }
                    else
                    {
                        comboBoxOrdersItemStatus.SelectedItem = itemStatus;
                        comboBoxOrdersItemStatus.Text = itemStatus.Name;
                    }
                    Bank bank = (from Bank b in comboBoxOrdersBank.Items
                                             where b.Id == order.BankId
                                             select b).FirstOrDefault();
                    if (bank == null)
                    {
                        Logger.Warn("Failed to get Bank!");
                        comboBoxOrdersBank.Text = String.Empty;
                    }
                    else
                    {
                        comboBoxOrdersBank.SelectedItem = bank;
                        comboBoxOrdersBank.Text = bank.ToString();
                    }
                    textBoxOrdersItemCount.Text = order.Count.ToString();
                    textBoxOrdersPrice.Text = order.Price;
                    textBoxOrdersPostage.Text = order.Postage;
                    textBoxOrdersTax.Text = order.Tax;
                    checkBoxOrdersLegalEntity.Checked = order.LegalEntity;
                    ShowPicture(item, pictureBoxOrders);
                    DisableOrdersSaveButton();
                    SetOrderId(order.Id);
                }
                else
                {
                    Logger.Debug("Order was not selected!");
                    MessageBox.Show(@"Select an order!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void DataGridViewBankSelectionChanged
            (object sender,
             EventArgs e)
        {
            DataGridView dataGridView = (DataGridView) sender;
            if (dataGridView.SelectedRows.Count < 1)
            {
                return;
            }
            List<Bank> list = (List<Bank>) dataGridViewBank.DataSource;
            if (list == null)
            {
                Logger.Warn("Failed to get orders binded to the control 'dataGridViewBank'.");
                return;
            }
            Logger.Info("Selected Bank changed...");
            try
            {
                Bank bank = (Bank) dataGridViewBank.SelectedRows[0].DataBoundItem;
                if (bank != null)
                {
                    Logger.Info("Selected Bank : '{0}'", bank.Format());
                    textBoxBankName.Text = bank.Name;
                    textBoxBankOwner.Text = bank.Owner;
                    textBoxBankAccountNumber.Text = bank.AccountNumber;
                    DisableBankSaveButton();
                    SetBankId(bank.Id);
                }
                else
                {
                    Logger.Debug("Bank was not selected!");
                    MessageBox.Show(@"Select an bank!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ButtonBankSaveClick
            (object sender,
             EventArgs e)
        {
            if (buttonBankSave.Text == language.TabBank.ButtonBankNew)
            {
                ClearBank();
                return;
            }
            Logger.Info("Save bank...");
            try
            {
                if (textBoxBankName.Text.Length > 1)
                {
                    Bank bank = new Bank
                                {
                                    Name = textBoxBankName.Text.Trim(),
                                    Owner = textBoxBankOwner.Text.Trim(),
                                    AccountNumber = textBoxBankAccountNumber.Text.Trim(),
                                };
                    bool insertBank = false;
                    List<Bank> bankGet = dataBase.BankGet(bank.Owner);
                    if (bankGet == null)
                    {
                        insertBank = true;
                    }
                    if (!insertBank)
                    {
                        List<Bank> findAll =
                            bankGet.FindAll(b => b.Name == bank.Name && b.AccountNumber == bank.AccountNumber);
                        if (findAll.Count < 1)
                        {
                            insertBank = true;
                        }
                    }
                    if (insertBank)
                    {
                        int rowsInserted = dataBase.BankInsert(bank);
                        if (rowsInserted < 1)
                        {
                            MessageBox.Show(@"Failed to insert Bank!", @"Error", MessageBoxButtons.OK,
                                            MessageBoxIcon.Error);
                            Logger.Error("Failed to insert Bank!");
                            return;
                        }
                        FillBank();
                        ClearBank();
                        return;
                    }
                }
                else
                {
                    MessageBox.Show(@"Insert ItemStatus Name!", @"Info", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ButtonBankUpdateClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Update bank...");
            try
            {
                int bankId = Misc.String2Number(labelBankId.Text);
                Bank bank = new Bank
                            {
                                Id = bankId,
                                Name = textBoxBankName.Text.Trim(),
                                Owner = textBoxBankOwner.Text.Trim(),
                                AccountNumber = textBoxBankAccountNumber.Text.Trim(),
                            };
                int rowsUpdated = dataBase.BankUpdate(bank);
                if (rowsUpdated < 1)
                {
                    const string message = @"Failed to update bank!";
                    Logger.Error(message);
                    MessageBox.Show(message, @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                ClearBank();
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ButtonBankDeleteClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Delete bank...");
            try
            {
                if (labelBankId.Text == @"-1")
                {
                    return;
                }
                int bankId = Misc.String2Number(labelBankId.Text);
                int rowsDeleted = dataBase.BankDelete(bankId);
                if (rowsDeleted < 1)
                {
                    const string message = @"Failed to remove bank!";
                    Logger.Error(message);
                    MessageBox.Show(message, @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                    return;
                }
                ClearBank();
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        public PagePreview.RenderEvent RenderEvent
        {
            get { return renderEvent; }
            set
            {
                pagePreviewExport.SetRenderEvent(value);
                renderEvent = value;
            }
        }
        PagePreview.RenderEvent renderEvent;

        private void ButtonExportPreviewClick(object sender, EventArgs e)
        {
            RenderEvent = new PagePreview.RenderEvent(renderer.Render);
        }
    }
}