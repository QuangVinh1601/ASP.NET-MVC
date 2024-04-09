using App.Data;
using App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;
using System.Threading.Tasks;
using WebAppMVC_1.Models;

namespace WebAppMVC_1.Areas.Database1.Controllers
{
    [Area("Database1")]
    [Route("/database-manage/[action]")]
    public class DbManageController : Controller
    {
        private readonly AppDbContext _context;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly UserManager<AppUser> _userManager;
        private readonly ILogger<DbManageController> _logger;
        public DbManageController(AppDbContext context , RoleManager<IdentityRole> roleManager, UserManager<AppUser> userManager, ILogger<DbManageController> logger)
        {
            _context = context;
            _roleManager = roleManager;
            _userManager = userManager;
            _logger = logger;
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
        public async Task<IActionResult> SeedDataAsync()
        {
            var roleNames = typeof(RoleName).GetFields().ToList();
            _logger.LogInformation("Quang VInh ");
            foreach ( var r in roleNames)
            {
                var roleName = (string)r.GetRawConstantValue();
                _logger.LogInformation(roleName);
                var role =  await _roleManager.FindByNameAsync(roleName);
                if (role == null)
                {
                    await _roleManager.CreateAsync(new IdentityRole(roleName));
                }
            }
            var useradmin = await _userManager.FindByNameAsync("admin");
            if(useradmin == null)
            {
                useradmin = new AppUser
                {
                    UserName = "admin", 
                    EmailConfirmed = true,
                    Email = "admin@example.com"
                };
                await _userManager.CreateAsync(useradmin, "admin123");
                await _userManager.AddToRoleAsync(useradmin, RoleName.Administrator);
            }
           
            StatusMessage = "SeedData thành công";
            return RedirectToAction("Index");
        }
    }
}
