using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ShopSphere.Web.Data;
using ShopSphere.Web.Models;
using ShopSphere.Web.ViewModels;

namespace ShopSphere.Web.Controllers.Admin
{

    [Authorize]
    public class ProductsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        private readonly AppDbContext _context;

        public ProductsController(AppDbContext context, IWebHostEnvironment webHostEnvironment)
        {
            _context = context;
            _webHostEnvironment = webHostEnvironment;
        }

        // GET: Admin/Products
        public async Task<IActionResult> Index()
        {
            var appDbContext = _context.Products.Include(p => p.Category);
            return View(await appDbContext.ToListAsync());
        }

        // GET: Admin/Products/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // GET: Admin/Products/Create
        public IActionResult Create()
        {
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name");
            return View();
        }

        // POST: Admin/Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,Price,ImageUrl,ImageFile,CategoryId")] ProductViewModel productModel)
        {
            if (ModelState.IsValid)
            {
                //product image part
                string imagePath = "";
                if (productModel.ImageFile != null)
                {
                    imagePath =await SaveImage( productModel.ImageFile);


                    var model = new ProductModel
                    {
                        Name = productModel.Name,
                        Description = productModel.Description,
                        Price = productModel.Price,
                        ImageUrl = imagePath,
                        CategoryId = productModel.CategoryId
                    };

                    _context.Add(model);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", productModel.CategoryId);
            return View(productModel);
        }

        private async Task<string> SaveImage(IFormFile? file)
        {
            //we have to save file
            //we have update image url(relative) /images/file.ext
            //for filename we use guid
            string fileName = Guid.NewGuid() + Path.GetExtension(file.FileName);//eg .png, .jpg
                                                                                                  //store this file
                                                                                                  //first check directory
            string uploadDir = Path.Combine(_webHostEnvironment.WebRootPath, "images", "products");
            if (!Directory.Exists(uploadDir))
            {
                Directory.CreateDirectory(uploadDir);
            }
            //save file to uploadDir
            string filePath = Path.Combine(uploadDir, fileName);

            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                await file.CopyToAsync(fileStream);
            }
            //update imagePath
            return "/images/products/" + fileName; //relative path
        }

        // GET: Admin/Products/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Products.FindAsync(id);
            if (productModel == null)
            {
                return NotFound();
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", productModel.CategoryId);
            // Map ProductModel to ProductViewModel
            var model = new ProductViewModel
            {
                Description = productModel.Description,
                Price = productModel.Price,
                Name = productModel.Name,
                ImageUrl = productModel.ImageUrl,
                CategoryId = productModel.CategoryId,
                Id = productModel.Id

            };
            return View(model);
        }

        // POST: Admin/Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,Price,ImageUrl,ImageFile,CategoryId")] ProductViewModel productModel)
        {
            if (id != productModel.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    var model =await _context.Products.FindAsync(productModel.Id); 
                    if (!string.IsNullOrEmpty(productModel.ImageUrl))
                    {
                        string filePath = _webHostEnvironment.WebRootPath + productModel.ImageUrl;
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);//
                        }
                        
                    }
                    if(productModel.ImageFile!=null)
                    {
                        string imagePath = await SaveImage(productModel.ImageFile);
                        model.ImageUrl = imagePath;
                    }
                    model.Name = productModel.Name;
                    model.Price = productModel.Price;
                    model.Description = productModel.Description;
                    

                    _context.Update(model);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductModelExists(productModel.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["CategoryId"] = new SelectList(_context.Categories, "Id", "Name", productModel.CategoryId);
            return View(productModel);
        }

        // GET: Admin/Products/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productModel = await _context.Products
                .Include(p => p.Category)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (productModel == null)
            {
                return NotFound();
            }

            return View(productModel);
        }

        // POST: Admin/Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productModel = await _context.Products.FindAsync(id);
            if (productModel != null)
            {
                _context.Products.Remove(productModel);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductModelExists(int id)
        {
            return _context.Products.Any(e => e.Id == id);
        }
    }
}
