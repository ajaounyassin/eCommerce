using System;
using System.Collections.Generic;
using Model;
using Model.Model;
using Repositories.Interfaces;

namespace Repositories.Repositories
{
    public class ShoppingCartRepository : IShoppingCartRepository
    {
        private readonly ECommerceDbContext _context;

        public ShoppingCartRepository(ECommerceDbContext context)
        {
            this._context = context;
        }

        //Create
        public ShoppingCart AddArticle(ShoppingCart shoppingCart, Article article)
        {
            _context.ShoppingCarts.Add(shoppingCart);
            _context.SaveChanges();
            return shoppingCart;
        }

        //Read
        public List<Article> ListArticles(ShoppingCart shoppingCart)
        {
            return null;

        }

        //Update
        public ShoppingCart Update(Guid basketId, ShoppingCart ShoppingCart)
        {
            return null;
        }

        public int GetQuantity(ShoppingCart shoppingCart)
        {
            return 0;
        }

        //Delete
        public bool DeleteArticle(Guid shoppingCartId, Article article)
        {
            return false;
        }

    }
}
