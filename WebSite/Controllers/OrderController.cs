using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebSite.Controllers
{
    public class OrderController : Controller
    {
        Models.Orders db = new Models.Orders();
        // GET: Order
        [Route("payment")]
        public ActionResult Payment()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Payment([Bind(Include ="firstName,cardNumber,Email,EmailConfirm")] Models.Order order)
        {
            if(ModelState.IsValid)
            {
                db.orders.Add(order);
                db.SaveChanges();
                return RedirectToAction("Complete");
            }
            return View(order);
        }

        public string Complete()
        {
            
              return "Null";
        }
    }
}