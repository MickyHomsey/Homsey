using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Homsey.Core.Entities;

namespace Homsey.Controllers
{
  public class CategoryController : Controller
  {
    public CategoryController(IDataRepository dataRepository)
    {
      _dataRepository = dataRepository;
    }

    private IDataRepository _dataRepository;

    // GET: /Category/
    public ActionResult Short()
    {
      return View(_dataRepository.GetCategories());
    }
  }
}
