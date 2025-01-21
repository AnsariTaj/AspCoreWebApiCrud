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
