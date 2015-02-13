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
    using System;
    using System.Globalization;
    using System.Web.Http;
    using Apworks.Repositories;
    using CloudNotes.Infrastructure;
    using CloudNotes.WebAPI.Models.Filters;

    /// <summary>
    ///     Represents the Ping controller.
    /// </summary>
    [RoutePrefix("api")]
    public class PingController : WebApiController
    {
        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="PingController" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        public PingController(IRepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        #endregion

        #region Public APIs

        /// <summary>
        ///     Pings the server instance.
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
        ///     Echoes the specified text.
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