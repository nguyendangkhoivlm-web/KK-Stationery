namespace appquanlynhanviencuahang
{
    partial class frmThanhToanQuaQR
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
            this.timerDemNguoc = new System.Windows.Forms.Timer(this.components);
            this.btnGiaLapThanhCong = new System.Windows.Forms.Button();
            this.btnHuyThanhToan = new System.Windows.Forms.Button();
            this.tblNutBam = new System.Windows.Forms.TableLayoutPanel();
            this.lblThoiGianConLai = new System.Windows.Forms.Label();
            this.tblCanGiua = new System.Windows.Forms.TableLayoutPanel();
            this.pnlKhungThe = new System.Windows.Forms.Panel();
            this.lblTenChuTaiKhoan = new System.Windows.Forms.Label();
            this.lblThongTinNganHang = new System.Windows.Forms.Label();
            this.lblNoiDungChuyenKhoan = new System.Windows.Forms.Label();
            this.lblSoTien = new System.Windows.Forms.Label();
            this.picMaQR = new System.Windows.Forms.PictureBox();
            this.lblHuongDanQuet = new System.Windows.Forms.Label();
            this.lblTieuDeThe = new System.Windows.Forms.Label();
            this.btnQuayLai = new System.Windows.Forms.Button();
            this.lblTieuDeTren = new System.Windows.Forms.Label();
            this.pnlThanhTieuDe = new System.Windows.Forms.Panel();
            this.tblNutBam.SuspendLayout();
            this.tblCanGiua.SuspendLayout();
            this.pnlKhungThe.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.picMaQR)).BeginInit();
            this.pnlThanhTieuDe.SuspendLayout();
            this.SuspendLayout();
            // 
            // timerDemNguoc
            // 
            this.timerDemNguoc.Interval = 1000;
            // 
            // btnGiaLapThanhCong
            // 
            this.btnGiaLapThanhCong.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(16)))), ((int)(((byte)(185)))), ((int)(((byte)(129)))));
            this.btnGiaLapThanhCong.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnGiaLapThanhCong.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnGiaLapThanhCong.FlatAppearance.BorderSize = 0;
            this.btnGiaLapThanhCong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGiaLapThanhCong.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnGiaLapThanhCong.ForeColor = System.Drawing.Color.White;
            this.btnGiaLapThanhCong.Location = new System.Drawing.Point(3, 3);
            this.btnGiaLapThanhCong.Margin = new System.Windows.Forms.Padding(3, 3, 8, 3);
            this.btnGiaLapThanhCong.Name = "btnGiaLapThanhCong";
            this.btnGiaLapThanhCong.Size = new System.Drawing.Size(374, 44);
            this.btnGiaLapThanhCong.TabIndex = 7;
            this.btnGiaLapThanhCong.Text = "⚡ Giả Lập Đã Nhận Tiền";
            this.btnGiaLapThanhCong.UseVisualStyleBackColor = false;
            // 
            // btnHuyThanhToan
            // 
            this.btnHuyThanhToan.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(241)))), ((int)(((byte)(245)))), ((int)(((byte)(249)))));
            this.btnHuyThanhToan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnHuyThanhToan.Dock = System.Windows.Forms.DockStyle.Fill;
            this.btnHuyThanhToan.FlatAppearance.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(203)))), ((int)(((byte)(213)))), ((int)(((byte)(225)))));
            this.btnHuyThanhToan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnHuyThanhToan.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.btnHuyThanhToan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.btnHuyThanhToan.Location = new System.Drawing.Point(393, 3);
            this.btnHuyThanhToan.Margin = new System.Windows.Forms.Padding(8, 3, 3, 3);
            this.btnHuyThanhToan.Name = "btnHuyThanhToan";
            this.btnHuyThanhToan.Size = new System.Drawing.Size(246, 44);
            this.btnHuyThanhToan.TabIndex = 6;
            this.btnHuyThanhToan.Text = "Hủy Bỏ";
            this.btnHuyThanhToan.UseVisualStyleBackColor = false;
            // 
            // tblNutBam
            // 
            this.tblNutBam.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tblNutBam.ColumnCount = 2;
            this.tblNutBam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
            this.tblNutBam.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
            this.tblNutBam.Controls.Add(this.btnGiaLapThanhCong, 0, 0);
            this.tblNutBam.Controls.Add(this.btnHuyThanhToan, 1, 0);
            this.tblNutBam.Location = new System.Drawing.Point(35, 560);
            this.tblNutBam.Name = "tblNutBam";
            this.tblNutBam.RowCount = 1;
            this.tblNutBam.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tblNutBam.Size = new System.Drawing.Size(642, 50);
            this.tblNutBam.TabIndex = 10;
            // 
            // lblThoiGianConLai
            // 
            this.lblThoiGianConLai.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThoiGianConLai.Font = new System.Drawing.Font("Segoe UI", 9.5F, System.Drawing.FontStyle.Italic);
            this.lblThoiGianConLai.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(234)))), ((int)(((byte)(88)))), ((int)(((byte)(12)))));
            this.lblThoiGianConLai.Location = new System.Drawing.Point(35, 528);
            this.lblThoiGianConLai.Name = "lblThoiGianConLai";
            this.lblThoiGianConLai.Size = new System.Drawing.Size(642, 22);
            this.lblThoiGianConLai.TabIndex = 5;
            this.lblThoiGianConLai.Text = "⏳ Mã QR có hiệu lực trong: 05:00";
            this.lblThoiGianConLai.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // tblCanGiua
            // 
            this.tblCanGiua.ColumnCount = 3;
            this.tblCanGiua.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCanGiua.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 720F));
            this.tblCanGiua.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCanGiua.Controls.Add(this.pnlKhungThe, 1, 1);
            this.tblCanGiua.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tblCanGiua.Location = new System.Drawing.Point(0, 55);
            this.tblCanGiua.Name = "tblCanGiua";
            this.tblCanGiua.RowCount = 3;
            this.tblCanGiua.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCanGiua.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 640F));
            this.tblCanGiua.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tblCanGiua.Size = new System.Drawing.Size(1021, 553);
            this.tblCanGiua.TabIndex = 3;
            // 
            // pnlKhungThe
            // 
            this.pnlKhungThe.BackColor = System.Drawing.Color.White;
            this.pnlKhungThe.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlKhungThe.Controls.Add(this.tblNutBam);
            this.pnlKhungThe.Controls.Add(this.lblThoiGianConLai);
            this.pnlKhungThe.Controls.Add(this.lblTenChuTaiKhoan);
            this.pnlKhungThe.Controls.Add(this.lblThongTinNganHang);
            this.pnlKhungThe.Controls.Add(this.lblNoiDungChuyenKhoan);
            this.pnlKhungThe.Controls.Add(this.lblSoTien);
            this.pnlKhungThe.Controls.Add(this.picMaQR);
            this.pnlKhungThe.Controls.Add(this.lblHuongDanQuet);
            this.pnlKhungThe.Controls.Add(this.lblTieuDeThe);
            this.pnlKhungThe.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pnlKhungThe.Location = new System.Drawing.Point(153, -40);
            this.pnlKhungThe.Name = "pnlKhungThe";
            this.pnlKhungThe.Padding = new System.Windows.Forms.Padding(35, 20, 35, 20);
            this.pnlKhungThe.Size = new System.Drawing.Size(714, 634);
            this.pnlKhungThe.TabIndex = 0;
            // 
            // lblTenChuTaiKhoan
            // 
            this.lblTenChuTaiKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTenChuTaiKhoan.Font = new System.Drawing.Font("Segoe UI", 10.5F, System.Drawing.FontStyle.Bold);
            this.lblTenChuTaiKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTenChuTaiKhoan.Location = new System.Drawing.Point(35, 498);
            this.lblTenChuTaiKhoan.Name = "lblTenChuTaiKhoan";
            this.lblTenChuTaiKhoan.Size = new System.Drawing.Size(642, 24);
            this.lblTenChuTaiKhoan.TabIndex = 9;
            this.lblTenChuTaiKhoan.Text = "Chủ TK: TRAN VU TUAN KIET";
            this.lblTenChuTaiKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblThongTinNganHang
            // 
            this.lblThongTinNganHang.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblThongTinNganHang.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblThongTinNganHang.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblThongTinNganHang.Location = new System.Drawing.Point(35, 472);
            this.lblThongTinNganHang.Name = "lblThongTinNganHang";
            this.lblThongTinNganHang.Size = new System.Drawing.Size(642, 22);
            this.lblThongTinNganHang.TabIndex = 8;
            this.lblThongTinNganHang.Text = "Ngân hàng Quân Đội (MBBank) - STK: 0987654321";
            this.lblThongTinNganHang.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblNoiDungChuyenKhoan
            // 
            this.lblNoiDungChuyenKhoan.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblNoiDungChuyenKhoan.Font = new System.Drawing.Font("Segoe UI", 10.5F);
            this.lblNoiDungChuyenKhoan.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(71)))), ((int)(((byte)(85)))), ((int)(((byte)(105)))));
            this.lblNoiDungChuyenKhoan.Location = new System.Drawing.Point(35, 445);
            this.lblNoiDungChuyenKhoan.Name = "lblNoiDungChuyenKhoan";
            this.lblNoiDungChuyenKhoan.Size = new System.Drawing.Size(642, 24);
            this.lblNoiDungChuyenKhoan.TabIndex = 4;
            this.lblNoiDungChuyenKhoan.Text = "Nội dung CK: HD-202608-001";
            this.lblNoiDungChuyenKhoan.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblSoTien
            // 
            this.lblSoTien.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblSoTien.Font = new System.Drawing.Font("Segoe UI", 22F, System.Drawing.FontStyle.Bold);
            this.lblSoTien.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(37)))), ((int)(((byte)(99)))), ((int)(((byte)(235)))));
            this.lblSoTien.Location = new System.Drawing.Point(35, 395);
            this.lblSoTien.Name = "lblSoTien";
            this.lblSoTien.Size = new System.Drawing.Size(642, 45);
            this.lblSoTien.TabIndex = 3;
            this.lblSoTien.Text = "0 VNĐ";
            this.lblSoTien.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // picMaQR
            // 
            this.picMaQR.Anchor = System.Windows.Forms.AnchorStyles.Top;
            this.picMaQR.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(248)))), ((int)(((byte)(250)))), ((int)(((byte)(252)))));
            this.picMaQR.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.picMaQR.Location = new System.Drawing.Point(196, 70);
            this.picMaQR.Name = "picMaQR";
            this.picMaQR.Size = new System.Drawing.Size(320, 320);
            this.picMaQR.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.picMaQR.TabIndex = 1;
            this.picMaQR.TabStop = false;
            // 
            // lblHuongDanQuet
            // 
            this.lblHuongDanQuet.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblHuongDanQuet.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.lblHuongDanQuet.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(100)))), ((int)(((byte)(116)))), ((int)(((byte)(139)))));
            this.lblHuongDanQuet.Location = new System.Drawing.Point(35, 42);
            this.lblHuongDanQuet.Name = "lblHuongDanQuet";
            this.lblHuongDanQuet.Size = new System.Drawing.Size(642, 22);
            this.lblHuongDanQuet.TabIndex = 2;
            this.lblHuongDanQuet.Text = "Mở App Ngân hàng hoặc Ví điện tử bất kỳ để quét mã";
            this.lblHuongDanQuet.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lblTieuDeThe
            // 
            this.lblTieuDeThe.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblTieuDeThe.Font = new System.Drawing.Font("Segoe UI", 16F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeThe.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(30)))), ((int)(((byte)(41)))), ((int)(((byte)(59)))));
            this.lblTieuDeThe.Location = new System.Drawing.Point(35, 8);
            this.lblTieuDeThe.Name = "lblTieuDeThe";
            this.lblTieuDeThe.Size = new System.Drawing.Size(642, 32);
            this.lblTieuDeThe.TabIndex = 0;
            this.lblTieuDeThe.Text = "Quét Mã VietQR Chuyển Khoản";
            this.lblTieuDeThe.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnQuayLai
            // 
            this.btnQuayLai.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnQuayLai.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnQuayLai.FlatAppearance.BorderSize = 0;
            this.btnQuayLai.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnQuayLai.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Bold);
            this.btnQuayLai.ForeColor = System.Drawing.Color.White;
            this.btnQuayLai.Location = new System.Drawing.Point(886, 11);
            this.btnQuayLai.Name = "btnQuayLai";
            this.btnQuayLai.Size = new System.Drawing.Size(120, 34);
            this.btnQuayLai.TabIndex = 1;
            this.btnQuayLai.Text = "⬅ Quay Lại";
            this.btnQuayLai.UseVisualStyleBackColor = true;
            // 
            // lblTieuDeTren
            // 
            this.lblTieuDeTren.AutoSize = true;
            this.lblTieuDeTren.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold);
            this.lblTieuDeTren.ForeColor = System.Drawing.Color.White;
            this.lblTieuDeTren.Location = new System.Drawing.Point(24, 11);
            this.lblTieuDeTren.Name = "lblTieuDeTren";
            this.lblTieuDeTren.Size = new System.Drawing.Size(418, 35);
            this.lblTieuDeTren.TabIndex = 0;
            this.lblTieuDeTren.Text = "Cổng Thanh Toán VietQR Tự Động";
            // 
            // pnlThanhTieuDe
            // 
            this.pnlThanhTieuDe.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(15)))), ((int)(((byte)(23)))), ((int)(((byte)(42)))));
            this.pnlThanhTieuDe.Controls.Add(this.btnQuayLai);
            this.pnlThanhTieuDe.Controls.Add(this.lblTieuDeTren);
            this.pnlThanhTieuDe.Dock = System.Windows.Forms.DockStyle.Top;
            this.pnlThanhTieuDe.Location = new System.Drawing.Point(0, 0);
            this.pnlThanhTieuDe.Name = "pnlThanhTieuDe";
            this.pnlThanhTieuDe.Size = new System.Drawing.Size(1021, 55);
            this.pnlThanhTieuDe.TabIndex = 2;
            // 
            // frmThanhToanQuaQR
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 608);
            this.Controls.Add(this.tblCanGiua);
            this.Controls.Add(this.pnlThanhTieuDe);
            this.Name = "frmThanhToanQuaQR";
            this.Text = "frmThanhToanQuaQR";
            this.tblNutBam.ResumeLayout(false);
            this.tblCanGiua.ResumeLayout(false);
            this.pnlKhungThe.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.picMaQR)).EndInit();
            this.pnlThanhTieuDe.ResumeLayout(false);
            this.pnlThanhTieuDe.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Timer timerDemNguoc;
        private System.Windows.Forms.Button btnGiaLapThanhCong;
        private System.Windows.Forms.Button btnHuyThanhToan;
        private System.Windows.Forms.TableLayoutPanel tblNutBam;
        private System.Windows.Forms.Label lblThoiGianConLai;
        private System.Windows.Forms.TableLayoutPanel tblCanGiua;
        private System.Windows.Forms.Panel pnlKhungThe;
        private System.Windows.Forms.Label lblTenChuTaiKhoan;
        private System.Windows.Forms.Label lblThongTinNganHang;
        private System.Windows.Forms.Label lblNoiDungChuyenKhoan;
        private System.Windows.Forms.Label lblSoTien;
        private System.Windows.Forms.PictureBox picMaQR;
        private System.Windows.Forms.Label lblHuongDanQuet;
        private System.Windows.Forms.Label lblTieuDeThe;
        private System.Windows.Forms.Button btnQuayLai;
        private System.Windows.Forms.Label lblTieuDeTren;
        private System.Windows.Forms.Panel pnlThanhTieuDe;
    }
}