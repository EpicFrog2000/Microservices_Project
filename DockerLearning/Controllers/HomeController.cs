using DockerLearning.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using MySqlConnector;
using DockerLearning.Scripts;

namespace DockerLearning.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Home()
        {
            List<string> tables = new List<string>();
            //var _dbContext = new DbContextModel();
            //try
            //{
            //    _dbContext.Database.OpenConnection();
            //
            //    using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            //    {
            //        command.CommandText = "SHOW DATABASES;";
            //        using (var reader = command.ExecuteReader())
            //        {
            //            while (reader.Read())
            //            {
            //                tables.Add(reader.GetString(0));
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    ViewData["Error"] = ex.ToString();
            //}
            //finally
            //{
            //    _dbContext.Database.CloseConnection();
            //}
            ViewData["tables"] = tables;
            ViewBag.CurrentPage = "Home";
            return View();
        }
        public IActionResult About()
        {
            ViewBag.CurrentPage = "About";
            return View();
        }
        public IActionResult Projects()
        {
            ViewBag.CurrentPage = "Projects";
            return View();
        }
        public async Task<IActionResult> GitHub()
        {
            ViewData["githubdata"] = await GithubDataRetriever.GetData();
            ViewBag.CurrentPage = "GitHub";
            return View();
        }
        public IActionResult Youtube()
        {
            ViewBag.CurrentPage = "Youtube";
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}