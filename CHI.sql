create database [MSOL]

go
create table [CHUCVU](
	MaChucVu int identity(1,1) primary key ,
	TenChucVu nvarchar(30),
)

go
create table [NHANVIEN](
	MaNV int identity (1,1) primary key not null,
	TenNV nvarchar (50),
	NgaySinh datetime,
	GioiTinh nvarchar(15) default N'Nam',
	CMND varchar (15) ,
	SDT varchar (15),
	DiaChi nvarchar(100),
	Luong int,
	ChucVu int foreign key references CHUCVU(MaChucVu),
	TinhTrang nvarchar(20) default N'Đang làm',
	HinhAnh image
)

go
create table [TAIKHOAN](
	MaTaiKhoan int identity(1,1) primary key not null ,
	TenTaiKhoan varchar(30) ,
	MaNV int foreign key references NHANVIEN(MaNV),
	MatKhau varchar(30)
)


go 
create table [LOAILEPHUC]
(
	MaLoaiLP int identity (1,1) primary key not null,
	TenLoaiLP nvarchar(20)
)

go
create table [TINHTRANG]
(
	MaTinhTrang int identity(1,1) primary key not null,
	TenTinhTrang nvarchar(30)
)

go
create table [LEPHUC] (
	MaLePhuc int identity(1,1) primary  key not null,
	NgayNhap datetime,
	MoTa nvarchar (50),
	GiaNhap int,
	GiaChoThue int,
	Loai int foreign key references LOAILEPHUC(MaLoaiLP),
	TinhTrang int foreign key references TINHTRANG(MaTinhTrang)default 1,
	HinhAnh image
)

go
create table [LOAIGOICHUP]
(
	MaLoaiGC int identity (1,1) primary key,
	TenLoaiGC nvarchar(30),
)
go
create table [GOICHUP]
(
	MaGoiChup int identity(1,1) primary key,
	Loai int foreign key references LOAIGOICHUP(MaLoaiGC),
	DiaDiem nvarchar(100),
	GiaTien int,
	TinhTrang nvarchar(20) default N'Đang sử dụng',
)
select * from GOICHUP

-------------HÓA ĐƠN--------------

create table [HOADON]
(
	MaHD int identity(1,1) primary key not null,
	NgayHD datetime,
	TenKH nvarchar(50),
	CMND varchar(15),
	SDT varchar(15),
	DiaChi nvarchar(100),
	TienLePhuc int default 0,
	TienGoiChup int default 0,
	TienAlbum int default 0,
	TongTien int default 0,
	DatCoc int default 0,
	ThanhToan int default 0,
	ConLai int default 0,
	InHD nvarchar(20) default N'Chưa in'
)


go
create table [CTHD_LEPHUC]
(
	MaCTLP int identity(1,1) primary key,
	MaHD int foreign key references HOADON(MaHD),
	MaLePhuc int foreign key references LEPHUC(MaLePhuc),
	GiaChoThue int
)

go
create table [CTHD_GOICHUP]
(
	MaCTGC int identity(1,1) primary key,
	MaHD int foreign key references HOADON(MaHD),
	MaGoiChup int foreign key references GOICHUP(MaGoiChup),
	GiaTien int,
	MaNV int foreign key references NHANVIEN(MaNV),
	NgayChup datetime 
)

go
create table [ALBUM]
(
	MaAlbum int identity(1,1) primary key not null,
	MaCTGC int foreign key references CTHD_GOICHUP (MaCTGC),
	NgayNhap datetime,
	GiaAlbum int,
)

go
create table [CTALBUM]
(
	MaCTAlbum int identity(1,1) primary key not null,
	MaAlbum int foreign key references ALBUM(MaAlbum),
	HinhAnh image
)

go 
create table [QUYDINH](
	SoTienCoc int,
	SoLePhucToiDa int ,
	SoGoiChupToiDa int 
)

go
create procedure UpdateQUYDINH
@SoTienCoc int,
@SoLePhucToiDa int ,
@SoGoiChupToiDa int 
as
update QUYDINH
set SoTienCoc=@SoTienCoc, SoLePhucToiDa=@SoLePhucToiDa, SoGoiChupToiDa=@SoGoiChupToiDa


go
create procedure UpdateTAIKHOAN
@TenTaiKhoan varchar(30),
@MatKhauMoi varchar(30)
as
update TAIKHOAN
set MatKhau=@MatKhauMoi
where TenTaiKhoan=@TenTaiKhoan


