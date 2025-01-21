namespace AspDotNetCoreCrudMvc.Models
{
    public class Rootobject
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }

    public class Data
    {
        public object result { get; set; }
        public IEnumerable< Value> value { get; set; }
    }

    public class Value
    {
        public int id { get; set; }
        public string studentName { get; set; }
        public string studentGender { get; set; }
        public int age { get; set; }
        public int standard { get; set; }
        public string fatherName { get; set; }
    }
}
