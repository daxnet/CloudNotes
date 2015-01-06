using System.Configuration;
using Apworks.Repositories;
using Apworks.Specifications;
using Apworks.Storage;
using CloudNotes.Domain.Model;
using CloudNotes.Infrastructure;
using CloudNotes.WebAPI.Models.Exceptions;
using CloudNotes.WebAPI.Models.Filters;
using System.Linq;
using System.Web.Hosting;
using System.Web.Http;

namespace CloudNotes.WebAPI.Controllers
{
    /// <summary>
    /// Represents the controller that provides the client package management APIs.
    /// </summary>
    [RoutePrefix("api")]
    public class PackageController : WebApiController
    {
        #region Private Fields

        private readonly IRepository<ClientPackage> repository;

        #endregion

        #region Ctor

        /// <summary>
        /// Initializes a new instance of <c>PackageController</c> class.
        /// </summary>
        /// <param name="repositoryContext">The instance of <see cref="IRepositoryContext"/></param>
        /// <param name="repository">The instance of client package repository.</param>
        public PackageController(IRepositoryContext repositoryContext,
            IRepository<ClientPackage> repository)
            : base(repositoryContext)
        {
            this.repository = repository;
        }

        #endregion

        #region Public APIs

        /// <summary>
        /// Gets the latest package information based on the given client type.
        /// </summary>
        /// <param name="clientType">The type of the client application. Currently
        /// it only supports DesktopClient.</param>
        /// <returns>HTTP 200 with package information if success.</returns>
        [WebApiAuthorization(Privileges.ApiGetPackage)]
        [HttpGet]
        [Route("packages/latest/{clientType}")]
        public IHttpActionResult GetLatestPackage(string clientType)
        {
            var package =
                this.repository.FindAll(
                    Specification<ClientPackage>.Eval(cp => cp.ClientType == clientType),
                    sort => sort.PublishedBy,
                    SortOrder.Descending).FirstOrDefault();
            if (package == null)
            {
                throw new EntityDoesNotExistException(
                    string.Format("The package for client type {0} doesn't exist.", clientType));
            }
            var packagePath =
                ConfigurationManager.AppSettings[Constants.PackageLocationUriSettingKey];

            string packageDownloadUrl;
            if (packagePath != null && !packagePath.EndsWith("/"))
                packageDownloadUrl = packagePath + "/" + package.PackageFileName;
            else
            {
                packageDownloadUrl = packagePath + package.PackageFileName;
            }

            return
                this.Ok(
                    new
                    {
                        package.ClientType,
                        package.Version,
                        package.ReleaseNotes,
                        package.DatePublished,
                        package.Description,
                        package.PublishedBy,
                        package.PackageFileName,
                        PackageDownloadURL = packageDownloadUrl
                    });
        }

        #endregion
    }
}