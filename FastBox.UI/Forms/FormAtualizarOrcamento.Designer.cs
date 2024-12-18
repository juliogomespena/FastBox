namespace FastBox.UI.Forms
{
    partial class FormAtualizarOrcamento
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
            LblItemAtualizarOrcamento = new Label();
            PanelInfoOrcamentoAtualizar = new Panel();
            ChkMaoDeObra = new CheckBox();
            LblDescricaoAtualizarOrcamento = new Label();
            panel1 = new Panel();
            RTxtDescricaoAtualizarOrcamento = new RichTextBox();
            TxtPrecoUnitarioFinalAtualizarOrcamento = new TextBox();
            LblPrecoFinalTotalAtualizarOrcamento = new Label();
            TxtPrecoFinalTotalAtualizarOrcamento = new TextBox();
            LblPrecoFinalUnitarioAtualizarOrcamento = new Label();
            TxtMargemAtualizarOrdem = new TextBox();
            LblMargemAtualizarOrcamento = new Label();
            TxtPrecoUnitarioAtualizarOrcamento = new TextBox();
            LblPrecoUnitarioAtualizarOrcamento = new Label();
            TxtQuantidadeAtualizarOrcamento = new TextBox();
            LblQuantidadeAtualizarOrcamento = new Label();
            DgvOrcamentosAtualizar = new DataGridView();
            BtnIncluirItemAtualizarOrcamento = new Button();
            BtnExcluirItemAtualizarOrcamento = new Button();
            TxtItemAtualizarOrcamento = new TextBox();
            LblInfoOrcamentoAtualizar = new Label();
            BtnAtualizarOrcamento = new Button();
            PanelInfoOrcamentoAtualizar.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvOrcamentosAtualizar).BeginInit();
            SuspendLayout();
            // 
            // LblItemAtualizarOrcamento
            // 
            LblItemAtualizarOrcamento.AutoSize = true;
            LblItemAtualizarOrcamento.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblItemAtualizarOrcamento.Location = new Point(8, 14);
            LblItemAtualizarOrcamento.Name = "LblItemAtualizarOrcamento";
            LblItemAtualizarOrcamento.Size = new Size(54, 26);
            LblItemAtualizarOrcamento.TabIndex = 0;
            LblItemAtualizarOrcamento.Text = "Item:";
            // 
            // PanelInfoOrcamentoAtualizar
            // 
            PanelInfoOrcamentoAtualizar.BorderStyle = BorderStyle.Fixed3D;
            PanelInfoOrcamentoAtualizar.Controls.Add(ChkMaoDeObra);
            PanelInfoOrcamentoAtualizar.Controls.Add(LblDescricaoAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(panel1);
            PanelInfoOrcamentoAtualizar.Controls.Add(TxtPrecoUnitarioFinalAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(LblPrecoFinalTotalAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(TxtPrecoFinalTotalAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(LblPrecoFinalUnitarioAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(TxtMargemAtualizarOrdem);
            PanelInfoOrcamentoAtualizar.Controls.Add(LblMargemAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(TxtPrecoUnitarioAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(LblPrecoUnitarioAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(TxtQuantidadeAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(LblQuantidadeAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(DgvOrcamentosAtualizar);
            PanelInfoOrcamentoAtualizar.Controls.Add(BtnIncluirItemAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(BtnExcluirItemAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(TxtItemAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Controls.Add(LblItemAtualizarOrcamento);
            PanelInfoOrcamentoAtualizar.Location = new Point(1, 25);
            PanelInfoOrcamentoAtualizar.Name = "PanelInfoOrcamentoAtualizar";
            PanelInfoOrcamentoAtualizar.Size = new Size(778, 463);
            PanelInfoOrcamentoAtualizar.TabIndex = 10;
            // 
            // ChkMaoDeObra
            // 
            ChkMaoDeObra.AutoSize = true;
            ChkMaoDeObra.Location = new Point(468, 20);
            ChkMaoDeObra.Name = "ChkMaoDeObra";
            ChkMaoDeObra.Size = new Size(105, 21);
            ChkMaoDeObra.TabIndex = 39;
            ChkMaoDeObra.Text = "Mão de obra";
            ChkMaoDeObra.UseVisualStyleBackColor = true;
            ChkMaoDeObra.CheckedChanged += ChkMaoDeObra_CheckedChanged;
            // 
            // LblDescricaoAtualizarOrcamento
            // 
            LblDescricaoAtualizarOrcamento.AutoSize = true;
            LblDescricaoAtualizarOrcamento.Location = new Point(8, 357);
            LblDescricaoAtualizarOrcamento.Name = "LblDescricaoAtualizarOrcamento";
            LblDescricaoAtualizarOrcamento.Size = new Size(65, 17);
            LblDescricaoAtualizarOrcamento.TabIndex = 12;
            LblDescricaoAtualizarOrcamento.Text = "Descrição";
            // 
            // panel1
            // 
            panel1.Controls.Add(RTxtDescricaoAtualizarOrcamento);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 377);
            panel1.Name = "panel1";
            panel1.Size = new Size(774, 82);
            panel1.TabIndex = 38;
            // 
            // RTxtDescricaoAtualizarOrcamento
            // 
            RTxtDescricaoAtualizarOrcamento.Dock = DockStyle.Bottom;
            RTxtDescricaoAtualizarOrcamento.Location = new Point(0, 3);
            RTxtDescricaoAtualizarOrcamento.Name = "RTxtDescricaoAtualizarOrcamento";
            RTxtDescricaoAtualizarOrcamento.Size = new Size(774, 79);
            RTxtDescricaoAtualizarOrcamento.TabIndex = 0;
            RTxtDescricaoAtualizarOrcamento.Text = "";
            // 
            // TxtPrecoUnitarioFinalAtualizarOrcamento
            // 
            TxtPrecoUnitarioFinalAtualizarOrcamento.BackColor = SystemColors.Window;
            TxtPrecoUnitarioFinalAtualizarOrcamento.Enabled = false;
            TxtPrecoUnitarioFinalAtualizarOrcamento.Font = new Font("Segoe UI Variable Display", 8.25F, FontStyle.Bold);
            TxtPrecoUnitarioFinalAtualizarOrcamento.Location = new Point(527, 71);
            TxtPrecoUnitarioFinalAtualizarOrcamento.Name = "TxtPrecoUnitarioFinalAtualizarOrcamento";
            TxtPrecoUnitarioFinalAtualizarOrcamento.Size = new Size(70, 22);
            TxtPrecoUnitarioFinalAtualizarOrcamento.TabIndex = 37;
            // 
            // LblPrecoFinalTotalAtualizarOrcamento
            // 
            LblPrecoFinalTotalAtualizarOrcamento.AutoSize = true;
            LblPrecoFinalTotalAtualizarOrcamento.Font = new Font("Segoe UI Variable Display", 8.25F);
            LblPrecoFinalTotalAtualizarOrcamento.Location = new Point(603, 74);
            LblPrecoFinalTotalAtualizarOrcamento.Name = "LblPrecoFinalTotalAtualizarOrcamento";
            LblPrecoFinalTotalAtualizarOrcamento.Size = new Size(85, 15);
            LblPrecoFinalTotalAtualizarOrcamento.TabIndex = 36;
            LblPrecoFinalTotalAtualizarOrcamento.Text = "Preço final total:";
            // 
            // TxtPrecoFinalTotalAtualizarOrcamento
            // 
            TxtPrecoFinalTotalAtualizarOrcamento.BackColor = SystemColors.Window;
            TxtPrecoFinalTotalAtualizarOrcamento.Enabled = false;
            TxtPrecoFinalTotalAtualizarOrcamento.Font = new Font("Segoe UI Variable Display", 8.25F, FontStyle.Bold);
            TxtPrecoFinalTotalAtualizarOrcamento.Location = new Point(692, 71);
            TxtPrecoFinalTotalAtualizarOrcamento.Name = "TxtPrecoFinalTotalAtualizarOrcamento";
            TxtPrecoFinalTotalAtualizarOrcamento.Size = new Size(70, 22);
            TxtPrecoFinalTotalAtualizarOrcamento.TabIndex = 35;
            // 
            // LblPrecoFinalUnitarioAtualizarOrcamento
            // 
            LblPrecoFinalUnitarioAtualizarOrcamento.AutoSize = true;
            LblPrecoFinalUnitarioAtualizarOrcamento.Font = new Font("Segoe UI Variable Display", 8.25F);
            LblPrecoFinalUnitarioAtualizarOrcamento.Location = new Point(420, 74);
            LblPrecoFinalUnitarioAtualizarOrcamento.Name = "LblPrecoFinalUnitarioAtualizarOrcamento";
            LblPrecoFinalUnitarioAtualizarOrcamento.Size = new Size(103, 15);
            LblPrecoFinalUnitarioAtualizarOrcamento.TabIndex = 34;
            LblPrecoFinalUnitarioAtualizarOrcamento.Text = "Preço final unitário: ";
            // 
            // TxtMargemAtualizarOrdem
            // 
            TxtMargemAtualizarOrdem.BackColor = SystemColors.Window;
            TxtMargemAtualizarOrdem.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtMargemAtualizarOrdem.Location = new Point(348, 62);
            TxtMargemAtualizarOrdem.Name = "TxtMargemAtualizarOrdem";
            TxtMargemAtualizarOrdem.Size = new Size(66, 33);
            TxtMargemAtualizarOrdem.TabIndex = 4;
            TxtMargemAtualizarOrdem.TextChanged += TxtMargemAtualizarOrdem_TextChanged;
            TxtMargemAtualizarOrdem.KeyPress += TxtMargemAtualizarOrdem_KeyPress;
            // 
            // LblMargemAtualizarOrcamento
            // 
            LblMargemAtualizarOrcamento.AutoSize = true;
            LblMargemAtualizarOrcamento.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblMargemAtualizarOrcamento.Location = new Point(258, 65);
            LblMargemAtualizarOrcamento.Name = "LblMargemAtualizarOrcamento";
            LblMargemAtualizarOrcamento.Size = new Size(86, 26);
            LblMargemAtualizarOrcamento.TabIndex = 32;
            LblMargemAtualizarOrcamento.Text = "Margem:";
            // 
            // TxtPrecoUnitarioAtualizarOrcamento
            // 
            TxtPrecoUnitarioAtualizarOrcamento.BackColor = SystemColors.Window;
            TxtPrecoUnitarioAtualizarOrcamento.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtPrecoUnitarioAtualizarOrcamento.Location = new Point(147, 62);
            TxtPrecoUnitarioAtualizarOrcamento.Name = "TxtPrecoUnitarioAtualizarOrcamento";
            TxtPrecoUnitarioAtualizarOrcamento.Size = new Size(105, 33);
            TxtPrecoUnitarioAtualizarOrcamento.TabIndex = 3;
            TxtPrecoUnitarioAtualizarOrcamento.TextChanged += TxtPrecoUnitarioAtualizarOrcamento_TextChanged;
            TxtPrecoUnitarioAtualizarOrcamento.KeyPress += TxtPrecoUnitarioAtualizarOrcamento_KeyPress;
            // 
            // LblPrecoUnitarioAtualizarOrcamento
            // 
            LblPrecoUnitarioAtualizarOrcamento.AutoSize = true;
            LblPrecoUnitarioAtualizarOrcamento.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPrecoUnitarioAtualizarOrcamento.Location = new Point(8, 65);
            LblPrecoUnitarioAtualizarOrcamento.Name = "LblPrecoUnitarioAtualizarOrcamento";
            LblPrecoUnitarioAtualizarOrcamento.Size = new Size(135, 26);
            LblPrecoUnitarioAtualizarOrcamento.TabIndex = 30;
            LblPrecoUnitarioAtualizarOrcamento.Text = "Custo unitário:";
            // 
            // TxtQuantidadeAtualizarOrcamento
            // 
            TxtQuantidadeAtualizarOrcamento.BackColor = SystemColors.Window;
            TxtQuantidadeAtualizarOrcamento.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtQuantidadeAtualizarOrcamento.Location = new Point(696, 11);
            TxtQuantidadeAtualizarOrcamento.Name = "TxtQuantidadeAtualizarOrcamento";
            TxtQuantidadeAtualizarOrcamento.Size = new Size(70, 33);
            TxtQuantidadeAtualizarOrcamento.TabIndex = 2;
            TxtQuantidadeAtualizarOrcamento.KeyPress += TxtQuantidadeAtualizarOrcamento_KeyPress;
            // 
            // LblQuantidadeAtualizarOrcamento
            // 
            LblQuantidadeAtualizarOrcamento.AutoSize = true;
            LblQuantidadeAtualizarOrcamento.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblQuantidadeAtualizarOrcamento.Location = new Point(579, 14);
            LblQuantidadeAtualizarOrcamento.Name = "LblQuantidadeAtualizarOrcamento";
            LblQuantidadeAtualizarOrcamento.Size = new Size(113, 26);
            LblQuantidadeAtualizarOrcamento.TabIndex = 28;
            LblQuantidadeAtualizarOrcamento.Text = "Quantidade:";
            // 
            // DgvOrcamentosAtualizar
            // 
            DgvOrcamentosAtualizar.AllowUserToAddRows = false;
            DgvOrcamentosAtualizar.AllowUserToDeleteRows = false;
            DgvOrcamentosAtualizar.AllowUserToResizeColumns = false;
            DgvOrcamentosAtualizar.AllowUserToResizeRows = false;
            DgvOrcamentosAtualizar.Anchor = AnchorStyles.Bottom;
            DgvOrcamentosAtualizar.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvOrcamentosAtualizar.Location = new Point(2, 180);
            DgvOrcamentosAtualizar.Name = "DgvOrcamentosAtualizar";
            DgvOrcamentosAtualizar.ReadOnly = true;
            DgvOrcamentosAtualizar.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvOrcamentosAtualizar.Size = new Size(774, 168);
            DgvOrcamentosAtualizar.TabIndex = 17;
            // 
            // BtnIncluirItemAtualizarOrcamento
            // 
            BtnIncluirItemAtualizarOrcamento.BackColor = SystemColors.ControlLight;
            BtnIncluirItemAtualizarOrcamento.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnIncluirItemAtualizarOrcamento.Location = new Point(8, 118);
            BtnIncluirItemAtualizarOrcamento.Name = "BtnIncluirItemAtualizarOrcamento";
            BtnIncluirItemAtualizarOrcamento.Size = new Size(365, 35);
            BtnIncluirItemAtualizarOrcamento.TabIndex = 5;
            BtnIncluirItemAtualizarOrcamento.Text = "Incluir item";
            BtnIncluirItemAtualizarOrcamento.UseVisualStyleBackColor = false;
            BtnIncluirItemAtualizarOrcamento.Click += BtnIncluirItemAtualizarOrcamento_Click;
            // 
            // BtnExcluirItemAtualizarOrcamento
            // 
            BtnExcluirItemAtualizarOrcamento.BackColor = SystemColors.ControlLight;
            BtnExcluirItemAtualizarOrcamento.Font = new Font("Segoe UI Variable Display Semib", 10F, FontStyle.Bold);
            BtnExcluirItemAtualizarOrcamento.Location = new Point(401, 118);
            BtnExcluirItemAtualizarOrcamento.Name = "BtnExcluirItemAtualizarOrcamento";
            BtnExcluirItemAtualizarOrcamento.Size = new Size(365, 35);
            BtnExcluirItemAtualizarOrcamento.TabIndex = 6;
            BtnExcluirItemAtualizarOrcamento.Text = "Excluir item";
            BtnExcluirItemAtualizarOrcamento.UseVisualStyleBackColor = false;
            BtnExcluirItemAtualizarOrcamento.Click += BtnExcluirItemAtualizarOrcamento_Click;
            // 
            // TxtItemAtualizarOrcamento
            // 
            TxtItemAtualizarOrcamento.BackColor = SystemColors.Window;
            TxtItemAtualizarOrcamento.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtItemAtualizarOrcamento.Location = new Point(66, 11);
            TxtItemAtualizarOrcamento.Name = "TxtItemAtualizarOrcamento";
            TxtItemAtualizarOrcamento.Size = new Size(396, 33);
            TxtItemAtualizarOrcamento.TabIndex = 1;
            // 
            // LblInfoOrcamentoAtualizar
            // 
            LblInfoOrcamentoAtualizar.AutoSize = true;
            LblInfoOrcamentoAtualizar.Location = new Point(5, 5);
            LblInfoOrcamentoAtualizar.Name = "LblInfoOrcamentoAtualizar";
            LblInfoOrcamentoAtualizar.Size = new Size(167, 17);
            LblInfoOrcamentoAtualizar.TabIndex = 11;
            LblInfoOrcamentoAtualizar.Text = "Informações do orçamento";
            // 
            // BtnAtualizarOrcamento
            // 
            BtnAtualizarOrcamento.AutoEllipsis = true;
            BtnAtualizarOrcamento.BackColor = SystemColors.ControlLight;
            BtnAtualizarOrcamento.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnAtualizarOrcamento.Location = new Point(4, 494);
            BtnAtualizarOrcamento.Name = "BtnAtualizarOrcamento";
            BtnAtualizarOrcamento.Size = new Size(778, 55);
            BtnAtualizarOrcamento.TabIndex = 7;
            BtnAtualizarOrcamento.Text = "Atualizar orçamento";
            BtnAtualizarOrcamento.UseVisualStyleBackColor = false;
            BtnAtualizarOrcamento.Click += BtnAtualizarOrcamento_Click;
            // 
            // FormAtualizarOrcamento
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(784, 561);
            Controls.Add(BtnAtualizarOrcamento);
            Controls.Add(LblInfoOrcamentoAtualizar);
            Controls.Add(PanelInfoOrcamentoAtualizar);
            MaximizeBox = false;
            MaximumSize = new Size(800, 600);
            MinimumSize = new Size(800, 600);
            Name = "FormAtualizarOrcamento";
            Text = "FastBox - Atualizar orçamento";
            Load += FormAtualizarOrcamento_Load;
            PanelInfoOrcamentoAtualizar.ResumeLayout(false);
            PanelInfoOrcamentoAtualizar.PerformLayout();
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)DgvOrcamentosAtualizar).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblItemAtualizarOrcamento;
        private TextBox TxtModelo;
        private Label LblModelo;
        private Label LblAno;
        private Label LblObservacoes;
        private Label LblMatricula;
        private Panel PanelInfoOrcamentoAtualizar;
        private Label LblInfoOrcamentoAtualizar;
        private Button BtnAtualizarOrcamento;
        private MaskedTextBox TxtMskAno;
        private MaskedTextBox TxtMskMatricula;
        private Label LblInfoMatricula;
        private RichTextBox RTxtObservacoes;
        private Button BtnNovoCliente;
        private Label LblCliente;
        private TextBox TxtCliente;
        private TextBox TxtItemAtualizarOrcamento;
        private ComboBox CmbVeiculosOrcamentoAtualizar;
        private Label LblVeiculoOrcamentoAtualizar;
        private ListBox LstSugestoesClientes;
        private Button BtnNovoVeiculoOrcamentoAtualizar;
        private Button BtnNovoClienteOrcamentoAtualizar;
        private Button BtnExcluirItemAtualizarOrcamento;
        private Button BtnIncluirItemAtualizarOrcamento;
        private DataGridView DgvOrcamentosAtualizar;
        private TextBox TxtQuantidadeAtualizarOrcamento;
        private Label LblQuantidadeAtualizarOrcamento;
        private TextBox TxtMargemAtualizarOrdem;
        private Label LblMargemAtualizarOrcamento;
        private TextBox TxtPrecoUnitarioAtualizarOrcamento;
        private Label LblPrecoUnitarioAtualizarOrcamento;
        private TextBox TxtPrecoUnitarioFinalAtualizarOrcamento;
        private Label LblPrecoFinalTotalAtualizarOrcamento;
        private TextBox TxtPrecoFinalTotalAtualizarOrcamento;
        private Label LblPrecoFinalUnitarioAtualizarOrcamento;
        private Panel panel1;
        private Label LblDescricaoAtualizarOrcamento;
        private RichTextBox RTxtDescricaoAtualizarOrcamento;
        private CheckBox ChkMaoDeObra;
    }
}