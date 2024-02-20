using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SeminarHub.Constraints.ErrorMessages;
using SeminarHub.Constraints.ValidationValues;
using SeminarHub.Data;
using SeminarHub.Models;
using SeminarHub.Models.ViewModels;
using System.Globalization;
using System.Security.Claims;

namespace SeminarHub.Controllers
{
    [Authorize]
    public class SeminarController : Controller
    {
        private readonly SeminarHubDbContext context;
        public SeminarController(SeminarHubDbContext _context)
        {
            context = _context;
        }

        [ActionName("All")]
        public async Task<IActionResult> Index()
        {
            var id = User?.Identity?.Name;
            var seminars = await context.Seminars
                .Include(s => s.Organizer)
                .Select(s => new SeminarCardViewModel()
                {
                    Id = s.Id,
                    Topic = s.Topic,
                    Lecturer = s.Lecturer,
                    Category = s.Category.Name,
                    DateAndTime = s.DateAndTime.ToString(ValidationValues.Seminar.DateFormat),
                    Organizer = s.Organizer.UserName
                })
                .ToListAsync();
            return View(seminars);
        }


        [HttpGet]
        public async Task<IActionResult> Add()
        {

            return View(new SeminarAddViewModel() { Categories = await GetCategories() }); ;
        }
        [HttpPost]
        public async Task<IActionResult> Add(SeminarAddViewModel vm)
        {
            if (vm == null)
            {
                vm.Categories = await GetCategories();
                return View(vm);
            }
            DateTime date = DateTime.Now;
            if (!DateTime.TryParseExact(
                vm.DateAndTime,
                ValidationValues.Seminar.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date))
            {
                ModelState.AddModelError(nameof(vm.DateAndTime), string.Format(ErrorMessages.invalidDateFormat, ValidationValues.Seminar.DateFormat));
            }
            if (!ModelState.IsValid)
            {
                vm.Categories = await GetCategories();
                return View(vm);
            }
            context.Seminars.Add(new Seminar()
            {
                Topic = vm.Topic,
                Lecturer = vm.Lecturer,
                Details = vm.Details,
                DateAndTime = date,
                Duration = vm.Duration,
                CategoryId = vm.CategoryId,
                OrganizerId = GetUserId()

            });
            if (await context.SaveChangesAsync() > 0)
            {
                return RedirectToAction("All");
            }
            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Join(int id)
        {
            var seminar = await context.Seminars
                .Include(s => s.SeminarsParticipants)
                .FirstOrDefaultAsync(s => s.Id == id);
            if (seminar == null)
            {
                return RedirectToAction("All");
            }
            if (!seminar.SeminarsParticipants.Any(sp => sp.ParticipantId == GetUserId()))
            {
                seminar.SeminarsParticipants.Add(new SeminarParticipant()
                {
                    ParticipantId = GetUserId(),
                    SeminarId = id
                });
                await context.SaveChangesAsync();
                return RedirectToAction(nameof(Joined));
            }
            return RedirectToAction("All");

        }
        [HttpGet]
        public async Task<IActionResult> Joined()
        {
            var seminars = await context.SeminarParticipants
                .Include(sp => sp.Seminar)
                .AsNoTracking()
                .Where(sp => sp.ParticipantId == GetUserId())
                .Select(sp => new SeminarCardViewModel()
                {
                    Id = sp.Seminar.Id,
                    Topic = sp.Seminar.Topic,
                    Lecturer = sp.Seminar.Lecturer,
                    Category = sp.Seminar.Category.Name,
                    DateAndTime = sp.Seminar.DateAndTime.ToString(ValidationValues.Seminar.DateFormat),
                    Organizer = sp.Seminar.Organizer.UserName
                })
                .ToListAsync();
            return View(seminars);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var seminar = await context.Seminars
              .FirstOrDefaultAsync(s => s.Id == id);
            if (seminar == null) { return RedirectToAction("All"); }
            if (seminar.OrganizerId == GetUserId())
            {
                var seminarVm = new SeminarAddViewModel()
                {
                    Topic = seminar.Topic,
                    Lecturer = seminar.Lecturer,
                    Details = seminar.Details,
                    DateAndTime = seminar.DateAndTime.ToString(ValidationValues.Seminar.DateFormat),
                    Duration = seminar.Duration,
                    CategoryId = seminar.CategoryId,
                    Categories = await GetCategories()
                };
                return View(seminarVm);
            }
            return RedirectToAction("All");
        }
        [HttpPost]
        public async Task<IActionResult> Edit(SeminarAddViewModel vm, int id)
        {
            var seminar = await context.Seminars
               .FirstOrDefaultAsync(s => s.Id == id);

            if (seminar == null)
            {
                vm.Categories = await GetCategories();
                return View(vm);
            }
            DateTime date = DateTime.Now;
            if (!DateTime.TryParseExact(
                vm.DateAndTime,
                ValidationValues.Seminar.DateFormat,
                CultureInfo.InvariantCulture,
                DateTimeStyles.None,
                out date))
            {
                ModelState.AddModelError(nameof(vm.DateAndTime), string.Format(ErrorMessages.invalidDateFormat, ValidationValues.Seminar.DateFormat));
            }
            if (!ModelState.IsValid)
            {
                vm.Categories = await GetCategories();
                return View(vm);
            }
            seminar.Topic = vm.Topic;
            seminar.DateAndTime = date;
            seminar.Lecturer = vm.Lecturer;
            seminar.Details = vm.Details;
            seminar.Duration = vm.Duration;
            seminar.CategoryId = vm.CategoryId;
            await context.SaveChangesAsync();
            return RedirectToAction("All");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            var seminar = await context.Seminars
               .Include(s => s.Category)
               .Include(s => s.Organizer)
               .FirstOrDefaultAsync(s => s.Id == id);
            if (seminar == null)
            {
                return RedirectToAction("All");
            }
            var vm = new SeminarDetailsViewModel()
            {

                Id = seminar.Id,
                Topic = seminar.Topic,
                Lecturer = seminar.Lecturer,
                Category = seminar.Category.Name,
                DateAndTime = seminar.DateAndTime.ToString(ValidationValues.Seminar.DateFormat),
                Organizer = seminar.Organizer.UserName,
                Details = seminar.Details,
                Duration = seminar.Duration
            };
            return View(vm);
        }
        [HttpPost]
        public async Task<IActionResult> Leave(int id)
        {
            var seminar = await context.Seminars
                .Include(s => s.SeminarsParticipants)
              .FirstOrDefaultAsync(s => s.Id == id);
            var participant = seminar.SeminarsParticipants
                .FirstOrDefault(sp => sp.ParticipantId == GetUserId());
            if (seminar == null)
            {
                BadRequest();
            }

            seminar.SeminarsParticipants.Remove(participant);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Joined));

        }
        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var seminar = await context.Seminars
             .Include(s => s.Organizer)
             .FirstOrDefaultAsync(s => s.Id == id);

