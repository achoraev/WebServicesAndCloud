namespace BullsAndCows.Data
{
    using System;
    using System.Linq;
    using System.Collections.Generic;
    using BullsAndCows.Data.Repositories;
    using BullsAndCows.Models;

    public class BullsAndCowsData : IBullsAndCowsData
    {
        // Unit of Work
        private BullsAndCowsDbContext context;
        private IDictionary<Type, object> repositories;

        public BullsAndCowsData()
            : this(new BullsAndCowsDbContext())
        {
        }

        public BullsAndCowsData(BullsAndCowsDbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<Game> Games
        {
            get { return this.GetRepository<Game>(); }
        }

        public IRepository<User> Users
        {
            get { return this.GetRepository<User>(); }
        }

        public IRepository<Guess> Guesses
        {
            get { return this.GetRepository<Guess>(); }
        }

        public IRepository<Score> Scores
        {
            get { return this.GetRepository<Score>(); }
        }

        public IRepository<Notification> Notifications
        {
            get { return this.GetRepository<Notification>(); }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }        

        // Unit of Work
        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfModel = typeof(T);
            if (!this.repositories.ContainsKey(typeOfModel))
            {
                var type = typeof(Repository<T>);

                if (typeOfModel.IsAssignableFrom(typeof(Game)))
                {
                    type = typeof(Repository<Game>);
                }

                this.repositories.Add(typeOfModel, Activator.CreateInstance(type, this.context));
            }

            return (IRepository<T>)this.repositories[typeOfModel];
        }
    }
}