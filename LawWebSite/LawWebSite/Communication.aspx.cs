using LawWebSite.Common;
using LawWebSite.Controller;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite
{
    public partial class Communication : System.Web.UI.Page
    {
        CommunicationController communicationController = new CommunicationController();
        ContentController contentController = new ContentController();
        QuestionController questionController = new QuestionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetCommunications();
            }

        }

        protected void RCommunication_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (e.Item.ItemType == ListItemType.Item || e.Item.ItemType == ListItemType.AlternatingItem)
            {
                Label lblContactInfo = e.Item.FindControl("LblContactInfo") as Label;
                Label lblWorkHour = e.Item.FindControl("LblWorkHour") as Label;


                if (lblContactInfo != null)
                {
                    ReturnModel<Models.Content> GetContentContactInfo = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblContactInfo");
                    if (GetContentContactInfo != null && !GetContentContactInfo.Is_Error)
                    {
                        var contactInfoDescription = GetContentContactInfo.Model.FirstOrDefault().Description;
                        lblContactInfo.Text = contactInfoDescription;
                    }
                }
                if (lblWorkHour != null)
                {
                    ReturnModel<Models.Content> GetContentWorkHour = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblWorkHour");
                    if (GetContentWorkHour != null && !GetContentWorkHour.Is_Error)
                    {
                        var workHourDescription = GetContentWorkHour.Model.FirstOrDefault().Description;
                        lblWorkHour.Text = workHourDescription;
                    }
                }

            }
        }

        private void GetCommunications()
        {
            ReturnModel<Models.Communication> GetCommunicationList = communicationController.GetCommunicationsByLanguageId(Global.GlobalLanguage.LanguageId);

            if (!GetCommunicationList.Is_Error)
            {
                RMaps.DataSource = GetCommunicationList.Model;
                RMaps.DataBind();

                RCommunication.DataSource = GetCommunicationList.Model;
                RCommunication.DataBind();
            }

            ReturnModel<Models.Content> GetContent = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblSendTitle");
            if (!GetContent.Is_Error)
            {
                LblSendTitle.Text = GetContent.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentKVKK = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblKVKK");
            if (!GetContentKVKK.Is_Error)
            {
                LblKVKK.Text = GetContentKVKK.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentKVKKHeader = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblKVKKHeader");
            if (!GetContentKVKKHeader.Is_Error)
            {
                LblKVKKHeader.Text = GetContentKVKKHeader.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentKVKKContent = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblKVKKContent");
            if (!GetContentKVKKContent.Is_Error)
            {
                LblKVKKContent.Text = GetContentKVKKContent.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentContactForm = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblUserContactForm");
            if (!GetContentContactForm.Is_Error)
            {
                LblUserContactForm.Text = GetContentContactForm.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentContactName = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblUserName");
            if (!GetContentContactName.Is_Error)
            {
                LblUserName.Text = GetContentContactName.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentContactSurname = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblUserSurname");
            if (!GetContentContactSurname.Is_Error)
            {
                LblUserSurname.Text = GetContentContactSurname.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentContactMail = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblUserMail");
            if (!GetContentContactMail.Is_Error)
            {
                LblUserMail.Text = GetContentContactMail.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentContactPhone = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblUserPhone");
            if (!GetContentContactPhone.Is_Error)
            {
                LblUserPhone.Text = GetContentContactPhone.Model.FirstOrDefault().Description;
            }

            ReturnModel<Models.Content> GetContentContactQuestion = contentController.GetContent(Global.GlobalLanguage.LanguageId, "LblUserQuestion");
            if (!GetContentContactQuestion.Is_Error)
            {
                LblUserQuestion.Text = GetContentContactQuestion.Model.FirstOrDefault().Description;
            }

        }

        protected void lnkAddQuestion_Click(object sender, EventArgs e)
        {
            if (IsValid)
            {
                Models.UserList newUserList = new Models.UserList()
                {
                    Name = questionName.Text,
                    Surname = questionSurname.Text,
                    Mail = questionMail.Text,
                    PhoneNumber = questionPhoneNumber.Text,
                    Question = question.Text,
                    CreatedDate = DateTime.Now
                };
                var result = questionController.InsertUserList(newUserList);

                if (!result.Is_Error)
                {
                    questionName.Text = string.Empty;
                    questionSurname.Text = string.Empty;
                    questionMail.Text = string.Empty;
                    questionPhoneNumber.Text = string.Empty;
                    question.Text = string.Empty;
                }
                else
                {
                }
            }
        }
    }
}