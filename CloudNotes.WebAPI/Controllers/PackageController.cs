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
    [RoutePrefix("api")]
    public class PackageController : WebApiController
    {
        private readonly IRepository<ClientPackage> repository;

        public PackageController(IRepositoryContext repositoryContext,
            IRepository<ClientPackage> repository)
            : base(repositoryContext)
        {
            this.repository = repository;
        }

        [WebApiAuthorization(Privileges.ApiGetPackage)]
        [HttpGet]
        [Route("packages/exist/{clientType}")]
        public IHttpActionResult PackageExists(string clientType)
        {
            return
                this.Ok(
                    this.repository.Exists(
                        Specification<ClientPackage>.Eval(
                            cp => cp.ClientType == clientType)));
        }

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
                HostingEnvironment.MapPath(ConfigurationManager.AppSettings[Constants.PackageLocationUriSettingKey]);

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
    }
}