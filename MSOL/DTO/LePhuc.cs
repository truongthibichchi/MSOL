using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;

namespace MSOL.DTO
{
    public class LePhuc
    {
        public int MaLePhuc { get; set; }
        public DateTime NgayNhap { get; set; }
        public string MoTa { get; set; }
        public int GiaNhap { get; set; }
        public int GiaChoThue { get; set; }
        public int Loai { get; set; }
        public int TinhTrang { get; set; }
        public byte[] HinhAnh { get; set; }

        public LePhuc(int malp, DateTime ngaynhap, string mota, int gianhap, int giachothue, int loai, int tinhtrang, byte[] hinhanh)
        {
            this.MaLePhuc = malp;
            this.NgayNhap = ngaynhap;
            this.MoTa = mota;
            this.GiaNhap = gianhap;
            this.GiaChoThue = giachothue;
            this.Loai = loai;
            this.TinhTrang = tinhtrang;
            this.HinhAnh = hinhanh;
        }

        public LePhuc()
        {
        }

        public LePhuc(DataRow row)
        {
            this.MaLePhuc = (int)row["MaLePhuc"];
            this.NgayNhap = (DateTime)row["NgayNhap"];
            this.MoTa = row["MoTa"].ToString();
            this.GiaNhap = (int)row["GiaNhap"];
            this.GiaChoThue = (int)row["GiaChoThue"];
            this.Loai = (int)row["Loai"];
            this.TinhTrang = (int)row["TinhTrang"];
            this.HinhAnh = (byte[])row["HinhAnh"];
        }
    }
}
