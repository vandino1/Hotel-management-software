--Tao DataBase--
Create DataBase QLKHACHSAN
go

use QLKHACHSAN
Go
--1 BẢNG CHỨC VỤ
Create Table ChucVu(
	MACV nvarchar(10) primary key,
	TENCV nvarchar(50) not null,
	SDT nvarchar(20),
)
go
--2 BẢNG NHÂN VIÊN
Create Table NhanVien(
	MANV nvarchar(10) primary key,
	HoNV nvarchar(15) not null,
	TenNV nvarchar(20) not null,
	GioiTinh nvarchar(3),
	Ngaysinh smalldatetime not null,
	CMND int unique,
	SDT nvarchar(20),
	DiaChi nvarchar(100),
	MACV nvarchar(10) not null foreign key(MACV) references ChucVu(MACV),	
)
go
--3 BẢNG KHÁCH HÀNG
CREATE Table KhachHang(
	MAKH nvarchar(10) primary key,
	HoKH nvarchar(30) not null,
	TenKH nvarchar(20) not null,
	GioiTinh nvarchar(3),
	NgaySinh smalldatetime not null,
	DiaChi nvarchar(200),
	SDT nvarchar(20),
	CMND int unique,
	QuocTich nvarchar(20) not null,
)
go
--4 BẢNG LOẠI PHÒNG
CREATE Table LoaiPhong(
	MaLoaiPhong nvarchar(10) primary key,
	TenLoaiPhong nvarchar(30) not null,
	DonGia int not null,
	DonViTinh nvarchar(10),
)
go
--5 BẢNG PHÒNG
CREATE Table Phong(
	SoPhong varchar(5) primary key,
	MaLoaiPhong nvarchar(10) not null foreign key(MaLoaiPhong) references LoaiPhong(MaLoaiPhong),
	TinhTrang nvarchar(20) not null,
)
go
--6 BẢNG DỊCH VỤ
CREATE Table DichVu(
	MADV nvarchar(20) primary key,
	TenDV nvarchar(30) not null,
	DonViTinh nvarchar(10),
	DonGia int not null,
	GhiChu nvarchar(20) not null,
)
go

--7 Bảng Thiết Bị
CREATE Table ThietBi(
	MATB nvarchar(15) primary key,
	TenTB nvarchar(30) not null,
	SoLuong int not null,
	DonViTinh nvarchar(10) not null,
	HangSanXuat nvarchar(20) not null,
	NamSX smalldatetime not null,
)
go
--8 BẢNG SỬ DỤNG DỊCH VỤ
CREATE Table SuDungDichVu(
	STT int primary key,
	MAKH nvarchar(10) not null foreign key(MAKH) references KhachHang(MAKH),
	NgaySuDung smalldatetime not null,
	SoPhong varchar(5) not null foreign key(SoPhong) references Phong(SoPhong),
	MADV nvarchar(20) not null foreign key(MADV) references DichVu(MADV),
	SoLuong int not null,
	ThanhTien int not null,
)
go
--9 BẢNG TRANG THIET BI PHONG SU DUNG
CREATE Table TrangTBPhong(
	MaTrangBi nvarchar(10) primary key,
	SoPhong varchar(5) not null foreign key(SoPhong) references Phong(SoPhong),
	MATB nvarchar(15) not null foreign key(MATB) references ThietBi(MATB), 
	SoLuong int not null,
	)
go

--10 BẢNG ĐĂNG KÝ PHÒNG
CREATE Table DangKyPhong (
	MADK nvarchar(10) primary key,
	NgayDK smalldatetime,
	MAKH nvarchar(10) not null foreign key(MAKH) references KhachHang(MAKH),
	NgayDen smalldatetime not null,
	NgayDi smalldatetime not null,
	SoPhong varchar(5) not null foreign key(SoPhong) references Phong(SoPhong),
	SoLuong int not null,
)
go
--11 BẢNG PHIẾU THANH TOÁN
CREATE Table PhieuThanhToan(
	MAHD nvarchar(10) primary key,
	MANV nvarchar(10) not null foreign key(MANV) references NhanVien(MANV),
	MAKH nvarchar(10) not null foreign key(MAKH) references KhachHang(MAKH),
	NgayThanhToan smalldatetime not null,
	SoPhong varchar(5) not null foreign key(SoPhong) references Phong(SoPhong),
	SoNgayTro int,
	TienPhong int not null,
	TongTien int not null,
)
go
--12 Bảng người dùng
CREATE TABLE nguoidung(
	ten nvarchar(30) not null primary key,
	matkhau varchar(50),
	quyen tinyint
)
GO
--Nhập Dữ Liệu:
-- Dữ liệu bảng chucvu
INSERT INTO ChucVu VALUES(N'LT',N'Lễ tân','0923100121');
INSERT INTO ChucVu VALUES(N'KT',N'Kế toán','0961864083');
INSERT INTO ChucVu VALUES(N'TQ',N'Thủ quỹ','0868523295');
INSERT INTO ChucVu VALUES(N'GDS',N'Giám đốc sảnh','0777487863');
INSERT INTO ChucVu VALUES(N'TTD',N'Trực tổng đài','0339749770');

