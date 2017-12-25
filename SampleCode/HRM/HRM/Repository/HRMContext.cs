using HRM.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace HRM.Repository
{
    public class HRMContext : DbContext
    {
        public HRMContext()
            : base("DefaultConnection")
        {
        }
        public DbSet<Employee> Employees { get; set; }
    }
}