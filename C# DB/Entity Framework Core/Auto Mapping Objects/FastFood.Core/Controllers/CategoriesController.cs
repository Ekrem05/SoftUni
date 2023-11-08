namespace FastFood.Core.Controllers
{
    using System;
    using AutoMapper;
    using Data;
    using FastFood.Models;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Categories;

    public class CategoriesController : Controller
    {
        private readonly FastFoodContext _context;
        private readonly IMapper _mapper;

        public CategoriesController(FastFoodContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(CreateCategoryInputModel model)
        {
            Category category = new Category()
            {
                Name = model.CategoryName
            }; 
            _context.AddRange(category);
            _context.SaveChanges();
            return View();
        }

        public IActionResult All()
        {
            return View(_context.Categories);
        }
    }
}
