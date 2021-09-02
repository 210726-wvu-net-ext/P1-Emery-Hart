using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
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
            return View(_repo.GetAllResturaunts());
        }

        // GET: RestaurantController/Reviews/
        // Returns reviews for a restaurant
        
        public ActionResult Reviews(int id)
        {
            List<Review> queryList = _repo.GetReviews(id);
            return View(queryList);
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
