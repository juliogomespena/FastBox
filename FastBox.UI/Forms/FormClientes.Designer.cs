namespace FastBox.UI.Forms
{
    partial class FormClientes
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormClientes));
            DgvClientes = new DataGridView();
            PanelClientesBotoes = new Panel();
            BtnRefresh = new Button();
            BtnNextPage = new Button();
            BtnPreviousPage = new Button();
            BtnExcluirCliente = new Button();
            BtnAtualizarCliente = new Button();
            BtnCadastrarCliente = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            TspBusca = new ToolStrip();
            TxtInfoTspBuscca = new ToolStripLabel();
            TspTxtNome = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            TspTxtNif = new ToolStripTextBox();
            toolStripSeparator2 = new ToolStripSeparator();
            TspTxtTelemovel = new ToolStripTextBox();
            toolStripSeparator3 = new ToolStripSeparator();
            TspTxtEmail = new ToolStripTextBox();
            toolStripSeparator4 = new ToolStripSeparator();
            TspTxtDataInicial = new ToolStripTextBox();
            TstLblData = new ToolStripLabel();
            TspTxtDataFinal = new ToolStripTextBox();
            toolStripSeparator5 = new ToolStripSeparator();
            TspTxtMatricula = new ToolStripTextBox();
            toolStripSeparator6 = new ToolStripSeparator();
            TspTxtEndereco = new ToolStripTextBox();
            toolStripSeparator7 = new ToolStripSeparator();
            TspBtnAplicar = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)DgvClientes).BeginInit();
            PanelClientesBotoes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            TspBusca.SuspendLayout();
            SuspendLayout();
            // 
            // DgvClientes
            // 
            DgvClientes.AllowUserToResizeColumns = false;
            DgvClientes.AllowUserToResizeRows = false;
            DgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvClientes.Dock = DockStyle.Fill;
            DgvClientes.Location = new Point(3, 3);
            DgvClientes.Name = "DgvClientes";
            DgvClientes.ReadOnly = true;
            DgvClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvClientes.Size = new Size(1258, 580);
            DgvClientes.TabIndex = 0;
            DgvClientes.CellToolTipTextNeeded += DgvClientes_CellToolTipTextNeeded;
            // 
            // PanelClientesBotoes
            // 
            PanelClientesBotoes.BackColor = SystemColors.ControlLight;
            PanelClientesBotoes.Controls.Add(BtnRefresh);
            PanelClientesBotoes.Controls.Add(BtnNextPage);
            PanelClientesBotoes.Controls.Add(BtnPreviousPage);
            PanelClientesBotoes.Controls.Add(BtnExcluirCliente);
            PanelClientesBotoes.Controls.Add(BtnAtualizarCliente);
            PanelClientesBotoes.Controls.Add(BtnCadastrarCliente);
            PanelClientesBotoes.Dock = DockStyle.Fill;
            PanelClientesBotoes.Location = new Point(3, 614);
            PanelClientesBotoes.Name = "PanelClientesBotoes";
            PanelClientesBotoes.Size = new Size(1258, 64);
            PanelClientesBotoes.TabIndex = 1;
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
            // BtnExcluirCliente
            // 
            BtnExcluirCliente.Anchor = AnchorStyles.Left;
            BtnExcluirCliente.AutoEllipsis = true;
            BtnExcluirCliente.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnExcluirCliente.BackColor = SystemColors.ControlLight;
            BtnExcluirCliente.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnExcluirCliente.Location = new Point(427, 6);
            BtnExcluirCliente.Name = "BtnExcluirCliente";
            BtnExcluirCliente.Size = new Size(203, 55);
            BtnExcluirCliente.TabIndex = 2;
            BtnExcluirCliente.Text = "Excluir";
            BtnExcluirCliente.UseVisualStyleBackColor = false;
            BtnExcluirCliente.Click += BtnExcluirCliente_Click;
            // 
            // BtnAtualizarCliente
            // 
            BtnAtualizarCliente.Anchor = AnchorStyles.Left;
            BtnAtualizarCliente.AutoEllipsis = true;
            BtnAtualizarCliente.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnAtualizarCliente.BackColor = SystemColors.ControlLight;
            BtnAtualizarCliente.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnAtualizarCliente.Location = new Point(218, 6);
            BtnAtualizarCliente.Name = "BtnAtualizarCliente";
            BtnAtualizarCliente.Size = new Size(203, 55);
            BtnAtualizarCliente.TabIndex = 1;
            BtnAtualizarCliente.Text = "Atualizar";
            BtnAtualizarCliente.UseVisualStyleBackColor = false;
            BtnAtualizarCliente.Click += BtnAtualizarCliente_Click;
            // 
            // BtnCadastrarCliente
            // 
            BtnCadastrarCliente.Anchor = AnchorStyles.Left;
            BtnCadastrarCliente.AutoEllipsis = true;
            BtnCadastrarCliente.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnCadastrarCliente.BackColor = SystemColors.ControlLight;
            BtnCadastrarCliente.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnCadastrarCliente.Location = new Point(9, 6);
            BtnCadastrarCliente.Name = "BtnCadastrarCliente";
            BtnCadastrarCliente.Size = new Size(203, 55);
            BtnCadastrarCliente.TabIndex = 0;
            BtnCadastrarCliente.Text = "Cadastrar";
            BtnCadastrarCliente.UseVisualStyleBackColor = false;
            BtnCadastrarCliente.Click += BtnCadastrarCliente_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlLight;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(TspBusca, 0, 1);
            tableLayoutPanel1.Controls.Add(DgvClientes, 0, 0);
            tableLayoutPanel1.Controls.Add(PanelClientesBotoes, 0, 2);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 3;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 25F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 70F));
            tableLayoutPanel1.Size = new Size(1264, 681);
            tableLayoutPanel1.TabIndex = 5;
            // 
            // TspBusca
            // 
            TspBusca.Items.AddRange(new ToolStripItem[] { TxtInfoTspBuscca, TspTxtNome, toolStripSeparator1, TspTxtNif, toolStripSeparator2, TspTxtTelemovel, toolStripSeparator3, TspTxtEmail, toolStripSeparator4, TspTxtDataInicial, TstLblData, TspTxtDataFinal, toolStripSeparator5, TspTxtMatricula, toolStripSeparator6, TspTxtEndereco, toolStripSeparator7, TspBtnAplicar });
            TspBusca.Location = new Point(0, 586);
            TspBusca.Name = "TspBusca";
            TspBusca.Size = new Size(1264, 25);
            TspBusca.TabIndex = 2;
            TspBusca.Text = "toolStrip1";
            // 
            // TxtInfoTspBuscca
            // 
            TxtInfoTspBuscca.Name = "TxtInfoTspBuscca";
            TxtInfoTspBuscca.Size = new Size(53, 22);
            TxtInfoTspBuscca.Text = "Buscar: ";
            // 
            // TspTxtNome
            // 
            TspTxtNome.ForeColor = Color.Gray;
            TspTxtNome.Name = "TspTxtNome";
            TspTxtNome.Size = new Size(150, 25);
            TspTxtNome.Text = "Nome completo";
            TspTxtNome.ToolTipText = "Nome";
            TspTxtNome.Enter += TspTxtNome_Enter;
            TspTxtNome.Leave += TspTxtNome_Leave;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 25);
            // 
            // TspTxtNif
            // 
            TspTxtNif.ForeColor = Color.Gray;
            TspTxtNif.Name = "TspTxtNif";
            TspTxtNif.Size = new Size(80, 25);
            TspTxtNif.Text = "NIF";
            TspTxtNif.Enter += TspTxtNif_Enter;
            TspTxtNif.Leave += TspTxtNif_Leave;
            // 
            // toolStripSeparator2
            // 
            toolStripSeparator2.Name = "toolStripSeparator2";
            toolStripSeparator2.Size = new Size(6, 25);
            // 
            // TspTxtTelemovel
            // 
            TspTxtTelemovel.ForeColor = Color.Gray;
            TspTxtTelemovel.Name = "TspTxtTelemovel";
            TspTxtTelemovel.Size = new Size(100, 25);
            TspTxtTelemovel.Text = "Telemóvel";
            TspTxtTelemovel.Enter += TspTxtTelemovel_Enter;
            TspTxtTelemovel.Leave += TspTxtTelemovel_Leave;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 25);
            // 
            // TspTxtEmail
            // 
            TspTxtEmail.ForeColor = Color.Gray;
            TspTxtEmail.Name = "TspTxtEmail";
            TspTxtEmail.Size = new Size(180, 25);
            TspTxtEmail.Text = "Email";
            TspTxtEmail.Enter += TspTxtEmail_Enter;
            TspTxtEmail.Leave += TspTxtEmail_Leave;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 25);
            // 
            // TspTxtDataInicial
            // 
            TspTxtDataInicial.ForeColor = Color.Gray;
            TspTxtDataInicial.Name = "TspTxtDataInicial";
            TspTxtDataInicial.Size = new Size(120, 25);
            TspTxtDataInicial.Text = "Data inicial";
            TspTxtDataInicial.Enter += TspTxtDataInicial_Enter;
            TspTxtDataInicial.Leave += TspTxtDataInicial_Leave;
            // 
            // TstLblData
            // 
            TstLblData.Name = "TstLblData";
            TstLblData.Size = new Size(26, 22);
            TstLblData.Text = "até";
            // 
            // TspTxtDataFinal
            // 
            TspTxtDataFinal.ForeColor = Color.Gray;
            TspTxtDataFinal.Name = "TspTxtDataFinal";
            TspTxtDataFinal.Size = new Size(120, 25);
            TspTxtDataFinal.Text = "Data final";
            TspTxtDataFinal.Enter += TspTxtDataFinal_Enter;
            TspTxtDataFinal.Leave += TspTxtDataFinal_Leave;
            // 
            // toolStripSeparator5
            // 
            toolStripSeparator5.Name = "toolStripSeparator5";
            toolStripSeparator5.Size = new Size(6, 25);
            // 
            // TspTxtMatricula
            // 
            TspTxtMatricula.ForeColor = Color.Gray;
            TspTxtMatricula.Name = "TspTxtMatricula";
            TspTxtMatricula.Size = new Size(80, 25);
            TspTxtMatricula.Text = "Matrícula";
            TspTxtMatricula.Enter += TspTxtMatricula_Enter;
            TspTxtMatricula.Leave += TspTxtMatricula_Leave;
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 25);
            // 
            // TspTxtEndereco
            // 
            TspTxtEndereco.ForeColor = Color.Gray;
            TspTxtEndereco.Name = "TspTxtEndereco";
            TspTxtEndereco.Size = new Size(200, 25);
            TspTxtEndereco.Text = "Endereço";
            TspTxtEndereco.Enter += TspTxtEndereco_Enter;
            TspTxtEndereco.Leave += TspTxtEndereco_Leave;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 25);
            // 
            // TspBtnAplicar
            // 
            TspBtnAplicar.DisplayStyle = ToolStripItemDisplayStyle.Text;
            TspBtnAplicar.Image = (Image)resources.GetObject("TspBtnAplicar.Image");
            TspBtnAplicar.ImageTransparentColor = Color.Magenta;
            TspBtnAplicar.Name = "TspBtnAplicar";
            TspBtnAplicar.Size = new Size(52, 22);
            TspBtnAplicar.Text = "Aplicar";
            TspBtnAplicar.Click += TspBtnAplicar_Click;
            // 
            // FormClientes
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(tableLayoutPanel1);
            Name = "FormClientes";
            Text = "FastBox - Clientes";
            Load += FormClientes_Load;
            ((System.ComponentModel.ISupportInitialize)DgvClientes).EndInit();
            PanelClientesBotoes.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            TspBusca.ResumeLayout(false);
            TspBusca.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvClientes;
        private Panel PanelClientesBotoes;
        private Button BtnExcluirCliente;
        private Button BtnAtualizarCliente;
        private Button BtnCadastrarCliente;
        private Button BtnPreviousPage;
        private Button BtnNextPage;
        private TableLayoutPanel tableLayoutPanel1;
        private Button BtnRefresh;
        private ToolStrip TspBusca;
        private ToolStripLabel TxtInfoTspBuscca;
        private ToolStripTextBox TspTxtNome;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox TspTxtNif;
        private ToolStripSeparator toolStripSeparator2;
        private ToolStripTextBox TspTxtTelemovel;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripTextBox TspTxtEmail;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripTextBox TspTxtDataInicial;
        private ToolStripLabel TstLblData;
        private ToolStripTextBox TspTxtDataFinal;
        private ToolStripSeparator toolStripSeparator5;
        private ToolStripTextBox TspTxtMatricula;
        private ToolStripSeparator toolStripSeparator6;
        private ToolStripTextBox TspTxtEndereco;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton TspBtnAplicar;
    }
}