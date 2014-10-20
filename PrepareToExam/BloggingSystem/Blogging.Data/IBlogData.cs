namespace Blogging.Data
{
    using Blogging.Data.Repositories;
    using Blogging.Models;

    public interface IBlogData
    {
        IRepository<BlogUser> BlogUsers { get; }
        IRepository<Post> Posts { get; }        
        IRepository<Tag> Tags { get; }
        IRepository<Comment> Comments { get; }
        int SaveChanges();
    }
}