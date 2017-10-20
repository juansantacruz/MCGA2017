using ASF.Entities;
using ASF.UI.Process;
using ASF.UI.WbSite.Constants.HomeController;
using ASF.UI.WbSite.Services.Cache;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class ClientController : Controller
    {
        // GET: Client
      //  [Route("client", Name = HomeControllerRoute.GetClient)]
        public ActionResult Index()
        {
           // var cp = new ClientProcess();
           // return View(cp.SelectList());

            var lista = DataCache.Instance.ClientList();           
            return View(lista);
        }
    }
}