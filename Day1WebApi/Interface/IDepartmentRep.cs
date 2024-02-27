using Day1WebApi.DTO;
using Day1WebApi.Model.Resources;

namespace Day1WebApi.Interface
{
    public interface IDepartmentRep
    {
        void add(Department std);
        void Delete(int id);
        void update(Department std);
        public List<Studentwithdepartment> GetAll();

        Department GetbyId(int id);
        Department GetbyName(string Name);
    }
}
