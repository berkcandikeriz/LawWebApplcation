using LawWebSite.Common;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace LawWebSite.Controller
{
    public class LawyerController
    {
        /// <summary>
        /// Sistemde bulunan avukat listesini döndüren metod
        /// </summary>
        /// <returns></returns>
        public ReturnModel<Models.Lawyer> GetLawyers()
        {
            ReturnModel<Models.Lawyer> returnModel = new ReturnModel<Models.Lawyer>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getLawyers = ent.Lawyers.ToList();
                    if (getLawyers != null && getLawyers.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getLawyers;
                        goto ReturnPointer;
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Veritabanı Hatası";
                        returnModel.Message_Content = "Veritabanından avukat listesi alınamadı";
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

        public ReturnModel<Models.Lawyer> GetLawyerByLawyerId(int LawyerId)
        {
            ReturnModel<Models.Lawyer> returnModel = new ReturnModel<Models.Lawyer>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getLawyers = ent.Lawyers.Where(x => x.LawyerId == LawyerId).ToList();
                    if (getLawyers != null && getLawyers.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getLawyers;
                        goto ReturnPointer;
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Veritabanı Hatası";
                        returnModel.Message_Content = "Veritabanından avukat listesi alınamadı";
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
        }/// <summary>
         /// Kullanıcı tarafından girilen kullanıcı adı ve şifreye göre admin statüsünde bulunan avukatı döndüren metod
         /// </summary>
         /// <param name="Username">Kullanıcı adı bilgisi</param>
         /// <param name="Password">Şifre bilgisi</param>
         /// <returns></returns>
        public ReturnModel<Models.Lawyer> GetLawyer(string Username, string Password)
        {
            ReturnModel<Models.Lawyer> returnModel = new ReturnModel<Models.Lawyer>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getLawyers = ent.Lawyers.Where(x => x.Email == Username).ToList();
                    if (getLawyers != null && getLawyers.Count > 0)
                    {
                        //Veritabanında kayıtlı olan şifre
                        string PasswordFromDb = getLawyers.FirstOrDefault().Password;

                        #region Şifre Hash'leme İşlemi
                        byte[] encData_byte = new byte[Password.Length];
                        encData_byte = System.Text.Encoding.UTF8.GetBytes(Password);
                        string PasswordEncoded = Convert.ToBase64String(encData_byte);
                        #endregion

                        if (PasswordFromDb == PasswordEncoded)
                        {
                            returnModel.Is_Error = false;
                            returnModel.Message_Header = string.Empty;
                            returnModel.Message_Content = string.Empty;
                            returnModel.Model = getLawyers;
                            goto ReturnPointer;
                        }
                        else
                        {
                            returnModel.Is_Error = true;
                            returnModel.Message_Header = "Şifre Hatalı";
                            returnModel.Message_Content = "Girmiş olduğunuz şifre ile sistemdeki şifre uyuşmadı.";
                            returnModel.Model = null;
                            goto ReturnPointer;
                        }

                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Kullanıcı Bulunamadı";
                        returnModel.Message_Content = Username + " adındaki kullanıcı sistemde bulunamadı.";
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

        public ReturnModel<Models.Lawyer> InsertLawyer(Models.Lawyer model)
        {
            ReturnModel<Models.Lawyer> returnModel = new ReturnModel<Models.Lawyer>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    ent.Lawyers.Add(model);
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
                        returnModel.Message_Content = "Avukatlar veritabanına eklenirken bir hata oluştu.";
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

        public ReturnModel<Models.Lawyer> DeleteLawyer(string lawyerId)
        {
            ReturnModel<Models.Lawyer> returnModel = new ReturnModel<Models.Lawyer>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    int id;
                    if (int.TryParse(lawyerId, out id))
                    {
                        Models.Lawyer lawyer = ent.Lawyers.FirstOrDefault(b => b.LawyerId == id);
                        if (lawyer != null)
                        {
                            ent.Lawyers.Remove(lawyer);
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
                            returnModel.Message_Content = "Belirtilen avukat bulunamadı.";
                            returnModel.Model = null;
                        }
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Hata";
                        returnModel.Message_Content = "AvukatId geçerli bir tamsayı değil.";
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

        public ReturnModel<Models.Lawyer> UpdateLawyer(Models.Lawyer model)
        {
            ReturnModel<Models.Lawyer> returnModel = new ReturnModel<Models.Lawyer>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var selectedLawyerItem = ent.Lawyers.FirstOrDefault(x => x.LawyerId == model.LawyerId);

                    selectedLawyerItem.FirstName = model.FirstName;
                    selectedLawyerItem.LastName = model.LastName;
                    selectedLawyerItem.Title = model.Title;
                    selectedLawyerItem.ImgUrl = model.ImgUrl;
                    selectedLawyerItem.Facebook = model.Facebook;
                    selectedLawyerItem.Twitter = model.Twitter;
                    selectedLawyerItem.Instagram = model.Instagram;
                    selectedLawyerItem.Linkedin = model.Linkedin;
                    selectedLawyerItem.Email = model.Email;
                    selectedLawyerItem.IsAdmin = model.IsAdmin;
                    selectedLawyerItem.Password = model.Password;

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
                        returnModel.Message_Content = "Avukat veritabanına güncellenirken bir hata oluştu.";
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