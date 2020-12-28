using level.Filters.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace level.Filters
{
    public class ExceptionAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {

            // TODO: check for each Exception type
            base.OnException(actionExecutedContext);

            var httpStatusCode = HttpStatusCode.InternalServerError;

            if (actionExecutedContext.Exception is CategoryNotExistException)
                httpStatusCode = HttpStatusCode.NotFound;

            if (actionExecutedContext.Exception is NotFindDataException)
                httpStatusCode = HttpStatusCode.NotFound;

            if (actionExecutedContext.Exception is NullReferenceException)
                httpStatusCode = HttpStatusCode.BadRequest;

            actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
                    httpStatusCode,
                    actionExecutedContext.Exception.Message
            );




        }
    }
}