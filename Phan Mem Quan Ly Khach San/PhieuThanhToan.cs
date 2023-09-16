using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BUS;
using System.Data.SqlClient;

namespace Phan_Mem_Quan_Ly_Khach_San
{
    public partial class FrmPhieuThanhToan : Form
    {
        public FrmPhieuThanhToan()
        {
            InitializeComponent();
        }
        static string s = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLKHACHSAN;Integrated Security=True";
        SqlConnection KetNoi = new SqlConnection(s);
        private void HienThiPhieuThanhToanLenDataGrid()
        {
            List<PhieuThanhToanDTO> lstPhieuThanhToan = PhieuThanhToanBUS.LayDSPhieuThanhToan();
            dgvPhieuThanhToan.DataSource = lstPhieuThanhToan;
        }
        private void HienThiNhanVienLenCombobox()
        {
            List<NhanVienDTO> lstNhanVien = NhanVienBUS.LayDSNhanVien();
            cmbMaNV.DataSource = lstNhanVien;
            cmbMaNV.DisplayMember = "SMaNV";
            cmbMaNV.ValueMember = "SMaNV";
        }
        private void HienThiKhachHangLenCombobox()
        {
            List<KhachHangDTO> lstKhachHang = KhachHangBUS.LayDSKhachHang();
            cmbMaKH.DataSource = lstKhachHang;
            cmbMaKH.DisplayMember = "SMaKH";
            cmbMaKH.ValueMember = "SMaKH";
        }      
        private void FrmPhieuThanhToan_Load(object sender, EventArgs e)
        {
            HienThiNhanVienLenCombobox();
            HienThiKhachHangLenCombobox();         
            HienThiPhieuThanhToanLenDatagrid();
        }
        private void HienThiPhieuThanhToanLenDatagrid()
        {
            List<PhieuThanhToanDTO> lstPhieuThanhToan = PhieuThanhToanBUS.LayDSPhieuThanhToan();
            dgvPhieuThanhToan.DataSource = lstPhieuThanhToan;
            dgvPhieuThanhToan.Columns["SMAHD"].HeaderText = "Mã Hóa Đơn";
            dgvPhieuThanhToan.Columns["SMANV"].HeaderText = "Mã Nhân Viên";
            dgvPhieuThanhToan.Columns["SMAKH"].HeaderText = "Mã Khách Hàng";
            dgvPhieuThanhToan.Columns["DTNgayThanhToan1"].HeaderText = "Ngày Thanh Toán";
            dgvPhieuThanhToan.Columns["SSoPhong"].HeaderText = "Số Phòng";
            dgvPhieuThanhToan.Columns["ISoNgayTro"].HeaderText = "Số Ngày Trọ";
            dgvPhieuThanhToan.Columns["ITienPhong"].HeaderText = "Giá Phòng (VNĐ/Ngày)";
            dgvPhieuThanhToan.Columns["ITongTien"].HeaderText = "Tổng Tiền (VNĐ)";

            dgvPhieuThanhToan.Columns["SMAHD"].Width = 100;
            dgvPhieuThanhToan.Columns["SMANV"].Width = 100;
            dgvPhieuThanhToan.Columns["SMAKH"].Width = 100;
            dgvPhieuThanhToan.Columns["DTNgayThanhToan1"].Width = 120;
            dgvPhieuThanhToan.Columns["SSoPhong"].Width = 120;
            dgvPhieuThanhToan.Columns["ISoNgayTro"].Width = 120;
            dgvPhieuThanhToan.Columns["ITienPhong"].Width = 200;
            dgvPhieuThanhToan.Columns["ITongTien"].Width = 200;

        }
        private void Reset()
        {
            txtMaHD.Clear();
            txtSoNgayTro.Clear();
            txtTienPhong.Clear();
            txtTongTien.Clear();
            txtTienDV.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaHD.Text == ""||txtSoPhong.Text == ""|| txtSoNgayTro.Text == ""|| txtTienPhong.Text == ""|| txtTienDV.Text == ""|| txtTongTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã hóa đơn có độ dài chuỗi hợp lệ hay không
            if (txtMaHD.Text.Length > 5)
            {
                MessageBox.Show("Mã hóa đơn tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã hóa đơn có bị trùng không
            if (PhieuThanhToanBUS.TimPhieuThanhToanTheoMa(txtMaHD.Text) != null)
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu PhieuThanhToanDTO
            PhieuThanhToanDTO ptt = new PhieuThanhToanDTO();
            ptt.SMAHD = txtMaHD.Text;
            ptt.SMANV = cmbMaNV.SelectedValue.ToString();
            ptt.SMAKH = cmbMaKH.SelectedValue.ToString();
            ptt.DTNgayThanhToan1 = DateTime.Parse(DTNgayTT.Text);
            ptt.SSoPhong = txtSoPhong.Text;
            ptt.ISoNgayTro = int.Parse(txtSoNgayTro.Text);
            ptt.ITienPhong = int.Parse(txtTienPhong.Text);
            ptt.ITongTien = int.Parse(txtTongTien.Text);

            // Thực hiện thêm
            if (PhieuThanhToanBUS.ThemPhieuThanhToan(ptt) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            Reset();
            HienThiPhieuThanhToanLenDatagrid();
            MessageBox.Show("Đã thêm hóa đơn thành công.");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaHD.Text == ""|| txtSoPhong.Text == "" || txtSoNgayTro.Text == ""|| txtTienPhong.Text == ""|| txtTienDV.Text == ""|| txtTongTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }

            // Kiểm tra mã hóa đơn có bị trùng không
            if (PhieuThanhToanBUS.TimPhieuThanhToanTheoMa(txtMaHD.Text) == null)
            {
                MessageBox.Show("Mã hóa đơn đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu PhieuThanhToanDTO
            PhieuThanhToanDTO ptt = new PhieuThanhToanDTO();
            ptt.SMAHD = txtMaHD.Text;
            ptt.SMANV = cmbMaNV.SelectedValue.ToString();
            ptt.SMAKH = cmbMaKH.SelectedValue.ToString();
            ptt.DTNgayThanhToan1 = DateTime.Parse(DTNgayTT.Text);
            ptt.SSoPhong = txtSoPhong.Text;
            ptt.ISoNgayTro = int.Parse(txtSoNgayTro.Text);
            ptt.ITienPhong = int.Parse(txtTienPhong.Text);
            ptt.ITongTien = int.Parse(txtTongTien.Text);

            // Thực hiện thêm
            if (PhieuThanhToanBUS.CapNhatPhieuThanhToan(ptt) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            Reset();
            HienThiPhieuThanhToanLenDatagrid();
            MessageBox.Show("Đã cập nhật hóa đơn thành công.");
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã hóa đơn có bị trùng không
            if (PhieuThanhToanBUS.TimPhieuThanhToanTheoMa(txtMaHD.Text) == null)
            {
                MessageBox.Show("Mã hóa đơn không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu PhieuThanhToanDTO
            PhieuThanhToanDTO ptt = new PhieuThanhToanDTO();
            ptt.SMAHD = txtMaHD.Text;

            // Thực hiện xóa
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa phiếu thanh toán này không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (PhieuThanhToanBUS.XoaPhieuThanhToan(ptt) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                Reset();
                HienThiPhieuThanhToanLenDatagrid();
                MessageBox.Show("Đã xóa phiếu thanh toán thành công.");
            }

        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<PhieuThanhToanDTO> ds = PhieuThanhToanBUS.LayDSPhieuThanhToan();
            List<PhieuThanhToanDTO> kq = (from ptt in ds
                                   where ptt.SMAHD.Contains(txtTimMaHD.Text)
                                   where ptt.SMANV.Contains(txtTimMaNV.Text)
                                   select ptt).ToList();
            dgvPhieuThanhToan.DataSource = kq;

        }

        private void dgvPhieuThanhToan_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvPhieuThanhToan.SelectedRows[0];
            txtMaHD.Text = r.Cells["SMAHD"].Value.ToString();
            cmbMaNV.SelectedValue = r.Cells["SMANV"].Value.ToString();
            cmbMaKH.SelectedValue = r.Cells["SMAKH"].Value.ToString();
            DTNgayTT.Text = r.Cells["DTNgayThanhToan1"].Value.ToString();
            txtSoPhong.Text = r.Cells["SSoPhong"].Value.ToString();
            txtSoNgayTro.Text = r.Cells["ISoNgayTro"].Value.ToString();
            txtTienPhong.Text = r.Cells["ITienPhong"].Value.ToString();
            txtTongTien.Text = r.Cells["ITongTien"].Value.ToString();
        }
        private void btnThoat_Click_1(object sender, EventArgs e)
        {       
                this.Close();
        }

        private void txtSoNgayTro_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Xin vui lòng nhập số vào !");
            }
        }
       

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (txtSoNgayTro.Text == "" )
            {
                MessageBox.Show("Vui lòng nhập số ngày trọ vào!");
                return;
            }
            
            if (txtTienDV.Text =="")
            {
                
                txtTienDV.Text = "0";
            }
            string getGiaDV = txtTienDV.Text.ToString();
            int tienphong = (Convert.ToInt32(txtTienPhong.Text));                  
            int tiendv = Convert.ToInt32(getGiaDV);
            int kq = tienphong * Convert.ToInt32((txtSoNgayTro.Text)) + tiendv;
            txtTongTien.Text = (kq).ToString();
        }      

        private void cmbMaKH_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtSoPhong.DataBindings.Clear();
            string layphong = @"select SoPhong from DangKyPhong where MAKH ='" + cmbMaKH.Text + "'";
            SqlCommand sqlc = new SqlCommand(layphong, KetNoi);
            SqlDataAdapter da = new SqlDataAdapter(layphong, KetNoi);
            DataTable dat = new DataTable();
            da.Fill(dat);
            txtSoPhong.DataBindings.Add("text", dat, "SoPhong");
            txtSoPhong.Refresh();
            dgvPhieuThanhToan.Refresh();
        }

        private void txtSoPhong_TextChanged(object sender, EventArgs e)
        {
            txtTienPhong.Clear();
            txtTienDV.Clear();
            txtTienDV.DataBindings.Clear();
            string laygiaDV = @"select ThanhTien from SuDungDichVu where SoPhong ='" + txtSoPhong.Text + "'";
            SqlCommand sqlc = new SqlCommand(laygiaDV, KetNoi);
            SqlDataAdapter da = new SqlDataAdapter(laygiaDV, KetNoi);
            DataTable dat = new DataTable();
            da.Fill(dat);
            txtTienDV.DataBindings.Add("text", dat, "ThanhTien");

            txtTienPhong.DataBindings.Clear();
            string laygiaPH = @"select DonGia from LoaiPhong lp, Phong p where p.SoPhong ='" + txtSoPhong.Text + "' and p.MaLoaiPhong = lp.MaLoaiPhong";
            SqlCommand sqlcP = new SqlCommand(laygiaPH, KetNoi);
            SqlDataAdapter daP = new SqlDataAdapter(laygiaPH, KetNoi);
            DataTable datP = new DataTable();
            daP.Fill(datP);
            txtTienPhong.DataBindings.Add("text", datP, "DonGia");

            txtTienDV.Refresh();
            txtTienPhong.Refresh();
            dgvPhieuThanhToan.Refresh();
        }
    }
}
