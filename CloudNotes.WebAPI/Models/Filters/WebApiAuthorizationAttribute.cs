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

namespace CloudNotes.WebAPI.Models.Filters
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Security.Principal;
    using System.Text;
    using System.Threading;
    using System.Web;
    using System.Web.Http.Controllers;
    using System.Web.Http.Filters;
    using Apworks.Repositories;
    using Apworks.Specifications;
    using CloudNotes.DESecurity;
    using CloudNotes.Domain.Model;

    /// <summary>
    ///     Represents the authorization filter attribute used by current Web API application.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = false)]
    public class WebApiAuthorizationAttribute : AuthorizationFilterAttribute
    {
        #region Private Fields

        private readonly string privilege;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebApiAuthorizationAttribute" /> class.
        /// </summary>
        public WebApiAuthorizationAttribute()
        {
            privilege = string.Empty;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="WebApiAuthorizationAttribute" /> class.
        /// </summary>
        /// <param name="privilege">The privilege.</param>
        public WebApiAuthorizationAttribute(string privilege)
        {
            this.privilege = privilege;
        }

        #endregion

        /// <summary>
        ///     Calls when a process requests authorization.
        /// </summary>
        /// <param name="actionContext">
        ///     The action context, which encapsulates information for using
        ///     <see cref="T:System.Web.Http.Filters.AuthorizationFilterAttribute" />.
        /// </param>
        public override void OnAuthorization(HttpActionContext actionContext)
        {
            var userPassword = ParseAuthorizationHeader(actionContext);
            if (userPassword == null)
            {
                Challenge(actionContext);
                return;
            }

            var roles = new List<string>();
            User user;
            if (!TryAuthorizeUser(userPassword.Item1, userPassword.Item2, actionContext, out user, ref roles))
            {
                Challenge(actionContext);
                return;
            }
            var identity = new BasicAuthenticationIdentity(user, userPassword.Item1);
            var principal = new GenericPrincipal(identity, roles.ToArray());

            Thread.CurrentPrincipal = principal;

            if (HttpContext.Current != null)
            {
                HttpContext.Current.User = principal;
            }

            base.OnAuthorization(actionContext);
        }

        /// <summary>
        ///     Tries the authorize user.
        /// </summary>
        /// <param name="username">The username.</param>
        /// <param name="password">The password.</param>
        /// <param name="actionContext">The action context.</param>
        /// <param name="user">The user.</param>
        /// <param name="roles">The roles.</param>
        /// <returns></returns>
        protected virtual bool TryAuthorizeUser(string username, string password, HttpActionContext actionContext,
            out User user, ref List<string> roles)
        {
            user = null;
            roles.Clear();
            var userRepository = GetService<IRepository<User>>(actionContext);
            var permissionRepository = GetService<IRepository<Permission>>(actionContext);

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                return false;
            }

            // Gets the user instance
            user = userRepository.Find(Specification<User>.Eval(u => u.UserName == username));
            if (((object) user) == null)
            {
                return false;
            }

            // Check if the user has been locked
            //if (user.Locked)
            //{
            //    return false;
            //}

            // Compares the encrypted password
            var encryptedPassword = Crypto.ComputeHash(password, username);
            if (user.Password != encryptedPassword)
            {
                return false;
            }
            roles.AddRange(user.Roles.Select(role => role.Name));

            // Checks the roles and privileges
            // If no requested privileges, which means any authenticated user could access the resource,
            // so no need to do the further checking.
            if (string.IsNullOrEmpty(privilege))
            {
                return true;
            }

            foreach (var role in user.Roles)
            {
                var assignedRole = role;
                var permissions =
                    permissionRepository.FindAll(Specification<Permission>.Eval(p => p.Role.ID == assignedRole.ID));
                if (permissions.Any(p => p.Privilege.Name == privilege &&
                                         p.Value == PermissionValue.Allow))
                {
                    return true;
                }
            }
            return false;
        }

        protected virtual Tuple<string, string> ParseAuthorizationHeader(HttpActionContext actionContext)
        {
            string authHeader = null;
            var auth = actionContext.Request.Headers.Authorization;
            if (auth != null && auth.Scheme == "Basic")
            {
                authHeader = auth.Parameter;
            }

            if (string.IsNullOrEmpty(authHeader))
            {
                return null;
            }

            authHeader = Encoding.Default.GetString(Convert.FromBase64String(authHeader));

            var tokens = authHeader.Split(':');
            if (tokens.Length < 2)
            {
                return null;
            }

            return new Tuple<string, string>(tokens[0], tokens[1]);
        }

        private static void Challenge(HttpActionContext actionContext)
        {
            var host = actionContext.Request.RequestUri.DnsSafeHost;
            actionContext.Response = actionContext.Request.CreateResponse(HttpStatusCode.Unauthorized);
            actionContext.Response.Headers.Add("WWW-Authenticate", string.Format("Basic realm=\"{0}\"", host));
        }

        private static T GetService<T>(HttpActionContext actionContext)
        {
            return (T) actionContext.Request.GetDependencyScope().GetService(typeof (T));
        }
    }

    public class BasicAuthenticationIdentity : GenericIdentity
    {
        public BasicAuthenticationIdentity(User user, string name)
            : base(name, "Basic")
        {
            User = user;
        }

        public User User { get; set; }
    }
}