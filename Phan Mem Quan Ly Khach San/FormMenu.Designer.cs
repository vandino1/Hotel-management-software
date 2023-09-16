
namespace Phan_Mem_Quan_Ly_Khach_San
{
    partial class FrmMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMenu));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.mni_HeThong = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoggin = new System.Windows.Forms.ToolStripMenuItem();
            this.mniExit = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDoiMK = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_QuanLy = new System.Windows.Forms.ToolStripMenuItem();
            this.mniChucVu = new System.Windows.Forms.ToolStripMenuItem();
            this.mniNhanVien = new System.Windows.Forms.ToolStripMenuItem();
            this.mniKH = new System.Windows.Forms.ToolStripMenuItem();
            this.mniLoaiPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.mniPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDV = new System.Windows.Forms.ToolStripMenuItem();
            this.mniThietBi = new System.Windows.Forms.ToolStripMenuItem();
            this.mniSDDV = new System.Windows.Forms.ToolStripMenuItem();
            this.mniPhieuThanhToan = new System.Windows.Forms.ToolStripMenuItem();
            this.mniDKPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.mniTrangTBPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.mniKhuVucPhong = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_HoTro = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_NangQuyen = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_InBaoCao = new System.Windows.Forms.ToolStripMenuItem();
            this.mni_HDSD = new System.Windows.Forms.ToolStripMenuItem();
            this.MenuThoat = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.PTBHinhAnh = new System.Windows.Forms.PictureBox();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.sttTTNguoiDung = new System.Windows.Forms.ToolStripStatusLabel();
            this.sttTTThoiGian = new System.Windows.Forms.ToolStripStatusLabel();
            this.mniSaoLuu = new System.Windows.Forms.ToolStripMenuItem();
            this.mniPhucHoi = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PTBHinhAnh)).BeginInit();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Visible;
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mni_HeThong,
            this.mni_QuanLy,
            this.mniKhuVucPhong,
            this.mni_HoTro,
            this.MenuThoat});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1045, 36);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // mni_HeThong
            // 
            this.mni_HeThong.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniLoggin,
            this.mniExit,
            this.mniDoiMK,
            this.mniSaoLuu,
            this.mniPhucHoi});
            this.mni_HeThong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mni_HeThong.Image = ((System.Drawing.Image)(resources.GetObject("mni_HeThong.Image")));
            this.mni_HeThong.Name = "mni_HeThong";
            this.mni_HeThong.Size = new System.Drawing.Size(131, 32);
            this.mni_HeThong.Text = "Hệ Thống";
            // 
            // mniLoggin
            // 
            this.mniLoggin.Image = ((System.Drawing.Image)(resources.GetObject("mniLoggin.Image")));
            this.mniLoggin.Name = "mniLoggin";
            this.mniLoggin.Size = new System.Drawing.Size(224, 32);
            this.mniLoggin.Text = "Đăng Nhập";
            this.mniLoggin.Click += new System.EventHandler(this.mniLoggin_Click);
            // 
            // mniExit
            // 
            this.mniExit.Image = ((System.Drawing.Image)(resources.GetObject("mniExit.Image")));
            this.mniExit.Name = "mniExit";
            this.mniExit.Size = new System.Drawing.Size(224, 32);
            this.mniExit.Text = "Đăng Xuất";
            this.mniExit.Click += new System.EventHandler(this.mniDangXuat_Click);
            // 
            // mniDoiMK
            // 
            this.mniDoiMK.Image = ((System.Drawing.Image)(resources.GetObject("mniDoiMK.Image")));
            this.mniDoiMK.Name = "mniDoiMK";
            this.mniDoiMK.Size = new System.Drawing.Size(224, 32);
            this.mniDoiMK.Text = "Đổi Mật Khẩu";
            this.mniDoiMK.Click += new System.EventHandler(this.mniDoiMK_Click);
            // 
            // mni_QuanLy
            // 
            this.mni_QuanLy.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mniChucVu,
            this.mniNhanVien,
            this.mniKH,
            this.mniLoaiPhong,
            this.mniPhong,
            this.mniDV,
            this.mniThietBi,
            this.mniSDDV,
            this.mniPhieuThanhToan,
            this.mniDKPhong,
            this.mniTrangTBPhong});
            this.mni_QuanLy.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mni_QuanLy.Image = ((System.Drawing.Image)(resources.GetObject("mni_QuanLy.Image")));
            this.mni_QuanLy.Name = "mni_QuanLy";
            this.mni_QuanLy.Size = new System.Drawing.Size(205, 32);
            this.mni_QuanLy.Text = "Quản lý nghiệp vụ";
            // 
            // mniChucVu
            // 
            this.mniChucVu.Name = "mniChucVu";
            this.mniChucVu.Size = new System.Drawing.Size(277, 32);
            this.mniChucVu.Text = "Chức Vụ";
            this.mniChucVu.Click += new System.EventHandler(this.mniChucVu_Click);
            // 
            // mniNhanVien
            // 
            this.mniNhanVien.Name = "mniNhanVien";
            this.mniNhanVien.Size = new System.Drawing.Size(277, 32);
            this.mniNhanVien.Text = "Nhân Viên";
            this.mniNhanVien.Click += new System.EventHandler(this.mniNhanVien_Click);
            // 
            // mniKH
            // 
            this.mniKH.Name = "mniKH";
            this.mniKH.Size = new System.Drawing.Size(277, 32);
            this.mniKH.Text = "Khách Hàng";
            this.mniKH.Click += new System.EventHandler(this.mniKH_Click);
            // 
            // mniLoaiPhong
            // 
            this.mniLoaiPhong.Name = "mniLoaiPhong";
            this.mniLoaiPhong.Size = new System.Drawing.Size(277, 32);
            this.mniLoaiPhong.Text = "Loại Phòng";
            this.mniLoaiPhong.Click += new System.EventHandler(this.mniLoaiPhong_Click);
            // 
            // mniPhong
            // 
            this.mniPhong.Name = "mniPhong";
            this.mniPhong.Size = new System.Drawing.Size(277, 32);
            this.mniPhong.Text = "Phòng";
            this.mniPhong.Click += new System.EventHandler(this.mniPhong_Click);
            // 
            // mniDV
            // 
            this.mniDV.Name = "mniDV";
            this.mniDV.Size = new System.Drawing.Size(277, 32);
            this.mniDV.Text = "Dịch Vụ";
            this.mniDV.Click += new System.EventHandler(this.mniDV_Click);
            // 
            // mniThietBi
            // 
            this.mniThietBi.Name = "mniThietBi";
            this.mniThietBi.Size = new System.Drawing.Size(277, 32);
            this.mniThietBi.Text = "Thiết Bị";
            this.mniThietBi.Click += new System.EventHandler(this.mniThietBi_Click);
            // 
            // mniSDDV
            // 
            this.mniSDDV.Name = "mniSDDV";
            this.mniSDDV.Size = new System.Drawing.Size(277, 32);
            this.mniSDDV.Text = "Sử Dụng Dịch Vụ";
            this.mniSDDV.Click += new System.EventHandler(this.mniSDDV_Click);
            // 
            // mniPhieuThanhToan
            // 
            this.mniPhieuThanhToan.Name = "mniPhieuThanhToan";
            this.mniPhieuThanhToan.Size = new System.Drawing.Size(277, 32);
            this.mniPhieuThanhToan.Text = "Phiếu Thanh Toán";
            this.mniPhieuThanhToan.Click += new System.EventHandler(this.mniPhieuThanhToan_Click);
            // 
            // mniDKPhong
            // 
            this.mniDKPhong.Name = "mniDKPhong";
            this.mniDKPhong.Size = new System.Drawing.Size(277, 32);
            this.mniDKPhong.Text = "Đăng Ký Phòng";
            this.mniDKPhong.Click += new System.EventHandler(this.mniDKPhong_Click);
            // 
            // mniTrangTBPhong
            // 
            this.mniTrangTBPhong.Name = "mniTrangTBPhong";
            this.mniTrangTBPhong.Size = new System.Drawing.Size(277, 32);
            this.mniTrangTBPhong.Text = "Trang Thiết Bị Phòng";
            this.mniTrangTBPhong.Click += new System.EventHandler(this.mniTrangTBPhong_Click);
            // 
            // mniKhuVucPhong
            // 
            this.mniKhuVucPhong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mniKhuVucPhong.Image = ((System.Drawing.Image)(resources.GetObject("mniKhuVucPhong.Image")));
            this.mniKhuVucPhong.Name = "mniKhuVucPhong";
            this.mniKhuVucPhong.Size = new System.Drawing.Size(232, 32);
            this.mniKhuVucPhong.Text = "Khu Vựa Chọn Phòng";
            this.mniKhuVucPhong.Click += new System.EventHandler(this.mniKhuVucPhong_Click);
            // 
            // mni_HoTro
            // 
            this.mni_HoTro.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mni_NangQuyen,
            this.mni_InBaoCao,
            this.mni_HDSD});
            this.mni_HoTro.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.mni_HoTro.Image = ((System.Drawing.Image)(resources.GetObject("mni_HoTro.Image")));
            this.mni_HoTro.Name = "mni_HoTro";
            this.mni_HoTro.Size = new System.Drawing.Size(104, 32);
            this.mni_HoTro.Text = "Hỗ Trợ";
            // 
            // mni_NangQuyen
            // 
            this.mni_NangQuyen.Image = ((System.Drawing.Image)(resources.GetObject("mni_NangQuyen.Image")));
            this.mni_NangQuyen.Name = "mni_NangQuyen";
            this.mni_NangQuyen.Size = new System.Drawing.Size(280, 32);
            this.mni_NangQuyen.Text = "Nâng cấp quyền";
            this.mni_NangQuyen.Click += new System.EventHandler(this.mni_NangQuyen_Click);
            // 
            // mni_InBaoCao
            // 
            this.mni_InBaoCao.Image = ((System.Drawing.Image)(resources.GetObject("mni_InBaoCao.Image")));
            this.mni_InBaoCao.Name = "mni_InBaoCao";
            this.mni_InBaoCao.Size = new System.Drawing.Size(280, 32);
            this.mni_InBaoCao.Text = "In Báo Cáo";
            this.mni_InBaoCao.Click += new System.EventHandler(this.mni_InBaoCao_Click);
            // 
            // mni_HDSD
            // 
            this.mni_HDSD.Image = ((System.Drawing.Image)(resources.GetObject("mni_HDSD.Image")));
            this.mni_HDSD.Name = "mni_HDSD";
            this.mni_HDSD.Size = new System.Drawing.Size(280, 32);
            this.mni_HDSD.Text = "Hướng Dẫn Sử Dụng";
            this.mni_HDSD.Click += new System.EventHandler(this.mni_HDSD_Click);
            // 
            // MenuThoat
            // 
            this.MenuThoat.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MenuThoat.ForeColor = System.Drawing.SystemColors.ControlText;
            this.MenuThoat.Image = ((System.Drawing.Image)(resources.GetObject("MenuThoat.Image")));
            this.MenuThoat.Name = "MenuThoat";
            this.MenuThoat.Size = new System.Drawing.Size(96, 32);
            this.MenuThoat.Text = "Thoát";
            this.MenuThoat.Click += new System.EventHandler(this.MenuThoat_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // PTBHinhAnh
            // 
            this.PTBHinhAnh.Image = ((System.Drawing.Image)(resources.GetObject("PTBHinhAnh.Image")));
            this.PTBHinhAnh.Location = new System.Drawing.Point(0, 39);
            this.PTBHinhAnh.Name = "PTBHinhAnh";
            this.PTBHinhAnh.Size = new System.Drawing.Size(1043, 482);
            this.PTBHinhAnh.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.PTBHinhAnh.TabIndex = 1;
            this.PTBHinhAnh.TabStop = false;
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.sttTTNguoiDung,
            this.sttTTThoiGian});
            this.statusStrip1.Location = new System.Drawing.Point(0, 491);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(1045, 26);
            this.statusStrip1.TabIndex = 2;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // sttTTNguoiDung
            // 
            this.sttTTNguoiDung.Name = "sttTTNguoiDung";
            this.sttTTNguoiDung.Size = new System.Drawing.Size(151, 20);
            this.sttTTNguoiDung.Text = "toolStripStatusLabel1";
            // 
            // sttTTThoiGian
            // 
            this.sttTTThoiGian.Name = "sttTTThoiGian";
            this.sttTTThoiGian.Size = new System.Drawing.Size(151, 20);
            this.sttTTThoiGian.Text = "toolStripStatusLabel1";
            // 
            // mniSaoLuu
            // 
            this.mniSaoLuu.Name = "mniSaoLuu";
            this.mniSaoLuu.Size = new System.Drawing.Size(224, 32);
            this.mniSaoLuu.Text = "Sao Lưu";
            this.mniSaoLuu.Click += new System.EventHandler(this.mniSaoLuu_Click);
            // 
            // mniPhucHoi
            // 
            this.mniPhucHoi.Name = "mniPhucHoi";
            this.mniPhucHoi.Size = new System.Drawing.Size(224, 32);
            this.mniPhucHoi.Text = "Phục Hồi";
            this.mniPhucHoi.Click += new System.EventHandler(this.mniPhucHoi_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1045, 517);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.PTBHinhAnh);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMenu";
            this.Text = "Giao Diện";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.PTBHinhAnh)).EndInit();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mni_QuanLy;
        private System.Windows.Forms.ToolStripMenuItem mni_HeThong;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem mniChucVu;
        private System.Windows.Forms.ToolStripMenuItem mniNhanVien;
        private System.Windows.Forms.ToolStripMenuItem mniKH;
        private System.Windows.Forms.ToolStripMenuItem mniLoaiPhong;
        private System.Windows.Forms.ToolStripMenuItem mniPhong;
        private System.Windows.Forms.ToolStripMenuItem mniDV;
        private System.Windows.Forms.ToolStripMenuItem mniThietBi;
        private System.Windows.Forms.ToolStripMenuItem mniLoggin;
        private System.Windows.Forms.ToolStripMenuItem MenuThoat;
        private System.Windows.Forms.PictureBox PTBHinhAnh;
        private System.Windows.Forms.ToolStripMenuItem mniKhuVucPhong;
        private System.Windows.Forms.ToolStripMenuItem mniSDDV;
        private System.Windows.Forms.ToolStripMenuItem mniPhieuThanhToan;
        private System.Windows.Forms.ToolStripMenuItem mniDKPhong;
        private System.Windows.Forms.ToolStripMenuItem mniExit;
        private System.Windows.Forms.ToolStripMenuItem mniDoiMK;
        private System.Windows.Forms.ToolStripMenuItem mniTrangTBPhong;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel sttTTNguoiDung;
        private System.Windows.Forms.ToolStripStatusLabel sttTTThoiGian;
        private System.Windows.Forms.ToolStripMenuItem mni_HoTro;
        private System.Windows.Forms.ToolStripMenuItem mni_NangQuyen;
        private System.Windows.Forms.ToolStripMenuItem mni_InBaoCao;
        private System.Windows.Forms.ToolStripMenuItem mni_HDSD;
        private System.Windows.Forms.ToolStripMenuItem mniSaoLuu;
        private System.Windows.Forms.ToolStripMenuItem mniPhucHoi;
    }
}