using ASF.Entities;
using ASF.UI.Process;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ASF.UI.WbSite.Controllers
{
    public class OrderController : Controller
    {
        // GET: Order
        public ActionResult Index()
        {
            var cp = new OrderProcess();
            return View(cp.SelectList());
        }

        public ActionResult Create()
        {
            var client = new ClientProcess().SelectList();

            ViewBag.Client = new SelectList(client, "Id", "FirstName");

            return View();
        }
        [HttpPost]
        public ActionResult Create(Order order, string Client)
        {
            try
            {
                var op = new OrderProcess();

                order.ClientId = Int32.Parse(Client);

                op.insertOrder(order);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        
        //#region Create jquery - autocomplete
        //public JsonResult GetClients(string Areas, string term = "")
        //{
        //    var empleados = from client in db.Client
        //                    where client.LastName.StartsWith(term)
        //                    select new { client.LastName, client.FirstName, client.Id };
        //    return Json(empleados, JsonRequestBehavior.AllowGet);
        //}
    }
}