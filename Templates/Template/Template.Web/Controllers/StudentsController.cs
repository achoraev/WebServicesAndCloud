namespace Template.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;
    using Template.Data;
    using StudentSystem.Services.Models;
    using Template.Models;

    public class StudentsController : ApiController
    {
        // base controller
        private IStudentData data;

        public StudentsController()
            : this(new StudentData())
        {
        }

        // base controller
        public StudentsController(IStudentData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var student = this.data
                 .Students
                 .All()
                 .Select(StudentModel.FromStudent);

            return Ok(student);
        }

        [HttpPost]
        public IHttpActionResult Create(Student student)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newStudent = new Student
            {
               Name = student.Name
            };

            this.data.Students.Add(newStudent);
            this.data.SaveChanges();

            student.Id = newStudent.Id;
            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, Student student)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingStudent = this.data.Students.All().FirstOrDefault(a => a.Id == id);
            if (existingStudent == null)
            {
                return BadRequest("This student does not exists!");
            }

            existingStudent.Name = student.Name;
            
            this.data.SaveChanges();

            student.Id = id;
            return Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingStudent = this.data.Students.All().FirstOrDefault(a => a.Id == id);
            if (existingStudent == null)
            {
                return BadRequest("This student does not exists!");
            }

            this.data.Students.Delete(existingStudent);
            this.data.SaveChanges();

            return Ok();
        }
    }
}