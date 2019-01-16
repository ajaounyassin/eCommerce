using System;
using System.Threading.Tasks;
using eCommerce.Services;
using Microsoft.AspNetCore.Mvc;
using Model.Model;

namespace eCommerce.Controllers
{
    public class ShoppingCartController
    {
        private readonly IShoppingCartService _shoppingCartService;

        public ShoppingCartController(IShoppingCartService shoppingCartService)
        {
            _shoppingCartService = shoppingCartService;
        }

        // POST: /Basket/AddToBasket
        [HttpPost]
        public async Task<IActionResult> Add(Article article, ShoppingCart shoppingCart, int quantity)
        {
             //await _shoppingCartService.AddArticle(shoppingCart, article, quantity);




            //if (productDetails?.Id == null)
            //{
            //    return RedirectToAction("Index", "Catalog");
            //}
            //var basketViewModel = await GetBasketViewModelAsync();

            //await _basketService.AddItemToBasket(basketViewModel.Id, productDetails.Id, productDetails.Price, 1);

            //return RedirectToAction("Index");
        }
    }
}
