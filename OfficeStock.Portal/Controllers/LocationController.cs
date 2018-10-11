
using Microsoft.AspNet.Identity;
using OfficeStock.Bll.Implamentations;
using OfficeStock.Bll.Interfaces;
using OfficeStock.Common.Enums;
using OfficeStock.Common.Repository;
using OfficeStock.Dal.Interfaces;
using OfficeStock.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace OfficeStock.Portal.Controllers
{
    public class LocationController : BaseController
    {
        public JsonResult UpdateLocationParent(int locationId, int parentId)
        {
            LocationBll bll = new LocationBll();
            Location location = bll.Get(x => x.Id == locationId);
            location.ParentId = parentId;
            bll.Update(location);
            return Json(new { HasError = "false", Messages = "Yer değiştirme başarılı." });
        }


        public JsonResult GetLocationsByParentId(int? parentId)
        {
            int id = parentId == null ? 0 : parentId.Value;
            LocationBll bll = new LocationBll();
            List<Location> list = bll.Gets(location => location.ParentId == id).ToList();

            return Json(list, JsonRequestBehavior.AllowGet);
        }

        public ActionResult Index()
        {
            LocationBll bll = new LocationBll();
            List<Location> list = bll.Gets(x => x.ParentId == 0).ToList();
            return View(list);
        }

        public ActionResult List()
        {
            LocationBll bll = new LocationBll();
            List<Location> list = bll.GetAll().ToList();
            return View(list);
        }

        public JsonResult GetSubMenu(string pid)
        {
            //this action for Get Sub Menus from Database and return  as json data
            List<Location> locations = new List<Location>();
            int pID = 0;
            int.TryParse(pid, out pID);

            locations = new LocationBll().Gets(x => x.ParentId == pID).ToList();
            return new JsonResult { Data = locations, JsonRequestBehavior = JsonRequestBehavior.AllowGet };
        }

        public ActionResult GetLocationList(PagingRequest request)
        {
            var response = new LocationBll().GetLocationList(request);
            return Json(response, JsonRequestBehavior.AllowGet);
        }

        [HttpGet]
        public ViewResult Details(int id)
        {
            LocationBll bll = new LocationBll();
            Location location = bll.Gets(x => x.Id == id).SingleOrDefault();
            return View(location);


        }


        public ActionResult CreateNormalLocation(Location model)
        {
            new LocationBll().Insert(model);
            return RedirectToAction("Index");
        }
        //LocationBll bll = new LocationBll();
        //List<Location> list = bll.GetAll().ToList();
        // List<Location> list = bll.Gets(x=>x.ParentId==0).ToList();
        //return View(list);
        public ActionResult CreateChild(Location model)
        {
            new LocationBll().Insert(model);
            return RedirectToAction("Index");
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
        public ActionResult Create(Location model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.Name))
                    new LocationBll().Insert(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { HasError = true, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }


        public ActionResult Details(Location model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(model);
        }

        [HttpPost]
        public ActionResult CreateLocat(Location model)
        {
            new LocationBll().Insert(model);
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        [HttpGet]
        public ActionResult UpdateLocation(int id)
        {
            Location model = new LocationBll().Get(x => x.Id == id);            
            return Json(model, JsonRequestBehavior.AllowGet);
        }
        
        public ActionResult Update(Location model)
        {
            new LocationBll().Update(model);
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Updatee(int id)
        {
            Location model = new LocationBll().Get(x => x.Id == id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Updatee(Location model)
        {
            try
            {
                new LocationBll().Updatee(model);
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { HasError = true, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

        public ActionResult GetLocationFromId(int Id)
        {
            Location location;
            try
            {
                location = new LocationBll().Get(u => u.Id == Id);
                HasError = false;
            }
            catch
            {
                HasError = true;
                Message = "Kullanıcı kayıt sırasında hata aldı.";
                return Json(new { HasError = base.HasError, Message = base.Message }, JsonRequestBehavior.AllowGet);
            }
            if (location == null)
            {
                HasError = true;
                Message = "Kullanıcı bulunamadı.";
                return Json(new { HasError = base.HasError, Message = base.Message }, JsonRequestBehavior.AllowGet);
            }

            return Json(new { HasError = base.HasError, Result = location }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetComporationListByParentId(Location model)
        {
            return Json(new { HasError = base.HasError, Result = "" }, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetByParentId(int ParentId)
        {
            List<Location> locationList = new LocationBll().GetByParentId(ParentId);

            return Json(locationList, JsonRequestBehavior.AllowGet);
        }

        public ActionResult GetById(int id)
        {
            Location location = new LocationBll().Get(x => x.Id == id);

            return Json(new { HasError = false, Result = location }, JsonRequestBehavior.AllowGet);
        }
        /*
        [HttpPost]
        public ActionResult Delete(int id, Location model)
        {
            var location = new LocationBll().Get(x => x.Id == id);
            if (location != null)
            {

                new LocationBll().Delete(location);


            }
            return RedirectToAction("Index");
        }*/
      
        
        public ActionResult Delete(int locationId)
        {
            new LocationBll().DeleteHierarchy(locationId);
            return RedirectToAction("Index");

        }
        
        public ActionResult Deletee(int id)
        {

            new LocationBll().DeleteById(id);
            return RedirectToAction("Index");

        }
    }
}