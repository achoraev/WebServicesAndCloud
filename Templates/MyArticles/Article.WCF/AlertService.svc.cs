namespace Articles.WCF
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using Article.Data;
    using Articles.Data;
    using Articles.WCF.DataModels;

    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "AlertService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select AlertService.svc or AlertService.svc.cs at the Solution Explorer and start debugging.
    public class AlertService : IAlertService
    {
        private AlertsData data;

        public AlertService()
        {
            this.data = new AlertsData(ArticleDbContext.Create());
        }

        public IEnumerable<AlertDataModel> GetAlerts()
        {
            var alerts = this.data.Alerts.All()
                .Where(a => a.ExpirationDate > DateTime.Now)
                .OrderByDescending( a => a.ExpirationDate)
                .Select(AlertDataModel.FromAlert).ToList();

            return alerts;
        }
    }
}