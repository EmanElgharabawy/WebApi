using Day1WebApi.DTO;
using Day1WebApi.Interface;
using Day1WebApi.Model.Database;
using Day1WebApi.Model.Resources;
using Microsoft.EntityFrameworkCore;

namespace Day1WebApi.Repository
{
    public class DepartmentRep : IDepartmentRep
    {
        private readonly Studentdbcontext db;

        public DepartmentRep(Studentdbcontext db)
        {
            this.db = db;
        }
        public void add(Department Dept)
        {
            db.Department.Add(Dept);
            db.SaveChanges();
        }

        public void Delete(int id)
        {
            var model = db.Department.FirstOrDefault(d => d.Id == id);
            db.Department.Remove(model);
            db.SaveChanges();
        }

        public List<Studentwithdepartment> GetAll()
        {
            var department = db.Department.Include(dept => dept.student).ToList();
            List<Studentwithdepartment> deptWithStuds = new List<Studentwithdepartment>();
            foreach (var dept in department)
            {
                var singleDept = new Studentwithdepartment()
                {
                    DeptId = dept.Id,
                    Name = dept.Name,
                    Location = dept.Location,
                    Manager = dept.Manager,
                    Students = dept.student.Select(x => x.Name).ToList()
                };
                deptWithStuds.Add(singleDept);
            }
            return deptWithStuds;
        }

       

        public Department GetbyId(int id)
        {
            return db.Department.Find(id);
        }

        public Department GetbyName(string Name)
        {
            return db.Department.FirstOrDefault(a => a.Name == Name);
        }

        public void update(Department std)
        {

            db.SaveChanges();


        }
    }
}
