using LawWebSite.Common;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawWebSite.Controller
{
    public class ServiceController
    {
        /// <summary>
        /// Sistemde bulunan avukat listesini döndüren metod
        /// </summary>
        /// <returns></returns>
        public ReturnModel<Models.Service> GetServices()
        {
            ReturnModel<Models.Service> returnModel = new ReturnModel<Models.Service>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getServices = ent.Services.ToList();
                    if (getServices != null && getServices.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getServices;
                        goto ReturnPointer;
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Veritabanı Hatası";
                        returnModel.Message_Content = "Veritabanından menü listesi alınamadı";
                        returnModel.Model = null;
                        goto ReturnPointer;
                    }
                }
            }
            catch (Exception exc)
            {
                returnModel.Is_Error = true;
                returnModel.Message_Header = "Sistemsel Hata";
                returnModel.Message_Content = "Hata Detayı " + exc.Message;
                returnModel.Model = null;
                goto ReturnPointer;
            }

        ReturnPointer:
            return returnModel;
        }
    }
}