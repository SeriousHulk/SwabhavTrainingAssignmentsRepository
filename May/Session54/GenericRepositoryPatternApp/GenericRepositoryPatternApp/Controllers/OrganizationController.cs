using GenericRepositoryPatternApp.EF;
using GenericRepositoryPatternApp.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepositoryPatternApp.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class OrganizationController : ControllerBase
    {
        private IRepository<Organization> _repository;
        public OrganizationController(IRepository<Organization> organizationRepo) 
        {
            _repository = organizationRepo;
        }
        [Route("/getAll")]
        [HttpGet]
        public IActionResult GetAllOrganizations()
        {
            var organizations = _repository.Get().ToList();
            return Ok(organizations);
        }
        [Route("/addOrganization")]
        [HttpPost]
        public IActionResult GetAllOrganizations(Organization organization)
        {
            _repository.Add(organization);
            return Ok();
        }

    }
}
