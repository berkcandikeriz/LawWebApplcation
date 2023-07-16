using LawWebSite.Common;
using LawWebSite.Models;
using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawWebSite.Controller
{
    public class LanguageController
    {
        /// <summary>
        /// Veritabanındaki tüm dilleri listeleyen metod
        /// </summary>
        /// <returns></returns>
        public ReturnModel<Models.Language> GetLanguages()
        {
            ReturnModel<Models.Language> returnModel = new ReturnModel<Models.Language>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    var getMenus = ent.Languages.ToList();
                    if (getMenus != null && getMenus.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getMenus;
                        goto ReturnPointer;
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Veritabanı Hatası";
                        returnModel.Message_Content = "Veritabanından dil listesi alınamadı";
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

        /// <summary>
        /// ID Bilgisi verilen dili/dilleri listeleyen metod
        /// </summary>
        /// <param name="LangaugeId">Dil Id Bilgisi Parametresi</param>
        /// <returns></returns>
        public ReturnModel<Models.Language> GetLanguageByLanguageId(int LangaugeId)
        {
            ReturnModel<Models.Language> returnModel = new ReturnModel<Models.Language>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getMenus = ent.Languages.Where(x => x.LanguageId == LangaugeId).ToList();
                    if (getMenus != null && getMenus.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getMenus;
                        goto ReturnPointer;
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Veritabanı Hatası";
                        returnModel.Message_Content = "Veritabanından dil listesi alınamadı";
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

        public ReturnModel<Models.Language> InsertLanguage(Models.Language model)
        {
            ReturnModel<Models.Language> returnModel = new ReturnModel<Models.Language>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var existingLanguage = ent.Languages.FirstOrDefault(l => l.Name == model.Name);
                    if (existingLanguage == null)
                    {
                        ent.Languages.Add(model);
                        int affectedRows = ent.SaveChanges();
                        if (affectedRows > 0)
                        {
                            returnModel.Is_Error = false;
                            returnModel.Message_Header = string.Empty;
                            returnModel.Message_Content = string.Empty;
                            returnModel.Model = null;
                        }
                        else
                        {
                            returnModel.Is_Error = true;
                            returnModel.Message_Header = "Veritabanı Hatası";
                            returnModel.Message_Content = "Dil veritabanına eklenirken bir hata oluştu.";
                            returnModel.Model = null;
                        }
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Hata";
                        returnModel.Message_Content = "Bu isimde bir dil zaten mevcut.";
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