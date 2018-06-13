using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSOL.DTO
{
    public class NhanVien
    {
        public int MaNV { get; set; }
        public string TenNV { get; set; }
        public DateTime NgaySinh { get; set; }
        public string GioiTinh { get; set; }
        public string CMND { get; set; }
        public string SDT { get; set; }
        public string DiaChi { get; set; }
        public int Luong { get; set; }
        public int ChucVu { get; set; }
        public string TinhTrang { get; set; }
        public byte[] HinhAnh { get; set; }
        public string TenChucVu { get; set; }

        public NhanVien(int maMV, string tenNV, DateTime ngaysinh, string gioitinh, string cmnd, string sdt, string diachi, int luong, int chucvu, string tinhtrang, byte[] hinhanh)
        {
            this.MaNV = maMV;
            this.TenNV = tenNV;
            this.NgaySinh = ngaysinh;
            this.GioiTinh = gioitinh;
            this.CMND = cmnd;
            this.SDT = sdt;
            this.DiaChi = diachi;
            this.Luong = luong;
            this.TinhTrang = tinhtrang;
            this.ChucVu = chucvu;
            this.HinhAnh = hinhanh;
        }

        public NhanVien(DataRow row)
        {
            this.MaNV = (int)row["MaNV"];
            this.TenNV = row["TenNV"].ToString();
            this.NgaySinh = (DateTime)row["NgaySinh"];
            this.GioiTinh = row["GioiTinh"].ToString();
            this.CMND = row["CMND"].ToString();
            this.SDT = row["SDT"].ToString();
            this.DiaChi = row["DiaChi"].ToString();
            this.Luong = (int)row["Luong"];
            this.ChucVu = (int)row["ChucVu"];
            this.TinhTrang = row["TinhTrang"].ToString();
            this.HinhAnh = (byte[])row["HinhAnh"];
            this.TenChucVu = row["TenChucVu"].ToString();
        }
    }
}

