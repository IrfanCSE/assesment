using Microsoft.AspNetCore.Mvc;
using primetechmvc.DTO;
using primetechmvc.IRepository;

namespace JWT.Controllers
{
    public class StudentController : Controller
    {
        private readonly IStudent _student;
        public StudentController(IStudent student)
        {
            _student = student;
        }

        public async Task<IActionResult> Index()
        {
            var list = await _student.StudentList();
            return View(list);
        }

        public IActionResult Assign()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Assign([FromForm] StudentDto obj)
        {
            var response = _student.AssignSubjectWithStudent(obj);
            return RedirectToAction("Index",response);
        }

        public async Task<IActionResult> Details(Guid StudentId)
        {
            var subjects = await _student.StudentSubjectById(StudentId);
            return View(subjects);
        }

        // [HttpGet]
        // [Route("Subject/Dropdown")]
        // public IActionResult GetDepartmentWithSubject()
        // {
        //     return Ok(_student.GetDepartmentWithSubject());
        // }
    }
}