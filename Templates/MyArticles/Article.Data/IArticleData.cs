namespace Article.Data
{
    using Article.Data.Repositories;
    using Article.Models;

    public interface IArticleData
    {
        IRepository<Article> Articles { get; }

        void SaveChanges();
    }
}