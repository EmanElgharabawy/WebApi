namespace Day1WebApi.DTO
{
    public class Studentwithdepartment
    {
        public int DeptId { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public string Manager { get; set; }
        public List<string> Students { get; set; }
    }
}
