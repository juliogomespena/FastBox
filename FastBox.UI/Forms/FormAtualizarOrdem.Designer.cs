namespace FastBox.UI.Forms
{
    partial class FormAtualizarOrdem
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
            LblClienteOrdemAtualizar = new Label();
            PanelInfoOrdemAtualizar = new Panel();
            TxtVeiculoOrdemAtualizar = new TextBox();
            LblPrazoEstimadoOrdemAtualizar = new Label();
            LblInfoOrcamentos = new Label();
            DateTimePickerEstimativaConclusao = new DateTimePicker();
            LblDescricaoOrdemAtualizar = new Label();
            RTxtDescricaoOrdemAtualizar = new RichTextBox();
            BtnNovoVeiculoOrdemAtualizar = new Button();
            BtnNovoClienteOrdemAtualizar = new Button();
            LblVeiculoOrdemAtualizar = new Label();
            TxtClienteOrdemAtualizar = new TextBox();
            PanelOrcamentosOrdemAtualizar = new Panel();
            BtnExcluirOrcamentoOrdemAtualizar = new Button();
            BtnReprovarOrcamentoOrdemAtualizar = new Button();
            BtnNovoOrcamentoOrdemAtualizar = new Button();
            BtnAprovarOrcamentoOrdemAtualizar = new Button();
            BtnEditarOrcamentoOrdemAtualizar = new Button();
            DgvOrcamentosAtualizarOrdem = new DataGridView();
            LblInfoOrdemAtualizar = new Label();
            BtnAtualizarOrdem = new Button();
            PanelInfoOrdemAtualizar.SuspendLayout();
            PanelOrcamentosOrdemAtualizar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvOrcamentosAtualizarOrdem).BeginInit();
            SuspendLayout();
            // 
            // LblClienteOrdemAtualizar
            // 
            LblClienteOrdemAtualizar.AutoSize = true;
            LblClienteOrdemAtualizar.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblClienteOrdemAtualizar.Location = new Point(8, 14);
            LblClienteOrdemAtualizar.Name = "LblClienteOrdemAtualizar";
            LblClienteOrdemAtualizar.Size = new Size(75, 26);
            LblClienteOrdemAtualizar.TabIndex = 0;
            LblClienteOrdemAtualizar.Text = "Cliente:";
            // 
            // PanelInfoOrdemAtualizar
            // 
            PanelInfoOrdemAtualizar.BorderStyle = BorderStyle.Fixed3D;
            PanelInfoOrdemAtualizar.Controls.Add(TxtVeiculoOrdemAtualizar);
            PanelInfoOrdemAtualizar.Controls.Add(LblPrazoEstimadoOrdemAtualizar);
            PanelInfoOrdemAtualizar.Controls.Add(LblInfoOrcamentos);
            PanelInfoOrdemAtualizar.Controls.Add(DateTimePickerEstimativaConclusao);
            PanelInfoOrdemAtualizar.Controls.Add(LblDescricaoOrdemAtualizar);
            PanelInfoOrdemAtualizar.Controls.Add(RTxtDescricaoOrdemAtualizar);
            PanelInfoOrdemAtualizar.Controls.Add(BtnNovoVeiculoOrdemAtualizar);
            PanelInfoOrdemAtualizar.Controls.Add(BtnNovoClienteOrdemAtualizar);
            PanelInfoOrdemAtualizar.Controls.Add(LblVeiculoOrdemAtualizar);
            PanelInfoOrdemAtualizar.Controls.Add(TxtClienteOrdemAtualizar);
            PanelInfoOrdemAtualizar.Controls.Add(LblClienteOrdemAtualizar);
            PanelInfoOrdemAtualizar.Controls.Add(PanelOrcamentosOrdemAtualizar);
            PanelInfoOrdemAtualizar.Location = new Point(4, 25);
            PanelInfoOrdemAtualizar.Name = "PanelInfoOrdemAtualizar";
            PanelInfoOrdemAtualizar.Size = new Size(778, 463);
            PanelInfoOrdemAtualizar.TabIndex = 10;
            // 
            // TxtVeiculoOrdemAtualizar
            // 
            TxtVeiculoOrdemAtualizar.BackColor = SystemColors.Window;
            TxtVeiculoOrdemAtualizar.Enabled = false;
            TxtVeiculoOrdemAtualizar.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtVeiculoOrdemAtualizar.Location = new Point(510, 11);
            TxtVeiculoOrdemAtualizar.Name = "TxtVeiculoOrdemAtualizar";
            TxtVeiculoOrdemAtualizar.Size = new Size(156, 33);
            TxtVeiculoOrdemAtualizar.TabIndex = 2;
            TxtVeiculoOrdemAtualizar.KeyPress += TxtVeiculoOrdemAtualizar_KeyPress;
            // 
            // LblPrazoEstimadoOrdemAtualizar
            // 
            LblPrazoEstimadoOrdemAtualizar.AutoSize = true;
            LblPrazoEstimadoOrdemAtualizar.Font = new Font("Segoe UI Variable Display", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPrazoEstimadoOrdemAtualizar.Location = new Point(498, 184);
            LblPrazoEstimadoOrdemAtualizar.Name = "LblPrazoEstimadoOrdemAtualizar";
            LblPrazoEstimadoOrdemAtualizar.Size = new Size(121, 21);
            LblPrazoEstimadoOrdemAtualizar.TabIndex = 32;
            LblPrazoEstimadoOrdemAtualizar.Text = "Prazo estimado:";
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
            // LblDescricaoOrdemAtualizar
            // 
            LblDescricaoOrdemAtualizar.AutoSize = true;
            LblDescricaoOrdemAtualizar.Location = new Point(3, 56);
            LblDescricaoOrdemAtualizar.Name = "LblDescricaoOrdemAtualizar";
            LblDescricaoOrdemAtualizar.Size = new Size(65, 17);
            LblDescricaoOrdemAtualizar.TabIndex = 25;
            LblDescricaoOrdemAtualizar.Text = "Descrição";
            // 
            // RTxtDescricaoOrdemAtualizar
            // 
            RTxtDescricaoOrdemAtualizar.Font = new Font("Segoe UI", 12F);
            RTxtDescricaoOrdemAtualizar.Location = new Point(3, 76);
            RTxtDescricaoOrdemAtualizar.Name = "RTxtDescricaoOrdemAtualizar";
            RTxtDescricaoOrdemAtualizar.Size = new Size(770, 98);
            RTxtDescricaoOrdemAtualizar.TabIndex = 3;
            RTxtDescricaoOrdemAtualizar.Text = "";
            // 
            // BtnNovoVeiculoOrdemAtualizar
            // 
            BtnNovoVeiculoOrdemAtualizar.BackColor = SystemColors.ControlLight;
            BtnNovoVeiculoOrdemAtualizar.Enabled = false;
            BtnNovoVeiculoOrdemAtualizar.Font = new Font("Segoe UI Variable Display Semib", 8F, FontStyle.Bold);
            BtnNovoVeiculoOrdemAtualizar.Location = new Point(672, 11);
            BtnNovoVeiculoOrdemAtualizar.Name = "BtnNovoVeiculoOrdemAtualizar";
            BtnNovoVeiculoOrdemAtualizar.Size = new Size(90, 34);
            BtnNovoVeiculoOrdemAtualizar.TabIndex = 101;
            BtnNovoVeiculoOrdemAtualizar.Text = "Novo veículo";
            BtnNovoVeiculoOrdemAtualizar.UseVisualStyleBackColor = false;
            BtnNovoVeiculoOrdemAtualizar.Click += BtnNovoVeiculoOrdemAtualizar_Click;
            // 
            // BtnNovoClienteOrdemAtualizar
            // 
            BtnNovoClienteOrdemAtualizar.BackColor = SystemColors.ControlLight;
            BtnNovoClienteOrdemAtualizar.Enabled = false;
            BtnNovoClienteOrdemAtualizar.Font = new Font("Segoe UI Variable Display Semib", 8F, FontStyle.Bold);
            BtnNovoClienteOrdemAtualizar.Location = new Point(303, 11);
            BtnNovoClienteOrdemAtualizar.Name = "BtnNovoClienteOrdemAtualizar";
            BtnNovoClienteOrdemAtualizar.Size = new Size(81, 34);
            BtnNovoClienteOrdemAtualizar.TabIndex = 100;
            BtnNovoClienteOrdemAtualizar.Text = "Novo cliente";
            BtnNovoClienteOrdemAtualizar.UseVisualStyleBackColor = false;
            BtnNovoClienteOrdemAtualizar.Click += BtnNovoClienteOrdemAtualizar_Click;
            // 
            // LblVeiculoOrdemAtualizar
            // 
            LblVeiculoOrdemAtualizar.AutoSize = true;
            LblVeiculoOrdemAtualizar.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblVeiculoOrdemAtualizar.Location = new Point(427, 14);
            LblVeiculoOrdemAtualizar.Name = "LblVeiculoOrdemAtualizar";
            LblVeiculoOrdemAtualizar.Size = new Size(77, 26);
            LblVeiculoOrdemAtualizar.TabIndex = 20;
            LblVeiculoOrdemAtualizar.Text = "Veículo:";
            // 
            // TxtClienteOrdemAtualizar
            // 
            TxtClienteOrdemAtualizar.BackColor = SystemColors.Window;
            TxtClienteOrdemAtualizar.Enabled = false;
            TxtClienteOrdemAtualizar.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtClienteOrdemAtualizar.Location = new Point(89, 11);
            TxtClienteOrdemAtualizar.Name = "TxtClienteOrdemAtualizar";
            TxtClienteOrdemAtualizar.Size = new Size(208, 33);
            TxtClienteOrdemAtualizar.TabIndex = 1;
            // 
            // PanelOrcamentosOrdemAtualizar
            // 
            PanelOrcamentosOrdemAtualizar.BorderStyle = BorderStyle.Fixed3D;
            PanelOrcamentosOrdemAtualizar.Controls.Add(BtnExcluirOrcamentoOrdemAtualizar);
            PanelOrcamentosOrdemAtualizar.Controls.Add(BtnReprovarOrcamentoOrdemAtualizar);
            PanelOrcamentosOrdemAtualizar.Controls.Add(BtnNovoOrcamentoOrdemAtualizar);
            PanelOrcamentosOrdemAtualizar.Controls.Add(BtnAprovarOrcamentoOrdemAtualizar);
            PanelOrcamentosOrdemAtualizar.Controls.Add(BtnEditarOrcamentoOrdemAtualizar);
            PanelOrcamentosOrdemAtualizar.Controls.Add(DgvOrcamentosAtualizarOrdem);
            PanelOrcamentosOrdemAtualizar.Location = new Point(-2, 222);
            PanelOrcamentosOrdemAtualizar.Name = "PanelOrcamentosOrdemAtualizar";
            PanelOrcamentosOrdemAtualizar.Size = new Size(778, 239);
            PanelOrcamentosOrdemAtualizar.TabIndex = 31;
            // 
            // BtnExcluirOrcamentoOrdemAtualizar
            // 
            BtnExcluirOrcamentoOrdemAtualizar.BackColor = SystemColors.ControlLight;
            BtnExcluirOrcamentoOrdemAtualizar.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnExcluirOrcamentoOrdemAtualizar.Location = new Point(323, 13);
            BtnExcluirOrcamentoOrdemAtualizar.Name = "BtnExcluirOrcamentoOrdemAtualizar";
            BtnExcluirOrcamentoOrdemAtualizar.Size = new Size(124, 35);
            BtnExcluirOrcamentoOrdemAtualizar.TabIndex = 7;
            BtnExcluirOrcamentoOrdemAtualizar.Text = "Excluir";
            BtnExcluirOrcamentoOrdemAtualizar.UseVisualStyleBackColor = false;
            BtnExcluirOrcamentoOrdemAtualizar.Click += BtnExcluirOrcamentoOrdemAtualizar_Click;
            // 
            // BtnReprovarOrcamentoOrdemAtualizar
            // 
            BtnReprovarOrcamentoOrdemAtualizar.BackColor = SystemColors.ControlLight;
            BtnReprovarOrcamentoOrdemAtualizar.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnReprovarOrcamentoOrdemAtualizar.Location = new Point(635, 13);
            BtnReprovarOrcamentoOrdemAtualizar.Name = "BtnReprovarOrcamentoOrdemAtualizar";
            BtnReprovarOrcamentoOrdemAtualizar.Size = new Size(124, 35);
            BtnReprovarOrcamentoOrdemAtualizar.TabIndex = 9;
            BtnReprovarOrcamentoOrdemAtualizar.Text = "Reprovar";
            BtnReprovarOrcamentoOrdemAtualizar.UseVisualStyleBackColor = false;
            BtnReprovarOrcamentoOrdemAtualizar.Click += BtnReprovarOrcamentoOrdemAtualizar_Click;
            // 
            // BtnNovoOrcamentoOrdemAtualizar
            // 
            BtnNovoOrcamentoOrdemAtualizar.BackColor = SystemColors.ControlLight;
            BtnNovoOrcamentoOrdemAtualizar.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnNovoOrcamentoOrdemAtualizar.Location = new Point(11, 13);
            BtnNovoOrcamentoOrdemAtualizar.Name = "BtnNovoOrcamentoOrdemAtualizar";
            BtnNovoOrcamentoOrdemAtualizar.Size = new Size(124, 35);
            BtnNovoOrcamentoOrdemAtualizar.TabIndex = 5;
            BtnNovoOrcamentoOrdemAtualizar.Text = "Novo";
            BtnNovoOrcamentoOrdemAtualizar.UseVisualStyleBackColor = false;
            BtnNovoOrcamentoOrdemAtualizar.Click += BtnNovoOrcamentoOrdemAtualizar_Click;
            // 
            // BtnAprovarOrcamentoOrdemAtualizar
            // 
            BtnAprovarOrcamentoOrdemAtualizar.BackColor = SystemColors.ControlLight;
            BtnAprovarOrcamentoOrdemAtualizar.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnAprovarOrcamentoOrdemAtualizar.Location = new Point(479, 13);
            BtnAprovarOrcamentoOrdemAtualizar.Name = "BtnAprovarOrcamentoOrdemAtualizar";
            BtnAprovarOrcamentoOrdemAtualizar.Size = new Size(124, 35);
            BtnAprovarOrcamentoOrdemAtualizar.TabIndex = 8;
            BtnAprovarOrcamentoOrdemAtualizar.Text = "Aprovar";
            BtnAprovarOrcamentoOrdemAtualizar.UseVisualStyleBackColor = false;
            BtnAprovarOrcamentoOrdemAtualizar.Click += BtnAprovarOrcamentoOrdemAtualizar_Click;
            // 
            // BtnEditarOrcamentoOrdemAtualizar
            // 
            BtnEditarOrcamentoOrdemAtualizar.BackColor = SystemColors.ControlLight;
            BtnEditarOrcamentoOrdemAtualizar.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnEditarOrcamentoOrdemAtualizar.Location = new Point(167, 13);
            BtnEditarOrcamentoOrdemAtualizar.Name = "BtnEditarOrcamentoOrdemAtualizar";
            BtnEditarOrcamentoOrdemAtualizar.Size = new Size(124, 35);
            BtnEditarOrcamentoOrdemAtualizar.TabIndex = 6;
            BtnEditarOrcamentoOrdemAtualizar.Text = "Editar";
            BtnEditarOrcamentoOrdemAtualizar.UseVisualStyleBackColor = false;
            BtnEditarOrcamentoOrdemAtualizar.Click += BtnEditarOrcamentoOrdemAtualizar_Click;
            // 
            // DgvOrcamentosAtualizarOrdem
            // 
            DgvOrcamentosAtualizarOrdem.AllowUserToAddRows = false;
            DgvOrcamentosAtualizarOrdem.AllowUserToDeleteRows = false;
            DgvOrcamentosAtualizarOrdem.AllowUserToResizeColumns = false;
            DgvOrcamentosAtualizarOrdem.AllowUserToResizeRows = false;
            DgvOrcamentosAtualizarOrdem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvOrcamentosAtualizarOrdem.Dock = DockStyle.Bottom;
            DgvOrcamentosAtualizarOrdem.Location = new Point(0, 58);
            DgvOrcamentosAtualizarOrdem.Name = "DgvOrcamentosAtualizarOrdem";
            DgvOrcamentosAtualizarOrdem.ReadOnly = true;
            DgvOrcamentosAtualizarOrdem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvOrcamentosAtualizarOrdem.Size = new Size(774, 177);
            DgvOrcamentosAtualizarOrdem.TabIndex = 10;
            // 
            // LblInfoOrdemAtualizar
            // 
            LblInfoOrdemAtualizar.AutoSize = true;
            LblInfoOrdemAtualizar.Location = new Point(5, 5);
            LblInfoOrdemAtualizar.Name = "LblInfoOrdemAtualizar";
            LblInfoOrdemAtualizar.Size = new Size(142, 17);
            LblInfoOrdemAtualizar.TabIndex = 11;
            LblInfoOrdemAtualizar.Text = "Informações da ordem";
            // 
            // BtnAtualizarOrdem
            // 
            BtnAtualizarOrdem.BackColor = SystemColors.ControlLight;
            BtnAtualizarOrdem.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnAtualizarOrdem.Location = new Point(4, 494);
            BtnAtualizarOrdem.Name = "BtnAtualizarOrdem";
            BtnAtualizarOrdem.Size = new Size(778, 55);
            BtnAtualizarOrdem.TabIndex = 11;
            BtnAtualizarOrdem.Text = "Atualizar ordem de serviço";
            BtnAtualizarOrdem.UseVisualStyleBackColor = false;
            BtnAtualizarOrdem.Click += BtnAtualizarOrdem_Click;
            // 
            // FormAtualizarOrdem
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(784, 561);
            Controls.Add(BtnAtualizarOrdem);
            Controls.Add(LblInfoOrdemAtualizar);
            Controls.Add(PanelInfoOrdemAtualizar);
            MaximizeBox = false;
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(800, 600);
            Name = "FormAtualizarOrdem";
            Text = "FastBox - Atualizar ordem de serviço";
            Load += FormAtualizarOrdem_Load;
            PanelInfoOrdemAtualizar.ResumeLayout(false);
            PanelInfoOrdemAtualizar.PerformLayout();
            PanelOrcamentosOrdemAtualizar.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvOrcamentosAtualizarOrdem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblClienteOrdemAtualizar;
        private TextBox TxtModelo;
        private Label LblModelo;
        private Label LblAno;
        private Label LblObservacoes;
        private Label LblMatricula;
        private Panel PanelInfoOrdemAtualizar;
        private Label LblInfoOrdemAtualizar;
        private Button BtnAtualizarOrdem;
        private MaskedTextBox TxtMskAno;
        private MaskedTextBox TxtMskMatricula;
        private Label LblInfoMatricula;
        private RichTextBox RTxtObservacoes;
        private Button BtnNovoCliente;
        private Label LblCliente;
        private TextBox TxtCliente;
        private DataGridView DgvOrcamentosAtualizarOrdem;
        private TextBox TxtClienteOrdemAtualizar;
        private Label LblVeiculoOrdemAtualizar;
        private RichTextBox RTxtDescricaoOrdemAtualizar;
        private Button BtnNovoVeiculoOrdemAtualizar;
        private Button BtnNovoClienteOrdemAtualizar;
        private Label LblDescricaoOrdemAtualizar;
        private Button BtnExcluirOrcamentoOrdemAtualizar;
        private Button BtnEditarOrcamentoOrdemAtualizar;
        private Button BtnNovoOrcamentoOrdemAtualizar;
        private DateTimePicker DateTimePickerEstimativaConclusao;
        private Panel PanelOrcamentosOrdemAtualizar;
        private Button BtnReprovarOrcamentoOrdemAtualizar;
        private Button BtnAprovarOrcamentoOrdemAtualizar;
        private Label LblPrazoEstimadoOrdemAtualizar;
        private Label LblInfoOrcamentos;
        private TextBox TxtVeiculoOrdemAtualizar;
    }
}