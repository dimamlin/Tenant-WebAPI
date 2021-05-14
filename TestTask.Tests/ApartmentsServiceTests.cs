using Business.ViewModels;
using Moq;
using TestTask.Data.Interfaces;
using TestTask.Data.Models;
using TestTask.Services;
using Xunit;

namespace TestTask.Tests
{
    public class ApartmentsServiceTests
    {
        [Fact]
        public void GetApartmentsReturnsCorrectResult()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(apartments => apartments.ApartmentsRepository.GetApartments);
            var service = new ApartmentsService(mock.Object);

            var result = service.GetFullApartments();

            Assert.NotNull(result);
            Assert.IsType<ApartmentsViewModel[]>(result);
        }

        private ApartmentsViewModel GetTestApartments() => new ApartmentsViewModel { Number = "1", RoomsCount = 2 };
    }
}
