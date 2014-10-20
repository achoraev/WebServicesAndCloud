namespace BullsAndCows.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Game
    {
        public Game()
        {            
            this.GameState = GameState.WaitingForOpponent;
            this.PlayerColor = PlayerColor.red;            
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        public int GuessNumber { get; set; }

        public User RedPlayer { get; set; }

        public User BluePlayer { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }

        public ICollection<Guess> Guesses { get; set; }

        public PlayerColor PlayerColor { get; set; }
    }
}