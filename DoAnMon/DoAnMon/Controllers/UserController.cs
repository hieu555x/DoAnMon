using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnMon.Models;
using System.Data.Entity.Migrations;

namespace DoAnMon.Controllers
{
    public class UserController : Controller
    {
        dbBanHangOnlineEntities data = new dbBanHangOnlineEntities();
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult DangNhap()
        {
            return View();
        }

        [HttpPost]
        public ActionResult  DangNhap(FormCollection collection)
        {
            var tendn = collection["TenDN"];
            var matkhau = collection["MatKhau"];
            khachHang kh = data.khachHangs.SingleOrDefault(a => a.email == tendn && a.matKhau == matkhau);
            if (kh != null)
            {
                Session["TaiKhoan"] = kh;
                return RedirectToAction("Index", "Shop");
            }
            else
            {
                ViewBag.ThongBao = "Tên đăng nhập hoặc mật khẩu không đúng";
            }
            return View();
        }

        [HttpGet]
        public ActionResult DangKy()
        {
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection)
        {
            string maKh;
            do
            {
                Random ran = new Random();
                int makh = ran.Next();
                maKh = "KH" + makh;
            } while (data.khachHangs.SingleOrDefault(a => a.maKH == maKh) != null);
            var hoten = collection["hoten"];
            var sodt = collection["sodt"];
            var email = collection["email"];
            var diachi = collection["diachi"];
            var ngaysinh = collection["ngaysinh"];
            var gioitinh = collection["gioitinh"];

        }
    }
}