namespace FastBox.UI
{
    partial class FormLogin
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
            LblLogin = new Label();
            LblPassword = new Label();
            TxtLogin = new TextBox();
            TxtPassword = new TextBox();
            BtnEntrar = new Button();
            PicBoxLogo = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)PicBoxLogo).BeginInit();
            SuspendLayout();
            // 
            // LblLogin
            // 
            LblLogin.AutoSize = true;
            LblLogin.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            LblLogin.Location = new Point(22, 109);
            LblLogin.Name = "LblLogin";
            LblLogin.Size = new Size(58, 21);
            LblLogin.TabIndex = 0;
            LblLogin.Text = "Login: ";
            // 
            // LblPassword
            // 
            LblPassword.AutoSize = true;
            LblPassword.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            LblPassword.Location = new Point(22, 184);
            LblPassword.Name = "LblPassword";
            LblPassword.Size = new Size(61, 21);
            LblPassword.TabIndex = 1;
            LblPassword.Text = "Senha: ";
            // 
            // TxtLogin
            // 
            TxtLogin.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtLogin.Location = new Point(22, 136);
            TxtLogin.Name = "TxtLogin";
            TxtLogin.Size = new Size(273, 32);
            TxtLogin.TabIndex = 2;
            // 
            // TxtPassword
            // 
            TxtPassword.Font = new Font("Segoe UI Semibold", 14F, FontStyle.Bold, GraphicsUnit.Point, 0);
            TxtPassword.Location = new Point(22, 211);
            TxtPassword.Name = "TxtPassword";
            TxtPassword.PasswordChar = '*';
            TxtPassword.Size = new Size(273, 32);
            TxtPassword.TabIndex = 3;
            // 
            // BtnEntrar
            // 
            BtnEntrar.Font = new Font("Segoe UI", 15.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            BtnEntrar.Location = new Point(61, 284);
            BtnEntrar.Name = "BtnEntrar";
            BtnEntrar.Size = new Size(184, 43);
            BtnEntrar.TabIndex = 4;
            BtnEntrar.Text = "Entrar";
            BtnEntrar.UseVisualStyleBackColor = true;
            BtnEntrar.Click += btnEntrar_Click;
            // 
            // PicBoxLogo
            // 
            PicBoxLogo.Image = Properties.Resources.Ativo_13;
            PicBoxLogo.Location = new Point(59, 9);
            PicBoxLogo.Name = "PicBoxLogo";
            PicBoxLogo.Size = new Size(185, 101);
            PicBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            PicBoxLogo.TabIndex = 5;
            PicBoxLogo.TabStop = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(312, 373);
            Controls.Add(LblLogin);
            Controls.Add(PicBoxLogo);
            Controls.Add(BtnEntrar);
            Controls.Add(TxtPassword);
            Controls.Add(TxtLogin);
            Controls.Add(LblPassword);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            MaximumSize = new Size(328, 412);
            MinimumSize = new Size(328, 412);
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FastBox - Login";
            ((System.ComponentModel.ISupportInitialize)PicBoxLogo).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblLogin;
        private Label LblPassword;
        private TextBox TxtLogin;
        private TextBox TxtPassword;
        private Button BtnEntrar;
        private PictureBox PicBoxLogo;
    }
}