using Homies.Data;
using Homies.Models;
using Homies.Models.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Globalization;
using System.Security.Claims;
using System.Security.Permissions;

namespace Homies.Controllers
{
    [Authorize]
    public class EventController : Controller
    {
        private HomiesDbContext dbContext;

        public EventController(HomiesDbContext _dbContext)
        {
            dbContext= _dbContext;
        }
        [ActionName("All")]
        public async Task<IActionResult> Index()
        {
            var events = dbContext.Events
                .Select(e => new EventViewModel()
                {
                    Id = e.Id,
                    Name = e.Name,
                    Start = e.Start.ToString("yyyy-MM-dd H:mm"),
                    Type = e.Type.Name,
                    Organiser=e.Organiser.UserName
                });
            return View(events);
        }

        [HttpGet]
        public async Task<IActionResult> Add()
        {
            EventCreationViewModel vm=new EventCreationViewModel();
            vm.Types = GetTypes();
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Add(EventCreationViewModel vm)
        {
            var start = DateTime.Now;
            var end = DateTime.Now;
            if (!DateTime
                .TryParseExact(vm.Start,
                "yyyy-MM-dd H:mm", 
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(vm.Start), "Invalid date!");
            }
            if (!DateTime
                .TryParseExact(vm.End,
                "yyyy-MM-dd H:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState.AddModelError(nameof(vm.End), "Invalid date!");
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Add));
            }
            Event eventModel=new Event() {
                Name= vm.Name,
                Description= vm.Description,
                Start= start,
                End=end,
                CreatedOn=DateTime.Now,
                TypeId= vm.TypeId,
                OrganiserId=GetUserId(),

            };

            await dbContext.Events.AddAsync(eventModel);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("All");
        }


        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var eventModel = await dbContext.Events
                .Include(e=>e.EventsParticipants)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (eventModel==null)
            {
                BadRequest();
            }
            bool exists=eventModel.EventsParticipants.Any(p => p.HelperId == GetUserId());
            if (!exists)
            {
                eventModel.EventsParticipants.Add(new EventParticipant() { EventId = id, HelperId = GetUserId() });
                await dbContext.SaveChangesAsync();
                return RedirectToAction(nameof(Joined));
            }
            return RedirectToAction("All");
        }
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            ICollection<EventViewModel> models = await dbContext.EventsParticipants
                .AsNoTracking()
                .Where(ep=>ep.HelperId == GetUserId())
                .Select(e=>new EventViewModel()
                {
                    Id=e.Event.Id,
                    Name = e.Event.Name,
                    Start= e.Event.Start.ToString("yyyy-MM-dd H:mm"),
                    Type= e.Event.Name,
                    Organiser= e.Event.Organiser.UserName
                }
                )
                .ToListAsync();
            return View(models);
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var item = await dbContext.Events.FirstOrDefaultAsync(e => e.Id == id);
            if (item == null)
            {
                BadRequest();
            }
            EventCreationViewModel vm = new EventCreationViewModel()
            {
                Id = id,
                Name = item.Name,
                Description = item.Description,
                Start = item.Start.ToString("yyyy-MM-dd H:mm"),
                End = item.End.ToString("yyyy-MM-dd H:mm"),
                Types = GetTypes()
            };
            return View(vm);
        
        }

        [HttpPost]
        public async Task<IActionResult> Edit(EventCreationViewModel vm)
        {
            var start = DateTime.Now;
            var end = DateTime.Now;
            if (!DateTime
                .TryParseExact(vm.Start,
                "yyyy-MM-dd H:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out start))
            {
                ModelState.AddModelError(nameof(vm.Start), "Invalid date!");
            }
            if (!DateTime
                .TryParseExact(vm.End,
                "yyyy-MM-dd H:mm",
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out end))
            {
                ModelState.AddModelError(nameof(vm.End), "Invalid date!");
            }
            if (!ModelState.IsValid)
            {
                return RedirectToAction(nameof(Add));
            }
            var entity = await dbContext.Events.FindAsync(vm.Id);

            entity.Name = vm.Name;
            entity.Description = vm.Description;
            entity.Start = start;
            entity.End = end;
            entity.CreatedOn = DateTime.Now;
            entity.TypeId = vm.TypeId;
            entity.OrganiserId = GetUserId();
           
            if (await dbContext.SaveChangesAsync()>0)
            {
                return RedirectToAction("All");

            }
            return RedirectToAction(nameof(Edit), vm.Id);
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (!dbContext.Events.Any(e=>e.Id==id))
            {
                return BadRequest();
            }

            var model = await dbContext.Events
                .Include(e=>e.Organiser)
                .Include(e=>e.Type)
                .FirstOrDefaultAsync(e => e.Id == id);

            EventDetailsViewModel vm = new EventDetailsViewModel()
            {
                Id = model.Id,
                Name = model.Name,
                Description = model.Description,
                CreatedOn = model.CreatedOn.ToString("yyyy-MM-dd H:mm"),
                Organiser = model.Organiser.UserName,
                Start = model.Start.ToString("yyyy-MM-dd H:mm"),
                End = model.End.ToString("yyyy-MM-dd H:mm"),
                Type = model.Type.Name
            };
            return View(vm);
        }

        public async Task<IActionResult> Leave(int id)
        {
            var ep=await dbContext.EventsParticipants
                .FirstOrDefaultAsync(ep => ep.HelperId == GetUserId());
            if (ep == null)
            {
                BadRequest();
            }
            var model = await dbContext.Events
                .Include(e=>e.EventsParticipants)
                .FirstOrDefaultAsync(e => e.Id == id);
            if (id == null)
            {
                BadRequest();
            }
            model.EventsParticipants.Remove(ep);
            await dbContext.SaveChangesAsync();
            return RedirectToAction("All");
        }
        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }
        private List<TypeViewModel> GetTypes()
        {
            return dbContext.Types
                .Select(t => new TypeViewModel()
                {
                    Id = t.Id,
                    Name = t.Name,
                })
                .ToList();
        }
    }
}
