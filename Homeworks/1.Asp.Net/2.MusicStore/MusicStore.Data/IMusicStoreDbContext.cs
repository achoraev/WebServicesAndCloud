namespace MusicStore.Data
{
    using MusicStore.Models;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    public interface IMusicStoreDbContext
    {
        IDbSet<Artist> Artists { get; set; }

        IDbSet<Album> Albums { get; set; }

        IDbSet<Song> Songs { get; set; }

        void SaveChanges();

        new IDbSet<TEntity> Set<TEntity>() where TEntity : class;

        DbEntityEntry<TEntity> Entry<TEntity>(TEntity entity) where TEntity : class;
    }
}