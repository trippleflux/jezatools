using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using NLog;

namespace jeza.Item.Tracker.Gui
{
    public partial class Gui : Form
    {
        private static readonly Logger Logger = LogManager.GetCurrentClassLogger();
        private readonly DataBase dataBase = new DataBase();

        public Gui()
        {
            InitializeComponent();

            //Settings settings = Misc.Deserialize(new Settings(), "settings.xml");
            //string setting = ConfigurationManager.AppSettings["language"];
            //language = settings.Languages.Find(l => l.Culture.Equals(setting));

            //tabPageItems.Text = language.TabItems.TabPageItems;
            //groupBoxItems.Text = language.TabItems.GroupBoxItems;

            //groupBoxItemsStatus.Text = language.TabItems.GroupBoxItemsStatus;
            //labelItemsStatusExisting.Text = language.TabItems.LabelItemsStatusExisting;
            //labelItemsStatusNew.Text = language.TabItems.LabelItemsStatusNew;

            //groupBoxItemsType.Text = language.TabItems.GroupBoxItemsType;
            FillItemTypes();
            FillItemStatus();
            FillItems();
            FillPersonInfo();
        }

        private void FillPersonInfo()
        {
            Logger.Debug("Fill person info");
            List<PersonInfo> list = dataBase.PersonInfoGetAll();
            if (list == null)
            {
                return;
            }
            //Order tab
            comboBoxOrderPersonInfo.Items.Clear();
            comboBoxOrderPersonInfo.Items.AddRange(list.ToArray());
            comboBoxOrderPersonInfo.SelectedItem = comboBoxOrderPersonInfo.Items[0];
            //PersonInfo tab
            listBoxPersonInfoList.Items.Clear();
            listBoxPersonInfoList.Items.AddRange(list.ToArray());
        }

        private void FillItems()
        {
            Logger.Debug("Fill Items");
            List<Item> items = dataBase.ItemGetAll();
            if (items == null)
            {
                return;
            }
            ListBox.ObjectCollection objectCollection = listBoxItemsList.Items;
            objectCollection.Clear();
            objectCollection.AddRange(items.ToArray());
            ComboBox.ObjectCollection collection = comboBoxOrderItem.Items;
            collection.Clear();
            collection.AddRange(items.ToArray());
            comboBoxOrderItem.SelectedItem = collection[0];
        }

        private void FillItemTypes()
        {
            Logger.Info("Fill Item Types...");
            List<ItemType> itemTypes = dataBase.ItemTypeGetAll();
            if (itemTypes == null)
            {
                Logger.Warn("ItemTypes is empty");
                return;
            }
            //order tab
            comboBoxOrderItemType.Items.Clear();
            comboBoxOrderItemType.Items.AddRange(itemTypes.ToArray());
            comboBoxOrderItemType.SelectedItem = comboBoxOrderItemType.Items[0];
            //items tab
            comboBoxItemsType.Items.Clear();
            comboBoxItemsType.Items.AddRange(itemTypes.ToArray());
            comboBoxItemsType.SelectedItem = comboBoxItemsType.Items[0];
            //item type tab
            listBoxItemTypeList.Items.Clear();
            listBoxItemTypeList.Items.AddRange(itemTypes.ToArray());
        }

        private void FillItemStatus()
        {
            Logger.Debug("Fill Item Status");
            List<ItemStatus> list = dataBase.ItemStatusGetAll();
            if (list == null)
            {
                return;
            }
            //Order tab
            comboBoxOrderItemStatus.Items.Clear();
            comboBoxOrderItemStatus.Items.AddRange(list.ToArray());
            comboBoxOrderItemStatus.SelectedItem = comboBoxOrderItemStatus.Items[0];
            //Item Status tab
            listBoxItemStatusList.Items.Clear();
            listBoxItemStatusList.Items.AddRange(list.ToArray());
        }

