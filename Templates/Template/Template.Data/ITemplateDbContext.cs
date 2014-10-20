namespace Template.Data
{
    using System;
    using System.Data.Entity;

    using Template.Models;

    public interface ITemplateDbContext
    {
        IDbSet<Student> Students { get; set; }

        void SaveChanges();
    }
}