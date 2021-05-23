using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnMon.Models;
using System.Data.Entity.Migrations;
using System.IO;

namespace DoAnMon.Controllers
{
    public class AdminController : Controller
    {
        dbBanHangOnlineEntities data = new dbBanHangOnlineEntities();

        // GET: Admin
        public ActionResult Index()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        [HttpGet]
        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(FormCollection collection)
        {
            var tendn = collection["email"];
            var matkhau = collection["psw"];
            taiKhoanTV ad = data.taiKhoanTVs.SingleOrDefault(a => a.taiKhoan == tendn  && a.matKhau == matkhau && a.maNhom == 1);
            taiKhoanTV ad1 = data.taiKhoanTVs.SingleOrDefault(a => a.email == tendn && a.matKhau == matkhau && a.maNhom == 1);
            if (ad == null && ad1 == null)  
            {
                ViewBag.ThongBao = "Tên đăng nhập , email đăng nhập hoặc mật khẩu không chính xác";
            }
            else
            {
                //ViewBag.ThongBao = "Chúc mừng đăng nhập thành công";
                if (ad != null)
                {
                    Session["Admin"] = ad;
                }
                else
                {
                    Session["Admin"] = ad1;
                }
                return RedirectToAction("Index", "Admin");
            }
            
            return View();
        }

        public ActionResult Logout()
        {
            Session["Admin"] = null;
            return RedirectToAction("Login", "Admin");
        }

        public ActionResult SanPham()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            return View();
        }

        [HttpGet]
        public ActionResult XoaSanPham(string id)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            sanPham sanpham = data.sanPhams.SingleOrDefault(a => a.maSP == id);
            ViewBag.MaSach = sanpham.maSP;
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }

        [HttpPost,ActionName("XoaSanPham")]
        public ActionResult XacNhanXoa(string id)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            sanPham sanpham = data.sanPhams.SingleOrDefault(a => a.maSP == id);
            ViewBag.MaSach = sanpham.maSP;
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            using(var context = new dbBanHangOnlineEntities())
            {
                var xoa = new sanPham { maSP = id };
                context.sanPhams.Attach(xoa);
                context.sanPhams.Remove(xoa);
                context.SaveChanges();
            }
            return RedirectToAction("SanPham", "Admin");
        }

        [HttpGet]
        public ActionResult ThemSanPham()
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.maLoai = new SelectList(data.loaiSPs.ToList().OrderBy(a => a.loaiHang), "maLoai", "loaiHang");
            return View();
        }

        [HttpPost]
        public ActionResult ThemSanPham(sanPham sanpham, HttpPostedFileBase fileupload)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Asset/Images/sanPham"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình Ảnh Đã Tồn Tại";
                }
                else
                {
                    fileupload.SaveAs(path);
                }
                string masp;
                do
                {
                    Random ran = new Random();
                    int ma = ran.Next(0, 99999999);
                    masp = "SP" + ma.ToString();
                } while (data.sanPhams.SingleOrDefault(a => a.maSP == masp) != null);


                sanpham.hinhDD = "/Asset/Images/sanPham/" + fileName;
                sanpham.maSP = masp;
                sanpham.ngayDang = DateTime.Now;
                sanpham.taiKhoan = ((taiKhoanTV)Session["Admin"]).taiKhoan;
                sanpham.daDuyet = false;
                sanpham.nhaSanXuat = null;
                sanpham.dvt = null;
                using (var context = new dbBanHangOnlineEntities())
                {
                    context.Set<sanPham>().AddOrUpdate(sanpham);
                    context.SaveChanges();
                }

            }
            ViewBag.maLoai = new SelectList(data.loaiSPs.ToList().OrderBy(a => a.loaiHang), "maLoai", "loaiHang");
            return View();
        }

        [HttpGet]
        public ActionResult ChinhSua(string id)
        {
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            ViewBag.maLoai = new SelectList(data.loaiSPs.ToList().OrderBy(a => a.loaiHang), "maLoai", "loaiHang");
            sanPham sanpham = data.sanPhams.SingleOrDefault(a => a.maSP == id);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }

        [HttpPost]
        public ActionResult ChinhSua(string id,FormCollection collection, HttpPostedFileBase fileupload)
        {
            ViewBag.maLoai = new SelectList(data.loaiSPs.ToList().OrderBy(a => a.loaiHang), "maLoai", "loaiHang");
            if (Session["Admin"] == null)
            {
                return RedirectToAction("Login", "Admin");
            }
            if (ModelState.IsValid)
            {
                var fileName = Path.GetFileName(fileupload.FileName);
                var path = Path.Combine(Server.MapPath("~/Content/Asset/Images/sanPham"), fileName);
                if (System.IO.File.Exists(path))
                {
                    ViewBag.ThongBao = "Hình ảnh đã tồn tại";
                    return View();
                }
                else
                {
                    fileupload.SaveAs(path);
                }
                sanPham sanpham = data.sanPhams.SingleOrDefault(a => a.maSP == id);
                if (sanpham == null)
                {
                    Response.StatusCode = 404;
                    return null;
                }
                sanpham.tenSP = collection["tenSP"];
                sanpham.giaBan = int.Parse(collection["giaBan"]);
                sanpham.giamGia = int.Parse(collection["giamGia"]);
                sanpham.ndTomTat = collection["ndTomTat"];
                sanpham.hinhDD = "/Asset/Images/sanPham/" + fileName;
                sanpham.maLoai = int.Parse(collection["maLoai"]);
                using (var context = new dbBanHangOnlineEntities())
                {
                    context.Set<sanPham>().AddOrUpdate(sanpham);
                    context.SaveChanges();
                }
            }
            return RedirectToAction("SanPham");
        }
    }
}