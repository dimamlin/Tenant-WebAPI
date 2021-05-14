using Business.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TestTask.Data.Interfaces;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ApartmentsController : ControllerBase
    {
        private readonly IApartmentsService apartmentsService;

        public ApartmentsController(IApartmentsService apartmentsService)
        {
            this.apartmentsService = apartmentsService;
        }

        [HttpGet]
        public ApartmentsViewModel[] Get() => apartmentsService.Get();

        [HttpGet("FullApartments")]
        public ApartmentsViewModel[] GetFullApartments()
        {
            return apartmentsService.GetFullApartments();
        }
    }
}
