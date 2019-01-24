using System.Collections.Generic;
using eCommerce.Services.Interfaces;
using Model.Model;
using Repositories.Interfaces;
using Repositories.Repositories;

namespace eCommerce.Services
{
    public class ArticleService : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUserRepository _userRepository;

        public ArticleService(IArticleRepository arRepo, IUserRepository usRepo)
        {
            _articleRepository = arRepo;
            _userRepository = usRepo;
        }

        public Article Create(Article article,string emailVendor)
        {
            if (emailVendor == "" || emailVendor is null)
            {
                return null;
            }
            else
            {
                var user = _userRepository.GetOne(emailVendor);
                article.Vendor = user;
                return _articleRepository.Add(article);
            }
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