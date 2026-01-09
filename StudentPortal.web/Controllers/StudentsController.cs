using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StudentPortal.web.Data;
using StudentPortal.web.Models;
using StudentPortal.web.Models.Table;

namespace StudentPortal.web.Controllers
{
    public class StudentsController : Controller
    {
        private readonly ApplicationDbContext dbContext;

        public StudentsController(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddStudentViewModel viewModel)
        {
            if (viewModel.Name is null || viewModel.Name == "")
            {
                ViewBag.msg = "Please Enter Name !";
            }
            else
            {
                var student = new Student
                {
                    Name = viewModel.Name,
                    Email = viewModel.Email,
                    Phone = viewModel.Phone,
                    Suscriber = viewModel.Suscriber
                };
                await dbContext.Students.AddAsync(student);
                await dbContext.SaveChangesAsync();
            }

            return View();
        }

        [HttpGet]
        public async Task<IActionResult> List()
        {
            var students = await dbContext.Students.ToListAsync();
            return View(students); 
        }

        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var student = await dbContext.Students.FindAsync(id);
            return View(student);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Student viewModel)
        {
            var student= await dbContext.Students.FindAsync(viewModel.Id);
            if(student != null)
            {
                student.Name= viewModel.Name;
                student.Email= viewModel.Email;
                student.Phone= viewModel.Phone;
                student.Suscriber= viewModel.Suscriber;

                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(Student viewModel)
        {
            var student = await dbContext.Students.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Id == viewModel.Id);
            if(student is not null)
            {
                dbContext.Students.Remove(new Student { Id = viewModel.Id});
                await dbContext.SaveChangesAsync();
            }
            return RedirectToAction("List", "Students");
        }
    }
}
