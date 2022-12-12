using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Project.Models;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Project.Controllers
{
    public class NguoiDungAdminController : AbstractController
    {
        Bds_CShapContext context;
        public NguoiDungAdminController()
        {
            context = new Bds_CShapContext();
        }
        public IActionResult Index()
        {
            return View("/");
        }
        public IActionResult DanhSach(string sort, int role, string search,int Pageindex, string thongbao,string thongbao2)
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true);// true: and, false: or

            int Pagesize = 5;
            string jsonStr = HttpContext.Session.GetString("useraccount");
            User c;
            if (jsonStr is null) c = new User();
            else c = JsonConvert.DeserializeObject<User>(jsonStr);
            List<User> listuser = context.Users.Where(x=>x.UserId!=c.UserId).ToList();
            if (string.IsNullOrEmpty(sort)&& role==0 && string.IsNullOrEmpty(search)&&Pageindex==0)
            {
                if (Pageindex == 0) { Pageindex = 1; }
                ViewBag.PageEnd = Logic.ExtensionPage.PageEndUser(listuser, Pagesize);
                ViewBag.UserList = Logic.ExtensionPage.PagingUser(listuser, Pageindex, Pagesize);
                ViewBag.PageIndex = Pageindex;
                if (!string.IsNullOrEmpty(thongbao)) { ViewBag.thongbao = "Đã xóa thành công!"; }
                if (!string.IsNullOrEmpty(thongbao2)) { ViewBag.thongbao = "Đã thay đổi thành công!"; }
                return View("/Views/User/UserList.cshtml");
            }
            else
            {
                if (Pageindex == 0) { Pageindex = 1; }
                
                if (!string.IsNullOrEmpty(sort))
                {
                    if (sort.Equals("des")) { listuser = listuser.OrderByDescending(x => x.UserId).ToList(); }
                    else { listuser = listuser.OrderBy(x => x.UserId).ToList(); }
                }
                if (role != 0) { listuser = listuser.Where(x => x.RoleId==role).ToList(); }
                if (!string.IsNullOrEmpty(search)) { listuser = listuser.Where(x => x.FullName.ToLower().Contains(search.ToLower())).ToList(); }
                ViewBag.PageEnd = Logic.ExtensionPage.PageEndUser(listuser, Pagesize);
                listuser = Logic.ExtensionPage.PagingUser(listuser, Pageindex, Pagesize);
                ViewBag.UserList = listuser;
                ViewBag.sort = sort;
                ViewBag.role = role;
                ViewBag.search = search;
                ViewBag.PageIndex = Pageindex;
                if (!string.IsNullOrEmpty(thongbao)) { ViewBag.thongbao = "Đã xóa thành công!"; }
                return View("/Views/User/UserList.cshtml");
            }
        }
        public IActionResult DoiVaiTro(int id, int roleuser)
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true);// true: and, false: or

            User u = context.Users.FirstOrDefault(x => x.UserId == id);
            u.RoleId= roleuser;
            context.Users.Update(u);
            context.SaveChanges();
            string thongbao = "konull!";
            return Redirect("/nguoidungadmin/danhsach?thongbao2=" + thongbao);
        }
        [HttpPost]
        public IActionResult XoaNguoiDung(int id)
        {
            User ucheck = CheckRoleSession(new int[] { 1 }, true);// true: and, false: or

            User u = context.Users.FirstOrDefault(x=> x.UserId == id);
            context.Users.Remove(u);
            context.SaveChanges();
            if (!string.IsNullOrEmpty(u.ImgAvar))
            {
                string imgPath = Path.Combine(Directory.GetCurrentDirectory(),
                      "wwwroot", "myfiles", u.ImgAvar);
                FileInfo fi = new FileInfo(imgPath);
                if (fi != null){
                   System.IO.File.Delete(imgPath);
                   fi.Delete();
                }
            }
            string thongbao = "konull!";
            return Redirect("/nguoidungadmin/danhsach?thongbao="+ thongbao);
        }
    }
}
