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
            GetCommunications();
        }

        private void GetCommunications()
        {
            ReturnModel<Models.Communication> GetCommunicationList = communicationController.GetCommunicationsByLanguageId(Global.GlobalLanguage.LanguageId);

            if (!GetCommunicationList.Is_Error)
            {
                RCommunication.DataSource = GetCommunicationList.Model;
                RCommunication.DataBind();
            }

            var mapModel = contentController.GetContent(Global.GlobalLanguage.LanguageId, "IFrmMap").Model;
            if (mapModel != null && mapModel.Any())
            {
                IFrmMap.Src = mapModel.FirstOrDefault().Description;
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