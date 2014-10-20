using BullsAndCows.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace BullsAndCows.WCF
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IBullsAndCows" in both code and config file together.
    [ServiceContract]    
    public interface IUserService
    {
        [OperationContract]
        [WebGet(UriTemplate = "api/users")]
        IEnumerable<User> GetUsers();
    }
}
