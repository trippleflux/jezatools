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
                        string imagePath = textBoxItemsImage.Text.Trim();
                        BinaryReader binaryData = new BinaryReader(new FileStream(imagePath, FileMode.Open, FileAccess.Read));
                        byte[] imageData = new byte[binaryData.BaseStream.Length];
                        binaryData.BaseStream.Read(imageData, 0, Convert.ToInt32(binaryData.BaseStream.Length));
                        item.Image = imageData;
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
                    //pictureBoxItems.ClientSize = new Size(300, 300);
                    Bitmap bitmap = new Bitmap(open.FileName);
                    pictureBoxItems.Image = bitmap;
                    //using (Image thumb = bitmap.GetThumbnailImage(250, 250, null, new IntPtr()))
                    //{
                    //    using (MemoryStream memoryStream = new MemoryStream())
                    //    {
                    //        thumb.Save(memoryStream, ImageFormat.Jpeg);
                    //    }
                    //}
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

        private void ButtonItemsSelectClick(object sender, EventArgs e)
        {
            try
            {
                Item selectedItem = (Item)listBoxItems.SelectedItem;
                if (selectedItem != null)
                {
                    List<Item> items = dataBase.GetItems();
                    Item find = items.Find(item => item.Id == selectedItem.Id);
                    if (find == null)
                    {
                        return;
                    }
                    textBoxItemsNew.Text = find.Name;
                    textBoxItemsItemDescription.Text = find.Description;
                    if (find.Image != null)
                    {
                        MemoryStream memoryStream = new MemoryStream(find.Image);
                        Bitmap bitmap = new Bitmap(memoryStream);
                        pictureBoxItems.Image = bitmap;
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
    }
}