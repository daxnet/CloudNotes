//  =======================================================================================================
// 
//     ,uEZGZX  LG                             Eu       iJ       vi                                              
//    BB7.  .:  uM                             8F       0BN      Bq             S:                               
//   @X         LO    rJLYi    :     i    iYLL XJ       Xu7@     Mu    7LjL;   rBOii   7LJ7    .vYUi             
//  ,@          LG  7Br...SB  vB     B   B1...7BL       0S i@,   OU  :@7. ,u@   @u.. :@:  ;B  LB. ::             
//  v@          LO  B      Z0 i@     @  BU     @Y       qq  .@L  Oj  @      5@  Oi   @.    MB U@                 
//  .@          JZ :@      :@ rB     B  @      5U       Eq    @0 Xj ,B      .B  Br  ,B:rv777i  :0ZU              
//   @M         LO  @      Mk :@    .@  BL     @J       EZ     GZML  @      XM  B;   @            Y@             
//    ZBFi::vu  1B  ;B7..:qO   BS..iGB   BJ..:vB2       BM      rBj  :@7,.:5B   qM.. i@r..i5. ir. UB             
//      iuU1vi   ,    ;LLv,     iYvi ,    ;LLr  .       .,       .     rvY7:     rLi   7LLr,  ,uvv:  
// 
// 
//  Copyright 2014-2015 daxnet
//  
//  Licensed under the Apache License, Version 2.0 (the "License");
//  you may not use this file except in compliance with the License.
//  You may obtain a copy of the License at
//  
//      http://www.apache.org/licenses/LICENSE-2.0
//  
//  Unless required by applicable law or agreed to in writing, software
//  distributed under the License is distributed on an "AS IS" BASIS,
//  WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
//  See the License for the specific language governing permissions and
//  limitations under the License.
//  =======================================================================================================

namespace CloudNotes.WebAPI.Controllers
{
    using System.Configuration;
    using System.Linq;
    using System.Web.Http;
    using Apworks.Repositories;
    using Apworks.Specifications;
    using Apworks.Storage;
    using CloudNotes.Domain.Model;
    using CloudNotes.Infrastructure;
    using CloudNotes.WebAPI.Models.Exceptions;
    using CloudNotes.WebAPI.Models.Filters;

    /// <summary>
    ///     Represents the controller that provides the client package management APIs.
    /// </summary>
    [RoutePrefix("api")]
    public class PackageController : WebApiController
    {
        #region Private Fields

        private readonly IRepository<ClientPackage> repository;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of <c>PackageController</c> class.
        /// </summary>
        /// <param name="repositoryContext">The instance of <see cref="IRepositoryContext" /></param>
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
        ///     Gets the latest package information based on the given client type.
        /// </summary>
        /// <param name="clientType">
        ///     The type of the client application. Currently
        ///     it only supports DesktopClient.
        /// </param>
        /// <returns>HTTP 200 with package information if success.</returns>
        [WebApiAuthorization(Privileges.ApiGetPackage)]
        [HttpGet]
        [Route("packages/latest/{clientType}")]
        public IHttpActionResult GetLatestPackage(string clientType)
        {
            var package =
                this.repository.FindAll(
                    Specification<ClientPackage>.Eval(cp => cp.ClientType == clientType),
                    sort => sort.DatePublished,
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
            {
                packageDownloadUrl = packagePath + "/" + package.PackageFileName;
            }
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