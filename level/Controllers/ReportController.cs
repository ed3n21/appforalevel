using level.Filters;
using level.Filters.Exceptions;
using level.Models;
using System.Collections.Generic;
using System.Web.Http;
using System.Web.Mvc;


namespace level.Controllers
{
    [Exception]
    public class ReportController : ApiController
    {
        [System.Web.Http.HttpGet]
        public string Test()
        {
            return "test";
        }

        //TODO: return Model class with Data for traffic


        [System.Web.Http.HttpGet]
        //https://localhost:44307/api/Report/GetTrafficData?category=%22home%22
        public string GetTrafficData(string category)
        {
            //TODO: check if category exist on service
            if (true) // categoryService("cate"). 
            {
                throw new CategoryNotExistException("This category doesn;t exist");
                //TODO: check if data for traffic exist from service

                if (true)
                {
                    throw new NotFindDataException("No data");
                }
                
            }

            return "OK";
        }
    }
}

