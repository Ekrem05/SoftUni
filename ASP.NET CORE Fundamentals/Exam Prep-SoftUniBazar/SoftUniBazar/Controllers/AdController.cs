using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Build.Framework;
using Microsoft.EntityFrameworkCore;
using SoftUniBazar.Data;
using SoftUniBazar.Models;
using SoftUniBazar.Models.ViewModels;
using System.ComponentModel;
using System.Security.Claims;
using static SoftUniBazar.Constraints.ValidationValues;

namespace SoftUniBazar.Controllers
{
    [Authorize]
    public class AdController : Controller
    {
        private BazarDbContext dbContext {  get; set; }
        public AdController(BazarDbContext dbContext)
        {
                this.dbContext = dbContext;
        }

        [ActionName("All")]
        public async Task<IActionResult> Index()
        {
            var ads = await dbContext.Ads.AsNoTracking()
                .Select(a => new AdViewModel()
                {
                    Id = a.Id,
                    Name = a.Name,
                    CreatedOn = a.CreatedOn.ToString(DateFormat),
                    Category = a.Category.Name,
                    Description = a.Description,
                    Price = a.Price,
                    Owner = a.Owner.UserName
                })
                .ToListAsync();
            return View(ads);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            var model = new AdFormViewModel();
            model.Categories = GetCategories();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Add(AdFormViewModel input)
        {
            if (input == null)
            {
                BadRequest();
            }
            if (ModelState.IsValid)
            {
                dbContext.Ads.Add(new Ad()
                {
                    Name = input.Name,
                    Description = input.Description,
                    ImageUrl = input.ImageUrl,
                    Price = input.Price,
                    CategoryId = input.CategoryId,
                    CreatedOn = DateTime.Now,
                    OwnerId = GetUserId(),

                });
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("All");
        }

        [HttpPost]
        [ActionName("AddToCart")]
        public async Task<IActionResult> Cart(int id)
        {
            if (id==null)
            {
                BadRequest();
            }
            var item = await dbContext.Ads
                .Include(a=>a.AdBuyers)
                .FirstOrDefaultAsync(a => a.Id == id);
            if (item==null)
            {
                BadRequest();
            }
            if (item.AdBuyers.Any(ab=>ab.BuyerId==GetUserId()&&ab.AdId==id))
            {
                BadRequest();
            }
            else
            {
                item.AdBuyers.Add(new AdBuyer()
                {
                    BuyerId = GetUserId(),
                    AdId = id
                });
                await dbContext.SaveChangesAsync();

                return RedirectToAction(nameof(Cart));
            }
            return RedirectToAction("All");

        }
        [HttpGet]
        public async Task<IActionResult> Cart()
        {
            var items = await dbContext.AdBuyers
                .AsNoTracking()
                .Include(ab => ab.Ad)
                .Where(ab => ab.BuyerId == GetUserId())
                .Select(ab => new AdViewModel()
                {

                    Id = ab.Ad.Id,
                    Name = ab.Ad.Name,
                    CreatedOn = ab.Ad.CreatedOn.ToString(DateFormat),
                    Category = ab.Ad.Category.Name,
                    Description = ab.Ad.Description,
                    Price = ab.Ad.Price,
                    Owner = ab.Ad.Owner.UserName
                })
                .ToListAsync();
            return View(items);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            if (id==null)
            {
                BadRequest();

            }
            var ad = await dbContext.Ads.FirstOrDefaultAsync(a => a.Id == id);
            if (ad==null)
            {
                BadRequest();
            }
            return View(new AdEditViewModel()
            {
                Id=id,
                Name=ad.Name,
                Description=ad.Description,
                ImageUrl=ad.ImageUrl,
                Price=ad.Price,
                Categories=GetCategories()
            });

        }

        [HttpPost]
        public async Task<IActionResult> Edit(AdEditViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var item =await dbContext.Ads.FirstOrDefaultAsync(a => a.Id ==vm.Id);
                if (item!=null)
                {
                    item.Name=vm.Name;
                    item.Description=vm.Description;
                    item.CategoryId = vm.CategoryId;
                    item.ImageUrl=vm.ImageUrl;
                    item.Price = vm.Price;

                    await dbContext.SaveChangesAsync();
                }
            }
            return RedirectToAction("All");
        }
        [HttpPost]
        public async Task<IActionResult> RemoveFromCart(int id)
        {
            var item = await dbContext.Ads.FirstOrDefaultAsync(a => a.Id == id);
            if (item==null)
            {
                BadRequest();
            }
            var adbuyer = await dbContext.AdBuyers.FirstOrDefaultAsync(ab => ab.BuyerId == GetUserId() && ab.AdId == id);
            if (adbuyer == null)
            {
                BadRequest();
            }

            item.AdBuyers.Remove(adbuyer);
            await dbContext.SaveChangesAsync();

            return RedirectToAction("All");
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
        }
       
        private ICollection<CategoryViewModel> GetCategories()
        {
            return dbContext.Categories
                .Select(c => new CategoryViewModel()
                {
                    Id = c.Id,
                    Name = c.Name,
                })
                .ToList();
        }
    }
}
