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
    public class AssetGroupsController : Controller
    {
        private Session1Entities db = new Session1Entities();

        public AssetGroupsController()
        {
            db.Configuration.LazyLoadingEnabled = false;
        }

        // POST: AssetGroups
        [HttpPost]
        public ActionResult Index()
        {
            return Json(db.AssetGroups.ToList());
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
