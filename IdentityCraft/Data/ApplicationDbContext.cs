﻿using IdentityCraft.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace IdentityCraft.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.Entity<ApplicationUser>().ToTable("Users", "security");
            builder.Entity<IdentityRole>().ToTable("Roles", "security");
            builder.Entity<IdentityUserRole<string>>().ToTable("UserRoles", "security");
            builder.Entity<IdentityUserClaim<string>>().ToTable("UserClaims", "security");
            builder.Entity<IdentityUserLogin<string>>().ToTable("UserLogins", "security");
            builder.Entity<IdentityRoleClaim<string>>().ToTable("Rolelaims", "security");
            builder.Entity<IdentityUserToken<string>>().ToTable("UserTokens", "security");


        }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Review> Reviews { get; set; }
    }
}
