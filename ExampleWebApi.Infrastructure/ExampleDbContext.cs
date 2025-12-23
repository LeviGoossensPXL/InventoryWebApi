using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using ExampleWebApi.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ExampleWebApi.Infrastructure
{
    public class ExampleDbContext : IdentityDbContext<User, IdentityRole<Guid>, Guid>
    {

        public ExampleDbContext(DbContextOptions<ExampleDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
        {

            base.OnModelCreating(builder);

            builder.Entity<User>().ToTable("Users");
            builder.Entity<IdentityUserClaim<Guid>>().ToTable("UserClaims");
            builder.Entity<IdentityRole<Guid>>().ToTable("Roles");
            builder.Entity<IdentityRoleClaim<Guid>>().ToTable("RoleClaims");
            builder.Entity<IdentityUserRole<Guid>>().ToTable("UserRoles");
            builder.Entity<IdentityUserLogin<Guid>>().ToTable("ExternalLogins");
            builder.Entity<IdentityUserToken<Guid>>().ToTable("UserTokens");


            builder.Entity<Item>().HasData(SeedData.Items);
            builder.Entity<Project>().HasData(SeedData.Projects);
            builder.Entity<Group>().HasData(SeedData.Groups);

            builder.Entity<User>().HasData(SeedData.Users);
            builder.Entity<Person>().HasData(SeedData.Persons);
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Item> Items { get; set; }

    }
}
