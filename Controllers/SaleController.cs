using Inventory_Mgmt.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Inventory_Mgmt.Controllers
{
    public class SaleController : Controller
    {
        Inventory_mgmtEntities db = new Inventory_mgmtEntities();
        // GET: Sale
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult DisplaySale()
        {
            List<sale> list = db.sales.OrderByDescending(x => x.id).ToList();
            return View(list);
        }

        [HttpGet]
        public ActionResult SaleProduct()
        {
            List<string> list = db.products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View();
        }

        [HttpPost]
        public ActionResult SaleProduct(sale s)
        {
            db.sales.Add(s);
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {
            sale s = db.sales.Where(x => x.id == id).SingleOrDefault();
            List<string> list = db.products.Select(x => x.product_name).ToList();
            ViewBag.ProductName = new SelectList(list);
            return View(s);
        }

        [HttpPost]
        public ActionResult Edit(int id, sale s)
        {
            sale sale = db.sales.Where(x => x.id == id).SingleOrDefault();
            sale.sale_prod=s.sale_prod;
            sale.sale_qnty=s.sale_qnty;
            sale.sale_date=s.sale_date;
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            sale s = db.sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            sale s = db.sales.Where(x => x.id == id).SingleOrDefault();
            return View(s);
        }

        [HttpPost]
        public ActionResult Delete(int id, sale s)
        {
            db.sales.Remove(db.sales.Where(x => x.id == id).SingleOrDefault());
            db.SaveChanges();
            return RedirectToAction("DisplaySale");
        }
    }
}