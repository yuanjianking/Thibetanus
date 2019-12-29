﻿using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Thibetanus.Areas.Identity.Models;
using Thibetanus.Models;

namespace Thibetanus.Areas.Identity
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        

        //public new DbSet<User> Users { get; set; }
        public new DbSet<ApplicationUser> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
             base.OnModelCreating(builder);
             // Customize the ASP.NET Identity model and override the defaults if needed.
             // For example, you can rename the ASP.NET Identity table names and more.
             // Add your customizations after calling base.OnModelCreating(builder);
        }
    }
}
