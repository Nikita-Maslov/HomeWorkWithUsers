using System;
using System.Runtime.ConstrainedExecution;
using AppDAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace AppDAL.EF {

    public class AppDBContext : DbContext {

        public DbSet<User> Users { get; set; } 
        public DbSet<MyTask> Tasks { get; set; } 

        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) {
            Database.EnsureCreated();
        }

       

    }
}

