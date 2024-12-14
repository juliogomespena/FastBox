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
            LblClienteOrdemCadastro = new Label();
            PanelInfoOrdemCadastro = new Panel();
            LblPrazoEstimadoOrdemCadastro = new Label();
            LblInfoOrcamentos = new Label();
            PanelOrcamentosOrdemCadastro = new Panel();
            BtnExcluirOrcamentoOrdemCadastro = new Button();
            BtnReprovarOrcamentoOrdemCadastro = new Button();
            BtnNovoOrcamentoOrdemCadastro = new Button();
            BtnAprovarOrcamentoOrdemCadastro = new Button();
            BtnEditarOrcamentoOrdemCadastro = new Button();
            DgvOrdensClientes = new DataGridView();
            dateTimePicker1 = new DateTimePicker();
            LblDescricaoOrdemCadastro = new Label();
            RTxtDescricaoOrdemCadastro = new RichTextBox();
            BtnNovoVeiculoOrdemCadastro = new Button();
            BtnNovoClienteOrdemCadastro = new Button();
            LstSugestoesClientes = new ListBox();
            CmbVeiculosOrdemCadastro = new ComboBox();
            LblVeiculoOrdemCadastro = new Label();
            TxtClienteOrdemCadastro = new TextBox();
            LblInfoOrdemCadastro = new Label();
            BtnGerarOrdemCadastro = new Button();
            PanelInfoOrdemCadastro.SuspendLayout();
            PanelOrcamentosOrdemCadastro.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvOrdensClientes).BeginInit();
            SuspendLayout();
            // 
            // LblClienteOrdemCadastro
            // 
            LblClienteOrdemCadastro.AutoSize = true;
            LblClienteOrdemCadastro.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblClienteOrdemCadastro.Location = new Point(8, 14);
            LblClienteOrdemCadastro.Name = "LblClienteOrdemCadastro";
            LblClienteOrdemCadastro.Size = new Size(75, 26);
            LblClienteOrdemCadastro.TabIndex = 0;
            LblClienteOrdemCadastro.Text = "Cliente:";
            // 
            // PanelInfoOrdemCadastro
            // 
            PanelInfoOrdemCadastro.BorderStyle = BorderStyle.Fixed3D;
            PanelInfoOrdemCadastro.Controls.Add(LblPrazoEstimadoOrdemCadastro);
            PanelInfoOrdemCadastro.Controls.Add(LblInfoOrcamentos);
            PanelInfoOrdemCadastro.Controls.Add(PanelOrcamentosOrdemCadastro);
            PanelInfoOrdemCadastro.Controls.Add(dateTimePicker1);
            PanelInfoOrdemCadastro.Controls.Add(LblDescricaoOrdemCadastro);
            PanelInfoOrdemCadastro.Controls.Add(RTxtDescricaoOrdemCadastro);
            PanelInfoOrdemCadastro.Controls.Add(BtnNovoVeiculoOrdemCadastro);
            PanelInfoOrdemCadastro.Controls.Add(BtnNovoClienteOrdemCadastro);
            PanelInfoOrdemCadastro.Controls.Add(LstSugestoesClientes);
            PanelInfoOrdemCadastro.Controls.Add(CmbVeiculosOrdemCadastro);
            PanelInfoOrdemCadastro.Controls.Add(LblVeiculoOrdemCadastro);
            PanelInfoOrdemCadastro.Controls.Add(TxtClienteOrdemCadastro);
            PanelInfoOrdemCadastro.Controls.Add(LblClienteOrdemCadastro);
            PanelInfoOrdemCadastro.Location = new Point(4, 25);
            PanelInfoOrdemCadastro.Name = "PanelInfoOrdemCadastro";
            PanelInfoOrdemCadastro.Size = new Size(778, 463);
            PanelInfoOrdemCadastro.TabIndex = 10;
            // 
            // LblPrazoEstimadoOrdemCadastro
            // 
            LblPrazoEstimadoOrdemCadastro.AutoSize = true;
            LblPrazoEstimadoOrdemCadastro.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPrazoEstimadoOrdemCadastro.Location = new Point(498, 184);
            LblPrazoEstimadoOrdemCadastro.Name = "LblPrazoEstimadoOrdemCadastro";
            LblPrazoEstimadoOrdemCadastro.Size = new Size(121, 21);
            LblPrazoEstimadoOrdemCadastro.TabIndex = 32;
            LblPrazoEstimadoOrdemCadastro.Text = "Prazo estimado:";
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
            // PanelOrcamentosOrdemCadastro
            // 
            PanelOrcamentosOrdemCadastro.BorderStyle = BorderStyle.Fixed3D;
            PanelOrcamentosOrdemCadastro.Controls.Add(BtnExcluirOrcamentoOrdemCadastro);
            PanelOrcamentosOrdemCadastro.Controls.Add(BtnReprovarOrcamentoOrdemCadastro);
            PanelOrcamentosOrdemCadastro.Controls.Add(BtnNovoOrcamentoOrdemCadastro);
            PanelOrcamentosOrdemCadastro.Controls.Add(BtnAprovarOrcamentoOrdemCadastro);
            PanelOrcamentosOrdemCadastro.Controls.Add(BtnEditarOrcamentoOrdemCadastro);
            PanelOrcamentosOrdemCadastro.Controls.Add(DgvOrdensClientes);
            PanelOrcamentosOrdemCadastro.Location = new Point(-2, 222);
            PanelOrcamentosOrdemCadastro.Name = "PanelOrcamentosOrdemCadastro";
            PanelOrcamentosOrdemCadastro.Size = new Size(778, 239);
            PanelOrcamentosOrdemCadastro.TabIndex = 31;
            // 
            // BtnExcluirOrcamentoOrdemCadastro
            // 
            BtnExcluirOrcamentoOrdemCadastro.BackColor = SystemColors.ControlLight;
            BtnExcluirOrcamentoOrdemCadastro.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnExcluirOrcamentoOrdemCadastro.Location = new Point(323, 13);
            BtnExcluirOrcamentoOrdemCadastro.Name = "BtnExcluirOrcamentoOrdemCadastro";
            BtnExcluirOrcamentoOrdemCadastro.Size = new Size(124, 35);
            BtnExcluirOrcamentoOrdemCadastro.TabIndex = 27;
            BtnExcluirOrcamentoOrdemCadastro.Text = "Excluir";
            BtnExcluirOrcamentoOrdemCadastro.UseVisualStyleBackColor = false;
            // 
            // BtnReprovarOrcamentoOrdemCadastro
            // 
            BtnReprovarOrcamentoOrdemCadastro.BackColor = SystemColors.ControlLight;
            BtnReprovarOrcamentoOrdemCadastro.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnReprovarOrcamentoOrdemCadastro.Location = new Point(635, 13);
            BtnReprovarOrcamentoOrdemCadastro.Name = "BtnReprovarOrcamentoOrdemCadastro";
            BtnReprovarOrcamentoOrdemCadastro.Size = new Size(124, 35);
            BtnReprovarOrcamentoOrdemCadastro.TabIndex = 30;
            BtnReprovarOrcamentoOrdemCadastro.Text = "Reprovar";
            BtnReprovarOrcamentoOrdemCadastro.UseVisualStyleBackColor = false;
            // 
            // BtnNovoOrcamentoOrdemCadastro
            // 
            BtnNovoOrcamentoOrdemCadastro.BackColor = SystemColors.ControlLight;
            BtnNovoOrcamentoOrdemCadastro.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnNovoOrcamentoOrdemCadastro.Location = new Point(11, 13);
            BtnNovoOrcamentoOrdemCadastro.Name = "BtnNovoOrcamentoOrdemCadastro";
            BtnNovoOrcamentoOrdemCadastro.Size = new Size(124, 35);
            BtnNovoOrcamentoOrdemCadastro.TabIndex = 16;
            BtnNovoOrcamentoOrdemCadastro.Text = "Novo";
            BtnNovoOrcamentoOrdemCadastro.UseVisualStyleBackColor = false;
            BtnNovoOrcamentoOrdemCadastro.Click += BtnNovoOrcamentoOrdemCadastro_Click;
            // 
            // BtnAprovarOrcamentoOrdemCadastro
            // 
            BtnAprovarOrcamentoOrdemCadastro.BackColor = SystemColors.ControlLight;
            BtnAprovarOrcamentoOrdemCadastro.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnAprovarOrcamentoOrdemCadastro.Location = new Point(479, 13);
            BtnAprovarOrcamentoOrdemCadastro.Name = "BtnAprovarOrcamentoOrdemCadastro";
            BtnAprovarOrcamentoOrdemCadastro.Size = new Size(124, 35);
            BtnAprovarOrcamentoOrdemCadastro.TabIndex = 29;
            BtnAprovarOrcamentoOrdemCadastro.Text = "Aprovar";
            BtnAprovarOrcamentoOrdemCadastro.UseVisualStyleBackColor = false;
            // 
            // BtnEditarOrcamentoOrdemCadastro
            // 
            BtnEditarOrcamentoOrdemCadastro.BackColor = SystemColors.ControlLight;
            BtnEditarOrcamentoOrdemCadastro.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnEditarOrcamentoOrdemCadastro.Location = new Point(167, 13);
            BtnEditarOrcamentoOrdemCadastro.Name = "BtnEditarOrcamentoOrdemCadastro";
            BtnEditarOrcamentoOrdemCadastro.Size = new Size(124, 35);
            BtnEditarOrcamentoOrdemCadastro.TabIndex = 26;
            BtnEditarOrcamentoOrdemCadastro.Text = "Editar";
            BtnEditarOrcamentoOrdemCadastro.UseVisualStyleBackColor = false;
            // 
            // DgvOrdensClientes
            // 
            DgvOrdensClientes.AllowUserToAddRows = false;
            DgvOrdensClientes.AllowUserToDeleteRows = false;
            DgvOrdensClientes.AllowUserToResizeColumns = false;
            DgvOrdensClientes.AllowUserToResizeRows = false;
            DgvOrdensClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvOrdensClientes.Dock = DockStyle.Bottom;
            DgvOrdensClientes.Location = new Point(0, 58);
            DgvOrdensClientes.Name = "DgvOrdensClientes";
            DgvOrdensClientes.ReadOnly = true;
            DgvOrdensClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvOrdensClientes.Size = new Size(774, 177);
            DgvOrdensClientes.TabIndex = 17;
            // 
            // dateTimePicker1
            // 
            dateTimePicker1.CustomFormat = "dd/MM/yyyy HH'h'";
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.Location = new Point(621, 183);
            dateTimePicker1.Name = "dateTimePicker1";
            dateTimePicker1.ShowUpDown = true;
            dateTimePicker1.Size = new Size(138, 25);
            dateTimePicker1.TabIndex = 28;
            // 
            // LblDescricaoOrdemCadastro
            // 
            LblDescricaoOrdemCadastro.AutoSize = true;
            LblDescricaoOrdemCadastro.Location = new Point(3, 56);
            LblDescricaoOrdemCadastro.Name = "LblDescricaoOrdemCadastro";
            LblDescricaoOrdemCadastro.Size = new Size(65, 17);
            LblDescricaoOrdemCadastro.TabIndex = 25;
            LblDescricaoOrdemCadastro.Text = "Descrição";
            // 
            // RTxtDescricaoOrdemCadastro
            // 
            RTxtDescricaoOrdemCadastro.Font = new Font("Segoe UI", 12F);
            RTxtDescricaoOrdemCadastro.Location = new Point(3, 76);
            RTxtDescricaoOrdemCadastro.Name = "RTxtDescricaoOrdemCadastro";
            RTxtDescricaoOrdemCadastro.Size = new Size(770, 98);
            RTxtDescricaoOrdemCadastro.TabIndex = 24;
            RTxtDescricaoOrdemCadastro.Text = "";
            // 
            // BtnNovoVeiculoOrdemCadastro
            // 
            BtnNovoVeiculoOrdemCadastro.BackColor = SystemColors.ControlLight;
            BtnNovoVeiculoOrdemCadastro.Font = new Font("Segoe UI Variable Display Semib", 8F, FontStyle.Bold);
            BtnNovoVeiculoOrdemCadastro.Location = new Point(672, 11);
            BtnNovoVeiculoOrdemCadastro.Name = "BtnNovoVeiculoOrdemCadastro";
            BtnNovoVeiculoOrdemCadastro.Size = new Size(90, 34);
            BtnNovoVeiculoOrdemCadastro.TabIndex = 23;
            BtnNovoVeiculoOrdemCadastro.Text = "Novo veículo";
            BtnNovoVeiculoOrdemCadastro.UseVisualStyleBackColor = false;
            BtnNovoVeiculoOrdemCadastro.Click += BtnNovoVeiculoOrdemCadastro_Click;
            // 
            // BtnNovoClienteOrdemCadastro
            // 
            BtnNovoClienteOrdemCadastro.BackColor = SystemColors.ControlLight;
            BtnNovoClienteOrdemCadastro.Font = new Font("Segoe UI Variable Display Semib", 8F, FontStyle.Bold);
            BtnNovoClienteOrdemCadastro.Location = new Point(303, 11);
            BtnNovoClienteOrdemCadastro.Name = "BtnNovoClienteOrdemCadastro";
            BtnNovoClienteOrdemCadastro.Size = new Size(81, 34);
            BtnNovoClienteOrdemCadastro.TabIndex = 16;
            BtnNovoClienteOrdemCadastro.Text = "Novo cliente";
            BtnNovoClienteOrdemCadastro.UseVisualStyleBackColor = false;
            BtnNovoClienteOrdemCadastro.Click += BtnNovoClienteOrdemCadastro_Click;
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
            // CmbVeiculosOrdemCadastro
            // 
            CmbVeiculosOrdemCadastro.AutoCompleteMode = AutoCompleteMode.Suggest;
            CmbVeiculosOrdemCadastro.AutoCompleteSource = AutoCompleteSource.ListItems;
            CmbVeiculosOrdemCadastro.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbVeiculosOrdemCadastro.Font = new Font("Segoe UI Variable Display", 14.25F);
            CmbVeiculosOrdemCadastro.FormattingEnabled = true;
            CmbVeiculosOrdemCadastro.Location = new Point(508, 11);
            CmbVeiculosOrdemCadastro.Name = "CmbVeiculosOrdemCadastro";
            CmbVeiculosOrdemCadastro.Size = new Size(158, 34);
            CmbVeiculosOrdemCadastro.TabIndex = 21;
            CmbVeiculosOrdemCadastro.SelectedIndexChanged += CmbVeiculos_SelectedIndexChanged;
            // 
            // LblVeiculoOrdemCadastro
            // 
            LblVeiculoOrdemCadastro.AutoSize = true;
            LblVeiculoOrdemCadastro.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblVeiculoOrdemCadastro.Location = new Point(427, 14);
            LblVeiculoOrdemCadastro.Name = "LblVeiculoOrdemCadastro";
            LblVeiculoOrdemCadastro.Size = new Size(77, 26);
            LblVeiculoOrdemCadastro.TabIndex = 20;
            LblVeiculoOrdemCadastro.Text = "Veículo:";
            // 
            // TxtClienteOrdemCadastro
            // 
            TxtClienteOrdemCadastro.BackColor = SystemColors.Window;
            TxtClienteOrdemCadastro.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtClienteOrdemCadastro.Location = new Point(89, 11);
            TxtClienteOrdemCadastro.Name = "TxtClienteOrdemCadastro";
            TxtClienteOrdemCadastro.Size = new Size(208, 33);
            TxtClienteOrdemCadastro.TabIndex = 18;
            TxtClienteOrdemCadastro.TextChanged += TxtClienteOrdem_TextChanged;
            // 
            // LblInfoOrdemCadastro
            // 
            LblInfoOrdemCadastro.AutoSize = true;
            LblInfoOrdemCadastro.Location = new Point(5, 5);
            LblInfoOrdemCadastro.Name = "LblInfoOrdemCadastro";
            LblInfoOrdemCadastro.Size = new Size(142, 17);
            LblInfoOrdemCadastro.TabIndex = 11;
            LblInfoOrdemCadastro.Text = "Informações da ordem";
            // 
            // BtnGerarOrdemCadastro
            // 
            BtnGerarOrdemCadastro.BackColor = SystemColors.ControlLight;
            BtnGerarOrdemCadastro.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnGerarOrdemCadastro.Location = new Point(4, 494);
            BtnGerarOrdemCadastro.Name = "BtnGerarOrdemCadastro";
            BtnGerarOrdemCadastro.Size = new Size(778, 55);
            BtnGerarOrdemCadastro.TabIndex = 15;
            BtnGerarOrdemCadastro.Text = "Gerar ordem de serviço";
            BtnGerarOrdemCadastro.UseVisualStyleBackColor = false;
            BtnGerarOrdemCadastro.Click += BtnGerarOrdem_Click;
            // 
            // FormCadastrarOrdem
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(784, 561);
            Controls.Add(BtnGerarOrdemCadastro);
            Controls.Add(LblInfoOrdemCadastro);
            Controls.Add(PanelInfoOrdemCadastro);
            MaximizeBox = false;
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(800, 600);
            Name = "FormCadastrarOrdem";
            Text = "FastBox - Nova ordem de serviço";
            Load += FormCadastrarOrdem_Load;
            PanelInfoOrdemCadastro.ResumeLayout(false);
            PanelInfoOrdemCadastro.PerformLayout();
            PanelOrcamentosOrdemCadastro.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvOrdensClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblClienteOrdemCadastro;
        private TextBox TxtModelo;
        private Label LblModelo;
        private Label LblAno;
        private Label LblObservacoes;
        private Label LblMatricula;
        private Panel PanelInfoOrdemCadastro;
        private Label LblInfoOrdemCadastro;
        private Button BtnGerarOrdemCadastro;
        private MaskedTextBox TxtMskAno;
        private MaskedTextBox TxtMskMatricula;
        private Label LblInfoMatricula;
        private RichTextBox RTxtObservacoes;
        private Button BtnNovoCliente;
        private Label LblCliente;
        private TextBox TxtCliente;
        private DataGridView DgvOrdensClientes;
        private TextBox TxtClienteOrdemCadastro;
        private ComboBox CmbVeiculosOrdemCadastro;
        private Label LblVeiculoOrdemCadastro;
        private ListBox LstSugestoesClientes;
        private RichTextBox RTxtDescricaoOrdemCadastro;
        private Button BtnNovoVeiculoOrdemCadastro;
        private Button BtnNovoClienteOrdemCadastro;
        private Label LblDescricaoOrdemCadastro;
        private Button BtnExcluirOrcamentoOrdemCadastro;
        private Button BtnEditarOrcamentoOrdemCadastro;
        private Button BtnNovoOrcamentoOrdemCadastro;
        private DateTimePicker dateTimePicker1;
        private Panel PanelOrcamentosOrdemCadastro;
        private Button BtnReprovarOrcamentoOrdemCadastro;
        private Button BtnAprovarOrcamentoOrdemCadastro;
        private Label LblPrazoEstimadoOrdemCadastro;
        private Label LblInfoOrcamentos;
    }
}