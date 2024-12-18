namespace FastBox.UI.Forms
{
    partial class FormOrdensDeServico
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormOrdensDeServico));
            DgvOrdensDeServico = new DataGridView();
            PanelOrdensDeServicoBotoes = new Panel();
            BtnCancelar = new Button();
            BtnConcluirOrdem = new Button();
            BtnFinalizarServico = new Button();
            BtnRefresh = new Button();
            BtnNextPage = new Button();
            BtnPreviousPage = new Button();
            BtnExcluirOrdemDeServico = new Button();
            BtnAbrirOrdemDeServico = new Button();
            BtnNovaOrdemDeServico = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            TspBusca = new ToolStrip();
            TxtInfoTspBuscca = new ToolStripLabel();
            TspCmbStatus = new ToolStripComboBox();
            toolStripSeparator1 = new ToolStripSeparator();
            TspTxtCliente = new ToolStripTextBox();
            toolStripSeparator2 = new ToolStripSeparator();
            TspTxtVeiculo = new ToolStripTextBox();
            toolStripSeparator3 = new ToolStripSeparator();
            TspTxtDescricao = new ToolStripTextBox();
            toolStripSeparator4 = new ToolStripSeparator();
            TspTxtAbertura = new ToolStripTextBox();
            toolStripSeparator5 = new ToolStripSeparator();
            TspTxtPrazo = new ToolStripTextBox();
            toolStripSeparator6 = new ToolStripSeparator();
            TspTxtValorTotal = new ToolStripTextBox();
            TspCmbValorTotalOpcao = new ToolStripComboBox();
            TspBtnAplicar = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)DgvOrdensDeServico).BeginInit();
            PanelOrdensDeServicoBotoes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            TspBusca.SuspendLayout();
            SuspendLayout();
            // 
            // DgvOrdensDeServico
            // 
            DgvOrdensDeServico.AllowUserToResizeColumns = false;
            DgvOrdensDeServico.AllowUserToResizeRows = false;
            DgvOrdensDeServico.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvOrdensDeServico.Dock = DockStyle.Fill;
            DgvOrdensDeServico.Location = new Point(3, 3);
            DgvOrdensDeServico.Name = "DgvOrdensDeServico";
            DgvOrdensDeServico.ReadOnly = true;
            DgvOrdensDeServico.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvOrdensDeServico.Size = new Size(1258, 564);
            DgvOrdensDeServico.TabIndex = 0;
            // 
            // PanelOrdensDeServicoBotoes
            // 
            PanelOrdensDeServicoBotoes.BackColor = SystemColors.ControlLight;
            PanelOrdensDeServicoBotoes.Controls.Add(BtnCancelar);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnConcluirOrdem);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnFinalizarServico);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnRefresh);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnNextPage);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnPreviousPage);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnExcluirOrdemDeServico);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnAbrirOrdemDeServico);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnNovaOrdemDeServico);
            PanelOrdensDeServicoBotoes.Dock = DockStyle.Fill;
            PanelOrdensDeServicoBotoes.Location = new Point(3, 614);
            PanelOrdensDeServicoBotoes.Name = "PanelOrdensDeServicoBotoes";
            PanelOrdensDeServicoBotoes.Size = new Size(1258, 64);
            PanelOrdensDeServicoBotoes.TabIndex = 1;
            // 
            // BtnCancelar
            // 
            BtnCancelar.Anchor = AnchorStyles.Left;
            BtnCancelar.AutoEllipsis = true;
            BtnCancelar.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnCancelar.BackColor = SystemColors.ControlLight;
            BtnCancelar.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnCancelar.Location = new Point(569, 6);
            BtnCancelar.Name = "BtnCancelar";
            BtnCancelar.Size = new Size(134, 55);
            BtnCancelar.TabIndex = 8;
            BtnCancelar.Text = "Cancelar";
            BtnCancelar.UseVisualStyleBackColor = false;
            BtnCancelar.Click += BtnCancelar_Click;
            // 
            // BtnConcluirOrdem
            // 
            BtnConcluirOrdem.Anchor = AnchorStyles.Left;
            BtnConcluirOrdem.AutoEllipsis = true;
            BtnConcluirOrdem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnConcluirOrdem.BackColor = SystemColors.ControlLight;
            BtnConcluirOrdem.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnConcluirOrdem.Location = new Point(429, 6);
            BtnConcluirOrdem.Name = "BtnConcluirOrdem";
            BtnConcluirOrdem.Size = new Size(134, 55);
            BtnConcluirOrdem.TabIndex = 7;
            BtnConcluirOrdem.Text = "Concluir";
            BtnConcluirOrdem.UseVisualStyleBackColor = false;
            BtnConcluirOrdem.Click += BtnConcluirOrdem_Click;
            // 
            // BtnFinalizarServico
            // 
            BtnFinalizarServico.Anchor = AnchorStyles.Left;
            BtnFinalizarServico.AutoEllipsis = true;
            BtnFinalizarServico.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnFinalizarServico.BackColor = SystemColors.ControlLight;
            BtnFinalizarServico.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnFinalizarServico.Location = new Point(289, 6);
            BtnFinalizarServico.Name = "BtnFinalizarServico";
            BtnFinalizarServico.Size = new Size(134, 55);
            BtnFinalizarServico.TabIndex = 6;
            BtnFinalizarServico.Text = "Retirada";
            BtnFinalizarServico.UseVisualStyleBackColor = false;
            BtnFinalizarServico.Click += BtnFinalizarServico_Click;
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
            // BtnExcluirOrdemDeServico
            // 
            BtnExcluirOrdemDeServico.Anchor = AnchorStyles.Left;
            BtnExcluirOrdemDeServico.AutoEllipsis = true;
            BtnExcluirOrdemDeServico.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnExcluirOrdemDeServico.BackColor = SystemColors.ControlLight;
            BtnExcluirOrdemDeServico.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnExcluirOrdemDeServico.Location = new Point(709, 6);
            BtnExcluirOrdemDeServico.Name = "BtnExcluirOrdemDeServico";
            BtnExcluirOrdemDeServico.Size = new Size(134, 55);
            BtnExcluirOrdemDeServico.TabIndex = 2;
            BtnExcluirOrdemDeServico.Text = "Excluir";
            BtnExcluirOrdemDeServico.UseVisualStyleBackColor = false;
            BtnExcluirOrdemDeServico.Click += BtnExcluirOrdemDeServico_Click;
            // 
            // BtnAbrirOrdemDeServico
            // 
            BtnAbrirOrdemDeServico.Anchor = AnchorStyles.Left;
            BtnAbrirOrdemDeServico.AutoEllipsis = true;
            BtnAbrirOrdemDeServico.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnAbrirOrdemDeServico.BackColor = SystemColors.ControlLight;
            BtnAbrirOrdemDeServico.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnAbrirOrdemDeServico.Location = new Point(149, 6);
            BtnAbrirOrdemDeServico.Name = "BtnAbrirOrdemDeServico";
            BtnAbrirOrdemDeServico.Size = new Size(134, 55);
            BtnAbrirOrdemDeServico.TabIndex = 1;
            BtnAbrirOrdemDeServico.Text = "Abrir";
            BtnAbrirOrdemDeServico.UseVisualStyleBackColor = false;
            BtnAbrirOrdemDeServico.Click += BtnAtualizarOrdemDeServico_Click;
            // 
            // BtnNovaOrdemDeServico
            // 
            BtnNovaOrdemDeServico.Anchor = AnchorStyles.Left;
            BtnNovaOrdemDeServico.AutoEllipsis = true;
            BtnNovaOrdemDeServico.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnNovaOrdemDeServico.BackColor = SystemColors.ControlLight;
            BtnNovaOrdemDeServico.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnNovaOrdemDeServico.Location = new Point(9, 6);
            BtnNovaOrdemDeServico.Name = "BtnNovaOrdemDeServico";
            BtnNovaOrdemDeServico.Size = new Size(134, 55);
            BtnNovaOrdemDeServico.TabIndex = 0;
            BtnNovaOrdemDeServico.Text = "Nova";
            BtnNovaOrdemDeServico.UseVisualStyleBackColor = false;
            BtnNovaOrdemDeServico.Click += BtnCadastrarOrdemDeServico_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlLight;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(TspBusca, 0, 1);
            tableLayoutPanel1.Controls.Add(DgvOrdensDeServico, 0, 0);
            tableLayoutPanel1.Controls.Add(PanelOrdensDeServicoBotoes, 0, 2);
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
            TspBusca.Items.AddRange(new ToolStripItem[] { TxtInfoTspBuscca, TspCmbStatus, toolStripSeparator1, TspTxtCliente, toolStripSeparator2, TspTxtVeiculo, toolStripSeparator3, TspTxtDescricao, toolStripSeparator4, TspTxtAbertura, toolStripSeparator5, TspTxtPrazo, toolStripSeparator6, TspTxtValorTotal, TspCmbValorTotalOpcao, TspBtnAplicar });
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
            // TspCmbStatus
            // 
            TspCmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            TspCmbStatus.ForeColor = SystemColors.WindowText;
            TspCmbStatus.Name = "TspCmbStatus";
            TspCmbStatus.Size = new Size(175, 41);
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 41);
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
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 41);
            // 
            // TspTxtVeiculo
            // 
            TspTxtVeiculo.ForeColor = Color.Gray;
            TspTxtVeiculo.Name = "TspTxtVeiculo";
            TspTxtVeiculo.Size = new Size(150, 41);
            TspTxtVeiculo.Text = "Veículo";
            TspTxtVeiculo.Enter += TspTxtVeiculo_Enter;
            TspTxtVeiculo.Leave += TspTxtVeiculo_Leave;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 41);
            // 
            // TspTxtDescricao
            // 
            TspTxtDescricao.ForeColor = Color.Gray;
            TspTxtDescricao.Name = "TspTxtDescricao";
            TspTxtDescricao.Size = new Size(150, 41);
            TspTxtDescricao.Text = "Descrição";
            TspTxtDescricao.Enter += TspTxtDescricao_Enter;
            TspTxtDescricao.Leave += TspTxtDescricao_Leave;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 41);
            // 
            // TspTxtAbertura
            // 
            TspTxtAbertura.ForeColor = Color.Gray;
            TspTxtAbertura.Name = "TspTxtAbertura";
            TspTxtAbertura.Size = new Size(120, 41);
            TspTxtAbertura.Text = "Data de abertura";
            TspTxtAbertura.Enter += TspTxtAbertura_Enter;
            TspTxtAbertura.Leave += TspTxtAbertura_Leave;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 41);
            // 
            // TspTxtPrazo
            // 
            TspTxtPrazo.ForeColor = Color.Gray;
            TspTxtPrazo.Name = "TspTxtPrazo";
            TspTxtPrazo.Size = new Size(120, 41);
            TspTxtPrazo.Text = "Prazo estimado";
            TspTxtPrazo.Enter += TspTxtPrazo_Enter;
            TspTxtPrazo.Leave += TspTxtPrazo_Leave;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 41);
            // 
            // TspTxtValorTotal
            // 
            TspTxtValorTotal.ForeColor = Color.Gray;
            TspTxtValorTotal.Name = "TspTxtValorTotal";
            TspTxtValorTotal.Size = new Size(80, 41);
            TspTxtValorTotal.Text = "Valor total";
            TspTxtValorTotal.Enter += TspTxtValorTotal_Enter;
            TspTxtValorTotal.Leave += TspTxtValorTotal_Leave;
            // 
            // TspCmbValorTotalOpcao
            // 
            TspCmbValorTotalOpcao.DropDownStyle = ComboBoxStyle.DropDownList;
            TspCmbValorTotalOpcao.Items.AddRange(new object[] { "Maior", "Menor" });
            TspCmbValorTotalOpcao.Name = "TspCmbValorTotalOpcao";
            TspCmbValorTotalOpcao.Size = new Size(75, 41);
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
            // FormOrdensDeServico
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(tableLayoutPanel1);
            Name = "FormOrdensDeServico";
            Text = "FastBox - Ordens de Serviço";
            Load += FormOrdensDeServico_Load;
            ((System.ComponentModel.ISupportInitialize)DgvOrdensDeServico).EndInit();
            PanelOrdensDeServicoBotoes.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            TspBusca.ResumeLayout(false);
            TspBusca.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvOrdensDeServico;
        private Panel PanelOrdensDeServicoBotoes;
        private Button BtnExcluirOrdemDeServico;
        private Button BtnAbrirOrdemDeServico;
        private Button BtnNovaOrdemDeServico;
        private Button BtnPreviousPage;
        private Button BtnNextPage;
        private TableLayoutPanel tableLayoutPanel1;
        private Button BtnRefresh;
        private Button BtnFinalizarServico;
        private Button BtnConcluirOrdem;
        private ToolStrip TspBusca;
        private ToolStripLabel TxtInfoTspBuscca;
        private ToolStripComboBox TspCmbStatus;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox TspTxtCliente;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripTextBox TspTxtVeiculo;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripTextBox TspTxtDescricao;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripTextBox TspTxtAbertura;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripTextBox TspTxtPrazo;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripTextBox TspTxtValorTotal;
        private ToolStripComboBox TspCmbValorTotalOpcao;
        private ToolStripButton TspBtnAplicar;
        private Button BtnCancelar;
    }
}
