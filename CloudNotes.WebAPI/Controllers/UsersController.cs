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
    using System.Text;
    using System.Web.Http;
    using Apworks.Repositories;
    using Apworks.Specifications;
    using AutoMapper;
    using CloudNotes.Domain.Model;
    using CloudNotes.Infrastructure;
    using CloudNotes.ViewModels;
    using CloudNotes.WebAPI.Models.Exceptions;
    using CloudNotes.WebAPI.Models.Filters;
    using CloudNotes.WebAPI.Properties;

    /// <summary>
    ///     Represents the API controller that manages CloudNotes users.
    /// </summary>
    [RoutePrefix("api")]
    public class UsersController : WebApiController
    {
        #region Private Fields

        private readonly IRepository<User> userRepository;

        #endregion

        #region Ctor

        /// <summary>
        ///     Initializes a new instance of the <see cref="UsersController" /> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        /// <param name="userRepository">The user repository.</param>
        public UsersController(IRepositoryContext repositoryContext,
            IRepository<User> userRepository)
            : base(repositoryContext)
        {
            this.userRepository = userRepository;
        }

        #endregion

        /// <summary>
        ///     Creates the user.
        /// </summary>
        /// <param name="viewModel">The view model which contains the user information.</param>
        /// <returns>The Http status with the created user ID.</returns>
        [WebApiAuthorization(Privileges.ApiCreateUser)]
        [Route("users/create")]
        [HttpPut]
        public IHttpActionResult CreateUser([FromBody] CreateUserViewModel viewModel)
        {
            if (this.userRepository.Exists(Specification<User>.Eval(u => u.UserName == viewModel.UserName)))
            {
                throw new UserAlreadyExistsException(
                    string.Format("The user '{0}' already exists.", viewModel.UserName));
            }
            if (this.userRepository.Exists(Specification<User>.Eval(u => u.Email == viewModel.Email)))
            {
                throw new EmailAlreadyExistsException(string.Format("The email '{0}' already exists.", viewModel.Email));
            }
            var user = Mapper.Map<CreateUserViewModel, User>(viewModel);
            this.userRepository.Add(user);
            this.RepositoryContext.Commit();
            return this.Ok(user.ID);
        }

        /// <summary>
        ///     Authenticates the specified user.
        /// </summary>
        /// <param name="viewModel">The view model which contains the username and password to be authenticated.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">viewModel</exception>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        /// <exception cref="System.FormatException"></exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        /// <exception cref="InvalidPasswordException"></exception>
        [Route("users/authenticate")]
        [HttpPost]
        public IHttpActionResult Authenticate([FromBody] AuthenticationViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("viewModel");
            }
            if (string.IsNullOrEmpty(viewModel.UserName))
            {
                throw new ArgumentException(string.Format(Resources.NullParameterPropertyError, "UserName", "viewModel"));
            }
            if (string.IsNullOrEmpty(viewModel.EncodedPassword))
            {
                throw new ArgumentException(string.Format(Resources.NullParameterPropertyError, "EncodedPassword",
                    "viewModel"));
            }
            if (!viewModel.EncodedPassword.IsBase64String())
            {
                throw new FormatException(Resources.InvalidValueFormat);
            }

            if (!this.userRepository.Exists(Specification<User>.Eval(u => u.UserName == viewModel.UserName)))
            {
                throw new UserDoesNotExistException(viewModel.UserName);
            }

            var user = this.userRepository.Find(Specification<User>.Eval(u => u.UserName == viewModel.UserName));
            if (user.Locked)
            {
                throw new UserLockedException("User has been locked.");
            }

            var encodedPassword = Encoding.ASCII.GetString(Convert.FromBase64String(viewModel.EncodedPassword));
            if (user.Password != encodedPassword)
            {
                throw new InvalidPasswordException(Resources.InvalidPasswordError);
            }

            user.DateLastAuthenticated = DateTime.UtcNow;
            this.userRepository.Update(user);
            this.RepositoryContext.Commit();
            return this.Ok(true);
        }

        /// <summary>
        ///     Changes the password.
        /// </summary>
        /// <param name="viewModel">The view model.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">viewModel</exception>
        /// <exception cref="System.ArgumentException">
        /// </exception>
        /// <exception cref="UserDoesNotExistException"></exception>
        /// <exception cref="InvalidPasswordException"></exception>
        [Route("users/password/change")]
        [HttpPost]
        public IHttpActionResult ChangePassword([FromBody] ChangePasswordViewModel viewModel)
        {
            if (viewModel == null)
            {
                throw new ArgumentNullException("viewModel");
            }
            if (string.IsNullOrEmpty(viewModel.UserName))
            {
                throw new ArgumentException(string.Format(Resources.NullParameterPropertyError, "UserName", "viewModel"));
            }
            if (string.IsNullOrEmpty(viewModel.EncodedOldPassword))
            {
                throw new ArgumentException(string.Format(Resources.NullParameterPropertyError, "EncodedOldPassword",
                    "viewModel"));
            }
            if (string.IsNullOrEmpty(viewModel.EncodedNewPassword))
            {
                throw new ArgumentException(string.Format(Resources.NullParameterPropertyError, "EncodedNewPassword",
                    "viewModel"));
            }
            if (!this.userRepository.Exists(Specification<User>.Eval(u => u.UserName == viewModel.UserName)))
            {
                throw new UserDoesNotExistException(viewModel.UserName);
            }

            var user = this.userRepository.Find(Specification<User>.Eval(u => u.UserName == viewModel.UserName));
            if (user.Locked)
            {
                throw new UserLockedException("User has been locked.");
            }

            var encodedOldPassword = Encoding.ASCII.GetString(Convert.FromBase64String(viewModel.EncodedOldPassword));
            if (user.Password != encodedOldPassword)
            {
                throw new InvalidPasswordException(Resources.InvalidPasswordError);
            }
            var encodedNewPassword = Encoding.ASCII.GetString(Convert.FromBase64String(viewModel.EncodedNewPassword));
            user.Password = encodedNewPassword;
            this.userRepository.Update(user);
            this.RepositoryContext.Commit();
            return this.Ok(true);
        }
    }
}