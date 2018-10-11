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
    public class BarcodeController : Controller
    {
        // GET: Barcode
        public ActionResult Index()
        {
            BarcodeBll bll = new BarcodeBll();
            List<Barcode> list = bll.GetAll().ToList();
            return View(list);
        }


        [HttpGet]
        public ViewResult Details(int id)
        {
            BarcodeBll bll = new BarcodeBll();
            Barcode barcode = bll.Gets(x => x.Id == id).SingleOrDefault();
            return View(barcode);
        }

        public ActionResult Details(Barcode model)
        {
            if (model == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            return View(model);
        }

        public ActionResult Delete(int id)
        {

            new BarcodeBll().DeleteById(id);
            return RedirectToAction("Index");

        }

        [HttpPost]
        public ActionResult Delete(int id, Barcode model)
        {
            var barcode = new BarcodeBll().Get(x => x.Id == id);
            if (barcode != null)
            {

                new BarcodeBll().Delete(barcode);


            }
            return RedirectToAction("Index");
        }


        [HttpGet]
        public ActionResult Update(int id)
        {
            Barcode model = new BarcodeBll().Get(x => x.Id == id);
            return View(model);
        }

        [HttpPost]
        public ActionResult Update(Barcode model)
        {
            try
            {
                new BarcodeBll().Update(model);
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
        public ActionResult Create(Barcode model)
        {
            try
            {
                if (!string.IsNullOrEmpty(model.code))
                    new BarcodeBll().Insert(model);

                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                return Json(new { HasError = true, Message = ex.Message }, JsonRequestBehavior.AllowGet);
            }
        }

    }
}