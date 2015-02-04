
using Apworks;
using Apworks.Repositories;
using Apworks.Specifications;
using Apworks.Storage;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using CloudNotes.Domain.Model;
using CloudNotes.Infrastructure;
using CloudNotes.ViewModels;
using CloudNotes.WebAPI.Models.Exceptions;
using CloudNotes.WebAPI.Models.Filters;
using log4net;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web.Http;

namespace CloudNotes.WebAPI.Controllers
{
    /// <summary>
    /// Represents the base class for Web API controllers.
    /// </summary>
    [WebApiExceptionHandler]
    [WebApiModelValidation]
    public abstract class WebApiController : ApiController
    {
        private bool disposed;
        private readonly IRepositoryContext repositoryContext;

        private static readonly ILog log = LogManager.GetLogger("CloudNotes.WebApi.Logger");

        /// <summary>
        /// Initializes a new instance of the <see cref="WebApiController"/> class.
        /// </summary>
        /// <param name="repositoryContext">The repository context.</param>
        protected WebApiController(IRepositoryContext repositoryContext)
        {
            this.repositoryContext = repositoryContext;
        }

        /// <summary>
        /// Gets the repository context.
        /// </summary>
        /// <value>
        /// The repository context.
        /// </value>
        protected IRepositoryContext RepositoryContext
        {
            get { return repositoryContext; }
        }

        /// <summary>
        /// Gets the current login user.
        /// </summary>
        /// <value>
        /// The current login user.
        /// </value>
        protected User CurrentLoginUser
        {
            get
            {
                return User != null ? ((BasicAuthenticationIdentity)User.Identity).User : null;
            }
        }

        protected ILog Log
        {
            get { return log; }
        }

        /// <summary>
        /// Checks if the given aggregate root is exist in the repository.
        /// </summary>
        /// <typeparam name="T">The type of the aggregate root to be checked.</typeparam>
        /// <param name="against">The aggregate root object to be checked.</param>
        /// <param name="repository">The repository for the aggregate root.</param>
        /// <param name="requiresItExists">The checking logic switcher.</param>
        /// <exception cref="CloudNotes.WebAPI.Models.Exceptions.EntityAlreadyExistsException">
        /// Throws when the <paramref name="requiresItExists"/> is set to <c>false</c> but the aggregate root exists.
        /// </exception>
        /// <exception>
        /// Throws when the
        ///     <cref>CloudNotes.WebAPI.Models.Exceptions.EntityDoesNotExistException</cref>
        ///     <paramref name="requiresItExists"/> is set to <c>true</c> but the aggregate root does not exist.
        /// </exception>
        protected virtual void RequireExistance<T>(T against, IRepository<T> repository, bool requiresItExists = true)
            where T : class, IAggregateRoot
        {
            RequireExistance(against.ID, repository, requiresItExists);
        }

        /// <summary>
        /// Checks if the given aggregate root is exist in the repository.
        /// </summary>
        /// <typeparam name="T">The type of the aggregate root.</typeparam>
        /// <param name="id">The identifier of the aggregate root.</param>
        /// <param name="repository">The repository for the aggregate root.</param>
        /// <param name="requiresItExists">The checking logic switcher.</param>
        /// <exception>
        /// Throws when the
        ///     <cref>CloudNotes.WebAPI.Models.Exceptions.EntityAlreadyExistsException</cref>
        ///     <paramref name="requiresItExists"/> is set to <c>false</c> but the aggregate root exists.
        /// </exception>
        /// <exception>
        /// Throws when the
        ///     <cref>CloudNotes.WebAPI.Models.Exceptions.EntityDoesNotExistException</cref>
        ///     <paramref name="requiresItExists"/> is set to <c>true</c> but the aggregate root does not exist.
        /// </exception>
        protected virtual void RequireExistance<T>(Guid id, IRepository<T> repository, bool requiresItExists = true)
            where T : class, IAggregateRoot
        {
            RequireExistance(p => p.ID == id, repository, requiresItExists);
        }

