using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BUS;
using DTO;
namespace Phan_Mem_Quan_Ly_Khach_San
{
    public partial class FrmMenu : Form
    {
        FrmDangNhap fDN;     
        public bool bDangNhap = false;
        public static NguoiDungDTO NguoiDung;
        private void HienThiMenu()
        {
            mniLoggin.Enabled = !bDangNhap;
            mniExit.Enabled = bDangNhap;

            if (bDangNhap == false)
            {
              
                sttTTNguoiDung.Text = "Chưa đăng nhập";              
                sttTTThoiGian.Text = "";

                mniChucVu.Enabled = false;
                mniNhanVien.Enabled = false;
                mniDoiMK.Enabled = false;
                mniKH.Enabled = false;
                mniLoaiPhong.Enabled = false;
                mniPhong.Enabled = false;
                mniDV.Enabled = false;
                mniThietBi.Enabled = false;
                mniSDDV.Enabled = false;
                mniPhieuThanhToan.Enabled = false;
                mniDKPhong.Enabled = false;
                mniTrangTBPhong.Enabled = false;
                mniKhuVucPhong.Enabled = false;
                mni_HoTro.Enabled = false;
                mni_QuanLy.Enabled = false;

            }
            else
            {
                int quyen;
                if (NguoiDung == null)
                    quyen = 0;
                else
                {
                    quyen = NguoiDung.IQuyen;
                    sttTTNguoiDung.Text = "Chào " + NguoiDung.STen + "! ";
                    sttTTThoiGian.Text = "Thời điểm đăng nhập: " + DateTime.Now;
                }
                switch (quyen) // hiển thị menu phù hợp với quyền 
                {
                    case 1: // quản trị
                        mniChucVu.Enabled = true;
                        mniNhanVien.Enabled = true;
                        mniDoiMK.Enabled = true;
                        mniKH.Enabled = true;
                        mniLoaiPhong.Enabled = true;
                        mniPhong.Enabled = true;
                        mniDV.Enabled = true;
                        mniThietBi.Enabled = true;
                        mniSDDV.Enabled = true;
                        mniPhieuThanhToan.Enabled = true;
                        mniDKPhong.Enabled = true;
                        mniTrangTBPhong.Enabled = true;
                        mniKhuVucPhong.Enabled = true;
                        mni_HoTro.Enabled = true;
                        mni_QuanLy.Enabled = true;
                        mni_NangQuyen.Enabled = true;
                        break;
                    case 2: // nhân viên
                        mniChucVu.Enabled = false;
                        mniNhanVien.Enabled = false;
                        mniDoiMK.Enabled = true;
                        mniKH.Enabled = true;
                        mniLoaiPhong.Enabled = false;
                        mniPhong.Enabled = false;
                        mniDV.Enabled = false;
                        mniThietBi.Enabled = false;
                        mniSDDV.Enabled = true;
                        mniPhieuThanhToan.Enabled = true;
                        mniDKPhong.Enabled = true;
                        mniTrangTBPhong.Enabled = false;
                        mniKhuVucPhong.Enabled = true;
                        mni_HoTro.Enabled = true;
                        mni_QuanLy.Enabled = true;
                        mni_NangQuyen.Enabled = false;
                        break;
                    default:
                        break;

                }
            }
        }
        public FrmMenu()
        {
            InitializeComponent();
        }


        private void mniChucVu_Click(object sender, EventArgs e)
        {
            FrmChucVu f1 = new FrmChucVu();
            this.Hide();
            f1.ShowDialog();
            this.Show();

        }

        private void mniKH_Click(object sender, EventArgs e)
        {
            FrmKhachHang f2 = new FrmKhachHang();
            this.Hide();
            f2.ShowDialog();
            this.Show();
        }

        private void mniLoaiPhong_Click(object sender, EventArgs e)
        {
            FrmLoaiPhong f3 = new FrmLoaiPhong();
            this.Hide();
            f3.ShowDialog();
            this.Show();

        }


        private void mniPhong_Click(object sender, EventArgs e)
        {
            FrmPhong f5 = new FrmPhong();
            this.Hide();
            f5.ShowDialog();
            this.Show();
        }

        private void mniDV_Click(object sender, EventArgs e)
        {
            FrmDichVu f6 = new FrmDichVu();
            this.Hide();
            f6.ShowDialog();
            this.Show();
        }
      

        private void mniNhanVien_Click(object sender, EventArgs e)
        {
            FrmNhanVien f11 = new FrmNhanVien();
            this.Hide();
            f11.ShowDialog();
            this.Show();
        }

