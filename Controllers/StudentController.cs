using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroAPI.Models;

namespace SuperHeroAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private static List<Student> students = new List<Student>
        {
            new Student
            {
                Id = 1,
                FirstName = "Dawoud",
                LastName = "Khawari"
            },

            new Student
            {
                Id = 2,
                FirstName = "Sedi",
                LastName = "Naseri"
            }
        };

        [HttpGet]
        public async Task<ActionResult<List<Student>>> Get()
        {
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Student>> Get(int id)
        {
            var student = students.Find(s => s.Id == id);
            if (student==null)
            {
                return BadRequest("Cant find Student");
            }
            return Ok(student);
        }

        [HttpPost]
        public async Task<ActionResult<List<SuperHero>>> AddStudent(Student student)
        {
            students.Add(student);
            return Ok(students);
        }
        //public Task<ActionResult<List<Student>>> AddStudent(Student student)
        //{
        //    students.Add(student);
        //    return Task.FromResult<ActionResult<List<Student>>>(Ok(students));
        //}
    }
}
