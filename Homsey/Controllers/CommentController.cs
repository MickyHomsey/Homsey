using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Homsey.BusinessComponents;
using Homsey.Core.BusinessComponents;
using Homsey.Core.Entities;
using Homsey.Models;

namespace Homsey.Controllers
{
  public class CommentController : Controller
  {
    private readonly IDataRepository _dataRepository;

    public CommentController(IDataRepository dataRepostory)
    {
      _dataRepository = dataRepostory;
    }

    public ActionResult Index()
    {
      return View();
    }

    public ActionResult LoadComments()
    {
      var articleExtender = new ArticleExtender();
      var title = articleExtender.GetArticleByTitleUrl(Request.Url.AbsoluteUri);
      var article = _dataRepository.GetPage(title);
      var comments = _dataRepository.GetCommentsByArticle(article.LanguageID, article.BlogID);

      return View(comments);
    }

    [HttpPost]
    public ActionResult AddComment(CommentModel commentModel)
    {
      if (this.ModelState.IsValid)
      {
        ArticleExtender articleExtender = new ArticleExtender();
        var title = articleExtender.GetArticleByTitleUrl(Request.UrlReferrer.AbsoluteUri);

        if (title == null)
        {
          throw new Exception("Page not found");
        }
        
        var pageData = _dataRepository.GetPage(title);
        _dataRepository.AddComment(commentModel.Name, commentModel.Email, commentModel.Remark, pageData.BlogID, pageData.LanguageID);

        return Redirect(Request.UrlReferrer.ToString());
      }

      //TODO: Add in the redirect to the page this it was on with the comment model
      return null;
    }
  }
}
