using Lunchify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchify.Data.Services
{
    class InMemoryLunchData : IEntityData<Lunch>
    {
        private List<Lunch> lunches;

        public InMemoryLunchData()
        {
            lunches = new List<Lunch>()
            {
                new Lunch {
                            Id = 1,
                            Name = "Pizza",
                            Description = "A margherita pizza with tomato and mozzerella.",
                            Vegetarian = true
                },
                new Lunch {
                            Id = 2,
                            Name = "Fancy Cheeseburger",
                            Description = "A double cheeseburger with ketchup and a brioche bun.",
                            Vegetarian = false
                },
                new Lunch {
                            Id = 3,
                            Name = "Lentil Soup",
                            Description = "Spiced red lentil soup made with onions and coconut milk.",
                            Vegetarian = true
                },
            };
        }

        public Lunch Get(int id)
        {
            return lunches.FirstOrDefault(l => l.Id == id);
        }

        public IEnumerable<Lunch> GetAll()
        {
            return lunches.OrderBy(l => l.Name);
        }

        public void Create(Lunch lunch)
        {
            lunches.Add(lunch);
            lunch.Id = lunches.Max(l => l.Id) + 1;
        }

        public void Update(Lunch lunch)
        {
            var existing = Get(lunch.Id);
            if (existing != null)
            {
                existing.Name = lunch.Name;
                existing.Description = lunch.Description;
                existing.Vegetarian = lunch.Vegetarian;
            }
        }

        public void Delete(int id)
        {
            var lunch = lunches.FirstOrDefault(l => l.Id == id);
            if (lunch != null)
            {
                lunches.Remove(lunch);
            }
        }
    }
}
