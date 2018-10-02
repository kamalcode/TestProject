using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TestProject.Models;

namespace TestProject.DataAccessLayer
{
    public class UnitOfWork
    {
        private TestProjectContext dbContext = new TestProjectContext();
        private GenericRepository<Car> carRepository;
        public GenericRepository<Car> CarRepository
        {
            get
            {

                if (this.carRepository == null)
                {
                    this.carRepository = new GenericRepository<Car>(dbContext);
                }
                return carRepository;
            }
        }

        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

    }
}