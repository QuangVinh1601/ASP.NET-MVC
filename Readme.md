## Controller
- Là một lớp kế thừa từ lớp Controller: Microsoft.AspNetCore.Mvc
- Khi khởi tạo Controller, thì hệ thống sẽ khởi tạo các thuộc tính cho C để chứa các dữ liệu mà Http request nó gửi đến 
- Action trả về bất kỳ kiểu dữ liệu nào, thường là IActionResult
- Các dịch vụ được inject vào Controller qua phương thức khởi tạo

## View 
- View là trang có đuôi .cshtml
- View của Action, mặc định được lưu tại: /Views/Tên Controller/Action.cshtml
- Thêm thư mục lưu trữ View;
```
   {0}: Action
   {1}: Controller
   {2}: Area
   options.ViewLocationFormats.Add("/MyView/{1}/{0}"+ RazorViewEngine.ViewExtension);
```

## Truyền dữ liệu sang View
- Model
- ViewData
- ViewBag
- TempData

## Area
- Là tên dùng để Routing
- Là cấu trúc thư mục chứa M.V.C
- Thiết lập Area cho Controller bằng '''[Area("AreaName)]'''
```
dotnet aspnet-codegenerator area Product
```

## Route
- endpoints.MapControllerRoute()
- endpoint.MapAreaControllerRoute()
- [AcceptVerbs("POST", "GET")] -> Chỉ áp dụng cho Action
- [Route("pattern")] -> Chỉ rõ địa chỉ tương đối hoặc tuyệt đối đến các Action hoặc Controller
- [HtppGet], [HttpPost]

## Url Generator
UrlTagHelper: Action(), ActionLink(), RouteUrl(), Link()
```
Url.Action("PlanetInfo", "Planet", new{id = 1}, Context.Request.Schema)
Url.RouteUrl("default", new {controller ="First", action="HelloView", id=1 , username="QuangVinh"})
```
## HTML Tag Helper : ``` <a>, <form>, <button>```
- Sử dụng thuộc tính
```
asp-area="ProductList"
asp-action="Index"
asp-controller ="Product"
asp-route-...= 123
asp-route="default"
```