using System.Collections.Generic;
using eCommerce.Services.Interfaces;
using Model.Model;
using Repositories.Interfaces;
using Repositories.Repositories;

namespace eCommerce.Services
{
    public class ArticleService : IArticleService
    {
        private readonly ArticleRepository _articleRepository;

        public ArticleService(IArticleRepository repo)
        {
            _articleRepository = (ArticleRepository)repo;
        }

        public Article Create(Article article)
        {
            return _articleRepository.Add(article);
        }

        public bool Delete(Article article)
        {
            return _articleRepository.Delete(article.Id);
        }

        public List<Article> FindbyName(string name)
        {
            return _articleRepository.GetArticles(name);
        }

        public List<Article> GetAll()
        {
            return _articleRepository.GetArticles();
        }

        public Article Update(Article article)
        {
            return _articleRepository.Update(article);
        }
    }
}