using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DAO;

namespace Phan_Mem_Quan_Ly_Khach_San
{
    public partial class frmXuatBaoCao : Form
    {
        public frmXuatBaoCao()
        {
            InitializeComponent();
        }
        SqlConnection con;
        private void frmXuatBaoCao_Load(object sender, EventArgs e)
        {
            string sTruyVan = "select * from PhieuThanhToan";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            ReportPhieuThanhToan rpt = new ReportPhieuThanhToan();
            rpt.SetDataSource(dt);
            crystalReportViewer2.ReportSource = rpt;
        }

        private void tìmKiếmToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(txtTim.Text == "")
            {
                MessageBox.Show("Vui lòng nhập mã hóa đơn vào");
                return;
            }
            if(txtTim.Text.Length > 5)
            {
                MessageBox.Show("Mã hóa đơn tối đa 5 ký tự!", "Thông báo");
            }    
            string sTruyVan = "SELECT KhachHang.HoKH, KhachHang.TenKH, KhachHang.GioiTinh, KhachHang.DiaChi, KhachHang.SDT, KhachHang.CMND, KhachHang.QuocTich, NhanVien.HoNV, NhanVien.TenNV, NhanVien.SDT AS SDTNV, DichVu.TenDV, DichVu.DonViTinh, DichVu.DonGia, SuDungDichVu.NgaySuDung, SuDungDichVu.SoLuong, SuDungDichVu.ThanhTien, LoaiPhong.TenLoaiPhong, LoaiPhong.DonGia AS TienPhong, LoaiPhong.DonViTinh AS DVT, PhieuThanhToan.SoPhong, PhieuThanhToan.SoNgayTro, PhieuThanhToan.TongTien, PhieuThanhToan.NgayThanhToan FROM DichVu INNER JOIN SuDungDichVu ON DichVu.MADV = SuDungDichVu.MADV CROSS JOIN LoaiPhong CROSS JOIN PhieuThanhToan INNER JOIN NhanVien ON PhieuThanhToan.MANV = NhanVien.MANV INNER JOIN KhachHang ON PhieuThanhToan.MAKH = KhachHang.MAKH and PhieuThanhToan.MAHD = '" + txtTim.Text+"'";
            con = DataProvider.MoKetNoi();
            DataTable dt = DataProvider.TruyVanLayDuLieu(sTruyVan, con);
            Report_2 rpt2 = new Report_2();
            rpt2.SetDataSource(dt);
            crystalReportViewer2.ReportSource = rpt2;

        }
    }
}
