using CollegeApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections;


namespace CollegeApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {

        [HttpGet]
        [Route("All")]//

      public ActionResult<IEnumerable<StudentDTO>> Students(StudentDTO model)
        {
            var student = ClassRepository.Students.Select(n=> new StudentDTO()

            {
                id = model.id,
                name = model.name,
                email = model.email,
                phone = model.phone



            });
            return Ok(student);
        }




        [HttpGet("{id:int}")]
        [ProducesResponseType(200)]  //here we are documenting web api responce so 
        [ProducesResponseType(400)] //user will have preidea what are possible responce from this endpoint
        [ProducesResponseType(404)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<Student> GetStudentById(int id)
        {

            if (id <= 0)
            {
                //statuscode 400
                return BadRequest();
            }
            var obj = ClassRepository.Students.Where(n => n.id == id).FirstOrDefault();

            if (obj == null)
                //statuscode 404
                return NotFound($"provided id {id} is not present");

            //statuscode 
            return Ok(obj);



     
        }





        [HttpGet("{name:alpha}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]
        public ActionResult<Student> GetStudentByName(string name)
        {
            if (string.IsNullOrEmpty(name))
            {
                return BadRequest();
            }
            var obj=ClassRepository.Students.Where(n=>n.name==name).FirstOrDefault();
            if (obj == null)
            {
                return NotFound();
            }

            return Ok(obj);

        }










        [HttpDelete("{id}")]
        public bool DeleteStudentById(int id)
        {
            var obj=ClassRepository.Students.Where(n=>n.id==id).FirstOrDefault();

            ClassRepository.Students.Remove(obj);

            return true;
        }








        [HttpPost]
        public ActionResult<StudentDTO>Create([FromBody]StudentDTO model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            
            int  newId = ClassRepository.Students.LastOrDefault().id + 1;
            Student student = new Student
            {
                id = newId,
                name = model.name,
                email = model.email,
                phone=model.phone

            };
            ClassRepository.Students.Add(student);
            model.id = student.id;


            return (model);
        }

      
        


        
       
          


        
    }
}
