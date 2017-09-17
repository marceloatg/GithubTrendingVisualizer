﻿using Microsoft.AspNetCore.Mvc;

namespace GithubTrendingVisualizer.Controllers
{
    [Route("[controller]")]
    public class RepositoriesController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        [Route("[action]")]
        public IActionResult Saved()
        {
            return View();
        }
    }
}