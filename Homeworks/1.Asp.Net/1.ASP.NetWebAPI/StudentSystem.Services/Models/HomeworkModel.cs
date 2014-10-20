namespace StudentSystem.Services.Models
{
    using StudentSystem.Models;
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq.Expressions;

    public class HomeworkModel
    {
        public static Expression<Func<Homework, HomeworkModel>> FromHomework
        {
            get
            {
                return s => new HomeworkModel
                {
                    Id = s.Id,
                    FileUrl = s.FileUrl,
                    TimeSent = s.TimeSent                   
                };
            }
        }

        public int Id { get; set; }

        public string FileUrl { get; set; }

        public DateTime TimeSent { get; set; }
    }
}