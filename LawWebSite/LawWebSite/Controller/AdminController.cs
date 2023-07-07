using LawWebSite.Common;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawWebSite.Controller
{
    public class AdminController
    {
        /// <summary>
        /// Sistemde bulunan avukat listesini döndüren metod
        /// </summary>
        /// <returns></returns>
        public ReturnModel<Models.Admin> CheckAdminLogin(string Username, string Password)
        {
            ReturnModel<Models.Admin> returnModel = new ReturnModel<Models.Admin>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var admin = ent.Admins.FirstOrDefault(a => a.Username == Username && a.Password == Password);

                    if (admin != null)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = new List<Models.Admin> { admin };
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Giriş Hatası";
                        returnModel.Message_Content = "Geçersiz kullanıcı adı veya şifre";
                        returnModel.Model = null;
                    }
                }
            }
            catch (Exception exc)
            {
                returnModel.Is_Error = true;
                returnModel.Message_Header = "Sistemsel Hata";
                returnModel.Message_Content = "Hata Detayı: " + exc.Message;
                returnModel.Model = null;
            }

            return returnModel;
        }


    }
}