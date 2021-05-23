using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAnMon.Models;
using System.Data.Entity.Migrations;

namespace DoAnMon.Controllers
{
    public class GioHangController : Controller
    {
        dbBanHangOnlineEntities data = new dbBanHangOnlineEntities();

        public List<GioHang> LayGioHang()
        {
            List<GioHang> GioHang_list = Session["GioHang"] as List<GioHang>;
            if (GioHang_list == null)
            {
                GioHang_list = new List<GioHang>();
                Session["GioHang"] = GioHang_list;
            }
            return GioHang_list;
        }

        public ActionResult ThemGioHang(string maSP,string strUrl)
        {
            List<GioHang> GioHang_list = LayGioHang();
            GioHang sanpham = GioHang_list.Find(a => a.maSP_cart == maSP);
            if (sanpham == null)
            {
                sanpham = new GioHang(maSP);
                GioHang_list.Add(sanpham);
                return Redirect(strUrl);
            }
            else
            {
                sanpham.soLuong_cart++;
                return Redirect(strUrl);
            }
        }

        public int TongSoLuong()
        {
            int TongSoLuong_cart = 0;
            List<GioHang> GioHang_list = Session["GioHang"] as List<GioHang>;
            if (GioHang_list != null)
            {
                TongSoLuong_cart = GioHang_list.Sum(a => a.soLuong_cart);
            }
            return TongSoLuong_cart;
        }

        public double TongTien()
        {
            double TongTien_cart = 0;
            List<GioHang> GioHang_list = Session["GioHang"] as List<GioHang>;
            if (GioHang_list != null)
            {
                TongTien_cart = GioHang_list.Sum(a => a.thanhTien_cart);
            }
            return TongTien_cart;
        }

        // GET: GioHang
        public ActionResult Index()
        {
            List<GioHang> GioHang_list = LayGioHang();
            if (GioHang_list.Count == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = String.Format("{0:0,0}", TongTien());
            return View(GioHang_list);
        }

        public ActionResult XoaSanPham(string id)
        {
            List<GioHang> GioHang_list = LayGioHang();
            GioHang sanpham = GioHang_list.SingleOrDefault(a => a.maSP_cart == id);
            if (sanpham != null)
            {
                GioHang_list.RemoveAll(a => a.maSP_cart == id);
                return RedirectToAction("Index");
            }
            if (GioHang_list.Count() == 0)
            {
                return RedirectToAction("Index", "Home");
            }
            return RedirectToAction("Index");
        }

        public ActionResult CapNhat(string id,FormCollection f)
        {
            List<GioHang> GioHang_list = LayGioHang();
            GioHang sanpham = GioHang_list.SingleOrDefault(a => a.maSP_cart == id);
            if (sanpham != null)
            {
                sanpham.soLuong_cart = int.Parse(f["txtSoLuong"].ToString());
            }
            return RedirectToAction("Index");
        }

        public ActionResult XoaTatCa()
        {
            List<GioHang> GioHang_list = LayGioHang();
            GioHang_list.Clear();
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public ActionResult DatHang()
        {
            if (Session["TaiKhoan"] == null || Session["TaiKhoan"].ToString() == "")
            {
                return RedirectToAction("DangNhap", "User");
            }
            if (Session["GioHang"] == null)
            {
                return RedirectToAction("Index", "Shop");
            }
            List<GioHang> GioHang_list = LayGioHang();
            ViewBag.TongSoLuong = TongSoLuong();
            ViewBag.TongTien = TongTien();
            return View(GioHang_list);
        }

        [HttpPost]
        public ActionResult DatHang(FormCollection collection)
        {
            donHang donhang = new donHang();
            khachHang khachhang = (khachHang)Session["TaiKhoan"];
            List<GioHang> GioHang_list = LayGioHang();
            string sodh;
            do
            {
                Random ran = new Random();
                int so = ran.Next(0, 99999999);
                sodh = "DH" + so.ToString();
            } while (data.donHangs.SingleOrDefault(a => a.soDH == sodh) != null);
            donhang.soDH = sodh;
            donhang.maKH = khachhang.maKH;
            donhang.taiKhoan = khachhang.email;
            donhang.ngayDat = DateTime.Now;
            donhang.daKichHoat = false;
            donhang.ngayGH = DateTime.Parse(String.Format("{0:MM/dd/yyyy}", collection["NgayGiao"]));
            donhang.diaChiGH = khachhang.diaChi + "," + data.quanHuyens.SingleOrDefault(a => a.maQH == khachhang.maQH).tenQH;
            donhang.trangThai = 0;
            using(var context = new dbBanHangOnlineEntities())
            {
                context.Set<donHang>().AddOrUpdate(donhang);
                foreach(var item in GioHang_list)
                {
                    context.Set<ctDonHang>().AddOrUpdate(new ctDonHang
                    {
                        soDH = donhang.soDH,
                        maSP = item.maSP_cart,
                        soLuong = item.soLuong_cart,
                        giaBan = long.Parse(item.donGia_cart.ToString()),
                        giamGia = 0
                    });
                }
                context.SaveChanges();
            }
            Session["GioHang"] = null;
            return RedirectToAction("XacNhanDonHang","GioHang");
        }

        public ActionResult XacNhanDonHang()
        {
            return View();
        }
    }
}