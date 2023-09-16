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
using DTO;
using BUS;

namespace Phan_Mem_Quan_Ly_Khach_San
{
    public partial class FrmDangKyPhong : Form
    {
        public FrmDangKyPhong()
        {
            InitializeComponent();
        }
        static string s = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLKHACHSAN;Integrated Security=True";
        SqlConnection KetNoi = new SqlConnection(s);
        private void Reset()
        {
            txtMaDK.Clear();                
            txtSoLuong.Clear();
            txtTrangThai.Clear();
        }
        private void HienThiDSMaKHLenCombobox()
        {
            List<KhachHangDTO> lstKhachHang = KhachHangBUS.LayDSKhachHang();
            cmbKhachHang.DataSource = lstKhachHang;
            cmbKhachHang.DisplayMember = "SMaKH";
            cmbKhachHang.ValueMember = "SMaKH";
        }
        private void HienThiTinhTrangPhongLenCombobox()
        {
            List<PhongDTO> lstPhong = PhongBUS.LayDSPhong();
            cmbSoPhong.DataSource = lstPhong;
            cmbSoPhong.DisplayMember = "SSoPhong";
            cmbSoPhong.ValueMember = "SSoPhong";
        }

        private void HienThiDKPhongLenDataGrid()
        {
            List<DKPhongDTO> lstDKPhong = DKPhongBUS.LayDSDKPhong();
            dgvDKPhong.DataSource = lstDKPhong;
        }

        private void HienThiDKPhongLenDatagrid()
        {
            List<DKPhongDTO> lstDKPhong = DKPhongBUS.LayDSDKPhong();
            dgvDKPhong.DataSource = lstDKPhong;
            dgvDKPhong.Columns["SMADK"].HeaderText = "Mã Đăng Ký";
            dgvDKPhong.Columns["DTNgayDK1"].HeaderText = "Ngày Đăng Ký";
            dgvDKPhong.Columns["SMAKH"].HeaderText = "Mã Khách Hàng";
            dgvDKPhong.Columns["DTNgayDen1"].HeaderText = "Ngày Đến";
            dgvDKPhong.Columns["DTNgayDi1"].HeaderText = "Ngày Đi";
            dgvDKPhong.Columns["SSoPhong"].HeaderText = "Số Phòng";
            dgvDKPhong.Columns["ISoLuong"].HeaderText = "Số Lượng";           
            dgvDKPhong.Columns["SMADK"].Width = 120;
            dgvDKPhong.Columns["DTNgayDK1"].Width = 150;
            dgvDKPhong.Columns["SMAKH"].Width = 120;
            dgvDKPhong.Columns["DTNgayDen1"].Width = 150;
            dgvDKPhong.Columns["DTNgayDi1"].Width = 150;
            dgvDKPhong.Columns["SSoPhong"].Width = 120;
            dgvDKPhong.Columns["ISoLuong"].Width = 120;        

        }
       

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaDK.Text == "" || txtSoLuong.Text == ""||txtTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
               
