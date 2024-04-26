using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace newZealandWalks.API.Controllers
{
    [Route("api/[controller]")] // https://localhost:PORT/api/students
    [ApiController]
    public class StudentsController : ControllerBase
    {
        [HttpGet] // GET: https://localhost:PORT/api/students
        public IActionResult GetAllStudents()
        {
            string[] studentNames = new string[] { "Jon", "Jon", "Jon", "Jon", "Jon" };

            return Ok(studentNames);
        }
    }
}
