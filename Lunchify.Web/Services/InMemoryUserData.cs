using Lunchify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchify.Data.Services
{
    class InMemoryUserData : IEntityData<User>
    {
        private List<User> users;

        public InMemoryUserData()
        {
            users = new List<User>()
            {
                new User { Id = 1, Name = "Rob" },
                new User { Id = 2, Name = "Mike" },
                new User { Id = 3, Name = "Loz" },
            };
        }

        public User Get(int id)
        {
            return users.FirstOrDefault(u => u.Id == id);
        }

        public IEnumerable<User> GetAll()
        {
            return users.OrderBy(u => u.Name);
        }

        public void Create(User user)
        {
            users.Add(user);
            user.Id = users.Max(u => u.Id) + 1;
        }

        public void Update(User user)
        {
            var existing = Get(user.Id);
            if(existing != null)
            {
                existing.Name = user.Name;
            }
        }

        public void Delete(int id)
        {
            var user = users.FirstOrDefault(u => u.Id == id);
            if (user != null)
            {
                users.Remove(user);
            }
        }
    }
}
