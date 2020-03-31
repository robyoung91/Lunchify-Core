using Lunchify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchify.Data.Services
{
    public interface IAppData
    {
        IEnumerable<User> GetAllUsers();

        User GetUser(int id);

        void CreateUser(User user);

        void UpdateUser(User user);

        void DeleteUser(int id);

        IEnumerable<Lunch> GetAllLunches();

        Lunch GetLunch(int id);

        void CreateLunch(Lunch lunch);

        void UpdateLunch(Lunch lunch);

        void DeleteLunch(int id);

        IEnumerable<LunchEvent> GetAllLunchEvents();

        LunchEvent GetLunchEvent(int id);

        void CreateLunchEvent(LunchEvent lunchEvent);

        void UpdateLunchEvent(LunchEvent lunchEvent);

        void DeleteLunchEvent(int id);
    }
}
