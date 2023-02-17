using BussinessLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeFirstKatmanliMimari.Controllers
{
    public class ArticleAdminController : Controller
    {
        ArticleManager repoArticle = new ArticleManager();

        public ActionResult Index()
        {
            var model = repoArticle.List();
            return View();
        }

        public ActionResult Delete(int Id)
        {
            var model = repoArticle.GetById(Id);
            repoArticle.Delete(model);
            return RedirectToAction("Index");
        }
    }
}