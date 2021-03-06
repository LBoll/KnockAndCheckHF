﻿using KnockAndCheckHF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace KnockAndCheckHF.Controllers
{
    public class SurveyInfo
    {
        public string SurveyID { get; set; }
        public string FormID { get; set; }
        public string Date { get; set; }
        public string Administrator { get; set; }
    }

    public class KnockAndCheckDAL
    {
        KnockAndCheckDBEntities2 ORM = new KnockAndCheckDBEntities2();
        ApplicationDbContext UserORM = new ApplicationDbContext();

        public string GetUserName(string Id)
        {
            return UserORM.Users.Find(Id).UserName;
        }

        public List<Patient> GetPatientList()
        {
            return ORM.Patients.ToList();
        }

        public Form GetForm(string FormID)
        {
            return ORM.Forms.Find(FormID);
        }

        public Form GetFormBySurveyID(string SurveyID)
        {
            return ORM.Forms.Find(ORM.Checkups.Find(SurveyID).FormID);
        }

        public Checkup GetCheckup(string CheckupID)
        {
            return ORM.Checkups.Find(CheckupID);
        }

        public void SaveDSSIForm(string Id, string PatientID, string DateOfVisit, string A1, string A2, string A3, string A4, string A5, string A6, string A7, string A8, string A9, string A10, string A11, int TotalScore)
        {
            string SurveyID = (ORM.Checkups.Count() + 1).ToString();

            ORM.Checkups.Add(new Checkup { Id = Id, PatientID = PatientID, FormID = "DSSI", DateOfVisit = DateOfVisit, A1 = A1, A2 = A2, A3 = A3, A4 = A4, A5 = A5, A6 = A6, A7 = A7, A8 = A8, A9 = A9, A10 = A10, A11 = A11, SurveyID = SurveyID, TotalScore = TotalScore });

            ORM.SaveChanges();
        }

        public void SaveWHO5Form(string Id, string PatientID, string DateOfVisit, string A1, string A2, string A3, string A4, string A5, int TotalScore)
        {
            string SurveyID = (ORM.Checkups.Count() + 1).ToString();

            ORM.Checkups.Add(new Checkup { Id = Id, PatientID = PatientID, FormID = "WHO5", DateOfVisit = DateOfVisit, A1 = A1, A2 = A2, A3 = A3, A4 = A4, A5 = A5, SurveyID = SurveyID, TotalScore = TotalScore });

            ORM.SaveChanges();
        }

        public void SaveEnrollment(string PatientID, string FirstName, string LastName, string DoB, string PhoneNumber, string StreetAddress, string City, string State, string Zip, string PrefferedDay, string PrefferedTime, string StartDate, string StartTime, string EmergencyFirstName, string EmergencyLastName, string EmergencyAddress, string EmergencyPhoneNumber, string EmergencyCity, string EmergencyState, string EmergencyZip, string EmergencyRelationship, string CareGiver)
        {
            KnockAndCheckDAL DAL = new KnockAndCheckDAL();

            ORM.Patients.Add(new Patient { PatientID = PatientID, FirstName = FirstName, LastName = LastName, DoB = DoB, PhoneNumber = PhoneNumber, StreetAddress = StreetAddress, City = City, State = State, Zip = Zip, PrefferedDay = PrefferedDay, PrefferedTime = PrefferedTime, StartDate = StartDate, StartTime = StartTime, EmergencyFirstName = EmergencyFirstName, EmergencyLastName = EmergencyLastName, EmergencyAddress = EmergencyAddress, EmergencyPhoneNumber = EmergencyPhoneNumber, EmergencyCity = EmergencyCity, EmergencyState = EmergencyState, EmergencyZip = EmergencyZip, EmergencyRelationship = EmergencyRelationship, PrimaryCareGiver = CareGiver, EnrollingCareGiver = CareGiver });

            ORM.SaveChanges();
        }

        public void SaveCHECKUPForm(string Id, string PatientID, string DateOfVisit, string A1, string A2, string A3, string A4, string A5)
        {
            string SurveyID = (ORM.Checkups.Count() + 1).ToString();

            ORM.Checkups.Add(new Checkup { Id = Id, PatientID = PatientID, FormID = "CHECKUP", DateOfVisit = DateOfVisit, A1 = A1, A2 = A2, A3 = A3, A4 = A4, A5 = A5, SurveyID = SurveyID });

            ORM.SaveChanges();
        }

        public Patient SpecificPatient(string PatientID)
        {
            return ORM.Patients.Find(PatientID);
        }

        public List<SurveyInfo> GetSurveysByID(string PatientID)
        {
            List<SurveyInfo> surveys = new List<SurveyInfo>();

            List<Checkup> checkups = ORM.Checkups.Where(x => x.PatientID == PatientID).ToList();

            foreach (Checkup checkup in checkups)
            {
                surveys.Add(new SurveyInfo { SurveyID = checkup.SurveyID, FormID = checkup.FormID, Date = checkup.DateOfVisit, Administrator = UserORM.Users.Find(checkup.Id).Email });
            }

            return surveys;
        }
    }
}