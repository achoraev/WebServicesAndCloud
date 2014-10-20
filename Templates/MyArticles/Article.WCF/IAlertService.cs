namespace Articles.WCF
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.ServiceModel;
    using System.ServiceModel.Web;
    using System.Text;

    using Articles.WCF.DataModels;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IAlertService" in both code and config file together.
    [ServiceContract]
    public interface IAlertService
    {
        [OperationContract]
        [WebGet(UriTemplate = "api/alerts")]
        IEnumerable<AlertDataModel> GetAlerts();
    }
}