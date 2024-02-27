using Day1WebApi.Controllers;
using Day1WebApi.Interface;
using Day1WebApi.Model.Database;
using Day1WebApi.Model.Resources;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Day1WebApi.Repository
{
    public class StudentERep : IStudentRep
    {
        private readonly Studentdbcontext db;

        public StudentERep(Studentdbcontext db)
        {
            this.db = db;
        }
        void IStudentRep.add(Student std)
        {
            db.Student.Add(std);
            db.SaveChanges();
        }

        Student IStudentRep.GetbyId(int id)
        {
            return db.Student.Find(id);

        }
        void IStudentRep.Delete(int  id)
        {
            var student = db.Student.Find(id);
            db.Student.Remove(student);
            db.SaveChanges();
        }

        IEnumerable<Student> IStudentRep.Getalldata()
        {
            return db.Student.Include(a => a.Department).Select(s => s);

        }

      

        Student IStudentRep.GetbyName(string Name)
        {
            return db.Student.FirstOrDefault(a => a.Name == Name);

        }

        void IStudentRep.update(Student std)
        {
            
            db.SaveChanges();

        }
    }
}
