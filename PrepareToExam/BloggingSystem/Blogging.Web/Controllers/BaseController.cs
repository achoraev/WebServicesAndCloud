namespace Blogging.Web.Controllers
{    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.Http;

    using Blogging.Data;

    public class BaseApiController : ApiController
    {
        protected IBlogData data;

        public BaseApiController(IBlogData data)
        {
            this.data = data;
        }
    }
}