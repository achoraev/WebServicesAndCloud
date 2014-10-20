namespace Blogging.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using Blogging.Data.Repositories;
    using Blogging.Models;

    public class BlogData : IBlogData
    {
        // Unit of Work
        private BlogDbContext context;
        private IDictionary<Type, object> repositories;        

        public BlogData(BlogDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<BlogUser> BlogUsers
        {
            get { return this.GetRepository<BlogUser>(); }
        }

        public IRepository<Post> Posts
        {
            get { return this.GetRepository<Post>(); }
        }

        public IRepository<Tag> Tags
        {
            get { return this.GetRepository<Tag>(); }
        }

        public IRepository<Comment> Comments
        {
            get { return this.GetRepository<Comment>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }        

        // Unit of Work
        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(BlogUser)))
                {
                    type = typeof(Repository<BlogUser>);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }       
    }
}