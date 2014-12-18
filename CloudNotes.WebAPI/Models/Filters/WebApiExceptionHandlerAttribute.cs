using CloudNotes.WebAPI.Models.Exceptions;
using System;
using System.Net;
using System.Net.Http;
using System.Web.Http.Filters;

namespace CloudNotes.WebAPI.Models.Filters
{
    public class WebApiExceptionHandlerAttribute : ExceptionFilterAttribute
    {
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            var exc = actionExecutedContext.Exception;
            if (exc is EntityAlreadyExistsException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.Conflict, exc);
            }
            else if (exc is UserDoesNotExistException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, exc);
            }
            else if (exc is EntityDoesNotExistException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.NotFound, exc);
            }
            else if (exc is InvalidOperationException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, exc);
            }
            else if (exc is InvalidPasswordException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.Forbidden, exc);
            }
            else if (exc is InsufficientPriviledgeException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.Unauthorized, exc);
            }
            else if (exc is ArgumentException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, exc);
            }
            else if (exc is FormatException)
            {
                actionExecutedContext.Response = actionExecutedContext.Request.CreateErrorResponse(HttpStatusCode.MethodNotAllowed, exc);
            }
            else
            {
                base.OnException(actionExecutedContext);
            }
        }
    }
}