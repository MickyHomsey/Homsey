using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Homsey.Core.Entities;

namespace Homsey.Controllers
{
  public class MenuController : Controller
  {
    public MenuController(IDataRepository dataRepository)
    {
      _dataRepository = dataRepository;
    }

    private IDataRepository _dataRepository;

    // GET: /Menu/
    public ActionResult MainMenu()
    {
      return View(_dataRepository.GetBaseMenuItems());
    }
  }
}
