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
                return RedirectToAction("Index", "Home");
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
            ViewBag.MaQH = new SelectList(data.quanHuyens.OrderBy(a => a.tenQH), "maQH", "tenQH");
            return View();
        }

        [HttpPost]
        public ActionResult DangKy(FormCollection collection)
        {
            ViewBag.MaQH = new SelectList(data.quanHuyens.OrderBy(a => a.tenQH), "maQH", "tenQH");
            string maKh;
            do
            {
                Random ran = new Random();
                int makh = ran.Next(0,99999999);
                maKh = "KH" + makh.ToString();
            } while (data.khachHangs.SingleOrDefault(a => a.maKH == maKh) != null);
            var hoten = collection["hoten"];
            var sodt = collection["sodt"];
            var email = collection["email"];
            var diachi = collection["diachi"];
            var ngaysinh = String.Format("{0:MM/dd/yyyy}", collection["ngaysinh"]);
            var gioitinh = true;
            if (collection["gioitinh"] == "Nam")
            {
                 gioitinh = false;
            }
            else if (collection["gioitinh"] == "Nữ")
            {
                 gioitinh = true;
            }
            var maqh = collection["maQH"];
            var matkhau = collection["matkhau"];
            using (var context = new dbBanHangOnlineEntities())
            {
                context.Set<khachHang>().AddOrUpdate(new khachHang
                {
                    maKH = maKh,
                    tenKH = hoten,
                    soDT = sodt,
                    email = email,
                    diaChi = diachi,
                    ngaySinh = DateTime.Parse(ngaysinh),
                    gioiTinh = gioitinh,
                    maQH = int.Parse(maqh),
                    diemTichLuy = 0,
                    matKhau = matkhau
                });
                context.SaveChanges();
            }
            return RedirectToAction("DangNhap", "User");
        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}