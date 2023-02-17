using BussinessLayer;
using CodeFirstKatmanliMimari.Models;
using DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstKatmanliMimari.Controllers
{
    public class CategoryController : Controller
    {
        ArticleManager repoArticle = new ArticleManager();
        public ActionResult Index(string CategoryName)
        {
            if (CategoryName == null)
            {
                return RedirectToAction("", "");
            }

            ViewBag.Title = "ERTUNET | " + CategoryName;
            List<ArticleByCategory> _articleByCategory;
            _articleByCategory = (from article in repoArticle.List()
                                  where CategoryName == Utils.UrlDuzenleme.UrlCevir(article.CategoryName).ToLower()
                                  select new ArticleByCategory
                                  {
                                      ArticleCategory = article.CategoryName,
                                      ArticleDate = article.ArticleData,
                                      ArticleReading = article.ReadingCount,
                                      ArticleUrl = article.ArticleUrl,
                                      AuthorName = article.Author,
                                      Content = article.Content,
                                      Title = article.Title,
                                      ImageUrl = article.ImageUrl
                                  }).ToList();

            return View(_articleByCategory);
        }
    }
}