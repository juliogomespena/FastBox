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
            DgvClientes = new DataGridView();
            PanelClientesBotoes = new Panel();
            BtnRefresh = new Button();
            BtnNextPage = new Button();
            BtnPreviousPage = new Button();
            BtnExcluirCliente = new Button();
            BtnAtualizarCliente = new Button();
            BtnCadastrarCliente = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)DgvClientes).BeginInit();
            PanelClientesBotoes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            DgvClientes.Size = new Size(1258, 600);
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
            PanelClientesBotoes.Location = new Point(3, 609);
            PanelClientesBotoes.Name = "PanelClientesBotoes";
            PanelClientesBotoes.Size = new Size(1258, 69);
            PanelClientesBotoes.TabIndex = 1;
            // 
            // BtnRefresh
            // 
            BtnRefresh.Anchor = AnchorStyles.Right;
            BtnRefresh.AutoEllipsis = true;
            BtnRefresh.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnRefresh.BackColor = SystemColors.ControlLight;
            BtnRefresh.Font = new Font("Segoe UI Variable Display Semib", 26F, FontStyle.Bold);
            BtnRefresh.Location = new Point(1052, 0);
            BtnRefresh.Name = "BtnRefresh";
            BtnRefresh.Size = new Size(72, 69);
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
            BtnNextPage.Location = new Point(1189, 0);
            BtnNextPage.Name = "BtnNextPage";
            BtnNextPage.Size = new Size(69, 69);
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
            BtnPreviousPage.Location = new Point(1122, 0);
            BtnPreviousPage.Name = "BtnPreviousPage";
            BtnPreviousPage.Size = new Size(69, 69);
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
            BtnExcluirCliente.Location = new Point(404, 0);
            BtnExcluirCliente.Name = "BtnExcluirCliente";
            BtnExcluirCliente.Size = new Size(203, 69);
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
            BtnAtualizarCliente.Location = new Point(202, 0);
            BtnAtualizarCliente.Name = "BtnAtualizarCliente";
            BtnAtualizarCliente.Size = new Size(203, 69);
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
            BtnCadastrarCliente.Location = new Point(0, 0);
            BtnCadastrarCliente.Name = "BtnCadastrarCliente";
            BtnCadastrarCliente.Size = new Size(203, 69);
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
            tableLayoutPanel1.Controls.Add(DgvClientes, 0, 0);
            tableLayoutPanel1.Controls.Add(PanelClientesBotoes, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tableLayoutPanel1.Size = new Size(1264, 681);
            tableLayoutPanel1.TabIndex = 5;
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
    }
}