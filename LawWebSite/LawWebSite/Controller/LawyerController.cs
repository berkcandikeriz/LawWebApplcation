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

        /// <summary>
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
    }
}