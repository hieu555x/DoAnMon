//------------------------------------------------------------------------------
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
    using System.Collections.Generic;
    
    public partial class sanPham
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public sanPham()
        {
            this.ctDonHangs = new HashSet<ctDonHang>();
        }
    
        public string maSP { get; set; }
        public string tenSP { get; set; }
        public string hinhDD { get; set; }
        public string ndTomTat { get; set; }
        public Nullable<System.DateTime> ngayDang { get; set; }
        public string noiDung { get; set; }
        public string taiKhoan { get; set; }
        public Nullable<bool> daDuyet { get; set; }
        public Nullable<int> giaBan { get; set; }
        public Nullable<int> giamGia { get; set; }
        public Nullable<int> maLoai { get; set; }
        public string nhaSanXuat { get; set; }
        public string dvt { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<ctDonHang> ctDonHangs { get; set; }
        public virtual loaiSP loaiSP { get; set; }
        public virtual taiKhoanTV taiKhoanTV { get; set; }
    }
}