        private void MenuThoat_Click(object sender, EventArgs e)
        {
            DialogResult traloi;
            traloi = MessageBox.Show("Bạn có muốn thoát khỏi phần mềm không?", "Xác Nhận", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (traloi == DialogResult.OK)             
                Application.Exit();
        }

        private void mniKhuVucPhong_Click(object sender, EventArgs e)
        {
            FrmSoDoPhong f4 = new FrmSoDoPhong();
            this.Hide();
            f4.ShowDialog();
            this.Show();
        }

        private void mniDKPhong_Click(object sender, EventArgs e)
        {
            FrmDangKyPhong a1 = new FrmDangKyPhong();
            this.Hide();
            a1.ShowDialog();
            this.Show();


        }

        private void mniSDDV_Click(object sender, EventArgs e)
        {
            FrmSuDungDV f7 = new FrmSuDungDV();
            this.Hide();
            f7.ShowDialog();
            this.Show();
        }

        private void mniPhieuThanhToan_Click(object sender, EventArgs e)
        {
            FrmPhieuThanhToan f8 = new FrmPhieuThanhToan();
            this.Hide();
            f8.ShowDialog();
            this.Show();

        }
        FrmDoiMatKhau FDMK;
        private void mniDoiMK_Click(object sender, EventArgs e)
        {      
                FDMK = new FrmDoiMatKhau();
                this.Hide();
                FDMK.ShowDialog();
                this.Show();
            
        }

        private void mniThietBi_Click(object sender, EventArgs e)
        {
            FrmThietBi f9 = new FrmThietBi();
            this.Hide();
            f9.ShowDialog();
            this.Show();

        }

        private void mniDangXuat_Click(object sender, EventArgs e)
        {
            // Đóng tất cả form đang mở
            foreach (Form f in this.MdiChildren)
            {
                if (!f.IsDisposed)
                    f.Close();
            }
            // Đăng xuất và thiết lập lại menu
            bDangNhap = false;
            HienThiMenu();
        }

        private void mniTrangTBPhong_Click(object sender, EventArgs e)
        {
            TFrmtrangTBPhong f10 = new TFrmtrangTBPhong();
            this.Hide();
            f10.ShowDialog();
            this.Show();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {
            HienThiMenu();
        }

        private void mniLoggin_Click(object sender, EventArgs e)
        {
            fDN = new FrmDangNhap();
            if (fDN.ShowDialog() == DialogResult.OK)
            {
                string sTen = fDN.txtDangNhap.Text;
                string sMatKhau = fDN.txtMatKhau.Text;
                NguoiDung = new NguoiDungDTO();
                NguoiDung = NguoiDung_BUS.LayNguoiDung(sTen, sMatKhau);
                if (NguoiDung != null)
                {
                    bDangNhap = true;
                }              
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng vui lòng nhập lại!");
                bDangNhap = false;
            }
            HienThiMenu();
            }
        }

        private void mni_NangQuyen_Click(object sender, EventArgs e)
        {
            FrmNguoiDung f11 = new FrmNguoiDung();
            this.Hide();
            f11.ShowDialog();
            this.Show();
        }

        private void mni_HDSD_Click(object sender, EventArgs e)
        {
            Help.ShowHelp(this, "HDSuDung.chm");
        }

        private void mni_InBaoCao_Click(object sender, EventArgs e)
        {
            frmXuatBaoCao f12 = new frmXuatBaoCao();        
            f12.ShowDialog();  
        }

        private void mniSaoLuu_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog saoluuFolder = new FolderBrowserDialog();
            saoluuFolder.Description = "Chọn thư mục lưu trữ";
            if (saoluuFolder.ShowDialog() == DialogResult.OK)
            {
                string sDuongDan = saoluuFolder.SelectedPath;
                if (BUS_CSDL.SaoLuu(sDuongDan) == true)
                    MessageBox.Show("Đã sao lưu dữ liệu vào " + sDuongDan);
                else
                    MessageBox.Show("Thao tác không thành công");
            }
        }

        private void mniPhucHoi_Click(object sender, EventArgs e)
        {
            OpenFileDialog phuchoiFile = new OpenFileDialog();
            phuchoiFile.Filter = "*.bak|*.bak";
            phuchoiFile.Title = "Chọn tập tin phục hồi (.bak)";
            if (phuchoiFile.ShowDialog() == DialogResult.OK && phuchoiFile.CheckFileExists == true)
            {
                string sDuongDan = phuchoiFile.FileName;
                if (BUS_CSDL.PhucHoi(sDuongDan) == true)
                    MessageBox.Show("Phục hồi dữ liệu thành công");
                else
                    MessageBox.Show("Phục hồi dữ liệu thất bại");
            }
        }
    }
    }

