using Model.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repositories.Interfaces
{
    public interface IBasketRepository
    {
        //Create
        Basket AddArticle(Guid basketId, Article article);
        
        //Read
        List<Article> ListArticles(Guid basketId);

        //Update
        Basket Update(Guid basketId, Basket basket);
        int GetQuantity(Guid basketId);

        //Delete
        bool DeleteArticle(Guid basketId, Article article);
    }
}
