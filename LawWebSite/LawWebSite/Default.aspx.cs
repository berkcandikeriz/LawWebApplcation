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
       ServiceController serviceController = new ServiceController();
        ContentController contentController = new ContentController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetSliders();
                GetServices();
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
        protected void RHomeServices_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblReadMore = e.Item.FindControl("LblReadMore") as Label;

                if (lblReadMore != null)
                {
                    ReturnModel<Models.Content> GetContentReadMore = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblReadMore");

                    if (GetContentReadMore != null && !GetContentReadMore.Is_Error)
                    {
                        var readMoreDescription = GetContentReadMore.Model.FirstOrDefault().Description;
                        lblReadMore.Text = readMoreDescription;
                    }
                }
            }
        }
        private void GetServices()
        {
            ReturnModel<Models.Service> GetServiceList = serviceController.GetServices();
            if (!GetServiceList.Is_Error)
            {
                RHomeServices.DataSource = GetServiceList.Model;
                RHomeServices.DataBind();
            }
        }
    }
}
