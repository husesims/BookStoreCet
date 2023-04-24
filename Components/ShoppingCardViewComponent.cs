using BookStoreCet.Data;
using BookStoreCet.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace BookStoreCet.Components
{
    public class ShopingCardViewComponent : ViewComponent
    {
        

        public ShopingCardViewComponent()
        {
            
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            ShopingCard shopingCard;
            var cardStr = Request.HttpContext.Session.GetString("shoppingCard");
            if (cardStr.IsNullOrEmpty())
            {
                shopingCard = new();
            }
            else
            {
                shopingCard = JsonSerializer.Deserialize<ShopingCard>(cardStr);
            }
            return View(shopingCard);

        }
    }
}
