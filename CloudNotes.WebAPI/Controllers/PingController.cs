using Apworks.Repositories;
using CloudNotes.Infrastructure;
using CloudNotes.WebAPI.Models.Filters;
using System;
using System.Globalization;
using System.Web.Http;

namespace CloudNotes.WebAPI.Controllers
{
    /// <summary>
    /// Represents the Ping controller.
    /// </summary>
    [RoutePrefix("api")]
    public class PingController : WebApiController
    {
        #region Ctor

        /// <summary>
        /// Initializes a new instance of the <see cref="PingController"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public PingController(IRepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        #endregion

        #region Public APIs

        /// <summary>
        /// Pings the server instance.
        /// </summary>
        /// <returns>A data structure that contains the server and user information.</returns>
        [WebApiAuthorization(Privileges.ApiPing)]
        [HttpGet]
        [Route("ping")]
        public IHttpActionResult Ping()
        {
            return this.Ok(
                new
                {
                    ID = Guid.NewGuid(),
                    UserID = this.CurrentLoginUser.ID,
                    UserName = this.User.Identity.Name,
                    ServerName = Environment.MachineName,
                    ProcessorCount = Environment.ProcessorCount.ToString(CultureInfo.InvariantCulture),
                    Is64BitOperatingSystem =
                        Environment.Is64BitOperatingSystem.ToString(CultureInfo.InvariantCulture),
                    OSVersion = Environment.OSVersion.ToString(),
                    CLRVersion = Environment.Version.ToString(),
                    DomainName = Environment.UserDomainName,
                    DomainUserName = Environment.UserName
                });
        }

        /// <summary>
        /// Echoes the specified text.
        /// </summary>
        /// <param name="text">The text.</param>
        /// <returns></returns>
        [WebApiAuthorization]
        [HttpGet]
        [Route("echo")]
        public IHttpActionResult Echo(string text)
        {
            return this.Ok(text);
        }

        #endregion
    }
}