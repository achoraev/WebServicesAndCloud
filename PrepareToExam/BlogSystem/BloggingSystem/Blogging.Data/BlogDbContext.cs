namespace Blogging.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Blogging.Data.Migrations;
    using Blogging.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BlogDbContext : IdentityDbContext<ApplicationUser>
    {
        public BlogDbContext()
            : base("BloggingSystem", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BlogDbContext, Configuration>());           
        }

        public static BlogDbContext Create()
        {
            return new BlogDbContext();
        }

        public IDbSet<BlogUser> BlogUsers {get; set;}

        public IDbSet<Post> Posts { get; set; }

        public IDbSet<Tag> Tags { get; set; }

        public IDbSet<Comment> Comments { get; set; }        
    }
}