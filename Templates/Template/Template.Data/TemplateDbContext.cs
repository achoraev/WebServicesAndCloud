namespace Template.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Template.Data.Migrations;
    using Template.Models;

    public class TemplateDbContext : DbContext, ITemplateDbContext
    {
        public TemplateDbContext()
            : base("Template")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<TemplateDbContext, Configuration>());
        }

        public IDbSet<Student> Students { get; set; }

        public static TemplateDbContext Create()
        {
            return new TemplateDbContext();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }
    }
}