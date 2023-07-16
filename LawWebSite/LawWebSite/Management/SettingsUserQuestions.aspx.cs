using LawWebSite.Controller;
using System;
using System.Linq;
using System.Web.UI;

namespace LawWebSite.Management
{
    public partial class SettingsUserQuestions : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                GetUserLists();
            }
        }

        private void GetUserLists()
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
    }
}
