using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSOL.DTO
{
    public class TaiKhoan
    {
        public int MaTaiKhoan { get; set; }
        public int MaNV { get; set; }
        public string TenTaiKhoan { get; set; }
        public string MatKhau { get; set; }
        //public string TenNV { get; set; }
        //public string TenChucVu { get; set; }


        public TaiKhoan(int mataikhoan, int manv, string tentaikhoan, string matkhau)
        {
            this.MaTaiKhoan = mataikhoan;
            this.MaNV = manv;
            this.TenTaiKhoan = tentaikhoan;
            this.MatKhau = matkhau;

        }

        public TaiKhoan(DataRow row)
        {
            this.MaTaiKhoan = (int)row["MaTaiKhoan"];
            this.MaNV = (int)row["MaNV"];
            this.TenTaiKhoan = row["TentaiKhoan"].ToString();
            this.MatKhau = row["MatKhau"].ToString();
            //this.TenNV = row["TenNV"].ToString();
            //this.TenChucVu = row["TenChucVu"].ToString();

        }
    }
}
