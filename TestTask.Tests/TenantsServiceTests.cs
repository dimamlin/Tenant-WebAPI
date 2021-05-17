using Business.ViewModels;
using Moq;
using System.Collections.Generic;
using TestTask.Data.Interfaces;
using TestTask.Data.Models;
using TestTask.Services;
using Xunit;

namespace TestTask.Tests
{
    public class TenantsServiceTests
    {
        [Fact]  
        public void GetTenantByIdReturnsCorrectResult()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(tenant => tenant.TenantsRepository.GetTenantById(2)).Returns(GetTestTenant());
            var service =  new TenantsService(mock.Object);

            var result = service.TenantById(2);

            Assert.Equal(result.FirstName, GetTestTenant().FirstName);
            Assert.IsType<TenantViewModel>(result);
        }

        private Tenant GetTestTenant()
        {
            return new Tenant { Id = 1, FirstName = "Dzmitry", LastName = "Brendom" };
        }

        [Fact]
        public void GetReturnsTenantsOnStartPage()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(tenant => tenant.TenantsRepository.GetTenants);
            var service = new TenantsService(mock.Object);

            var result = service.Get();

            Assert.IsType<TenantViewModel[]>(result);
        }

        private List<Tenant> GetTestTenants()
        {
            var tenants = new List<Tenant>
            {
                new Tenant { Id=1, FirstName="Dzmitry", LastName="Brendom"},
                new Tenant { Id=2, FirstName="David", LastName="Guetta"}
            };
            return tenants;
        }

        [Fact]
        public void InsertAddValidTenantWithUniquePhoneNumber()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(tenant => tenant.TenantsRepository.InsertTenant(GetTestTenant()));
            var service = new TenantsService(mock.Object);

            var result = service.Insert(GetTenantViewModel());

            Assert.IsType<TenantViewModel[]>(result);
            Assert.True(GetTenantViewModel().PhoneNumber == "+3752987546530");
            Assert.NotNull(result);
        }

        private TenantViewModel GetTenantViewModel()
        {
            return new TenantViewModel { FirstName = "Jack", LastName = "Nivman", PhoneNumber = "+3752987546530", FlatNunmber = 3, IsTenant = true };
        }

        [Fact]
        public void HistoryReturnsCorrectTenants()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(tenant => tenant.TenantsRepository.TenantsInApartments(1)).Returns(mock.Object.TenantsRepository.TenantsInApartments(1));
            var service = new TenantsService(mock.Object);

            var result = service.Insert(GetTenantViewModel());

            Assert.IsType<TenantViewModel[]>(result);
            Assert.True(GetTenantViewModel().PhoneNumber == "+3752987546530");
            Assert.NotNull(result);
        }

        [Fact]
        public void ExitEvictedCorrectTenant()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(tenant => tenant.TenantsRepository.ExitTenant(1));
            var service = new TenantsService(mock.Object);

            var result = service.Exit(1);

            Assert.IsType<TenantViewModel[]>(result);
            Assert.NotNull(result);
        }

        [Fact]
        public void ActualReturnsCorrectTenants()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(tenant => tenant.TenantsRepository.ActualTenantsInApartments(1)).Returns(mock.Object.TenantsRepository.ActualTenantsInApartments(1));
            var service = new TenantsService(mock.Object);

            var result = service.Actual(1);

            Assert.IsType<TenantViewModel[]>(result);
            Assert.NotNull(result);
        }
    }
}
