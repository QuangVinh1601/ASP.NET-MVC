using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.IO;
using System.Linq;
using WebAppMVC_1.Models;
using WebAppMVC_1.Services;

namespace WebAppMVC_1.Controllers
{
    public class FirstController : Controller
    {
        private readonly ILogger<FirstController> _logger;
        private readonly ProductService _product;
        public FirstController(ILogger<FirstController> logger, ProductService product)
        {
            _logger = logger;
            _product = product;
        }
        //Những thuộc tính được thiết lập sau khi Controller được khởi tạo để lưu trữ các dữ liệu của HTTP Request gửi tới

        //this.HttpContexst
        //this.Request
        //this.Response
        //this.RouteData

        //this.User
        //this.ModelState
        //this.ViewData
        //this.ViewBag
        //this.Url
        //this.TempData

        public string Index()
        {
            _logger.LogInformation("Trang First Index");
            return "Day la Index của First";
        }
        public void Nothing()
        {
            _logger.LogInformation("Nothing");
            Response.Headers.Add("Ten", "Vinh");
        }
        public object Anything ()
        {
            return new int[] { 1, 2, 3, 4 };
        }
        public IActionResult Action()
        {
            //         Kiểu trả về | Phương thức
            //------------------------------------------------
            //    ContentResult |    Content()  -> tra ve header chua noi dung là Content() ve cho Client
            //    EmptyResult |   new EmptyResult()
            //    FileResult |   File()
            //    ForbidResult |     Forbid()
            //    JsonResult |   Json()
            //    LocalRedirectResult | LocalRedirect() -> chuyen huong den trang Local trong du an
            //    RedirectResult |   Redirect() -> chuyen huong den 1 Url bat kì
            //    RedirectToActionResult | RedirectToAction()
            //    RedirectToPageResult | RedirectToRoute()
            //    RedirectToRouteResult | RedirectToPage()
            //    PartialViewResult | PartialView()
            //    ViewComponentResult | ViewComponent()
            //    StatusCodeResult |     StatusCode()
            //    ViewResult |   View()
            string content = @"
                Minh la Nguyen Huu Quang Vinh,
                Dai hoc Duy Tan



            ";
            return Content(content, "text/html");
        }
        public IActionResult Cat()
        {
            string filePath = Path.Combine(Startup.ContentRootPath, "Files", "hinh-nen-ngo-nghinh-anh-meo-cute-nupet-new-6.jpg");
            byte[] bytes = System.IO.File.ReadAllBytes(filePath);
            return File(bytes, "image/jpg");
        }
        public IActionResult JsonContent ()
        {
            return Json(new
            {
                product = "Iphone X",
                price = 100
            });
        }
        public IActionResult LocalRedirect()
        {
            string url =  Url.Action("Privacy", "Home");
            _logger.LogInformation("Home - Privacy");
            return LocalRedirect(url); //tra ve LocalRedirectResult
        }
        public IActionResult AnyRedirect()
        {
            string url = "https://google.com";
            _logger.LogInformation($"Chuyen huong den {url}");
            return Redirect(url); //tra ve RedirectResult
        }
        public IActionResult XinChao(string username)
        {
            

            //TH1: View -> duong dan tuyet doi den .cshtml
            //return View("/MyView/xinchaomoinguoi.cshtml");  // View() -> su dung Razor Engine, đọc file .cshtml

            //TH2: View -> truyen Model vao .cshtml
            //return View("/MyView/xinchaomoinguoi.cshtml" , username);

            //TH3: View -> duong dan tuong doi den. cshtml (/Views/Ten Controller/.cshtml)
            //return View("xinchaomoinguoi2", username);

            //TH4: View -> khong truyen tham so (Razor Engine thi hanh trang View co cung ten voi Action)
            // Views/Ten Controller/ XinChao.cshtml
            // return View((object)username);

            return View();
        }
        [AcceptVerbs("POST","GET")]
        public IActionResult ViewProduct(int? id)
        {
            if (id == null)
            {
                return NotFound("Không tìm thấy sản phẩm");
            }
            ProductModel product = _product.Products.Where(p => p.Id == id).FirstOrDefault();
            if (product == null)
            {
                this.TempData["StatusMessage"] = "Không tìm thấy sản phẩm tương ứng";
                return Redirect(Url.Action("Index", "Home"));
            }
            //return View(product);

            //Truyen ViewData

            //this.ViewData["product"] = product;
            //return View("ViewProduct2");

            //Truyen ViewBag

            this.ViewBag.Product = product;
            //this.ViewData["Title"] = product.Name;
            return View("ViewProduct3");
        }
        

    }
}
