namespace FastBox.UI.Forms
{
    partial class FormCadastrarFornecedor
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
            LblNome = new Label();
            TxtNome = new TextBox();
            LblTelemovel = new Label();
            TxtEmail = new TextBox();
            LblEmail = new Label();
            PanelInfoFornecedor = new Panel();
            TxtMskTelemovel = new MaskedTextBox();
            LblInfoFornecedor = new Label();
            PanelEnderecoFornecedor = new Panel();
            TxtMskCodigoPostal = new MaskedTextBox();
            LblCodigoPostal = new Label();
            LblPais = new Label();
            TxtPais = new TextBox();
            LblConcelho = new Label();
            CmbConcelho = new ComboBox();
            LblFreguesia = new Label();
            TxtFreguesia = new TextBox();
            LblComplemento = new Label();
            TxtComplemento = new TextBox();
            LblNumeroEndereco = new Label();
            TxtNumeroEndereco = new TextBox();
            LblLogradouro = new Label();
            TxtLogradouro = new TextBox();
            BtnCadastrarFornecedor = new Button();
            ChkCadastrarEndereco = new CheckBox();
            PanelInfoFornecedor.SuspendLayout();
            PanelEnderecoFornecedor.SuspendLayout();
            SuspendLayout();
            // 
            // LblNome
            // 
            LblNome.AutoSize = true;
            LblNome.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblNome.Location = new Point(9, 14);
            LblNome.Name = "LblNome";
            LblNome.Size = new Size(67, 26);
            LblNome.TabIndex = 0;
            LblNome.Text = "Nome:";
            // 
            // TxtNome
            // 
            TxtNome.BackColor = SystemColors.Window;
            TxtNome.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtNome.Location = new Point(79, 11);
            TxtNome.Name = "TxtNome";
            TxtNome.Size = new Size(690, 33);
            TxtNome.TabIndex = 1;
            // 
            // LblTelemovel
            // 
            LblTelemovel.AutoSize = true;
            LblTelemovel.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblTelemovel.Location = new Point(9, 66);
            LblTelemovel.Name = "LblTelemovel";
            LblTelemovel.Size = new Size(98, 26);
            LblTelemovel.TabIndex = 4;
            LblTelemovel.Text = "Telemóvel:";
            // 
            // TxtEmail
            // 
            TxtEmail.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtEmail.Location = new Point(330, 63);
            TxtEmail.Name = "TxtEmail";
            TxtEmail.Size = new Size(439, 33);
            TxtEmail.TabIndex = 4;
            // 
            // LblEmail
            // 
            LblEmail.AutoSize = true;
            LblEmail.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblEmail.Location = new Point(269, 66);
            LblEmail.Name = "LblEmail";
            LblEmail.Size = new Size(58, 26);
            LblEmail.TabIndex = 6;
            LblEmail.Text = "Email:";
            // 
            // PanelInfoFornecedor
            // 
            PanelInfoFornecedor.BorderStyle = BorderStyle.Fixed3D;
            PanelInfoFornecedor.Controls.Add(TxtMskTelemovel);
            PanelInfoFornecedor.Controls.Add(LblNome);
            PanelInfoFornecedor.Controls.Add(TxtNome);
            PanelInfoFornecedor.Controls.Add(TxtEmail);
            PanelInfoFornecedor.Controls.Add(LblEmail);
            PanelInfoFornecedor.Controls.Add(LblTelemovel);
            PanelInfoFornecedor.Location = new Point(4, 25);
            PanelInfoFornecedor.Name = "PanelInfoFornecedor";
            PanelInfoFornecedor.Size = new Size(780, 118);
            PanelInfoFornecedor.TabIndex = 10;
            // 
            // TxtMskTelemovel
            // 
            TxtMskTelemovel.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtMskTelemovel.Location = new Point(112, 63);
            TxtMskTelemovel.Mask = "+000 000 000 000";
            TxtMskTelemovel.Name = "TxtMskTelemovel";
            TxtMskTelemovel.Size = new Size(152, 33);
            TxtMskTelemovel.TabIndex = 3;
            // 
            // LblInfoFornecedor
            // 
            LblInfoFornecedor.AutoSize = true;
            LblInfoFornecedor.Location = new Point(5, 5);
            LblInfoFornecedor.Name = "LblInfoFornecedor";
            LblInfoFornecedor.Size = new Size(169, 17);
            LblInfoFornecedor.TabIndex = 11;
            LblInfoFornecedor.Text = "Informações do fornecedor";
            // 
            // PanelEnderecoFornecedor
            // 
            PanelEnderecoFornecedor.BorderStyle = BorderStyle.Fixed3D;
            PanelEnderecoFornecedor.Controls.Add(TxtMskCodigoPostal);
            PanelEnderecoFornecedor.Controls.Add(LblCodigoPostal);
            PanelEnderecoFornecedor.Controls.Add(LblPais);
            PanelEnderecoFornecedor.Controls.Add(TxtPais);
            PanelEnderecoFornecedor.Controls.Add(LblConcelho);
            PanelEnderecoFornecedor.Controls.Add(CmbConcelho);
            PanelEnderecoFornecedor.Controls.Add(LblFreguesia);
            PanelEnderecoFornecedor.Controls.Add(TxtFreguesia);
            PanelEnderecoFornecedor.Controls.Add(LblComplemento);
            PanelEnderecoFornecedor.Controls.Add(TxtComplemento);
            PanelEnderecoFornecedor.Controls.Add(LblNumeroEndereco);
            PanelEnderecoFornecedor.Controls.Add(TxtNumeroEndereco);
            PanelEnderecoFornecedor.Controls.Add(LblLogradouro);
            PanelEnderecoFornecedor.Controls.Add(TxtLogradouro);
            PanelEnderecoFornecedor.Enabled = false;
            PanelEnderecoFornecedor.Location = new Point(4, 170);
            PanelEnderecoFornecedor.Name = "PanelEnderecoFornecedor";
            PanelEnderecoFornecedor.Size = new Size(780, 164);
            PanelEnderecoFornecedor.TabIndex = 11;
            // 
            // TxtMskCodigoPostal
            // 
            TxtMskCodigoPostal.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtMskCodigoPostal.Location = new Point(625, 111);
            TxtMskCodigoPostal.Mask = "0000-000";
            TxtMskCodigoPostal.Name = "TxtMskCodigoPostal";
            TxtMskCodigoPostal.Size = new Size(90, 33);
            TxtMskCodigoPostal.TabIndex = 13;
            // 
            // LblCodigoPostal
            // 
            LblCodigoPostal.AutoSize = true;
            LblCodigoPostal.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblCodigoPostal.Location = new Point(488, 114);
            LblCodigoPostal.Name = "LblCodigoPostal";
            LblCodigoPostal.Size = new Size(132, 26);
            LblCodigoPostal.TabIndex = 12;
            LblCodigoPostal.Text = "Codigo postal:";
            // 
            // LblPais
            // 
            LblPais.AutoSize = true;
            LblPais.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblPais.Location = new Point(278, 114);
            LblPais.Name = "LblPais";
            LblPais.Size = new Size(47, 26);
            LblPais.TabIndex = 10;
            LblPais.Text = "País:";
            // 
            // TxtPais
            // 
            TxtPais.Enabled = false;
            TxtPais.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtPais.Location = new Point(328, 111);
            TxtPais.Name = "TxtPais";
            TxtPais.Size = new Size(157, 33);
            TxtPais.TabIndex = 11;
            TxtPais.Text = "Portugal";
            // 
            // LblConcelho
            // 
            LblConcelho.AutoSize = true;
            LblConcelho.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblConcelho.Location = new Point(7, 114);
            LblConcelho.Name = "LblConcelho";
            LblConcelho.Size = new Size(97, 26);
            LblConcelho.TabIndex = 9;
            LblConcelho.Text = "Concelho:";
            // 
            // CmbConcelho
            // 
            CmbConcelho.DropDownStyle = ComboBoxStyle.DropDownList;
            CmbConcelho.Font = new Font("Segoe UI Variable Display", 14.25F);
            CmbConcelho.FormattingEnabled = true;
            CmbConcelho.Location = new Point(107, 111);
            CmbConcelho.Name = "CmbConcelho";
            CmbConcelho.Size = new Size(168, 34);
            CmbConcelho.TabIndex = 8;
            // 
            // LblFreguesia
            // 
            LblFreguesia.AutoSize = true;
            LblFreguesia.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblFreguesia.Location = new Point(451, 64);
            LblFreguesia.Name = "LblFreguesia";
            LblFreguesia.Size = new Size(96, 26);
            LblFreguesia.TabIndex = 6;
            LblFreguesia.Text = "Freguesia:";
            // 
            // TxtFreguesia
            // 
            TxtFreguesia.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtFreguesia.Location = new Point(550, 61);
            TxtFreguesia.Name = "TxtFreguesia";
            TxtFreguesia.Size = new Size(217, 33);
            TxtFreguesia.TabIndex = 7;
            // 
            // LblComplemento
            // 
            LblComplemento.AutoSize = true;
            LblComplemento.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblComplemento.Location = new Point(165, 64);
            LblComplemento.Name = "LblComplemento";
            LblComplemento.Size = new Size(136, 26);
            LblComplemento.TabIndex = 4;
            LblComplemento.Text = "Complemento:";
            // 
            // TxtComplemento
            // 
            TxtComplemento.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtComplemento.Location = new Point(303, 61);
            TxtComplemento.Name = "TxtComplemento";
            TxtComplemento.Size = new Size(145, 33);
            TxtComplemento.TabIndex = 5;
            // 
            // LblNumeroEndereco
            // 
            LblNumeroEndereco.AutoSize = true;
            LblNumeroEndereco.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblNumeroEndereco.Location = new Point(7, 64);
            LblNumeroEndereco.Name = "LblNumeroEndereco";
            LblNumeroEndereco.Size = new Size(85, 26);
            LblNumeroEndereco.TabIndex = 2;
            LblNumeroEndereco.Text = "Numero:";
            // 
            // TxtNumeroEndereco
            // 
            TxtNumeroEndereco.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtNumeroEndereco.Location = new Point(94, 61);
            TxtNumeroEndereco.Name = "TxtNumeroEndereco";
            TxtNumeroEndereco.Size = new Size(68, 33);
            TxtNumeroEndereco.TabIndex = 3;
            // 
            // LblLogradouro
            // 
            LblLogradouro.AutoSize = true;
            LblLogradouro.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblLogradouro.Location = new Point(7, 14);
            LblLogradouro.Name = "LblLogradouro";
            LblLogradouro.Size = new Size(114, 26);
            LblLogradouro.TabIndex = 0;
            LblLogradouro.Text = "Logradouro:";
            // 
            // TxtLogradouro
            // 
            TxtLogradouro.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtLogradouro.Location = new Point(124, 11);
            TxtLogradouro.Name = "TxtLogradouro";
            TxtLogradouro.Size = new Size(643, 33);
            TxtLogradouro.TabIndex = 1;
            // 
            // BtnCadastrarFornecedor
            // 
            BtnCadastrarFornecedor.BackColor = SystemColors.ControlLight;
            BtnCadastrarFornecedor.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnCadastrarFornecedor.Location = new Point(4, 336);
            BtnCadastrarFornecedor.Name = "BtnCadastrarFornecedor";
            BtnCadastrarFornecedor.Size = new Size(778, 55);
            BtnCadastrarFornecedor.TabIndex = 15;
            BtnCadastrarFornecedor.Text = "Cadastrar";
            BtnCadastrarFornecedor.UseVisualStyleBackColor = false;
            BtnCadastrarFornecedor.Click += BtnCadastrarFornecedor_Click;
            // 
            // ChkCadastrarEndereco
            // 
            ChkCadastrarEndereco.Location = new Point(5, 144);
            ChkCadastrarEndereco.Name = "ChkCadastrarEndereco";
            ChkCadastrarEndereco.Size = new Size(151, 24);
            ChkCadastrarEndereco.TabIndex = 0;
            ChkCadastrarEndereco.Text = "Cadastrar endereço";
            ChkCadastrarEndereco.CheckedChanged += ChkCadastrarEndereco_CheckedChanged_1;
            // 
            // FormCadastrarFornecedor
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(784, 394);
            Controls.Add(ChkCadastrarEndereco);
            Controls.Add(BtnCadastrarFornecedor);
            Controls.Add(PanelEnderecoFornecedor);
            Controls.Add(LblInfoFornecedor);
            Controls.Add(PanelInfoFornecedor);
            MaximizeBox = false;
            MaximumSize = new Size(800, 434);
            MinimumSize = new Size(800, 433);
            Name = "FormCadastrarFornecedor";
            Text = "FastBox - Cadastro de fornecedores";
            Load += FormCadastrarFornecedor_Load;
            PanelInfoFornecedor.ResumeLayout(false);
            PanelInfoFornecedor.PerformLayout();
            PanelEnderecoFornecedor.ResumeLayout(false);
            PanelEnderecoFornecedor.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblNome;
        private TextBox TxtNome;
        private Label LblTelemovel;
        private TextBox TxtEmail;
        private Label LblEmail;
        private Panel PanelInfoFornecedor;
        private Label LblInfoFornecedor;
        private Panel PanelEnderecoFornecedor;
        private Label LblLogradouro;
        private TextBox TxtLogradouro;
        private Label LblNumeroEndereco;
        private TextBox TxtNumeroEndereco;
        private Label LblComplemento;
        private TextBox TxtComplemento;
        private Label LblFreguesia;
        private TextBox TxtFreguesia;
        private Label LblPais;
        private TextBox TxtPais;
        private Label LblConcelho;
        private ComboBox CmbConcelho;
        private Label LblCodigoPostal;
        private Button BtnCadastrarFornecedor;
        private MaskedTextBox TxtMskTelemovel;
        private MaskedTextBox TxtMskCodigoPostal;
        private CheckBox ChkCadastrarEndereco;
    }
}