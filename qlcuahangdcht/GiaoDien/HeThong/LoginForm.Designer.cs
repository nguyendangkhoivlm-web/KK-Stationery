namespace qlcuahangdcht
{
    partial class LoginForm
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
            this.pnlMain = new System.Windows.Forms.Panel();
            this.pnlRegister = new System.Windows.Forms.Panel();
            this.pnlLogin = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.txtLoginPass = new System.Windows.Forms.TextBox();
            this.txtLoginUser = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnRegister = new System.Windows.Forms.Button();
            this.txtRegConfirmPass = new System.Windows.Forms.TextBox();
            this.txtRegUser = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtRegHoTen = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtRegPass = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.pnlMain.SuspendLayout();
            this.pnlRegister.SuspendLayout();
            this.pnlLogin.SuspendLayout();
            this.SuspendLayout();
            // 
            // pnlMain
            // 
            this.pnlMain.BackColor = System.Drawing.SystemColors.Window;
            this.pnlMain.Controls.Add(this.pnlRegister);
            this.pnlMain.Controls.Add(this.pnlLogin);
            this.pnlMain.Location = new System.Drawing.Point(44, 32);
            this.pnlMain.Name = "pnlMain";
            this.pnlMain.Size = new System.Drawing.Size(780, 480);
            this.pnlMain.TabIndex = 0;
            // 
            // pnlRegister
            // 
            this.pnlRegister.Controls.Add(this.panel1);
            this.pnlRegister.Controls.Add(this.label9);
            this.pnlRegister.Controls.Add(this.txtRegPass);
            this.pnlRegister.Controls.Add(this.label8);
            this.pnlRegister.Controls.Add(this.txtRegHoTen);
            this.pnlRegister.Controls.Add(this.label7);
            this.pnlRegister.Controls.Add(this.btnRegister);
            this.pnlRegister.Controls.Add(this.txtRegConfirmPass);
            this.pnlRegister.Controls.Add(this.txtRegUser);
            this.pnlRegister.Controls.Add(this.label5);
            this.pnlRegister.Controls.Add(this.label6);
            this.pnlRegister.Location = new System.Drawing.Point(391, 14);
            this.pnlRegister.Name = "pnlRegister";
            this.pnlRegister.Size = new System.Drawing.Size(376, 452);
            this.pnlRegister.TabIndex = 1;
            // 
            // pnlLogin
            // 
            this.pnlLogin.Controls.Add(this.label4);
            this.pnlLogin.Controls.Add(this.btnLogin);
            this.pnlLogin.Controls.Add(this.txtLoginPass);
            this.pnlLogin.Controls.Add(this.txtLoginUser);
            this.pnlLogin.Controls.Add(this.label3);
            this.pnlLogin.Controls.Add(this.label2);
            this.pnlLogin.Controls.Add(this.label1);
            this.pnlLogin.Location = new System.Drawing.Point(13, 14);
            this.pnlLogin.Name = "pnlLogin";
            this.pnlLogin.Size = new System.Drawing.Size(376, 452);
            this.pnlLogin.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.BackColor = System.Drawing.Color.CornflowerBlue;
            this.btnLogin.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.ForeColor = System.Drawing.Color.White;
            this.btnLogin.Location = new System.Drawing.Point(56, 308);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(260, 51);
            this.btnLogin.TabIndex = 5;
            this.btnLogin.Text = "Đăng nhập";
            this.btnLogin.UseVisualStyleBackColor = false;
            // 
            // txtLoginPass
            // 
            this.txtLoginPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginPass.Location = new System.Drawing.Point(56, 258);
            this.txtLoginPass.Name = "txtLoginPass";
            this.txtLoginPass.Size = new System.Drawing.Size(260, 34);
            this.txtLoginPass.TabIndex = 4;
            this.txtLoginPass.UseSystemPasswordChar = true;
            this.txtLoginPass.Enter += new System.EventHandler(this.txtLoginUser_Enter);
            this.txtLoginPass.Leave += new System.EventHandler(this.txtLoginUser_Leave);
            // 
            // txtLoginUser
            // 
            this.txtLoginUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtLoginUser.Location = new System.Drawing.Point(56, 180);
            this.txtLoginUser.Name = "txtLoginUser";
            this.txtLoginUser.Size = new System.Drawing.Size(260, 34);
            this.txtLoginUser.TabIndex = 3;
            this.txtLoginUser.Enter += new System.EventHandler(this.txtLoginUser_Enter);
            this.txtLoginUser.Leave += new System.EventHandler(this.txtLoginUser_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label3.Location = new System.Drawing.Point(63, 234);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(77, 20);
            this.label3.TabIndex = 2;
            this.label3.Text = "Mật khẩu";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label2.Location = new System.Drawing.Point(63, 156);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(119, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Tên đăng nhập";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(90, 92);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(163, 39);
            this.label1.TabIndex = 0;
            this.label1.Text = "Đăng nhập";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Underline, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(114, 370);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(131, 20);
            this.label4.TabIndex = 6;
            this.label4.Text = "Quên mật khẩu?";
            // 
            // btnRegister
            // 
            this.btnRegister.BackColor = System.Drawing.Color.SeaGreen;
            this.btnRegister.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnRegister.ForeColor = System.Drawing.Color.White;
            this.btnRegister.Location = new System.Drawing.Point(60, 379);
            this.btnRegister.Name = "btnRegister";
            this.btnRegister.Size = new System.Drawing.Size(260, 54);
            this.btnRegister.TabIndex = 10;
            this.btnRegister.Text = "Đăng ký";
            this.btnRegister.UseVisualStyleBackColor = false;
            // 
            // txtRegConfirmPass
            // 
            this.txtRegConfirmPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegConfirmPass.Location = new System.Drawing.Point(60, 332);
            this.txtRegConfirmPass.Name = "txtRegConfirmPass";
            this.txtRegConfirmPass.Size = new System.Drawing.Size(260, 34);
            this.txtRegConfirmPass.TabIndex = 9;
            this.txtRegConfirmPass.UseSystemPasswordChar = true;
            this.txtRegConfirmPass.Enter += new System.EventHandler(this.txtLoginUser_Enter);
            this.txtRegConfirmPass.Leave += new System.EventHandler(this.txtLoginUser_Leave);
            // 
            // txtRegUser
            // 
            this.txtRegUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegUser.Location = new System.Drawing.Point(60, 185);
            this.txtRegUser.Name = "txtRegUser";
            this.txtRegUser.Size = new System.Drawing.Size(260, 34);
            this.txtRegUser.TabIndex = 8;
            this.txtRegUser.Enter += new System.EventHandler(this.txtLoginUser_Enter);
            this.txtRegUser.Leave += new System.EventHandler(this.txtLoginUser_Leave);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label5.Location = new System.Drawing.Point(67, 308);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(143, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Nhập lại mật khẩu";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label6.Location = new System.Drawing.Point(67, 161);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(119, 20);
            this.label6.TabIndex = 6;
            this.label6.Text = "Tên đăng nhập";
            // 
            // txtRegHoTen
            // 
            this.txtRegHoTen.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegHoTen.Location = new System.Drawing.Point(60, 115);
            this.txtRegHoTen.Name = "txtRegHoTen";
            this.txtRegHoTen.Size = new System.Drawing.Size(260, 34);
            this.txtRegHoTen.TabIndex = 12;
            this.txtRegHoTen.Enter += new System.EventHandler(this.txtLoginUser_Enter);
            this.txtRegHoTen.Leave += new System.EventHandler(this.txtLoginUser_Leave);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label7.Location = new System.Drawing.Point(67, 91);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(81, 20);
            this.label7.TabIndex = 11;
            this.label7.Text = "Họ và tên";
            // 
            // txtRegPass
            // 
            this.txtRegPass.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRegPass.Location = new System.Drawing.Point(60, 261);
            this.txtRegPass.Name = "txtRegPass";
            this.txtRegPass.Size = new System.Drawing.Size(260, 34);
            this.txtRegPass.TabIndex = 14;
            this.txtRegPass.Enter += new System.EventHandler(this.txtLoginUser_Enter);
            this.txtRegPass.Leave += new System.EventHandler(this.txtLoginUser_Leave);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.SystemColors.ControlText;
            this.label8.Location = new System.Drawing.Point(67, 237);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(77, 20);
            this.label8.TabIndex = 13;
            this.label8.Text = "Mật khẩu";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Font = new System.Drawing.Font("Times New Roman", 19.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.Location = new System.Drawing.Point(23, 13);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(327, 39);
            this.label9.TabIndex = 15;
            this.label9.Text = "Đăng ký tài khoản mới";
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.WindowFrame;
            this.panel1.Location = new System.Drawing.Point(-9, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(10, 452);
            this.panel1.TabIndex = 1;
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.AliceBlue;
            this.ClientSize = new System.Drawing.Size(872, 543);
            this.Controls.Add(this.pnlMain);
            this.Name = "LoginForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "LoginForm";
            this.pnlMain.ResumeLayout(false);
            this.pnlRegister.ResumeLayout(false);
            this.pnlRegister.PerformLayout();
            this.pnlLogin.ResumeLayout(false);
            this.pnlLogin.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel pnlMain;
        private System.Windows.Forms.Panel pnlRegister;
        private System.Windows.Forms.Panel pnlLogin;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.TextBox txtLoginPass;
        private System.Windows.Forms.TextBox txtLoginUser;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtRegPass;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtRegHoTen;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Button btnRegister;
        private System.Windows.Forms.TextBox txtRegConfirmPass;
        private System.Windows.Forms.TextBox txtRegUser;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Panel panel1;
    }
}