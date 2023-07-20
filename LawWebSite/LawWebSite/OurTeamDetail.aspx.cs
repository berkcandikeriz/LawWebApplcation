using LawWebSite.Controller;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class OurTeamDetail : System.Web.UI.Page
    {
        LawyerController lawyerController = new LawyerController();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (!string.IsNullOrEmpty(Request.QueryString["LawyerDetailContent"]))
                {
                    int LawyerId = 0;
                    if (int.TryParse(Request.QueryString["LawyerDetailContent"], out LawyerId))
                    {
                        var result = lawyerController.GetLawyerByLawyerId(LawyerId);
                        if (!result.Is_Error)
                        {
                            var SelectedLawyer = result.Model[0];
                            Page.Title = LblLawyerTitle.Text = SelectedLawyer.Title;
                            LblLawyerName.Text = SelectedLawyer.FirstName + " " + SelectedLawyer.LastName;
                            LblLawyerDescription.Text = SelectedLawyer.Description;
                            LblLawyerPhone.Text=SelectedLawyer.PhoneNumber.ToString();
                            LblLawyerInstagram.Text = SelectedLawyer.Instagram;
                            LblLawyerLinkdln.Text = SelectedLawyer.Linkedin;
                            LblLawyerMail.Text = SelectedLawyer.Email;
                            LblLawyerTwitter.Text = SelectedLawyer.Twitter;




                            if (!string.IsNullOrEmpty(SelectedLawyer.ImgUrl.Trim()) && SelectedLawyer.ImgUrl.Trim() != "#")
                            {
                                if (SelectedLawyer.ImgUrl.Contains("http"))
                                {
                                    ImgImageUrl.ImageUrl = SelectedLawyer.ImgUrl;
                                }
                                else
                                {
                                    ImgImageUrl.ImageUrl = "/Assets/Uploads/" + SelectedLawyer.ImgUrl;
                                }
                            }
                            else
                            {
                                ImgImageUrl.ImageUrl = "Assets/images/image_1.jpg";
                            }
                        }
                    }
                }
            }
        }
    }
}