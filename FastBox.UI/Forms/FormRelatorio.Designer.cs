namespace FastBox.UI.Forms;

partial class FormRelatorio
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
		DtpMesRelatorio = new DateTimePicker();
		LblSelecionarMes = new Label();
		BtnGerarRelatorio = new Button();
		SuspendLayout();
		// 
		// DtpMesRelatorio
		// 
		DtpMesRelatorio.CustomFormat = "MM/yyyy";
		DtpMesRelatorio.Font = new Font("Segoe UI", 16F);
		DtpMesRelatorio.Format = DateTimePickerFormat.Custom;
		DtpMesRelatorio.Location = new Point(190, 17);
		DtpMesRelatorio.Name = "DtpMesRelatorio";
		DtpMesRelatorio.RightToLeft = RightToLeft.No;
		DtpMesRelatorio.Size = new Size(133, 36);
		DtpMesRelatorio.TabIndex = 26;
		// 
		// LblSelecionarMes
		// 
		LblSelecionarMes.AutoSize = true;
		LblSelecionarMes.Font = new Font("Segoe UI Variable Display", 16F);
		LblSelecionarMes.Location = new Point(12, 21);
		LblSelecionarMes.Name = "LblSelecionarMes";
		LblSelecionarMes.Size = new Size(172, 30);
		LblSelecionarMes.TabIndex = 25;
		LblSelecionarMes.Text = "Selecione o mês:";
		// 
		// BtnGerarRelatorio
		// 
		BtnGerarRelatorio.BackColor = SystemColors.ControlLight;
		BtnGerarRelatorio.Font = new Font("Segoe UI Variable Display Semib", 16F, FontStyle.Bold);
		BtnGerarRelatorio.Location = new Point(329, 17);
		BtnGerarRelatorio.Name = "BtnGerarRelatorio";
		BtnGerarRelatorio.Size = new Size(127, 36);
		BtnGerarRelatorio.TabIndex = 27;
		BtnGerarRelatorio.Text = "Gerar";
		BtnGerarRelatorio.UseVisualStyleBackColor = false;
		BtnGerarRelatorio.Click += BtnGerarRelatorio_Click;
		// 
		// FormRelatorio
		// 
		AutoScaleDimensions = new SizeF(7F, 17F);
		AutoScaleMode = AutoScaleMode.Font;
		ClientSize = new Size(473, 75);
		Controls.Add(BtnGerarRelatorio);
		Controls.Add(DtpMesRelatorio);
		Controls.Add(LblSelecionarMes);
		FormBorderStyle = FormBorderStyle.FixedDialog;
		MaximizeBox = false;
		MaximumSize = new Size(489, 114);
		MinimumSize = new Size(489, 114);
		Name = "FormRelatorio";
		SizeGripStyle = SizeGripStyle.Hide;
		Text = "FastBox - Gerar relatório";
		ResumeLayout(false);
		PerformLayout();
	}

	#endregion

	private DateTimePicker DtpMesRelatorio;
	private Label LblSelecionarMes;
	private Button BtnGerarRelatorio;
}