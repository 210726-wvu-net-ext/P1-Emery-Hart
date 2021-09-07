using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using RestaurantReviewer.Domain;
using RestaurantReviewer.App.Models;

namespace RestaurantReviewer.App.Controllers
{
    public class RestaurantController : Controller
    {
        private readonly IRepository _repo;

        public RestaurantController(IRepository repo)
        {
            _repo = repo;
        }

        // GET: RestaurantController/Index
        // Displays a list of all currently tracked locations
        public ActionResult Index()
        {
            Log.Information("Fetched Resturants list view");
            return View(_repo.GetAllResturaunts());

        }

        // GET: RestaurantController/Reviews/
        // Returns reviews for a restaurant
        public ActionResult Reviews(int id)
        {
            List<Review> queryList = _repo.GetReviews(id);
            Log.Information($"Got reviews for RestID# {id}");
            return View(queryList);
            
        }

        /// <summary>
        /// Search By ID or Name
        /// </summary>
        /// <param name="input">generic input</param>
        /// <returns>A single restaurant object</returns>

        [ValidateAntiForgeryToken]
        public ActionResult SingleSearch(string input)
        {
            int goodIn;
            Restaurant foundRest;
            if (int.TryParse(input, out goodIn))
            {
                foundRest = _repo.SearchRestaurants(goodIn);
                Log.Information("SS - Found by ID");
            }
            else if (input != null)
            {
                foundRest = _repo.SearchRestaurants(input);
                Log.Information("SS - Found by name");
            }
            else
            {
                foundRest = null;
                Log.Debug("SS - Bad input, or type mismatch");
            }
            return View(foundRest);
        }


        public ActionResult ListSearch(string input)
        {
            List<Restaurant> foundList = new List<Restaurant>();
            int goodIn;

            if (int.TryParse(input, out goodIn))
            {
                //Search here
                foundList = _repo.SearchRestaurantList(goodIn);
                Log.Information("LS - Found list by zip");
            }
            else if (input != null)
            {
                //Search here
                foundList = _repo.SearchRestaurantList(input);
                Log.Information("LS - Found list by style");
            }
            else
            {
                foundList = null;
                Log.Debug("LS - Bad input, or type mismatch");
            }
            return View(foundList);
        }

        // GET: RestaurantController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RestaurantController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RestaurantController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: RestaurantController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }


    }
}
