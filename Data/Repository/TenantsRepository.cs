using System.Collections.Generic;
using System.Linq;
using TestTask.Data.Interfaces;
using TestTask.Data.Models;

namespace TestTask.Data.Repository
{
    public class TenantsRepository : ITenantsRepository
    {
        private readonly AppDBContent appDBContent;

        public TenantsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }
        
        public IEnumerable<Tenant> GetTenants
        {
            get 
            {
                return appDBContent.Tenant;
            }
        }

        public Tenant GetTenantById(int tenantId)
        {
            return appDBContent.Tenant.FirstOrDefault(p => p.Id == tenantId);
        }

        public void InsertTenant(Tenant tenant)
        {
            appDBContent.Tenant.Add(tenant);
            appDBContent.SaveChanges();
        }

        public IEnumerable<Tenant> TenantsInApartments(int apartmentsId)
        {
            return appDBContent.Tenant.Where(x => x.FlatNunmber == apartmentsId).ToList();
        }

        public void ExitTenant(int id)
        {
            appDBContent.Tenant.FirstOrDefault(p => p.Id == id).IsTenant = false;
        }

        public IEnumerable<Tenant> ActualTenantsInApartments(int apartmentsId)
        {
            return appDBContent.Tenant.Where(x => x.ApartmentsId == apartmentsId && x.IsTenant == true);
        }
    }
}
