namespace BullsAndCows.Web.Models
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;    
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;

    using BullsAndCows.Models;

    public class GameModel
    {       
        public static Expression<Func<Game, GameModel>> FromGame
        {
            get
            {
                return g => new GameModel
                {
                    Id = g.Id,
                    Name = g.Name,
                    Blue = g.BluePlayer,
                    Red = g.RedPlayer,                    
                    GameState = g.GameState,
                    DateCreated = g.DateCreated
                };
            }
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public User Blue { get; set; }

        public User Red { get; set; }

        public GameState GameState { get; set; }

        public DateTime DateCreated { get; set; }        
    }
}