using AutoFacStudy.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AutoFacStudy.Controllers
{
    public class StudyController : Controller
    {
        IStudy study;
        IStudy2 sutdy2;
        public StudyController(IStudy study,IStudy2 sutdy2) {
            this.study = study;
            this.sutdy2 = sutdy2;
        }
        // GET: Study
        public ActionResult Index()
        {
            ViewBag.study = study.getTest()+ sutdy2.Sutdy2();
            return View();
        }
    }
}