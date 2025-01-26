using AspCoreWebApiCrud.Models;
using AspDotNetCoreCrudMvc.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace AspDotNetCoreCrudMvc.Controllers
{
    public class StudentController : Controller
    {       
        private HttpClient client=new HttpClient();
        [HttpGet]
        public IActionResult Index()
        {
            List<Value> students = new List<Value>();
            try
            {
                HttpResponseMessage response = client.GetAsync(AppSetting.Url + "GetAllStudent").Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;                   
                    var rootobject = JsonConvert.DeserializeObject<Rootobject>(result);
                    if (rootobject != null)
                    {
                        students = rootobject.data.value.ToList();                       
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return View(students);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult PostStudentDetails(Value value)
        {
            try
            {
                var data = JsonConvert.SerializeObject(value);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PostAsync(AppSetting.Url+"PostStudentDetails/Student", content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["Insert_message"] = "Student Details successfully added!!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }
        [HttpGet]
        public IActionResult Edit(int id)
        {
           Value value=new Value();
            try
            {
                HttpResponseMessage response = client.GetAsync(AppSetting.Url + "GetStudentById/Id?Id=" + id).Result;
                if (response.IsSuccessStatusCode)
                {
                    string result = response.Content.ReadAsStringAsync().Result;
                    var rootobject = JsonConvert.DeserializeObject<Status>(result);
                    if (rootobject != null)
                    {
                        value = rootobject.data.value;
                    }
                }
            }
            catch (Exception ex)
            {

                throw;
            }
           
            return View(value);
        }
     
        public IActionResult UpdateStudentDetails(Value value)
        {
            string message = "";
            try
            {
                var data = JsonConvert.SerializeObject(value);
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");
                HttpResponseMessage response = client.PutAsync(AppSetting.Url + value.id,content).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["Update_Message"] = "Student Details Updated Successlly!!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                message = ex.Message;
                
            }
            return View(message);
        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            try
            {
                HttpResponseMessage response = client.DeleteAsync(AppSetting.Url+id).Result;
                if (response.IsSuccessStatusCode)
                {
                    TempData["Delete_Message"] = $"Student Id {id} Deleted Successlly!!";
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {

                throw;
            }
            return View();
        }
    }
}
