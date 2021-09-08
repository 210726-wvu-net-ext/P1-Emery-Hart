using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RestaurantReviewer.Domain
{
    public interface IRepository
    {
        List<Restaurant> GetAllResturaunts();
        //For single return searches (by Name or ID)
        Restaurant SearchRestaurants(int ID);
        Restaurant SearchRestaurants(string Name);

        //For list searches (by ZIP or Style)
        List<Restaurant> SearchRestaurantList(int zip);
        List<Restaurant> SearchRestaurantList(string style);

        List<User> GetUsers(); //Admin restricted function

        List<Review> GetReviews(int ID);

        //Review AddReview(Review nReview);

        User AddUser(User nUser);
    }
}
