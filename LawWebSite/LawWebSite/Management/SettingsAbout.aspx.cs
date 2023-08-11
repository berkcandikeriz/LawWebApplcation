using LawWebSite.Controller;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite.Management
{
    public partial class SettingsAbout : System.Web.UI.Page
    {
        AboutController aboutController = new AboutController();
        LanguageController languageController = new LanguageController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetAbouts();
                GetLanguagesByDdlDilSeciniz();
            }


        }

        private void GetLanguagesByDdlDilSeciniz()
        {
            var dilListesi = languageController.GetLanguages();
            DdlAboutDilSeciniz.Items.Clear();
            DdlAboutDilSeciniz.Items.Add(new ListItem() { Text = "Seçiniz", Value = "0" });
            if (!dilListesi.Is_Error && dilListesi != null && dilListesi.Model.Count > 0)
            {
                foreach (var item in dilListesi.Model)
                {
                    DdlAboutDilSeciniz.Items.Add(new ListItem() { Text = item.Name, Value = item.LanguageId.ToString() });

                }
            }
        }

        private void GetAbouts()
        {
            var getAboutModel = aboutController.GetAbouts();
            if (!getAboutModel.Is_Error)
            {
                var sortedAbouts = getAboutModel.Model.OrderBy(m => m.AboutId).ToList();
                RAbouts.DataSource = sortedAbouts;
                RAbouts.DataBind();
            }
        }

        private void Clear()
        {

            DdlAboutDilSeciniz.SelectedIndex = 0;
            txtAboutIsim.Text = string.Empty;
            Session["AboutImage"] = null;


        }

        protected void lnkCloseMenu_Click(object sender, EventArgs e)
        {

        }

        protected void lnkAddAbout_Click(object sender, EventArgs e)
        {
            if (Session["selectedAboutItem"] != null)
            {
                Models.About selectedAboutItem = Session["selectedAboutItem"] as Models.About;
                string AboutImage = string.Empty;
                if (Session["AboutImage"] != null)
                {
                    AboutImage = Session["AboutImage"].ToString();
                }

                if (FuAboutPhoto.HasFile)
                {
                    string DeleteImagePath = Path.Combine(Server.MapPath("~/Assets/Uploads/"), AboutImage);
                    if (File.Exists(DeleteImagePath))
                        File.Delete(DeleteImagePath);

                    Guid guid = Guid.NewGuid();
                    FileInfo fi = new FileInfo(FuAboutPhoto.FileName);
                    string NewImagePath = Path.Combine(Server.MapPath("~/Assets/Uploads/"), guid + fi.Extension);
                    string NewImageName = guid + fi.Extension;

                    FuAboutPhoto.SaveAs(NewImagePath);
                    AboutImage = NewImageName;
                }
                Models.About newAbout = new Models.About()
                {
                    AboutId = selectedAboutItem.AboutId,
                    LanguageId = int.Parse(DdlAboutDilSeciniz.SelectedValue),
                    AboutDescription = txtAboutIsim.Text,
                    ImageUrl = AboutImage,

                };
                var result = aboutController.UpdateAbout(newAbout);

                if (!result.Is_Error)
                {
                    LblAboutModalHeader.Text = "Hakkımızda Güncelleme Başarılı";
                    LblAboutModalBody.Text = "Hakkımızda başarıyla güncellenmiştir.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalAboutInformation();", true);

                    GetAbouts();
                    Clear();
                    Session["selectedAboutItem"] = null;
                }
                else
                {
                    LblAboutModalHeader.Text = "Hakkımızda Güncelleme Başarısız";
                    LblAboutModalBody.Text = "Hakkımızda güncelleme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                    ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalAboutInformation();", true);
                }
            }
        }

        protected void LbAboutEdit_Click(object sender, EventArgs e)
        {
            string aboutId = ((LinkButton)sender).CommandArgument;
            var result = aboutController.GetAboutByAboutId(int.Parse(aboutId));
            LblAboutAddEditHeader.Text = "Hakkımızda İçeriğini Güncelle";
            lnkAddAbout.Text = "Hakkımızda Güncelle";

            if (!result.Is_Error)
            {
                Models.About selectedAboutItem = result.Model[0];
                DdlAboutDilSeciniz.SelectedValue = selectedAboutItem.LanguageId.ToString();
                txtAboutIsim.Text = selectedAboutItem.AboutDescription;
                Session["AboutImage"] = selectedAboutItem.ImageUrl;


                Session["selectedAboutItem"] = selectedAboutItem;

                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "LbAboutEditModal();", true);
            }
        }
    }
}