using OdeToFood.Core;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace OdeToFood.Data
{
    public interface IRestaurantData
    {
        IEnumerable<Restaurant> GetRestaurantsByName(string name);
        Restaurant GetRestaurantById(int id);
    }

    public class InMemoryRestaurantData : IRestaurantData
    {
        public List<Restaurant> restaurants { get; private set; }

        public InMemoryRestaurantData()
        {
            restaurants = new List<Restaurant>()
            {
                new Restaurant() { Id = 1, Name = "Marichis", Cuizine = CuizineType.Italian, Location = "Owasso" },
                new Restaurant() { Id = 2, Name = "Chachis", Cuizine = CuizineType.Mexican, Location = "Broken Arrow" },
                new Restaurant() { Id = 3, Name = "Romeshis", Cuizine = CuizineType.Indian, Location = "Tulsa" },
            };
        }

        public Restaurant GetRestaurantById(int id)
        {
            return restaurants.SingleOrDefault(r => r.Id == id);
        }

        public IEnumerable<Restaurant> GetRestaurantsByName(string name = null)
        {
            return from r in restaurants
                   where string.IsNullOrWhiteSpace(name) || r.Name.StartsWith(name)
                   orderby r.Name
                   select r;
        }
    }
}
