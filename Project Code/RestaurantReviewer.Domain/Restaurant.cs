using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RestaurantReviewer.Domain
{
    public class Restaurant
    {
        public Restaurant() { }
        public Restaurant(string name)
        {
            this.Name = name;
        }
        public Restaurant(int id, string name, int style, string description, int zip) : this(name)
        {
            this.Id = id;
            this.Style = style;
            this.Zip = zip;
            this.Desc = description;
        }
        public int Id { get; set; }
        public string Name { get; set; }
        public int Style { get; set; }
        public string Desc { get; set; }
        public int Zip { get; set; }
        public List<Review> Reviews { get; set; }
    }
}
