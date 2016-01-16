using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ElectronicsStore.Domain.Abstract;
using ElectronicsStore.Domain.Entities;
using ElectronicsStore.WebUI.Models;

namespace ElectronicsStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;

        // shows a maximum of 4 items per page
        public int PageSize = 4;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, int page = 1)
        {
            ProductsListViewModel model = new ProductsListViewModel
            {
                Products = repository.Products.OrderBy(p => p.ProductID)
                                               .Where(p => category == null || p.Category == category)
                                               .Skip((page - 1) * PageSize)
                                               .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? repository.Products.Count() : repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };
            return View(model);
        }
    }
}