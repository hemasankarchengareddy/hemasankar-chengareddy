using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {

        [HttpGet]
        public ActionResult Get(bool getAll,string applicationId, string type)
        {
            if (Session["SavedData"] != null && getAll != false)
            {
              
                ViewData["id"] = applicationId;
                ViewData["type"] = type;

                TempData["ToShow"] = Session["SavedData"];
            }
            return RedirectToAction("Index");
        }

        [HttpDelete]
        public ActionResult delete(string applicationId)
        {
            if (applicationId != null)
            { Session["SavedData"] = null; }
            return null;
        }
        [HttpPut]
        public ActionResult put(string applicationId)
        {

            return null;
        }
        class allData
        {
            public string id { get; set; }
            public string type { get; set; }
            public string summary { get; set; }
            public decimal amount { get; set; }
            public DateTime postingDate { get; set; }
            public bool isClear { get; set; }
            public DateTime clearDate { get; set; }

        }

        [HttpPost]
        public ActionResult Post(string applicationId,string type, string summary,decimal amount, bool isClear)
        {
            allData obj = new allData();
            obj.id = applicationId;
            obj.type = type;
            obj.summary = summary;
            obj.amount = amount;//0;
            obj.postingDate = DateTime.Now;
            obj.isClear = isClear;//true;
            obj.clearDate = DateTime.Now; //datetime.now;
            Session["SavedData"] = obj;
            return null;
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}