        /// <summary>
        /// Checks if the given aggregate root is exist in the repository.
        /// </summary>
        /// <typeparam name="T">The type of the aggregate root.</typeparam>
        /// <param name="checking">The lambda expression which identifies the checking logic.</param>
        /// <param name="repository">The repository for the aggregate root.</param>
        /// <param name="requiresItExists">The checking logic switcher.</param>
        /// <exception>
        /// Throws when the
        ///     <cref>CloudNotes.WebAPI.Models.Exceptions.EntityAlreadyExistsException</cref>
        ///     <paramref name="requiresItExists"/> is set to <c>false</c> but the aggregate root exists.
        /// </exception>
        /// <exception>
        /// Throws when the
        ///     <cref>CloudNotes.WebAPI.Models.Exceptions.EntityDoesNotExistException</cref>
        ///     <paramref name="requiresItExists"/> is set to <c>true</c> but the aggregate root does not exist.
        /// </exception>
        protected virtual void RequireExistance<T>(Expression<Func<T, bool>> checking, IRepository<T> repository, bool requiresItExists = true)
            where T : class, IAggregateRoot
        {
            var existance = repository.Exists(Specification<T>.Eval(checking));
            if (!requiresItExists && existance)
                throw new EntityAlreadyExistsException(string.Format("The aggregate root of type '{0}' already exists in the repository. The checking expression is '{1}'.", typeof(T), checking));
            if (requiresItExists && !existance)
                throw new EntityDoesNotExistException(string.Format("The aggregate root of type '{0}' does not exist in the repository. The checking expression is '{1}'", typeof(T), checking));
        }

        /// <summary>
        /// Gets the by criteria.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="criteria">The criteria.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">repository</exception>
        /// <exception cref="System.InvalidOperationException">Cannot perform a paging query: The paging query requires the sorting but neither SortPredicate nor SortOrder was specified.</exception>
        protected virtual IEnumerable<TViewModel> GetByCriteria<TAggregateRoot, TViewModel>(IRepository<TAggregateRoot> repository,
            QueryCriteria criteria)
            where TAggregateRoot : class, IAggregateRoot
            where TViewModel : ViewModel
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            if (criteria == null)
            {
                return repository.FindAll()
                    .Project().To<TViewModel>();
            }

            Specification<TAggregateRoot> querySpecification = new AnySpecification<TAggregateRoot>();
            if (!string.IsNullOrEmpty(criteria.FilterExpression))
                querySpecification = Specification<TAggregateRoot>.Eval(System.Linq.Dynamic.DynamicExpression.ParseLambda<TAggregateRoot, bool>(criteria.FilterExpression));

            Expression<Func<TAggregateRoot, dynamic>> sortPredicate = null;
            if (!string.IsNullOrEmpty(criteria.SortingField))
                sortPredicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<TAggregateRoot, dynamic>(criteria.SortingField);

            var sortOrder = SortOrder.Unspecified;
            if (criteria.SortingOrder.HasValue)
                sortOrder = criteria.SortingOrder.Value;

            if (criteria.PageSize.HasValue && criteria.PageNumber.HasValue)
            {
                if (sortPredicate == null || sortOrder == SortOrder.Unspecified)
                    throw new InvalidOperationException("Cannot perform a paging query: The paging query requires the sorting but neither SortPredicate nor SortOrder was specified.");
                return repository.FindAll(querySpecification, sortPredicate, sortOrder,
                    criteria.PageNumber.Value, criteria.PageSize.Value).CastPagedResult(Mapper.Map<TAggregateRoot, TViewModel>);
            }
            return repository
                .FindAll(querySpecification, sortPredicate, sortOrder)
                .Project()
                .To<TViewModel>();
        }

