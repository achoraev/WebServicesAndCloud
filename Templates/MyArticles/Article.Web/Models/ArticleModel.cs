namespace Article.Web.Models
{   
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Linq.Expressions;
    using Article.Models;

    public class ArticleModel
    {
        public static Expression<Func<Article, ArticleModel>> FromArticle
        {
            get
            {
                return s => new ArticleModel
                {
                    Id = s.Id,
                    Name = s.Title
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