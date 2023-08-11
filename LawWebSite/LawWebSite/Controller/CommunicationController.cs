using LawWebSite.Common;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawWebSite.Controller
{
    public class CommunicationController
    {
        /// <summary>
        /// Veritabanındaki tüm İletişim bilgilerinilisteleyen metod
        /// </summary>
        /// <returns></returns>
        public ReturnModel<Models.Communication> GetCommunications()
        {
            ReturnModel<Models.Communication> returnModel = new ReturnModel<Models.Communication>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getCommunications = ent.Communications.Include("Language").ToList();
                    if (getCommunications != null && getCommunications.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getCommunications;
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
        public ReturnModel<Models.Communication> GetCommunicationByCommunicationId(int CommunicationId)
        {
            ReturnModel<Models.Communication> returnModel = new ReturnModel<Models.Communication>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getCommunications = ent.Communications.Where(x => x.CommunicationId == CommunicationId).ToList();
                    if (getCommunications != null && getCommunications.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getCommunications;
                        goto ReturnPointer;
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Veritabanı Hatası";
                        returnModel.Message_Content = "Veritabanından İletişim listesi alınamadı";
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
        /// Sistemde seçili olan dile ait İletişimleri listeleyen metod
        /// </summary>
        /// <param name="LanguageId">Dil Id Bilgisi Parametresi</param>
        /// <returns></returns>
        public ReturnModel<Models.Communication> GetCommunicationsByLanguageId(int LanguageId)
        {
            ReturnModel<Models.Communication> returnModel = new ReturnModel<Models.Communication>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getCommunications = ent.Communications.Include("Language").Where(x => x.LanguageId == LanguageId).OrderBy(x => x.CommunicationId).ToList();
                    if (getCommunications != null && getCommunications.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getCommunications;
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
        public ReturnModel<Models.Communication> DeleteCommunication(string communicationId)
        {
            ReturnModel<Models.Communication> returnModel = new ReturnModel<Models.Communication>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    int id;
                    if (int.TryParse(communicationId, out id))
                    {
                        Models.Communication communication = ent.Communications.FirstOrDefault(b => b.CommunicationId == id);
                        if (communication != null)
                        {
                            ent.Communications.Remove(communication);
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
                            returnModel.Message_Content = "Belirtilen Communication bulunamadı.";
                            returnModel.Model = null;
                        }
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Hata";
                        returnModel.Message_Content = "CommunicationId geçerli bir tamsayı değil.";
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

        public ReturnModel<Models.Communication> UpdateCommunication(Models.Communication model)
        {
            ReturnModel<Models.Communication> returnModel = new ReturnModel<Models.Communication>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var selectedCommunicationItem = ent.Communications.FirstOrDefault(x => x.CommunicationId == model.CommunicationId);

                    selectedCommunicationItem.LanguageId = model.LanguageId;
                    selectedCommunicationItem.Address = model.Address;
                    selectedCommunicationItem.PhoneNumber = model.PhoneNumber;
                    selectedCommunicationItem.MapUrl = model.MapUrl;
                    selectedCommunicationItem.Mail = model.Mail;
                    selectedCommunicationItem.MidWeek = model.MidWeek;
                    selectedCommunicationItem.Saturday = model.Saturday;
                    selectedCommunicationItem.Sunday = model.Sunday;

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
                        returnModel.Message_Content = "Communication veritabanına güncellenirken bir hata oluştu.";
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