using LawWebSite.Common;
using LawWebSite.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

        public ReturnModel<Models.Blog> GetBlogByBlogId(int BlogId)
        {
            ReturnModel<Models.Blog> returnModel = new ReturnModel<Models.Blog>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var getBlogs = ent.Blogs.Where(x => x.BlogId == BlogId).ToList();
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
                        returnModel.Message_Content = "Veritabanından blog listesi alınamadı";
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

                    var getBlogs = ent.Blogs.Include("Language").Where(x => x.LanguageId == LanguageId).OrderBy(x => x.OrderNumber).ToList();
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

        public ReturnModel<Models.Blog> InsertBlog(Models.Blog model)
        {
            ReturnModel<Models.Blog> returnModel = new ReturnModel<Models.Blog>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    ent.Blogs.Add(model);
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
                        returnModel.Message_Content = "Blog veritabanına eklenirken bir hata oluştu.";
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

        public ReturnModel<Models.Blog> DeleteBlog(string blogId)
        {
            ReturnModel<Models.Blog> returnModel = new ReturnModel<Models.Blog>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    int id;
                    if (int.TryParse(blogId, out id))
                    {
                        Models.Blog blog = ent.Blogs.FirstOrDefault(b => b.BlogId == id);
                        if (blog != null)
                        {
                            ent.Blogs.Remove(blog);
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
                            returnModel.Message_Content = "Belirtilen blog bulunamadı.";
                            returnModel.Model = null;
                        }
                    }
                    else
                    {
                        returnModel.Is_Error = true;
                        returnModel.Message_Header = "Hata";
                        returnModel.Message_Content = "BlogId geçerli bir tamsayı değil.";
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

        public ReturnModel<Models.Blog> UpdateBlog(Models.Blog model)
        {
            ReturnModel<Models.Blog> returnModel = new ReturnModel<Models.Blog>();

            try
            {
                using (DBLAW23Entities ent = new DBLAW23Entities())
                {
                    ent.Configuration.LazyLoadingEnabled = false;
                    ent.Configuration.ProxyCreationEnabled = false;

                    var selectedBlogItem = ent.Blogs.FirstOrDefault(x=> x.BlogId == model.BlogId);

                    selectedBlogItem.LanguageId = model.LanguageId;
                    selectedBlogItem.BlogTitle = model.BlogTitle;
                    selectedBlogItem.BlogSubtitle = model.BlogSubtitle;
                    selectedBlogItem.Description = model.Description;
                    selectedBlogItem.Author = model.Author;
                    selectedBlogItem.Url = model.Url;
                    selectedBlogItem.ImageUrl = model.ImageUrl;
                    selectedBlogItem.CreatedDate = model.CreatedDate;
                    selectedBlogItem.UpdateDate = model.UpdateDate;
                    selectedBlogItem.OrderNumber = model.OrderNumber;

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
                        returnModel.Message_Content = "Blog veritabanına güncellenirken bir hata oluştu.";
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