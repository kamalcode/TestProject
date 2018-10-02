using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestProject.DataAccessLayer;
using TestProject.Models;

namespace TestProject.Interfaces
{
   public interface IUnitOfWork
    {
        GenericRepository<Car> CarRepository { get; }
        void Save();

    }
}
