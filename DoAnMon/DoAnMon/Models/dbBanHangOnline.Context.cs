﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnMon.Models
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    using System.Data.Entity.Core.Objects;
    using System.Linq;
    
    public partial class dbBanHangOnlineEntities : DbContext
    {
        public dbBanHangOnlineEntities()
            : base("name=dbBanHangOnlineEntities")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<baiViet> baiViets { get; set; }
        public virtual DbSet<ctDonHang> ctDonHangs { get; set; }
        public virtual DbSet<donHang> donHangs { get; set; }
        public virtual DbSet<khachHang> khachHangs { get; set; }
        public virtual DbSet<loaiSP> loaiSPs { get; set; }
        public virtual DbSet<nhomTk> nhomTks { get; set; }
        public virtual DbSet<quanHuyen> quanHuyens { get; set; }
        public virtual DbSet<sanPham> sanPhams { get; set; }
        public virtual DbSet<sysdiagram> sysdiagrams { get; set; }
        public virtual DbSet<taiKhoanTV> taiKhoanTVs { get; set; }
    
        public virtual ObjectResult<baoCao_matHangDaBan_trongThang_Result> baoCao_matHangDaBan_trongThang(Nullable<int> month)
        {
            var monthParameter = month.HasValue ?
                new ObjectParameter("month", month) :
                new ObjectParameter("month", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<baoCao_matHangDaBan_trongThang_Result>("baoCao_matHangDaBan_trongThang", monthParameter);
        }
    
        public virtual int capNhat_DiemTichLuy()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("capNhat_DiemTichLuy");
        }
    
        public virtual int ChangePassword(string taiKhoan, string matKhau)
        {
            var taiKhoanParameter = taiKhoan != null ?
                new ObjectParameter("taiKhoan", taiKhoan) :
                new ObjectParameter("taiKhoan", typeof(string));
    
            var matKhauParameter = matKhau != null ?
                new ObjectParameter("matKhau", matKhau) :
                new ObjectParameter("matKhau", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("ChangePassword", taiKhoanParameter, matKhauParameter);
        }
    
        public virtual int createName(Nullable<bool> gender, ObjectParameter firstName, ObjectParameter lastName, ObjectParameter email)
        {
            var genderParameter = gender.HasValue ?
                new ObjectParameter("gender", gender) :
                new ObjectParameter("gender", typeof(bool));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("createName", genderParameter, firstName, lastName, email);
        }
    
        public virtual int createTempData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("createTempData");
        }
    
        public virtual ObjectResult<customersByPaging_Result> customersByPaging(Nullable<int> pageNumber)
        {
            var pageNumberParameter = pageNumber.HasValue ?
                new ObjectParameter("pageNumber", pageNumber) :
                new ObjectParameter("pageNumber", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<customersByPaging_Result>("customersByPaging", pageNumberParameter);
        }
    
        public virtual int dropTempData()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("dropTempData");
        }
    
        public virtual int InDonHang(string soDH)
        {
            var soDHParameter = soDH != null ?
                new ObjectParameter("soDH", soDH) :
                new ObjectParameter("soDH", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("InDonHang", soDHParameter);
        }
    
        public virtual int insertInto_KhachHang(Nullable<int> soLuong, Nullable<int> maxYear)
        {
            var soLuongParameter = soLuong.HasValue ?
                new ObjectParameter("soLuong", soLuong) :
                new ObjectParameter("soLuong", typeof(int));
    
            var maxYearParameter = maxYear.HasValue ?
                new ObjectParameter("maxYear", maxYear) :
                new ObjectParameter("maxYear", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertInto_KhachHang", soLuongParameter, maxYearParameter);
        }
    
        public virtual int insertInto_Order(Nullable<int> soLuong, Nullable<int> thang, Nullable<int> nam, Nullable<int> maNhom)
        {
            var soLuongParameter = soLuong.HasValue ?
                new ObjectParameter("soLuong", soLuong) :
                new ObjectParameter("soLuong", typeof(int));
    
            var thangParameter = thang.HasValue ?
                new ObjectParameter("thang", thang) :
                new ObjectParameter("thang", typeof(int));
    
            var namParameter = nam.HasValue ?
                new ObjectParameter("nam", nam) :
                new ObjectParameter("nam", typeof(int));
    
            var maNhomParameter = maNhom.HasValue ?
                new ObjectParameter("maNhom", maNhom) :
                new ObjectParameter("maNhom", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertInto_Order", soLuongParameter, thangParameter, namParameter, maNhomParameter);
        }
    
        public virtual int insertInto_TaiKhoanTV(Nullable<int> soLuong, Nullable<int> maxYear)
        {
            var soLuongParameter = soLuong.HasValue ?
                new ObjectParameter("soLuong", soLuong) :
                new ObjectParameter("soLuong", typeof(int));
    
            var maxYearParameter = maxYear.HasValue ?
                new ObjectParameter("maxYear", maxYear) :
                new ObjectParameter("maxYear", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("insertInto_TaiKhoanTV", soLuongParameter, maxYearParameter);
        }
    
        public virtual int NewCustomer(string maKH, string tenKH, Nullable<bool> gioiTinh, Nullable<System.DateTime> ngaySinh, string soDT, string email, string diaChi, Nullable<int> maQH, string ghiChu)
        {
            var maKHParameter = maKH != null ?
                new ObjectParameter("maKH", maKH) :
                new ObjectParameter("maKH", typeof(string));
    
            var tenKHParameter = tenKH != null ?
                new ObjectParameter("tenKH", tenKH) :
                new ObjectParameter("tenKH", typeof(string));
    
            var gioiTinhParameter = gioiTinh.HasValue ?
                new ObjectParameter("gioiTinh", gioiTinh) :
                new ObjectParameter("gioiTinh", typeof(bool));
    
            var ngaySinhParameter = ngaySinh.HasValue ?
                new ObjectParameter("ngaySinh", ngaySinh) :
                new ObjectParameter("ngaySinh", typeof(System.DateTime));
    
            var soDTParameter = soDT != null ?
                new ObjectParameter("soDT", soDT) :
                new ObjectParameter("soDT", typeof(string));
    
            var emailParameter = email != null ?
                new ObjectParameter("email", email) :
                new ObjectParameter("email", typeof(string));
    
            var diaChiParameter = diaChi != null ?
                new ObjectParameter("diaChi", diaChi) :
                new ObjectParameter("diaChi", typeof(string));
    
            var maQHParameter = maQH.HasValue ?
                new ObjectParameter("maQH", maQH) :
                new ObjectParameter("maQH", typeof(int));
    
            var ghiChuParameter = ghiChu != null ?
                new ObjectParameter("ghiChu", ghiChu) :
                new ObjectParameter("ghiChu", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("NewCustomer", maKHParameter, tenKHParameter, gioiTinhParameter, ngaySinhParameter, soDTParameter, emailParameter, diaChiParameter, maQHParameter, ghiChuParameter);
        }
    
        public virtual ObjectResult<reportByWeekDay_Result> reportByWeekDay(Nullable<int> n)
        {
            var nParameter = n.HasValue ?
                new ObjectParameter("n", n) :
                new ObjectParameter("n", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<reportByWeekDay_Result>("reportByWeekDay", nParameter);
        }
    
        public virtual int sp_alterdiagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_alterdiagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_creatediagram(string diagramname, Nullable<int> owner_id, Nullable<int> version, byte[] definition)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var versionParameter = version.HasValue ?
                new ObjectParameter("version", version) :
                new ObjectParameter("version", typeof(int));
    
            var definitionParameter = definition != null ?
                new ObjectParameter("definition", definition) :
                new ObjectParameter("definition", typeof(byte[]));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_creatediagram", diagramnameParameter, owner_idParameter, versionParameter, definitionParameter);
        }
    
        public virtual int sp_dropdiagram(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_dropdiagram", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagramdefinition_Result> sp_helpdiagramdefinition(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagramdefinition_Result>("sp_helpdiagramdefinition", diagramnameParameter, owner_idParameter);
        }
    
        public virtual ObjectResult<sp_helpdiagrams_Result> sp_helpdiagrams(string diagramname, Nullable<int> owner_id)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction<sp_helpdiagrams_Result>("sp_helpdiagrams", diagramnameParameter, owner_idParameter);
        }
    
        public virtual int sp_renamediagram(string diagramname, Nullable<int> owner_id, string new_diagramname)
        {
            var diagramnameParameter = diagramname != null ?
                new ObjectParameter("diagramname", diagramname) :
                new ObjectParameter("diagramname", typeof(string));
    
            var owner_idParameter = owner_id.HasValue ?
                new ObjectParameter("owner_id", owner_id) :
                new ObjectParameter("owner_id", typeof(int));
    
            var new_diagramnameParameter = new_diagramname != null ?
                new ObjectParameter("new_diagramname", new_diagramname) :
                new ObjectParameter("new_diagramname", typeof(string));
    
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_renamediagram", diagramnameParameter, owner_idParameter, new_diagramnameParameter);
        }
    
        public virtual int sp_upgraddiagrams()
        {
            return ((IObjectContextAdapter)this).ObjectContext.ExecuteFunction("sp_upgraddiagrams");
        }
    }
}
