using Business.ViewModels;

namespace TestTask.Data.Interfaces
{
    public interface ITenantsService
    {
        public TenantViewModel[] Get();

        public TenantViewModel TenantById(int id);

        public TenantViewModel[] Insert(TenantViewModel tenant);

        public TenantViewModel[] ApartmentsTenant(int flatNumber);

        public TenantViewModel[] Exit(int tenantId);

        public TenantViewModel[] Actual(int flatNumber);
    }
}
