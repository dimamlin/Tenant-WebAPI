using Business.ViewModels;
using Moq;
using System;
using System.Collections.Generic;
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

            var result = service.Get();

            Assert.NotNull(result);
            Assert.IsType<ApartmentsViewModel[]>(result);
        }

        [Fact]
        public void GetFullApartmentsReturnsCorrectResult()
        {
            var mock = new Mock<IUnitOfWork>();
            mock.Setup(apartments => apartments.ApartmentsRepository.GetApartments).Returns(mock.Object.ApartmentsRepository.GetApartments);
            var service = new ApartmentsService(mock.Object);

            var result = service.GetFullApartments();

            Assert.NotNull(result);
            Assert.IsType<ApartmentsViewModel[]>(result);
        }
    }
}
