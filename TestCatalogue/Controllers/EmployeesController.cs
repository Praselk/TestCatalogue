using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using TestCatalogue.BLL.Interfaces;

namespace TestCatalogue.Controllers
{
    [Route("api/employees")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        ICatalogueService service;
        public EmployeesController(ICatalogueService srv)
        {
            this.service = srv;
        }

        [Produces("application/json")]
        [HttpGet("search")]
        [Route("api/employees/search")]
        public IActionResult Search()
        {
            try
            {
                string term = HttpContext.Request.Query["term"].ToString();

                var names = service.Employees.GetAll().Where(emp => emp.FirstName.Contains(term))
                        .Select(emp => emp.FirstName).ToList();
                return Ok(names);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
