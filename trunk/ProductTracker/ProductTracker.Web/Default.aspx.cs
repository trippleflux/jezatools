using System;

namespace ProductTracker.Web
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            ShowItems();
            if (!IsPostBack)
            {
                PopulateItems();
            }
        }

        private void PopulateItems()
        {
            ShowItems();
        }

        private void PopulateShops()
        {
            ShowShops();
        }

        private void ShowItems()
        {
            GridViewItems.Visible = true;
            GridViewShops.Visible = false;
        }

        private void ShowShops()
        {
            GridViewItems.Visible = false;
            GridViewShops.Visible = true;
        }

        protected void LinkButtonShops_Click(object sender, EventArgs e)
        {
            PopulateShops();
        }

        protected void LinkButtonItems_Click(object sender, EventArgs e)
        {
            PopulateItems();
        }
    }
}