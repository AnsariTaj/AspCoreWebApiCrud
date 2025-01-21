using AspCoreWebApiCrud.Models;
using Microsoft.AspNetCore.Mvc;

namespace AspCoreWebApiCrud.IServices
{
    public interface IStudent
    {
        Task<ActionResult<List<StudentModel>>> GetStudentDetails();
        Task<ActionResult<StudentModel>> GetStudentById(int Id);
        Task<ActionResult<StudentModel>> PostStudentDetails(StudentModel student);
        Task<ActionResult<StudentModel>> UpdateStudentDetails(int Id, StudentModel studentModel);
        Task<ActionResult<StudentModel>> DeleteStudentDetails(int Id);

    }
}
