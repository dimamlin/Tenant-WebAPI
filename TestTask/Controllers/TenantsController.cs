using Business.ViewModels;
using Microsoft.AspNetCore.Mvc;
using TestTask.Data.Interfaces;

namespace TestTask.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TenantsController : ControllerBase
    {
        private readonly ITenantsService tenantsService;

        public TenantsController(ITenantsService tenantsService)
        {
            this.tenantsService = tenantsService;
        }

        [HttpGet]
        public TenantViewModel[] Get()
        {
            return tenantsService.Get();
        }

        [HttpGet("TenantById/{Id}")]
        public TenantViewModel GetTenantById(int id)
        {
            return tenantsService.TenantById(id);
        }

        [HttpPost]
        public TenantViewModel[] Insert([FromBody] TenantViewModel tenant)
        {
            return tenantsService.Insert(tenant);
        }

        [HttpGet("History/{flatNumber}")]
        public TenantViewModel[] GetApartmentsHistory(int flatNumber) 
        {
            return tenantsService.ApartmentsTenant(flatNumber);
        } 

        [HttpGet("EvictedTenant/{Id}")] 
        public TenantViewModel[] Exit(int Id) 
        {
            return tenantsService.Exit(Id);
        } 

        [HttpGet("ActualTenants/{flatNumber}")]
        public TenantViewModel[] GetActualTenants(int flatNumber) 
        {
            return tenantsService.Actual(flatNumber);
        }
     }
}
