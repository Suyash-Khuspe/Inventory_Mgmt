using Inventory_Mgmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Mgmt.Controllers
{
    public class PurchaseController : Controller
    {
        Inventory_mgmtEntities db = new Inventory_mgmtEntities();
        // GET: Purchase
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DisplayPurchase()
        {
            List<purcahse> list = db.purcahses.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult PurchaseProduct()
        {
            List<string>list=db.products.Select(x=>x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult PurchaseProduct(purcahse pr) 
        {
            db.purcahses.Add(pr);
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult Edit(int id) 
        {
            purcahse p = db.purcahses.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(p); 
        }

        [HttpPost]
        public ActionResult Edit(int id, purcahse pr)
        {
            purcahse pur= db.purcahses.Where(x => x.id == id).SingleOrDefault();
            pur.purchase_prod=pr.purchase_prod;
            pur.purchase_qnty=pr.purchase_qnty;
            pur.purchase_date=pr.purchase_date;
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }

        [HttpGet]
        public ActionResult PurchaseDetails(int id)
        {
            purcahse p = db.purcahses.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(p);
        }

        [HttpGet]
        public ActionResult DeletePurchase(int id)
        {
            purcahse p = db.purcahses.Where(x => x.id == id).SingleOrDefault();
            return View(p);
        }

        [HttpPost]
        public ActionResult DeletePurchase(int id, purcahse pr)
        {
            db.purcahses.Remove(db.purcahses.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplayPurchase");
        }
    }

}