using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NorthwindSystem.BLL.Interface;
using NorthwindSystem.Data.Models;
using NorthwindSystem.Models;

namespace NorthwindSystem.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductService _productService;
        private readonly ICategoryService _categoryService;

        public ProductController(IProductService productService, ICategoryService categoryService)
        {
            _productService = productService;
            _categoryService = categoryService;
        }

        public async Task<IActionResult> Index()
        {
            var allProducts = await _productService.GetAll();

            return View(allProducts);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            ViewBag.Method = "Add";
            var model = await BuildAddUpdateProductModelAsync(null);
            return View("CreateUpdateView", model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Add"); ;
            }

            if (product != null)
            {
                await _productService.Add(product);
            }

            return RedirectToAction("Index");
        }

        [HttpGet]
        public async Task<IActionResult> Update(int productId)
        {
            ViewBag.Method = "Update";
            var model = await BuildAddUpdateProductModelAsync(productId);
            return View("CreateUpdateView", model);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Product product)
        {
            if (!ModelState.IsValid)
            {
                return RedirectToAction("Update", product.Id);
            }

            await _productService.Update(product);
            return RedirectToAction("Index");
        }

        private async Task<CreateUpdateProductViewModel> BuildAddUpdateProductModelAsync(int? productId)
        {
            return new CreateUpdateProductViewModel()
            {
                Categories = await _categoryService.GetAll(),
                Suppliers = new List<Supplier>(), // await _supplierService.GetAll(),
                Product = productId.HasValue ? await _productService.GetById(productId.Value) : null
            };
        }
    }
}