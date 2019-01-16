using System.Collections.Generic;
using Model.Model;

namespace eCommerce.Services
{
    public interface IShoppingCartService
    {
        ShoppingCart AddArticle(ShoppingCart sc, Article article, int quantity);
        void DeleteArticle(Article article);
        void DeleteShoppingCart(ShoppingCart sc);
        List<Article> GetAllArticles(ShoppingCart sc);
    }
}

