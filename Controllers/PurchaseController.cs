using BookStoreCet.Data;
using BookStoreCet.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;
using Microsoft.IdentityModel.Tokens;
using System.Text.Json;

namespace BookStoreCet.Controllers
{
    [Authorize]
    public class PurchaseController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public PurchaseController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public IActionResult Card(int id)
        {

            //if(!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
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

            shopingCard.Add(new ShopingList { BookId = id, Count = 1 });



            Request.HttpContext.Session.SetString("shoppingCard", JsonSerializer.Serialize(shopingCard));
            return RedirectToAction("Index", "Home");


        }
        public IActionResult Index(int id)
        {

            //if(!User.Identity.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            var book=dbContext.Books.Find(id);
            if (book == null)
            {
                return NotFound();
            }
            PurchaseModel model = new PurchaseModel();
            model.PurchasedBook= book;
            model.PurchasedBookId= book.Id;
            return View(model);
        }
        [HttpPost]
        public IActionResult Index(PurchaseModel model) { 
            if(ModelState.IsValid)
            {
                //User.Identity.Name
                var cetUser = dbContext.Users.FirstOrDefault(x => x.UserName == User.Identity.Name);
                if (cetUser == null)
                {
                    return BadRequest("No such a user");
                }

                var book = dbContext.Books.Find(model.PurchasedBookId);
                Order order = new Order();
                order.NameSurname = model.NameSurname;
                order.Address = model.Address;
                order.OrderDate = DateTime.Now;
                order.CardInfo = model.CardInfo;
                order.CetUserId = cetUser.Id;
                //order.CetUser = cetUser;


                OrderDetail orderDetail=new OrderDetail();
                orderDetail.Order = order;
                orderDetail.BookId =book.Id;
                orderDetail.Count = 1;
                orderDetail.Price =book.Price;
                order.Orders.Add(orderDetail);
                dbContext.Orders.Add(order);
                dbContext.SaveChanges();
                return RedirectToAction("PurchaseSuccess");
            }
            return View(model);
        }

        public IActionResult PurchaseSuccess()
        {
            return View();
        }
    }
}
