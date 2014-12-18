using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace CloudNotes.WebAPI.Models.Filters
{
    public class WebApiModelValidationAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            var modelState = actionContext.ModelState;
            if (!modelState.IsValid)
            {
                var errors = new Dictionary<string, List<string>>();

                foreach (var key in modelState.Keys)
                {
                    var state = modelState[key];
                    if (state.Errors != null)
                    {
                        foreach (var stateError in state.Errors)
                        {
                            if (!errors.ContainsKey(key))
                                errors.Add(key, new List<string>());
                            errors[key].Add(stateError.ErrorMessage);
                        }
                    }
                }
                actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.BadRequest,
                    errors);
            }
            else
                base.OnActionExecuting(actionContext);
        }
    }
}