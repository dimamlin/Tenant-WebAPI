namespace TestTask.Data.Interfaces
{
    public interface IUnitOfWork
    {
        ITenantsRepository TenantsRepository { get; }

        IApartmentsRepository ApartmentsRepository { get; }

        void Save();
    }
}
