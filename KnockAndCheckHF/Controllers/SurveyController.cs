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

            string CareGiver = User.Identity.GetUserName();

            DAL.SaveEnrollment(PatientID, FirstName, LastName, DoB, PhoneNumber, StreetAddress, City, State, Zip, PrefferedDay, PrefferedTime, StartDate, StartTime, EmergencyFirstName, EmergencyLastName, EmergencyAddress, EmergencyPhoneNumber, EmergencyCity, EmergencyState, EmergencyZip, EmergencyRelationship, CareGiver);

            return View("../Home/Index");
        }

        [Authorize]
        public ActionResult DSSI(string PatientID)
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            ViewBag.PatientID = PatientID;

            ViewBag.Form = DAL.GetForm("DSSI");

            return View();
        }

        [Authorize]
        public ActionResult SaveDSSIForm(string PatientID, string DateOfVisit, string A1, string A2, string A3, string A4, string A5, string A6, string A7, string A8, string A9, string A10, string A11)
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            int TotalScore = int.Parse(A1.Substring(A1.Length - 2, 1)) + int.Parse(A2.Substring(A2.Length - 2, 1)) + int.Parse(A3.Substring(A3.Length - 2, 1)) + int.Parse(A4.Substring(A4.Length - 2, 1)) + int.Parse(A5.Substring(A5.Length - 2, 1)) + int.Parse(A6.Substring(A6.Length - 2, 1)) + int.Parse(A7.Substring(A7.Length - 2, 1)) + int.Parse(A8.Substring(A8.Length - 2, 1)) + int.Parse(A9.Substring(A9.Length - 2, 1)) + int.Parse(A10.Substring(A10.Length - 2, 1)) + int.Parse(A11.Substring(A11.Length - 2, 1));

            DAL.SaveDSSIForm(User.Identity.GetUserId(), PatientID, DateOfVisit, A1, A2, A3, A4, A5, A6, A7, A8, A9, A10, A11, TotalScore);

            return RedirectToAction("WHO5", new { PatientID = PatientID });
        }

        [Authorize]
        public ActionResult WHO5(string PatientID)
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            ViewBag.PatientID = PatientID; 

            ViewBag.Form = DAL.GetForm("WHO5");

            return View();
        }

        [Authorize]
        public ActionResult SaveWHO5Form(string PatientID, string DateOfVisit, string A1, string A2, string A3, string A4, string A5)
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            int TotalScore = int.Parse(A1.Substring(A1.Length - 2, 1)) + int.Parse(A2.Substring(A2.Length - 2, 1)) + int.Parse(A3.Substring(A3.Length - 2, 1)) + int.Parse(A4.Substring(A4.Length - 2, 1)) + int.Parse(A5.Substring(A5.Length - 2, 1));

            DAL.SaveWHO5Form(User.Identity.GetUserId(), PatientID, DateOfVisit, A1, A2, A3, A4, A5, TotalScore);

            return RedirectToAction("SpecificPatient", new { PatientID = PatientID });
        }

        [Authorize]
        public ActionResult CHECKUP(string PatientID)
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            ViewBag.PatientID = PatientID;

            ViewBag.Form = DAL.GetForm("CHECKUP");

            return View();
        }

        [Authorize]
        public ActionResult SaveCHECKUPForm(string PatientID, string DateOfVisit, string A1, string A2, string A3, string A4, string A5)
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            DAL.SaveCHECKUPForm(User.Identity.GetUserId(), PatientID, DateOfVisit, A1, A2, A3, A4, A5);

            return RedirectToAction("SpecificPatient", new { PatientID = PatientID });
        }

        [Authorize]
        public ActionResult ViewSurvey(string SurveyID)
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            ViewBag.Patient = DAL.SpecificPatient(DAL.GetCheckup(SurveyID).PatientID);
            ViewBag.Form = DAL.GetFormBySurveyID(SurveyID);
            ViewBag.Checkup = DAL.GetCheckup(SurveyID);
            ViewBag.UserName = DAL.GetUserName(DAL.GetCheckup(SurveyID).Id);

            return View();
        }

        public ActionResult SpecificPatient(string PatientID)
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            ViewBag.CurrentUser = User.Identity.GetUserName();
            ViewBag.Patient = DAL.SpecificPatient(PatientID);
            ViewBag.Surveys = DAL.GetSurveysByID(PatientID);

            return View("Patient");
        }
    }
}