                return;
            }
            if(txtTrangThai.Text == "Có Khách")
            {
                MessageBox.Show("Phòng này đã có người vui lòng chọn phòng khác.", "Thông Báo");
                return;
            }    
            // Kiểm tra mã phòng có độ dài chuỗi hợp lệ hay không
            if (txtMaDK.Text.Length > 5)
            {
                MessageBox.Show("Mã đăng ký tối đa 5 ký tự!");
                return;
            }
            // Kiểm tra mã phòng có bị trùng không
            if (DKPhongBUS.TimDKPhongTheoMa(txtMaDK.Text) != null)
            {
                MessageBox.Show("Mã đăng ký đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }

            // Gán dữ liệu vào kiểu PhongDTO
            DKPhongDTO dkp = new DKPhongDTO();
            dkp.SMADK = txtMaDK.Text;
            dkp.DTNgayDK1 = DateTime.Parse(DTNgayDK.Text);
            dkp.SMAKH = cmbKhachHang.SelectedValue.ToString();
            dkp.DTNgayDen1 = DateTime.Parse(DTNgayDen.Text);
            dkp.DTNgayDi1 = DateTime.Parse(DTNgayDi.Text);
            dkp.SSoPhong = cmbSoPhong.SelectedValue.ToString();
            dkp.ISoLuong = int.Parse(txtSoLuong.Text);
           
            

            // Thực hiện thêm
            if (DKPhongBUS.ThemDKPhong(dkp) == false)
            {
                MessageBox.Show("Không đặt phòng được.");
                return;
            }
            HienThiDKPhongLenDataGrid();
            MessageBox.Show("Đã đặt phòng thành công.");
            PhongDTO p = new PhongDTO();
            p.SSoPhong = cmbSoPhong.SelectedValue.ToString();
            if (PhongBUS.ThayDoiTrangThaiPhong(p) == false)
            {
                MessageBox.Show("Không thay đổi trạng thái được.");
                return;
            }
            Reset();
            MessageBox.Show("Tình trạng phòng đã thay đổi trạng thái.","Thông báo");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaDK.Text == "" || txtSoLuong.Text == "" || txtTrangThai.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }

            // Kiểm tra mã phòng có bị trùng không
            if (DKPhongBUS.TimDKPhongTheoMa(txtMaDK.Text) == null)
            {
                MessageBox.Show("Mã đăng ký đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            
            // Gán dữ liệu vào kiểu PhongDTO
            DKPhongDTO dkp = new DKPhongDTO();
            dkp.SMADK = txtMaDK.Text;
            dkp.DTNgayDK1 = DateTime.Parse(DTNgayDK.Text);
            dkp.SMAKH = cmbKhachHang.SelectedValue.ToString();
            dkp.DTNgayDen1 = DateTime.Parse(DTNgayDen.Text);
            dkp.DTNgayDi1 = DateTime.Parse(DTNgayDi.Text);
            dkp.SSoPhong = cmbSoPhong.SelectedValue.ToString();
            dkp.ISoLuong = int.Parse(txtSoLuong.Text);          


            // Thực hiện cập nhật
            if (DKPhongBUS.CapNhatDKPhong(dkp) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            Reset();
            HienThiDKPhongLenDatagrid();
            MessageBox.Show("Đã cập nhật thông tin đặt phòng thành công.");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra mã chức vụ có tồn tại không
            if (DKPhongBUS.TimDKPhongTheoMa(txtMaDK.Text) == null)
            {
                MessageBox.Show("Mã đăng ký không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu PhongDTO
            DKPhongDTO dkp = new DKPhongDTO();
            dkp.SMADK = txtMaDK.Text;

            // Thực hiện xóa 
            if (MessageBox.Show("Bạn chắc chắn muốn xóa đăng ký phòng không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (DKPhongBUS.XoaDKPhong(dkp) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                Reset();
                HienThiDKPhongLenDatagrid();
                MessageBox.Show("Đã xóa thành công.");
            }

        }

        private void FrmDangKyPhong_Load(object sender, EventArgs e)
        {
            HienThiTinhTrangPhongLenCombobox();
            HienThiDSMaKHLenCombobox();          
            HienThiDKPhongLenDatagrid();
  
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<DKPhongDTO> ds = DKPhongBUS.LayDSDKPhong();
            List<DKPhongDTO> kq = (from dkp in ds
                                 where dkp.SMADK.Contains(txtTimMaDK.Text)
                                 where dkp.SMAKH.Contains(txtTimMaKH.Text)
                                 select dkp).ToList();
            dgvDKPhong.DataSource = kq;

        }

        private void dgvDKPhong_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvDKPhong.SelectedRows[0];
            txtMaDK.Text = r.Cells["SMADK"].Value.ToString();
            DTNgayDK.Text = r.Cells["DTNgayDK1"].Value.ToString();
            cmbKhachHang.SelectedValue = r.Cells["SMAKH"].Value.ToString();
            DTNgayDen.Text = r.Cells["DTNgayDen1"].Value.ToString();
            DTNgayDi.Text = r.Cells["DTNgayDi1"].Value.ToString();
            cmbSoPhong.SelectedValue = r.Cells["SSoPhong"].Value.ToString();
            txtSoLuong.Text = r.Cells["ISoLuong"].Value.ToString();                  

        }

        private void btnThoat_Click_1(object sender, EventArgs e)
        {
                this.Close();
        }

        private void txtSoLuong_KeyPress(object sender, KeyPressEventArgs e)
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

        private void DTNgayDi_ValueChanged(object sender, EventArgs e)
        {
            if (DTNgayDi.Value < DTNgayDen.Value)
            {
                MessageBox.Show("Ngày đi phải lớn hơn ngày đến");
            DTNgayDi.Value = DTNgayDen.Value;
            
                return;
            }
            if (DTNgayDi.Value < DTNgayDK.Value)
            {
                MessageBox.Show("Ngày đi phải lớn hơn ngày đăng ký");
                DTNgayDi.Value = DTNgayDK.Value;

                return;
            }

        }

        private void cmbSoPhong_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTrangThai.DataBindings.Clear();
            string trangthai = @"select TinhTrang from Phong where SoPhong ='" + cmbSoPhong.Text + "'";
            SqlCommand sqlc = new SqlCommand(trangthai, KetNoi);
            SqlDataAdapter da = new SqlDataAdapter(trangthai, KetNoi);
            DataTable dat = new DataTable();
            da.Fill(dat);
            txtTrangThai.DataBindings.Add("text", dat, "TinhTrang");
            txtTrangThai.Refresh();
            dgvDKPhong.Refresh();
        }     
    }
}
