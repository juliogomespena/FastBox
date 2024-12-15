namespace FastBox.UI.Forms
{
    partial class FormCadastrarOrdem
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
            LblClienteOrdemCadastrar = new Label();
            PanelInfoOrdemCadastrar = new Panel();
            TxtVeiculoOrdemCadastrar = new TextBox();
            LblPrazoEstimadoOrdemCadastrar = new Label();
            LblInfoOrcamentos = new Label();
            DateTimePickerEstimativaConclusao = new DateTimePicker();
            LstSugestoesClientes = new ListBox();
            LstSugestoesVeiculos = new ListBox();
            LblDescricaoOrdemCadastrar = new Label();
            RTxtDescricaoOrdemCadastrar = new RichTextBox();
            BtnNovoVeiculoOrdemCadastrar = new Button();
            BtnNovoClienteOrdemCadastrar = new Button();
            LblVeiculoOrdemCadastrar = new Label();
            TxtClienteOrdemCadastrar = new TextBox();
            PanelOrcamentosOrdemCadastrar = new Panel();
            BtnExcluirOrcamentoOrdemCadastrar = new Button();
            BtnReprovarOrcamentoOrdemCadastrar = new Button();
            BtnNovoOrcamentoOrdemCadastrar = new Button();
            BtnAprovarOrcamentoOrdemCadastrar = new Button();
            BtnEditarOrcamentoOrdemCadastrar = new Button();
            DgvOrcamentosCadastrarOrdem = new DataGridView();
            LblInfoOrdemCadastrar = new Label();
            BtnGerarOrdemCadastrar = new Button();
            PanelInfoOrdemCadastrar.SuspendLayout();
            PanelOrcamentosOrdemCadastrar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvOrcamentosCadastrarOrdem).BeginInit();
            SuspendLayout();
            // 
            // LblClienteOrdemCadastrar
            // 
            LblClienteOrdemCadastrar.AutoSize = true;
            LblClienteOrdemCadastrar.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblClienteOrdemCadastrar.Location = new Point(8, 14);
            LblClienteOrdemCadastrar.Name = "LblClienteOrdemCadastrar";
            LblClienteOrdemCadastrar.Size = new Size(75, 26);
            LblClienteOrdemCadastrar.TabIndex = 0;
            LblClienteOrdemCadastrar.Text = "Cliente:";
            // 
            // PanelInfoOrdemCadastrar
            // 
            PanelInfoOrdemCadastrar.BorderStyle = BorderStyle.Fixed3D;
            PanelInfoOrdemCadastrar.Controls.Add(TxtVeiculoOrdemCadastrar);
            PanelInfoOrdemCadastrar.Controls.Add(LblPrazoEstimadoOrdemCadastrar);
            PanelInfoOrdemCadastrar.Controls.Add(LblInfoOrcamentos);
            PanelInfoOrdemCadastrar.Controls.Add(DateTimePickerEstimativaConclusao);
            PanelInfoOrdemCadastrar.Controls.Add(LstSugestoesClientes);
            PanelInfoOrdemCadastrar.Controls.Add(LstSugestoesVeiculos);
            PanelInfoOrdemCadastrar.Controls.Add(LblDescricaoOrdemCadastrar);
            PanelInfoOrdemCadastrar.Controls.Add(RTxtDescricaoOrdemCadastrar);
            PanelInfoOrdemCadastrar.Controls.Add(BtnNovoVeiculoOrdemCadastrar);
            PanelInfoOrdemCadastrar.Controls.Add(BtnNovoClienteOrdemCadastrar);
            PanelInfoOrdemCadastrar.Controls.Add(LblVeiculoOrdemCadastrar);
            PanelInfoOrdemCadastrar.Controls.Add(TxtClienteOrdemCadastrar);
            PanelInfoOrdemCadastrar.Controls.Add(LblClienteOrdemCadastrar);
            PanelInfoOrdemCadastrar.Controls.Add(PanelOrcamentosOrdemCadastrar);
            PanelInfoOrdemCadastrar.Location = new Point(4, 25);
            PanelInfoOrdemCadastrar.Name = "PanelInfoOrdemCadastrar";
            PanelInfoOrdemCadastrar.Size = new Size(778, 463);
            PanelInfoOrdemCadastrar.TabIndex = 10;
            // 
            // TxtVeiculoOrdemCadastrar
            // 
            TxtVeiculoOrdemCadastrar.BackColor = SystemColors.Window;
            TxtVeiculoOrdemCadastrar.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtVeiculoOrdemCadastrar.Location = new Point(510, 11);
            TxtVeiculoOrdemCadastrar.Name = "TxtVeiculoOrdemCadastrar";
            TxtVeiculoOrdemCadastrar.Size = new Size(156, 33);
            TxtVeiculoOrdemCadastrar.TabIndex = 2;
            TxtVeiculoOrdemCadastrar.TextChanged += TxtVeiculoOrdemCadastrar_TextChanged;
            TxtVeiculoOrdemCadastrar.KeyPress += TxtVeiculoOrdemCadastrar_KeyPress;
            // 
            // LblPrazoEstimadoOrdemCadastrar
            // 
            LblPrazoEstimadoOrdemCadastrar.AutoSize = true;
            LblPrazoEstimadoOrdemCadastrar.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPrazoEstimadoOrdemCadastrar.Location = new Point(498, 184);
            LblPrazoEstimadoOrdemCadastrar.Name = "LblPrazoEstimadoOrdemCadastrar";
            LblPrazoEstimadoOrdemCadastrar.Size = new Size(121, 21);
            LblPrazoEstimadoOrdemCadastrar.TabIndex = 32;
            LblPrazoEstimadoOrdemCadastrar.Text = "Prazo estimado:";
            // 
            // LblInfoOrcamentos
            // 
            LblInfoOrcamentos.AutoSize = true;
            LblInfoOrcamentos.Location = new Point(2, 202);
            LblInfoOrcamentos.Name = "LblInfoOrcamentos";
            LblInfoOrcamentos.Size = new Size(79, 17);
            LblInfoOrcamentos.TabIndex = 16;
            LblInfoOrcamentos.Text = "Orçamentos";
            // 
            // DateTimePickerEstimativaConclusao
            // 
            DateTimePickerEstimativaConclusao.CustomFormat = "dd/MM/yyyy HH'h'";
            DateTimePickerEstimativaConclusao.Format = DateTimePickerFormat.Custom;
            DateTimePickerEstimativaConclusao.Location = new Point(621, 183);
            DateTimePickerEstimativaConclusao.Name = "DateTimePickerEstimativaConclusao";
            DateTimePickerEstimativaConclusao.ShowUpDown = true;
            DateTimePickerEstimativaConclusao.Size = new Size(138, 25);
            DateTimePickerEstimativaConclusao.TabIndex = 4;
            // 
            // LstSugestoesClientes
            // 
            LstSugestoesClientes.FormattingEnabled = true;
            LstSugestoesClientes.IntegralHeight = false;
            LstSugestoesClientes.ItemHeight = 17;
            LstSugestoesClientes.Location = new Point(89, 44);
            LstSugestoesClientes.Name = "LstSugestoesClientes";
            LstSugestoesClientes.Size = new Size(1, 1);
            LstSugestoesClientes.TabIndex = 22;
            LstSugestoesClientes.Visible = false;
            LstSugestoesClientes.Click += LstSugestoesClientes_Click;
            LstSugestoesClientes.KeyDown += LstSugestoesClientes_KeyDown;
            // 
            // LstSugestoesVeiculos
            // 
            LstSugestoesVeiculos.FormattingEnabled = true;
            LstSugestoesVeiculos.IntegralHeight = false;
            LstSugestoesVeiculos.ItemHeight = 17;
            LstSugestoesVeiculos.Location = new Point(510, 44);
            LstSugestoesVeiculos.Name = "LstSugestoesVeiculos";
            LstSugestoesVeiculos.Size = new Size(1, 1);
            LstSugestoesVeiculos.TabIndex = 33;
            LstSugestoesVeiculos.Visible = false;
            LstSugestoesVeiculos.Click += LstSugestoesVeiculos_Click;
            LstSugestoesVeiculos.KeyDown += LstSugestoesVeiculos_KeyDown;
            // 
            // LblDescricaoOrdemCadastrar
            // 
            LblDescricaoOrdemCadastrar.AutoSize = true;
            LblDescricaoOrdemCadastrar.Location = new Point(3, 56);
            LblDescricaoOrdemCadastrar.Name = "LblDescricaoOrdemCadastrar";
            LblDescricaoOrdemCadastrar.Size = new Size(65, 17);
            LblDescricaoOrdemCadastrar.TabIndex = 25;
            LblDescricaoOrdemCadastrar.Text = "Descrição";
            // 
            // RTxtDescricaoOrdemCadastrar
            // 
            RTxtDescricaoOrdemCadastrar.Font = new Font("Segoe UI", 12F);
            RTxtDescricaoOrdemCadastrar.Location = new Point(3, 76);
            RTxtDescricaoOrdemCadastrar.Name = "RTxtDescricaoOrdemCadastrar";
            RTxtDescricaoOrdemCadastrar.Size = new Size(770, 98);
            RTxtDescricaoOrdemCadastrar.TabIndex = 3;
            RTxtDescricaoOrdemCadastrar.Text = "";
            // 
            // BtnNovoVeiculoOrdemCadastrar
            // 
            BtnNovoVeiculoOrdemCadastrar.BackColor = SystemColors.ControlLight;
            BtnNovoVeiculoOrdemCadastrar.Font = new Font("Segoe UI Variable Display Semib", 8F, FontStyle.Bold);
            BtnNovoVeiculoOrdemCadastrar.Location = new Point(672, 11);
            BtnNovoVeiculoOrdemCadastrar.Name = "BtnNovoVeiculoOrdemCadastrar";
            BtnNovoVeiculoOrdemCadastrar.Size = new Size(90, 34);
            BtnNovoVeiculoOrdemCadastrar.TabIndex = 101;
            BtnNovoVeiculoOrdemCadastrar.Text = "Novo veículo";
            BtnNovoVeiculoOrdemCadastrar.UseVisualStyleBackColor = false;
            BtnNovoVeiculoOrdemCadastrar.Click += BtnNovoVeiculoOrdemCadastrar_Click;
            // 
            // BtnNovoClienteOrdemCadastrar
            // 
            BtnNovoClienteOrdemCadastrar.BackColor = SystemColors.ControlLight;
            BtnNovoClienteOrdemCadastrar.Font = new Font("Segoe UI Variable Display Semib", 8F, FontStyle.Bold);
            BtnNovoClienteOrdemCadastrar.Location = new Point(303, 11);
            BtnNovoClienteOrdemCadastrar.Name = "BtnNovoClienteOrdemCadastrar";
            BtnNovoClienteOrdemCadastrar.Size = new Size(81, 34);
            BtnNovoClienteOrdemCadastrar.TabIndex = 100;
            BtnNovoClienteOrdemCadastrar.Text = "Novo cliente";
            BtnNovoClienteOrdemCadastrar.UseVisualStyleBackColor = false;
            BtnNovoClienteOrdemCadastrar.Click += BtnNovoClienteOrdemCadastrar_Click;
            // 
            // LblVeiculoOrdemCadastrar
            // 
            LblVeiculoOrdemCadastrar.AutoSize = true;
            LblVeiculoOrdemCadastrar.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblVeiculoOrdemCadastrar.Location = new Point(427, 14);
            LblVeiculoOrdemCadastrar.Name = "LblVeiculoOrdemCadastrar";
            LblVeiculoOrdemCadastrar.Size = new Size(77, 26);
            LblVeiculoOrdemCadastrar.TabIndex = 20;
            LblVeiculoOrdemCadastrar.Text = "Veículo:";
            // 
            // TxtClienteOrdemCadastrar
            // 
            TxtClienteOrdemCadastrar.BackColor = SystemColors.Window;
            TxtClienteOrdemCadastrar.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtClienteOrdemCadastrar.Location = new Point(89, 11);
            TxtClienteOrdemCadastrar.Name = "TxtClienteOrdemCadastrar";
            TxtClienteOrdemCadastrar.Size = new Size(208, 33);
            TxtClienteOrdemCadastrar.TabIndex = 1;
            TxtClienteOrdemCadastrar.TextChanged += TxtClienteOrdem_TextChanged;
            // 
            // PanelOrcamentosOrdemCadastrar
            // 
            PanelOrcamentosOrdemCadastrar.BorderStyle = BorderStyle.Fixed3D;
            PanelOrcamentosOrdemCadastrar.Controls.Add(BtnExcluirOrcamentoOrdemCadastrar);
            PanelOrcamentosOrdemCadastrar.Controls.Add(BtnReprovarOrcamentoOrdemCadastrar);
            PanelOrcamentosOrdemCadastrar.Controls.Add(BtnNovoOrcamentoOrdemCadastrar);
            PanelOrcamentosOrdemCadastrar.Controls.Add(BtnAprovarOrcamentoOrdemCadastrar);
            PanelOrcamentosOrdemCadastrar.Controls.Add(BtnEditarOrcamentoOrdemCadastrar);
            PanelOrcamentosOrdemCadastrar.Controls.Add(DgvOrcamentosCadastrarOrdem);
            PanelOrcamentosOrdemCadastrar.Location = new Point(-2, 222);
            PanelOrcamentosOrdemCadastrar.Name = "PanelOrcamentosOrdemCadastrar";
            PanelOrcamentosOrdemCadastrar.Size = new Size(778, 239);
            PanelOrcamentosOrdemCadastrar.TabIndex = 31;
            // 
            // BtnExcluirOrcamentoOrdemCadastrar
            // 
            BtnExcluirOrcamentoOrdemCadastrar.BackColor = SystemColors.ControlLight;
            BtnExcluirOrcamentoOrdemCadastrar.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnExcluirOrcamentoOrdemCadastrar.Location = new Point(323, 13);
            BtnExcluirOrcamentoOrdemCadastrar.Name = "BtnExcluirOrcamentoOrdemCadastrar";
            BtnExcluirOrcamentoOrdemCadastrar.Size = new Size(124, 35);
            BtnExcluirOrcamentoOrdemCadastrar.TabIndex = 7;
            BtnExcluirOrcamentoOrdemCadastrar.Text = "Excluir";
            BtnExcluirOrcamentoOrdemCadastrar.UseVisualStyleBackColor = false;
            BtnExcluirOrcamentoOrdemCadastrar.Click += BtnExcluirOrcamentoOrdemCadastrar_Click;
            // 
            // BtnReprovarOrcamentoOrdemCadastrar
            // 
            BtnReprovarOrcamentoOrdemCadastrar.BackColor = SystemColors.ControlLight;
            BtnReprovarOrcamentoOrdemCadastrar.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnReprovarOrcamentoOrdemCadastrar.Location = new Point(635, 13);
            BtnReprovarOrcamentoOrdemCadastrar.Name = "BtnReprovarOrcamentoOrdemCadastrar";
            BtnReprovarOrcamentoOrdemCadastrar.Size = new Size(124, 35);
            BtnReprovarOrcamentoOrdemCadastrar.TabIndex = 9;
            BtnReprovarOrcamentoOrdemCadastrar.Text = "Reprovar";
            BtnReprovarOrcamentoOrdemCadastrar.UseVisualStyleBackColor = false;
            BtnReprovarOrcamentoOrdemCadastrar.Click += BtnReprovarOrcamentoOrdemCadastrar_Click;
            // 
            // BtnNovoOrcamentoOrdemCadastrar
            // 
            BtnNovoOrcamentoOrdemCadastrar.BackColor = SystemColors.ControlLight;
            BtnNovoOrcamentoOrdemCadastrar.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnNovoOrcamentoOrdemCadastrar.Location = new Point(11, 13);
            BtnNovoOrcamentoOrdemCadastrar.Name = "BtnNovoOrcamentoOrdemCadastrar";
            BtnNovoOrcamentoOrdemCadastrar.Size = new Size(124, 35);
            BtnNovoOrcamentoOrdemCadastrar.TabIndex = 5;
            BtnNovoOrcamentoOrdemCadastrar.Text = "Novo";
            BtnNovoOrcamentoOrdemCadastrar.UseVisualStyleBackColor = false;
            BtnNovoOrcamentoOrdemCadastrar.Click += BtnNovoOrcamentoOrdemCadastrar_Click;
            // 
            // BtnAprovarOrcamentoOrdemCadastrar
            // 
            BtnAprovarOrcamentoOrdemCadastrar.BackColor = SystemColors.ControlLight;
            BtnAprovarOrcamentoOrdemCadastrar.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnAprovarOrcamentoOrdemCadastrar.Location = new Point(479, 13);
            BtnAprovarOrcamentoOrdemCadastrar.Name = "BtnAprovarOrcamentoOrdemCadastrar";
            BtnAprovarOrcamentoOrdemCadastrar.Size = new Size(124, 35);
            BtnAprovarOrcamentoOrdemCadastrar.TabIndex = 8;
            BtnAprovarOrcamentoOrdemCadastrar.Text = "Aprovar";
            BtnAprovarOrcamentoOrdemCadastrar.UseVisualStyleBackColor = false;
            BtnAprovarOrcamentoOrdemCadastrar.Click += BtnAprovarOrcamentoOrdemCadastrar_Click;
            // 
            // BtnEditarOrcamentoOrdemCadastrar
            // 
            BtnEditarOrcamentoOrdemCadastrar.BackColor = SystemColors.ControlLight;
            BtnEditarOrcamentoOrdemCadastrar.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnEditarOrcamentoOrdemCadastrar.Location = new Point(167, 13);
            BtnEditarOrcamentoOrdemCadastrar.Name = "BtnEditarOrcamentoOrdemCadastrar";
            BtnEditarOrcamentoOrdemCadastrar.Size = new Size(124, 35);
            BtnEditarOrcamentoOrdemCadastrar.TabIndex = 6;
            BtnEditarOrcamentoOrdemCadastrar.Text = "Editar";
            BtnEditarOrcamentoOrdemCadastrar.UseVisualStyleBackColor = false;
            BtnEditarOrcamentoOrdemCadastrar.Click += BtnEditarOrcamentoOrdemCadastrar_Click;
            // 
            // DgvOrcamentosCadastrarOrdem
            // 
            DgvOrcamentosCadastrarOrdem.AllowUserToAddRows = false;
            DgvOrcamentosCadastrarOrdem.AllowUserToDeleteRows = false;
            DgvOrcamentosCadastrarOrdem.AllowUserToResizeColumns = false;
            DgvOrcamentosCadastrarOrdem.AllowUserToResizeRows = false;
            DgvOrcamentosCadastrarOrdem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvOrcamentosCadastrarOrdem.Dock = DockStyle.Bottom;
            DgvOrcamentosCadastrarOrdem.Location = new Point(0, 58);
            DgvOrcamentosCadastrarOrdem.Name = "DgvOrcamentosCadastrarOrdem";
            DgvOrcamentosCadastrarOrdem.ReadOnly = true;
            DgvOrcamentosCadastrarOrdem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvOrcamentosCadastrarOrdem.Size = new Size(774, 177);
            DgvOrcamentosCadastrarOrdem.TabIndex = 10;
            // 
            // LblInfoOrdemCadastrar
            // 
            LblInfoOrdemCadastrar.AutoSize = true;
            LblInfoOrdemCadastrar.Location = new Point(5, 5);
            LblInfoOrdemCadastrar.Name = "LblInfoOrdemCadastrar";
            LblInfoOrdemCadastrar.Size = new Size(142, 17);
            LblInfoOrdemCadastrar.TabIndex = 11;
            LblInfoOrdemCadastrar.Text = "Informações da ordem";
            // 
            // BtnGerarOrdemCadastrar
            // 
            BtnGerarOrdemCadastrar.BackColor = SystemColors.ControlLight;
            BtnGerarOrdemCadastrar.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnGerarOrdemCadastrar.Location = new Point(4, 494);
            BtnGerarOrdemCadastrar.Name = "BtnGerarOrdemCadastrar";
            BtnGerarOrdemCadastrar.Size = new Size(778, 55);
            BtnGerarOrdemCadastrar.TabIndex = 11;
            BtnGerarOrdemCadastrar.Text = "Gerar ordem de serviço";
            BtnGerarOrdemCadastrar.UseVisualStyleBackColor = false;
            BtnGerarOrdemCadastrar.Click += BtnGerarOrdem_Click;
            // 
            // FormCadastrarOrdem
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(784, 561);
            Controls.Add(BtnGerarOrdemCadastrar);
            Controls.Add(LblInfoOrdemCadastrar);
            Controls.Add(PanelInfoOrdemCadastrar);
            MaximizeBox = false;
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(800, 600);
            Name = "FormCadastrarOrdem";
            Text = "FastBox - Cadastrar ordem de serviço";
            Load += FormCadastrarOrdem_Load;
            PanelInfoOrdemCadastrar.ResumeLayout(false);
            PanelInfoOrdemCadastrar.PerformLayout();
            PanelOrcamentosOrdemCadastrar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvOrcamentosCadastrarOrdem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblClienteOrdemCadastrar;
        private TextBox TxtModelo;
        private Label LblModelo;
        private Label LblAno;
        private Label LblObservacoes;
        private Label LblMatricula;
        private Panel PanelInfoOrdemCadastrar;
        private Label LblInfoOrdemCadastrar;
        private Button BtnGerarOrdemCadastrar;
        private MaskedTextBox TxtMskAno;
        private MaskedTextBox TxtMskMatricula;
        private Label LblInfoMatricula;
        private RichTextBox RTxtObservacoes;
        private Button BtnNovoCliente;
        private Label LblCliente;
        private TextBox TxtCliente;
        private DataGridView DgvOrcamentosCadastrarOrdem;
        private TextBox TxtClienteOrdemCadastrar;
        private Label LblVeiculoOrdemCadastrar;
        private ListBox LstSugestoesClientes;
        private RichTextBox RTxtDescricaoOrdemCadastrar;
        private Button BtnNovoVeiculoOrdemCadastrar;
        private Button BtnNovoClienteOrdemCadastrar;
        private Label LblDescricaoOrdemCadastrar;
        private Button BtnExcluirOrcamentoOrdemCadastrar;
        private Button BtnEditarOrcamentoOrdemCadastrar;
        private Button BtnNovoOrcamentoOrdemCadastrar;
        private DateTimePicker DateTimePickerEstimativaConclusao;
        private Panel PanelOrcamentosOrdemCadastrar;
        private Button BtnReprovarOrcamentoOrdemCadastrar;
        private Button BtnAprovarOrcamentoOrdemCadastrar;
        private Label LblPrazoEstimadoOrdemCadastrar;
        private Label LblInfoOrcamentos;
        private TextBox TxtVeiculoOrdemCadastrar;
        private ListBox LstSugestoesVeiculos;
    }
}