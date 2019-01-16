using System;
using System.Collections.Generic;
using Model.Model;
using Repositories.Interfaces;

namespace eCommerce.Services
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IShoppingCartRepository _shoppingCartRepository;

        public ShoppingCart AddArticle(ShoppingCart sc, Article article, int quantity)
        {
            throw new NotImplementedException();
        }

        public void DeleteArticle(Article article)
        {
            throw new NotImplementedException();
        }

        public void DeleteShoppingCart(ShoppingCart sc)
        {
            throw new NotImplementedException();
        }

        public List<Article> GetAllArticles(ShoppingCart sc)
        {
            throw new NotImplementedException();
        }

        public bool Delete(ShoppingCart shoppingCart)
        {
            return _shoppingCartRepository.Delete(shoppingCart);
        }
    }
}
