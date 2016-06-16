using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SaleMandu.dal;
using System.IO;

namespace SaleMandu.Controllers
{
    public class SellManduController : Controller
    {
        private db_salemanduEntities db = new db_salemanduEntities();

        // GET: SellMandu
        public ActionResult Index()
        {
            return View(db.tbl_productDetail.ToList());
        }

        public ActionResult admin()
        {
            return View(db.tbl_productDetail.ToList());
        }
        // GET: SellMandu/Details/5
        [Authorize]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_productDetail tbl_productDetail = db.tbl_productDetail.Find(id);
            if (tbl_productDetail == null)
            {
                return HttpNotFound();
            }
            return View(tbl_productDetail);
        }

        // GET: SellMandu/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SellMandu/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateInput(false)]
        //public ActionResult Create([Bind(Include = "PID,email,mobile_number,product_name,product_location,product_price,product_description,condition,home_delivery,warranty_type,color,features,make_year,bought_time,type,image")] tbl_productDetail tbl_productDetail)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        db.tbl_productDetail.Add(tbl_productDetail);
        //        db.SaveChanges();
        //        return RedirectToAction("Index");
        //    }

        //    return View(tbl_productDetail);
        //}


        public ActionResult Create(tbl_productDetail productDetail, HttpPostedFileBase image)
        {
            if (ModelState.IsValid)
            {
                if (image != null)
                {
                    string filename = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);
                    image.SaveAs(Server.MapPath("~/Image/" + filename));
                    productDetail.image = filename;
                }
                db.tbl_productDetail.Add(productDetail);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(productDetail);
        }








        // GET: SellMandu/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_productDetail tbl_productDetail = db.tbl_productDetail.Find(id);
            if (tbl_productDetail == null)
            {
                return HttpNotFound();
            }
            return View(tbl_productDetail);
        }

        // POST: SellMandu/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "PID,email,mobile_number,product_name,product_location,product_price,product_description,condition,home_delivery,warranty_type,color,features,make_year,bought_time,type,image")] tbl_productDetail tbl_productDetail)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tbl_productDetail).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tbl_productDetail);
        }

        // GET: SellMandu/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            tbl_productDetail tbl_productDetail = db.tbl_productDetail.Find(id);
            if (tbl_productDetail == null)
            {
                return HttpNotFound();
            }
            return View(tbl_productDetail);
        }

        // POST: SellMandu/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            tbl_productDetail tbl_productDetail = db.tbl_productDetail.Find(id);
            db.tbl_productDetail.Remove(tbl_productDetail);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
