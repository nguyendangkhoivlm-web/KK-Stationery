namespace appquanlynhanviencuahang
{
    partial class frmChonSanPham
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            this.colDonViTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDonGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colTenSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.colMaSP = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dgvDanhSachSanPham = new System.Windows.Forms.DataGridView();
            this.colTonKho = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.pnlThaoTacDuoi = new System.Windows.Forms.Panel();
            this.btnXacNhanThem = new System.Windows.Forms.Button();
            this.btnHuyBo = new System.Windows.Forms.Button();
            this.numSoLuongChon = new System.Windows.Forms.NumericUpDown();
            this.lblSoLuong = new System.Windows.Forms.Label();
            this.lblSanPhamDangChon = new System.Windows.Forms.Label();
            this.lblLocDanhMuc = new System.Windows.Forms.Label();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.btnLamMoi = new System.Windows.Forms.Button();
            this.cboDanhMuc = new System.Windows.Forms.ComboBox();
            this.pnlThanhTimKiem = new System.Windows.Forms.Panel();
            this.lblTimKiem = new System.Windows.Forms.Label();
            this.btnDong = new System.Windows.Forms.Button();
            this.lblTieuDeTren = new System.Windows.Forms.Label();
            this.pnlThanhTieuDe = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSanPham)).BeginInit();
            this.pnlThaoTacDuoi.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongChon)).BeginInit();
            this.pnlThanhTimKiem.SuspendLayout();
            this.pnlThanhTieuDe.SuspendLayout();
            this.SuspendLayout();
            // 
            // colDonViTinh
            // 
            this.colDonViTinh.DataPropertyName = "DonViTinh";
            this.colDonViTinh.FillWeight = 70F;
            this.colDonViTinh.HeaderText = "Đơn vị tính";
            this.colDonViTinh.MinimumWidth = 6;
            this.colDonViTinh.Name = "colDonViTinh";
            this.colDonViTinh.ReadOnly = true;
            // 
            // colDonGia
            // 
            this.colDonGia.DataPropertyName = "DonGia";
            this.colDonGia.FillWeight = 90F;
            this.colDonGia.HeaderText = "Đơn giá (VNĐ)";
            this.colDonGia.MinimumWidth = 6;
            this.colDonGia.Name = "colDonGia";
            this.colDonGia.ReadOnly = true;
            // 
            // colDanhMuc
            // 
            this.colDanhMuc.DataPropertyName = "DanhMuc";
            this.colDanhMuc.HeaderText = "Danh mục";
            this.colDanhMuc.MinimumWidth = 6;
            this.colDanhMuc.Name = "colDanhMuc";
            this.colDanhMuc.ReadOnly = true;
            // 
            // colTenSP
            // 
            this.colTenSP.DataPropertyName = "TenSP";
            this.colTenSP.FillWeight = 180F;
            this.colTenSP.HeaderText = "Tên sản phẩm";
            this.colTenSP.MinimumWidth = 6;
            this.colTenSP.Name = "colTenSP";
            this.colTenSP.ReadOnly = true;
            // 
            // colMaSP
            // 
            this.colMaSP.DataPropertyName = "MaSP";
            this.colMaSP.FillWeight = 80F;
            this.colMaSP.HeaderText = "Mã SP";
            this.colMaSP.MinimumWidth = 6;
            this.colMaSP.Name = "colMaSP";
            this.colMaSP.ReadOnly = true;
            // 
            // dgvDanhSachSanPham
            // 
            this.dgvDanhSachSanPham.AllowUserToAddRows = false;
            this.dgvDanhSachSanPham.AllowUserToDeleteRows = false;
            this.dgvDanhSachSanPham.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachSanPham.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.dgvDanhSachSanPham.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDanhSachSanPham.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            dataGridViewCellStyle1.Padding = new System.Windows.Forms.Padding(4);
            dataGridViewCellStyle1.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            dataGridViewCellStyle1.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.dgvDanhSachSanPham.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvDanhSachSanPham.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachSanPham.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.colMaSP,
            this.colTenSP,
            this.colDanhMuc,
            this.colDonGia,
            this.colTonKho,
            this.colDonViTinh});
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.White;
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Segoe UI", 9.5F);
            dataGridViewCellStyle2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.Padding = new System.Windows.Forms.Padding(3);
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(238)))), ((int)(((byte)(242)))), ((int)(((byte)(255)))));
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvDanhSachSanPham.DefaultCellStyle = dataGridViewCellStyle2;
            this.dgvDanhSachSanPham.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSachSanPham.EnableHeadersVisualStyles = false;
            this.dgvDanhSachSanPham.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(226)))), ((int)(((byte)(232)))), ((int)(((byte)(240)))));
            this.dgvDanhSachSanPham.Location = new System.Drawing.Point(0, 120);
            this.dgvDanhSachSanPham.MultiSelect = false;
            this.dgvDanhSachSanPham.Name = "dgvDanhSachSanPham";
            this.dgvDanhSachSanPham.ReadOnly = true;
            this.dgvDanhSachSanPham.RowHeadersVisible = false;
            this.dgvDanhSachSanPham.RowHeadersWidth = 51;
            this.dgvDanhSachSanPham.RowTemplate.Height = 36;
            this.dgvDanhSachSanPham.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachSanPham.Size = new System.Drawing.Size(1110, 404);
            this.dgvDanhSachSanPham.TabIndex = 7;
            // 
            // colTonKho
            // 
            this.colTonKho.DataPropertyName = "TonKho";
            this.colTonKho.FillWeight = 70F;
            this.colTonKho.HeaderText = "Tồn kho";
            this.colTonKho.MinimumWidth = 6;
            this.colTonKho.Name = "colTonKho";
            this.colTonKho.ReadOnly = true;
            // 
            // pnlThaoTacDuoi
            // 
            this.pnlThaoTacDuoi.BackColor = System.Drawing.Color.White;
            this.pnlThaoTacDuoi.Controls.Add(this.btnXacNhanThem);
            this.pnlThaoTacDuoi.Controls.Add(this.btnHuyBo);
            this.pnlThaoTacDuoi.Controls.Add(this.numSoLuongChon);
            this.pnlThaoTacDuoi.Controls.Add(this.lblSoLuong);
            this.pnlThaoTacDuoi.Controls.Add(this.lblSanPhamDangChon);
            this.pnlThaoTacDuoi.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlThaoTacDuoi.Location = new System.Drawing.Point(0, 524);
            this.pnlThaoTacDuoi.Name = "pnlThaoTacDuoi";
            this.pnlThaoTacDuoi.Size = new System.Drawing.Size(1110, 70);
            this.pnlThaoTacDuoi.TabIndex = 6;
            // 
            // btnXacNhanThem
            // 
            this.btnXacNhanThem.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXacNhanThem.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnXacNhanThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXacNhanThem.FlatAppearance.BorderSize = 0;
            this.btnXacNhanThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXacNhanThem.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnXacNhanThem.ForeColor = System.Drawing.Color.White;
            this.btnXacNhanThem.Location = new System.Drawing.Point(866, 14);
            this.btnXacNhanThem.Name = "btnXacNhanThem";
            this.btnXacNhanThem.Size = new System.Drawing.Size(225, 42);
            this.btnXacNhanThem.TabIndex = 4;
            this.btnXacNhanThem.Text = "✔ Chọn Vào Hóa Đơn";
            this.btnXacNhanThem.UseVisualStyleBackColor = false;
            // 
            // btnHuyBo
            // 
            this.btnHuyBo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.btnHuyBo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnHuyBo.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyBo.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnHuyBo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyBo.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnHuyBo.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnHuyBo.Location = new System.Drawing.Point(746, 14);
            this.btnHuyBo.Name = "btnHuyBo";
            this.btnHuyBo.Size = new System.Drawing.Size(105, 42);
            this.btnHuyBo.TabIndex = 3;
            this.btnHuyBo.Text = "Hủy";
            this.btnHuyBo.UseVisualStyleBackColor = false;
            this.btnHuyBo.Click += new System.EventHandler(this.btnHuyBo_Click_1);
            // 
            // numSoLuongChon
            // 
            this.numSoLuongChon.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.numSoLuongChon.Location = new System.Drawing.Point(490, 20);
            this.numSoLuongChon.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numSoLuongChon.Name = "numSoLuongChon";
            this.numSoLuongChon.Size = new System.Drawing.Size(90, 32);
            this.numSoLuongChon.TabIndex = 2;
            this.numSoLuongChon.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numSoLuongChon.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // lblSoLuong
            // 
            this.lblSoLuong.AutoSize = true;
            this.lblSoLuong.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.lblSoLuong.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblSoLuong.Location = new System.Drawing.Point(400, 24);
            this.lblSoLuong.Name = "lblSoLuong";
            this.lblSoLuong.Size = new System.Drawing.Size(88, 23);
            this.lblSoLuong.TabIndex = 1;
            this.lblSoLuong.Text = "Số lượng:";
            // 
            // lblSanPhamDangChon
            // 
            this.lblSanPhamDangChon.AutoSize = true;
            this.lblSanPhamDangChon.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Italic);
            this.lblSanPhamDangChon.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblSanPhamDangChon.Location = new System.Drawing.Point(20, 24);
            this.lblSanPhamDangChon.Name = "lblSanPhamDangChon";
            this.lblSanPhamDangChon.Size = new System.Drawing.Size(212, 23);
            this.lblSanPhamDangChon.TabIndex = 0;
            this.lblSanPhamDangChon.Text = "Chưa chọn sản phẩm nào...";
            // 
            // lblLocDanhMuc
            // 
            this.lblLocDanhMuc.AutoSize = true;
            this.lblLocDanhMuc.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblLocDanhMuc.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblLocDanhMuc.Location = new System.Drawing.Point(485, 23);
            this.lblLocDanhMuc.Name = "lblLocDanhMuc";
            this.lblLocDanhMuc.Size = new System.Drawing.Size(92, 21);
            this.lblLocDanhMuc.TabIndex = 2;
            this.lblLocDanhMuc.Text = "Danh mục:";
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.txtTimKiem.Location = new System.Drawing.Point(105, 18);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(350, 30);
            this.txtTimKiem.TabIndex = 1;
            // 
            // btnLamMoi
            // 
            this.btnLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnLamMoi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnLamMoi.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLamMoi.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnLamMoi.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(51)))), ((int)(((byte)(65)))), ((int)(((byte)(85)))));
            this.btnLamMoi.Location = new System.Drawing.Point(966, 16);
            this.btnLamMoi.Name = "btnLamMoi";
            this.btnLamMoi.Size = new System.Drawing.Size(125, 34);
            this.btnLamMoi.TabIndex = 4;
            this.btnLamMoi.Text = "🔄 Làm mới";
            this.btnLamMoi.UseVisualStyleBackColor = false;
            // 
            // cboDanhMuc
            // 
            this.cboDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboDanhMuc.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.cboDanhMuc.FormattingEnabled = true;
            this.cboDanhMuc.Location = new System.Drawing.Point(580, 18);
            this.cboDanhMuc.Name = "cboDanhMuc";
            this.cboDanhMuc.Size = new System.Drawing.Size(200, 31);
            this.cboDanhMuc.TabIndex = 3;
            // 
            // pnlThanhTimKiem
            // 
            this.pnlThanhTimKiem.BackColor = System.Drawing.Color.White;
            this.pnlThanhTimKiem.Controls.Add(this.btnLamMoi);
            this.pnlThanhTimKiem.Controls.Add(this.cboDanhMuc);
            this.pnlThanhTimKiem.Controls.Add(this.lblLocDanhMuc);
            this.pnlThanhTimKiem.Controls.Add(this.txtTimKiem);
            this.pnlThanhTimKiem.Controls.Add(this.lblTimKiem);
            this.pnlThanhTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThanhTimKiem.Location = new System.Drawing.Point(0, 55);
            this.pnlThanhTimKiem.Name = "pnlThanhTimKiem";
            this.pnlThanhTimKiem.Size = new System.Drawing.Size(1110, 65);
            this.pnlThanhTimKiem.TabIndex = 5;
            // 
            // lblTimKiem
            // 
            this.lblTimKiem.AutoSize = true;
            this.lblTimKiem.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.lblTimKiem.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblTimKiem.Location = new System.Drawing.Point(20, 23);
            this.lblTimKiem.Name = "lblTimKiem";
            this.lblTimKiem.Size = new System.Drawing.Size(85, 21);
            this.lblTimKiem.TabIndex = 0;
            this.lblTimKiem.Text = "Tìm kiếm:";
            // 
            // btnDong
            // 
            this.btnDong.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnDong.FlatAppearance.BorderSize = 0;
            this.btnDong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDong.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
            this.btnDong.ForeColor = System.Drawing.Color.White;
            this.btnDong.Location = new System.Drawing.Point(1010, 10);
            this.btnDong.Name = "btnDong";
            this.btnDong.Size = new System.Drawing.Size(88, 35);
            this.btnDong.TabIndex = 1;
            this.btnDong.Text = "✖ Đóng";
            this.btnDong.UseVisualStyleBackColor = true;
            // 
            // lblTieuDeTren
            // 
            this.lblTieuDeTren.AutoSize = true;
            this.lblTieuDeTren.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTren.ForeColor = System.Drawing.Color.White;
            this.lblTieuDeTren.Location = new System.Drawing.Point(20, 13);
            this.lblTieuDeTren.Name = "lblTieuDeTren";
            this.lblTieuDeTren.Size = new System.Drawing.Size(283, 32);
            this.lblTieuDeTren.TabIndex = 0;
            this.lblTieuDeTren.Text = "📦 Chọn Sản Phẩm Bán";
            // 
            // pnlThanhTieuDe
            // 
            this.pnlThanhTieuDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlThanhTieuDe.Controls.Add(this.btnDong);
            this.pnlThanhTieuDe.Controls.Add(this.lblTieuDeTren);
            this.pnlThanhTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThanhTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnlThanhTieuDe.Name = "pnlThanhTieuDe";
            this.pnlThanhTieuDe.Size = new System.Drawing.Size(1110, 55);
            this.pnlThanhTieuDe.TabIndex = 4;
            // 
            // frmChonSanPham
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1110, 594);
            this.Controls.Add(this.dgvDanhSachSanPham);
            this.Controls.Add(this.pnlThaoTacDuoi);
            this.Controls.Add(this.pnlThanhTimKiem);
            this.Controls.Add(this.pnlThanhTieuDe);
            this.Name = "frmChonSanPham";
            this.Text = "frmChonSanPham";
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSanPham)).EndInit();
            this.pnlThaoTacDuoi.ResumeLayout(false);
            this.pnlThaoTacDuoi.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numSoLuongChon)).EndInit();
            this.pnlThanhTimKiem.ResumeLayout(false);
            this.pnlThanhTimKiem.PerformLayout();
            this.pnlThanhTieuDe.ResumeLayout(false);
            this.pnlThanhTieuDe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn colDonViTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDonGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn colDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTenSP;
        private System.Windows.Forms.DataGridViewTextBoxColumn colMaSP;
        private System.Windows.Forms.DataGridView dgvDanhSachSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn colTonKho;
        private System.Windows.Forms.Panel pnlThaoTacDuoi;
        private System.Windows.Forms.Button btnXacNhanThem;
        private System.Windows.Forms.Button btnHuyBo;
        private System.Windows.Forms.NumericUpDown numSoLuongChon;
        private System.Windows.Forms.Label lblSoLuong;
        private System.Windows.Forms.Label lblSanPhamDangChon;
        private System.Windows.Forms.Label lblLocDanhMuc;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Button btnLamMoi;
        private System.Windows.Forms.ComboBox cboDanhMuc;
        private System.Windows.Forms.Panel pnlThanhTimKiem;
        private System.Windows.Forms.Label lblTimKiem;
        private System.Windows.Forms.Button btnDong;
        private System.Windows.Forms.Label lblTieuDeTren;
        private System.Windows.Forms.Panel pnlThanhTieuDe;
    }
}