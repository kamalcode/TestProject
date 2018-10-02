using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TestProject.Models;

namespace TestProject.DataAccessLayer
{
    public class TestProjectContext: DbContext
    {
        public DbSet<Car> Cars { get; set; }

    }
}