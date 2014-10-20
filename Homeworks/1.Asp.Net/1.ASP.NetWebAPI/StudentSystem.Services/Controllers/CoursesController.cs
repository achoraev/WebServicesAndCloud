namespace StudentSystem.Services.Controllers
{
    using StudentSystem.Data;
    using StudentSystem.Models;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Net;
    using System.Net.Http;
    using System.Web.Http;

    public class CoursesController : ApiController
    {
        private IStudentSystemData data;

        public CoursesController()
            : this(new StudentsSystemData())
        {
        }

        public CoursesController(IStudentSystemData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult Get()
        {
            var courses = this.data
                 .Courses
                 .All()
                 .Select(c => c.Name + "; " + c.Description);                

            return Ok(courses);
        }

        [HttpGet]
        public IHttpActionResult Get(string id)
        {
            var coursesIdAsGuid = new Guid(id);

            var courses = this.data
                .Courses
                .All()
                .Where(c => c.Id == coursesIdAsGuid);                

            if (courses == null)
            {
                return BadRequest("Course does not exist - invalid id");
            }

            return Ok(courses);
        }

        [HttpPost]
        public IHttpActionResult Create(Course course)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newCourse = new Course
            {
                Name = course.Name,
                Description = course.Description               
            };

            this.data.Courses.Add(newCourse);
            this.data.SaveChanges();

            course.Id = newCourse.Id;
            course.Name = newCourse.Name;
            course.Description = newCourse.Description;            
            return Ok(newCourse);
        }

        [HttpPut]
        public IHttpActionResult Update(string id, Course course)
        {
            var coursesIdAsGuid = new Guid(id);

            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingCourse = this.data.Courses.All().FirstOrDefault(a => a.Id == coursesIdAsGuid);
            if (existingCourse == null)
            {
                return BadRequest("This course does not exists!");
            }

            existingCourse.Name = course.Name;
            existingCourse.Description = course.Description;
            existingCourse.Students = course.Students;
            existingCourse.Homeworks = course.Homeworks;

            this.data.SaveChanges();

            course.Id = coursesIdAsGuid;
            return Ok(course);
        }

        [HttpDelete]
        public IHttpActionResult Delete(string id)
        {
            var coursesIdAsGuid = new Guid(id);

            var existingCourse = this.data.Courses.All().FirstOrDefault(a => a.Id == coursesIdAsGuid);
            if (existingCourse == null)
            {
                return BadRequest("This course does not exists!");
            }

            this.data.Courses.Delete(existingCourse);
            this.data.SaveChanges();

            return Ok();
        }
    }
}