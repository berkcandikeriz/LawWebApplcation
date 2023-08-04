using LawWebSite.Controller;
using System;
using System.Collections.Generic;
using System.EnterpriseServices;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class ServiceDetail : System.Web.UI.Page
    {
        ServiceController serviceController = new ServiceController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetServiceDetails();
            }

          
        }

        private void GetServiceDetails()
        {
            if (!string.IsNullOrEmpty(Request.QueryString["ServiceDetailContent"]))
            {
                int ServiceId = 0;
                if (int.TryParse(Request.QueryString["ServiceDetailContent"], out ServiceId))
                {
                    var result = serviceController.GetServiceByServiceId(ServiceId);
                    if (!result.Is_Error)
                    {
                        var SelectedService = result.Model[0];
                        Page.Title = LblServiceHeader.Text = SelectedService.Title;
                        LblCreatedDate.Text = SelectedService.CreatedDate.Value.ToString("d");
                        LblServiceContent.Text = SelectedService.Description;

                        if (!string.IsNullOrEmpty(SelectedService.Image.Trim()) && SelectedService.Image.Trim() != "#")
                        {
                            if (SelectedService.Image.Contains("http"))
                            {
                                ServiceDetailImageUrl.ImageUrl = SelectedService.Image;
                            }
                            else
                            {
                                ServiceDetailImageUrl.ImageUrl = "/Assets/Uploads/" + SelectedService.Image;
                            }
                        }
                        else
                        {
                            ServiceDetailImageUrl.ImageUrl = "Assets/images/aile-siddet.jpg";
                        }
                    }
                }
            }
        }
    }
}