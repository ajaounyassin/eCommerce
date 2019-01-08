using System;
using System.Collections.Generic;
using System.Linq;
using Model;
using Model.Model;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class ArticleRepository : IArticleRepository
    {
        private readonly ECommerceDbContext _context;
        public ArticleRepository(ECommerceDbContext context)
        {
            _context = context;
        }

        //Create 
        public Article Add(Article article)
        {
            _context.Articles.Add(article);
            _context.SaveChanges();
            return article;
        }

        //Read
        public List<Article> GetArticles(string recherche)
        {
            return _context.Articles.Where(x => x.Wording.Contains(recherche)).ToList();
        }
        public List<Article> GetArticles()
        {
            return _context.Articles.ToList();
        }

        public int GetQuantity(Guid article)
        {
            return 
        }

        //Update
        public Article Update(Guid articleId, Article article)
        {
            return null;
        }
        public Article ActiveArticle(Guid articleId, bool active)
        {
            return null;
        }
        public Article TopArticle(Guid articleId, bool top)
        {
            return null;
        }
        public Article UpdateQuantityArticle(Guid articleId, int quantity)
        {
            return null;
        }
        public Article UpdatePrice(Guid articleId, decimal priceET)
        {
            return null;
        }
        public Article UpdatePicture(Guid articleId, string picture)
        {
            return null;
        }

        //Delete
        public bool Delete(Guid id)
        {
            if (this._context.Addresses.Find(id) != null)
            {
                _context.Addresses.Remove(_context.Addresses.Find(id));
                _context.SaveChanges();
                return true;
            }
            return false;
        } 
    }
}
