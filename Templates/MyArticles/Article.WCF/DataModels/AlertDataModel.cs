namespace Articles.WCF.DataModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Linq.Expressions;
    using System.Web;

    using Article.Models;    

    public class AlertDataModel
    {
        public static Expression<Func<Alert, AlertDataModel>> FromAlert
        {
            get
            {
                return a => new AlertDataModel
                {
                    Content = a.Content,
                    ID = a.Id
                };
            }
        }

        public int ID { get; set; }

        public string Content { get; set; }
    }
}