using System.Collections.Generic;
using TestTask.Data.Models;

namespace TestTask.Data.Interfaces
{
    public interface ITenantsRepository
    {
        IEnumerable<Tenant> GetTenants { get; }

        Tenant GetTenantById(int tenantId);

        void InsertTenant(Tenant tenant);

        IEnumerable<Tenant> TenantsInApartments(int apartmentsId);

        void ExitTenant(int id);

        IEnumerable<Tenant> ActualTenantsInApartments(int apartmentsId);
    }
}
