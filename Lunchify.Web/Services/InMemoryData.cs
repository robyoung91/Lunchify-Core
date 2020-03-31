using Lunchify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchify.Data.Services
{
    public class InMemoryData : IAppData
    {
        InMemoryUserData userData;
        InMemoryLunchData lunchData;
        InMemoryLunchEventData lunchEventData;
        
        public InMemoryData()
        {
            userData = new InMemoryUserData();
            lunchData = new InMemoryLunchData();
            lunchEventData = new InMemoryLunchEventData();

            lunchEventData.Create(new LunchEvent
            {
                Id = 1,
                Host = userData.Get(1),
                Lunch = lunchData.Get(1),
                Location = "Piccadilly Gate",
                Capacity = 4,
            });

            lunchEventData.Create(new LunchEvent
            {
                Id = 2,
                Host = userData.Get(2),
                Lunch = lunchData.Get(2),
                Location = "Heaton Moor",
                Capacity = 3,
            });

            lunchEventData.Create(new LunchEvent
            {
                Id = 3,
                Host = userData.Get(3),
                Lunch = lunchData.Get(3),
                Location = "Didsbury",
                Capacity = 6,
            });

            }
        

        public void CreateLunch(Lunch lunch)
        {
            lunchData.Create(lunch);
        }

        public void CreateLunchEvent(LunchEvent lunchEvent)
        {
            lunchEventData.Create(lunchEvent);
        }

        public void CreateUser(User user)
        {
            userData.Create(user);
        }

        public void DeleteLunch(int id)
        {
            lunchData.Delete(id);
        }

        public void DeleteLunchEvent(int id)
        {
            lunchEventData.Delete(id);
        }

        public void DeleteUser(int id)
        {
            userData.Delete(id);
        }

        public IEnumerable<Lunch> GetAllLunches()
        {
            return lunchData.GetAll();
        }

        public IEnumerable<LunchEvent> GetAllLunchEvents()
        {
            return lunchEventData.GetAll();
        }

        public IEnumerable<User> GetAllUsers()
        {
            return userData.GetAll();
        }

        public Lunch GetLunch(int id)
        {
            return lunchData.Get(id);
        }

        public LunchEvent GetLunchEvent(int id)
        {
            return lunchEventData.Get(id);
        }

        public User GetUser(int id)
        {
            return userData.Get(id);
        }

        public void UpdateLunch(Lunch lunch)
        {
            lunchData.Update(lunch);
        }

        public void UpdateLunchEvent(LunchEvent lunchEvent)
        {
            lunchEventData.Update(lunchEvent);
        }

        public void UpdateUser(User user)
        {
            userData.Update(user);
        }
    }
}
