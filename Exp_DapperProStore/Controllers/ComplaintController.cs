using Exp_DapperProStore.Models;
using Exp_DapperProStore.Reponsitory;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Exp_DapperProStore.Controllers
{
    public class ComplaintController : Controller
    {
        // GET: Complaint
        public ActionResult AddComplaint()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddComplaint(ComplaintModel ObjComp)
        {
            try
            {
                ComplaintRepo Obj = new ComplaintRepo();
                ViewBag.ComplaintId = "Successfully, Your Id: " + Obj.AddComplaint(ObjComp);
            }
            catch (Exception)
            {
                ViewBag.ComplaintId = "error, please check details";
            }
            return View();
        }
    }
}