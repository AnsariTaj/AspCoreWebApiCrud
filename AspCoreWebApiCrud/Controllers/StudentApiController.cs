using AspCoreWebApiCrud.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreWebApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentApiController : ControllerBase
    {
        private readonly StudentContext studentContext;

        public StudentApiController(StudentContext studentContext)
        {
            this.studentContext = studentContext;
        }
        [HttpGet]
        [Route("GetAllStudent")]
        public async Task<ActionResult<List<StudentModel>>> GetStudentDetails()
        {
            var item = await studentContext.Students.ToListAsync();
            if (item == null)
            {
                return NotFound(new { Message = $"Item not found." });
            }
            return Ok(item);
        }
        [HttpGet]
        [Route("GetStudentById/Id")]
        public async Task<ActionResult<StudentModel>> GetStudentById(int Id)
        {
            var item = await studentContext.Students.FirstOrDefaultAsync(s => s.Id == Id);
            if (item == null)
            {
                return NotFound(new { Message = $"Not found id {Id} student details" });
            }
            return Ok(item);
        }
        [HttpPost]
        [Route("PostStudentDetails/student")]
        public async Task<ActionResult<StudentModel>> PostStudentDetails(StudentModel student)
        {
            await studentContext.Students.AddAsync(student);
            await studentContext.SaveChangesAsync();
            return Ok(student);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<StudentModel>> UpdateStudentDetails(int Id,StudentModel studentModel)
        {
            var item = await studentContext.Students.FindAsync(Id);
            if (item == null)
            {
                return NotFound(new { Message = $"The id {Id} is not found in data base!!" });
            }
            if (Id != studentModel.Id)
            {
                return BadRequest(new {Message=$"Id should be match in both places!!"});
            }
            studentContext.Entry(studentModel).State = EntityState.Modified;
            await studentContext.SaveChangesAsync();
            return Ok(studentModel);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<StudentModel>> DeleteStudentDetails(int Id)
        {
            var item = await studentContext.Students.FindAsync(Id);
            if (item == null)
            {
                return NotFound();
            }
            studentContext.Students.Remove(item);
            await studentContext.SaveChangesAsync();
            return Ok();
        }
    }
}
