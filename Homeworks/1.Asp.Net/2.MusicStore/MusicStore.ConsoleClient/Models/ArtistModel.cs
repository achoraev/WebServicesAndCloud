namespace MusicStore.ConsoleClient.Models
{
    using System;

    public class ArtistModel
    {
        public int ArtistId { get; set; }

        public string Name { get; set; }

        public string Country { get; set; }

        public DateTime? BirthDate { get; set; }
    }
}