using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace level.Controllers
{
    public class ReportController : ApiController
    {
        [HttpGet]
        public string Test()
        {
            return "test";
        }
    }
}
