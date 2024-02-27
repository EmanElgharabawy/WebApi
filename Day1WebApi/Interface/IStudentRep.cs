using Day1WebApi.Model.Resources;

namespace Day1WebApi.Interface
{
    public interface IStudentRep
    {
        void add(Student std);
        void Delete(int id);
        void update(Student std);
        IEnumerable<Student> Getalldata();

        Student GetbyId(int id);
        Student GetbyName(string Name);
    }
}
