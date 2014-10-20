namespace BullsAndCows.Models
{
    using System;

    using BullsAndCows.Models.Notifications;

    public class Notification
    {
        public int Id { get; set; }

        public string Message { get; set; }

        public DateTime DateCreated { get; set; }

        public int MyProperty { get; set; }

        public Type Type { get; set; }

        public State State { get; set; }

        public int GameId { get; set; }
    }
}