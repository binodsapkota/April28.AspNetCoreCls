using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using ShopSphere.Web.Data;
using ShopSphere.Web.Models;
using ShopSphere.Web.ViewModels;

namespace ShopSphere.Web.Controllers
{
    public class CheckoutController : Controller
    {
        private readonly AppDbContext _context;
        public CheckoutController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }

        public IActionResult Index()
        {
            var cart = GetCartItems();
            if (cart.Count == 0)
            {
                return RedirectToAction("Index", "Cart");
            }
            // Here you would typically retrieve the cart items from a service or database
            CheckoutViewModel model = new CheckoutViewModel
            {
                CartItems = cart,
                TotalAmount = cart.Sum(item => item.Price * item.Quantity)
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Index(CheckoutViewModel vm)
        {
            var cart = GetCartItems();
            if (!ModelState.IsValid)
            {
                vm.CartItems = cart;
                return View(vm);
            }

            var order = new OrderModel()
            {
                UserId = "",
                Fullname = vm.Fullname,
                Address = vm.Address,
                City = vm.City,
                ZipCode = vm.ZipCode,
                PhoneNumber = vm.PhoneNumber,
                OrderDate = DateTime.UtcNow

            };





            order.OrderItems = cart
                .Select(x => new OrderItemModel()
                {
                    OrderId = order.Id,
                    ProductId = x.ProductId,
                    Price = x.Price,
                    Quantity = x.Quantity

                }).ToList();


            _context.Orders.Add(order);
            await _context.SaveChangesAsync();

            //remove cart items from session
            HttpContext.Session.Remove("Cart");


            return RedirectToAction("Complete");
        }
        [HttpGet]
        public IActionResult Complete()
        {
            return View();
        }

        private List<CartItemViewModel> GetCartItems()
        {
            var jsonString = HttpContext.Session.GetString("Cart");
            if (jsonString is null)
            {
                return new List<CartItemViewModel>();
            }
            List<CartItemViewModel> cart = JsonConvert.DeserializeObject<List<CartItemViewModel>>(jsonString);
            return cart ?? new List<CartItemViewModel>();
        }


    }
}
