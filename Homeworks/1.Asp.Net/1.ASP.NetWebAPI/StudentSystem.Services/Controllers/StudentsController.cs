namespace StudentSystem.Services.Controllers
{    
    using System;
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class StudentsController : ApiController
    {
        private IStudentSystemData data;

        public StudentsController()
            : this(new StudentsSystemData())
        {
        }

        public StudentsController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var student = this.data
                 .Students
                 .All()
                 .Select(StudentModel.FromStudent);

            return Ok(student);
        }

        [HttpGet]        
        public IHttpActionResult Get(int id)
        {
            var student = this.data
                .Students
                .All()
                .Where(s => s.StudentId == id)
                .Select(StudentModel.FromStudent)
                .FirstOrDefault();

            if (student == null)
            {
                return BadRequest("Student does not exist - invalid id");
            }

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
                FirstName = student.FirstName,
                LastName = student.LastName
            };

            this.data.Students.Add(newStudent);
            this.data.SaveChanges();

            student.StudentId = newStudent.StudentId;
            return Ok(student);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, Student student)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingStudent = this.data.Students.All().FirstOrDefault(a => a.StudentId == id);
            if (existingStudent == null)
            {
                return BadRequest("This student does not exists!");
            }

            existingStudent.FirstName = student.FirstName;
            existingStudent.LastName = student.LastName;
            this.data.SaveChanges();

            student.StudentId = id;
            return Ok(student);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingStudent = this.data.Students.All().FirstOrDefault(a => a.StudentId == id);
            if (existingStudent == null)
            {
                return BadRequest("This student does not exists!");
            }

            this.data.Students.Delete(existingStudent);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddCourse(int id, string courseId)
        {
            var student = this.data.Students.All().FirstOrDefault(a => a.StudentId == id);
            if (student == null)
            {
                return BadRequest("This student does not exists - invalid id!");
            }

            var coursesIdAsGuid = new Guid(courseId);
            var course = this.data.Courses.All().FirstOrDefault(b => b.Id == coursesIdAsGuid);
            if (course == null)
            {
                return BadRequest("This course does not exists - invalid id!");
            }

            student.Courses.Add(course);            
            this.data.SaveChanges();

            return Ok();
        }
    }
}