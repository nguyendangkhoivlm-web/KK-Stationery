namespace qlcuahangdcht
{
    partial class MainForm
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
            this.pnlSidebar = new System.Windows.Forms.Panel();
            this.pnlRightContent = new System.Windows.Forms.Panel();
            this.pnlHeader = new System.Windows.Forms.Panel();
            this.pnlContainer = new System.Windows.Forms.Panel();
            this.btnTongQuan = new System.Windows.Forms.Button();
            this.btnBanHang = new System.Windows.Forms.Button();
            this.btnNhanVien = new System.Windows.Forms.Button();
            this.btnSanPham = new System.Windows.Forms.Button();
            this.btnBaoCao = new System.Windows.Forms.Button();
            this.pnlSidebar.SuspendLayout();
            this.pnlRightContent.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlSidebar
            // 
            this.pnlSidebar.BackColor = System.Drawing.Color.CornflowerBlue;
            this.pnlSidebar.Controls.Add(this.btnBaoCao);
            this.pnlSidebar.Controls.Add(this.btnNhanVien);
            this.pnlSidebar.Controls.Add(this.btnSanPham);
            this.pnlSidebar.Controls.Add(this.btnBanHang);
            this.pnlSidebar.Controls.Add(this.btnTongQuan);
            this.pnlSidebar.Dock = System.Windows.Forms.DockStyle.Left;
            this.pnlSidebar.Location = new System.Drawing.Point(0, 0);
            this.pnlSidebar.Name = "pnlSidebar";
            this.pnlSidebar.Size = new System.Drawing.Size(250, 810);
            this.pnlSidebar.TabIndex = 0;
            // 
            // pnlRightContent
            // 
            this.pnlRightContent.Controls.Add(this.pnlContainer);
            this.pnlRightContent.Controls.Add(this.pnlHeader);
            this.pnlRightContent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlRightContent.Location = new System.Drawing.Point(250, 0);
            this.pnlRightContent.Name = "pnlRightContent";
            this.pnlRightContent.Size = new System.Drawing.Size(1192, 810);
            this.pnlRightContent.TabIndex = 1;
            // 
            // pnlHeader
            // 
            this.pnlHeader.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlHeader.Location = new System.Drawing.Point(0, 0);
            this.pnlHeader.Name = "pnlHeader";
            this.pnlHeader.Size = new System.Drawing.Size(1192, 75);
            this.pnlHeader.TabIndex = 0;
            // 
            // pnlContainer
            // 
            this.pnlContainer.BackColor = System.Drawing.SystemColors.ControlLight;
            this.pnlContainer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlContainer.Location = new System.Drawing.Point(0, 75);
            this.pnlContainer.Name = "pnlContainer";
            this.pnlContainer.Size = new System.Drawing.Size(1192, 735);
            this.pnlContainer.TabIndex = 1;
            // 
            // btnTongQuan
            // 
            this.btnTongQuan.FlatAppearance.BorderSize = 0;
            this.btnTongQuan.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnTongQuan.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnTongQuan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnTongQuan.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTongQuan.ForeColor = System.Drawing.Color.White;
            this.btnTongQuan.Location = new System.Drawing.Point(15, 97);
            this.btnTongQuan.Name = "btnTongQuan";
            this.btnTongQuan.Size = new System.Drawing.Size(223, 41);
            this.btnTongQuan.TabIndex = 0;
            this.btnTongQuan.Text = "📊 Tổng quan";
            this.btnTongQuan.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTongQuan.UseVisualStyleBackColor = true;
            this.btnTongQuan.Click += new System.EventHandler(this.btnTongQuan_Click);
            // 
            // btnBanHang
            // 
            this.btnBanHang.FlatAppearance.BorderSize = 0;
            this.btnBanHang.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBanHang.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBanHang.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBanHang.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBanHang.ForeColor = System.Drawing.Color.White;
            this.btnBanHang.Location = new System.Drawing.Point(15, 161);
            this.btnBanHang.Name = "btnBanHang";
            this.btnBanHang.Size = new System.Drawing.Size(223, 41);
            this.btnBanHang.TabIndex = 1;
            this.btnBanHang.Text = "🛒 Bán hàng";
            this.btnBanHang.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBanHang.UseVisualStyleBackColor = true;
            this.btnBanHang.Click += new System.EventHandler(this.btnBanHang_Click);
            // 
            // btnNhanVien
            // 
            this.btnNhanVien.FlatAppearance.BorderSize = 0;
            this.btnNhanVien.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNhanVien.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnNhanVien.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnNhanVien.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNhanVien.ForeColor = System.Drawing.Color.White;
            this.btnNhanVien.Location = new System.Drawing.Point(15, 286);
            this.btnNhanVien.Name = "btnNhanVien";
            this.btnNhanVien.Size = new System.Drawing.Size(223, 41);
            this.btnNhanVien.TabIndex = 3;
            this.btnNhanVien.Text = "👥 Quản lý Nhân viên";
            this.btnNhanVien.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnNhanVien.UseVisualStyleBackColor = true;
            this.btnNhanVien.Click += new System.EventHandler(this.btnNhanVien_Click);
            // 
            // btnSanPham
            // 
            this.btnSanPham.FlatAppearance.BorderSize = 0;
            this.btnSanPham.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSanPham.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnSanPham.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnSanPham.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSanPham.ForeColor = System.Drawing.Color.White;
            this.btnSanPham.Location = new System.Drawing.Point(15, 222);
            this.btnSanPham.Name = "btnSanPham";
            this.btnSanPham.Size = new System.Drawing.Size(223, 41);
            this.btnSanPham.TabIndex = 2;
            this.btnSanPham.Text = "📦 Quản lý Sản phẩm";
            this.btnSanPham.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnSanPham.UseVisualStyleBackColor = true;
            this.btnSanPham.Click += new System.EventHandler(this.btnSanPham_Click);
            // 
            // btnBaoCao
            // 
            this.btnBaoCao.FlatAppearance.BorderSize = 0;
            this.btnBaoCao.FlatAppearance.MouseDownBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBaoCao.FlatAppearance.MouseOverBackColor = System.Drawing.Color.LightSteelBlue;
            this.btnBaoCao.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBaoCao.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBaoCao.ForeColor = System.Drawing.Color.White;
            this.btnBaoCao.Location = new System.Drawing.Point(15, 348);
            this.btnBaoCao.Name = "btnBaoCao";
            this.btnBaoCao.Size = new System.Drawing.Size(223, 41);
            this.btnBaoCao.TabIndex = 4;
            this.btnBaoCao.Text = "📈 Báo cáo doanh thu";
            this.btnBaoCao.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnBaoCao.UseVisualStyleBackColor = true;
            this.btnBaoCao.Click += new System.EventHandler(this.btnBaoCao_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1442, 810);
            this.Controls.Add(this.pnlRightContent);
            this.Controls.Add(this.pnlSidebar);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Hệ Thống Quản Lý Cửa Hàng Dụng Cụ Học Tập";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.pnlSidebar.ResumeLayout(false);
            this.pnlRightContent.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlSidebar;
        private System.Windows.Forms.Panel pnlRightContent;
        private System.Windows.Forms.Panel pnlHeader;
        private System.Windows.Forms.Panel pnlContainer;
        private System.Windows.Forms.Button btnTongQuan;
        private System.Windows.Forms.Button btnBaoCao;
        private System.Windows.Forms.Button btnNhanVien;
        private System.Windows.Forms.Button btnSanPham;
        private System.Windows.Forms.Button btnBanHang;
    }
}