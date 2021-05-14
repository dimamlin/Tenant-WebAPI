using System.Collections.Generic;
using System.Linq;
using TestTask.Data.Interfaces;
using TestTask.Data.Models;

namespace TestTask.Data.Repository
{
    public class ApartmentsRepository : IApartmentsRepository
    {
        private readonly AppDBContent appDBContent;

        public ApartmentsRepository(AppDBContent appDBContent)
        {
            this.appDBContent = appDBContent;
        }

        public IEnumerable<Apartments> GetApartments
        {
            get
            {
                return appDBContent.Apartments;
            }
        }

        public Apartments GetObjectApartment(int apartmentId)
        {
            return appDBContent.Apartments.FirstOrDefault(p => p.Id == apartmentId);
        }
    }
}
