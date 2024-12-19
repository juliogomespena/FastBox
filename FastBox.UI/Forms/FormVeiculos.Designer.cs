namespace FastBox.UI.Forms
{
    partial class FormVeiculos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormVeiculos));
            DgvVeiculos = new DataGridView();
            PanelVeiculosBotoes = new Panel();
            BtnRefresh = new Button();
            BtnNextPage = new Button();
            BtnPreviousPage = new Button();
            BtnExcluirVeiculo = new Button();
            BtnAbrirVeiculo = new Button();
            BtnCadastrarVeiculo = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            TspBusca = new ToolStrip();
            TxtInfoTspBuscca = new ToolStripLabel();
            TspTxtMarca = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            TspTxtModelo = new ToolStripTextBox();
            toolStripSeparator2 = new ToolStripSeparator();
            TspTxtAno = new ToolStripTextBox();
            toolStripSeparator3 = new ToolStripSeparator();
            TspTxtMatricula = new ToolStripTextBox();
            toolStripSeparator4 = new ToolStripSeparator();
            TspTxtCliente = new ToolStripTextBox();
            toolStripSeparator5 = new ToolStripSeparator();
            TspTxtObservacoes = new ToolStripTextBox();
            TspBtnAplicar = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)DgvVeiculos).BeginInit();
            PanelVeiculosBotoes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            TspBusca.SuspendLayout();
            SuspendLayout();
            // 
            // DgvVeiculos
            // 
            DgvVeiculos.AllowUserToResizeColumns = false;
            DgvVeiculos.AllowUserToResizeRows = false;
            DgvVeiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvVeiculos.Dock = DockStyle.Fill;
            DgvVeiculos.Location = new Point(3, 3);
            DgvVeiculos.Name = "DgvVeiculos";
            DgvVeiculos.ReadOnly = true;
            DgvVeiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvVeiculos.Size = new Size(1258, 564);
            DgvVeiculos.TabIndex = 0;
            // 
            // PanelVeiculosBotoes
            // 
            PanelVeiculosBotoes.BackColor = SystemColors.ControlLight;
            PanelVeiculosBotoes.Controls.Add(BtnRefresh);
            PanelVeiculosBotoes.Controls.Add(BtnNextPage);
            PanelVeiculosBotoes.Controls.Add(BtnPreviousPage);
            PanelVeiculosBotoes.Controls.Add(BtnExcluirVeiculo);
            PanelVeiculosBotoes.Controls.Add(BtnAbrirVeiculo);
            PanelVeiculosBotoes.Controls.Add(BtnCadastrarVeiculo);
            PanelVeiculosBotoes.Dock = DockStyle.Fill;
            PanelVeiculosBotoes.Location = new Point(3, 614);
            PanelVeiculosBotoes.Name = "PanelVeiculosBotoes";
            PanelVeiculosBotoes.Size = new Size(1258, 64);
            PanelVeiculosBotoes.TabIndex = 1;
            // 
            // BtnRefresh
            // 
            BtnRefresh.Anchor = AnchorStyles.Right;
            BtnRefresh.AutoEllipsis = true;
            BtnRefresh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnRefresh.BackColor = SystemColors.ControlLight;
            BtnRefresh.Font = new Font("Segoe UI Variable Display Semib", 26F, FontStyle.Bold);
            BtnRefresh.Location = new Point(1027, 6);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(72, 55);
            BtnRefresh.TabIndex = 5;
            BtnRefresh.Text = "⟳";
            BtnRefresh.UseVisualStyleBackColor = false;
            BtnRefresh.Click += BtnRefresh_Click;
            // 
            // BtnNextPage
            // 
            BtnNextPage.Anchor = AnchorStyles.Right;
            BtnNextPage.AutoEllipsis = true;
            BtnNextPage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnNextPage.BackColor = SystemColors.ControlLight;
            BtnNextPage.Font = new Font("Segoe UI Variable Display Semib", 30F, FontStyle.Bold);
            BtnNextPage.Location = new Point(1180, 6);
            BtnNextPage.Name = "BtnNextPage";
            BtnNextPage.Size = new Size(69, 55);
            BtnNextPage.TabIndex = 4;
            BtnNextPage.Text = "→";
            BtnNextPage.UseVisualStyleBackColor = false;
            BtnNextPage.Click += BtnNextPage_Click;
            // 
            // BtnPreviousPage
            // 
            BtnPreviousPage.Anchor = AnchorStyles.Right;
            BtnPreviousPage.AutoEllipsis = true;
            BtnPreviousPage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnPreviousPage.BackColor = SystemColors.ControlLight;
            BtnPreviousPage.Font = new Font("Segoe UI Variable Display Semib", 30F, FontStyle.Bold);
            BtnPreviousPage.Location = new Point(1105, 6);
            BtnPreviousPage.Name = "BtnPreviousPage";
            BtnPreviousPage.Size = new Size(69, 55);
            BtnPreviousPage.TabIndex = 3;
            BtnPreviousPage.Text = "←";
            BtnPreviousPage.UseVisualStyleBackColor = false;
            BtnPreviousPage.Click += BtnPreviousPage_Click;
            // 
            // BtnExcluirVeiculo
            // 
            BtnExcluirVeiculo.Anchor = AnchorStyles.Left;
            BtnExcluirVeiculo.AutoEllipsis = true;
            BtnExcluirVeiculo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnExcluirVeiculo.BackColor = SystemColors.ControlLight;
            BtnExcluirVeiculo.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnExcluirVeiculo.Location = new Point(427, 6);
            BtnExcluirVeiculo.Name = "BtnExcluirVeiculo";
            BtnExcluirVeiculo.Size = new Size(203, 55);
            BtnExcluirVeiculo.TabIndex = 2;
            BtnExcluirVeiculo.Text = "Excluir";
            BtnExcluirVeiculo.UseVisualStyleBackColor = false;
            BtnExcluirVeiculo.Click += BtnExcluirVeiculo_Click;
            // 
            // BtnAbrirVeiculo
            // 
            BtnAbrirVeiculo.Anchor = AnchorStyles.Left;
            BtnAbrirVeiculo.AutoEllipsis = true;
            BtnAbrirVeiculo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnAbrirVeiculo.BackColor = SystemColors.ControlLight;
            BtnAbrirVeiculo.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnAbrirVeiculo.Location = new Point(218, 6);
            BtnAbrirVeiculo.Name = "BtnAbrirVeiculo";
            BtnAbrirVeiculo.Size = new Size(203, 55);
            BtnAbrirVeiculo.TabIndex = 1;
            BtnAbrirVeiculo.Text = "Abrir";
            BtnAbrirVeiculo.UseVisualStyleBackColor = false;
            BtnAbrirVeiculo.Click += BtnAtualizarVeiculo_Click;
            // 
            // BtnCadastrarVeiculo
            // 
            BtnCadastrarVeiculo.Anchor = AnchorStyles.Left;
            BtnCadastrarVeiculo.AutoEllipsis = true;
            BtnCadastrarVeiculo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnCadastrarVeiculo.BackColor = SystemColors.ControlLight;
            BtnCadastrarVeiculo.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnCadastrarVeiculo.Location = new Point(9, 6);
            BtnCadastrarVeiculo.Name = "BtnCadastrarVeiculo";
            BtnCadastrarVeiculo.Size = new Size(203, 55);
            BtnCadastrarVeiculo.TabIndex = 0;
            BtnCadastrarVeiculo.Text = "Cadastrar";
            BtnCadastrarVeiculo.UseVisualStyleBackColor = false;
            BtnCadastrarVeiculo.Click += BtnCadastrarVeiculo_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlLight;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(TspBusca, 0, 1);
            tableLayoutPanel1.Controls.Add(DgvVeiculos, 0, 0);
            tableLayoutPanel1.Controls.Add(PanelVeiculosBotoes, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 41F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.Size = new Size(1264, 681);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // TspBusca
            // 
            TspBusca.Dock = DockStyle.Fill;
            TspBusca.Items.AddRange(new ToolStripItem[] { TxtInfoTspBuscca, TspTxtMarca, toolStripSeparator1, TspTxtModelo, toolStripSeparator2, TspTxtAno, toolStripSeparator3, TspTxtMatricula, toolStripSeparator4, TspTxtCliente, toolStripSeparator5, TspTxtObservacoes, TspBtnAplicar });
            TspBusca.Location = new Point(0, 570);
            TspBusca.Name = "TspBusca";
            TspBusca.Size = new Size(1264, 41);
            TspBusca.TabIndex = 3;
            TspBusca.Text = "toolStrip1";
            // 
            // TxtInfoTspBuscca
            // 
            TxtInfoTspBuscca.Name = "TxtInfoTspBuscca";
            TxtInfoTspBuscca.Size = new Size(53, 38);
            TxtInfoTspBuscca.Text = "Buscar: ";
            // 
            // TspTxtMarca
            // 
            TspTxtMarca.ForeColor = Color.Gray;
            TspTxtMarca.Name = "TspTxtMarca";
            TspTxtMarca.Size = new Size(100, 41);
            TspTxtMarca.Text = "Marca";
            TspTxtMarca.Enter += TspTxtMarca_Enter;
            TspTxtMarca.Leave += TspTxtMarca_Leave;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 41);
            // 
            // TspTxtModelo
            // 
            TspTxtModelo.ForeColor = Color.Gray;
            TspTxtModelo.Name = "TspTxtModelo";
            TspTxtModelo.Size = new Size(100, 41);
            TspTxtModelo.Text = "Modelo";
            TspTxtModelo.Enter += TspTxtModelo_Enter;
            TspTxtModelo.Leave += TspTxtModelo_Leave;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 41);
            // 
            // TspTxtAno
            // 
            TspTxtAno.ForeColor = Color.Gray;
            TspTxtAno.Name = "TspTxtAno";
            TspTxtAno.Size = new Size(50, 41);
            TspTxtAno.Text = "Ano";
            TspTxtAno.Enter += TspTxtAno_Enter;
            TspTxtAno.Leave += TspTxtAno_Leave;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 41);
            // 
            // TspTxtMatricula
            // 
            TspTxtMatricula.ForeColor = Color.Gray;
            TspTxtMatricula.Name = "TspTxtMatricula";
            TspTxtMatricula.Size = new Size(100, 41);
            TspTxtMatricula.Text = "Matrícula";
            TspTxtMatricula.Enter += TspTxtMatricula_Enter;
            TspTxtMatricula.Leave += TspTxtMatricula_Leave;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 41);
            // 
            // TspTxtCliente
            // 
            TspTxtCliente.ForeColor = Color.Gray;
            TspTxtCliente.Name = "TspTxtCliente";
            TspTxtCliente.Size = new Size(150, 41);
            TspTxtCliente.Text = "Cliente";
            TspTxtCliente.Enter += TspTxtCliente_Enter;
            TspTxtCliente.Leave += TspTxtCliente_Leave;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 41);
            // 
            // TspTxtObservacoes
            // 
            TspTxtObservacoes.ForeColor = Color.Gray;
            TspTxtObservacoes.Name = "TspTxtObservacoes";
            TspTxtObservacoes.Size = new Size(150, 41);
            TspTxtObservacoes.Text = "Observações";
            TspTxtObservacoes.Enter += TspTxtObservacoes_Enter;
            TspTxtObservacoes.Leave += TspTxtObservacoes_Leave;
            // 
            // TspBtnAplicar
            // 
            TspBtnAplicar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            TspBtnAplicar.Image = (Image)resources.GetObject("TspBtnAplicar.Image");
            TspBtnAplicar.ImageTransparentColor = Color.Magenta;
            TspBtnAplicar.Name = "TspBtnAplicar";
            TspBtnAplicar.Size = new Size(52, 38);
            TspBtnAplicar.Text = "Aplicar";
            TspBtnAplicar.Click += TspBtnAplicar_Click;
            // 
            // FormVeiculos
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(tableLayoutPanel1);
            Name = "FormVeiculos";
            Text = "FastBox - Veículos";
            Load += FormVeiculos_Load;
            ((System.ComponentModel.ISupportInitialize)DgvVeiculos).EndInit();
            PanelVeiculosBotoes.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            TspBusca.ResumeLayout(false);
            TspBusca.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvVeiculos;
        private Panel PanelVeiculosBotoes;
        private Button BtnExcluirVeiculo;
        private Button BtnAbrirVeiculo;
        private Button BtnCadastrarVeiculo;
        private Button BtnPreviousPage;
        private Button BtnNextPage;
        private TableLayoutPanel tableLayoutPanel1;
        private Button BtnRefresh;
        private ToolStrip TspBusca;
        private ToolStripLabel TxtInfoTspBuscca;
        private ToolStripTextBox TspTxtMarca;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox TspTxtModelo;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripTextBox TspTxtAno;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripTextBox TspTxtMatricula;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripTextBox TspTxtCliente;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripTextBox TspTxtObservacoes;
        private ToolStripButton TspBtnAplicar;
    }
}