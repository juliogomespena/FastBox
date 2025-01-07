namespace FastBox.UI.Forms
{
    partial class FormCadastrarCliente
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
            TxtSobrenome = new TextBox();
            LblSobrenome = new Label();
            LblTelemovel = new Label();
            TxtEmail = new TextBox();
            LblEmail = new Label();
            LblNif = new Label();
            PanelInfoCliente = new Panel();
            LblInfoNif = new Label();
            TxtMskNif = new MaskedTextBox();
            TxtMskTelemovel = new MaskedTextBox();
            LblInfoCliente = new Label();
            PanelEnderecoCliente = new Panel();
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
            BtnCadastrarCliente = new Button();
            ChkCadastrarEndereco = new CheckBox();
            PanelInfoCliente.SuspendLayout();
            PanelEnderecoCliente.SuspendLayout();
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
            TxtNome.Size = new Size(167, 33);
            TxtNome.TabIndex = 1;
            TxtNome.KeyPress += TxtNome_KeyPress;
            // 
            // TxtSobrenome
            // 
            TxtSobrenome.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtSobrenome.Location = new Point(364, 11);
            TxtSobrenome.Name = "TxtSobrenome";
            TxtSobrenome.Size = new Size(405, 33);
            TxtSobrenome.TabIndex = 2;
            TxtSobrenome.KeyPress += TxtSobrenome_KeyPress;
            // 
            // LblSobrenome
            // 
            LblSobrenome.AutoSize = true;
            LblSobrenome.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblSobrenome.Location = new Point(248, 14);
            LblSobrenome.Name = "LblSobrenome";
            LblSobrenome.Size = new Size(114, 26);
            LblSobrenome.TabIndex = 2;
            LblSobrenome.Text = "Sobrenome:";
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
            // LblNif
            // 
            LblNif.AutoSize = true;
            LblNif.Font = new Font("Segoe UI Variable Display", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LblNif.Location = new Point(9, 117);
            LblNif.Name = "LblNif";
            LblNif.Size = new Size(44, 26);
            LblNif.TabIndex = 8;
            LblNif.Text = "NIF:";
            // 
            // PanelInfoCliente
            // 
            PanelInfoCliente.BorderStyle = BorderStyle.Fixed3D;
            PanelInfoCliente.Controls.Add(LblInfoNif);
            PanelInfoCliente.Controls.Add(TxtMskNif);
            PanelInfoCliente.Controls.Add(TxtMskTelemovel);
            PanelInfoCliente.Controls.Add(LblNome);
            PanelInfoCliente.Controls.Add(TxtNome);
            PanelInfoCliente.Controls.Add(LblNif);
            PanelInfoCliente.Controls.Add(LblSobrenome);
            PanelInfoCliente.Controls.Add(TxtEmail);
            PanelInfoCliente.Controls.Add(TxtSobrenome);
            PanelInfoCliente.Controls.Add(LblEmail);
            PanelInfoCliente.Controls.Add(LblTelemovel);
            PanelInfoCliente.Location = new Point(4, 25);
            PanelInfoCliente.Name = "PanelInfoCliente";
            PanelInfoCliente.Size = new Size(780, 164);
            PanelInfoCliente.TabIndex = 10;
            // 
            // LblInfoNif
            // 
            LblInfoNif.AutoSize = true;
            LblInfoNif.Location = new Point(170, 124);
            LblInfoNif.Name = "LblInfoNif";
            LblInfoNif.Size = new Size(0, 17);
            LblInfoNif.TabIndex = 12;
            // 
            // TxtMskNif
            // 
            TxtMskNif.Font = new Font("Segoe UI Variable Display", 14.25F);
            TxtMskNif.Location = new Point(58, 114);
            TxtMskNif.Mask = "000000000";
            TxtMskNif.Name = "TxtMskNif";
            TxtMskNif.Size = new Size(106, 33);
            TxtMskNif.TabIndex = 5;
            TxtMskNif.TextChanged += TxtMskNif_TextChanged;
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
            // LblInfoCliente
            // 
            LblInfoCliente.AutoSize = true;
            LblInfoCliente.Location = new Point(5, 5);
            LblInfoCliente.Name = "LblInfoCliente";
            LblInfoCliente.Size = new Size(141, 17);
            LblInfoCliente.TabIndex = 11;
            LblInfoCliente.Text = "Informações do cliente";
            // 
            // PanelEnderecoCliente
            // 
            PanelEnderecoCliente.BorderStyle = BorderStyle.Fixed3D;
            PanelEnderecoCliente.Controls.Add(TxtMskCodigoPostal);
            PanelEnderecoCliente.Controls.Add(LblCodigoPostal);
            PanelEnderecoCliente.Controls.Add(LblPais);
            PanelEnderecoCliente.Controls.Add(TxtPais);
            PanelEnderecoCliente.Controls.Add(LblConcelho);
            PanelEnderecoCliente.Controls.Add(CmbConcelho);
            PanelEnderecoCliente.Controls.Add(LblFreguesia);
            PanelEnderecoCliente.Controls.Add(TxtFreguesia);
            PanelEnderecoCliente.Controls.Add(LblComplemento);
            PanelEnderecoCliente.Controls.Add(TxtComplemento);
            PanelEnderecoCliente.Controls.Add(LblNumeroEndereco);
            PanelEnderecoCliente.Controls.Add(TxtNumeroEndereco);
            PanelEnderecoCliente.Controls.Add(LblLogradouro);
            PanelEnderecoCliente.Controls.Add(TxtLogradouro);
            PanelEnderecoCliente.Enabled = false;
            PanelEnderecoCliente.Location = new Point(4, 219);
            PanelEnderecoCliente.Name = "PanelEnderecoCliente";
            PanelEnderecoCliente.Size = new Size(780, 164);
            PanelEnderecoCliente.TabIndex = 11;
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
            // BtnCadastrarCliente
            // 
            BtnCadastrarCliente.BackColor = SystemColors.ControlLight;
            BtnCadastrarCliente.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
            BtnCadastrarCliente.Location = new Point(4, 395);
            BtnCadastrarCliente.Name = "BtnCadastrarCliente";
            BtnCadastrarCliente.Size = new Size(778, 55);
            BtnCadastrarCliente.TabIndex = 15;
            BtnCadastrarCliente.Text = "Cadastrar";
            BtnCadastrarCliente.UseVisualStyleBackColor = false;
            BtnCadastrarCliente.Click += BtnCadastrarCliente_Click;
            // 
            // ChkCadastrarEndereco
            // 
            ChkCadastrarEndereco.Location = new Point(5, 193);
            ChkCadastrarEndereco.Name = "ChkCadastrarEndereco";
            ChkCadastrarEndereco.Size = new Size(151, 24);
            ChkCadastrarEndereco.TabIndex = 0;
            ChkCadastrarEndereco.Text = "Cadastrar endereço";
            ChkCadastrarEndereco.CheckedChanged += ChkCadastrarEndereco_CheckedChanged_1;
            // 
            // FormCadastrarCliente
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.Control;
            ClientSize = new Size(784, 461);
            Controls.Add(ChkCadastrarEndereco);
            Controls.Add(BtnCadastrarCliente);
            Controls.Add(PanelEnderecoCliente);
            Controls.Add(LblInfoCliente);
            Controls.Add(PanelInfoCliente);
            MaximizeBox = false;
            MaximumSize = new Size(800, 500);
            MinimumSize = new Size(800, 500);
            Name = "FormCadastrarCliente";
            Text = "FastBox - Cadastro de clientes";
            Load += FormCadastrarCliente_Load;
            PanelInfoCliente.ResumeLayout(false);
            PanelInfoCliente.PerformLayout();
            PanelEnderecoCliente.ResumeLayout(false);
            PanelEnderecoCliente.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label LblNome;
        private TextBox TxtNome;
        private TextBox TxtSobrenome;
        private Label LblSobrenome;
        private Label LblTelemovel;
        private TextBox TxtEmail;
        private Label LblEmail;
        private Label LblNif;
        private Panel PanelInfoCliente;
        private Label LblInfoCliente;
        private Panel PanelEnderecoCliente;
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
        private Button BtnCadastrarCliente;
        private MaskedTextBox TxtMskTelemovel;
        private MaskedTextBox TxtMskNif;
        private Label LblInfoNif;
        private MaskedTextBox TxtMskCodigoPostal;
        private CheckBox ChkCadastrarEndereco;
    }
}