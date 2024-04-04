using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using WebAppMVC_1.Models;

namespace WebAppMVC_1.Areas.Database1.Controllers
{
    [Area("Database1")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext _context;
        public DbManageController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult DeleteDb()
        {
            return View();
        }

        [TempData]
        public string StatusMessage { set; get; }
        [HttpPost]
        public async Task<IActionResult> DeleteDbAsync()
        {
            var success =  await  _context.Database.EnsureDeletedAsync();
            StatusMessage = success ? "Xóa Database thành công" : "Xóa không thành công";
            return RedirectToAction("Index");
            
        }
        [HttpPost]
        public async Task<IActionResult> MigrationAsync()
        {
            await _context.Database.MigrateAsync(); // Cập nhật các Migration ở trạng thái Pending
            StatusMessage = "Cập nhập Migration thành công";
            return RedirectToAction("Index");
        }
    }
}
