namespace Article.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Article.Data.Repositories;
    using Article.Models;

    public class ArticleData : IArticleData
    {
        // Unit of Work
        private IArticleDbContext context;
        private IDictionary<Type, object> repositories;

        public ArticleData()
            : this(new ArticleDbContext())
        {
        }              

        public IRepository<Article> Articles
        {
            get
            {
                return this.GetRepository<Article>();
            }
        }

        public void SaveChanges()
        {
            this.context.SaveChanges();
        }

        public ArticleData(IArticleDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        // Unit of Work
        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(Article)))
                {
                    type = typeof(Repository<Article>);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }    
    }
}