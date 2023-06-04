using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawWebSite.Controller
{
    public class CommonController
    {
        LanguageController languageController = new LanguageController();

        /// <summary>
        /// Uygulama ayağa kalktığında varsayılan dil nesnesi set edilir.
        /// </summary>
        public void SetLanguage()
        {
            try
            {
                Models.Language GetLanguage = new Models.Language();

                if (Global.GlobalLanguage.LanguageId != 0)
                {
                    GetLanguage = languageController.GetLanguageByLanguageId(Global.GlobalLanguage.LanguageId).Model.FirstOrDefault();
                }
                else
                { 
                    GetLanguage = languageController.GetLanguages().Model.FirstOrDefault(x => x.Name == "Türkçe");
                }

                Global.GlobalLanguage = GetLanguage;
            }
            catch (Exception exc)
            {
                
            }
        }
    }
}