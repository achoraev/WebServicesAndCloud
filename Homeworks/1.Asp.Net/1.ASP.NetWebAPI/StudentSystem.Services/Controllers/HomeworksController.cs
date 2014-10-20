namespace StudentSystem.Services.Controllers
{    
    using System;
    using System.Linq;
    using System.Web.Http;

    using StudentSystem.Data;
    using StudentSystem.Models;
    using StudentSystem.Services.Models;

    public class HomeworksController : ApiController
    {
        private IStudentSystemData data;

        public HomeworksController()
            : this(new StudentsSystemData())
        {
        }

        public HomeworksController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var homework = this.data
                 .Homeworks
                 .All()
                 .Select(HomeworkModel.FromHomework);

            return Ok(homework);
        }

        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            var homework = this.data
                .Homeworks
                .All()
                .Where(h => h.Id == id)
                .Select(HomeworkModel.FromHomework)
                .FirstOrDefault();

            if (homework == null)
            {
                return BadRequest("Homework does not exist - invalid id");
            }

            return Ok(homework);
        }

        [HttpPost]
        public IHttpActionResult Create(Homework homework)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            homework.TimeSent = DateTime.Now;

            this.data.Homeworks.Add(homework);
            this.data.SaveChanges();

            return Ok(homework);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, Homework homework)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingHomework = this.data.Homeworks.All().FirstOrDefault(h => h.Id == id);
            if (existingHomework == null)
            {
                return BadRequest("This homework does not exists!");
            }

            existingHomework.CourseId = homework.CourseId;
            existingHomework.FileUrl = homework.FileUrl;
            existingHomework.TimeSent = DateTime.Now;
            existingHomework.StudentIdentification = homework.StudentIdentification;

            this.data.SaveChanges();

            homework.Id = id;

            return Ok(homework);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingHomework = this.data.Homeworks.All().FirstOrDefault(h => h.Id == id);
            if (existingHomework == null)
            {
                return BadRequest("This homework does not exists!");
            }

            this.data.Homeworks.Delete(existingHomework);
            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddCourse(int homeworkId, string courseId)
        {
            var homework = this.data.Homeworks.All().FirstOrDefault(h => h.Id == homeworkId);
            if (homework == null)
            {
                return BadRequest("This homework does not exists - invalid id!");
            }

            var coursesIdAsGuid = new Guid(courseId);
            var course = this.data.Courses.All().FirstOrDefault(b => b.Id == coursesIdAsGuid);
            if (course == null)
            {
                return BadRequest("This course does not exists - invalid id!");
            }

            homework.CourseId = course.Id;

            this.data.SaveChanges();

            return Ok();
        }

        [HttpPost]
        public IHttpActionResult AddStudent(int homeworkId, int studentId)
        {
            var homework = this.data.Homeworks.All().FirstOrDefault(h => h.Id == homeworkId);
            if (homework == null)
            {
                return BadRequest("This homework does not exists - invalid id!");
            }

            var student = this.data.Students.All().FirstOrDefault(s => s.StudentId == studentId);
            if (student == null)
            {
                return BadRequest("This student does not exists - invalid id!");
            }

            homework.StudentIdentification = student.StudentId;

            this.data.SaveChanges();

            return Ok();
        }
    }
}