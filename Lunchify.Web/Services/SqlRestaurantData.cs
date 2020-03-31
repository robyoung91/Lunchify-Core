using Lunchify.Data.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchify.Data.Services
{
    public class SqlRestaurantData : IAppData
    {
        private readonly LunchifyDbContext db;

        public SqlRestaurantData(LunchifyDbContext db)
        {
            this.db = db;
        }

        public void CreateLunch(Lunch lunch)
        {
            db.Lunches.Add(lunch);
            db.SaveChanges();
        }

        public void CreateLunchEvent(LunchEvent lunchEvent)
        {
            db.LunchEvents.Add(lunchEvent);
            //lunchEvent.Host.Id = db.Users.FirstOrDefault(user => user.Id == lunchEvent.Host.Id).Id;
            //lunchEvent.Lunch.Id = db.Lunches.FirstOrDefault(lunch => lunch.Id == lunchEvent.Lunch.Id).Id;
            db.SaveChanges();
        }

        public void CreateUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public void DeleteLunch(int id)
        {
            var lunch = db.Lunches.FirstOrDefault(l => l.Id == id);
            db.Lunches.Remove(lunch);
            db.SaveChanges();
        }

        public void DeleteLunchEvent(int id)
        {
            var lunchEvent = db.LunchEvents.FirstOrDefault(l => l.Id == id);
            db.LunchEvents.Remove(lunchEvent);
            db.SaveChanges();
        }

        public void DeleteUser(int id)
        {
            var user = db.Users.FirstOrDefault(l => l.Id == id);
            db.Users.Remove(user);
            db.SaveChanges();
        }

        public IEnumerable<Lunch> GetAllLunches()
        {
            return db.Lunches.OrderBy(l => l.Name);
        }

        public IEnumerable<LunchEvent> GetAllLunchEvents()
        {
            return db.LunchEvents.Include(x => x.Host).Include(x => x.Lunch)
                .OrderBy(l => l.Id);
        }

        public IEnumerable<User> GetAllUsers()
        {
            return db.Users.OrderBy(u => u.Name);
        }

        public Lunch GetLunch(int id)
        {
            return db.Lunches.FirstOrDefault(l => l.Id == id);
        }

        public LunchEvent GetLunchEvent(int id)
        {
            return db.LunchEvents.Include(x => x.Host).Include(x => x.Lunch).FirstOrDefault(l => l.Id == id);
        }

        public User GetUser(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public void UpdateLunch(Lunch lunch)
        {
            var entry = db.Entry(lunch);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateLunchEvent(LunchEvent lunchEvent)
        {
            var entry = db.Entry(lunchEvent);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }

        public void UpdateUser(User user)
        {
            var entry = db.Entry(user);
            entry.State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
