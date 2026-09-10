namespace qlcuahangdcht
{
    partial class UC_SanPham
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.cboLocDanhMuc = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtTimKiemSp = new System.Windows.Forms.TextBox();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnXoaSp = new System.Windows.Forms.Button();
            this.btnCapNhatSp = new System.Windows.Forms.Button();
            this.btnThemSp = new System.Windows.Forms.Button();
            this.panel3 = new System.Windows.Forms.Panel();
            this.dgvDanhSachSp = new System.Windows.Forms.DataGridView();
            this.MaSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenSanPham = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TenDanhMuc = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DongGia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SoLuongTon = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TrangThai = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.panel1.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSp)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.cboLocDanhMuc);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.txtTimKiemSp);
            this.panel1.Location = new System.Drawing.Point(10, 10);
            this.panel1.Margin = new System.Windows.Forms.Padding(0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(758, 115);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // cboLocDanhMuc
            // 
            this.cboLocDanhMuc.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboLocDanhMuc.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.cboLocDanhMuc.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboLocDanhMuc.FormattingEnabled = true;
            this.cboLocDanhMuc.Location = new System.Drawing.Point(107, 80);
            this.cboLocDanhMuc.MinimumSize = new System.Drawing.Size(225, 0);
            this.cboLocDanhMuc.Name = "cboLocDanhMuc";
            this.cboLocDanhMuc.Size = new System.Drawing.Size(225, 30);
            this.cboLocDanhMuc.TabIndex = 7;
            this.cboLocDanhMuc.SelectedIndexChanged += new System.EventHandler(this.cboDanhMuc_SelectedIndexChanged_1);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(11, 85);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 22);
            this.label2.TabIndex = 6;
            this.label2.Text = "Danh mục: ";
            this.label2.Click += new System.EventHandler(this.label2_Click_1);
            // 
            // txtTimKiemSp
            // 
            this.txtTimKiemSp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtTimKiemSp.ForeColor = System.Drawing.Color.Silver;
            this.txtTimKiemSp.Location = new System.Drawing.Point(15, 3);
            this.txtTimKiemSp.Name = "txtTimKiemSp";
            this.txtTimKiemSp.Size = new System.Drawing.Size(285, 28);
            this.txtTimKiemSp.TabIndex = 3;
            this.txtTimKiemSp.Text = "Tìm kiếm sản phẩm...";
            this.txtTimKiemSp.TextChanged += new System.EventHandler(this.txtTimKiem_TextChanged);
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
            this.tableLayoutPanel1.TabIndex = 1;
            this.tableLayoutPanel1.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.btnXoaSp);
            this.panel2.Controls.Add(this.btnCapNhatSp);
            this.panel2.Controls.Add(this.btnThemSp);
            this.panel2.Location = new System.Drawing.Point(768, 10);
            this.panel2.Margin = new System.Windows.Forms.Padding(0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(414, 115);
            this.panel2.TabIndex = 2;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // btnXoaSp
            // 
            this.btnXoaSp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaSp.BackColor = System.Drawing.Color.Firebrick;
            this.btnXoaSp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnXoaSp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaSp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnXoaSp.ForeColor = System.Drawing.Color.White;
            this.btnXoaSp.Location = new System.Drawing.Point(300, 80);
            this.btnXoaSp.Name = "btnXoaSp";
            this.btnXoaSp.Size = new System.Drawing.Size(111, 32);
            this.btnXoaSp.TabIndex = 8;
            this.btnXoaSp.Text = "🗑  Xóa";
            this.btnXoaSp.UseVisualStyleBackColor = false;
            this.btnXoaSp.Click += new System.EventHandler(this.btnXoaSP_Click);
            // 
            // btnCapNhatSp
            // 
            this.btnCapNhatSp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnCapNhatSp.BackColor = System.Drawing.Color.Orange;
            this.btnCapNhatSp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnCapNhatSp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCapNhatSp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCapNhatSp.ForeColor = System.Drawing.Color.White;
            this.btnCapNhatSp.Location = new System.Drawing.Point(159, 80);
            this.btnCapNhatSp.Name = "btnCapNhatSp";
            this.btnCapNhatSp.Size = new System.Drawing.Size(133, 32);
            this.btnCapNhatSp.TabIndex = 7;
            this.btnCapNhatSp.Text = "✎  Cập nhật";
            this.btnCapNhatSp.UseVisualStyleBackColor = false;
            this.btnCapNhatSp.Click += new System.EventHandler(this.btnCapNhatSP_Click);
            // 
            // btnThemSp
            // 
            this.btnThemSp.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemSp.BackColor = System.Drawing.Color.Green;
            this.btnThemSp.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnThemSp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemSp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnThemSp.ForeColor = System.Drawing.Color.White;
            this.btnThemSp.Location = new System.Drawing.Point(18, 80);
            this.btnThemSp.Name = "btnThemSp";
            this.btnThemSp.Size = new System.Drawing.Size(132, 32);
            this.btnThemSp.TabIndex = 6;
            this.btnThemSp.Text = "+ Thêm mới";
            this.btnThemSp.UseVisualStyleBackColor = false;
            this.btnThemSp.Click += new System.EventHandler(this.btnThemSP_Click);
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.White;
            this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel3.Controls.Add(this.dgvDanhSachSp);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel3.Location = new System.Drawing.Point(0, 135);
            this.panel3.Name = "panel3";
            this.panel3.Padding = new System.Windows.Forms.Padding(10);
            this.panel3.Size = new System.Drawing.Size(1192, 600);
            this.panel3.TabIndex = 7;
            this.panel3.Paint += new System.Windows.Forms.PaintEventHandler(this.panel3_Paint);
            // 
            // dgvDanhSachSp
            // 
            this.dgvDanhSachSp.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvDanhSachSp.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachSp.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachSp.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MaSanPham,
            this.TenSanPham,
            this.TenDanhMuc,
            this.DongGia,
            this.SoLuongTon,
            this.TrangThai});
            this.dgvDanhSachSp.Location = new System.Drawing.Point(9, 9);
            this.dgvDanhSachSp.Name = "dgvDanhSachSp";
            this.dgvDanhSachSp.RowHeadersVisible = false;
            this.dgvDanhSachSp.RowHeadersWidth = 51;
            this.dgvDanhSachSp.RowTemplate.Height = 24;
            this.dgvDanhSachSp.Size = new System.Drawing.Size(1172, 527);
            this.dgvDanhSachSp.TabIndex = 2;
            this.dgvDanhSachSp.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // MaSanPham
            // 
            this.MaSanPham.FillWeight = 80F;
            this.MaSanPham.HeaderText = "Mã SP";
            this.MaSanPham.MinimumWidth = 6;
            this.MaSanPham.Name = "MaSanPham";
            // 
            // TenSanPham
            // 
            this.TenSanPham.HeaderText = "Tên sản phẩm";
            this.TenSanPham.MinimumWidth = 6;
            this.TenSanPham.Name = "TenSanPham";
            // 
            // TenDanhMuc
            // 
            this.TenDanhMuc.FillWeight = 85F;
            this.TenDanhMuc.HeaderText = "Danh mục";
            this.TenDanhMuc.MinimumWidth = 6;
            this.TenDanhMuc.Name = "TenDanhMuc";
            // 
            // DongGia
            // 
            this.DongGia.HeaderText = "Đơn giá";
            this.DongGia.MinimumWidth = 6;
            this.DongGia.Name = "DongGia";
            // 
            // SoLuongTon
            // 
            this.SoLuongTon.FillWeight = 70F;
            this.SoLuongTon.HeaderText = "Số lượng tồn";
            this.SoLuongTon.MinimumWidth = 6;
            this.SoLuongTon.Name = "SoLuongTon";
            // 
            // TrangThai
            // 
            this.TrangThai.FillWeight = 80F;
            this.TrangThai.HeaderText = "Trạng thái";
            this.TrangThai.MinimumWidth = 6;
            this.TrangThai.Name = "TrangThai";
            // 
            // UC_SanPham
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.SystemColors.ControlLight;
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "UC_SanPham";
            this.Size = new System.Drawing.Size(1192, 735);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachSp)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TextBox txtTimKiemSp;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnXoaSp;
        private System.Windows.Forms.Button btnCapNhatSp;
        private System.Windows.Forms.Button btnThemSp;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.ComboBox cboLocDanhMuc;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dgvDanhSachSp;
        private System.Windows.Forms.DataGridViewTextBoxColumn MaSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenSanPham;
        private System.Windows.Forms.DataGridViewTextBoxColumn TenDanhMuc;
        private System.Windows.Forms.DataGridViewTextBoxColumn DongGia;
        private System.Windows.Forms.DataGridViewTextBoxColumn SoLuongTon;
        private System.Windows.Forms.DataGridViewTextBoxColumn TrangThai;
    }
}
