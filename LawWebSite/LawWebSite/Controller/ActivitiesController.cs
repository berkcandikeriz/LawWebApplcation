using LawWebSite.Common;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawWebSite.Controller
{
    public class ActivitiesController
    {

        /// <summary>
        /// Veritabanındaki tüm Faaliyetleri listeleyen metod
        /// </summary>
        /// <returns></returns>
        /// 

        public ReturnModel<Models.Activity> GetActivities()
        {
            ReturnModel<Models.Activity> returnModel = new ReturnModel<Models.Activity>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getActivities = ent.Activities.Include("Language").ToList();
                    if (getActivities != null && getActivities.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getActivities;
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

        public ReturnModel<Models.Activity> GetActivitiesByActivitiesId(int ActivitiesId)
        {
            ReturnModel<Models.Activity> returnModel = new ReturnModel<Models.Activity>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getActivities = ent.Activities.Where(x => x.ActivitiesId == ActivitiesId).ToList();
                    if (getActivities != null && getActivities.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getActivities;
                        goto ReturnPointer;
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Veritabanı Hatası";
                        returnModel.Message_Content = "Veritabanından Faaliyet listesi alınamadı";
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
        /// Sistemde seçili olan dile ait Faaliyetleri listeleyen metod
        /// </summary>
        /// <param name="LanguageId">Dil Id Bilgisi Parametresi</param>
        /// <returns></returns>
        /// 
        public ReturnModel<Models.Activity> GetActivitiesByLanguageId(int LanguageId)
        {
            ReturnModel<Models.Activity> returnModel = new ReturnModel<Models.Activity>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getActivities = ent.Activities.Include("Language").Where(x => x.LanguageId == LanguageId).OrderBy(x => x.OrderNumber).ToList();
                    if (getActivities != null && getActivities.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getActivities;
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

        public ReturnModel<Models.Activity> InsertActivities(Models.Activity model)
        {
            ReturnModel<Models.Activity> returnModel = new ReturnModel<Models.Activity>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    ent.Activities.Add(model);
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
                        returnModel.Message_Content = "Faaliyet veritabanına eklenirken bir hata oluştu.";
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

        public ReturnModel<Models.Activity> DeleteActivities(string activitiesId)
        {
            ReturnModel<Models.Activity> returnModel = new ReturnModel<Models.Activity>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    int id;
                    if (int.TryParse(activitiesId, out id))
                    {
                        Models.Activity activities = ent.Activities.FirstOrDefault(b => b.ActivitiesId == id);
                        if (activities != null)
                        {
                            ent.Activities.Remove(activities);
                            ent.SaveChanges();

                            returnModel.Is_Error = false;
                            returnModel.Message_Header = string.Empty;
                            returnModel.Message_Content = string.Empty;
                            returnModel.Model = null;
                        }
                        else
                        {
                            returnModel.Is_Error = true;
                            returnModel.Message_Header = "Hata";
                            returnModel.Message_Content = "Belirtilen Faaliyet bulunamadı.";
                            returnModel.Model = null;
                        }
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Hata";
                        returnModel.Message_Content = "ActivitiesId geçerli bir tamsayı değil.";
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

        public ReturnModel<Models.Activity> UpdateActivities(Models.Activity model)
        {
            ReturnModel<Models.Activity> returnModel = new ReturnModel<Models.Activity>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var selectedActivitiesItem = ent.Activities.FirstOrDefault(x => x.ActivitiesId == model.ActivitiesId);

                    selectedActivitiesItem.LanguageId = model.LanguageId;
                    selectedActivitiesItem.BlogTitle = model.BlogTitle;
                    selectedActivitiesItem.Description = model.Description;
                    selectedActivitiesItem.ImageUrl = model.ImageUrl;
                    selectedActivitiesItem.OrderNumber = model.OrderNumber;

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
                        returnModel.Message_Content = "Faaliyet veritabanına güncellenirken bir hata oluştu.";
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