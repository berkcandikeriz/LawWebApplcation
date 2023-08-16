using LawWebSite.Common;
using LawWebSite.Controller;
using LawWebSite.Models;
using System;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class Default : System.Web.UI.Page
    {
        private SliderController sliderController = new SliderController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSliders();
            }
        }

        private void GetSliders()
        {
            ReturnModel<Models.Slider> GetSliderList = sliderController.GetSlidersByLanguageId(Global.GlobalLanguage.LanguageId);
            if (!GetSliderList.Is_Error)
            {
                RSliders.DataSource = GetSliderList.Model;
                RSliders.DataBind();
            }
        }

    }
}
