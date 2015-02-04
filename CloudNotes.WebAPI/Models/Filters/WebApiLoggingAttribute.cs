using log4net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CloudNotes.WebAPI.Models.Filters
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class WebApiLoggingAttribute : ActionFilterAttribute
    {
        private static readonly Stopwatch stopwatch = new Stopwatch();
        private static readonly ILog log = LogManager.GetLogger("CloudNotes.WebApi.Logger");

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            log.DebugFormat("Executing {0}.{1}", actionContext.ControllerContext.ControllerDescriptor.ControllerName, actionContext.ActionDescriptor.ActionName);
            log.Debug("\t--- Arguments ---");
            foreach(var kvp in actionContext.ActionArguments)
            {
                log.DebugFormat("\t[{0}] -> [{1}]", kvp.Key, kvp.Value);
            }
            stopwatch.Restart();
            base.OnActionExecuting(actionContext);
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);
            stopwatch.Stop();
            log.DebugFormat("Executed {0}.{1}, Elapsed: {2}", actionExecutedContext.ActionContext.ControllerContext.ControllerDescriptor.ControllerName,
                actionExecutedContext.ActionContext.ActionDescriptor.ActionName, stopwatch.Elapsed);
        }
    }
}