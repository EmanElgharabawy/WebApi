using Day1WebApi.Interface;
using Day1WebApi.Model.Resources;
using Day1WebApi.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Day1WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]


    public class StudentController : ControllerBase
    {
        private readonly IStudentRep stdRep;

        public StudentController( IStudentRep stdRep)
        {
            this.stdRep = stdRep;
        }

        [HttpPost]
        public IActionResult Create(Student std)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             stdRep.add(std);

            return Ok(new { Message = "Student added successfully"});
        }

        [HttpPut("{id}")]
        
        public IActionResult Update( [FromRoute]int id , [FromBody]Student updatedStudent)
        {
            if (ModelState.IsValid)
            {

                Student oldData = stdRep.GetbyId(id);
                oldData.Age = updatedStudent.Age;
                oldData.Name = updatedStudent.Name;
                oldData.Address = updatedStudent.Address;
                oldData.Image = updatedStudent.Image;

                if (oldData == null)
                {
                    return NotFound(new { Message = "Student Not Found" });
                }

                stdRep.update(oldData);
                
                return Ok(new { Message = "Student Updated successfully" });
            }
            else
                return BadRequest(ModelState);
        }

        [HttpGet]
        public IActionResult Getalldata()
        {  
            var model = stdRep.Getalldata();
            return Ok(model);
        }

        [HttpGet]
        [Route("{stdname:alpha}")]
        public IActionResult GetByName(string stdname)
        {
            var student = stdRep.GetbyName(stdname);

            if (student == null)
            {
                return NotFound(new { Message = "Student Not Found" });
            }

            return Ok(student);
        }

        [HttpGet]
        [Route("{id:int}")]

        public IActionResult getbyid(int id)
        { 
          var studentbyid= stdRep.GetbyId(id);
            return Ok(studentbyid);
        }

        [HttpDelete]
        public IActionResult Delete(int  id )
        {
           stdRep.Delete(id);
            return Ok();

        }
    }
}
