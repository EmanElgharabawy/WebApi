using Day1WebApi.CustomFilter;
using Day1WebApi.Interface;
using Day1WebApi.Model.Database;
using Day1WebApi.Model.Resources;

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DepartmentController : ControllerBase
    {
        private readonly IDepartmentRep deptRep;

        public DepartmentController( IDepartmentRep deptRep)
        {
            this.deptRep = deptRep;
        }

        [HttpPost]
        [Filter]

        public IActionResult Create(Department Dept)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            deptRep.add(Dept);

            return Ok(new { Message = "Department added successfully" });
        }

        [HttpPut("{id}")]
        [Filter]

        public IActionResult Update([FromRoute] int id, [FromBody] Department updatedDepartment)
        {
            if (ModelState.IsValid)
            {

                Department oldData = deptRep.GetbyId(id);
                oldData.Location = updatedDepartment.Location;
                oldData.Name = updatedDepartment.Name;
                oldData.Manager = updatedDepartment.Manager;
            


                if (oldData == null)
                {
                    return NotFound(new { Message = "Department Not Found" });
                }

                deptRep.update(oldData);

                return Ok(new { Message = "Department Updated successfully" });
            }
            else
                return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult Getalldata()
        {
            var model = deptRep.GetAll();
            return Ok(model);
        }

        [HttpGet]
        [Route("{Deptname:alpha}")]
        public IActionResult GetByName(string Deptname)
        {
            var Department = deptRep.GetbyName(Deptname);

            if (Department == null)
            {
                return NotFound(new { Message = "Department Not Found" });
            }

            return Ok(Department);
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult getbyid(int id)
        {
            var Departmentbyid = deptRep.GetbyId(id);
            return Ok(Departmentbyid);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            deptRep.Delete(id);
            return Ok();

        }

    }
}
