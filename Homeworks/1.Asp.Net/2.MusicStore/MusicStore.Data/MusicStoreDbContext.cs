namespace MusicStore.Data
{
    using MusicStore.Data.Migrations;
    using MusicStore.Models;
    using System.Data.Entity;

    public class MusicStoreDbContext : DbContext, IMusicStoreDbContext
    {
        public MusicStoreDbContext()
            :base("MusicStoreDb")
        {
            Database.SetInitializer<MusicStoreDbContext>(new MigrateDatabaseToLatestVersion<MusicStoreDbContext, Configuration>());
        }

        public IDbSet<Artist> Artists { get; set; }

        public IDbSet<Album> Albums { get; set; }

        public IDbSet<Song> Songs { get; set; }

        public new void SaveChanges()
        {
            base.SaveChanges();
        }

        public new IDbSet<TEntity> Set<TEntity>() where TEntity : class
        {
            return base.Set<TEntity>();
        }
    }
}