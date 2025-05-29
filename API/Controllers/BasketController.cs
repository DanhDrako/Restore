using API.Data;
using API.DTOs;
using API.Entities;
using API.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class BasketController(StoreContext context) : BaseApiController
    {
        [AllowAnonymous]
        [HttpGet]
        public async Task<ActionResult<BasketDto>> GetBasket()
        {
            var basket = await RetrieveBasket();

            if (basket == null) return NoContent();

            return basket.ToDto();
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<BasketDto>> AddItemToBasket(int productId, int quantity)
        {
            // get basket
            var basket = await RetrieveBasket();
            // create basket if it doesn't exist
            basket ??= CreateBasket();

            // get product
            var product = await context.Products.FindAsync(productId);
            if (product == null) return BadRequest("Problem adding item to basket");

            // add item to basket
            basket.AddItem(product, quantity);

            // save changes
            var result = await context.SaveChangesAsync() > 0;
            if (result) return CreatedAtAction(nameof(GetBasket), basket.ToDto());

            return BadRequest("Problem updating basket");
        }

        [AllowAnonymous]
        [HttpDelete]
        public async Task<ActionResult> RemoveBasketItem(int productId, int quantity)
        {
            // get basket
            var basket = await RetrieveBasket();

            // remove the item or reduce its quantity
            if (basket == null) return BadRequest("Unable to retrieve basket");

            // remove item from basket
            basket.RemoveItem(productId, quantity);

            // save changes
            var result = await context.SaveChangesAsync() > 0;
            if (result) return Ok();

            return BadRequest("Problem updating basket");
        }

        private async Task<Basket?> RetrieveBasket()
        {
            return await context.Baskets
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .FirstOrDefaultAsync(x => x.BasketId == Request.Cookies["basketId"]);
        }

        private Basket CreateBasket()
        {
            // generate a new basket id
            var basketId = Guid.NewGuid().ToString();

            // set cookie
            var cookieOptions = new CookieOptions
            {
                IsEssential = true,
                Expires = DateTime.UtcNow.AddDays(30),
            };
            Response.Cookies.Append("basketId", basketId, cookieOptions);

            // create basket
            var basket = new Basket
            {
                BasketId = basketId
            };
            // add basket to context
            context.Baskets.Add(basket);

            return basket;
        }
    }
}
