using Business.ViewModels;

namespace TestTask.Data.Interfaces
{
    public interface IApartmentsService
    {
        public ApartmentsViewModel[] Get();

        public ApartmentsViewModel[] GetFullApartments();
    }
}
