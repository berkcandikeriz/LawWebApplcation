using LawWebSite.Controller;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Security.Policy;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Xml.Linq;

namespace LawWebSite.Management
{
    public partial class SettingsMenu : System.Web.UI.Page
    {
        MenuController menuController = new MenuController();
        LanguageController languageController = new LanguageController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetMenus();
                GetLanguagesByDdlDilSeciniz();
            }


        }
        private void GetLanguagesByDdlDilSeciniz()
        {
            var dilListesi = languageController.GetLanguages();
            DdlMenuDilSeciniz.Items.Clear();
            DdlMenuDilSeciniz.Items.Add(new ListItem() { Text = "Seçiniz", Value = "0" });
            if (!dilListesi.Is_Error && dilListesi != null && dilListesi.Model.Count > 0)
            {
                foreach (var item in dilListesi.Model)
                {
                    DdlMenuDilSeciniz.Items.Add(new ListItem() { Text = item.Name, Value = item.LanguageId.ToString() });

                }
            }
        }

        private void GetMenus()
        {
            var getMenuModel = menuController.GetMenus();
            if (!getMenuModel.Is_Error)
            {
                var sortedMenus = getMenuModel.Model.OrderBy(m => m.Order).ToList();
                RMenus.DataSource = sortedMenus;
                RMenus.DataBind();
            }
        }

        private void Clear()
        {

            DdlMenuDilSeciniz.SelectedIndex = 0;
            txtIsim.Text = string.Empty;
            txtUrl.Text = string.Empty;
            txtSiralama.Text = string.Empty;
            txtKonum.Text = string.Empty;

        }


        protected void lnkAddMenu_Click(object sender, EventArgs e)
        {
            if (Session["selectedMenuItem"] != null)
            {
                Models.Menu selectedMenuItem = Session["selectedMenuItem"] as Models.Menu;
                Models.Menu newMenu = new Models.Menu()
                {
                    MenuId = selectedMenuItem.MenuId,
                    LanguageId = int.Parse(DdlMenuDilSeciniz.SelectedValue),
                    Name = txtIsim.Text,
                    Url = txtUrl.Text,
                    Order = int.Parse(txtSiralama.Text),
                    Location = int.Parse(txtKonum.Text)
                };
                var result = menuController.UpdateMenu(newMenu);

                if (!result.Is_Error)
                {
                    LblMenuModalHeader.Text = "Menu Güncelleme Başarılı";
                    LblMenuModalBody.Text = "Menu başarıyla güncellenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalMenuInformation();", true);

                    GetMenus();
                    Clear();
                    Session["selectedMenuItem"] = null;
                }
                else
                {
                    LblMenuModalHeader.Text = "Menu Güncelleme Başarısız";
                    LblMenuModalBody.Text = "Menu güncelleme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalMenuInformation();", true);
                }
            }

            else
            {
                Models.Menu newMenu = new Models.Menu()
                {
                    LanguageId = int.Parse(DdlMenuDilSeciniz.SelectedValue),
                    Name = txtIsim.Text,
                    Url = txtUrl.Text,
                    Order = int.Parse(txtSiralama.Text),
                    Location = int.Parse(txtKonum.Text)
                };

                var result = menuController.InsertMenu(newMenu);

                if (!result.Is_Error)
                {
                    LblMenuModalHeader.Text = "Menu Ekleme Başarılı";
                    LblMenuModalBody.Text = "Menu başarıyla eklenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalMenuInformation();", true);

                    GetMenus();
                    Clear();
                }
                else
                {
                    LblMenuModalHeader.Text = "Menu Ekleme Başarısız";
                    LblMenuModalBody.Text = "Menu eklerken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalMenuInformation();", true);
                }
            }
        }


        protected void lnkCloseMenu_Click(object sender, EventArgs e)
        {

        }

        protected void LbMenuEdit_Click(object sender, EventArgs e)
        {
            string menuId = ((LinkButton)sender).CommandArgument;
            var result = menuController.GetMenuByMenuId(int.Parse(menuId));
            LblMenuAddEditHeader.Text = menuId + "# Numaralı Menu Güncelle";
            lnkAddMenu.Text = "Menu Güncelle";

            if (!result.Is_Error)
            {
                Models.Menu selectedMenuItem = result.Model[0];
                DdlMenuDilSeciniz.SelectedValue = selectedMenuItem.LanguageId.ToString();
                txtIsim.Text = selectedMenuItem.Name;
                txtUrl.Text = selectedMenuItem.Url;
                txtSiralama.Text = selectedMenuItem.Order.ToString();
                txtKonum.Text = selectedMenuItem.Location.ToString();

                Session["selectedMenuItem"] = selectedMenuItem;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbMenuEditModal();", true);
            }
        }

        protected void LbMenuDelete_Click(object sender, EventArgs e)
        {
            string menuId = (sender as LinkButton).CommandArgument;

            var result = menuController.DeleteMenu(menuId);

            if (!result.Is_Error)
            {
                GetMenus();

                LblMenuModalHeader.Text = "Menu Silme Başarılı";
                LblMenuModalBody.Text = "Menu silme işlemi başarılı";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalMenuInformation();", true);
            }
            else
            {
                LblMenuModalHeader.Text = "Menu Silme Başarısız";
                LblMenuModalBody.Text = "Menu silme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalMenuInformation();", true);
            }
        }

        protected void LbMenuEkle_Click(object sender, EventArgs e)
        { 
                LblMenuAddEditHeader.Text = "Yeni Menu Ekle";
                lnkAddMenu.Text = "Yeni Menu Ekle";

               ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbMenuEditModal();", true);

        }
    }
}