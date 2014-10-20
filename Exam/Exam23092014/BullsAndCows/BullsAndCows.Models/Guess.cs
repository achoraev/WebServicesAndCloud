namespace BullsAndCows.Models
{
    using System;
    public class Guess
    {

        public int Id { get; set; }

        public Guid UserId { get; set; }

        public virtual User Users { get; set; }
    }
}