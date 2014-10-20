namespace Article.Web.Controllers
{
    
    using System.Linq;
    using System.Web.Http;
    
    using Article.Web.Models;   
    using Article.Models;
    using Article.Data;
    
    public class ArticleController : ApiController
    {
        // base controller
        private IArticleData data;

        public ArticleController()
            : this(new ArticleData())
        {
        }

        // base controller
        public ArticleController(IArticleData data)
        {
            this.data = data;
        }

        [HttpGet]
        public IHttpActionResult GetAll()
        {
            var article = this.data
                 .Articles
                 .All()
                 .Select(ArticleModel.FromArticle);

            return Ok(article);
        }

        [HttpPost]
        public IHttpActionResult Create(Article article)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var newArticle = new Article
            {
               Title = article.Title
            };

            this.data.Articles.Add(newArticle);
            this.data.SaveChanges();

            article.ID = newArticle.ID;
            return Ok(article);
        }

        [HttpPut]
        public IHttpActionResult Update(int id, Article article)
        {
            if (!this.ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var existingArticle = this.data.Articles.All().FirstOrDefault(a => a.Id == id);
            if (existingArticle == null)
            {
                return BadRequest("This article does not exists!");
            }

            existingArticle.Title = article.Title;
            
            this.data.SaveChanges();

            article.ID = id;
            return Ok(article);
        }

        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            var existingArticle = this.data.Articles.All().FirstOrDefault(a => a.ID == id);
            if (existingArticle == null)
            {
                return BadRequest("This article does not exists!");
            }

            this.data.Articles.Delete(existingArticle);
            this.data.SaveChanges();

            return Ok();
        }
    }
}