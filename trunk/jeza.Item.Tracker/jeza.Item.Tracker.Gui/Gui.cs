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
            List<PersonInfo> list = dataBase.GetPersonInfo();
            if (list == null)
            {
                return;
            }
            ComboBox.ObjectCollection items = comboBoxOrderSubscriberPersonInfo.Items;
            items.Clear();
            items.AddRange(list.ToArray());
            comboBoxOrderSubscriberPersonInfo.SelectedItem = items[0];
        }

        private void FillItems()
        {
            Logger.Debug("FillItems");
            List<Item> items = dataBase.GetItems();
            if (items == null)
            {
                return;
            }
            ListBox.ObjectCollection objectCollection = listBoxItems.Items;
            objectCollection.Clear();
            objectCollection.AddRange(items.ToArray());
            FillComboBoxWithItems(items, comboBoxOrderItem);
        }

        private void FillItemTypes()
        {
            Logger.Debug("FillItemTypes");
            List<ItemType> itemTypes = dataBase.GetItemTypes();
            if (itemTypes == null)
            {
                buttonItemsTypeSelect.Enabled = false;
                return;
            }
            FillComboBoxWithItemTypes(itemTypes, comboBoxItemsTypeExisting);
            FillComboBoxWithItemTypes(itemTypes, comboBoxItemsItemType);
            buttonItemsTypeSelect.Enabled = true;
        }

        private static void FillComboBoxWithItems
            (List<Item> list,
             ComboBox comboBox)
        {
            ComboBox.ObjectCollection items = comboBox.Items;
            items.Clear();
            items.AddRange(list.ToArray());
            comboBox.SelectedItem = items[0];
        }

        private static void FillComboBoxWithItemTypes
            (List<ItemType> itemTypes,
             ComboBox comboBox)
        {
            ComboBox.ObjectCollection items = comboBox.Items;
            items.Clear();
            items.AddRange(itemTypes.ToArray());
            comboBox.SelectedItem = items[0];
        }

        private void FillItemStatus()
        {
            Logger.Debug("FillItemStatus");
            List<ItemStatus> list = dataBase.GetItemStatus();
            if (list == null)
            {
                buttonItemsStatusSelect.Enabled = false;
                return;
            }
            FillComboBoxWithItemStatus(list, comboBoxItemsStatusExisting);
            FillComboBoxWithItemStatus(list, comboBoxOrderItemStatus);
            buttonItemsStatusSelect.Enabled = true;
        }

        private static void FillComboBoxWithItemStatus
            (List<ItemStatus> list,
             ComboBox comboBox)
        {
            ComboBox.ObjectCollection items = comboBox.Items;
            items.Clear();
            items.AddRange(list.ToArray());
            comboBox.SelectedItem = items[0];
        }

        private void ButtonItemsSaveClick
            (object sender,
             EventArgs e)
        {
            try
            {
                if (textBoxItemsNew.Text.Length > 1)
                {
                    Item item = new Item
                                {
                                    Name = textBoxItemsNew.Text,
                                    Description = textBoxItemsItemDescription.Text
                                };
                    ItemType selectedItem = (ItemType) comboBoxItemsItemType.SelectedItem;
                    if (selectedItem != null)
                    {
                        item.ItemTypeId = selectedItem.Id;
                    }
                    item.Image = new byte[] {};
                    if (textBoxItemsImage.Text.Length > 1)
                    {
                        item.Image = Misc.GetThumbNailImageData(textBoxItemsImage.Text);
                    }
                    int rowsUpdated = dataBase.InsertItem(item);
                    if (rowsUpdated < 1)
                    {
                        MessageBox.Show(@"Failed to insert Item!", @"Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        FillItems();
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

        private static void ShowError(Exception exception)
        {
            Logger.Error(exception.ToString);
            MessageBox.Show(exception.Message, @"Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void ButtonItemsStatusSaveClick
            (object sender,
             EventArgs e)
        {
            try
            {
                if (textBoxItemsStatusNew.Text.Length > 1)
                {
                    int rowsUpdated = dataBase.InsertItemStatus(textBoxItemsStatusNew.Text.Trim());
                    if (rowsUpdated < 1)
                    {
                        MessageBox.Show(@"Failed to insert ItemStatus!", @"Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        FillItemStatus();
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

        private void ButtonItemsTypeSaveClick
            (object sender,
             EventArgs e)
        {
            try
            {
                if (textBoxItemsTypeNew.Text.Length > 1)
                {
                    int rowsUpdated = dataBase.InsertItemType(textBoxItemsTypeNew.Text.Trim());
                    if (rowsUpdated < 1)
                    {
                        MessageBox.Show(@"Failed to insert ItemType!", @"Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        FillItemTypes();
                    }
                }
                else
                {
                    MessageBox.Show(@"Insert ItemType Name!", @"Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ButtonItemsPictureBoxSelectClick
            (object sender,
             EventArgs e)
        {
            Logger.Debug("Select image...");
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
                    textBoxItemsImage.Text = open.FileName;
                }
            }
            catch (Exception exception)
            {
                ShowError(exception);
            }
        }

        private void ButtonItemsTypeSelectClick
            (object sender,
             EventArgs e)
        {
            textBoxItemsTypeNew.Text = comboBoxItemsTypeExisting.SelectedText;
        }

        private void ButtonItemsSelectClick
            (object sender,
             EventArgs e)
        {
            try
            {
                Item selectedItem = (Item) listBoxItems.SelectedItem;
                if (selectedItem != null)
                {
                    Item item = dataBase.GetItem(selectedItem.Id);
                    if (item == null)
                    {
                        return;
                    }
                    textBoxItemsNew.Text = item.Name;
                    textBoxItemsItemDescription.Text = item.Description;
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

        private void ButtonOrderitemSelectClick
            (object sender,
             EventArgs e)
        {
            try
            {
                Item selectedItem = (Item) comboBoxOrderItem.SelectedItem;
                if (selectedItem != null)
                {
                    Item item = dataBase.GetItem(selectedItem.Id);
                    if (item == null)
                    {
                        return;
                    }
                    pictureBoxOrderItem.Image = new Bitmap(1, 1);
                    if (item.Image != null)
                    {
                        if (item.Image.Length > 0)
                        {
                            MemoryStream memoryStream = new MemoryStream(item.Image);
                            Bitmap bitmap = new Bitmap(memoryStream);
                            pictureBoxOrderItem.Image = bitmap;
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

        private void ButtonOrderSubscriberPersonInfoSelectClick
            (object sender,
             EventArgs e)
        {
            try
            {
                PersonInfo selectedItem = (PersonInfo) comboBoxOrderSubscriberPersonInfo.SelectedItem;
                if (selectedItem != null)
                {
                    PersonInfo personInfo = dataBase.GetPersonInfo(selectedItem.Id);
                    if (personInfo == null)
                    {
                        Logger.Warn("Failed to get person info for id={0}", selectedItem.Id);
                        return;
                    }
                    textBoxOrderPersonInfoName.Text = personInfo.Name;
                    textBoxOrderPersonInfoSurName.Text = personInfo.SurName;
                    textBoxOrderPersonInfoNickName.Text = personInfo.NickName;
                    textBoxOrderPersonInfoDescription.Text = personInfo.Description;
                    textBoxOrderPersonInfoAddress.Text = personInfo.Address;
                    textBoxOrderPersonInfoPopstNumber.Text = personInfo.PostNumber.ToString();
                    textBoxOrderPersonInfoCity.Text = personInfo.City;
                    textBoxOrderPersonInfoEmail.Text = personInfo.Email;
                    textBoxOrderPersonInfoTelephone.Text = personInfo.Telephone;
                    textBoxOrderPersonInfoTelephoneMobile.Text = personInfo.TelephoneMobile;
                    textBoxOrderPersonInfoFaxNumber.Text = personInfo.Fax;
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
                if (textBoxOrderPersonInfoName.Text.Length > 1)
                {
                    PersonInfo personInfo = new PersonInfo
                                            {
                                                Name = textBoxOrderPersonInfoName.Text,
                                                SurName = textBoxOrderPersonInfoSurName.Text,
                                                NickName = textBoxOrderPersonInfoNickName.Text,
                                                Description = textBoxOrderPersonInfoDescription.Text,
                                                Address = textBoxOrderPersonInfoAddress.Text,
                                                PostNumber = Misc.String2Number(textBoxOrderPersonInfoPopstNumber.Text),
                                                City = textBoxOrderPersonInfoCity.Text,
                                                Email = textBoxOrderPersonInfoEmail.Text,
                                                Telephone = textBoxOrderPersonInfoTelephone.Text,
                                                TelephoneMobile = textBoxOrderPersonInfoTelephoneMobile.Text,
                                                Fax = textBoxOrderPersonInfoFaxNumber.Text,
                                            };
                    int rowsUpdated = dataBase.InsertPerson(personInfo);
                    if (rowsUpdated < 1)
                    {
                        MessageBox.Show(@"Failed to insert PersonInfo!", @"Error", MessageBoxButtons.OK,
                                        MessageBoxIcon.Error);
                    }
                    else
                    {
                        FillPersonInfo();
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