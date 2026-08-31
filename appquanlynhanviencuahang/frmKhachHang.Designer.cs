namespace appquanlynhanviencuahang
{
    partial class frmKhachHang
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
            this.pnlKhungNoiDung = new System.Windows.Forms.Panel();
            this.dgvDanhSachKhachHang = new System.Windows.Forms.DataGridView();
            this.pnlTimKiem = new System.Windows.Forms.Panel();
            this.btnTimKiem = new System.Windows.Forms.Button();
            this.txtTimKiem = new System.Windows.Forms.TextBox();
            this.pnlTieuDeTren = new System.Windows.Forms.Panel();
            this.btnXoaKhachHang = new System.Windows.Forms.Button();
            this.btnThemKhachHang = new System.Windows.Forms.Button();
            this.lblTieuDe = new System.Windows.Forms.Label();
            this.pnlKhungNoiDung.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachKhachHang)).BeginInit();
            this.pnlTimKiem.SuspendLayout();
            this.pnlTieuDeTren.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlKhungNoiDung
            // 
            this.pnlKhungNoiDung.BackColor = System.Drawing.Color.White;
            this.pnlKhungNoiDung.Controls.Add(this.dgvDanhSachKhachHang);
            this.pnlKhungNoiDung.Controls.Add(this.pnlTimKiem);
            this.pnlKhungNoiDung.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKhungNoiDung.Location = new System.Drawing.Point(0, 55);
            this.pnlKhungNoiDung.Name = "pnlKhungNoiDung";
            this.pnlKhungNoiDung.Padding = new System.Windows.Forms.Padding(18);
            this.pnlKhungNoiDung.Size = new System.Drawing.Size(1003, 444);
            this.pnlKhungNoiDung.TabIndex = 3;
            // 
            // dgvDanhSachKhachHang
            // 
            this.dgvDanhSachKhachHang.AllowUserToAddRows = false;
            this.dgvDanhSachKhachHang.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvDanhSachKhachHang.BackgroundColor = System.Drawing.Color.White;
            this.dgvDanhSachKhachHang.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dgvDanhSachKhachHang.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvDanhSachKhachHang.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDanhSachKhachHang.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvDanhSachKhachHang.EnableHeadersVisualStyles = false;
            this.dgvDanhSachKhachHang.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(237)))), ((int)(((byte)(242)))), ((int)(((byte)(247)))));
            this.dgvDanhSachKhachHang.Location = new System.Drawing.Point(18, 66);
            this.dgvDanhSachKhachHang.MultiSelect = false;
            this.dgvDanhSachKhachHang.Name = "dgvDanhSachKhachHang";
            this.dgvDanhSachKhachHang.RowHeadersVisible = false;
            this.dgvDanhSachKhachHang.RowHeadersWidth = 51;
            this.dgvDanhSachKhachHang.RowTemplate.Height = 42;
            this.dgvDanhSachKhachHang.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvDanhSachKhachHang.Size = new System.Drawing.Size(967, 360);
            this.dgvDanhSachKhachHang.TabIndex = 1;
            // 
            // pnlTimKiem
            // 
            this.pnlTimKiem.Controls.Add(this.btnTimKiem);
            this.pnlTimKiem.Controls.Add(this.txtTimKiem);
            this.pnlTimKiem.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTimKiem.Location = new System.Drawing.Point(18, 18);
            this.pnlTimKiem.Name = "pnlTimKiem";
            this.pnlTimKiem.Size = new System.Drawing.Size(967, 48);
            this.pnlTimKiem.TabIndex = 0;
            // 
            // btnTimKiem
            // 
            this.btnTimKiem.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnTimKiem.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnTimKiem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTimKiem.Location = new System.Drawing.Point(430, 6);
            this.btnTimKiem.Name = "btnTimKiem";
            this.btnTimKiem.Size = new System.Drawing.Size(75, 30);
            this.btnTimKiem.TabIndex = 1;
            this.btnTimKiem.Text = "Tìm";
            this.btnTimKiem.UseVisualStyleBackColor = false;
            // 
            // txtTimKiem
            // 
            this.txtTimKiem.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.txtTimKiem.ForeColor = System.Drawing.Color.Gray;
            this.txtTimKiem.Location = new System.Drawing.Point(0, 6);
            this.txtTimKiem.Name = "txtTimKiem";
            this.txtTimKiem.Size = new System.Drawing.Size(420, 31);
            this.txtTimKiem.TabIndex = 0;
            this.txtTimKiem.Text = "Tìm kiếm theo Mã hoặc Số điện thoại...";
            // 
            // pnlTieuDeTren
            // 
            this.pnlTieuDeTren.Controls.Add(this.btnXoaKhachHang);
            this.pnlTieuDeTren.Controls.Add(this.btnThemKhachHang);
            this.pnlTieuDeTren.Controls.Add(this.lblTieuDe);
            this.pnlTieuDeTren.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlTieuDeTren.Location = new System.Drawing.Point(0, 0);
            this.pnlTieuDeTren.Name = "pnlTieuDeTren";
            this.pnlTieuDeTren.Size = new System.Drawing.Size(1003, 55);
            this.pnlTieuDeTren.TabIndex = 2;
            // 
            // btnXoaKhachHang
            // 
            this.btnXoaKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnXoaKhachHang.BackColor = System.Drawing.Color.OrangeRed;
            this.btnXoaKhachHang.FlatAppearance.BorderSize = 0;
            this.btnXoaKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnXoaKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnXoaKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnXoaKhachHang.Location = new System.Drawing.Point(662, 6);
            this.btnXoaKhachHang.Name = "btnXoaKhachHang";
            this.btnXoaKhachHang.Size = new System.Drawing.Size(145, 38);
            this.btnXoaKhachHang.TabIndex = 2;
            this.btnXoaKhachHang.Text = "🗑 Xóa Khách Hàng";
            this.btnXoaKhachHang.UseVisualStyleBackColor = false;
            // 
            // btnThemKhachHang
            // 
            this.btnThemKhachHang.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnThemKhachHang.BackColor = System.Drawing.Color.RoyalBlue;
            this.btnThemKhachHang.FlatAppearance.BorderSize = 0;
            this.btnThemKhachHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnThemKhachHang.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Bold);
            this.btnThemKhachHang.ForeColor = System.Drawing.Color.White;
            this.btnThemKhachHang.Location = new System.Drawing.Point(818, 5);
            this.btnThemKhachHang.Name = "btnThemKhachHang";
            this.btnThemKhachHang.Size = new System.Drawing.Size(185, 38);
            this.btnThemKhachHang.TabIndex = 1;
            this.btnThemKhachHang.Text = "+ Thêm Khách Hàng";
            this.btnThemKhachHang.UseVisualStyleBackColor = false;
            // 
            // lblTieuDe
            // 
            this.lblTieuDe.AutoSize = true;
            this.lblTieuDe.Font = new System.Drawing.Font("Segoe UI", 17F, System.Drawing.FontStyle.Bold);
            this.lblTieuDe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTieuDe.Location = new System.Drawing.Point(0, 5);
            this.lblTieuDe.Name = "lblTieuDe";
            this.lblTieuDe.Size = new System.Drawing.Size(302, 40);
            this.lblTieuDe.TabIndex = 0;
            this.lblTieuDe.Text = "Quản Lý Khách Hàng";
            // 
            // frmKhachHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1003, 499);
            this.Controls.Add(this.pnlKhungNoiDung);
            this.Controls.Add(this.pnlTieuDeTren);
            this.Name = "frmKhachHang";
            this.Text = "frmKhachHang";
            this.pnlKhungNoiDung.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDanhSachKhachHang)).EndInit();
            this.pnlTimKiem.ResumeLayout(false);
            this.pnlTimKiem.PerformLayout();
            this.pnlTieuDeTren.ResumeLayout(false);
            this.pnlTieuDeTren.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlKhungNoiDung;
        private System.Windows.Forms.DataGridView dgvDanhSachKhachHang;
        private System.Windows.Forms.Panel pnlTimKiem;
        private System.Windows.Forms.Button btnTimKiem;
        private System.Windows.Forms.TextBox txtTimKiem;
        private System.Windows.Forms.Panel pnlTieuDeTren;
        private System.Windows.Forms.Button btnXoaKhachHang;
        private System.Windows.Forms.Button btnThemKhachHang;
        private System.Windows.Forms.Label lblTieuDe;
    }
}