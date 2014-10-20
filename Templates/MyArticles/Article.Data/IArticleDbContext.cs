namespace Article.Data
{
    using System;
    using System.Data.Entity;

    using Article.Models;

    public interface IArticleDbContext
    {
        IDbSet<Article> Articles { get; set; }    
        IDbSet<Like> Likes { get; set; }
        IDbSet<Comment> Comments { get; set; }
        IDbSet<Category> Categories { get; set; }
        IDbSet<Tag> Tags { get; set; }
        IDbSet<Alert> Alerts { get; set; }

        void SaveChanges();
    }
}