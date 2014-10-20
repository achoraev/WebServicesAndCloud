namespace StudentSystem.Services.Models
{   
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using Template.Models;

    public class StudentModel
    {
        public static Expression<Func<Student, StudentModel>> FromStudent
        {
            get
            {
                return s => new StudentModel
                {
                    Id = s.Id,
                    Name = s.Name
                };
            }
        }

        public int Id { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(20)]
        public string Name { get; set; }
    }    
}