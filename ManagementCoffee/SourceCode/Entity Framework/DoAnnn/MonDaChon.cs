//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace DoAnnn
{
    using System;
    using System.Collections.Generic;
    
    public partial class MonDaChon
    {
        public string MaHD { get; set; }
        public string LoaiHD { get; set; }
        public string MaMon { get; set; }
        public string MaNV { get; set; }
        public string MaKh { get; set; }
        public string TenNV { get; set; }
        public string TenKH { get; set; }
        public string TenMon { get; set; }
        public string Ngay { get; set; }
        public string GiaMon { get; set; }
        public string SoLuong { get; set; }
    
        public virtual HoaDon HoaDon { get; set; }
        public virtual KhachHang KhachHang { get; set; }
        public virtual ThucDon ThucDon { get; set; }
        public virtual NhanVien NhanVien { get; set; }
    }
}