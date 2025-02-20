using FastBox.BLL.DTOs;
using FastBox.BLL.DTOs.Filters;
using FastBox.BLL.Services.Interfaces;
using FastBox.DAL.Models;
using FastBox.UI.Helper;
using System.Diagnostics;

namespace FastBox.UI.Forms;

public partial class FormRelatorio : Form
{
	private readonly IOrdemDeServicoService _ordemDeServicoService;

	public FormRelatorio(IOrdemDeServicoService ordemDeServicoService)
	{
		InitializeComponent();
		_ordemDeServicoService = ordemDeServicoService;
	}

	private async void BtnGerarRelatorio_Click(object sender, EventArgs e)
	{
		try
		{
			OrdemDeServicoFilter filter = new OrdemDeServicoFilter
			{
				Ano = DtpMesRelatorio.Value.Year,
				Mes = DtpMesRelatorio.Value.Month
			};

			var ordens = await _ordemDeServicoService.GetAllOrdens(filter);

			using (SaveFileDialog saveFileDialog = new SaveFileDialog())
			{
				saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
				saveFileDialog.Title = "Salvar relatório como PDF";
				saveFileDialog.FileName = $"Relatório {DtpMesRelatorio.Value.ToString("MMMM")}-{DtpMesRelatorio.Value.Year}";

				if (saveFileDialog.ShowDialog() == DialogResult.OK)
				{
					string filePath = saveFileDialog.FileName;

					PDF.GenerateRelatorio(ordens.ToList(), filePath);
					MessageBox.Show($"Relatório de {DtpMesRelatorio.Value.ToString("MMMM")}/{DtpMesRelatorio.Value.Year} gerado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

					string? folderPath = Path.GetDirectoryName(filePath);
					if (folderPath != null)
					{
						Process.Start(new ProcessStartInfo
						{
							FileName = folderPath,
							UseShellExecute = true,
							Verb = "open"
						});
					}
				}
			}
		}
		catch (Exception ex)
		{
			MessageBox.Show($"Erro ao gerar relatório: {ex.Message}", "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}
