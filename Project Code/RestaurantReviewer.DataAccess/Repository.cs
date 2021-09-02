using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using RestaurantReviewer.DataAccess.Entities;
using RestaurantReviewer.Domain;

namespace RestaurantReviewer.DataAccess
{
    public class Repository : IRepository
    {
        //Establish pathing
        private readonly PojectzeroContext _context;

        public Repository (PojectzeroContext context)
        {
            _context = context;
        }


        //Functionality bellow here
        public List<Domain.Restaurant> GetAllResturaunts()
        {
            return _context.Resturants.Select(
            rest => new Domain.Restaurant(rest.ResturantId, rest.Name, rest.Style, rest.Description, rest.Zip)
            ).ToList();
        }

        // Searching
        /// <summary>
        /// Searches Restaurants by ID or Name

        /// </summary>
        /// <param name="ID">ID the user wishes to search for</param>
        /// <param name="Name">Name of the Restaurant being searched for</param>
        /// <returns>Restaurant Model, Empty if none matching is found</returns>
        public Domain.Restaurant SearchRestaurants(int ID)
        {
            Entities.Resturant foundRest = _context.Resturants
                .FirstOrDefault(rest => rest.ResturantId == ID);

            if (foundRest != null)
            {
                return new Domain.Restaurant(foundRest.ResturantId, foundRest.Name, foundRest.Style, foundRest.Description, foundRest.Zip);
            }
            return new Domain.Restaurant();
        }
        //Overload for name search
        public Domain.Restaurant SearchRestaurants(string Name)
        {
            Entities.Resturant foundRest = _context.Resturants
                .FirstOrDefault(rest => rest.Name == Name);

            if (foundRest != null)
            {
                return new Domain.Restaurant(foundRest.ResturantId, foundRest.Name, foundRest.Style, foundRest.Description, foundRest.Zip);
            }
            return new Domain.Restaurant();
        }
        /// <summary>
        /// Search for a list of Restaurants by Zip or Style
        /// Method to search by average review in BL
        /// </summary>
        /// <returns>List of matching Restaurants</returns>
        public List<Domain.Restaurant> SearchRestaurantList(int Zip)
        {
            List<Domain.Restaurant> restList = GetAllResturaunts();
            List<Domain.Restaurant> foundList = new List<Domain.Restaurant>();
            foreach (Domain.Restaurant rest in restList)
            {
                if (rest.Zip == Zip)
                {
                    foundList.Add(rest);
                }
            }

            return foundList;
        }

        /// <summary>
        /// Searches Restaurants by style, more complex than by zip
        /// Reaches into styles to match string with style ID to match to Restaurants
        /// </summary>
        /// <returns>List of matching Restaurants</returns>       
        public List<Domain.Restaurant> SearchRestaurantList(string Style)
        {
            List<Domain.Restaurant> restList = GetAllResturaunts();
            List<Domain.Restaurant> foundList = new List<Domain.Restaurant>();
            //Match the style to style ID
            Entities.Style foundStyle = _context.Styles
                .FirstOrDefault(style => style.Style1 == Style);

            if (foundStyle != null)
            {
                foreach (Domain.Restaurant rest in restList)
                {
                    if (foundStyle.StyleId == rest.Style)
                    {
                        foundList.Add(rest);
                    }
                }
                return foundList;
            }

            return foundList;
        }


        public List<Domain.User> GetUsers() //This fucntion is restricted to only admin (lvl 2) users
        {
            return _context.Users.Select(
                user => new Domain.User(user.UserId, user.Uname, user.Upass, user.AccessLvl)
            ).ToList();
        }

        /// <summary>
        /// Searches reviews by resturaunt ID, may potentially expand to use name
        /// </summary>
        /// <param name="id">Resturaunt ID to find reviews for</param>
        /// <returns>list of review objects</returns>
        public List<Domain.Review> GetReviews(int id)
        {
            List<Domain.Review> foundList = new List<Domain.Review>();
            List<Domain.Review> reviewList = _context.Reviews.Select(
                rev => new Domain.Review(rev.ReviewId, rev.UserId, rev.ResturantId, rev.Rating, rev.Thoughts)
            ).ToList();

            foreach (Domain.Review rev in reviewList)
            {
                if (rev.RID == id)
                {
                    foundList.Add(rev);
                }
            }
            return foundList;
        }
    }
}
