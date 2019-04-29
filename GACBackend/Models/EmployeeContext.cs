using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace GACBackend.Models
{
    public class EmployeeContext :DbContext
    {
        public DbSet<Employee> Employees { get; set; }

        
        public DbSet<Task> Tasks { get; set; }
        
        public DbSet<TimeDetails> TimeDetails { get; set; }

        //public System.Data.Entity.DbSet<GACBackend.Models.ApiConsume> ApiConsumes { get; set; }
    }
}