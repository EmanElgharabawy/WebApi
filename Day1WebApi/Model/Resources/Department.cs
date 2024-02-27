using Day1WebApi.Validation;
using System.Collections.Generic;

namespace Day1WebApi.Model.Resources
{
    public class Department
    {
        public int Id { get; set; }
        [UniqueeName]
        public string Name { get; set; }
        public string Location { get; set; }
        public string Manager { get; set; }

        public ICollection<Student> student { get; } = new HashSet<Student>();
    }
}
