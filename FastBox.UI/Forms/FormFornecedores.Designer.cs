namespace FastBox.UI.Forms
{
    partial class FormFornecedores
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormFornecedores));
            DgvFornecedores = new DataGridView();
            PanelFornecedoresBotoes = new Panel();
            BtnRefresh = new Button();
            BtnNextPage = new Button();
            BtnPreviousPage = new Button();
            BtnExcluirFornecedor = new Button();
            BtnAbrirFornecedor = new Button();
            BtnCadastrarFornecedor = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            TspBusca = new ToolStrip();
            TxtInfoTspBuscca = new ToolStripLabel();
            TspTxtNome = new ToolStripTextBox();
            toolStripSeparator1 = new ToolStripSeparator();
            TspTxtTelemovel = new ToolStripTextBox();
            toolStripSeparator3 = new ToolStripSeparator();
            TspTxtEmail = new ToolStripTextBox();
            toolStripSeparator4 = new ToolStripSeparator();
            TspTxtPeca = new ToolStripTextBox();
            toolStripSeparator6 = new ToolStripSeparator();
            TspTxtEndereco = new ToolStripTextBox();
            toolStripSeparator7 = new ToolStripSeparator();
            TspBtnAplicar = new ToolStripButton();
            ((System.ComponentModel.ISupportInitialize)DgvFornecedores).BeginInit();
            PanelFornecedoresBotoes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            TspBusca.SuspendLayout();
            SuspendLayout();
            // 
            // DgvFornecedores
            // 
            DgvFornecedores.AllowUserToResizeColumns = false;
            DgvFornecedores.AllowUserToResizeRows = false;
            DgvFornecedores.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvFornecedores.Dock = DockStyle.Fill;
            DgvFornecedores.Location = new Point(3, 3);
            DgvFornecedores.Name = "DgvFornecedores";
            DgvFornecedores.ReadOnly = true;
            DgvFornecedores.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvFornecedores.Size = new Size(1258, 564);
            DgvFornecedores.TabIndex = 0;
            DgvFornecedores.CellToolTipTextNeeded += DgvFornecedores_CellToolTipTextNeeded;
            // 
            // PanelFornecedoresBotoes
            // 
            PanelFornecedoresBotoes.BackColor = SystemColors.ControlLight;
            PanelFornecedoresBotoes.Controls.Add(BtnRefresh);
            PanelFornecedoresBotoes.Controls.Add(BtnNextPage);
            PanelFornecedoresBotoes.Controls.Add(BtnPreviousPage);
            PanelFornecedoresBotoes.Controls.Add(BtnExcluirFornecedor);
            PanelFornecedoresBotoes.Controls.Add(BtnAbrirFornecedor);
            PanelFornecedoresBotoes.Controls.Add(BtnCadastrarFornecedor);
            PanelFornecedoresBotoes.Dock = DockStyle.Fill;
            PanelFornecedoresBotoes.Location = new Point(3, 614);
            PanelFornecedoresBotoes.Name = "PanelFornecedoresBotoes";
            PanelFornecedoresBotoes.Size = new Size(1258, 64);
            PanelFornecedoresBotoes.TabIndex = 1;
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
            // BtnExcluirFornecedor
            // 
            BtnExcluirFornecedor.Anchor = AnchorStyles.Left;
            BtnExcluirFornecedor.AutoEllipsis = true;
            BtnExcluirFornecedor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnExcluirFornecedor.BackColor = SystemColors.ControlLight;
            BtnExcluirFornecedor.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnExcluirFornecedor.Location = new Point(427, 6);
            BtnExcluirFornecedor.Name = "BtnExcluirFornecedor";
            BtnExcluirFornecedor.Size = new Size(203, 55);
            BtnExcluirFornecedor.TabIndex = 2;
            BtnExcluirFornecedor.Text = "Excluir";
            BtnExcluirFornecedor.UseVisualStyleBackColor = false;
            BtnExcluirFornecedor.Click += BtnExcluirFornecedor_Click;
            // 
            // BtnAbrirFornecedor
            // 
            BtnAbrirFornecedor.Anchor = AnchorStyles.Left;
            BtnAbrirFornecedor.AutoEllipsis = true;
            BtnAbrirFornecedor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnAbrirFornecedor.BackColor = SystemColors.ControlLight;
            BtnAbrirFornecedor.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnAbrirFornecedor.Location = new Point(218, 6);
            BtnAbrirFornecedor.Name = "BtnAbrirFornecedor";
            BtnAbrirFornecedor.Size = new Size(203, 55);
            BtnAbrirFornecedor.TabIndex = 1;
            BtnAbrirFornecedor.Text = "Abrir";
            BtnAbrirFornecedor.UseVisualStyleBackColor = false;
            BtnAbrirFornecedor.Click += BtnAtualizarFornecedor_Click;
            // 
            // BtnCadastrarFornecedor
            // 
            BtnCadastrarFornecedor.Anchor = AnchorStyles.Left;
            BtnCadastrarFornecedor.AutoEllipsis = true;
            BtnCadastrarFornecedor.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnCadastrarFornecedor.BackColor = SystemColors.ControlLight;
            BtnCadastrarFornecedor.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnCadastrarFornecedor.Location = new Point(9, 6);
            BtnCadastrarFornecedor.Name = "BtnCadastrarFornecedor";
            BtnCadastrarFornecedor.Size = new Size(203, 55);
            BtnCadastrarFornecedor.TabIndex = 0;
            BtnCadastrarFornecedor.Text = "Cadastrar";
            BtnCadastrarFornecedor.UseVisualStyleBackColor = false;
            BtnCadastrarFornecedor.Click += BtnCadastrarFornecedor_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlLight;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(TspBusca, 0, 1);
            tableLayoutPanel1.Controls.Add(DgvFornecedores, 0, 0);
            tableLayoutPanel1.Controls.Add(PanelFornecedoresBotoes, 0, 2);
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
            TspBusca.Items.AddRange(new ToolStripItem[] { TxtInfoTspBuscca, TspTxtNome, toolStripSeparator1, TspTxtTelemovel, toolStripSeparator3, TspTxtEmail, toolStripSeparator4, TspTxtPeca, toolStripSeparator6, TspTxtEndereco, toolStripSeparator7, TspBtnAplicar });
            TspBusca.Location = new Point(0, 570);
            TspBusca.Name = "TspBusca";
            TspBusca.Size = new Size(1264, 41);
            TspBusca.TabIndex = 2;
            TspBusca.Text = "toolStrip1";
            // 
            // TxtInfoTspBuscca
            // 
            TxtInfoTspBuscca.Name = "TxtInfoTspBuscca";
            TxtInfoTspBuscca.Size = new Size(53, 38);
            TxtInfoTspBuscca.Text = "Buscar: ";
            // 
            // TspTxtNome
            // 
            TspTxtNome.ForeColor = Color.Gray;
            TspTxtNome.Name = "TspTxtNome";
            TspTxtNome.Size = new Size(150, 41);
            TspTxtNome.Text = "Nome";
            TspTxtNome.ToolTipText = "Nome";
            TspTxtNome.Enter += TspTxtNome_Enter;
            TspTxtNome.Leave += TspTxtNome_Leave;
            // 
            // toolStripSeparator1
            // 
            toolStripSeparator1.Name = "toolStripSeparator1";
            toolStripSeparator1.Size = new Size(6, 41);
            // 
            // TspTxtTelemovel
            // 
            TspTxtTelemovel.ForeColor = Color.Gray;
            TspTxtTelemovel.Name = "TspTxtTelemovel";
            TspTxtTelemovel.Size = new Size(100, 41);
            TspTxtTelemovel.Text = "Telemóvel";
            TspTxtTelemovel.Enter += TspTxtTelemovel_Enter;
            TspTxtTelemovel.Leave += TspTxtTelemovel_Leave;
            // 
            // toolStripSeparator3
            // 
            toolStripSeparator3.Name = "toolStripSeparator3";
            toolStripSeparator3.Size = new Size(6, 41);
            // 
            // TspTxtEmail
            // 
            TspTxtEmail.ForeColor = Color.Gray;
            TspTxtEmail.Name = "TspTxtEmail";
            TspTxtEmail.Size = new Size(180, 41);
            TspTxtEmail.Text = "Email";
            TspTxtEmail.Enter += TspTxtEmail_Enter;
            TspTxtEmail.Leave += TspTxtEmail_Leave;
            // 
            // toolStripSeparator4
            // 
            toolStripSeparator4.Name = "toolStripSeparator4";
            toolStripSeparator4.Size = new Size(6, 41);
            // 
            // TspTxtPeca
            // 
            TspTxtPeca.ForeColor = Color.Gray;
            TspTxtPeca.Name = "TspTxtPeca";
            TspTxtPeca.Size = new Size(180, 41);
            TspTxtPeca.Text = "Peça";
            // 
            // toolStripSeparator6
            // 
            toolStripSeparator6.Name = "toolStripSeparator6";
            toolStripSeparator6.Size = new Size(6, 41);
            // 
            // TspTxtEndereco
            // 
            TspTxtEndereco.ForeColor = Color.Gray;
            TspTxtEndereco.Name = "TspTxtEndereco";
            TspTxtEndereco.Size = new Size(200, 41);
            TspTxtEndereco.Text = "Endereço";
            TspTxtEndereco.Enter += TspTxtEndereco_Enter;
            TspTxtEndereco.Leave += TspTxtEndereco_Leave;
            // 
            // toolStripSeparator7
            // 
            toolStripSeparator7.Name = "toolStripSeparator7";
            toolStripSeparator7.Size = new Size(6, 41);
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
            // FormFornecedores
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1264, 681);
            Controls.Add(tableLayoutPanel1);
            Name = "FormFornecedores";
            Text = "FastBox - Fornecedores";
            Load += FormFornecedores_Load;
            ((System.ComponentModel.ISupportInitialize)DgvFornecedores).EndInit();
            PanelFornecedoresBotoes.ResumeLayout(false);
            tableLayoutPanel1.ResumeLayout(false);
            tableLayoutPanel1.PerformLayout();
            TspBusca.ResumeLayout(false);
            TspBusca.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvFornecedores;
        private Panel PanelFornecedoresBotoes;
        private Button BtnExcluirFornecedor;
        private Button BtnAbrirFornecedor;
        private Button BtnCadastrarFornecedor;
        private Button BtnPreviousPage;
        private Button BtnNextPage;
        private TableLayoutPanel tableLayoutPanel1;
        private Button BtnRefresh;
        private ToolStrip TspBusca;
        private ToolStripLabel TxtInfoTspBuscca;
        private ToolStripTextBox TspTxtNome;
        private ToolStripSeparator toolStripSeparator1;
        private ToolStripTextBox TspTxtTelemovel;
        private ToolStripSeparator toolStripSeparator3;
        private ToolStripTextBox TspTxtEmail;
        private ToolStripSeparator toolStripSeparator4;
        private ToolStripTextBox TspTxtEndereco;
        private ToolStripSeparator toolStripSeparator7;
        private ToolStripButton TspBtnAplicar;
        private ToolStripTextBox TspTxtPeca;
        private ToolStripSeparator toolStripSeparator6;
    }
}