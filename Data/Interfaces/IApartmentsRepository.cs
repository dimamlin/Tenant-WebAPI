using System.Collections.Generic;
using TestTask.Data.Models;

namespace TestTask.Data.Interfaces
{
    public interface IApartmentsRepository
    {
        IEnumerable<Apartments> GetApartments { get; }

        Apartments GetObjectApartment(int apartmentId);
    }
}
