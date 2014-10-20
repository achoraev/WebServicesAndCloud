namespace Article.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using Article.Data.Migrations;
    using Article.Models;

    public class ArticleDbContext : DbContext, IArticleDbContext
    {
        public ArticleDbContext()
            : base("Article")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<ArticleDbContext, Configuration>());
        }

        public IDbSet<Article> Articles { get; set; }

        public static ArticleDbContext Create()
        {
            return new ArticleDbContext();
        }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }


        public IDbSet<Like> Likes
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IDbSet<Comment> Comments
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IDbSet<Category> Categories
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IDbSet<Tag> Tags
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }

        public IDbSet<Alert> Alerts
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }
    }
}