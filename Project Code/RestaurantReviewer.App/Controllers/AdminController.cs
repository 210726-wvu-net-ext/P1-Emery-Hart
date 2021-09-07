using Microsoft.AspNetCore.Mvc;
using System;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RestaurantReviewer.Domain;

namespace RestaurantReviewer.App.Controllers
{
    public class AdminController : Controller
    {
        private readonly IRepository _repo;

        public AdminController(IRepository repo)
        {
            _repo = repo;
        }
        public IActionResult Index()
        {
            Log.Information("Admin mode enabled");
            return View(_repo.GetUsers());
        }
    }
}
