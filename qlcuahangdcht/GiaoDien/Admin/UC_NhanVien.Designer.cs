namespace qlcuahangdcht
{
    partial class UC_NhanVien
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            this.VaiTro = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnCapTaiKhoan = new System.Windows.Forms.Button();
            this.btnThemNv = new System.Windows.Forms.Button();
            this.btnXoaNv = new System.Windows.Forms.Button();
            this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SDT = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.NgaySinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.GioiTinh = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HoTen = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MaNhanVien = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDanhSachNv = new System.Windows.Forms.DataGridView();
            this.DiaChi = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.cboLocChucVu = new System.Windows.Forms.ComboBox();
            this.txtTimKiemNv = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNv)).BeginInit();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // VaiTro
            // 
            this.VaiTro.FillWeight = 80F;
            this.VaiTro.HeaderText = "Vai trò";
            this.VaiTro.MinimumWidth = 6;
            this.VaiTro.Name = "VaiTro";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnCapTaiKhoan);
            this.panel2.Controls.Add(this.btnThemNv);
            this.panel2.Controls.Add(this.btnXoaNv);
            this.panel2.Location = new System.Drawing.Point(608, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(574, 115);
            this.panel2.TabIndex = 2;
            // 
            // btnCapTaiKhoan
            // 
            this.btnCapTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapTaiKhoan.AutoSize = true;
            this.btnCapTaiKhoan.BackColor = System.Drawing.Color.Orange;
            this.btnCapTaiKhoan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapTaiKhoan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapTaiKhoan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapTaiKhoan.ForeColor = System.Drawing.Color.White;
            this.btnCapTaiKhoan.Location = new System.Drawing.Point(216, 79);
            this.btnCapTaiKhoan.Name = "btnCapTaiKhoan";
            this.btnCapTaiKhoan.Size = new System.Drawing.Size(171, 34);
            this.btnCapTaiKhoan.TabIndex = 10;
            this.btnCapTaiKhoan.Text = "🔑 Cấp tài khoản";
            this.btnCapTaiKhoan.UseVisualStyleBackColor = false;
            this.btnCapTaiKhoan.Click += new System.EventHandler(this.btnCapTaiKhoan_Click);
            // 
            // btnThemNv
            // 
            this.btnThemNv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemNv.AutoSize = true;
            this.btnThemNv.BackColor = System.Drawing.Color.Green;
            this.btnThemNv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemNv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemNv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemNv.ForeColor = System.Drawing.Color.White;
            this.btnThemNv.Location = new System.Drawing.Point(16, 79);
            this.btnThemNv.Name = "btnThemNv";
            this.btnThemNv.Size = new System.Drawing.Size(187, 34);
            this.btnThemNv.TabIndex = 9;
            this.btnThemNv.Text = "+ Thêm nhân viên";
            this.btnThemNv.UseVisualStyleBackColor = false;
            this.btnThemNv.Click += new System.EventHandler(this.btnThemNv_Click);
            // 
            // btnXoaNv
            // 
            this.btnXoaNv.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaNv.AutoSize = true;
            this.btnXoaNv.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoaNv.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaNv.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaNv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaNv.ForeColor = System.Drawing.Color.White;
            this.btnXoaNv.Location = new System.Drawing.Point(401, 79);
            this.btnXoaNv.Name = "btnXoaNv";
            this.btnXoaNv.Size = new System.Drawing.Size(170, 34);
            this.btnXoaNv.TabIndex = 11;
            this.btnXoaNv.Text = "🗑 Xóa nhân viên";
            this.btnXoaNv.UseVisualStyleBackColor = false;
            // 
            // Email
            // 
            this.Email.HeaderText = "Email";
            this.Email.MinimumWidth = 6;
            this.Email.Name = "Email";
            // 
            // SDT
            // 
            this.SDT.HeaderText = "Số điện thoại";
            this.SDT.MinimumWidth = 6;
            this.SDT.Name = "SDT";
            // 
            // NgaySinh
            // 
            dataGridViewCellStyle3.Format = "dd/MM/yyyy";
            this.NgaySinh.DefaultCellStyle = dataGridViewCellStyle3;
            this.NgaySinh.HeaderText = "Ngày sinh";
            this.NgaySinh.MinimumWidth = 6;
            this.NgaySinh.Name = "NgaySinh";
            // 
            // GioiTinh
            // 
            this.GioiTinh.FillWeight = 55F;
            this.GioiTinh.HeaderText = "Giới tính";
            this.GioiTinh.MinimumWidth = 6;
            this.GioiTinh.Name = "GioiTinh";
            // 
            // HoTen
            // 
            this.HoTen.HeaderText = "Họ và tên";
            this.HoTen.MinimumWidth = 6;
            this.HoTen.Name = "HoTen";
            // 
            // MaNhanVien
            // 
            this.MaNhanVien.FillWeight = 90F;
            this.MaNhanVien.HeaderText = "Mã NV";
            this.MaNhanVien.MinimumWidth = 6;
            this.MaNhanVien.Name = "MaNhanVien";
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvDanhSachNv);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 135);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(1192, 600);
            this.panel3.TabIndex = 11;
            // 
            // dgvDanhSachNv
            // 
            this.dgvDanhSachNv.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachNv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachNv.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachNv.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaNhanVien,
            this.HoTen,
            this.GioiTinh,
            this.NgaySinh,
            this.SDT,
            this.Email,
            this.DiaChi,
            this.VaiTro});
            this.dgvDanhSachNv.Location = new System.Drawing.Point(9, 10);
            this.dgvDanhSachNv.Name = "dgvDanhSachNv";
            this.dgvDanhSachNv.RowHeadersVisible = false;
            this.dgvDanhSachNv.RowHeadersWidth = 51;
            this.dgvDanhSachNv.RowTemplate.Height = 24;
            this.dgvDanhSachNv.Size = new System.Drawing.Size(1172, 527);
            this.dgvDanhSachNv.TabIndex = 3;
            // 
            // DiaChi
            // 
            this.DiaChi.HeaderText = "Địa chỉ";
            this.DiaChi.MinimumWidth = 6;
            this.DiaChi.Name = "DiaChi";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.cboLocChucVu);
            this.panel1.Controls.Add(this.txtTimKiemNv);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(598, 115);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(13, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(86, 22);
            this.label1.TabIndex = 10;
            this.label1.Text = "Chức vụ: ";
            // 
            // cboLocChucVu
            // 
            this.cboLocChucVu.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocChucVu.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocChucVu.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocChucVu.FormattingEnabled = true;
            this.cboLocChucVu.Location = new System.Drawing.Point(105, 82);
            this.cboLocChucVu.Name = "cboLocChucVu";
            this.cboLocChucVu.Size = new System.Drawing.Size(195, 30);
            this.cboLocChucVu.TabIndex = 9;
            // 
            // txtTimKiemNv
            // 
            this.txtTimKiemNv.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemNv.ForeColor = System.Drawing.Color.Silver;
            this.txtTimKiemNv.Location = new System.Drawing.Point(15, 3);
            this.txtTimKiemNv.Name = "txtTimKiemNv";
            this.txtTimKiemNv.Size = new System.Drawing.Size(285, 28);
            this.txtTimKiemNv.TabIndex = 8;
            this.txtTimKiemNv.Text = "Tìm kiếm nhân viên...";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle());
            this.tableLayoutPanel1.Controls.Add(this.panel2, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.panel1, 0, 0);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.Padding = new System.Windows.Forms.Padding(10);
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.tableLayoutPanel1.Size = new System.Drawing.Size(1192, 135);
            this.tableLayoutPanel1.TabIndex = 10;
            // 
            // UC_NhanVien
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_NhanVien";
            this.Size = new System.Drawing.Size(1192, 735);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachNv)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridViewTextBoxColumn VaiTro;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnCapTaiKhoan;
        private System.Windows.Forms.Button btnThemNv;
        private System.Windows.Forms.Button btnXoaNv;
        private System.Windows.Forms.DataGridViewTextBoxColumn Email;
        private System.Windows.Forms.DataGridViewTextBoxColumn SDT;
        private System.Windows.Forms.DataGridViewTextBoxColumn NgaySinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn GioiTinh;
        private System.Windows.Forms.DataGridViewTextBoxColumn HoTen;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaNhanVien;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.DataGridView dgvDanhSachNv;
        private System.Windows.Forms.DataGridViewTextBoxColumn DiaChi;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cboLocChucVu;
        private System.Windows.Forms.TextBox txtTimKiemNv;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
    }
}
