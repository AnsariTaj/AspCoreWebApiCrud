namespace AspDotNetCoreCrudMvc.Models
{
    public class Rootobject
    {
        public bool success { get; set; }
        public string message { get; set; }
        public Data data { get; set; }
    }
    public class Status
    {
        public bool success { get; set; }
        public string message { get; set; }
        public DataResult data { get; set; }
    }
    public class DataResult
    {
        public object result { get; set; }
        public Value value { get; set; }
    }
    public class Data
    {
        public object result { get; set; }
        public IEnumerable< Value> value { get; set; }
    }

    public class Value
    {
        public int id { get; set; }
        public string? StudentName { get; set; }
        public string? StudentGender { get; set; }
        public int Age { get; set; }
        public int Standard { get; set; }
        public string? FatherName { get; set; }
    }
}
