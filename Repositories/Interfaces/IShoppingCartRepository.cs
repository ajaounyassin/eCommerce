using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IShoppingCartRepository
    {
        //Create
        ShoppingCart AddArticle(ShoppingCart shoppingCartId, Article article);
        
        //Read
        List<Article> ListArticles(ShoppingCart shoppingCart);


        //Update
        ShoppingCart Update(Guid shoppingCartId, ShoppingCart shoppingCart);

        int GetQuantity(ShoppingCart shoppingCart);

        //Delete
        bool DeleteArticle(Guid shoppingCartId, Article article);
    }
}
