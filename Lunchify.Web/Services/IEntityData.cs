using Lunchify.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lunchify.Data.Services
{
    public interface IEntityData<T>
    {

        IEnumerable<T> GetAll();

        T Get(int id);

        void Create(T obj);

        void Update(T obj);

        void Delete(int id);
    }
}
