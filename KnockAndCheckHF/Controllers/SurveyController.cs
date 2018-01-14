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
        public ActionResult Enrollment()
        {
            return View();
        }

        [Authorize]
        public ActionResult SaveEnrollment(string PatientID, string FirstName, string LastName, string DoB, string PhoneNumber, string StreetAddress, string City, string State, string Zip, string PrefferedDay, string PrefferedTime, string StartDate, string StartTime, string EmergencyFirstName, string EmergencyLastName, string EmergencyAddress, string EmergencyPhoneNumber, string EmergencyCity, string EmergencyState, string EmergencyZip, string EmergencyRelationship)
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            DAL.SaveEnrollment(PatientID, FirstName, LastName, DoB, PhoneNumber, StreetAddress, City, State, Zip, PrefferedDay, PrefferedTime, StartDate, StartTime, EmergencyFirstName, EmergencyLastName, EmergencyAddress, EmergencyPhoneNumber, EmergencyCity, EmergencyState, EmergencyZip, EmergencyRelationship);

            return View("../Home/Index");
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

        [Authorize]
        public ActionResult WHO5()
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            ViewBag.Patients = DAL.GetPatientList();

            ViewBag.Form = DAL.GetForm("WHO5");

            return View();
        }

        [Authorize]
        public ActionResult SaveWHO5Form(string PatientID, string DateOfVisit, string A1, string A2, string A3, string A4, string A5)
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            DAL.SaveWHO5Form(User.Identity.GetUserId(), PatientID, DateOfVisit, A1, A2, A3, A4, A5);

            return View("../Home/Index");
        }
    }
}