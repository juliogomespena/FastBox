namespace FastBox.UI.Forms
{
    partial class FormConcluirOrdem
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
            PanelInfoVeiculo = new Panel();
            CmbMetodosDePagamentoConcluirOrdem = new ComboBox();
            LblEuroConcluirOrdem = new Label();
            TxtEuroConcluirOrdem = new TextBox();
            LblOrcamentosConcluirOrdem = new Label();
            DgvOrcamentosConcluirOrdem = new DataGridView();
            LblVeiculoConcluirOrdem = new Label();
            TxtVeiculoConcluirOrdem = new TextBox();
            LblClienteConcluirOrdem = new Label();
            TxtClienteConcluirOrdem = new TextBox();
            LblIdConcluirOrdem = new Label();
            TxtIdConcluirOrdem = new TextBox();
            LblInfoVeiculo = new Label();
            BtnReceberPagamento = new Button();
            PanelInfoVeiculo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvOrcamentosConcluirOrdem).BeginInit();
            SuspendLayout();
            // 
            // PanelInfoVeiculo
            // 
            PanelInfoVeiculo.BorderStyle = BorderStyle.Fixed3D;
            PanelInfoVeiculo.Controls.Add(CmbMetodosDePagamentoConcluirOrdem);
            PanelInfoVeiculo.Controls.Add(LblEuroConcluirOrdem);
            PanelInfoVeiculo.Controls.Add(TxtEuroConcluirOrdem);
            PanelInfoVeiculo.Controls.Add(LblOrcamentosConcluirOrdem);
            PanelInfoVeiculo.Controls.Add(DgvOrcamentosConcluirOrdem);
            PanelInfoVeiculo.Controls.Add(LblVeiculoConcluirOrdem);
            PanelInfoVeiculo.Controls.Add(TxtVeiculoConcluirOrdem);
            PanelInfoVeiculo.Controls.Add(LblClienteConcluirOrdem);
            PanelInfoVeiculo.Controls.Add(TxtClienteConcluirOrdem);
            PanelInfoVeiculo.Controls.Add(LblIdConcluirOrdem);
            PanelInfoVeiculo.Controls.Add(TxtIdConcluirOrdem);
            PanelInfoVeiculo.Location = new Point(4, 25);
            PanelInfoVeiculo.Name = "PanelInfoVeiculo";
            PanelInfoVeiculo.Size = new Size(780, 364);
            PanelInfoVeiculo.TabIndex = 10;
            // 
            // CmbMetodosDePagamentoConcluirOrdem
            // 
            CmbMetodosDePagamentoConcluirOrdem.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbMetodosDePagamentoConcluirOrdem.Font = new Font("Segoe UI Variable Display", 22F);
            CmbMetodosDePagamentoConcluirOrdem.FormattingEnabled = true;
            CmbMetodosDePagamentoConcluirOrdem.Location = new Point(375, 286);
            CmbMetodosDePagamentoConcluirOrdem.Name = "CmbMetodosDePagamentoConcluirOrdem";
            CmbMetodosDePagamentoConcluirOrdem.Size = new Size(347, 46);
            CmbMetodosDePagamentoConcluirOrdem.TabIndex = 21;
            // 
            // LblEuroConcluirOrdem
            // 
            LblEuroConcluirOrdem.AutoSize = true;
            LblEuroConcluirOrdem.Font = new Font("Segoe UI Variable Display", 22F);
            LblEuroConcluirOrdem.Location = new Point(53, 289);
            LblEuroConcluirOrdem.Name = "LblEuroConcluirOrdem";
            LblEuroConcluirOrdem.Size = new Size(41, 40);
            LblEuroConcluirOrdem.TabIndex = 20;
            LblEuroConcluirOrdem.Text = "€:";
            // 
            // TxtEuroConcluirOrdem
            // 
            TxtEuroConcluirOrdem.BackColor = SystemColors.Window;
            TxtEuroConcluirOrdem.Font = new Font("Segoe UI Variable Display", 22F);
            TxtEuroConcluirOrdem.ForeColor = Color.Gray;
            TxtEuroConcluirOrdem.Location = new Point(107, 286);
            TxtEuroConcluirOrdem.Name = "TxtEuroConcluirOrdem";
            TxtEuroConcluirOrdem.Size = new Size(225, 47);
            TxtEuroConcluirOrdem.TabIndex = 19;
            TxtEuroConcluirOrdem.Enter += TxtEuroConcluirOrdem_Enter;
            TxtEuroConcluirOrdem.KeyPress += TxtEuroConcluirOrdem_KeyPress;
            TxtEuroConcluirOrdem.Leave += TxtEuroConcluirOrdem_Leave;
            // 
            // LblOrcamentosConcluirOrdem
            // 
            LblOrcamentosConcluirOrdem.AutoSize = true;
            LblOrcamentosConcluirOrdem.Location = new Point(-1, 68);
            LblOrcamentosConcluirOrdem.Name = "LblOrcamentosConcluirOrdem";
            LblOrcamentosConcluirOrdem.Size = new Size(79, 17);
            LblOrcamentosConcluirOrdem.TabIndex = 16;
            LblOrcamentosConcluirOrdem.Text = "Orçamentos";
            // 
            // DgvOrcamentosConcluirOrdem
            // 
            DgvOrcamentosConcluirOrdem.AllowUserToAddRows = false;
            DgvOrcamentosConcluirOrdem.AllowUserToDeleteRows = false;
            DgvOrcamentosConcluirOrdem.AllowUserToResizeColumns = false;
            DgvOrcamentosConcluirOrdem.AllowUserToResizeRows = false;
            DgvOrcamentosConcluirOrdem.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvOrcamentosConcluirOrdem.Location = new Point(-1, 88);
            DgvOrcamentosConcluirOrdem.Name = "DgvOrcamentosConcluirOrdem";
            DgvOrcamentosConcluirOrdem.ReadOnly = true;
            DgvOrcamentosConcluirOrdem.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvOrcamentosConcluirOrdem.Size = new Size(776, 166);
            DgvOrcamentosConcluirOrdem.TabIndex = 18;
            // 
            // LblVeiculoConcluirOrdem
            // 
            LblVeiculoConcluirOrdem.AutoSize = true;
            LblVeiculoConcluirOrdem.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblVeiculoConcluirOrdem.Location = new Point(439, 24);
            LblVeiculoConcluirOrdem.Name = "LblVeiculoConcluirOrdem";
            LblVeiculoConcluirOrdem.Size = new Size(77, 26);
            LblVeiculoConcluirOrdem.TabIndex = 6;
            LblVeiculoConcluirOrdem.Text = "Veículo:";
            // 
            // TxtVeiculoConcluirOrdem
            // 
            TxtVeiculoConcluirOrdem.BackColor = SystemColors.Window;
            TxtVeiculoConcluirOrdem.Enabled = false;
            TxtVeiculoConcluirOrdem.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtVeiculoConcluirOrdem.Location = new Point(522, 21);
            TxtVeiculoConcluirOrdem.Name = "TxtVeiculoConcluirOrdem";
            TxtVeiculoConcluirOrdem.Size = new Size(244, 33);
            TxtVeiculoConcluirOrdem.TabIndex = 7;
            // 
            // LblClienteConcluirOrdem
            // 
            LblClienteConcluirOrdem.AutoSize = true;
            LblClienteConcluirOrdem.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblClienteConcluirOrdem.Location = new Point(127, 24);
            LblClienteConcluirOrdem.Name = "LblClienteConcluirOrdem";
            LblClienteConcluirOrdem.Size = new Size(75, 26);
            LblClienteConcluirOrdem.TabIndex = 4;
            LblClienteConcluirOrdem.Text = "Cliente:";
            // 
            // TxtClienteConcluirOrdem
            // 
            TxtClienteConcluirOrdem.BackColor = SystemColors.Window;
            TxtClienteConcluirOrdem.Enabled = false;
            TxtClienteConcluirOrdem.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtClienteConcluirOrdem.Location = new Point(208, 21);
            TxtClienteConcluirOrdem.Name = "TxtClienteConcluirOrdem";
            TxtClienteConcluirOrdem.Size = new Size(215, 33);
            TxtClienteConcluirOrdem.TabIndex = 5;
            // 
            // LblIdConcluirOrdem
            // 
            LblIdConcluirOrdem.AutoSize = true;
            LblIdConcluirOrdem.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblIdConcluirOrdem.Location = new Point(6, 24);
            LblIdConcluirOrdem.Name = "LblIdConcluirOrdem";
            LblIdConcluirOrdem.Size = new Size(32, 26);
            LblIdConcluirOrdem.TabIndex = 2;
            LblIdConcluirOrdem.Text = "Id:";
            // 
            // TxtIdConcluirOrdem
            // 
            TxtIdConcluirOrdem.BackColor = SystemColors.Window;
            TxtIdConcluirOrdem.Enabled = false;
            TxtIdConcluirOrdem.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtIdConcluirOrdem.Location = new Point(44, 21);
            TxtIdConcluirOrdem.Name = "TxtIdConcluirOrdem";
            TxtIdConcluirOrdem.Size = new Size(67, 33);
            TxtIdConcluirOrdem.TabIndex = 3;
            // 
            // LblInfoVeiculo
            // 
            LblInfoVeiculo.AutoSize = true;
            LblInfoVeiculo.Location = new Point(5, 5);
            LblInfoVeiculo.Name = "LblInfoVeiculo";
            LblInfoVeiculo.Size = new Size(162, 17);
            LblInfoVeiculo.TabIndex = 11;
            LblInfoVeiculo.Text = "Concluir ordem de serviço";
            // 
            // BtnReceberPagamento
            // 
            BtnReceberPagamento.BackColor = SystemColors.ControlLight;
            BtnReceberPagamento.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnReceberPagamento.Location = new Point(4, 395);
            BtnReceberPagamento.Name = "BtnReceberPagamento";
            BtnReceberPagamento.Size = new Size(778, 55);
            BtnReceberPagamento.TabIndex = 15;
            BtnReceberPagamento.Text = "Receber pagamento";
            BtnReceberPagamento.UseVisualStyleBackColor = false;
            BtnReceberPagamento.Click += BtnReceberPagamento_Click;
            // 
            // FormConcluirOrdem
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(784, 461);
            Controls.Add(BtnReceberPagamento);
            Controls.Add(LblInfoVeiculo);
            Controls.Add(PanelInfoVeiculo);
            MaximizeBox = false;
            MaximumSize = new Size(800, 500);
            MinimumSize = new Size(800, 500);
            Name = "FormConcluirOrdem";
            Text = "FastBox - Pagamento";
            Load += FormConcluirOrdem_Load;
            PanelInfoVeiculo.ResumeLayout(false);
            PanelInfoVeiculo.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvOrcamentosConcluirOrdem).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Panel PanelInfoVeiculo;
        private Label LblInfoVeiculo;
        private Button BtnReceberPagamento;
        private Label LblVeiculoConcluirOrdem;
        private TextBox TxtVeiculoConcluirOrdem;
        private Label LblClienteConcluirOrdem;
        private TextBox TxtClienteConcluirOrdem;
        private Label LblIdConcluirOrdem;
        private TextBox TxtIdConcluirOrdem;
        private Label LblOrcamentosConcluirOrdem;
        private DataGridView DgvOrcamentosConcluirOrdem;
        private Label LblEuroConcluirOrdem;
        private TextBox TxtEuroConcluirOrdem;
        private ComboBox CmbMetodosDePagamentoConcluirOrdem;
    }
}