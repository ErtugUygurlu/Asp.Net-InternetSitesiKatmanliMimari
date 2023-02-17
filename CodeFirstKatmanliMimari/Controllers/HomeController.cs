using BussinessLayer;
using BussinessLayer.Abstract;
using CodeFirstKatmanliMimari.Models;
using DataEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstKatmanliMimari.Controllers
{
    public class HomeController : Controller
    {
        //Repository<Author> repoAuthor = new Repository<Author>();
        //Repository<Article> repoArticle = new Repository<Article>();
        ArticleManager repoArticle = new ArticleManager();
        AuthorManager repoAuthor = new AuthorManager();
        public ActionResult Index()
        {
            //Test test = new Test();
            var articleList = repoArticle.List();
            ViewBag.Keywords = "Teknoloji, Bilim, Eğlence, Alışveriş, Haberler";
            ViewBag.Description = "1990 yılında Antalya'da kurulan ERTUNET teknoloji şirketi varlığını başarıyla sürdürmektedir.";
            ViewBag.Title = "ERTUNET | Anasayfa";
            return View(articleList);
        }

        public ActionResult Authors()
        {
            var articleList = repoArticle.List();
            var authorList = articleList.GroupBy(u => new { u.Author }).Select(grp => grp.FirstOrDefault()).ToList();
            ViewBag.AuthorList = authorList.ToList();
            return View();
        }

        public ActionResult Detail(string linkUrl)
        {
            if (linkUrl == null)
            {
                return RedirectToAction("", "");
            }
            ViewBag.Title = "Makale | Detay Sayfası";
            ArticleViewModel articleModel = (from article in repoArticle.List()
                                             join author in repoAuthor.List() on article.Author equals author.NameSurname
                                             where article.ArticleUrl == linkUrl
                                             select new ArticleViewModel
                                             {
                                                 //Article
                                                 ArticleUrl = article.ArticleUrl,
                                                 ArticleCategory = article.CategoryName,
                                                 ArticleDate = article.ArticleData,
                                                 Content = article.Content,
                                                 Title = article.Title,
                                                 ArticleReading = article.ReadingCount,
                                                 ArticleTags = article.Tags.Split(','),
                                                 //Author
                                                 AuthorAbout = author.AuthorAbout,
                                                 AuthorFacebook = author.FacebookAdress,
                                                 AuthorImageUrl = author.Image,
                                                 AuthorInstagram = author.Instagram,
                                                 AuthorName = author.NameSurname,
                                                 AuthorTwitter = author.TwitterAdress,

                                             }).FirstOrDefault();
            return View(articleModel);
        }

        public ActionResult TopArticle()
        {
            var articleList = repoArticle.List().OrderByDescending(m => m.ReadingCount).Take(3).ToList();
            return View(articleList);
        }
        public ActionResult InstagramArea()
        {
            return View();
        }

        public ActionResult Advertisement()
        {
            return View();
        }

    }
}