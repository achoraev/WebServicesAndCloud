namespace MusicStore.ConsoleClient
{
    using System;
    using MusicStore.Data;
    using System.Net.Http;
    using System.Net.Http.Headers;
    using MusicStore.ConsoleClient.DataClients;

    class Program
    {
        private const string JsonContentType = "application/json";
        private const string XmlContentType = "application/xml";
        private const string BaseUri = @"http://localhost:10152/";

        static void Main()
        {
            var db = new MusicStoreData();
            
            var client = new HttpClient()
            {
                BaseAddress = new Uri(BaseUri)
            };

            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(JsonContentType));
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue(XmlContentType));

            //CRUD Artists
            var artistsDataClient = new ArtistsDataClient(client);
            Console.WriteLine("Adding artists...");

            artistsDataClient.Create("John Lennon", "UK", null);
            artistsDataClient.Create("Shakira", "Colombia", null);

            Console.WriteLine("Artists added.");

            var allArtists = artistsDataClient.GetAll();
            foreach (var artist in allArtists)
            {
                Console.WriteLine(artist.Name);
            }

            Console.WriteLine("Updating artists...");

            artistsDataClient.Update(1, "Mick Jagger", "UK", null);
            artistsDataClient.Delete(2);

            Console.WriteLine("Done.");

            allArtists = artistsDataClient.GetAll();
            foreach (var artist in allArtists)
            {
                Console.WriteLine(artist.Name);
            }

            //CRUD Songs
            var songsDataClient = new SongsDataClient(client);

            Console.WriteLine("Addings songs...");

            songsDataClient.Create("Thunderstruck", "rock", 1990);
            songsDataClient.Create("Kashmir", "rock", 1962);

            Console.WriteLine("Done.");

            var allSongs = songsDataClient.GetAll();
            foreach (var song in allSongs)
            {
                Console.WriteLine(song.Title);
            }

            Console.WriteLine("Updating songs...");

            songsDataClient.Update(1, "What Evil Men Do", "metal", 1993);
            songsDataClient.Delete(2);

            Console.WriteLine("Done");
            
            allSongs = songsDataClient.GetAll();
            foreach (var song in allSongs)
            {
                Console.WriteLine(song.Title);
            }
            
            //CRUD Albums
            var albumsDataClient = new AlbumsDataClient(client);

            Console.WriteLine("Adding albums...");

            albumsDataClient.Create("Motorizer", 2008, "Universal");
            albumsDataClient.Create("Liubimi pesni za masa", 1999, "Independent");

            Console.WriteLine("Done.");
            var allAlbums = albumsDataClient.GetAll();
            foreach (var album in allAlbums)
            {
                Console.WriteLine(album.Title);
            }

            Console.WriteLine("Updating albums...");
            albumsDataClient.Update(1, "The world is yours", "Universal", 2010);
            albumsDataClient.Delete(2);
            Console.WriteLine("Done");

            allAlbums = albumsDataClient.GetAll();
            foreach (var album in allAlbums)
            {
                Console.WriteLine(album.Title);
            }
        }
    }
}