        private void ButtonItemsSaveClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Save item...");
            try
            {
                if (textBoxItemsName.Text.Length > 1)
                {
                    Item item = new Item
                                {
                                    Name = textBoxItemsName.Text,
                                    Description = textBoxItemsDescription.Text
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
                    item.Image = new byte[] {};
                    //TODO: add image
                    int rowsUpdated = dataBase.ItemInsert(item);
                    if (rowsUpdated < 1)
                    {
                        MessageBox.Show(@"Failed to insert Item!", @"Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        FillItems();
                        EnableItemsSaveButton();
                        textBoxItemsName.Text = String.Empty;
                        textBoxItemsDescription.Text = String.Empty;
                        pictureBoxItems.Image = new Bitmap(1, 1);
                        SetItemId(-1);
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

        private void ButtonItemTypeSaveClick
            (object sender,
             EventArgs e)
        {
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
                        MessageBox.Show(@"ItemType with that name already exists!", @"Warn", MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                        return;
                    }
                    int rowsUpdated = dataBase.ItemTypeInsert(itemType);
                    if (rowsUpdated < 1)
                    {
                        MessageBox.Show(@"Failed to insert Item type!", @"Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        FillItemTypes();
                        EnableItemTypeSaveButton();
                        textBoxItemTypeName.Text = String.Empty;
                        textBoxItemTypeDescription.Text = String.Empty;
                        SetItemTypeId(-1);
                    }
                }
                else
                {
                    MessageBox.Show(@"Insert ItemType Name!", @"Info", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
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

        private void ButtonItemsSelectClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Select item...");
            try
            {
                Item selectedItem = (Item) listBoxItemsList.SelectedItem;
                if (selectedItem != null)
                {
                    Item item = dataBase.ItemGet(selectedItem.Id);
                    if (item == null)
                    {
                        return;
                    }
                    textBoxItemsName.Text = item.Name;
                    textBoxItemsDescription.Text = item.Description;
                    pictureBoxItems.Image = new Bitmap(1, 1);
                    if (item.Image != null)
                    {
                        if (item.Image.Length > 0)
                        {
                            MemoryStream memoryStream = new MemoryStream(item.Image);
                            Bitmap bitmap = new Bitmap(memoryStream);
                            pictureBoxItems.Image = bitmap;
                        }
                    }
                    DisableItemsSaveButton();
                    SetItemId(item.Id);
                }
                else
                {
                    MessageBox.Show(@"Select an Item!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ButtonItemTypeListSelectClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Select item type...");
            try
            {
                ItemType selectedItem = (ItemType) listBoxItemTypeList.SelectedItem;
                if (selectedItem != null)
                {
                    ItemType itemType = dataBase.ItemTypeGet(selectedItem.Id);
                    if (itemType == null)
                    {
                        return;
                    }
                    textBoxItemTypeName.Text = itemType.Name;
                    textBoxItemTypeDescription.Text = itemType.Description;
                    DisableItemTypeSaveButton();
                    SetItemTypeId(itemType.Id);
                }
                else
                {
                    MessageBox.Show(@"Select an Item!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

        private void SetItemId(int itemId)
        {
            labelItemsId.Text = itemId.ToString();
        }

        private void ButtonOrderitemSelectClick
            (object sender,
             EventArgs e)
        {
            try
            {
                Item selectedItem = (Item) comboBoxOrderItem.SelectedItem;
                if (selectedItem != null)
                {
                    Item item = dataBase.ItemGet(selectedItem.Id);
                    if (item == null)
                    {
                        return;
                    }
                    pictureBoxOrder.Image = new Bitmap(1, 1);
                    if (item.Image != null)
                    {
                        if (item.Image.Length > 0)
                        {
                            MemoryStream memoryStream = new MemoryStream(item.Image);
                            Bitmap bitmap = new Bitmap(memoryStream);
                            pictureBoxOrder.Image = bitmap;
                        }
                    }
                }
                else
                {
                    MessageBox.Show(@"Select an Item!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ButtonItemsStatusSaveClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Save item status...");
            try
            {
                if (textBoxItemStatusName.Text.Length > 1)
                {
                    ItemStatus itemStatus = new ItemStatus
                                            {
                                                Name = textBoxItemStatusName.Text,
                                                Description = textBoxItemStatusDescription.Text
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
                        EnableItemStatusSaveButton();
                        textBoxItemStatusName.Text = String.Empty;
                        textBoxItemStatusDescription.Text = String.Empty;
                        SetItemStatusId(-1);
                    }
                }
                else
                {
                    MessageBox.Show(@"Insert ItemType Name!", @"Info", MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
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
                    textBoxItemStatusName.Text = String.Empty;
                    textBoxItemStatusDescription.Text = String.Empty;
                    SetItemStatusId(-1);
                    EnableItemStatusSaveButton();
                }
                FillItemStatus();
            }
            else
            {
                MessageBox.Show(@"Failed to update Item Status!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
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
                    textBoxItemStatusName.Text = String.Empty;
                    textBoxItemStatusDescription.Text = String.Empty;
                    SetItemStatusId(-1);
                    EnableItemStatusSaveButton();
                }
                FillItemStatus();
            }
            else
            {
                MessageBox.Show(@"Failed to delete Item Status!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ButtonItemsStatusSelectClick
            (object sender,
             EventArgs e)
        {
            Logger.Info("Select item status...");
            try
            {
                ItemStatus selectedItemStatus = (ItemStatus) listBoxItemStatusList.SelectedItem;
                if (selectedItemStatus != null)
                {
                    ItemStatus itemStatus = dataBase.ItemStatusGet(selectedItemStatus.Id);
                    if (itemStatus == null)
                    {
                        return;
                    }
                    textBoxItemStatusName.Text = itemStatus.Name;
                    textBoxItemStatusDescription.Text = itemStatus.Description;
                    DisableItemStatusSaveButton();
                    SetItemStatusId(itemStatus.Id);
                }
                else
                {
                    MessageBox.Show(@"Select an Item Status!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
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
                                Description = textBoxItemsDescription.Text
                            };
                ItemType selectedItem = (ItemType) comboBoxItemsType.SelectedItem;
                if (selectedItem != null)
                {
                    item.ItemTypeId = selectedItem.Id;
                }
                item.Image = new byte[] {};
                //TODO: add image
                int rowsUpdated = dataBase.ItemUpdate(item);
                if (rowsUpdated < 1)
                {
                    MessageBox.Show(@"Failed to update Item!", @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    textBoxItemsName.Text = String.Empty;
                    textBoxItemsDescription.Text = String.Empty;
                    pictureBoxItems.Image = new Bitmap(1, 1);
                    SetItemId(-1);
                    EnableItemsSaveButton();
                }
                FillItems();
            }
            else
            {
                MessageBox.Show(@"Failed to update Item!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
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

        private void ChangeItemStatusButtonStatus(bool enabled)
        {
            buttonItemsStatusSave.Enabled = enabled;
            buttonItemStatusUpdate.Enabled = !enabled;
            buttonItemStatusDelete.Enabled = !enabled;
        }

        private void ChangeItemsButtonStatus(bool enabled)
        {
            buttonItemsSave.Enabled = enabled;
            buttonItemsUpdate.Enabled = !enabled;
            buttonItemsDelete.Enabled = !enabled;
        }

        private void ChangeItemTypeButtonStatus(bool enabled)
        {
            buttonItemTypeSave.Enabled = enabled;
            buttonItemTypeUpdate.Enabled = !enabled;
            buttonItemTypeDelete.Enabled = !enabled;
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
                    textBoxItemsName.Text = String.Empty;
                    textBoxItemsDescription.Text = String.Empty;
                    pictureBoxItems.Image = new Bitmap(1, 1);
                    SetItemId(-1);
                    EnableItemsSaveButton();
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
                    textBoxItemTypeName.Text = String.Empty;
                    textBoxItemTypeDescription.Text = String.Empty;
                    SetItemTypeId(-1);
                    EnableItemTypeSaveButton();
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
                int rowsUpdated = dataBase.ItemTypeDelete(itemTypeId);
                if (rowsUpdated < 1)
                {
                    MessageBox.Show(@"Failed to delete ItemType!", @"Error", MessageBoxButtons.OK,
                                    MessageBoxIcon.Error);
                }
                else
                {
                    textBoxItemTypeName.Text = String.Empty;
                    textBoxItemTypeDescription.Text = String.Empty;
                    SetItemTypeId(-1);
                    EnableItemTypeSaveButton();
                }
                FillItemTypes();
            }
            else
            {
                MessageBox.Show(@"Failed to delete ItemType!", @"Error", MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
        }

        private void ButtonPersonInfoListSelectClick
            (object sender,
             EventArgs e)
        {
            try
            {
                PersonInfo selectedItem = (PersonInfo) listBoxPersonInfoList.SelectedItem;
                if (selectedItem != null)
                {
                    PersonInfo personInfo = dataBase.PersonInfoGet(selectedItem.Id);
                    if (personInfo == null)
                    {
                        Logger.Warn("Failed to get person info for id={0}", selectedItem.Id);
                        return;
                    }
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
                }
                else
                {
                    MessageBox.Show(@"Select an Person!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ButtonOrderPersonInfoSaveClick
            (object sender,
             EventArgs e)
        {
            try
            {
                string name = textBoxPersonInfoName.Text.Trim();
                if (name.Length > 1)
                {
                    PersonInfo personInfoExisting = dataBase.PersonInfoGet(name);
                    if (personInfoExisting != null)
                    {
                        MessageBox.Show(@"PersonInfo with that name already exists!", @"Warn", MessageBoxButtons.OK,
                                        MessageBoxIcon.Stop);
                        return;
                    }
                    PersonInfo personInfo = new PersonInfo
                                            {
                                                Name = name,
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
                    int rowsUpdated = dataBase.PersonInfoInsert(personInfo);
                    if (rowsUpdated < 1)
                    {
                        MessageBox.Show(@"Failed to insert PersonInfo!", @"Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        FillPersonInfo();
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
    }
}