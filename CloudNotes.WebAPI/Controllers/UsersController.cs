using Apworks.Repositories;
using Apworks.Specifications;

using AutoMapper;

using CloudNotes.Domain.Model;
using CloudNotes.Infrastructure;
using CloudNotes.ViewModels;
using CloudNotes.WebAPI.Models.Exceptions;
using CloudNotes.WebAPI.Models.Filters;
using CloudNotes.WebAPI.Properties;
using System;
using System.Text;
using System.Web.Http;

namespace CloudNotes.WebAPI.Controllers
{
    /// <summary>
    /// Represents the API controller that manages CloudNotes users.
    /// </summary>
    [RoutePrefix("api")]
    public class UsersController : WebApiController
    {
        #region Private Fields
        private readonly IRepository<User> userRepository;
        #endregion

        #region Ctor
        /// <summary>
        /// Initializes a new instance of the <see cref="UsersController"/> class.
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
        /// Creates the user.
        /// </summary>
        /// <param name="viewModel">The view model which contains the user information.</param>
        /// <returns>The Http status with the created user ID.</returns>
        [WebApiAuthorization(Privileges.ApiCreateUser)]
        [Route("users/create")]
        [HttpPut]
        public IHttpActionResult CreateUser([FromBody] CreateUserViewModel viewModel)
        {
            if (userRepository.Exists(Specification<User>.Eval(u => u.UserName == viewModel.UserName)))
                throw new UserAlreadyExistsException(
                    string.Format("The user '{0}' already exists.", viewModel.UserName));
            if (userRepository.Exists(Specification<User>.Eval(u => u.Email == viewModel.Email))) 
                throw new EmailAlreadyExistsException(string.Format("The email '{0}' already exists.", viewModel.Email));
            var user = Mapper.Map<CreateUserViewModel, User>(viewModel);
            userRepository.Add(user);
            RepositoryContext.Commit();
            return Ok(user.ID);
        }

        /// <summary>
        /// Authenticates the specified user.
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
            if (viewModel==null)
                throw new ArgumentNullException("viewModel");
            if (string.IsNullOrEmpty(viewModel.UserName))
                throw new ArgumentException(string.Format(Resources.NullParameterPropertyError, "UserName", "viewModel"));
            if (string.IsNullOrEmpty(viewModel.EncodedPassword))
                throw new ArgumentException(string.Format(Resources.NullParameterPropertyError, "EncodedPassword", "viewModel"));
            if (!viewModel.EncodedPassword.IsBase64String())
                throw new FormatException(Resources.InvalidValueFormat);

            if (!userRepository.Exists(Specification<User>.Eval(u => u.UserName == viewModel.UserName)))
            {
                throw new UserDoesNotExistException(viewModel.UserName);
            }

            var user = userRepository.Find(Specification<User>.Eval(u => u.UserName == viewModel.UserName));
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
            userRepository.Update(user);
            RepositoryContext.Commit();
            return this.Ok(true);
        }

        /// <summary>
        /// Changes the password.
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
                throw new ArgumentNullException("viewModel");
            if (string.IsNullOrEmpty(viewModel.UserName))
                throw new ArgumentException(string.Format(Resources.NullParameterPropertyError, "UserName", "viewModel"));
            if (string.IsNullOrEmpty(viewModel.EncodedOldPassword))
                throw new ArgumentException(string.Format(Resources.NullParameterPropertyError, "EncodedOldPassword", "viewModel"));
            if (string.IsNullOrEmpty(viewModel.EncodedNewPassword))
                throw new ArgumentException(string.Format(Resources.NullParameterPropertyError, "EncodedNewPassword", "viewModel"));
            if (!userRepository.Exists(Specification<User>.Eval(u => u.UserName == viewModel.UserName)))
                throw new UserDoesNotExistException(viewModel.UserName);

            var user = userRepository.Find(Specification<User>.Eval(u => u.UserName == viewModel.UserName));
            if (user.Locked)
            {
                throw new UserLockedException("User has been locked.");
            }

            var encodedOldPassword = Encoding.ASCII.GetString(Convert.FromBase64String(viewModel.EncodedOldPassword));
            if (user.Password != encodedOldPassword)
                throw new InvalidPasswordException(Resources.InvalidPasswordError);
            var encodedNewPassword = Encoding.ASCII.GetString(Convert.FromBase64String(viewModel.EncodedNewPassword));
            user.Password = encodedNewPassword;
            userRepository.Update(user);
            RepositoryContext.Commit();
            return this.Ok(true);
        }
    }
}