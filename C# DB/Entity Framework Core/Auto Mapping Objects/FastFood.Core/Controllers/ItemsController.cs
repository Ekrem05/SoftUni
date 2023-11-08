namespace FastFood.Core.Controllers
{
    using System;
    using System.Linq;
    using AutoMapper;
    using AutoMapper.QueryableExtensions;
    using Data;
    using Microsoft.AspNetCore.Mvc;
    using ViewModels.Items;

    public class ItemsController : Controller
    {
        private readonly FastFoodContext _context;
        private readonly IMapper _mapper;

        public ItemsController(FastFoodContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult Create()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        public IActionResult Create(CreateItemInputModel model)
        {
            throw new NotImplementedException();
        }

        public IActionResult All()
        {
            throw new NotImplementedException();
        }
    }
}
