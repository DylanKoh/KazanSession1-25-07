using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using KazanSession1_25_07;

namespace KazanSession1_25_07.Controllers
{
    public class AssetsController : Controller
    {
        private Session1Entities db = new Session1Entities();

        public AssetsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // POST: Assets
        [HttpPost]
        public ActionResult Index()
        {
            var assets = db.Assets;
            return Json(assets.ToList());
        }

        // POST: Assets/Details/5
        [HttpPost]
        public ActionResult Details(long? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Asset asset = db.Assets.Find(id);
            if (asset == null)
            {
                return HttpNotFound();
            }
            return View(asset);
        }


        // POST: Assets/Create
        [HttpPost]
        public ActionResult Create([Bind(Include = "ID,AssetSN,AssetName,DepartmentLocationID,EmployeeID,AssetGroupID,Description,WarrantyDate")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Assets.Add(asset);
                db.SaveChanges();
                return Json("Asset created successfully!");
            }
            return Json("Unable to create asset!");
        }


        // POST: Assets/Edit/5
        [HttpPost]
        public ActionResult Edit([Bind(Include = "ID,AssetSN,AssetName,DepartmentLocationID,EmployeeID,AssetGroupID,Description,WarrantyDate")] Asset asset)
        {
            if (ModelState.IsValid)
            {
                db.Entry(asset).State = EntityState.Modified;
                db.SaveChanges();
                return Json("Asset modified successfully!");
            }
            return Json("An unexpected error occured! Please try again later");
        }

        // POST: Assets/Delete/5
        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(long id)
        {
            Asset asset = db.Assets.Find(id);
            db.Assets.Remove(asset);
            db.SaveChanges();
            return Json("Asset deleted successfully!");
        }

        // POST: Assets/GetCustomView
        [HttpPost]
        public ActionResult GetCustomView()
        {
            var customView = (from x in db.Assets
                              join y in db.AssetGroups on x.AssetGroupID equals y.ID
                              join z in db.DepartmentLocations on x.DepartmentLocationID equals z.ID
                              join a in db.Departments on z.DepartmentID equals a.ID
                              select new
                              {
                                  AssetID = x.ID,
                                  AssetName = x.AssetName,
                                  AssetSN = x.AssetSN,
                                  AssetGroup = y.Name,
                                  AssetDepartment = a.Name,
                                  AssetWarrantyDate = x.WarrantyDate
                              });
            return Json(customView.ToList());
        }

        // POST: Assets/GetUniqueSNs
        [HttpPost]
        public ActionResult GetUniqueSNs()
        {
            var listSN = new List<string>();
            listSN = (from x in db.Assets
                      select x.AssetSN).ToList();
            listSN.AddRange((from x in db.AssetTransferLogs
                             select x.FromAssetSN).ToList());
            listSN.AddRange((from x in db.AssetTransferLogs
                             select x.ToAssetSN).ToList());
            return Json(listSN.Distinct());
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
