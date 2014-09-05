using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

using Homsey.BusinessComponents;
using Homsey.Core.BusinessComponents;
using Homsey.Core.Contract;
using Homsey.Core.Entities;
using Homsey.Interfaces;

namespace Homsey.Controllers
{
  public class ArticleController : Controller, IWebController
  {
    public ArticleController(IDataRepository dataRepositoy)
    {
      this._dataRepositoy = dataRepositoy;
      this.RenderCommentController = true;
      ViewBag.RenderCommentController = this.RenderCommentController;
    }

    private IPageContentView _pageData;
    private IDataRepository _dataRepositoy;

    public bool RenderCommentController { get; set; }

    // GET: /Article/
    public ActionResult Index()
    {
      if (HasValidArticle())
      {
        return View(_pageData);
      }

      return RedirectToAction("Index", "Default");
    }

    private bool HasValidArticle()
    {
      var articleExtendor = new ArticleExtender();
      var title = articleExtendor.GetArticleByTitleUrl(Request.Url.AbsolutePath);
      _pageData = _dataRepositoy.GetPage(title);
      
      if (_pageData == null)
      {
        return false;
      }
      
      return true;
    }
  }
}
