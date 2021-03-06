using Business.ViewModels;
using System;
using System.Linq;
using TestTask.Data.Interfaces;
using TestTask.Data.Models;

namespace TestTask.Services
{
    public class TenantsService : ITenantsService
    {
        private readonly IUnitOfWork unitOfWork;
        
        public TenantsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public TenantViewModel[] Get() 
        {
            return unitOfWork.TenantsRepository.GetTenants.Select(tenant => new TenantViewModel
            {
                FirstName = tenant.FirstName,
                LastName = tenant.LastName,
                PhoneNumber = tenant.PhoneNumber,
                FlatNunmber = tenant.FlatNunmber,
                IsTenant = tenant.IsTenant
            }
            ).ToArray();
        }

        public TenantViewModel TenantById(int id)
        {
            var tenant = unitOfWork.TenantsRepository.GetTenantById(id);
            return new TenantViewModel {
                FirstName = tenant.FirstName,
                LastName = tenant.LastName,
                PhoneNumber = tenant.PhoneNumber,
                FlatNunmber = tenant.FlatNunmber,
                IsTenant = tenant.IsTenant
            };
        }

        public TenantViewModel[] Insert(TenantViewModel tenant)
        {
            if(unitOfWork.TenantsRepository.GetTenants.Any(x => x.PhoneNumber == tenant.PhoneNumber))
            {
                throw new Exception("Phone number is not unique: " + tenant.PhoneNumber);
            }

            unitOfWork.TenantsRepository.InsertTenant(
               new Tenant
               {
                   FirstName = tenant.FirstName,
                   LastName = tenant.LastName,
                   PhoneNumber = tenant.PhoneNumber,
                   FlatNunmber = tenant.FlatNunmber,
                   IsTenant = tenant.IsTenant
               });

                unitOfWork.Save();

            return unitOfWork.TenantsRepository.GetTenants.Select(tenant => new TenantViewModel
            {
                FirstName = tenant.FirstName,
                LastName = tenant.LastName,
                PhoneNumber = tenant.PhoneNumber,
                FlatNunmber = tenant.FlatNunmber,
                IsTenant = tenant.IsTenant
            }
            ).ToArray();
        }

        public TenantViewModel[] ApartmentsTenant(int flatNumber)
        {
            return unitOfWork.TenantsRepository.TenantsInApartments(flatNumber).Select(tenant => new TenantViewModel
            {
                FirstName = tenant.FirstName,
                LastName = tenant.LastName,
                PhoneNumber = tenant.PhoneNumber,
                FlatNunmber = tenant.FlatNunmber,
                IsTenant = tenant.IsTenant
            }
            ).ToArray();
        }

        public TenantViewModel[] Exit(int tenantId) 
        {
            unitOfWork.TenantsRepository.ExitTenant(tenantId);
            unitOfWork.Save();

            return unitOfWork.TenantsRepository.GetTenants.Select(tenant => new TenantViewModel
            {
                FirstName = tenant.FirstName,
                LastName = tenant.LastName,
                PhoneNumber = tenant.PhoneNumber,
                FlatNunmber = tenant.FlatNunmber,
                IsTenant = tenant.IsTenant
            }
            ).ToArray();
        }

        public TenantViewModel[] Actual(int flatNumber)
        {
            return unitOfWork.TenantsRepository.ActualTenantsInApartments(flatNumber).Select(tenant => new TenantViewModel
            {
                FirstName = tenant.FirstName,
                LastName = tenant.LastName,
                PhoneNumber = tenant.PhoneNumber,
                FlatNunmber = tenant.FlatNunmber,
                IsTenant = tenant.IsTenant
            }
            ).ToArray();
        }
    }
}