            if (seminar == null || seminar.Organizer.Id != GetUserId())
            {
                

                return RedirectToAction(nameof(Details));
            }
            //First removing the seminar from the users's joined seminars, then deleting it
            var usersWithThisSeminar = await context.SeminarParticipants
                    .Where(sp => sp.SeminarId == id)
                    .ToArrayAsync();
            context.SeminarParticipants.RemoveRange(usersWithThisSeminar);
            context.Seminars.Remove(seminar);
            await context.SaveChangesAsync();
            return RedirectToAction("All");

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var seminar = await context.Seminars
            .FirstOrDefaultAsync(s => s.Id == id);
            if (seminar == null)
            {
                return RedirectToAction("All");
            }
            if (seminar.OrganizerId == GetUserId())
            {
                var vm = new SeminarDeleteViewModel()
                {
                    Id = id,
                    Topic = seminar.Topic,
                    DateAndTime = seminar.DateAndTime,
                };
                return View(vm);
            }
            return RedirectToAction("All");

        }

        private string GetUserId()
        {
            return User.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        }

        private async Task<ICollection<CategoryViewModel>> GetCategories()
        {
            return await context.Categories.Select(c => new CategoryViewModel { Name = c.Name, Id = c.Id }).ToListAsync();
        }

    }
}
