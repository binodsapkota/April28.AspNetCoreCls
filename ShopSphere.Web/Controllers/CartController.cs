using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using ShopSphere.Web.Data;
using ShopSphere.Web.ViewModels;

namespace ShopSphere.Web.Controllers
{
    public class CartController : Controller
    {

        //we have to store cart in session 
        //lets create a prop cart


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

        private void SetCartItems(List<CartItemViewModel> items)
        {
            var jsonString = JsonConvert.SerializeObject(items);
            //set data to session
            HttpContext.Session.SetString("Cart", jsonString);
        }

        // This controller handles the shopping cart functionality
        private readonly AppDbContext _context;
        public CartController(AppDbContext appDbContext)
        {
            _context = appDbContext;
        }
        public IActionResult Index()
        {
            List<CartItemViewModel> items = new List<CartItemViewModel>();
            // Here you would typically retrieve the cart items from a service or database

            return View(GetCartItems());
        }

        [HttpPost]
        public async Task<IActionResult> AddToCart(int id)
        {
            // Here you would typically add the item to the cart in a service or database
            // For demonstration purposes, we will just return a success message
            var product = await _context.Products.FindAsync(id);
            if (product == null)
            {
                return NotFound();
            }

            var cartVm = new CartItemViewModel
            {
                ProductId = product.Id,
                ProductName = product.Name,
                ImageUrl = product.ImageUrl,
                Price = product.Price,
                Quantity = 1 // Default quantity is set to 1
            };
            var items = GetCartItems();

            items.Add(cartVm);

            SetCartItems(items);
            TempData["SuccessMessage"] = $"{product.Name} has been added to your cart.";
            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Remove(int productId)
        {
            var cart = GetCartItems();
            cart.RemoveAll(x => x.ProductId == productId);

            SetCartItems(cart);
            TempData["message"] = "Product Remove From Cart";
            return RedirectToAction("Index");
        }

        [HttpPost]
        public IActionResult UpdateQuantity(int productId,int quantity)
        {
            var cart = GetCartItems();

            var product = cart.FirstOrDefault(x => x.ProductId == productId);
            product.Quantity = quantity;

            SetCartItems(cart);
            TempData["message"] = "Product Updated";
            return RedirectToAction("index");


        }
    }
}
