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
            DgvOrdensDeServico = new DataGridView();
            PanelOrdensDeServicoBotoes = new Panel();
            BtnConcluirOrdem = new Button();
            BtnFinalizarServico = new Button();
            BtnRefresh = new Button();
            BtnNextPage = new Button();
            BtnPreviousPage = new Button();
            BtnExcluirOrdemDeServico = new Button();
            BtnAtualizarOrdemDeServico = new Button();
            BtnCadastrarOrdemDeServico = new Button();
            tableLayoutPanel1 = new TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)DgvOrdensDeServico).BeginInit();
            PanelOrdensDeServicoBotoes.SuspendLayout();
            tableLayoutPanel1.SuspendLayout();
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
            DgvOrdensDeServico.Size = new Size(1258, 600);
            DgvOrdensDeServico.TabIndex = 0;
            // 
            // PanelOrdensDeServicoBotoes
            // 
            PanelOrdensDeServicoBotoes.BackColor = SystemColors.ControlLight;
            PanelOrdensDeServicoBotoes.Controls.Add(BtnConcluirOrdem);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnFinalizarServico);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnRefresh);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnNextPage);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnPreviousPage);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnExcluirOrdemDeServico);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnAtualizarOrdemDeServico);
            PanelOrdensDeServicoBotoes.Controls.Add(BtnCadastrarOrdemDeServico);
            PanelOrdensDeServicoBotoes.Dock = DockStyle.Fill;
            PanelOrdensDeServicoBotoes.Location = new Point(3, 609);
            PanelOrdensDeServicoBotoes.Name = "PanelOrdensDeServicoBotoes";
            PanelOrdensDeServicoBotoes.Size = new Size(1258, 69);
            PanelOrdensDeServicoBotoes.TabIndex = 1;
            // 
            // BtnConcluirOrdem
            // 
            BtnConcluirOrdem.Anchor = AnchorStyles.Left;
            BtnConcluirOrdem.AutoEllipsis = true;
            BtnConcluirOrdem.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnConcluirOrdem.BackColor = SystemColors.ControlLight;
            BtnConcluirOrdem.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnConcluirOrdem.Location = new Point(627, 0);
            BtnConcluirOrdem.Name = "BtnConcluirOrdem";
            BtnConcluirOrdem.Size = new Size(203, 69);
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
            BtnFinalizarServico.Location = new Point(418, 0);
            BtnFinalizarServico.Name = "BtnFinalizarServico";
            BtnFinalizarServico.Size = new Size(203, 69);
            BtnFinalizarServico.TabIndex = 6;
            BtnFinalizarServico.Text = "Finalizar serviço";
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
            // BtnExcluirOrdemDeServico
            // 
            BtnExcluirOrdemDeServico.Anchor = AnchorStyles.Left;
            BtnExcluirOrdemDeServico.AutoEllipsis = true;
            BtnExcluirOrdemDeServico.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnExcluirOrdemDeServico.BackColor = SystemColors.ControlLight;
            BtnExcluirOrdemDeServico.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnExcluirOrdemDeServico.Location = new Point(836, 0);
            BtnExcluirOrdemDeServico.Name = "BtnExcluirOrdemDeServico";
            BtnExcluirOrdemDeServico.Size = new Size(203, 69);
            BtnExcluirOrdemDeServico.TabIndex = 2;
            BtnExcluirOrdemDeServico.Text = "Excluir";
            BtnExcluirOrdemDeServico.UseVisualStyleBackColor = false;
            BtnExcluirOrdemDeServico.Click += BtnExcluirOrdemDeServico_Click;
            // 
            // BtnAtualizarOrdemDeServico
            // 
            BtnAtualizarOrdemDeServico.Anchor = AnchorStyles.Left;
            BtnAtualizarOrdemDeServico.AutoEllipsis = true;
            BtnAtualizarOrdemDeServico.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnAtualizarOrdemDeServico.BackColor = SystemColors.ControlLight;
            BtnAtualizarOrdemDeServico.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnAtualizarOrdemDeServico.Location = new Point(209, 0);
            BtnAtualizarOrdemDeServico.Name = "BtnAtualizarOrdemDeServico";
            BtnAtualizarOrdemDeServico.Size = new Size(203, 69);
            BtnAtualizarOrdemDeServico.TabIndex = 1;
            BtnAtualizarOrdemDeServico.Text = "Atualizar";
            BtnAtualizarOrdemDeServico.UseVisualStyleBackColor = false;
            BtnAtualizarOrdemDeServico.Click += BtnAtualizarOrdemDeServico_Click;
            // 
            // BtnCadastrarOrdemDeServico
            // 
            BtnCadastrarOrdemDeServico.Anchor = AnchorStyles.Left;
            BtnCadastrarOrdemDeServico.AutoEllipsis = true;
            BtnCadastrarOrdemDeServico.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            BtnCadastrarOrdemDeServico.BackColor = SystemColors.ControlLight;
            BtnCadastrarOrdemDeServico.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnCadastrarOrdemDeServico.Location = new Point(0, 0);
            BtnCadastrarOrdemDeServico.Name = "BtnCadastrarOrdemDeServico";
            BtnCadastrarOrdemDeServico.Size = new Size(203, 69);
            BtnCadastrarOrdemDeServico.TabIndex = 0;
            BtnCadastrarOrdemDeServico.Text = "Cadastrar";
            BtnCadastrarOrdemDeServico.UseVisualStyleBackColor = false;
            BtnCadastrarOrdemDeServico.Click += BtnCadastrarOrdemDeServico_Click;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.BackColor = SystemColors.ControlLight;
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.Controls.Add(DgvOrdensDeServico, 0, 0);
            tableLayoutPanel1.Controls.Add(PanelOrdensDeServicoBotoes, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 0);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 2;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Absolute, 75F));
            tableLayoutPanel1.Size = new Size(1264, 681);
            tableLayoutPanel1.TabIndex = 5;
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
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DgvOrdensDeServico;
        private Panel PanelOrdensDeServicoBotoes;
        private Button BtnExcluirOrdemDeServico;
        private Button BtnAtualizarOrdemDeServico;
        private Button BtnCadastrarOrdemDeServico;
        private Button BtnPreviousPage;
        private Button BtnNextPage;
        private TableLayoutPanel tableLayoutPanel1;
        private Button BtnRefresh;
        private Button BtnFinalizarServico;
        private Button BtnConcluirOrdem;
    }
}
