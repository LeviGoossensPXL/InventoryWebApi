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
            builder.Entity<GroupItem>().HasKey(gi => new { gi.GroupId, gi.ItemId });
            builder.Entity<GroupProject>().HasKey(gi => new { gi.GroupId, gi.ProjectId });
            builder.Entity<GroupUser>().HasKey(gi => new { gi.GroupId, gi.UserId });
        }

        public DbSet<Project> Projects { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<GroupItem> GroupItems { get; set; }
        public DbSet<GroupProject> GroupProjects { get; set; }
        public DbSet<GroupUser> GroupUsers { get; set; }
    }
}
