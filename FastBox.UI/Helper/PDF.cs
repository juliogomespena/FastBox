using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using FastBox.BLL.DTOs;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Geom;

namespace FastBox.UI.Helper;

internal class PDF
{
    public static void GenerateOrcamento(OrcamentoViewModel orcamento,ClienteViewModel? cliente, VeiculoViewModel? veiculo, string filePath)
    {
        using (PdfWriter writer = new PdfWriter(filePath))
        {
            using (PdfDocument pdf = new PdfDocument(writer))
            {
                Document document = new Document(pdf);

                byte[] logoBytes;
                using (var ms = new System.IO.MemoryStream())
                {
                    FastBox.UI.Properties.Resources.logo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                    logoBytes = ms.ToArray();
                }

                ImageData imageData = ImageDataFactory.Create(logoBytes);
                var logo = new iText.Layout.Element.Image(imageData)
                    .ScaleToFit(200, 200)
                    .SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);
                document.Add(logo);

                document.Add(new Paragraph("FastBox - Setúbal")
                    .SetFontSize(16)
                    .SetTextAlignment(TextAlignment.LEFT));
                document.Add(new Paragraph("Estrada de Palmela, 45a - Setúbal")
                    .SetTextAlignment(TextAlignment.LEFT));
                document.Add(new Paragraph("Telefone: +351 937-368-242")
                    .SetTextAlignment(TextAlignment.LEFT));

                document.Add(new Paragraph("\n"));

                document.Add(new Paragraph($"Orçamento - Nº{orcamento.Numero}\nViatura: {(veiculo is null ? "Viatura não cadastrada" : veiculo.ModeloMatricula)}\nCliente: {(cliente is null ? "Cliente não cadastrado" : cliente.NomeSobrenome)}")
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER));
                document.Add(new Paragraph($"{orcamento.Descricao}")
                    .SetFontSize(14)
                    .SetTextAlignment(TextAlignment.CENTER));
                document.Add(new Paragraph($"Data: {orcamento.DataCriacao:dd/MM/yyyy HH:mm}")
                    .SetTextAlignment(TextAlignment.CENTER));

                document.Add(new Paragraph("\n"));
 
                Table table = new Table(UnitValue.CreatePercentArray(4)).UseAllAvailableWidth();
                table.AddHeaderCell("Item");
                table.AddHeaderCell("Quantidade");
                table.AddHeaderCell("Preço unitário");
                table.AddHeaderCell("Total");

                foreach (var item in orcamento.ItensOrcamento)
                {
                    table.AddCell(item.Descricao);
                    table.AddCell(item.Quantidade.ToString());
                    table.AddCell(item.ValorUnitario.ToString("C2"));
                    table.AddCell(item.ValorTotal.ToString("C2"));
                }

                document.Add(table);

                document.Add(new Paragraph($"\nValor líquido: {orcamento.VendaTotal.ToString("C2")}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.RIGHT));
                document.Add(new Paragraph($"IVA: {(orcamento.VendaTotal * GlobalConfiguration.IVA).ToString("C2")}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.RIGHT));
                document.Add(new Paragraph($"Valor total: {(orcamento.VendaTotal + (orcamento.VendaTotal * GlobalConfiguration.IVA)).ToString("C2")}")
                    .SetFontSize(12)
                    .SetTextAlignment(TextAlignment.RIGHT));

                document.Close();
            }
        }
    }

	public static void GenerateRelatorio(List<OrdemDeServicoViewModel> ordens, string filePath, string monthYear)
	{
		using (PdfWriter writer = new PdfWriter(filePath))
		{
			using (PdfDocument pdf = new PdfDocument(writer))
			{
				Document document = new Document(pdf, PageSize.A4.Rotate());

				byte[] logoBytes;
				using (var ms = new System.IO.MemoryStream())
				{
					FastBox.UI.Properties.Resources.logo.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
					logoBytes = ms.ToArray();
				}

				ImageData imageData = ImageDataFactory.Create(logoBytes);
				var logo = new iText.Layout.Element.Image(imageData)
					.ScaleToFit(200, 200)
					.SetHorizontalAlignment(iText.Layout.Properties.HorizontalAlignment.LEFT);
				document.Add(logo);

				document.Add(new Paragraph("FastBox - Setúbal")
					.SetFontSize(16)
					.SetTextAlignment(TextAlignment.LEFT));

                document.Add(new LineSeparator(new SolidLine()));

				document.Add(new Paragraph("\n"));

				document.Add(new Paragraph($"Resumo de {monthYear}")
					.SetFontSize(12)
					.SetTextAlignment(TextAlignment.LEFT));

                Table table = new Table(UnitValue.CreatePercentArray(new float[] {3, 16, 13, 16, 3, 7, 7, 7, 7, 7, 7, 7})).UseAllAvailableWidth();
				table.AddHeaderCell("N°");
                table.AddHeaderCell("Status");
                table.AddHeaderCell("Cliente");
                table.AddHeaderCell("Viatura");
				table.AddHeaderCell("Dia");
				table.AddHeaderCell("Valor total");
				table.AddHeaderCell("Mão de obra");
				table.AddHeaderCell("Peças");
				table.AddHeaderCell("Lucro peças");
				table.AddHeaderCell("Lucro total");
				table.AddHeaderCell("Pago");
                table.AddHeaderCell("Pendente");

                int ordemCount = 0;

				foreach (var ordem in ordens)
                {
					ordemCount++;
					table.AddCell(ordemCount.ToString());
                    table.AddCell(ordem.Status);
                    table.AddCell(ordem.Cliente?.Nome);
                    table.AddCell(ordem.ModeloMatricula);
                    table.AddCell(ordem.DataAbertura.ToString("dd"));
                    table.AddCell(ordem.ValorTotal?.ToString("C2"));
                    table.AddCell(ordem.MaoDeObra?.ToString("C2"));
					table.AddCell(ordem.Pecas?.ToString("C2"));
					table.AddCell(ordem.LucroPecas?.ToString("C2"));
					table.AddCell(ordem.Lucro?.ToString("C2"));
					table.AddCell(ordem.ValorPago);
					table.AddCell(ordem.ValorDevido);
                }

				document.Add(table);

				document.Add(new Paragraph($"\nTotal de vendas: {ordens.Sum(o => o.ValorTotal)?.ToString("C2")}\tTotal de mão de obra: {ordens.Sum(o => o.MaoDeObra)?.ToString("C2")}\tCusto de peças: {ordens.Sum(o => o.Pecas)?.ToString("C2")}\tLucro de peças: {ordens.Sum(o => o.LucroPecas)}\tLucro total: {ordens.Sum(o => o.Lucro)?.ToString("C2")}\n\nRecebidos totais: {ordens.Sum(o => o.ValorPagoDecimal)?.ToString("C2")}\tDevidos totais: {ordens.Sum(o => o.ValorDevidoDecimal)?.ToString("C2")}\n\nTicket médio: {(ordens.Sum(o => o.ValorTotal) / ordemCount)?.ToString("C2")}")
					.SetFontSize(12)
					.SetTextAlignment(TextAlignment.RIGHT));

				document.Close();
			}
		}
	}
}
