using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnockAndCheckHF.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListPatients()
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            ViewBag.Patients = DAL.GetPatientList();

            return View();
        }
    }
}