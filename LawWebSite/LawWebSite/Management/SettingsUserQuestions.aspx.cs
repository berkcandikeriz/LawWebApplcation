using LawWebSite.Controller;
using System;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LawWebSite.Management
{
    public partial class SettingsUserQuestions : Page
    {
        QuestionController questionController = new QuestionController();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                QuestionLists();
            }
        }

        private void QuestionLists()
        {
            QuestionController questionController = new QuestionController();
            var getUserListModel = questionController.GetUserLists();
            if (!getUserListModel.Is_Error)
            {
                var sortedUserLists = getUserListModel.Model.OrderBy(m => m.UserId).ToList();
                RUserList.DataSource = sortedUserLists;
                RUserList.DataBind();
            }
        }

        protected void LbQuestionDelete_Click(object sender, EventArgs e)
        {
            string userId = (sender as LinkButton).CommandArgument;

            var result = questionController.DeleteQuestion(userId);

            if (!result.Is_Error)
            {
                QuestionLists();

                LblQuestionModalHeader.Text = "Soru Silme Başarılı";
                LblQuestionModalBody.Text = "Soru silme işlemi başarılı";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalQuestionInformation();", true);
            }
            else
            {
                LblQuestionModalHeader.Text = "Soru Silme Başarısız";
                LblQuestionModalBody.Text = "Soru silme işlemi yaparken bir hata ile karşılaşıldı. Daha sonra tekrar deneyiniz.";
                ClientScript.RegisterStartupScript(this.GetType(), "Popup", "PopUpModalQuestionInformation();", true);
            }
        }
    }
}
