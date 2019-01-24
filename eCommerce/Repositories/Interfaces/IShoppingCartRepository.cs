using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        ShoppingCart CreateCart(ShoppingCart shoppingCart, User user);
        ShoppingCart AddArticle(ShoppingCart shoppingCart, Article article);
        
        ICollection<Article> ListArticles(ShoppingCart shoppingCart);
        bool Find(ShoppingCart shoppingCart);
        
        ShoppingCart Update(Guid shoppingCartId, ShoppingCart shoppingCart);

        int GetQuantity(ShoppingCart shoppingCart);
        
        bool DeleteArticle(ShoppingCart shoppingCart, Article article);
        bool Delete(ShoppingCart shoppingCart);

    }
}
