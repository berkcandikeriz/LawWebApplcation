using LawWebSite.Common;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LawWebSite.Controller
{
    public class BlogController
    {
        /// <summary>
        /// Veritabanındaki tüm blogları listeleyen metod
        /// </summary>
        /// <returns></returns>
        public ReturnModel<Models.Blog> GetBlogs()
        {
            ReturnModel<Models.Blog> returnModel = new ReturnModel<Models.Blog>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getBlogs = ent.Blogs.Include("Language").ToList();
                    if (getBlogs != null && getBlogs.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getBlogs;
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

        /// <summary>
        /// Sistemde seçili olan dile ait blogları listeleyen metod
        /// </summary>
        /// <param name="LanguageId">Dil Id Bilgisi Parametresi</param>
        /// <returns></returns>
        public ReturnModel<Models.Blog> GetBlogsByLanguageId(int LanguageId)
        {
            ReturnModel<Models.Blog> returnModel = new ReturnModel<Models.Blog>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getBlogs = ent.Blogs.Include("Language").Where(x => x.LanguageId == LanguageId).OrderByDescending(x => x.CreatedDate).ToList();
                    if (getBlogs != null && getBlogs.Count > 0)
                    {
                        returnModel.Is_Error = false;
                        returnModel.Message_Header = string.Empty;
                        returnModel.Message_Content = string.Empty;
                        returnModel.Model = getBlogs;
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