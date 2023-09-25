using LawWebSite.Common;
using LawWebSite.Controller;
using LawWebSite.Models;
using System;
using System.Linq;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class Default : System.Web.UI.Page
    {
        private SliderController sliderController = new SliderController();
        ActivitiesController activitiesController = new ActivitiesController();
        ContentController contentController = new ContentController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSliders();
                GetActivities();
                RenderBody();
            }
        }
        private void RenderBody()
        {
            ReturnModel<Models.Content> GetContentActivitiesForm = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblActivities");
            if (!GetContentActivitiesForm.Is_Error)
            {
                LblActivities.Text = GetContentActivitiesForm.Model.FirstOrDefault().Description;
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
        private void GetActivities()
        {
            ReturnModel<Models.Activity> GetActivityList = activitiesController.GetActivitiesByLanguageId(Global.GlobalLanguage.LanguageId);
            if (!GetActivityList.Is_Error)
            {
                RActivities.DataSource = GetActivityList.Model;
                RActivities.DataBind();

            }
        }
    }
}
