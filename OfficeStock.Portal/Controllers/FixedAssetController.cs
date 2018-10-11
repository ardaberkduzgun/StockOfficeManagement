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
    public class FixedAssetController : Controller
    {
        // GET: FixedAsset
        public ActionResult Index()
        {
            FixedAssetBll bll = new FixedAssetBll();
            List<FixedAsset> list = bll.GetAll().ToList();
            return View(list);
        }


        [HttpGet]
        public ViewResult Details(int id)
        {
            FixedAssetBll bll = new FixedAssetBll();
            FixedAsset fixedAsset = bll.Gets(x => x.Id == id).SingleOrDefault();
            return View(fixedAsset);
        }

        public ActionResult Details(FixedAsset model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {

            new FixedAssetBll().DeleteById(id);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Delete(int id, FixedAsset model)
        {
            var fixedAsset = new FixedAssetBll().Get(x => x.Id == id);
            if (fixedAsset != null)
            {

                new FixedAssetBll().Delete(fixedAsset);


            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            FixedAsset model = new FixedAssetBll().Get(x => x.Id == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(FixedAsset model)
        {
            try
            {
                new FixedAssetBll().Update(model);
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
        public ActionResult Create(FixedAsset model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.Description))
                    new FixedAssetBll().Insert(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { HasError = true, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public JsonResult GetAllGroups()
        {
            List<Group> list = new GroupBll().GetAll().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAllLocations()
        {
            List<Location> list = new LocationBll().GetAll().ToList();
            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetLocationsByParentId(int? parentId)
        {
            int id = parentId == null ? 0 : parentId.Value;
            LocationBll bll = new LocationBll();
            List<Location> list = bll.Gets(location => location.ParentId == id).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

    }
}