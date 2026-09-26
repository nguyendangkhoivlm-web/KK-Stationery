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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle9 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle10 = new System.Windows.Forms.DataGridViewCellStyle();
            this.dgvDanhSachSanPham = new System.Windows.Forms.DataGridView();
            this.btnTroLaiTrangTruoc = new System.Windows.Forms.Button();
            this.btnLuuNhap = new System.Windows.Forms.Button();
            this.lblTongCong = new System.Windows.Forms.Label();
            this.lblThueVAT = new System.Windows.Forms.Label();
            this.pnlThanhToanDuoi = new System.Windows.Forms.Panel();
            this.btnThanhToan1 = new System.Windows.Forms.Button();
            this.lblTamTinh = new System.Windows.Forms.Label();
            this.pnlThaoTacSP = new System.Windows.Forms.Panel();
            this.btnXoaSanPham = new System.Windows.Forms.Button();
            this.btnThemSanPham = new System.Windows.Forms.Button();
            this.txtTimKiemSanPham = new System.Windows.Forms.TextBox();
            this.lblMaHoaDon = new System.Windows.Forms.Label();
            this.btnCapNhatHoaDon = new System.Windows.Forms.Button();
            this.lblKhachHang = new System.Windows.Forms.Label();
            this.lblNhanVien = new System.Windows.Forms.Label();
            this.lblNgayLap = new System.Windows.Forms.Label();
            this.pnlThongTinTren = new System.Windows.Forms.Panel();
            this.lblTieuDeChinh = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSanPham)).BeginInit();
            this.pnlThanhToanDuoi.SuspendLayout();
            this.pnlThaoTacSP.SuspendLayout();
            this.pnlThongTinTren.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDanhSachSanPham
            // 
            this.dgvDanhSachSanPham.AllowUserToAddRows = false;
            this.dgvDanhSachSanPham.AllowUserToDeleteRows = false;
            this.dgvDanhSachSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachSanPham.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachSanPham.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle9.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle9.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle9.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle9.Padding = new System.Windows.Forms.Padding(6);
            dataGridViewCellStyle9.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle9.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle9.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvDanhSachSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle9;
            this.dgvDanhSachSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle10.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle10.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle10.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle10.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle10.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle10.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle10.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSachSanPham.DefaultCellStyle = dataGridViewCellStyle10;
            this.dgvDanhSachSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSachSanPham.EnableHeadersVisualStyles = false;
            this.dgvDanhSachSanPham.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvDanhSachSanPham.Location = new System.Drawing.Point(0, 185);
            this.dgvDanhSachSanPham.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.dgvDanhSachSanPham.Name = "dgvDanhSachSanPham";
            this.dgvDanhSachSanPham.ReadOnly = true;
            this.dgvDanhSachSanPham.RowHeadersVisible = false;
            this.dgvDanhSachSanPham.RowHeadersWidth = 51;
            this.dgvDanhSachSanPham.RowTemplate.Height = 38;
            this.dgvDanhSachSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachSanPham.Size = new System.Drawing.Size(1154, 365);
            this.dgvDanhSachSanPham.TabIndex = 6;
            // 
            // btnTroLaiTrangTruoc
            // 
            this.btnTroLaiTrangTruoc.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnTroLaiTrangTruoc.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTroLaiTrangTruoc.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnTroLaiTrangTruoc.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTroLaiTrangTruoc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTroLaiTrangTruoc.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnTroLaiTrangTruoc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnTroLaiTrangTruoc.Location = new System.Drawing.Point(656, 76);
            this.btnTroLaiTrangTruoc.Name = "btnTroLaiTrangTruoc";
            this.btnTroLaiTrangTruoc.Size = new System.Drawing.Size(130, 44);
            this.btnTroLaiTrangTruoc.TabIndex = 5;
            this.btnTroLaiTrangTruoc.Text = "⬅  Quay Lại";
            this.btnTroLaiTrangTruoc.UseVisualStyleBackColor = false;
            // 
            // btnLuuNhap
            // 
            this.btnLuuNhap.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLuuNhap.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnLuuNhap.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLuuNhap.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnLuuNhap.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLuuNhap.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnLuuNhap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnLuuNhap.Location = new System.Drawing.Point(798, 76);
            this.btnLuuNhap.Name = "btnLuuNhap";
            this.btnLuuNhap.Size = new System.Drawing.Size(135, 44);
            this.btnLuuNhap.TabIndex = 4;
            this.btnLuuNhap.Text = "💾  Lưu Nháp";
            this.btnLuuNhap.UseVisualStyleBackColor = false;
            // 
            // lblTongCong
            // 
            this.lblTongCong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTongCong.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTongCong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblTongCong.Location = new System.Drawing.Point(622, 12);
            this.lblTongCong.Name = "lblTongCong";
            this.lblTongCong.Size = new System.Drawing.Size(512, 50);
            this.lblTongCong.TabIndex = 2;
            this.lblTongCong.Text = "Tổng cộng: 0 VNĐ";
            this.lblTongCong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblThueVAT
            // 
            this.lblThueVAT.AutoSize = true;
            this.lblThueVAT.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblThueVAT.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblThueVAT.Location = new System.Drawing.Point(20, 52);
            this.lblThueVAT.Name = "lblThueVAT";
            this.lblThueVAT.Size = new System.Drawing.Size(202, 28);
            this.lblThueVAT.TabIndex = 1;
            this.lblThueVAT.Text = "Thuế VAT (8%): 0 VNĐ";
            // 
            // pnlThanhToanDuoi
            // 
            this.pnlThanhToanDuoi.BackColor = System.Drawing.Color.White;
            this.pnlThanhToanDuoi.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThanhToanDuoi.Controls.Add(this.btnTroLaiTrangTruoc);
            this.pnlThanhToanDuoi.Controls.Add(this.btnLuuNhap);
            this.pnlThanhToanDuoi.Controls.Add(this.btnThanhToan1);
            this.pnlThanhToanDuoi.Controls.Add(this.lblTongCong);
            this.pnlThanhToanDuoi.Controls.Add(this.lblThueVAT);
            this.pnlThanhToanDuoi.Controls.Add(this.lblTamTinh);
            this.pnlThanhToanDuoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThanhToanDuoi.Location = new System.Drawing.Point(0, 550);
            this.pnlThanhToanDuoi.Margin = new System.Windows.Forms.Padding(0, 8, 0, 0);
            this.pnlThanhToanDuoi.Name = "pnlThanhToanDuoi";
            this.pnlThanhToanDuoi.Padding = new System.Windows.Forms.Padding(18, 12, 18, 12);
            this.pnlThanhToanDuoi.Size = new System.Drawing.Size(1154, 134);
            this.pnlThanhToanDuoi.TabIndex = 7;
            // 
            // btnThanhToan1
            // 
            this.btnThanhToan1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThanhToan1.BackColor = System.Drawing.Color.LimeGreen;
            this.btnThanhToan1.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThanhToan1.FlatAppearance.BorderSize = 0;
            this.btnThanhToan1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThanhToan1.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnThanhToan1.ForeColor = System.Drawing.Color.White;
            this.btnThanhToan1.Location = new System.Drawing.Point(945, 76);
            this.btnThanhToan1.Name = "btnThanhToan1";
            this.btnThanhToan1.Size = new System.Drawing.Size(189, 44);
            this.btnThanhToan1.TabIndex = 3;
            this.btnThanhToan1.Text = "💳  Thanh Toán";
            this.btnThanhToan1.UseVisualStyleBackColor = false;
            // 
            // lblTamTinh
            // 
            this.lblTamTinh.AutoSize = true;
            this.lblTamTinh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTamTinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblTamTinh.Location = new System.Drawing.Point(20, 18);
            this.lblTamTinh.Name = "lblTamTinh";
            this.lblTamTinh.Size = new System.Drawing.Size(154, 28);
            this.lblTamTinh.TabIndex = 0;
            this.lblTamTinh.Text = "Tạm tính: 0 VNĐ";
            // 
            // pnlThaoTacSP
            // 
            this.pnlThaoTacSP.BackColor = System.Drawing.Color.White;
            this.pnlThaoTacSP.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThaoTacSP.Controls.Add(this.btnXoaSanPham);
            this.pnlThaoTacSP.Controls.Add(this.btnThemSanPham);
            this.pnlThaoTacSP.Controls.Add(this.txtTimKiemSanPham);
            this.pnlThaoTacSP.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThaoTacSP.Location = new System.Drawing.Point(0, 122);
            this.pnlThaoTacSP.Margin = new System.Windows.Forms.Padding(0, 8, 0, 8);
            this.pnlThaoTacSP.Name = "pnlThaoTacSP";
            this.pnlThaoTacSP.Padding = new System.Windows.Forms.Padding(14, 8, 14, 8);
            this.pnlThaoTacSP.Size = new System.Drawing.Size(1154, 63);
            this.pnlThaoTacSP.TabIndex = 5;
            // 
            // btnXoaSanPham
            // 
            this.btnXoaSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaSanPham.BackColor = System.Drawing.Color.OrangeRed;
            this.btnXoaSanPham.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaSanPham.FlatAppearance.BorderSize = 0;
            this.btnXoaSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSanPham.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaSanPham.ForeColor = System.Drawing.Color.White;
            this.btnXoaSanPham.Location = new System.Drawing.Point(996, 9);
            this.btnXoaSanPham.Name = "btnXoaSanPham";
            this.btnXoaSanPham.Size = new System.Drawing.Size(142, 38);
            this.btnXoaSanPham.TabIndex = 2;
            this.btnXoaSanPham.Text = "🗑  Xóa Sản Phẩm";
            this.btnXoaSanPham.UseVisualStyleBackColor = false;
            // 
            // btnThemSanPham
            // 
            this.btnThemSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemSanPham.BackColor = System.Drawing.Color.LimeGreen;
            this.btnThemSanPham.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemSanPham.FlatAppearance.BorderSize = 0;
            this.btnThemSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSanPham.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThemSanPham.ForeColor = System.Drawing.Color.White;
            this.btnThemSanPham.Location = new System.Drawing.Point(830, 9);
            this.btnThemSanPham.Name = "btnThemSanPham";
            this.btnThemSanPham.Size = new System.Drawing.Size(158, 38);
            this.btnThemSanPham.TabIndex = 1;
            this.btnThemSanPham.Text = "➕  Thêm Sản Phẩm";
            this.btnThemSanPham.UseVisualStyleBackColor = false;
            // 
            // txtTimKiemSanPham
            // 
            this.txtTimKiemSanPham.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtTimKiemSanPham.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.txtTimKiemSanPham.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtTimKiemSanPham.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTimKiemSanPham.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.txtTimKiemSanPham.Location = new System.Drawing.Point(14, 13);
            this.txtTimKiemSanPham.Name = "txtTimKiemSanPham";
            this.txtTimKiemSanPham.Size = new System.Drawing.Size(798, 31);
            this.txtTimKiemSanPham.TabIndex = 0;
            this.txtTimKiemSanPham.Text = "Tìm kiếm sản phẩm theo tên hoặc mã...";
            // 
            // lblMaHoaDon
            // 
            this.lblMaHoaDon.AutoSize = true;
            this.lblMaHoaDon.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblMaHoaDon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(217)))), ((int)(((byte)(119)))), ((int)(((byte)(6)))));
            this.lblMaHoaDon.Location = new System.Drawing.Point(20, 52);
            this.lblMaHoaDon.Name = "lblMaHoaDon";
            this.lblMaHoaDon.Size = new System.Drawing.Size(260, 25);
            this.lblMaHoaDon.TabIndex = 1;
            this.lblMaHoaDon.Text = "Mã Hóa Đơn: HD-202608-001";
            // 
            // btnCapNhatHoaDon
            // 
            this.btnCapNhatHoaDon.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapNhatHoaDon.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.btnCapNhatHoaDon.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapNhatHoaDon.FlatAppearance.BorderSize = 0;
            this.btnCapNhatHoaDon.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatHoaDon.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnCapNhatHoaDon.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatHoaDon.Location = new System.Drawing.Point(952, 16);
            this.btnCapNhatHoaDon.Name = "btnCapNhatHoaDon";
            this.btnCapNhatHoaDon.Size = new System.Drawing.Size(182, 38);
            this.btnCapNhatHoaDon.TabIndex = 5;
            this.btnCapNhatHoaDon.Text = "🔄 Cập Nhật Hóa Đơn";
            this.btnCapNhatHoaDon.UseVisualStyleBackColor = false;
            // 
            // lblKhachHang
            // 
            this.lblKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblKhachHang.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.lblKhachHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblKhachHang.Location = new System.Drawing.Point(682, 68);
            this.lblKhachHang.Name = "lblKhachHang";
            this.lblKhachHang.Size = new System.Drawing.Size(452, 28);
            this.lblKhachHang.TabIndex = 4;
            this.lblKhachHang.Text = "👤 Khách Hàng: Khách vãng lai";
            this.lblKhachHang.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblNhanVien
            // 
            this.lblNhanVien.AutoSize = true;
            this.lblNhanVien.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNhanVien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNhanVien.Location = new System.Drawing.Point(260, 80);
            this.lblNhanVien.Name = "lblNhanVien";
            this.lblNhanVien.Size = new System.Drawing.Size(122, 21);
            this.lblNhanVien.TabIndex = 3;
            this.lblNhanVien.Text = "Thu ngân: NV01";
            // 
            // lblNgayLap
            // 
            this.lblNgayLap.AutoSize = true;
            this.lblNgayLap.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            this.lblNgayLap.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblNgayLap.Location = new System.Drawing.Point(20, 80);
            this.lblNgayLap.Name = "lblNgayLap";
            this.lblNgayLap.Size = new System.Drawing.Size(75, 21);
            this.lblNgayLap.TabIndex = 2;
            this.lblNgayLap.Text = "Ngày lập:";
            // 
            // pnlThongTinTren
            // 
            this.pnlThongTinTren.BackColor = System.Drawing.Color.White;
            this.pnlThongTinTren.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlThongTinTren.Controls.Add(this.btnCapNhatHoaDon);
            this.pnlThongTinTren.Controls.Add(this.lblKhachHang);
            this.pnlThongTinTren.Controls.Add(this.lblNhanVien);
            this.pnlThongTinTren.Controls.Add(this.lblNgayLap);
            this.pnlThongTinTren.Controls.Add(this.lblMaHoaDon);
            this.pnlThongTinTren.Controls.Add(this.lblTieuDeChinh);
            this.pnlThongTinTren.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThongTinTren.Location = new System.Drawing.Point(0, 0);
            this.pnlThongTinTren.Name = "pnlThongTinTren";
            this.pnlThongTinTren.Padding = new System.Windows.Forms.Padding(18, 14, 18, 14);
            this.pnlThongTinTren.Size = new System.Drawing.Size(1154, 122);
            this.pnlThongTinTren.TabIndex = 4;
            // 
            // lblTieuDeChinh
            // 
            this.lblTieuDeChinh.AutoSize = true;
            this.lblTieuDeChinh.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeChinh.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.lblTieuDeChinh.Location = new System.Drawing.Point(18, 12);
            this.lblTieuDeChinh.Name = "lblTieuDeChinh";
            this.lblTieuDeChinh.Size = new System.Drawing.Size(286, 37);
            this.lblTieuDeChinh.TabIndex = 0;
            this.lblTieuDeChinh.Text = "🧾 Lập Hóa Đơn Mới";
            // 
            // frmLapHoaDon
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1154, 684);
            this.Controls.Add(this.dgvDanhSachSanPham);
            this.Controls.Add(this.pnlThanhToanDuoi);
            this.Controls.Add(this.pnlThaoTacSP);
            this.Controls.Add(this.pnlThongTinTren);
            this.Name = "frmLapHoaDon";
            this.Text = "frmLapHoaDon";
            this.Load += new System.EventHandler(this.frmLapHoaDon_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSanPham)).EndInit();
            this.pnlThanhToanDuoi.ResumeLayout(false);
            this.pnlThanhToanDuoi.PerformLayout();
            this.pnlThaoTacSP.ResumeLayout(false);
            this.pnlThaoTacSP.PerformLayout();
            this.pnlThongTinTren.ResumeLayout(false);
            this.pnlThongTinTren.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDanhSachSanPham;
        private System.Windows.Forms.Button btnTroLaiTrangTruoc;
        private System.Windows.Forms.Button btnLuuNhap;
        private System.Windows.Forms.Label lblTongCong;
        private System.Windows.Forms.Label lblThueVAT;
        private System.Windows.Forms.Panel pnlThanhToanDuoi;
        private System.Windows.Forms.Button btnThanhToan1;
        private System.Windows.Forms.Label lblTamTinh;
        private System.Windows.Forms.Panel pnlThaoTacSP;
        private System.Windows.Forms.Button btnXoaSanPham;
        private System.Windows.Forms.Button btnThemSanPham;
        private System.Windows.Forms.TextBox txtTimKiemSanPham;
        private System.Windows.Forms.Label lblMaHoaDon;
        private System.Windows.Forms.Button btnCapNhatHoaDon;
        private System.Windows.Forms.Label lblKhachHang;
        private System.Windows.Forms.Label lblNhanVien;
        private System.Windows.Forms.Label lblNgayLap;
        private System.Windows.Forms.Panel pnlThongTinTren;
        private System.Windows.Forms.Label lblTieuDeChinh;
    }
}