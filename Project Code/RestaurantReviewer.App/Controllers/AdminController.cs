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
            Log.Information("Admin mode enabled, userlist fetched");
            return View(_repo.GetUsers());
        }

        // Add user goes here
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddUser(string uName, string uPass, int accessLvl)
        {
            string nUname = "";
            string nPass = "";
            int nAccess = 0;
            
            if (!String.IsNullOrWhiteSpace(uName))
            {
                nUname = uName;
                Log.Debug("NU - Accepted Username");
            }
            else
            {
                Log.Error("NU - (Name) String Empty");
            }

            if (!String.IsNullOrWhiteSpace(uPass))
            {
                nPass = uPass;
                Log.Debug("NU - Accepted Pass");
            }
            else
            {
                Log.Error("NU - (Pass) String Empty");
            }

            if (accessLvl >= 1)
            {
                nAccess = accessLvl;
                Log.Debug("Nu - Accepted Access lvl");
            }
            else
            {
                Log.Error("NU - (Access) out of bounds");
            }

            User nUser = new User(nUname, nPass, nAccess);
            nUser = _repo.AddUser(nUser);
            Log.Information("User add was successful");

            return View("Index");
        }
    }
}
