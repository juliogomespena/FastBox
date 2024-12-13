namespace FastBox.UI.Forms
{
    partial class FormCadastrarOrdem
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
            LblOrdemCliente = new Label();
            PanelInfoOrdem = new Panel();
            LstSugestoesClientes = new ListBox();
            CmbVeiculos = new ComboBox();
            LblOrdemVeiculo = new Label();
            TxtClienteOrdem = new TextBox();
            DgvOrdensClientes = new DataGridView();
            LblInfoOrdem = new Label();
            BtnGerarOrdem = new Button();
            PanelInfoOrdem.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DgvOrdensClientes).BeginInit();
            SuspendLayout();
            // 
            // LblOrdemCliente
            // 
            LblOrdemCliente.AutoSize = true;
            LblOrdemCliente.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblOrdemCliente.Location = new Point(9, 14);
            LblOrdemCliente.Name = "LblOrdemCliente";
            LblOrdemCliente.Size = new Size(75, 26);
            LblOrdemCliente.TabIndex = 0;
            LblOrdemCliente.Text = "Cliente:";
            // 
            // PanelInfoOrdem
            // 
            PanelInfoOrdem.BorderStyle = BorderStyle.Fixed3D;
            PanelInfoOrdem.Controls.Add(LstSugestoesClientes);
            PanelInfoOrdem.Controls.Add(CmbVeiculos);
            PanelInfoOrdem.Controls.Add(LblOrdemVeiculo);
            PanelInfoOrdem.Controls.Add(TxtClienteOrdem);
            PanelInfoOrdem.Controls.Add(DgvOrdensClientes);
            PanelInfoOrdem.Controls.Add(LblOrdemCliente);
            PanelInfoOrdem.Location = new Point(4, 25);
            PanelInfoOrdem.Name = "PanelInfoOrdem";
            PanelInfoOrdem.Size = new Size(780, 364);
            PanelInfoOrdem.TabIndex = 10;
            // 
            // LstSugestoesClientes
            // 
            LstSugestoesClientes.FormattingEnabled = true;
            LstSugestoesClientes.IntegralHeight = false;
            LstSugestoesClientes.ItemHeight = 17;
            LstSugestoesClientes.Location = new Point(89, 44);
            LstSugestoesClientes.Name = "LstSugestoesClientes";
            LstSugestoesClientes.Size = new Size(208, 38);
            LstSugestoesClientes.TabIndex = 22;
            LstSugestoesClientes.Visible = false;
            LstSugestoesClientes.Click += LstSugestoesClientes_Click;
            LstSugestoesClientes.KeyDown += LstSugestoesClientes_KeyDown;
            // 
            // CmbVeiculos
            // 
            CmbVeiculos.AutoCompleteMode = AutoCompleteMode.Suggest;
            CmbVeiculos.AutoCompleteSource = AutoCompleteSource.ListItems;
            CmbVeiculos.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbVeiculos.Font = new Font("Segoe UI Variable Display", 14.25F);
            CmbVeiculos.FormattingEnabled = true;
            CmbVeiculos.Location = new Point(384, 11);
            CmbVeiculos.Name = "CmbVeiculos";
            CmbVeiculos.Size = new Size(158, 34);
            CmbVeiculos.TabIndex = 21;
            CmbVeiculos.SelectedIndexChanged += CmbVeiculos_SelectedIndexChanged;
            // 
            // LblOrdemVeiculo
            // 
            LblOrdemVeiculo.AutoSize = true;
            LblOrdemVeiculo.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblOrdemVeiculo.Location = new Point(303, 14);
            LblOrdemVeiculo.Name = "LblOrdemVeiculo";
            LblOrdemVeiculo.Size = new Size(77, 26);
            LblOrdemVeiculo.TabIndex = 20;
            LblOrdemVeiculo.Text = "Veículo:";
            // 
            // TxtClienteOrdem
            // 
            TxtClienteOrdem.BackColor = SystemColors.Window;
            TxtClienteOrdem.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtClienteOrdem.Location = new Point(89, 11);
            TxtClienteOrdem.Name = "TxtClienteOrdem";
            TxtClienteOrdem.Size = new Size(208, 33);
            TxtClienteOrdem.TabIndex = 18;
            TxtClienteOrdem.TextChanged += TxtClienteOrdem_TextChanged;
            // 
            // DgvOrdensClientes
            // 
            DgvOrdensClientes.AllowUserToAddRows = false;
            DgvOrdensClientes.AllowUserToDeleteRows = false;
            DgvOrdensClientes.AllowUserToResizeColumns = false;
            DgvOrdensClientes.AllowUserToResizeRows = false;
            DgvOrdensClientes.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DgvOrdensClientes.Dock = DockStyle.Bottom;
            DgvOrdensClientes.Location = new Point(0, 163);
            DgvOrdensClientes.Name = "DgvOrdensClientes";
            DgvOrdensClientes.ReadOnly = true;
            DgvOrdensClientes.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DgvOrdensClientes.Size = new Size(776, 197);
            DgvOrdensClientes.TabIndex = 17;
            // 
            // LblInfoOrdem
            // 
            LblInfoOrdem.AutoSize = true;
            LblInfoOrdem.Location = new Point(5, 5);
            LblInfoOrdem.Name = "LblInfoOrdem";
            LblInfoOrdem.Size = new Size(142, 17);
            LblInfoOrdem.TabIndex = 11;
            LblInfoOrdem.Text = "Informações da ordem";
            // 
            // BtnGerarOrdem
            // 
            BtnGerarOrdem.BackColor = SystemColors.ControlLight;
            BtnGerarOrdem.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnGerarOrdem.Location = new Point(4, 395);
            BtnGerarOrdem.Name = "BtnGerarOrdem";
            BtnGerarOrdem.Size = new Size(778, 55);
            BtnGerarOrdem.TabIndex = 15;
            BtnGerarOrdem.Text = "Gerar ordem de serviço";
            BtnGerarOrdem.UseVisualStyleBackColor = false;
            BtnGerarOrdem.Click += BtnGerarOrdem_Click;
            // 
            // FormCadastrarOrdem
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(784, 461);
            Controls.Add(BtnGerarOrdem);
            Controls.Add(LblInfoOrdem);
            Controls.Add(PanelInfoOrdem);
            MaximizeBox = false;
            MaximumSize = new Size(800, 500);
            MinimumSize = new Size(800, 500);
            Name = "FormCadastrarOrdem";
            Text = "FastBox - Nova ordem de serviço";
            PanelInfoOrdem.ResumeLayout(false);
            PanelInfoOrdem.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DgvOrdensClientes).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblOrdemCliente;
        private TextBox TxtModelo;
        private Label LblModelo;
        private Label LblAno;
        private Label LblObservacoes;
        private Label LblMatricula;
        private Panel PanelInfoOrdem;
        private Label LblInfoOrdem;
        private Button BtnGerarOrdem;
        private MaskedTextBox TxtMskAno;
        private MaskedTextBox TxtMskMatricula;
        private Label LblInfoMatricula;
        private RichTextBox RTxtObservacoes;
        private Button BtnNovoCliente;
        private Label LblCliente;
        private TextBox TxtCliente;
        private DataGridView DgvOrdensClientes;
        private TextBox TxtClienteOrdem;
        private ComboBox CmbVeiculos;
        private Label LblOrdemVeiculo;
        private ListBox LstSugestoesClientes;
    }
}