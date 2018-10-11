using Microsoft.Ajax.Utilities;
using OfficeStock.Bll.Implamentations;
using OfficeStock.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace OfficeStock.Portal.Controllers
{
    public class GroupController : Controller
    {
        // GET: Group
        public ActionResult Index()
        {
            GroupBll bll = new GroupBll();
            List<Group> list = bll.GetAll().ToList();
            return View(list);
        }


        [HttpGet]
        public ViewResult Details(int id)
        {
            GroupBll bll = new GroupBll();
            Group group = bll.Gets(x => x.Id == id).SingleOrDefault();
            return View(group);
        }

        public ActionResult Details(Group model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {

            new GroupBll().DeleteById(id);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Delete(int id, Group model)
        {
            var group = new GroupBll().Get(x => x.Id == id);
            if (group != null)
            {

                new GroupBll().Delete(group);

                
            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            Group model = new GroupBll().Get(x => x.Id == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Group model)
        {
            try
            {
                new GroupBll().Update(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { HasError = true, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpGet]
        public ActionResult Create()
        {
            try
            {
                return View();
            }
            catch (Exception ex)
            {
                return Json(new { HasError = true, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
        [HttpPost]
        public ActionResult Create(Group model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.Name))
                    new GroupBll().Insert(model);

                return RedirectToAction("Index");
            }
            catch(Exception ex)
            {
                return Json(new { HasError = true, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }
     
    }
}