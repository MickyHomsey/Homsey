using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Homsey.Interfaces;

namespace Homsey.Controllers
{
  public class AboutController : Controller, IWebController
  {
    public bool RenderCommentController { get; set; }

    public AboutController()
    {
      ViewBag.RenderCommentController = this.RenderCommentController;
    }

    // GET: /About/
    public ActionResult AboutMe()
    {
      return View();
    }

    public ActionResult ShortMe()
    {
      return View();
    }

    public ActionResult AboutMyBlog()
    {
      return View();
    }

    public ActionResult ContactMe()
    {
      return View();
    }
  }
}
