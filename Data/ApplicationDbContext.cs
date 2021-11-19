using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using ClientsWebApp.Models;

namespace ClientsWebApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        
        public DbSet<ClientsWebApp.Models.UsersModel> UsersModel { get; set; }
        public DbSet<ClientsWebApp.Models.GainsCategory> GainsCategory { get; set; }
        public DbSet<ClientsWebApp.Models.SpendingCategory> SpendingCategory { get; set; }
        public DbSet<ClientsWebApp.Models.SpendingCategory> Categories { get; set; }
    }
}
