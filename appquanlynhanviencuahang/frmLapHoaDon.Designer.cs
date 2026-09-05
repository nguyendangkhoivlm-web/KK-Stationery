namespace appquanlynhanviencuahang
{
    partial class frmLapHoaDon
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
            this.btnThanhToan1 = new System.Windows.Forms.Button();
            this.btnLuuNhap = new System.Windows.Forms.Button();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.lblTamTinh = new System.Windows.Forms.Label();
            this.dgvDanhSachSanPham = new System.Windows.Forms.DataGridView();
            this.pnlThanhToanDuoi = new System.Windows.Forms.Panel();
            this.lblThueVAT = new System.Windows.Forms.Label();
            this.btnXoaSanPham = new System.Windows.Forms.Button();
            this.lblTieuDeChinh = new System.Windows.Forms.Label();
            this.btnThemSanPham = new System.Windows.Forms.Button();
            this.txtTimKiemSanPham = new System.Windows.Forms.TextBox();
            this.btnCapNhatHoaDon = new System.Windows.Forms.Button();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.pnlThaoTacSP = new System.Windows.Forms.Panel();
            this.pnlThongTinTren = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSanPham)).BeginInit();
            this.pnlThanhToanDuoi.SuspendLayout();
            this.pnlThaoTacSP.SuspendLayout();
            this.pnlThongTinTren.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnThanhToan1
            // 
            this.btnThanhToan1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan1.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnThanhToan1.FlatAppearance.BorderSize = 0;
            this.btnThanhToan1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan1.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan1.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan1.Location = new System.Drawing.Point(907, 76);
            this.btnThanhToan1.Name = "btnThanhToan1";
            this.btnThanhToan1.Size = new System.Drawing.Size(140, 42);
            this.btnThanhToan1.TabIndex = 4;
            this.btnThanhToan1.Text = "Thanh Toán";
            this.btnThanhToan1.UseVisualStyleBackColor = false;
            this.btnThanhToan1.Click += new System.EventHandler(this.btnThanhToan1_Click);
            // 
            // btnLuuNhap
            // 
            this.btnLuuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnLuuNhap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnLuuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuNhap.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.btnLuuNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLuuNhap.Location = new System.Drawing.Point(783, 76);
            this.btnLuuNhap.Name = "btnLuuNhap";
            this.btnLuuNhap.Size = new System.Drawing.Size(115, 42);
            this.btnLuuNhap.TabIndex = 3;
            this.btnLuuNhap.Text = "Lưu Nháp";
            this.btnLuuNhap.UseVisualStyleBackColor = false;
            this.btnLuuNhap.Click += new System.EventHandler(this.btnLuuNhap_Click);
            // 
            // lblTongCong
            // 
            this.lblTongCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongCong.Font = new System.Drawing.Font("Segoe UI", 13.5F, System.Drawing.FontStyle.Bold);
            this.lblTongCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTongCong.Location = new System.Drawing.Point(703, 40);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(344, 30);
            this.lblTongCong.TabIndex = 2;
            this.lblTongCong.Text = "Tổng cộng: 0 VNĐ";
            this.lblTongCong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTamTinh
            // 
            this.lblTamTinh.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTamTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTamTinh.Location = new System.Drawing.Point(753, 1);
            this.lblTamTinh.Name = "lblTamTinh";
            this.lblTamTinh.Size = new System.Drawing.Size(294, 20);
            this.lblTamTinh.TabIndex = 0;
            this.lblTamTinh.Text = "Tạm tính: 0 VNĐ";
            this.lblTamTinh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // dgvDanhSachSanPham
            // 
            this.dgvDanhSachSanPham.AllowUserToAddRows = false;
            this.dgvDanhSachSanPham.AllowUserToDeleteRows = false;
            this.dgvDanhSachSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachSanPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDanhSachSanPham.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDanhSachSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSachSanPham.EnableHeadersVisualStyles = false;
            this.dgvDanhSachSanPham.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.dgvDanhSachSanPham.Location = new System.Drawing.Point(0, 157);
            this.dgvDanhSachSanPham.Name = "dgvDanhSachSanPham";
            this.dgvDanhSachSanPham.RowHeadersVisible = false;
            this.dgvDanhSachSanPham.RowHeadersWidth = 51;
            this.dgvDanhSachSanPham.RowTemplate.Height = 38;
            this.dgvDanhSachSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachSanPham.Size = new System.Drawing.Size(1047, 332);
            this.dgvDanhSachSanPham.TabIndex = 6;
            // 
            // pnlThanhToanDuoi
            // 
            this.pnlThanhToanDuoi.Controls.Add(this.btnThanhToan1);
            this.pnlThanhToanDuoi.Controls.Add(this.btnLuuNhap);
            this.pnlThanhToanDuoi.Controls.Add(this.lblTongCong);
            this.pnlThanhToanDuoi.Controls.Add(this.lblThueVAT);
            this.pnlThanhToanDuoi.Controls.Add(this.lblTamTinh);
            this.pnlThanhToanDuoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThanhToanDuoi.Location = new System.Drawing.Point(0, 489);
            this.pnlThanhToanDuoi.Name = "pnlThanhToanDuoi";
            this.pnlThanhToanDuoi.Size = new System.Drawing.Size(1047, 126);
            this.pnlThanhToanDuoi.TabIndex = 7;
            // 
            // lblThueVAT
            // 
            this.lblThueVAT.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThueVAT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblThueVAT.Location = new System.Drawing.Point(753, 22);
            this.lblThueVAT.Name = "lblThueVAT";
            this.lblThueVAT.Size = new System.Drawing.Size(294, 20);
            this.lblThueVAT.TabIndex = 1;
            this.lblThueVAT.Text = "Thuế VAT (8%): 0 VNĐ";
            this.lblThueVAT.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btnXoaSanPham
            // 
            this.btnXoaSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaSanPham.BackColor = System.Drawing.Color.OrangeRed;
            this.btnXoaSanPham.FlatAppearance.BorderSize = 0;
            this.btnXoaSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSanPham.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaSanPham.ForeColor = System.Drawing.Color.White;
            this.btnXoaSanPham.Location = new System.Drawing.Point(917, 5);
            this.btnXoaSanPham.Name = "btnXoaSanPham";
            this.btnXoaSanPham.Size = new System.Drawing.Size(130, 35);
            this.btnXoaSanPham.TabIndex = 2;
            this.btnXoaSanPham.Text = "🗑 Xóa Sản Phẩm";
            this.btnXoaSanPham.UseVisualStyleBackColor = false;
            this.btnXoaSanPham.Click += new System.EventHandler(this.btnXoaSanPham_Click);
            // 
            // lblTieuDeChinh
            // 
            this.lblTieuDeChinh.AutoSize = true;
            this.lblTieuDeChinh.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeChinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTieuDeChinh.Location = new System.Drawing.Point(0, 0);
            this.lblTieuDeChinh.Name = "lblTieuDeChinh";
            this.lblTieuDeChinh.Size = new System.Drawing.Size(241, 37);
            this.lblTieuDeChinh.TabIndex = 0;
            this.lblTieuDeChinh.Text = "Lập Hóa Đơn Mới";
            // 
            // btnThemSanPham
            // 
            this.btnThemSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemSanPham.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnThemSanPham.FlatAppearance.BorderSize = 0;
            this.btnThemSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSanPham.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThemSanPham.ForeColor = System.Drawing.Color.White;
            this.btnThemSanPham.Location = new System.Drawing.Point(768, 5);
            this.btnThemSanPham.Name = "btnThemSanPham";
            this.btnThemSanPham.Size = new System.Drawing.Size(140, 35);
            this.btnThemSanPham.TabIndex = 1;
            this.btnThemSanPham.Text = "+ Thêm Sản Phẩm";
            this.btnThemSanPham.UseVisualStyleBackColor = false;
            this.btnThemSanPham.Click += new System.EventHandler(this.btnThemSanPham_Click);
            // 
            // txtTimKiemSanPham
            // 
            this.txtTimKiemSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiemSanPham.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiemSanPham.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiemSanPham.Location = new System.Drawing.Point(0, 9);
            this.txtTimKiemSanPham.Name = "txtTimKiemSanPham";
            this.txtTimKiemSanPham.Size = new System.Drawing.Size(753, 30);
            this.txtTimKiemSanPham.TabIndex = 0;
            this.txtTimKiemSanPham.Text = "Tìm kiếm sản phẩm theo tên hoặc mã...";
            this.txtTimKiemSanPham.TextChanged += new System.EventHandler(this.txtTimKiemSanPham_TextChanged);
            // 
            // btnCapNhatHoaDon
            // 
            this.btnCapNhatHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapNhatHoaDon.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnCapNhatHoaDon.FlatAppearance.BorderSize = 0;
            this.btnCapNhatHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCapNhatHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatHoaDon.Location = new System.Drawing.Point(836, 10);
            this.btnCapNhatHoaDon.Name = "btnCapNhatHoaDon";
            this.btnCapNhatHoaDon.Size = new System.Drawing.Size(160, 38);
            this.btnCapNhatHoaDon.TabIndex = 7;
            this.btnCapNhatHoaDon.Text = "🔄 Cập Nhật Hóa Đơn";
            this.btnCapNhatHoaDon.UseVisualStyleBackColor = false;
            this.btnCapNhatHoaDon.Click += new System.EventHandler(this.btnCapNhatHoaDon_Click);
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblKhachHang.Location = new System.Drawing.Point(687, 55);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(354, 25);
            this.lblKhachHang.TabIndex = 6;
            this.lblKhachHang.Text = "Khách Hàng: Khách vãng lai";
            this.lblKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNhanVien.Location = new System.Drawing.Point(3, 81);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(70, 16);
            this.lblNhanVien.TabIndex = 3;
            this.lblNhanVien.Text = "Nhân viên:";
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNgayLap.Location = new System.Drawing.Point(3, 61);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(69, 16);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Ngày Lập:";
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblMaHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblMaHoaDon.Location = new System.Drawing.Point(3, 38);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(230, 21);
            this.lblMaHoaDon.TabIndex = 1;
            this.lblMaHoaDon.Text = "Mã Hóa Đơn: HD-202608-001";
            // 
            // pnlThaoTacSP
            // 
            this.pnlThaoTacSP.Controls.Add(this.btnXoaSanPham);
            this.pnlThaoTacSP.Controls.Add(this.btnThemSanPham);
            this.pnlThaoTacSP.Controls.Add(this.txtTimKiemSanPham);
            this.pnlThaoTacSP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThaoTacSP.Location = new System.Drawing.Point(0, 107);
            this.pnlThaoTacSP.Name = "pnlThaoTacSP";
            this.pnlThaoTacSP.Size = new System.Drawing.Size(1047, 50);
            this.pnlThaoTacSP.TabIndex = 5;
            // 
            // pnlThongTinTren
            // 
            this.pnlThongTinTren.Controls.Add(this.btnCapNhatHoaDon);
            this.pnlThongTinTren.Controls.Add(this.lblKhachHang);
            this.pnlThongTinTren.Controls.Add(this.lblNhanVien);
            this.pnlThongTinTren.Controls.Add(this.lblNgayLap);
            this.pnlThongTinTren.Controls.Add(this.lblMaHoaDon);
            this.pnlThongTinTren.Controls.Add(this.lblTieuDeChinh);
            this.pnlThongTinTren.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongTinTren.Location = new System.Drawing.Point(0, 0);
            this.pnlThongTinTren.Name = "pnlThongTinTren";
            this.pnlThongTinTren.Size = new System.Drawing.Size(1047, 107);
            this.pnlThongTinTren.TabIndex = 4;
            // 
            // frmLapHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1047, 615);
            this.Controls.Add(this.dgvDanhSachSanPham);
            this.Controls.Add(this.pnlThanhToanDuoi);
            this.Controls.Add(this.pnlThaoTacSP);
            this.Controls.Add(this.pnlThongTinTren);
            this.Name = "frmLapHoaDon";
            this.Text = "frmLapHoaDon";
            this.Load += new System.EventHandler(this.frmLapHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSanPham)).EndInit();
            this.pnlThanhToanDuoi.ResumeLayout(false);
            this.pnlThaoTacSP.ResumeLayout(false);
            this.pnlThaoTacSP.PerformLayout();
            this.pnlThongTinTren.ResumeLayout(false);
            this.pnlThongTinTren.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnThanhToan1;
        private System.Windows.Forms.Button btnLuuNhap;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.Label lblTamTinh;
        private System.Windows.Forms.DataGridView dgvDanhSachSanPham;
        private System.Windows.Forms.Panel pnlThanhToanDuoi;
        private System.Windows.Forms.Label lblThueVAT;
        private System.Windows.Forms.Button btnXoaSanPham;
        private System.Windows.Forms.Label lblTieuDeChinh;
        private System.Windows.Forms.Button btnThemSanPham;
        private System.Windows.Forms.TextBox txtTimKiemSanPham;
        private System.Windows.Forms.Button btnCapNhatHoaDon;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.Panel pnlThaoTacSP;
        private System.Windows.Forms.Panel pnlThongTinTren;
    }
}