using Business.ViewModels;
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
            Tenant tenant = unitOfWork.TenantsRepository.GetTenantById(id);
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
            bool flag = true;
            foreach(var phone in unitOfWork.TenantsRepository.GetTenants.Select(tenant => tenant.PhoneNumber))
            {
                if(phone == tenant.PhoneNumber)
                {
                    flag = false;
                }
            }

            if (flag)
            {
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
            }

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
