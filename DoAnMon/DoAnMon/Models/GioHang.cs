using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DoAnMon.Models;

namespace DoAnMon.Models
{
    public class GioHang
    {
        dbBanHangOnlineEntities data = new dbBanHangOnlineEntities();

        public string maSP_cart { get; set; }
        public string tenSP_cart { get; set; }
        public string hinhAnh_cart { get; set; }
        public double donGia_cart { get; set; }
        public int soLuong_cart { get; set; }
        public double thanhTien_cart
        {
            get
            {
                return soLuong_cart * donGia_cart;
            }
        }
        public GioHang(string maSP)
        {
            maSP_cart = maSP;
            sanPham sanpham = data.sanPhams.Single(a => a.maSP == maSP);
            tenSP_cart = sanpham.tenSP;
            hinhAnh_cart = sanpham.hinhDD;
            donGia_cart = double.Parse(sanpham.giaBan.ToString());
            soLuong_cart = 1;
        }
    }
}