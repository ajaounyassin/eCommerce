using System.Collections.Generic;
using eCommerce.Services;
using eCommerce.Services.Interfaces;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace eCommerce.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("eCommercePolicy")]

    public class ArticleController : ControllerBase
    {
        private IArticleService _articleService;

        public ArticleController(IArticleService articleService)
        {
            _articleService = (ArticleService)articleService;
        }

        [HttpPost("create")]
        public IActionResult Add(Article article, string emailVendor)
        {
            var ar = _articleService.Create(article,emailVendor);
            return Ok(ar);
        }

        [HttpGet("getall")]
        public List<Article> GetArticles()
        {
            var articles = _articleService.GetAll();
            return articles;
        }

        [HttpGet("findBy")]
        public List<Article> GetArticles(string name)
        {
            var articles = _articleService.FindbyName(name);
            return articles;
        }

        [HttpDelete("delete")]
        public IActionResult Delete(Article article)
        {
            _articleService.Delete(article);
            return NoContent();

        }
    }
}