-- Dữ liệu bảng nhanvien
INSERT INTO NhanVien VALUES(N'NV001',N'Nguyễn Văn',N'An',N'Nam','1985-04-19',058697488,'0923120111',N'127 Võ Văn Tần, Đà Nẵng','GDS');
INSERT INTO NhanVien VALUES(N'NV002',N'Lý Văn',N'Sang',N'Nam','1995-04-20',165489625,'0923111222',N'121 Phan Chu Trinh, Nha Trang, Khánh Hòa','LT');
INSERT INTO NhanVien VALUES(N'NV003',N'Cao Ngọc Lan',N'Anh',N'Nữ','1994-05-12',024163988,'0868274554',N'22 Hồ Tùng Mậu, Thống Nhất, Thị xã Pleiku, Gia Lai','TQ');
INSERT INTO NhanVien VALUES(N'NV004',N'Đỗ Trọng',N'Phát',N'Nam','1999-03-19',125411526,'0586295696',N'51 Trường Trinh, Tuy Hòa, Phú Yên','KT');
INSERT INTO NhanVien VALUES(N'NV005',N'Lê Thành',N'Nhân',N'Nam','1996-07-20',023698745,'0156894555',N'345 Lý Chiêu Hoàng, Bạch Mai, Hà Nội','TTD');
INSERT INTO NhanVien VALUES(N'NV006',N'Nguyễn Thanh',N'Tùng',N'Nữ','1997-02-9',958989236,'0923120111',N'123 Lý Thường Kiệt, Quận 2, TpHCM','TTD');

-- Dữ liệu bảng khách hàng
INSERT INTO KhachHang VALUES(N'KH001',N'Vũ Tuấn',N'Anh',N'Nam','1980-04-11',N'Bà Triệu','01235243234',123253454,N'Việt Nam');
INSERT INTO KhachHang VALUES(N'KH002',N'Cao Thị Ngọc',N'Linh',N'Nữ','1985-03-12',N'18 Thanh Bình','0984234567',012434832,N'Hàn Quốc');
INSERT INTO KhachHang VALUES(N'KH003',N'Nguyễn Thị Ngọc',N'Lan',N'Nữ','1990-01-10',N'19 Hai Bà Trưng','0987654356',123383294,N'Anh Quốc');
INSERT INTO KhachHang VALUES(N'KH004',N'Phạm Minh',N'Đức',N'Nam','1995-04-30',N'20 Phan Châu Trinh','0956243242',145573262,N'Việt Nam');
INSERT INTO KhachHang VALUES(N'KH005',N'Nguyễn Bá',N'Tòng',N'Nam','1996-07-20',N'23 Ung Văn Khiêm','0963243462',152015415,N'Tây Ban Nha');

-- Dữ liệu bảng loại phòng
INSERT INTO LoaiPhong VALUES(N'VP101',N'VIP ĐƠN',300000,N'Ngày');
INSERT INTO LoaiPhong VALUES(N'VP102',N'VIP ĐƠN',300000,N'Ngày');
INSERT INTO LoaiPhong VALUES(N'VP201',N'VIP ĐÔI',400000,N'Ngày');
INSERT INTO LoaiPhong VALUES(N'VP202',N'VIP ĐÔI',400000,N'Ngày');
INSERT INTO LoaiPhong VALUES(N'VP301',N'VIP ĐÔI CỠ LỚN',500000,N'Ngày');
INSERT INTO LoaiPhong VALUES(N'VP302',N'VIP ĐÔI CỠ LỚN',500000,N'Ngày');

-- Dữ liệu bảng phòng
INSERT INTO Phong VALUES(N'P001',N'VP101',N'Phòng trống');
INSERT INTO Phong VALUES(N'P002',N'VP102',N'Phòng trống');
INSERT INTO Phong VALUES(N'P003',N'VP201',N'Có Khách');
INSERT INTO Phong VALUES(N'P004',N'VP202',N'Có Khách');
INSERT INTO Phong VALUES(N'P005',N'VP301',N'Phòng Trống');
INSERT INTO Phong VALUES(N'P006',N'VP302',N'Phòng trống');


