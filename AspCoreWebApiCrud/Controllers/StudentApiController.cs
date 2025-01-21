using AspCoreWebApiCrud.IServices;
using AspCoreWebApiCrud.Models;
using AspCoreWebApiCrud.Services;
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
        private readonly IStudent _student;

        public StudentApiController(StudentContext studentContext, IStudent student)
        {
            this.studentContext = studentContext;
            _student = student;
        }
        [HttpGet]
        [Route("GetAllStudent")]
        public async Task<ActionResult<List<StudentModel>>> GetStudentDetails()
        {            
            var item = await _student.GetStudentDetails();
            if (item == null)
            {
                return NotFound();
            }
            var response = new
            {
                Success = true,
                Message = "Student details got seccessfully",
                Data = item
            };
            return Ok(response);
        }
        [HttpGet]
        [Route("GetStudentById/Id")]
        public async Task<ActionResult<StudentModel>> GetStudentById(int Id)
        {
            var item = await _student.GetStudentById(Id);
            if (item == null)
            {
                return NotFound(new { Message = $"Not found id {Id} student details" });
            }
            var response = new
            {
                Success = true,
                Message = "Item getById successfully.",
                Data = item
            };
            return Ok(response);
        }
        [HttpPost]
        [Route("PostStudentDetails/student")]
        public async Task<ActionResult<StudentModel>> PostStudentDetails(StudentModel student)
        {
            if (student == null)
            {
                return BadRequest(new { Message = "Invalid input data." });
            }
            var item = await _student.PostStudentDetails(student);
           
            var response = new
            {
                Success = true,
                Message = "Item created successfully.",
                Data = student
            };
            return Ok(response);
        }
        [HttpPut("{Id}")]
        public async Task<ActionResult<StudentModel>> UpdateStudentDetails(int Id, StudentModel studentModel)
        {
            var item = await _student.UpdateStudentDetails(Id, studentModel);
            try
            {              
               
                if (item == null)
                {
                    return BadRequest(new {Message=$"Invalid input data." });
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            var respone = new
            {
                satus = true,
                Message = "Item got updated successfully",
                Data = item
            };
            return Ok(respone);
        }
        [HttpDelete("{Id}")]
        public async Task<ActionResult<StudentModel>> DeleteStudentDetails(int Id)
        {
            try
            {
                var item =await _student.DeleteStudentDetails(Id);
            }
            catch (Exception ex)
            {

                throw;
            }           
            return Ok(Id);
        }
    }
}
