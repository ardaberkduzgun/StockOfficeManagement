using OfficeStock.Bll.Implamentations;
using OfficeStock.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;


namespace OfficeStock.Portal.Controllers
{
    public class TreeviewController : Controller
    {
        // GET: Treeview
      public ActionResult OnDemand()
        {
            List<Location> all = new List<Location>();
            all = new LocationBll().Gets(x => x.ParentId == 0).ToList();
            return View(all);
        }
        public JsonResult GetSubMenu(string pid)
        {
            //this action for Get Sub Menus from Database and return  as json data
            List<Location> locations = new List<Location>();
            int pID = 0;
            int.TryParse(pid, out pID);

            //locations = new LocationBll().GetAll().ToList();
            locations = new LocationBll().Gets(x => x.ParentId==pID).OrderBy(a => a.Name).ToList();
            
            return new JsonResult { Data= locations , JsonRequestBehavior= JsonRequestBehavior.AllowGet};
        }
    }
}