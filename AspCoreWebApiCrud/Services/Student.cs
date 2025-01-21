using AspCoreWebApiCrud.IServices;
using AspCoreWebApiCrud.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace AspCoreWebApiCrud.Services
{
    public class Student : IStudent
    {
        private readonly StudentContext _studentContext;
        public Student(StudentContext studentContext)
        {
            _studentContext = studentContext;
        }
        public async Task<ActionResult<List<StudentModel>>> GetStudentDetails()
        {
            var item = await _studentContext.Students.ToListAsync();
            return item;
        }
        public async Task<ActionResult<StudentModel>> GetStudentById(int Id)
        {
            return await _studentContext.Students.FindAsync(Id);
        }

        public async Task<ActionResult<StudentModel>> PostStudentDetails(StudentModel student)
        {
            try
            {
                var item = await _studentContext.Students.AddAsync(student);
                await _studentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            return student;
        }

        public async Task<ActionResult<StudentModel>> UpdateStudentDetails(int Id, StudentModel studentModel)
        {
           // var item = await _studentContext.Students.FindAsync(Id);
            if(Id!=studentModel.Id)
            {
                //return item;
            }
            _studentContext.Entry(studentModel).State = EntityState.Modified;
            try
            {
                await _studentContext.SaveChangesAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
           
            return studentModel;
        }
        public async Task<ActionResult<StudentModel>> DeleteStudentDetails(int Id)
        {
            var item=await  _studentContext.Students.FirstOrDefaultAsync(x => x.Id == Id);
            if(item == null)
            {
                return item;
            }
            _studentContext.Students.Remove(item);
            await _studentContext.SaveChangesAsync();
            return item;
        }
    }
}
