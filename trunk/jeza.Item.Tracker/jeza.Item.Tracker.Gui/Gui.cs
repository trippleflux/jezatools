using System;
using System.Configuration;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using NLog;

namespace jeza.Item.Tracker.Gui
{
    public partial class Gui : Form
    {
        private static Logger Logger = LogManager.GetCurrentClassLogger();
        
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
        }

        private void buttonItemsSave_Click(object sender, EventArgs e)
        {
        }

        private void buttonItemsStatusSave_Click(object sender, EventArgs e)
        {
        }

        private void buttonItemsTypeSave_Click(object sender, EventArgs e)
        {
        }

        private void buttonItemsPictureBoxSelect_Click(object sender, EventArgs e)
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
                    using (Image thumb = bitmap.GetThumbnailImage(250, 250, null, new IntPtr()))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            thumb.Save(memoryStream, ImageFormat.Jpeg);
                            //thumb.Save(@"D:\temp\bugs\gaming\thumbUntitled.png");
                            //byte[] bytes = memoryStream.ToArray();
                        }
                    }
                    textBoxItemsImage.Text = open.FileName;
                }
            }
            catch (Exception exception)
            {
                Logger.Error(exception.StackTrace);
                MessageBox.Show(exception.Message);
            }
        }
    }
}