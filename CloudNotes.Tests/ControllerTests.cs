using Apworks;
using Apworks.Repositories;
using Apworks.Specifications;

using CloudNotes.Domain.Model;
using CloudNotes.WebAPI;
using CloudNotes.WebAPI.Models.Filters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Security.Principal;
using System.Threading;

namespace CloudNotes.Tests
{
    [TestClass]
    public abstract class ControllerTests
    {
        private readonly Mock<IRepositoryContext> mockRepositoryContext = new Mock<IRepositoryContext>();

        private readonly User currentLoginUser = new User
                                                     {
                                                         DateRegistered = DateTime.UtcNow,
                                                         Email = "test.cloudnotes@daxnetsvr.cloudapp.net",
                                                         ID = Guid.NewGuid(),
                                                         Notes = null,
                                                         Password = "Sfe@3322",
                                                         Roles = null,
                                                         UserName = "test.cloudnotes"
                                                     };

        protected ControllerTests()
        {
            this.InjectLoginUser(currentLoginUser);
            mockRepositoryContext.Setup(x => x.Commit()).Callback(() => { });
        }

        protected Mock<IRepositoryContext> MockRepositoryContext
        {
            get
            {
                return this.mockRepositoryContext;
            }
        }

        protected User CurrentLoginUser
        {
            get
            {
                return this.currentLoginUser;
            }
        }

        protected void InjectLoginUser(User user)
        {
            Thread.CurrentPrincipal = new GenericPrincipal(
                 new BasicAuthenticationIdentity(user, "Basic"),
                 new[] { "Administrator" });
        }

        protected Mock<IRepository<T>> CreateMockRepository<T>(Action<T> addAction = null,
            Action<T> removeAction = null,
            Action<T> updateAction = null,
            Func<ISpecification<T>, bool> existsAction = null,
            Func<ISpecification<T>, T> findAction = null,
            Func<object, T> getByKeyResult = null)
            where T : class, IAggregateRoot
        {
            var mockRepository = new Mock<IRepository<T>>();

            if (addAction != null) mockRepository.Setup(x => x.Add(It.IsAny<T>())).Callback(addAction);

            if (existsAction != null) mockRepository.Setup(x => x.Exists(It.IsAny<ISpecification<T>>())).Returns(existsAction);

            if (findAction != null) mockRepository.Setup(x => x.Find(It.IsAny<ISpecification<T>>())).Returns(findAction);

            if (getByKeyResult != null) mockRepository.Setup(x => x.GetByKey(It.IsAny<Guid>())).Returns(getByKeyResult);

            if (removeAction != null) mockRepository.Setup(x => x.Remove(It.IsAny<T>())).Callback(removeAction);

            if (updateAction != null) mockRepository.Setup(x => x.Update(It.IsAny<T>())).Callback(updateAction);

            return mockRepository;
        }

        [AssemblyInitialize]
        public static void AssemblyInitialization(TestContext context)
        {
            AutoMapperConfig.Initialize();
        }
    }
}