        protected virtual IEnumerable<TViewModel> GetByCriteria<TAggregateRoot, TViewModel>(IRepository<TAggregateRoot> repository,
            string filterExpression = null, string sortingField = null, SortOrder? sortingOrder = null)
            where TAggregateRoot : class, IAggregateRoot
            where TViewModel : ViewModel
        {
            if (repository == null)
                throw new ArgumentNullException("repository");

            Specification<TAggregateRoot> querySpecification = new AnySpecification<TAggregateRoot>();
            if (!string.IsNullOrEmpty(filterExpression))
                querySpecification = Specification<TAggregateRoot>.Eval(System.Linq.Dynamic.DynamicExpression.ParseLambda<TAggregateRoot, bool>(filterExpression));
            Expression<Func<TAggregateRoot, dynamic>> sortPredicate = null;
            var sortOrder = sortingOrder ?? SortOrder.Unspecified;
            if (!string.IsNullOrEmpty(sortingField))
            {
                sortPredicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<TAggregateRoot, dynamic>(sortingField);
            }
            return repository.FindAll(querySpecification, sortPredicate, sortOrder).Project().To<TViewModel>();
        }

        /// <summary>
        /// Gets the paged result by criteria.
        /// </summary>
        /// <typeparam name="TAggregateRoot">The type of the aggregate root.</typeparam>
        /// <typeparam name="TViewModel">The type of the view model.</typeparam>
        /// <param name="repository">The repository.</param>
        /// <param name="pageNumber">The page number.</param>
        /// <param name="pageSize">Size of the page.</param>
        /// <param name="sortingField">The sorting field.</param>
        /// <param name="sortingOrder">The sorting order.</param>
        /// <param name="filterExpression">The filter expression.</param>
        /// <param name="expressionArgs">The expression arguments.</param>
        /// <returns></returns>
        /// <exception cref="System.ArgumentNullException">
        /// repository
        /// or
        /// sortingField
        /// </exception>
        protected virtual PagedResult<TViewModel> GetPagedResultByCriteria<TAggregateRoot, TViewModel>(IRepository<TAggregateRoot> repository,
            int pageNumber, int pageSize, string sortingField, SortOrder sortingOrder, string filterExpression = null, params object[] expressionArgs)
            where TAggregateRoot : class, IAggregateRoot
            where TViewModel : ViewModel
        {
            if (repository == null) throw new ArgumentNullException("repository");

            if (string.IsNullOrEmpty(sortingField))
                throw new ArgumentNullException("sortingField");

            if (sortingOrder == SortOrder.Unspecified)
                sortingOrder = SortOrder.Ascending;
            Specification<TAggregateRoot> querySpecification = new AnySpecification<TAggregateRoot>();
            if (!string.IsNullOrEmpty(filterExpression))
            {
                if (expressionArgs != null && expressionArgs.Length > 0)
                    querySpecification = Specification<TAggregateRoot>.Eval(System.Linq.Dynamic.DynamicExpression.ParseLambda<TAggregateRoot, bool>(filterExpression, expressionArgs));
                else
                    querySpecification = Specification<TAggregateRoot>.Eval(System.Linq.Dynamic.DynamicExpression.ParseLambda<TAggregateRoot, bool>(filterExpression));
            }
            var sortPredicate = System.Linq.Dynamic.DynamicExpression.ParseLambda<TAggregateRoot, dynamic>(sortingField);
            var result = repository.FindAll(querySpecification, sortPredicate, sortingOrder, pageNumber, pageSize);
            return result != null ? result.CastPagedResult(Mapper.Map<TAggregateRoot, TViewModel>) : null;
        }

        /// <summary>
        /// Releases the unmanaged resources that are used by the object and, optionally, releases the managed resources.
        /// </summary>
        /// <param name="disposing">true to release both managed and unmanaged resources; false to release only unmanaged resources.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (!disposed)
                {
                    this.repositoryContext.Dispose();
                    disposed = true;
                }
            }
            base.Dispose(disposing);
        }
    }
}