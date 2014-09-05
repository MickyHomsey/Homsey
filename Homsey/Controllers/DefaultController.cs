using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Homsey.Core.BusinessComponents;
using Homsey.Core.Entities;
using Homsey.Interfaces;

namespace Homsey.Controllers
{
  public class DefaultController : Controller, IWebController
  {
    public DefaultController(IDataRepository dataRepository)
    {
      ViewBag.RenderCommentController = this.RenderCommentController;
      _dataRepository = dataRepository;
    }

    private IDataRepository _dataRepository;

    public bool RenderCommentController { get; set; }

    // GET: /Default/
    public ActionResult Index()
    {
      ViewBag.Title = "The Index Page";
      
      EnvironmentSettings environmentalSettings = new EnvironmentSettings(_dataRepository);
      var language = environmentalSettings.GetCurrentLanguage(Request.Url.AbsoluteUri);

      var allBlogs = _dataRepository.GetPage(language);
      return PartialView(allBlogs);
    }
  }
}
