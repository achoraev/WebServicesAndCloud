namespace MusicStore.Data
{
    using MusicStore.Data.Repositories;
    using MusicStore.Models;

    public interface IMusicStoreData
    {
        IGenericRepository<Artist> Artists { get; }

        IGenericRepository<Album> Albums { get; }

        IGenericRepository<Song> Songs { get; }

        void SaveChanges();
    }
}