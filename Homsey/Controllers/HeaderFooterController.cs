using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Homsey.Controllers
{
  public class HeaderFooterController : Controller
  {
    // GET: /HeaderFooter/

    public ActionResult Header()
    {
      return PartialView();
    }

    public ActionResult Footer()
    {
      return PartialView();
    }
  }
}
