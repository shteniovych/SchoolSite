﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BLL.Interfaces;
using BLL.ViewModels;
using DNL.Infrastructure;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace DNL.Controllers
{
    public class NewsController : Controller
    {
        private readonly INewsService _newsService;
        public NewsController(INewsService newsService)
        {
            _newsService = newsService;
        }
        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admins")]
        public ViewResult Index()
        {
            return View(_newsService.GetAll());
        }

        public IActionResult AllNews()
        {
            return View(_newsService.GetAll());
        }

        public IActionResult NewsDetails(int newsId)
        {
            var result = _newsService.Get(newsId);
            return View(result);
        }

        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admins")]
        [HttpGet]
        public ViewResult Create() => View();
        [HttpPost]
        public IActionResult Create(NewsViewModel client)
        {
            if (ModelState.IsValid)
            {
                _newsService.Add(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        [ViewLayout("_ProfileLayout")]
        [Authorize(Roles = "Admins")]
        public ViewResult Edit(int id)
        {
            return View(_newsService.Get(id));
        }
        [HttpPost]
        public IActionResult Edit(NewsViewModel client)
        {
            if (ModelState.IsValid)
            {
                _newsService.Update(client);
                return RedirectToAction("Index");
            }
            return View(client);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            _newsService.Delete(id);
            return RedirectToAction("Index");
        }
    }
}