namespace FastBox.UI.Forms
{
    partial class FormAtualizarVeiculo
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
            LblMarca = new Label();
            TxtMarca = new TextBox();
            TxtModelo = new TextBox();
            LblModelo = new Label();
            LblAno = new Label();
            LblObservacoes = new Label();
            LblMatricula = new Label();
            PanelInfoVeiculo = new Panel();
            DgvVeiculosClientes = new DataGridView();
            BtnNovoCliente = new Button();
            LblCliente = new Label();
            TxtCliente = new TextBox();
            RTxtObservacoes = new RichTextBox();
            TxtMskMatricula = new MaskedTextBox();
            TxtMskAno = new MaskedTextBox();
            LblInfoVeiculo = new Label();
            BtnAtualizarVeiculo = new Button();
            PanelInfoVeiculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvVeiculosClientes).BeginInit();
            SuspendLayout();
            // 
            // LblMarca
            // 
            LblMarca.AutoSize = true;
            LblMarca.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblMarca.Location = new Point(9, 14);
            LblMarca.Name = "LblMarca";
            LblMarca.Size = new Size(68, 26);
            LblMarca.TabIndex = 0;
            LblMarca.Text = "Marca:";
            // 
            // TxtMarca
            // 
            TxtMarca.BackColor = SystemColors.Window;
            TxtMarca.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtMarca.Location = new Point(81, 11);
            TxtMarca.Name = "TxtMarca";
            TxtMarca.Size = new Size(167, 33);
            TxtMarca.TabIndex = 1;
            // 
            // TxtModelo
            // 
            TxtModelo.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtModelo.Location = new Point(336, 11);
            TxtModelo.Name = "TxtModelo";
            TxtModelo.Size = new Size(307, 33);
            TxtModelo.TabIndex = 2;
            // 
            // LblModelo
            // 
            LblModelo.AutoSize = true;
            LblModelo.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblModelo.Location = new Point(252, 14);
            LblModelo.Name = "LblModelo";
            LblModelo.Size = new Size(80, 26);
            LblModelo.TabIndex = 2;
            LblModelo.Text = "Modelo:";
            // 
            // LblAno
            // 
            LblAno.AutoSize = true;
            LblAno.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblAno.Location = new Point(649, 14);
            LblAno.Name = "LblAno";
            LblAno.Size = new Size(50, 26);
            LblAno.TabIndex = 4;
            LblAno.Text = "Ano:";
            // 
            // LblObservacoes
            // 
            LblObservacoes.AutoSize = true;
            LblObservacoes.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblObservacoes.Location = new Point(277, 66);
            LblObservacoes.Name = "LblObservacoes";
            LblObservacoes.Size = new Size(125, 26);
            LblObservacoes.TabIndex = 6;
            LblObservacoes.Text = "Observações:";
            // 
            // LblMatricula
            // 
            LblMatricula.AutoSize = true;
            LblMatricula.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblMatricula.Location = new Point(9, 66);
            LblMatricula.Name = "LblMatricula";
            LblMatricula.Size = new Size(94, 26);
            LblMatricula.TabIndex = 8;
            LblMatricula.Text = "Matrícula:";
            // 
            // PanelInfoVeiculo
            // 
            PanelInfoVeiculo.BorderStyle = BorderStyle.Fixed3D;
            PanelInfoVeiculo.Controls.Add(DgvVeiculosClientes);
            PanelInfoVeiculo.Controls.Add(BtnNovoCliente);
            PanelInfoVeiculo.Controls.Add(LblCliente);
            PanelInfoVeiculo.Controls.Add(TxtCliente);
            PanelInfoVeiculo.Controls.Add(RTxtObservacoes);
            PanelInfoVeiculo.Controls.Add(TxtMskMatricula);
            PanelInfoVeiculo.Controls.Add(TxtMskAno);
            PanelInfoVeiculo.Controls.Add(LblMarca);
            PanelInfoVeiculo.Controls.Add(TxtMarca);
            PanelInfoVeiculo.Controls.Add(LblMatricula);
            PanelInfoVeiculo.Controls.Add(LblModelo);
            PanelInfoVeiculo.Controls.Add(TxtModelo);
            PanelInfoVeiculo.Controls.Add(LblObservacoes);
            PanelInfoVeiculo.Controls.Add(LblAno);
            PanelInfoVeiculo.Enabled = false;
            PanelInfoVeiculo.Location = new Point(4, 25);
            PanelInfoVeiculo.Name = "PanelInfoVeiculo";
            PanelInfoVeiculo.Size = new Size(780, 364);
            PanelInfoVeiculo.TabIndex = 10;
            // 
            // DgvVeiculosClientes
            // 
            DgvVeiculosClientes.AllowUserToAddRows = false;
            DgvVeiculosClientes.AllowUserToDeleteRows = false;
            DgvVeiculosClientes.AllowUserToResizeColumns = false;
            DgvVeiculosClientes.AllowUserToResizeRows = false;
            DgvVeiculosClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvVeiculosClientes.Dock = DockStyle.Bottom;
            DgvVeiculosClientes.Location = new Point(0, 163);
            DgvVeiculosClientes.Name = "DgvVeiculosClientes";
            DgvVeiculosClientes.ReadOnly = true;
            DgvVeiculosClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvVeiculosClientes.Size = new Size(776, 197);
            DgvVeiculosClientes.TabIndex = 17;
            DgvVeiculosClientes.CellClick += DgvVeiculosClientes_CellClick;
            // 
            // BtnNovoCliente
            // 
            BtnNovoCliente.BackColor = SystemColors.ControlLight;
            BtnNovoCliente.Location = new Point(297, 112);
            BtnNovoCliente.Name = "BtnNovoCliente";
            BtnNovoCliente.Size = new Size(100, 33);
            BtnNovoCliente.TabIndex = 16;
            BtnNovoCliente.Text = "Novo cliente";
            BtnNovoCliente.UseVisualStyleBackColor = false;
            BtnNovoCliente.Click += BtnNovoCliente_Click;
            // 
            // LblCliente
            // 
            LblCliente.AutoSize = true;
            LblCliente.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblCliente.Location = new Point(9, 115);
            LblCliente.Name = "LblCliente";
            LblCliente.Size = new Size(75, 26);
            LblCliente.TabIndex = 14;
            LblCliente.Text = "Cliente:";
            // 
            // TxtCliente
            // 
            TxtCliente.BackColor = SystemColors.Window;
            TxtCliente.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtCliente.Location = new Point(87, 112);
            TxtCliente.Name = "TxtCliente";
            TxtCliente.Size = new Size(201, 33);
            TxtCliente.TabIndex = 15;
            TxtCliente.TextChanged += TxtCliente_TextChanged;
            // 
            // RTxtObservacoes
            // 
            RTxtObservacoes.Location = new Point(406, 63);
            RTxtObservacoes.Name = "RTxtObservacoes";
            RTxtObservacoes.Size = new Size(361, 94);
            RTxtObservacoes.TabIndex = 13;
            RTxtObservacoes.Text = "";
            // 
            // TxtMskMatricula
            // 
            TxtMskMatricula.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtMskMatricula.Location = new Point(107, 63);
            TxtMskMatricula.Name = "TxtMskMatricula";
            TxtMskMatricula.Size = new Size(164, 33);
            TxtMskMatricula.TabIndex = 5;
            TxtMskMatricula.KeyPress += TxtMskMatricula_KeyPress;
            // 
            // TxtMskAno
            // 
            TxtMskAno.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtMskAno.Location = new Point(703, 11);
            TxtMskAno.Mask = "0000";
            TxtMskAno.Name = "TxtMskAno";
            TxtMskAno.Size = new Size(64, 33);
            TxtMskAno.TabIndex = 3;
            // 
            // LblInfoVeiculo
            // 
            LblInfoVeiculo.AutoSize = true;
            LblInfoVeiculo.Location = new Point(5, 5);
            LblInfoVeiculo.Name = "LblInfoVeiculo";
            LblInfoVeiculo.Size = new Size(144, 17);
            LblInfoVeiculo.TabIndex = 11;
            LblInfoVeiculo.Text = "Informações do veiculo";
            // 
            // BtnAtualizarVeiculo
            // 
            BtnAtualizarVeiculo.BackColor = SystemColors.ControlLight;
            BtnAtualizarVeiculo.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnAtualizarVeiculo.Location = new Point(4, 395);
            BtnAtualizarVeiculo.Name = "BtnAtualizarVeiculo";
            BtnAtualizarVeiculo.Size = new Size(778, 55);
            BtnAtualizarVeiculo.TabIndex = 15;
            BtnAtualizarVeiculo.Text = "Atualizar";
            BtnAtualizarVeiculo.UseVisualStyleBackColor = false;
            BtnAtualizarVeiculo.Click += BtnAtualizarVeiculo_Click;
            // 
            // FormAtualizarVeiculo
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(784, 461);
            Controls.Add(BtnAtualizarVeiculo);
            Controls.Add(LblInfoVeiculo);
            Controls.Add(PanelInfoVeiculo);
            MaximizeBox = false;
            MaximumSize = new Size(800, 500);
            MinimumSize = new Size(800, 500);
            Name = "FormAtualizarVeiculo";
            Text = "FastBox - Atualizar veículo";
            Load += FormAtualizarVeiculo_Load;
            PanelInfoVeiculo.ResumeLayout(false);
            PanelInfoVeiculo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvVeiculosClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblMarca;
        private TextBox TxtMarca;
        private TextBox TxtModelo;
        private Label LblModelo;
        private Label LblAno;
        private Label LblObservacoes;
        private Label LblMatricula;
        private Panel PanelInfoVeiculo;
        private Label LblInfoVeiculo;
        private Button BtnAtualizarVeiculo;
        private MaskedTextBox TxtMskAno;
        private MaskedTextBox TxtMskMatricula;
        private RichTextBox RTxtObservacoes;
        private Button BtnNovoCliente;
        private Label LblCliente;
        private TextBox TxtCliente;
        private DataGridView DgvVeiculosClientes;
    }
}