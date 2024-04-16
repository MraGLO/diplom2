using diplom.Data;
using diplom.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace diplom.Controllers
{
    public class SubjectController : Controller
    {
        private readonly DiplomDbContext _dbContext;
        public SubjectController(DiplomDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IActionResult Index()
        {
            List<Subject> subject = _dbContext.Subjects.ToList();
            return View(subject);
        }

    }
}
