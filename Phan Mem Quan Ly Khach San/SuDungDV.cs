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

    public partial class FrmSuDungDV : Form
    {
        public FrmSuDungDV()
        {
            InitializeComponent();
        }
        static string s = @"Data Source=ADMIN\SQLEXPRESS;Initial Catalog=QLKHACHSAN;Integrated Security=True";
        SqlConnection KetNoi = new SqlConnection(s);
        private void HienThiSuDungDichVuLenDataGrid()
        {
            List<SuDungDichVuDTO> lstSuDungDichVu = SuDungDichVuBUS.LayDSSuDungDichVu();
           dgvSuDungDV.DataSource = lstSuDungDichVu;
        }
        private void HienThiMaDichVuLenCombobox()
        {
            List<DichVuDTO> lstDichVu = DichVuBUS.LayDSDichVu();
            cmbMaDV.DataSource = lstDichVu;
            cmbMaDV.DisplayMember = "SMaDV";
            cmbMaDV.ValueMember = "SMaDV";
        }      
        private void HienThiMaKHLenCombobox()
        {
            List<KhachHangDTO> lstKhachHang = KhachHangBUS.LayDSKhachHang();
            cmbMaKH.DataSource = lstKhachHang;
            cmbMaKH.DisplayMember = "SMaKH";
            cmbMaKH.ValueMember = "SMaKH";
        }
        private void HienThiDSSuDungDichVuLenDatagrid()
        {
            List<SuDungDichVuDTO> lstSuDungDichVu = SuDungDichVuBUS.LayDSSuDungDichVu();
            dgvSuDungDV.DataSource = lstSuDungDichVu;
            dgvSuDungDV.Columns["ISTT"].HeaderText = "Số Thứ Tự";
            dgvSuDungDV.Columns["SMaKH"].HeaderText = "Mã Khách Hàng";
            dgvSuDungDV.Columns["DTNgaySuDung1"].HeaderText = "Ngày Sử Dụng Dịch Vụ";
            dgvSuDungDV.Columns["SSoPhong"].HeaderText = "Số Phòng";
            dgvSuDungDV.Columns["SMaDV"].HeaderText = "Mã Dịch Vụ";
            dgvSuDungDV.Columns["ISoLuong"].HeaderText = "Số Lượng";
            dgvSuDungDV.Columns["IThanhTien"].HeaderText = "Thành Tiền (VNĐ)";

            dgvSuDungDV.Columns["ISTT"].Width = 80;
            dgvSuDungDV.Columns["SMaKH"].Width = 200;
            dgvSuDungDV.Columns["DTNgaySuDung1"].Width = 200;
            dgvSuDungDV.Columns["SSoPhong"].Width = 80;
            dgvSuDungDV.Columns["SMaDV"].Width = 150;
            dgvSuDungDV.Columns["ISoLuong"].Width = 100;
            dgvSuDungDV.Columns["IThanhTien"].Width = 200;

        }
        private void Reset()
        {
            txtSTT.Clear();                         
            txtSoLuong.Clear();
            txtThanhTien.Clear();
            txtGiaDV.Clear();
            txtTenDV.Clear();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtSTT.Text == "" || txtSoLuong.Text == ""|| txtGiaDV.Text == ""|| txtTenDV.Text == ""|| txtThanhTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }
            // Kiểm tra số thứ tự có độ dài chuỗi hợp lệ hay không
            if (txtSTT.Text.Length > 4)
            {
                MessageBox.Show("Số thứ tự tối đa 4 chữ số!");
                return;
            }
            // Kiểm tra số thứ tự có bị trùng không
            if (SuDungDichVuBUS.TimSuDungDichVuTheoMa(txtSTT.Text) != null)
            {
                MessageBox.Show("Số thứ tự đã tồn tại! Vui lòng chọn số thứ tự khác.");
                return;
            }
            // Gán dữ liệu vào kiểu SuDungDVDTO
            SuDungDichVuDTO udv = new SuDungDichVuDTO();
            udv.ISTT = int.Parse(txtSTT.Text);
            udv.SMaKH = cmbMaKH.SelectedValue.ToString();
            udv.DTNgaySuDung1 = DateTime.Parse(DTNgaySuDung.Text);
            udv.SSoPhong = txtSoPhong.Text;
            udv.SMaDV = cmbMaDV.SelectedValue.ToString();
            udv.ISoLuong = int.Parse(txtSoLuong.Text);
            udv.IThanhTien = int.Parse(txtThanhTien.Text);
            // Thực hiện thêm
            if (SuDungDichVuBUS.ThemSuDungDichVu(udv) == false)
            {
                MessageBox.Show("Không thêm được.");
                return;
            }
            Reset();
            HienThiDSSuDungDichVuLenDatagrid();
            MessageBox.Show("Đã thêm người sử dụng dịch vụ thành công.");

        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra dữ liệu có bị bỏ trống
            if (txtSTT.Text == ""|| txtSoLuong.Text == ""|| txtGiaDV.Text == ""|| txtTenDV.Text == ""|| txtThanhTien.Text == "")
            {
                MessageBox.Show("Vui lòng nhập đầy đủ dữ liệu!");
                return;
            }

            // Kiểm tra số thứ tự có bị trùng không
            if (SuDungDichVuBUS.TimSuDungDichVuTheoMa(txtSTT.Text) == null)
            {
                MessageBox.Show("Số thứ tự đã tồn tại! Vui lòng chọn số thứ tự khác.");
                return;
            }
            // Gán dữ liệu vào kiểu SuDungDVDTO
            SuDungDichVuDTO udv = new SuDungDichVuDTO();
            udv.ISTT = int.Parse(txtSTT.Text);
            udv.SMaKH = cmbMaKH.SelectedValue.ToString();
            udv.DTNgaySuDung1 = DateTime.Parse(DTNgaySuDung.Text);
            udv.SSoPhong = txtSoPhong.Text;
            udv.SMaDV = cmbMaDV.SelectedValue.ToString();
            udv.ISoLuong = int.Parse(txtSoLuong.Text);
            udv.IThanhTien = int.Parse(txtThanhTien.Text);
           
            // Thực hiện thêm
            if (SuDungDichVuBUS.CapNhatSuDungDichVu(udv) == false)
            {
                MessageBox.Show("Không cập nhật được.");
                return;
            }
            Reset();
            HienThiDSSuDungDichVuLenDatagrid();
            MessageBox.Show("Đã cập nhật thông tin sử dụng dịch vụ thành công.");

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            // Kiểm tra số thứ tự có tồn tại không
            if (SuDungDichVuBUS.TimSuDungDichVuTheoMa(txtSTT.Text) == null)
            {
                MessageBox.Show("Số Thứ Tự không tồn tại!");
                return;
            }
            // Gán dữ liệu vào kiểu SuDungDVDTO
            SuDungDichVuDTO udv = new SuDungDichVuDTO();
            udv.ISTT = int.Parse(txtSTT.Text);

            // Thực hiện xóa 
            if (MessageBox.Show("Bạn có chắc chắn muốn xóa người sử dụng dịch vụ không ?", "Thông báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == System.Windows.Forms.DialogResult.OK)
            {
                if (SuDungDichVuBUS.XoaSuDungDichVu(udv) == false)
                {
                    MessageBox.Show("Không xóa được.");
                    return;
                }
                Reset();
                HienThiDSSuDungDichVuLenDatagrid();
                MessageBox.Show("Đã xóa người sử dụng dịch vụ thành công.");
            }
        }

        private void FrmSuDungDV_Load(object sender, EventArgs e)
        {         
            HienThiMaDichVuLenCombobox();
            HienThiDSSuDungDichVuLenDatagrid();
            HienThiMaKHLenCombobox();
            txtGiaDV.DataBindings.Clear();
           
        }

        private void btnTimKiem_Click(object sender, EventArgs e)
        {
            List<SuDungDichVuDTO> ds = SuDungDichVuBUS.LayDSSuDungDichVu();
            List<SuDungDichVuDTO> kq = (from udv in ds
                                 //where udv.SHoTen.Contains(txtTimHoVaTen.Text)
                                 where udv.SSoPhong.Contains(txtTimSoPhong.Text)
                                 select udv).ToList();
            dgvSuDungDV.DataSource = kq;

        }

        private void dgvSuDungDV_Click(object sender, EventArgs e)
        {
            DataGridViewRow r = new DataGridViewRow();
            r = dgvSuDungDV.SelectedRows[0];
            txtSTT.Text = r.Cells["ISTT"].Value.ToString();
            cmbMaKH.SelectedValue = r.Cells["SMaKH"].Value.ToString();
            DTNgaySuDung.Text = r.Cells["DTNgaySuDung1"].Value.ToString();
            txtSoPhong.Text = r.Cells["SSoPhong"].Value.ToString();
            cmbMaDV.SelectedValue = r.Cells["SMaDV"].Value.ToString();
            txtSoLuong.Text = r.Cells["ISoLuong"].Value.ToString();
            txtThanhTien.Text = r.Cells["IThanhTien"].Value.ToString();
      

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

        private void btnTinhTien_Click(object sender, EventArgs e)
        {
            if (txtSoLuong.Text == "")
            {
                MessageBox.Show("Vui lòng nhập số lượng vào!");
                return;
            }
            string getGia = txtGiaDV.Text.ToString();
            int soluong = (Convert.ToInt32(txtSoLuong.Text));
            int dongia = Convert.ToInt32(getGia);
            int kq = soluong * dongia;
            txtThanhTien.Text = (kq).ToString();
        }
        private void cmbMaDV_SelectedIndexChanged(object sender, EventArgs e)
        {
            txtTenDV.DataBindings.Clear();
            string layten = @"select TenDV from DichVu where MADV ='" + cmbMaDV.Text + "'";
            SqlCommand sqlc = new SqlCommand(layten, KetNoi);
            SqlDataAdapter da = new SqlDataAdapter(layten, KetNoi);
            DataTable dat = new DataTable();
            da.Fill(dat);
            txtTenDV.DataBindings.Add("text", dat, "TenDV");

            txtGiaDV.DataBindings.Clear();
            string laygia = @"select DonGia from DichVu where MaDV ='" + cmbMaDV.Text + "'";
            SqlCommand sqlq = new SqlCommand(laygia, KetNoi);
            SqlDataAdapter dp = new SqlDataAdapter(laygia, KetNoi);
            DataTable d = new DataTable();
            dp.Fill(d);
            txtGiaDV.DataBindings.Add("text", d, "DonGia");
            txtThanhTien.Refresh();
            txtGiaDV.Refresh();
            txtTenDV.Refresh();
            dgvSuDungDV.Refresh();


        }

        private void txtSTT_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar))
            {
                e.Handled = false;
            }
            else
            {
                e.Handled = true;
                MessageBox.Show("Số thứ tự phải là số !");
            }
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
            dgvSuDungDV.Refresh();
        }
    }
}
