using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Homsey.BusinessComponents;
using Homsey.Core.Contract;

namespace Homsey.Controllers
{
  public class QuotationController : Controller
  {
    public ActionResult Index()
    {
      string url = Request.Url.AbsoluteUri;
      //ILanguage currentLanguage = EnvironmentSettings.GetCurrentLanguage(url);
      //IQuotation[] quotes = CacheQuotation.GetAllCategoriesByLanguage(currentLanguage);
      return View();
    }
  }
}
