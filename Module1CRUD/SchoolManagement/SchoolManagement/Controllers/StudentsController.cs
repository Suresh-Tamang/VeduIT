using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SchoolManagement.Models;

namespace SchoolManagement.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
            
        }
        [Authorize]
        [HttpGet]
        public IActionResult AddStudents()
        {
            return View();
        }

        
        [HttpPost]
        public async Task<IActionResult> AddStudents(AddStudentsViewModel viewModel)
        {
            var student = new Student
            {
                Name = viewModel.Name,
                Email = viewModel.Email,
                Phone = viewModel.Phone,
                Address = viewModel.Address,
                Course = viewModel.Course,
                Enrolled = viewModel.Enrolled,

            };
            await dbContext.Students.AddAsync(student);
            await dbContext.SaveChangesAsync();

            TempData["SuccessMessage"] = "Student added successfully!";
            return RedirectToAction("Index","Students");


        }


        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students);
        }


        [HttpGet]
        public async Task<IActionResult> EditStudent(int id)
        {
            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }

        [HttpPost]
        public async Task<IActionResult> EditStudent(Student viewModel)
        {
            var student = await dbContext.Students.FindAsync(viewModel.Id);
            if (student is not null)
            {
                student.Name = viewModel.Name;
                student.Email = viewModel.Email;
                student.Phone = viewModel.Phone;
                student.Course = viewModel.Course;
                student.Enrolled = viewModel.Enrolled;
                await dbContext.SaveChangesAsync();
            }
            TempData["SuccessMessage"] = "Student Edited  successfully!";
            return RedirectToAction("", "Students");
        }


        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students.FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if (student is not null)
            {
                dbContext.Students.Remove(student);
                await dbContext.SaveChangesAsync();
            }
            TempData["SuccessMessage"] = "Student Deleted successfully!";
            return RedirectToAction("Index");
        }
    }
}
