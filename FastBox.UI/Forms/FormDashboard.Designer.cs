namespace FastBox.UI
{
    partial class FormDashboard
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
            components = new System.ComponentModel.Container();
            PanelTopMenu = new Panel();
            PanelTopMenuBorder = new Panel();
            LblDataHora = new Label();
            LblTitulo = new Label();
            LblBemVindo = new Label();
            PicBoxLogo = new PictureBox();
            PanelSideMenu = new Panel();
            BtnSair = new Button();
            BtnConfiguracoes = new Button();
            BtnRelatorios = new Button();
            BtnOrdensDeServico = new Button();
            BtnVeiculos = new Button();
            BtnClientes = new Button();
            PanelMain = new Panel();
            DataHora = new System.Windows.Forms.Timer(components);
            PanelTopMenu.SuspendLayout();
            PanelTopMenuBorder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PicBoxLogo).BeginInit();
            PanelSideMenu.SuspendLayout();
            SuspendLayout();
            // 
            // PanelTopMenu
            // 
            PanelTopMenu.BackColor = SystemColors.ControlLight;
            PanelTopMenu.BorderStyle = BorderStyle.Fixed3D;
            PanelTopMenu.Controls.Add(PanelTopMenuBorder);
            PanelTopMenu.Controls.Add(PicBoxLogo);
            PanelTopMenu.Dock = DockStyle.Top;
            PanelTopMenu.Location = new Point(0, 0);
            PanelTopMenu.Name = "PanelTopMenu";
            PanelTopMenu.Size = new Size(1264, 79);
            PanelTopMenu.TabIndex = 0;
            // 
            // PanelTopMenuBorder
            // 
            PanelTopMenuBorder.AutoSize = true;
            PanelTopMenuBorder.BackColor = SystemColors.ControlLight;
            PanelTopMenuBorder.BorderStyle = BorderStyle.Fixed3D;
            PanelTopMenuBorder.Controls.Add(LblDataHora);
            PanelTopMenuBorder.Controls.Add(LblTitulo);
            PanelTopMenuBorder.Controls.Add(LblBemVindo);
            PanelTopMenuBorder.Dock = DockStyle.Fill;
            PanelTopMenuBorder.Location = new Point(233, 0);
            PanelTopMenuBorder.Name = "PanelTopMenuBorder";
            PanelTopMenuBorder.Size = new Size(1027, 75);
            PanelTopMenuBorder.TabIndex = 4;
            // 
            // LblDataHora
            // 
            LblDataHora.Anchor = AnchorStyles.Right;
            LblDataHora.AutoSize = true;
            LblDataHora.Font = new Font("Segoe UI", 20F);
            LblDataHora.Location = new Point(747, 15);
            LblDataHora.Name = "LblDataHora";
            LblDataHora.Size = new Size(0, 37);
            LblDataHora.TabIndex = 4;
            // 
            // LblTitulo
            // 
            LblTitulo.Anchor = AnchorStyles.Left;
            LblTitulo.AutoSize = true;
            LblTitulo.Font = new Font("Segoe UI Variable Display Semib", 20F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LblTitulo.Location = new Point(6, 13);
            LblTitulo.Name = "LblTitulo";
            LblTitulo.Size = new Size(447, 36);
            LblTitulo.TabIndex = 1;
            LblTitulo.Text = "Sistema de Gestão para Oficinas 🛠";
            // 
            // LblBemVindo
            // 
            LblBemVindo.Anchor = AnchorStyles.Left;
            LblBemVindo.AutoSize = true;
            LblBemVindo.Location = new Point(18, 49);
            LblBemVindo.Name = "LblBemVindo";
            LblBemVindo.Size = new Size(175, 17);
            LblBemVindo.TabIndex = 2;
            LblBemVindo.Text = "Seja bem vindo fastboxadm!";
            // 
            // PicBoxLogo
            // 
            PicBoxLogo.BorderStyle = BorderStyle.Fixed3D;
            PicBoxLogo.Cursor = Cursors.Hand;
            PicBoxLogo.Dock = DockStyle.Left;
            PicBoxLogo.Image = Properties.Resources.Ativo_13;
            PicBoxLogo.Location = new Point(0, 0);
            PicBoxLogo.Name = "PicBoxLogo";
            PicBoxLogo.Size = new Size(233, 75);
            PicBoxLogo.SizeMode = PictureBoxSizeMode.Zoom;
            PicBoxLogo.TabIndex = 0;
            PicBoxLogo.TabStop = false;
            PicBoxLogo.Click += PicBoxLogo_Click;
            // 
            // PanelSideMenu
            // 
            PanelSideMenu.BackColor = SystemColors.ControlLight;
            PanelSideMenu.BorderStyle = BorderStyle.Fixed3D;
            PanelSideMenu.Controls.Add(BtnSair);
            PanelSideMenu.Controls.Add(BtnConfiguracoes);
            PanelSideMenu.Controls.Add(BtnRelatorios);
            PanelSideMenu.Controls.Add(BtnOrdensDeServico);
            PanelSideMenu.Controls.Add(BtnVeiculos);
            PanelSideMenu.Controls.Add(BtnClientes);
            PanelSideMenu.Dock = DockStyle.Left;
            PanelSideMenu.Location = new Point(0, 79);
            PanelSideMenu.Name = "PanelSideMenu";
            PanelSideMenu.Size = new Size(235, 602);
            PanelSideMenu.TabIndex = 1;
            // 
            // BtnSair
            // 
            BtnSair.BackColor = SystemColors.ControlLight;
            BtnSair.Cursor = Cursors.Hand;
            BtnSair.Dock = DockStyle.Top;
            BtnSair.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold);
            BtnSair.Location = new Point(0, 320);
            BtnSair.Name = "BtnSair";
            BtnSair.Size = new Size(231, 64);
            BtnSair.TabIndex = 5;
            BtnSair.Text = "Sair";
            BtnSair.UseVisualStyleBackColor = false;
            BtnSair.Click += BtnSair_Click;
            // 
            // BtnConfiguracoes
            // 
            BtnConfiguracoes.BackColor = SystemColors.ControlLight;
            BtnConfiguracoes.Cursor = Cursors.Hand;
            BtnConfiguracoes.Dock = DockStyle.Top;
            BtnConfiguracoes.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold);
            BtnConfiguracoes.Location = new Point(0, 256);
            BtnConfiguracoes.Name = "BtnConfiguracoes";
            BtnConfiguracoes.Size = new Size(231, 64);
            BtnConfiguracoes.TabIndex = 4;
            BtnConfiguracoes.Text = "Configurações";
            BtnConfiguracoes.UseVisualStyleBackColor = false;
            // 
            // BtnRelatorios
            // 
            BtnRelatorios.BackColor = SystemColors.ControlLight;
            BtnRelatorios.Cursor = Cursors.Hand;
            BtnRelatorios.Dock = DockStyle.Top;
            BtnRelatorios.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold);
            BtnRelatorios.Location = new Point(0, 192);
            BtnRelatorios.Name = "BtnRelatorios";
            BtnRelatorios.Size = new Size(231, 64);
            BtnRelatorios.TabIndex = 3;
            BtnRelatorios.Text = "Relatórios";
            BtnRelatorios.UseVisualStyleBackColor = false;
            // 
            // BtnOrdensDeServico
            // 
            BtnOrdensDeServico.BackColor = SystemColors.ControlLight;
            BtnOrdensDeServico.Cursor = Cursors.Hand;
            BtnOrdensDeServico.Dock = DockStyle.Top;
            BtnOrdensDeServico.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold);
            BtnOrdensDeServico.Location = new Point(0, 128);
            BtnOrdensDeServico.Name = "BtnOrdensDeServico";
            BtnOrdensDeServico.Size = new Size(231, 64);
            BtnOrdensDeServico.TabIndex = 2;
            BtnOrdensDeServico.Text = "Ordens de serviço";
            BtnOrdensDeServico.UseVisualStyleBackColor = false;
            // 
            // BtnVeiculos
            // 
            BtnVeiculos.BackColor = SystemColors.ControlLight;
            BtnVeiculos.Cursor = Cursors.Hand;
            BtnVeiculos.Dock = DockStyle.Top;
            BtnVeiculos.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold);
            BtnVeiculos.Location = new Point(0, 64);
            BtnVeiculos.Name = "BtnVeiculos";
            BtnVeiculos.Size = new Size(231, 64);
            BtnVeiculos.TabIndex = 1;
            BtnVeiculos.Text = "Veículos";
            BtnVeiculos.UseVisualStyleBackColor = false;
            // 
            // BtnClientes
            // 
            BtnClientes.BackColor = SystemColors.ControlLight;
            BtnClientes.Cursor = Cursors.Hand;
            BtnClientes.Dock = DockStyle.Top;
            BtnClientes.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            BtnClientes.Location = new Point(0, 0);
            BtnClientes.Name = "BtnClientes";
            BtnClientes.Size = new Size(231, 64);
            BtnClientes.TabIndex = 0;
            BtnClientes.Text = "Clientes";
            BtnClientes.UseVisualStyleBackColor = false;
            BtnClientes.Click += BtnClientes_Click;
            // 
            // PanelMain
            // 
            PanelMain.BackColor = SystemColors.ControlLight;
            PanelMain.BorderStyle = BorderStyle.Fixed3D;
            PanelMain.Dock = DockStyle.Fill;
            PanelMain.Location = new Point(235, 79);
            PanelMain.Name = "PanelMain";
            PanelMain.Size = new Size(1029, 602);
            PanelMain.TabIndex = 2;
            // 
            // DataHora
            // 
            DataHora.Enabled = true;
            DataHora.Interval = 1000;
            DataHora.Tick += DataHora_Tick;
            // 
            // FormDashboard
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(PanelMain);
            Controls.Add(PanelSideMenu);
            Controls.Add(PanelTopMenu);
            Name = "FormDashboard";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "FastBox - Dashboard";
            WindowState = FormWindowState.Maximized;
            FormClosing += FormDashboard_FormClosing;
            Load += FormDashboard_Load;
            PanelTopMenu.ResumeLayout(false);
            PanelTopMenu.PerformLayout();
            PanelTopMenuBorder.ResumeLayout(false);
            PanelTopMenuBorder.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PicBoxLogo).EndInit();
            PanelSideMenu.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel PanelTopMenu;
        private PictureBox PicBoxLogo;
        private Panel PanelSideMenu;
        private Panel PanelMain;
        private Button BtnOrdensDeServico;
        private Button BtnVeiculos;
        private Button BtnClientes;
        private Button BtnConfiguracoes;
        private Button BtnRelatorios;
        private Label LblBemVindo;
        private Label LblTitulo;
        private System.Windows.Forms.Timer DataHora;
        private Panel PanelTopMenuBorder;
        private Label LblDataHora;
        private Button BtnSair;
    }
}