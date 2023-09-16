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
    public partial class TFrmtrangTBPhong : Form
    {
        public TFrmtrangTBPhong()
        {
            InitializeComponent();
        }
        static string s = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLKHACHSAN;Integrated Security=True";
        SqlConnection KetNoi = new SqlConnection(s);
        private void Reset()
        {
            txtMaTBPhong.Clear();           
            txtSoLuong.Clear();
            txtTenTB.Clear();
        }
        private void HienThiTrangBiPhongLenDataGrid()
        {
            List<ThietBiDTO> lstThietBi = ThietBiBUS.LayDSThietBi();
            dgvTrangTBPhong.DataSource = lstThietBi;
        }
        private void HienThiSoPhongLenCombobox()
        {
            List<PhongDTO> lstPhong = PhongBUS.LayDSPhong();
            cmbsophong.DataSource = lstPhong;
            cmbsophong.DisplayMember = "SSoPhong";
            cmbsophong.ValueMember = "SSoPhong";
        }
        private void HienThiMaTBLenCombobox()
        {
            List<ThietBiDTO> lstThietBi = ThietBiBUS.LayDSThietBi();
            cmbMaThietBi.DataSource = lstThietBi;
            cmbMaThietBi.DisplayMember = "SMATB";
            cmbMaThietBi.ValueMember = "SMATB";
        }
        private void HienThiDSTrangBiPhongLenDatagrid()
        {
            List<TrangBiPhongDTO> lstTrangBiPhong = TrangBiPhongBUS.LayDSTrangBiPhong();
            dgvTrangTBPhong.DataSource = lstTrangBiPhong;
            dgvTrangTBPhong.Columns["SMaTrangBi"].HeaderText = "Mã Trang Bị";
            dgvTrangTBPhong.Columns["SSoPhong"].HeaderText = "Số Phòng";
            dgvTrangTBPhong.Columns["SMATB"].HeaderText = "Mã Thiết Bị";
            dgvTrangTBPhong.Columns["ISoLuong"].HeaderText = "Số Lượng";
            dgvTrangTBPhong.Columns["SMaTrangBi"].Width = 180;
            dgvTrangTBPhong.Columns["SSoPhong"].Width = 180;
            dgvTrangTBPhong.Columns["SMATB"].Width = 180;
            dgvTrangTBPhong.Columns["ISoLuong"].Width = 150;
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaTBPhong.Text == ""|| txtSoLuong.Text == ""|| txtTenTB.Text =="")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra mã TB Phòng có độ dài chuỗi hợp lệ hay không
            if (txtMaTBPhong.Text.Length > 6)
            {
                MessageBox.Show("Mã trang thiết bị phòng tối đa 6 ký tự!");
                return;
            }
            // Kiểm tra mã TB Phòng có bị trùng không
            if (TrangBiPhongBUS.TimTrangBiPhongTheoMa(txtMaTBPhong.Text) != null)
            {
                MessageBox.Show("Mã thiết bị đã tồn tại! Vui lòng chọn mã khác.");
                return;
            }
            // Gán dữ liệu vào kiểu MaTBPhongDTO
            TrangBiPhongDTO tbp = new TrangBiPhongDTO();
            tbp.SMaTrangBi = txtMaTBPhong.Text;
            tbp.SSoPhong = cmbsophong.SelectedValue.ToString();
            tbp.SMATB = cmbMaThietBi.SelectedValue.ToString();
            tbp.ISoLuong = int.Parse(txtSoLuong.Text);
            // Thực hiện thêm
            if (TrangBiPhongBUS.ThemTrangBiPhong(tbp) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            Reset();
            HienThiDSTrangBiPhongLenDatagrid();
            MessageBox.Show("Đã thêm trang thiết bị phòng thành công.");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaTBPhong.Text == "" || txtSoLuong.Text == "" || txtTenTB.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }

            // Kiểm tra mã TB Phòng có tồn tại không
            if (TrangBiPhongBUS.TimTrangBiPhongTheoMa(txtMaTBPhong.Text) == null)
            {
                MessageBox.Show("Mã trang bị phòng không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu TrangBiPhongDTO
            TrangBiPhongDTO tbp = new TrangBiPhongDTO();
            tbp.SMaTrangBi = txtMaTBPhong.Text;
            tbp.SSoPhong = cmbsophong.SelectedValue.ToString();
            tbp.SMATB = cmbMaThietBi.SelectedValue.ToString();
            tbp.ISoLuong = int.Parse(txtSoLuong.Text);
            // Thực hiện thêm
            if (TrangBiPhongBUS.CapNhatTrangBiPhong(tbp) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            Reset();
            HienThiDSTrangBiPhongLenDatagrid();
            MessageBox.Show("Đã cập nhật trang thiết bị phòng thành công.");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtMaTBPhong.Text == "" ||txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }

            // Kiểm tra mã TB Phòng có tồn tại không
            if (TrangBiPhongBUS.TimTrangBiPhongTheoMa(txtMaTBPhong.Text) == null)
            {
                MessageBox.Show("Mã trang thiết bị phòng không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu TrangBiPhongDTO
            TrangBiPhongDTO tbp = new TrangBiPhongDTO();
            tbp.SMaTrangBi = txtMaTBPhong.Text;

            // Thực hiện xóa
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa trang thiết bị phòng không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (TrangBiPhongBUS.XoaTrangBiPhong(tbp) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                Reset();
                HienThiDSTrangBiPhongLenDatagrid();
                MessageBox.Show("Đã xóa trang thiết bị phòng thành công.");
            }
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<TrangBiPhongDTO> ds = TrangBiPhongBUS.LayDSTrangBiPhong();
            List<TrangBiPhongDTO> kq = (from tbp in ds
                                   where tbp.SMaTrangBi.Contains(txtTimMATBPhong.Text)
                                   where tbp.SSoPhong.Contains(txtTimSoPhong.Text)
                                   select tbp).ToList();
            dgvTrangTBPhong.DataSource = kq;


        }

        private void FrmTrangTBPhong_Load(object sender, EventArgs e)
        {
            HienThiMaTBLenCombobox();
            HienThiDSTrangBiPhongLenDatagrid();
            HienThiSoPhongLenCombobox();
        }

        private void dgvTrangTBPhong_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvTrangTBPhong.SelectedRows[0];
            txtMaTBPhong.Text = r.Cells["SMaTrangBi"].Value.ToString();
            cmbsophong.SelectedValue = r.Cells["SSoPhong"].Value.ToString();
            cmbMaThietBi.SelectedValue = r.Cells["SMATB"].Value.ToString();
            txtSoLuong.Text = r.Cells["ISoLuong"].Value.ToString();
        }

        private void btnThoat_Click(object sender, EventArgs e)
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

        private void cmbMaThietBi_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenTB.DataBindings.Clear();
            string tentb = @"select TenTB from ThietBi where MATB ='" + cmbMaThietBi.Text + "'";
            SqlCommand sqlc = new SqlCommand(tentb, KetNoi);
            SqlDataAdapter da = new SqlDataAdapter(tentb, KetNoi);
            DataTable dat = new DataTable();
            da.Fill(dat);
            txtTenTB.DataBindings.Add("text", dat, "TenTB");
            txtTenTB.Refresh();
            dgvTrangTBPhong.Refresh();
        }
    }
}