-- Dữ liệu bảng dịch vụ
INSERT INTO DichVu VALUES(N'DV001',N'Bia Hà Nội 330ml',N'Lon',15000,N'Còn Sản Phẩm');
INSERT INTO DichVu VALUES(N'DV002',N'Mì Xào Giòn',N'Đĩa',45000,N' Còn Sản Phẩm');
INSERT INTO DichVu VALUES(N'DV003',N'Hoa quả tươi',N'Đĩa',70000,N'Còn Sản Phẩm');
INSERT INTO DichVu VALUES(N'DV004',N'Mỳ Cay Hàn Quốc',N'Đĩa',50000,N'Còn Sản Phẩm');
INSERT INTO DichVu VALUES(N'DV005',N'Thịt Hun Khói ',N'Đĩa',300000,N'Còn Sản Phẩm');
INSERT INTO DichVu VALUES(N'DV006',N'Rượu Vodka 330ml',N'Lon',100000,N'Còn Sản Phẩm');
INSERT INTO DichVu VALUES(N'DV007',N' Xúc Xích Đức','Đĩa',50000,N'Còn Sản Phẩm');

-- Dữ liệu bảng thiết bị
INSERT INTO ThietBi VALUES(N'TB001',N'Tủ Lạnh',1,N'Cái',N'SHARP','2020');
INSERT INTO ThietBi VALUES(N'TB002',N'Máy Giặt',1,N'Cái',N'SHARP','2021');
INSERT INTO ThietBi VALUES(N'TB003',N'Quạt Máy',3,N'Cái',N'PANASONIC','2019');
INSERT INTO ThietBi VALUES(N'TB004',N'Giường Ngủ',2,N'Cái',N'ALALA','2020');
INSERT INTO ThietBi VALUES(N'TB005',N'Ti Vi',1,N'Cái',N'LG','2020');

-- Dữ liệu bảng sử dụng dịch vụ
INSERT INTO SuDungDichVu VALUES(1,N'KH001','2022-01-1',N'P001',N'DV001',2,30000);
INSERT INTO SuDungDichVu VALUES(2,N'KH002','2022-01-10',N'P004',N'DV003',1,70000);
INSERT INTO SuDungDichVu VALUES(3,N'KH003','2022-01-20',N'P003',N'DV002',2,90000);
INSERT INTO SuDungDichVu VALUES(4,N'KH004','2022-02-15',N'P002',N'DV005',1,300000);
INSERT INTO SuDungDichVu VALUES(5,N'KH005','2022-03-2',N'P005',N'DV004',2,100000);

-- Dữ liệu bảng trang tb phòng
INSERT INTO TrangTBPhong VALUES(N'TBP001',N'P001',N'TB001',1);
INSERT INTO TrangTBPhong VALUES(N'TBP002',N'P003',N'TB005',2);
INSERT INTO TrangTBPhong VALUES(N'TBP003',N'P002',N'TB004',1);
INSERT INTO TrangTBPhong VALUES(N'TBP004',N'P004',N'TB002',1);
INSERT INTO TrangTBPhong VALUES(N'TBP005',N'P005',N'TB003',2);

-- Dữ liệu bảng đăng ký phòng
INSERT INTO DangKyPhong VALUES(N'DK001','2021-03-20',N'KH001','2021-03-22','2021-03-26',N'P001',3);
INSERT INTO DangKyPhong VALUES(N'DK002','2021-04-15',N'KH003','2021-04-16','2021-04-20',N'P002',2);
INSERT INTO DangKyPhong VALUES(N'DK003','2021-06-20',N'KH004','2021-06-21','2021-06-22',N'P006',1);


-- Dữ liệu bảng phiếu thanh toán
INSERT INTO PhieuThanhToan VALUES(N'HD001',N'NV001',N'KH003',N'2021-03-25','P002',5,1500000,1700000);
INSERT INTO PhieuThanhToan VALUES(N'HD002',N'NV003',N'KH001',N'2021-04-19','P001',5,1500000,1530000);
INSERT INTO PhieuThanhToan VALUES(N'HD003',N'NV004',N'KH004',N'2021-06-21','P006',2,1000000,1100000);
-- Dữ liệu bảng nguoidung
INSERT INTO nguoidung VALUES(N'quantri','e99a18c428cb38d5f260853678922e03',1);	/* Mật khẩu abc123 */
INSERT INTO nguoidung VALUES(N'nhanvien','a906449d5769fa7361d7ecc6aa3f6d28',2);	/* Mật khẩu 123abc */


SELECT * FROM ChucVu
SELECT * FROM NhanVien
SELECT * FROM KhachHang
SELECT * FROM LoaiPhong
SELECT * FROM Phong
SELECT * FROM DichVu
SELECT * FROM ThietBi
SELECT * FROM SuDungDichVu
SELECT * FROM TrangTBPhong
SELECT * FROM DangKyPhong
SELECT * FROM PhieuThanhToan
SELECT * FROM nguoidung



 






