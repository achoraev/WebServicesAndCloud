namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;

    public class User
    {
        private ICollection<Game> students;
        
        private ICollection<Guess> homeworks;

        public User()
        {
            this.UserId = Guid.NewGuid();
            this.Games = new HashSet<Game>();
            this.Guesses = new HashSet<Guess>();
        }    

        public Guid UserId { get; set; }

        public string Username { get; set; }

        public PlayerColor PlayerColor { get; set; }

        public Game GameId { get; set; }

        public virtual ICollection<Game> Games { get; set; }

        public Guess GuessId { get; set; }

        public virtual ICollection<Guess> Guesses { get; set; }

        public int Number { get; set; }

        public DateTime DateMade { get; set; }

        public int CowsCount { get; set; }

        public int BullsCount { get; set; }
    }
}