go
create proc InsertTAIKHOAN
@TenTaiKhoan varchar (30),
@MaNV int,
@MatKhau varchar(30)
as
insert into TAIKHOAN(TenTaiKhoan, MaNV, MatKhau) 
values (@TenTaiKhoan, @MaNV, @MatKhau)

go
create proc USP_dangnhap
@TenTaiKhoan varchar(30), @MatKhau varchar(30)
as
begin
	select * from TAIKHOAN
	where TenTaiKhoan=@TenTaiKhoan and MatKhau=@MatKhau
end


---- proc LEPHUC---
go
create procedure UpdateLEPHUC
@MaLePhuc int,
@NgayNhap datetime,
@MoTa nvarchar (50),
@GiaNhap int,
@GiaChoThue int,
@Loai int,
@HinhAnh image
AS
update LEPHUC
set NgayNhap=@NgayNhap, MoTa=@MoTa, GiaNhap=@GiaNhap, GiaChoThue=@GiaChoThue, Loai=@Loai, HinhAnh=@HinhAnh
where MaLePhuc=@MaLePhuc


go
create procedure InsertLEPHUC 
@NgayNhap datetime,
@MoTa nvarchar (50),
@GiaNhap int,
@GiaChoThue int,
@Loai int,
@HinhAnh image
AS
insert into LEPHUC(NgayNhap, MoTa, GiaNhap, GiaChoThue, Loai, TinhTrang, HinhAnh)
values(@NgayNhap, @MoTa, @GiaNhap, @GiaChoThue, @Loai, 1, @HinhAnh)


---------------------------------------------------------------------
go
create proc InsertNHANVIEN
@TenNV nvarchar (50),
@NgaySinh datetime,
@GioiTinh nvarchar(15),
@CMND varchar (15) ,
@SDT varchar (15),
@DiaChi nvarchar(100),
@Luong int,
@ChucVu int,
@HinhAnh image
as 
insert into NHANVIEN(TenNV, NgaySinh, GioiTinh, CMND,SDT, DiaChi, Luong, ChucVu, HinhAnh)
values (@TenNV, @NgaySinh, @GioiTinh,  @CMND, @SDT, @DiaChi, @Luong, @ChucVu, @HinhAnh)




go
create proc UpdateNHANVIEN
@MaNV int,
@TenNV nvarchar (50),
@NgaySinh datetime,
@GioiTinh nvarchar(15),
@CMND varchar (15) ,
@SDT varchar (15),
@DiaChi nvarchar(100),
@Luong int,
@ChucVu int,
@HinhAnh image
as 
update NHANVIEN
set TenNV=@TenNV, NgaySinh=@NgaySinh, GioiTinh=@GioiTinh, CMND=@CMND, SDT=@SDT, DiaChi=@DiaChi, Luong=@Luong, ChucVu=@ChucVu, HinhAnh=@HinhAnh 
where MaNV=@MaNV



go
create proc InsertHOADON
@NgayHD datetime,
@TenKH nvarchar(50),
@CMND varchar(15),
@SDT varchar(15),
@DiaChi nvarchar(100)
as
insert into HOADON(NgayHD, TenKH, CMND, SDT, DiaChi) 
values (@NgayHD, @TenKH, @CMND, @SDT, @DiaChi)

go
alter proc UpdateHOADON
@MaHD int,
@NgayHD datetime,
@TenKH nvarchar(50),
@CMND varchar(15),
@SDT varchar(15),
@DiaChi nvarchar(100)
as
update HOADON
set NgayHD=@NgayHD, TenKH=@TenKH, CMND=@CMND, SDT=@SDT, DiaChi=@DiaChi
where MaHD=@MaHD



go
create proc InsertCTHDGoichup
@MaHD int,
@MaGoiChup int,
@GiaTien int,
@MaNV int,
@NgayChup datetime 
as
insert into CTHD_GOICHUP(MaHD, MaGoiChup, GiaTien, MaNV, NgayChup)
values (@MaHD, @MaGoiChup, @GiaTien, @MaNV, @NgayChup)



go
create proc UpdateCTHDGoiChup
@MaCTGC int,
@MaNV int,
@NgayChup datetime
as
update CTHD_GOICHUP
set MaNV=@MaNV, NgayChup=@NgayChup
where MaCTGC=@MaCTGC


go
create proc InsertALBUM
@MaCTGC int,
@NgayNhap datetime,
@GiaAlbum int
as
insert into ALBUM(MaCTGC, NgayNhap, GiaAlbum) 
values (@MaCTGC, @NgayNhap, @GiaAlbum)

