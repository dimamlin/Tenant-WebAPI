using TestTask.Data.Interfaces;

namespace TestTask.Data.Repository
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDBContent appDBContent;
        private ITenantsRepository tenantsRepository;
        private IApartmentsRepository apartmentsRepository;

        public UnitOfWork(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public ITenantsRepository TenantsRepository
        {
            get
            {
                return tenantsRepository ??= new TenantsRepository(appDBContent);
            }
        }

        public IApartmentsRepository ApartmentsRepository 
        {
            get
            {
                return apartmentsRepository ??= new ApartmentsRepository(appDBContent);
            }
        } 

        public void Save()
        {
            appDBContent.SaveChanges();
        }
    }
}
