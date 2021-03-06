﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using DNL.Models;
using Microsoft.AspNetCore.Authorization;
using BLL.Interfaces;

namespace DNL.Controllers
{
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;
        private readonly ITeacherService _teacherService;

        public HomeController(INewsService newsService, ITeacherService teacherService)
        {
            _newsService = newsService;
            _teacherService = teacherService;
        }

        public IActionResult Index()
        {
            var news = _newsService.GetAll().Reverse().Take(6);
            return View(news);
        }

        public IActionResult About()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        public IActionResult Statut()
        {
            return View();
        }
        public IActionResult License()
        {
            return View();
        }
        public IActionResult Vacancies()
        {
            return View();
        }
        public IActionResult EntryRules()
        {
            return View();
        }
        public IActionResult MethodicalWork()
        {
            var result = _teacherService.GetMethodicalAssociations();
            return View(result);
        }
        public IActionResult EducationalActivities()
        {
            return View();
        }
        public IActionResult Achievements()
        {
            return View();
        }
        public IActionResult WorkPlan()
        {
            return View();
        }
        public IActionResult DirectorMeeting()
        {
            return View();
        }
        public IActionResult Orders()
        {
            return View();
        } 
        public IActionResult FinancialStatements()
        {
            return View();
        }
        public IActionResult PedagogicalMeetings()
        {
            return View();
        }
        public IActionResult LegalFramework()
        {
            return View();
        }
        public IActionResult Guidelines()
        {
            return View();
        }
        public IActionResult PedagogicalCertification()
        {
            return View();
        }
        public IActionResult PedagogicsPerspectivePlan()
        {
            return View();
        }
        public IActionResult NationalPatrioticEducation()
        {
            return View();
        }
        public IActionResult EducationalPrograms()
        {
            return View();
        }
        public IActionResult ActivityReport()
        {
            return View();
        }
        public IActionResult inclination()
        {
            return View();
        }
        public IActionResult CirTimetable()
        {
            return View();
        }
        public IActionResult MaterialBase()
        {
            return View();
        }
        
    }
}