go
create proc UpdateALBUM
@MaAlbum int,
@MaCTGC int,
@NgayNhap datetime,
@GiaAlbum int
as
update ALBUM
set MaCTGC=@MaCTGC, NgayNhap=@NgayNhap, GiaAlbum=@GiaAlbum
where MaAlbum=@MaAlbum


go
create proc InsertCTALBUM
@MaAlbum int,
@HinhAnh image
as
insert into CTALBUM(MaAlbum, HinhAnh)
values (@MaAlbum, @HinhAnh)

go
create proc THONGKEDOANHTHU
@BatDau datetime,
@KetThuc datetime
as 
	begin
		select * from HOADON
		where NgayHD>=@BatDau and NgayHD<= @KetThuc
	end







insert into CHUCVU(TenChucVu) values (N'Quản lý')
insert into CHUCVU(TenChucVu) values (N'Tiếp tân')
insert into CHUCVU(TenChucVu) values (N'Thợ chụp ảnh')
insert into CHUCVU(TenChucVu) values (N'Hậu kỳ')
insert into CHUCVU(TenChucVu) values (N'Bảo vệ')


insert into NHANVIEN(TenNV, NgaySinh, GioiTinh, CMND, SDT, DiaChi, Luong, ChucVu, HinhAnh)
select N'Trương Thị Bích Chi', GETDATE(), N'Nữ', '15520062', '0971xxxxxx', 'TPHCM', 10000000, 1, BulkColumn
from openrowset (Bulk 'E:\MI RI KI\linh tinh\1.jpg', Single_Blob) as image

insert into NHANVIEN(TenNV, NgaySinh, GioiTinh, CMND, SDT, DiaChi, Luong, ChucVu, HinhAnh)
select N'Trương Duy Khánh', GETDATE(), N'Nam', '15520068', '0971xxxxxx', 'TPHCM', 10000000, 4, BulkColumn
from openrowset (Bulk 'E:\MI RI KI\linh tinh\2.jpg', Single_Blob) as image

insert into NHANVIEN(TenNV, NgaySinh, GioiTinh, CMND, SDT, DiaChi, Luong, ChucVu, HinhAnh)
select N'Trương Thị Ý Nhi', GETDATE(), N'Nữ', '15520062', '0971xxxxxx', 'TPHCM', 10000000, 2, BulkColumn
from openrowset (Bulk 'E:\MI RI KI\linh tinh\nhi.jpg', Single_Blob) as image

insert into NHANVIEN(TenNV, NgaySinh, GioiTinh, CMND, SDT, DiaChi, Luong, ChucVu, HinhAnh)
select N'Mẹ', GETDATE(), N'Nữ', '15520062', '0971xxxxxx', 'TPHCM', 10000000, 3, BulkColumn
from openrowset (Bulk 'E:\MI RI KI\linh tinh\nhi.jpg', Single_Blob) as image


go
insert into TAIKHOAN(TenTaiKhoan, MaNV, MatKhau) values ('miriki', 1, 'miriki')
insert into TAIKHOAN(TenTaiKhoan, MaNV, MatKhau) values ('khanh', 3, 'khanh')
insert into TAIKHOAN(TenTaiKhoan, MaNV, MatKhau) values ('nhi', 2, 'nhi')



go
insert into LOAILEPHUC(TenLoaiLP) values(N'váy cưới')
insert into LOAILEPHUC(TenLoaiLP) values(N'vest chú rể')


go
insert into TINHTRANG(TenTinhTrang) values (N'Sẵn có')
insert into TINHTRANG(TenTinhTrang) values (N'Đã thuê')
insert into TINHTRANG(TenTinhTrang) values (N'Hết sự dụng')
go
insert into LOAILEPHUC(TenLoaiLP) values(N'váy cưới')
insert into LOAILEPHUC(TenLoaiLP) values(N'vest chú rể')




insert into LOAIGOICHUP(TenLoaiGC) values (N'Ngoại cảnh')
insert into LOAIGOICHUP(TenLoaiGC) values (N'Phim trường')


insert into GOICHUP(Loai, DiaDiem, GiaTien) values (1, N'Biển Hồ Cốc Vũng Tàu', 6660000 )
insert into GOICHUP(Loai, DiaDiem, GiaTien) values (1, N'Núi Bửu Long', 6200000 )
insert into GOICHUP(Loai, DiaDiem, GiaTien) values (2, N'Phim Trường Lamour', 5600000 )
insert into GOICHUP(Loai, DiaDiem, GiaTien) values (2, N' Green House', 4500000 )




