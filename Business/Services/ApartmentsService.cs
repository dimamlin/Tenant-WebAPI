using Business.ViewModels;
using System.Linq;
using TestTask.Data.Interfaces;

namespace TestTask.Services
{
    public class ApartmentsService : IApartmentsService
    {
        private readonly IUnitOfWork unitOfWork;

        public ApartmentsService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public ApartmentsViewModel[] Get()
        {
            return unitOfWork.ApartmentsRepository.GetApartments.Select(apartments => new ApartmentsViewModel
            {
                Number = apartments.Number,
                RoomsCount = apartments.RoomsCount
            }
            ).ToArray();
        }

        public ApartmentsViewModel[] GetFullApartments()
        {
            return unitOfWork.ApartmentsRepository.GetApartments.Where(a => a.RoomsCount < unitOfWork.TenantsRepository.ActualTenantsInApartments(a.Id).Count()).Select(apartments => new ApartmentsViewModel
            {
                Number = apartments.Number,
                RoomsCount = apartments.RoomsCount
            }
            ).ToArray();
        }
    }
}
