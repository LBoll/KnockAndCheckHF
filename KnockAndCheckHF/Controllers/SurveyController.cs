using Microsoft.AspNet.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KnockAndCheckHF.Controllers
{
    public class SurveyController : Controller
    {
        // GET: Survey
        public ActionResult Index()
        {
            return View();
        }

        [Authorize]
        public ActionResult DSSI()
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            ViewBag.Patients = DAL.GetPatientList();

            ViewBag.Form = DAL.GetForm("DSSI");

            return View();
        }

        [Authorize]
        public ActionResult SaveDSSIForm(string PatientID, string DateOfVisit, string A1, string A2, string A3, string A4, string A5, string A6, string A7, string A8, string A9, string A10, string A11)
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            DAL.SaveDSSIForm(User.Identity.GetUserId(), PatientID, DateOfVisit, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11);

            return View("../Home/Index");
        }
    }
}