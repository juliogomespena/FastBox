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
            BtnNextPage = new Button();
            BtnPreviousPage = new Button();
            BtnExcluirCliente = new Button();
            BtnAtualizarInformacoes = new Button();
            BtnCadastrarCliente = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)DgvClientes).BeginInit();
            PanelClientesBotoes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // DgvClientes
            // 
            DgvClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvClientes.Dock = DockStyle.Fill;
            DgvClientes.Location = new Point(3, 3);
            DgvClientes.Margin = new Padding(3, 3, 3, 10);
            DgvClientes.Name = "DgvClientes";
            DgvClientes.Size = new Size(1258, 593);
            DgvClientes.TabIndex = 0;
            // 
            // PanelClientesBotoes
            // 
            PanelClientesBotoes.BackColor = SystemColors.ControlLight;
            PanelClientesBotoes.Controls.Add(BtnNextPage);
            PanelClientesBotoes.Controls.Add(BtnPreviousPage);
            PanelClientesBotoes.Controls.Add(BtnExcluirCliente);
            PanelClientesBotoes.Controls.Add(BtnAtualizarInformacoes);
            PanelClientesBotoes.Controls.Add(BtnCadastrarCliente);
            PanelClientesBotoes.Dock = DockStyle.Fill;
            PanelClientesBotoes.Location = new Point(3, 609);
            PanelClientesBotoes.Name = "PanelClientesBotoes";
            PanelClientesBotoes.Size = new Size(1258, 69);
            PanelClientesBotoes.TabIndex = 1;
            // 
            // BtnNextPage
            // 
            BtnNextPage.Anchor = AnchorStyles.Right;
            BtnNextPage.AutoEllipsis = true;
            BtnNextPage.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnNextPage.BackColor = SystemColors.ControlLight;
            BtnNextPage.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold);
            BtnNextPage.Location = new Point(1055, -14);
            BtnNextPage.Name = "BtnNextPage";
            BtnNextPage.Size = new Size(203, 100);
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
            BtnPreviousPage.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold);
            BtnPreviousPage.Location = new Point(852, -14);
            BtnPreviousPage.Name = "BtnPreviousPage";
            BtnPreviousPage.Size = new Size(203, 100);
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
            BtnExcluirCliente.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold);
            BtnExcluirCliente.Location = new Point(406, -17);
            BtnExcluirCliente.Name = "BtnExcluirCliente";
            BtnExcluirCliente.Size = new Size(203, 103);
            BtnExcluirCliente.TabIndex = 2;
            BtnExcluirCliente.Text = "Excluir cliente";
            BtnExcluirCliente.UseVisualStyleBackColor = false;
            // 
            // BtnAtualizarInformacoes
            // 
            BtnAtualizarInformacoes.Anchor = AnchorStyles.Left;
            BtnAtualizarInformacoes.AutoEllipsis = true;
            BtnAtualizarInformacoes.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnAtualizarInformacoes.BackColor = SystemColors.ControlLight;
            BtnAtualizarInformacoes.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold);
            BtnAtualizarInformacoes.Location = new Point(203, -17);
            BtnAtualizarInformacoes.Name = "BtnAtualizarInformacoes";
            BtnAtualizarInformacoes.Size = new Size(203, 103);
            BtnAtualizarInformacoes.TabIndex = 1;
            BtnAtualizarInformacoes.Text = "Atualizar informações";
            BtnAtualizarInformacoes.UseVisualStyleBackColor = false;
            // 
            // BtnCadastrarCliente
            // 
            BtnCadastrarCliente.Anchor = AnchorStyles.Left;
            BtnCadastrarCliente.AutoEllipsis = true;
            BtnCadastrarCliente.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnCadastrarCliente.BackColor = SystemColors.ControlLight;
            BtnCadastrarCliente.Font = new Font("Segoe UI Variable Display Semib", 18F, FontStyle.Bold);
            BtnCadastrarCliente.Location = new Point(0, -17);
            BtnCadastrarCliente.Name = "BtnCadastrarCliente";
            BtnCadastrarCliente.Size = new Size(203, 103);
            BtnCadastrarCliente.TabIndex = 0;
            BtnCadastrarCliente.Text = "Cadastrar cliente";
            BtnCadastrarCliente.UseVisualStyleBackColor = false;
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
            Text = "FormClientes";
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
        private Button BtnAtualizarInformacoes;
        private Button BtnCadastrarCliente;
        private Button BtnPreviousPage;
        private Button BtnNextPage;
        private TableLayoutPanel tableLayoutPanel1;
    }
}