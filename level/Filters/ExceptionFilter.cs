
using System;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace level.Filters
{
    public class ExceptionAttribute : FilterAttribute, IExceptionFilter
    {
   

        public void OnException(ExceptionContext filterContext)
        {
            throw new NotImplementedException();
        }

        //public override void OnException(HttpActionExecutedContext actionExecutedContext)
        //{

        //    // TODO: check for each Exception type
        //    base.OnException(actionExecutedContext);

        //    var httpStatusCode = HttpStatusCode.InternalServerError;

        //    if (actionExecutedContext.Exception is CategoryNotExistException)
        //        httpStatusCode = HttpStatusCode.NotFound;

        //    if (actionExecutedContext.Exception is NotFindDataException)
        //        httpStatusCode = HttpStatusCode.NotFound;

        //    if (actionExecutedContext.Exception is NullReferenceException)
        //        httpStatusCode = HttpStatusCode.BadRequest;

        //    actionExecutedContext.Response = actionExecutedContext.Request.CreateResponse(
        //            httpStatusCode,
        //            actionExecutedContext.Exception.Message
        //    );




        //}
    }
}