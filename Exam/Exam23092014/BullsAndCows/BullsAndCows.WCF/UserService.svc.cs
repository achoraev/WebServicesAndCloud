    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.Text;

    using BullsAndCows.Data;
    using BullsAndCows.Models;

namespace BullsAndCows.WCF
{
    

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "BullsAndCows" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select BullsAndCows.svc or BullsAndCows.svc.cs at the Solution Explorer and start debugging.
    public class UserService : IUserService
    {
        private BullsAndCowsData data;

       public UserService()
        {
            this.data = new BullsAndCowsData(BullsAndCowsDbContext.Create());
        }

        public IEnumerable<User> GetUsers()
        {
            var users = this.data.Users
                .All()            
                .OrderBy(u => u.Username)
                .Take(10);

            return users;
        }
    }
}