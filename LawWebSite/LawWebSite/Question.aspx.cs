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
    public partial class Question : System.Web.UI.Page
    {
        QuestionController questionController = new QuestionController();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void lnkAddQuestion_Click(object sender, EventArgs e)
        {
            Models.UserList newUserList = new Models.UserList()
            {


                Name = questionName.Text,
                Surname = questionSurname.Text,
                Mail = questionMail.Text,
                PhoneNumber = questionPhoneNumber.Text,
                Question = question.Text,
                CreatedDate = DateTime.Today

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
                // Hata durumunda uygun işlemleri gerçekleştirin
            }

        }
    }
}