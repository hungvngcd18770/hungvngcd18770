using ASPDevApp.Models;
using ASPDevApp.ViewModel;
using Microsoft.Ajax.Utilities;
using Microsoft.AspNet.Identity;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;

namespace ASPDevApp.Controllers
{
    [Authorize]
    public class CoursesController : Controller
    {

        private ApplicationDbContext _context;
        public CoursesController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Index(string searchString)
        {
            var userId = User.Identity.GetUserId();
            var courses = _context.Courses
                .Include(t => t.Category)
                .ToList();//.Where(t => t.UserId.Equals(userId))

            if (!searchString.IsNullOrWhiteSpace())
            {
                courses = _context.Courses
                    .Where(t => t.Name.Contains(searchString))
                    .Include(t => t.Category)
                    .ToList();
            }
            return View(courses);
        }
        [HttpGet]
        public ActionResult Create()
        {
            var viewModel = new CourseCategoriesViewModel()
            {
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }
        [HttpPost]
        public ActionResult Create(Course course)
        {
            
            if (!ModelState.IsValid)
            {
                return View();
            }
            var userId = User.Identity.GetUserId();
            var newCourse = new Course()
            {
                Name = course.Name,
                Description = course.Description,
                CategoryId = course.CategoryId
            };
            _context.Courses.Add(newCourse);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            var userId = User.Identity.GetUserId();
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);

            if (courseInDb == null) return HttpNotFound();
            var trainer = _context.TrainerProfiles.Where(t => t.CourseId == id);
            foreach (var item in trainer)
            {
                item.Course = null;
                item.CourseId = null;
            }
            var trainee = _context.TraineeProfiles.Where(t => t.CourseId == id);
            foreach (var item in trainee)
            {
                item.Course = null;
                item.CourseId = null;

            }
            _context.Courses.Remove(courseInDb);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            
            var courseInDb = _context.Courses.SingleOrDefault(t => t.Id == id);
            if (courseInDb == null) return HttpNotFound();

            var userId = User.Identity.GetUserId();

            var viewModel = new CourseCategoriesViewModel()
            {
                Course = courseInDb,
                Categories = _context.Categories.ToList()
            };
            return View(viewModel);
        }

        [HttpPost]
        public ActionResult Edit(Course course)
        {
            if (!ModelState.IsValid)
            {
                var viewModel = new CourseCategoriesViewModel()
                {
                    Course = course,
                    Categories = _context.Categories.ToList()
                };
                return View(viewModel);
            }
            var userId = User.Identity.GetUserId();
            var courseInDb = _context.Courses
                
                .SingleOrDefault(t => t.Id == course.Id);//.Where(t => t.UserId.Equals(userId))

            courseInDb.Name = course.Name;
            courseInDb.Description = course.Description;
            courseInDb.CategoryId = course.CategoryId;
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }

}