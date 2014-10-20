namespace BullsAndCows.Data
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;

    using BullsAndCows.Data.Migrations;
    using BullsAndCows.Models;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class BullsAndCowsDbContext : IdentityDbContext<ApplicationUser>
    {
        public BullsAndCowsDbContext()
            : base("BullsAndCows", throwIfV1Schema: false)
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<BullsAndCowsDbContext, Configuration>());           
        }

        public static BullsAndCowsDbContext Create()
        {
            return new BullsAndCowsDbContext();
        }

        public IDbSet<Game> Game {get; set;}

        public IDbSet<Guess> Guess { get; set; }

        public IDbSet<Notification> Notification { get; set; }

        public IDbSet<Score> Score { get; set; }
    }
}