insert into ALBUM(MaCTGC, NgayNhap, GiaAlbum) values (2, GETDATE(), 2000000)
insert into ALBUM(MaCTGC, NgayNhap, GiaAlbum) values (9, GETDATE(), 9000000)
insert into ALBUM(MaCTGC, NgayNhap, GiaAlbum) values (11, GETDATE(), 11000000)
insert into ALBUM(MaCTGC, NgayNhap, GiaAlbum) values (12, GETDATE(), 12000000)
insert into ALBUM(MaCTGC, NgayNhap, GiaAlbum) values (13, GETDATE(), 13000000)
insert into ALBUM(MaCTGC, NgayNhap, GiaAlbum) values (14, GETDATE(), 14000000)



select ctgc.*, gc.DiaDiem, nv.TenNV, hd.TenKH, hd.SDT
from CTHD_GOICHUP ctgc, HOADON hd, GOICHUP gc, NHANVIEN nv
where ctgc.MaHD=hd.MaHD and ctgc.MaGoiChup=gc.MaGoiChup and ctgc.MaNV=nv.MaNV 
select * from HOADON
select * from CTHD_GOICHUP
select * from CTHD_LEPHUC
update HOADON set DatCoc = TongTien/2 where MaHD=1
select * from TAIKHOAN
select * from NHANVIEN
update NHANVIEN set SDT=12345
select * from HOADON
select * from ALBUM
select* from CHUCVU

select al.*, gc.DiaDiem
from ALBUM al, HOADON hd, CTHD_GOICHUP ctgc, GOICHUP gc
where al.MaCTGC= ctgc.MaCTGC and ctgc.MaHD=hd.MaHD and ctgc.MaGoiChup=gc.MaGoiChup and hd.MaHD=1

select al.*, hd.MaHD, hd.TenKH, gc.DiaDiem, ctgc.* from ALBUM al, HOADON hd, CTHD_GOICHUP ctgc, GOICHUP gc where al.MaCTGC= ctgc.MaCTGC and ctgc.MaHD=hd.MaHD and ctgc.MaGoiChup=gc.MaGoiChup and hd.MaHD=1
update HOADON set InHD=N'Chưa in' where MaHD=2
select * from CTHD_LEPHUC where MaHD=3
select * from CTHD_GOICHUP where MaHD=3
select al.*, hd.MaHD, hd.TenKH, gc.DiaDiem, ctgc.* from ALBUM al, HOADON hd, CTHD_GOICHUP ctgc, GOICHUP gc where al.MaCTGC= ctgc.MaCTGC and ctgc.MaHD=hd.MaHD and ctgc.MaGoiChup=gc.MaGoiChup and hd.MaHD=3
update HOADON set TienLePhuc= 500000, TienGoiCHup =16600000 , TienAlbum =22000000 where MaHD=3

select * from NHANVIEN where GioiTinh=N'Nữ'
update NHANVIEN set GioiTinh=N'Nữ' where GioiTinh='Nu'
select ctgc.*, gc.DiaDiem, nv.TenNV, hd.TenKH, hd.SDT from CTHD_GOICHUP ctgc, HOADON hd, GOICHUP gc, NHANVIEN nv where ctgc.MaHD=hd.MaHD and ctgc.MaGoiChup=gc.MaGoiChup and ctgc.MaNV=nv.MaNV order by NgayChup asc, MaCTGC asc
select NHANVIEN.*, ChucVu.TenChucVu from NHANVIEN, CHUCVU where NHANVIEN.ChucVu=CHUCVU.MaChucVu and ( TenNV like N'%ảnh%' or CHUCVU.TenChucVu like N'%ảnh%' or DiaChi like N'%tphcm%' or SDT like  N'%tphcm%' or GioiTinh like N'%ảnh%' or TinhTrang like N'%ảnh%' or MaNV=1 or CMND like N'%ảnh%' or Luong=500000 )

select * from GOICHUP
select ALBUM.*, HOADON.MaHD, HOADON.TenKH, GOICHUP.DiaDiem, CTHD_GOICHUP.* from ALBUM, HOADON, GOICHUP, CTHD_GOICHUP where ALBUM.MaCTGC=CTHD_GOICHUP.MaCTGC and CTHD_GOICHUP.MaGoiChup=GOICHUP.MaGoiChup and CTHD_GOICHUP.MaHD=HOADON.MaHD

update HOADON set TenKH=N'Chi' where MaHD=5
update HOADON set SDT='123' where MaHD=5





