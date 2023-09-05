using LawWebSite.Common;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawWebSite.Controller
{
    public class FaqController
    {

        /// <summary>
        /// Veritabanındaki tüm soruları listeleyen metod
        /// </summary>
        /// <returns></returns>
        /// 
        public ReturnModel<Models.Faq> GetFaqs()
        {
            ReturnModel<Models.Faq> returnModel = new ReturnModel<Models.Faq>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getFaqs = ent.Faqs.Include("Language").ToList();
                    if (getFaqs != null && getFaqs.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getFaqs;
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

        public ReturnModel<Models.Faq> GetFaqByFaqId(int FaqId)
        {
            ReturnModel<Models.Faq> returnModel = new ReturnModel<Models.Faq>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getFaqs = ent.Faqs.Where(x => x.FaqId == FaqId).ToList();
                    if (getFaqs != null && getFaqs.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getFaqs;
                        goto ReturnPointer;
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Veritabanı Hatası";
                        returnModel.Message_Content = "Veritabanından Soru listesi alınamadı";
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
        /// Sistemde seçili olan dile ait soruları listeleyen metod
        /// </summary>
        /// <param name="LanguageId">Dil Id Bilgisi Parametresi</param>
        /// <returns></returns>
        public ReturnModel<Models.Faq> GetFaqsByLanguageId(int LanguageId)
        {
            ReturnModel<Models.Faq> returnModel = new ReturnModel<Models.Faq>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getFaqs = ent.Faqs.Include("Language").Where(x => x.LanguageId == LanguageId).OrderBy(x => x.FaqId).ToList();
                    if (getFaqs != null && getFaqs.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getFaqs;
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

        public ReturnModel<Models.Faq> InsertFaq(Models.Faq model)
        {
            ReturnModel<Models.Faq> returnModel = new ReturnModel<Models.Faq>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    ent.Faqs.Add(model);
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
                        returnModel.Message_Content = "Sorular veritabanına eklenirken bir hata oluştu.";
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

        public ReturnModel<Models.Faq> DeleteFaq(string faqId)
        {
            ReturnModel<Models.Faq> returnModel = new ReturnModel<Models.Faq>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    int id;
                    if (int.TryParse(faqId, out id))
                    {
                        Models.Faq faq = ent.Faqs.FirstOrDefault(b => b.FaqId == id);
                        if (faq != null)
                        {
                            ent.Faqs.Remove(faq);
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
                            returnModel.Message_Content = "Belirtilen soru bulunamadı.";
                            returnModel.Model = null;
                        }
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Hata";
                        returnModel.Message_Content = "FaqId geçerli bir tamsayı değil.";
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

        public ReturnModel<Models.Faq> UpdateFaq(Models.Faq model)
        {
            ReturnModel<Models.Faq> returnModel = new ReturnModel<Models.Faq>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var selectedFaqItem = ent.Faqs.FirstOrDefault(x => x.FaqId == model.FaqId);

                    selectedFaqItem.LanguageId = model.LanguageId;
                    selectedFaqItem.Url = model.Url;
                    selectedFaqItem.Question = model.Question;
                    selectedFaqItem.Answer = model.Answer;
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
                        returnModel.Message_Content = "Faq veritabanına güncellenirken bir hata oluştu.";
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