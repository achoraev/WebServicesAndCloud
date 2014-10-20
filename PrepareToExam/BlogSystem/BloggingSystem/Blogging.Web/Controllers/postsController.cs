namespace Blogging.Web.Controllers
{
    using System.Linq;
    using System.Web.Http;

    using Blogging.Data;
    using Blogging.Web.Models;
    using Blogging.Models;

    public class postsController : BaseApiController
    {               
        public postsController(IBlogData data)
            : base(data)
        {
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var post = this.data
                 .Posts
                 .All();
                 //.Select(StudentModel.FromStudent);

            return Ok(post);
        }

        //[HttpPost]
        //public IHttpActionResult Create(Student student)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var newStudent = new Student
        //    {
        //       Name = student.Name
        //    };

        //    this.data.Students.Add(newStudent);
        //    this.data.SaveChanges();

        //    student.Id = newStudent.Id;
        //    return Ok(student);
        //}

        //[HttpPut]
        //public IHttpActionResult Update(int id, Student student)
        //{
        //    if (!this.ModelState.IsValid)
        //    {
        //        return BadRequest(ModelState);
        //    }

        //    var existingStudent = this.data.Students.All().FirstOrDefault(a => a.Id == id);
        //    if (existingStudent == null)
        //    {
        //        return BadRequest("This student does not exists!");
        //    }

        //    existingStudent.Name = student.Name;
            
        //    this.data.SaveChanges();

        //    student.Id = id;
        //    return Ok(student);
        //}

        //[HttpDelete]
        //public IHttpActionResult Delete(int id)
        //{
        //    var existingStudent = this.data.Students.All().FirstOrDefault(a => a.Id == id);
        //    if (existingStudent == null)
        //    {
        //        return BadRequest("This student does not exists!");
        //    }

        //    this.data.Students.Delete(existingStudent);
        //    this.data.SaveChanges();

        //    return Ok();
        //}
    }
}