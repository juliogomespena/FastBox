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
            DgvVeiculos = new DataGridView();
            PanelVeiculosBotoes = new Panel();
            BtnRefresh = new Button();
            BtnNextPage = new Button();
            BtnPreviousPage = new Button();
            BtnExcluirVeiculo = new Button();
            BtnAtualizarVeiculo = new Button();
            BtnCadastrarVeiculo = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)DgvVeiculos).BeginInit();
            PanelVeiculosBotoes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
            SuspendLayout();
            // 
            // DgvVeiculos
            // 
            DgvVeiculos.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvVeiculos.Dock = DockStyle.Fill;
            DgvVeiculos.Location = new Point(3, 3);
            DgvVeiculos.Name = "DgvVeiculos";
            DgvVeiculos.ReadOnly = true;
            DgvVeiculos.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvVeiculos.Size = new Size(1258, 600);
            DgvVeiculos.TabIndex = 0;
            DgvVeiculos.CellToolTipTextNeeded += DgvVeiculos_CellToolTipTextNeeded;
            // 
            // PanelVeiculosBotoes
            // 
            PanelVeiculosBotoes.BackColor = SystemColors.ControlLight;
            PanelVeiculosBotoes.Controls.Add(BtnRefresh);
            PanelVeiculosBotoes.Controls.Add(BtnNextPage);
            PanelVeiculosBotoes.Controls.Add(BtnPreviousPage);
            PanelVeiculosBotoes.Controls.Add(BtnExcluirVeiculo);
            PanelVeiculosBotoes.Controls.Add(BtnAtualizarVeiculo);
            PanelVeiculosBotoes.Controls.Add(BtnCadastrarVeiculo);
            PanelVeiculosBotoes.Dock = DockStyle.Fill;
            PanelVeiculosBotoes.Location = new Point(3, 609);
            PanelVeiculosBotoes.Name = "PanelVeiculosBotoes";
            PanelVeiculosBotoes.Size = new Size(1258, 69);
            PanelVeiculosBotoes.TabIndex = 1;
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
            // BtnExcluirVeiculo
            // 
            BtnExcluirVeiculo.Anchor = AnchorStyles.Left;
            BtnExcluirVeiculo.AutoEllipsis = true;
            BtnExcluirVeiculo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnExcluirVeiculo.BackColor = SystemColors.ControlLight;
            BtnExcluirVeiculo.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnExcluirVeiculo.Location = new Point(404, 0);
            BtnExcluirVeiculo.Name = "BtnExcluirVeiculo";
            BtnExcluirVeiculo.Size = new Size(203, 69);
            BtnExcluirVeiculo.TabIndex = 2;
            BtnExcluirVeiculo.Text = "Excluir";
            BtnExcluirVeiculo.UseVisualStyleBackColor = false;
            BtnExcluirVeiculo.Click += BtnExcluirVeiculo_Click;
            // 
            // BtnAtualizarVeiculo
            // 
            BtnAtualizarVeiculo.Anchor = AnchorStyles.Left;
            BtnAtualizarVeiculo.AutoEllipsis = true;
            BtnAtualizarVeiculo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnAtualizarVeiculo.BackColor = SystemColors.ControlLight;
            BtnAtualizarVeiculo.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnAtualizarVeiculo.Location = new Point(202, 0);
            BtnAtualizarVeiculo.Name = "BtnAtualizarVeiculo";
            BtnAtualizarVeiculo.Size = new Size(203, 69);
            BtnAtualizarVeiculo.TabIndex = 1;
            BtnAtualizarVeiculo.Text = "Atualizar";
            BtnAtualizarVeiculo.UseVisualStyleBackColor = false;
            BtnAtualizarVeiculo.Click += BtnAtualizarVeiculo_Click;
            // 
            // BtnCadastrarVeiculo
            // 
            BtnCadastrarVeiculo.Anchor = AnchorStyles.Left;
            BtnCadastrarVeiculo.AutoEllipsis = true;
            BtnCadastrarVeiculo.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnCadastrarVeiculo.BackColor = SystemColors.ControlLight;
            BtnCadastrarVeiculo.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnCadastrarVeiculo.Location = new Point(0, 0);
            BtnCadastrarVeiculo.Name = "BtnCadastrarVeiculo";
            BtnCadastrarVeiculo.Size = new Size(203, 69);
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
            tableLayoutPanel1.Controls.Add(DgvVeiculos, 0, 0);
            tableLayoutPanel1.Controls.Add(PanelVeiculosBotoes, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tableLayoutPanel1.Size = new Size(1264, 681);
            tableLayoutPanel1.TabIndex = 5;
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
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvVeiculos;
        private Panel PanelVeiculosBotoes;
        private Button BtnExcluirVeiculo;
        private Button BtnAtualizarVeiculo;
        private Button BtnCadastrarVeiculo;
        private Button BtnPreviousPage;
        private Button BtnNextPage;
        private TableLayoutPanel tableLayoutPanel1;
        private Button BtnRefresh;
    }
}