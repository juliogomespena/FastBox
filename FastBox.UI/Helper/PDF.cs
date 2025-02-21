using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using FastBox.BLL.DTOs;
using iText.Kernel.Pdf.Canvas.Draw;
using iText.Kernel.Geom;
using System.Linq;

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

                Table table = new Table(UnitValue.CreatePercentArray(new float[] {3, 12, 13, 16, 3, 7, 7, 7, 7, 7, 7, 7, 7})).UseAllAvailableWidth();
				table.AddHeaderCell("N°");
                table.AddHeaderCell("Status");
                table.AddHeaderCell("Cliente");
                table.AddHeaderCell("Viatura");
				table.AddHeaderCell("Dia");
				table.AddHeaderCell("Valor total");
				table.AddHeaderCell("IVA");
				table.AddHeaderCell("Mão de obra");
				table.AddHeaderCell("Peças e serviços");
				table.AddHeaderCell("Lucro peças e serviços");
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
					table.AddCell(ordem.IncluirIva ? (ordem.ValorTotal - (ordem.ValorTotal / (decimal)1.23))?.ToString("C2") : 0.ToString("C2"));
					table.AddCell(ordem.MaoDeObra?.ToString("C2"));
					table.AddCell(ordem.Pecas?.ToString("C2"));
					table.AddCell(ordem.LucroPecas?.ToString("C2"));
					table.AddCell(ordem.Lucro?.ToString("C2"));
					table.AddCell(ordem.ValorPago);
					table.AddCell(ordem.ValorDevido);
                }

				document.Add(table);

				document.Add(new Paragraph($"\nVendas: {ordens.Sum(o => o.ValorTotal)?.ToString("C2")}\tMão de obra: {ordens.Sum(o => o.MaoDeObra)?.ToString("C2")}\tPeças e serviços: {ordens.Sum(o => o.Pecas)?.ToString("C2")}\tLucro de peças e serviços: {ordens.Sum(o => o.LucroPecas)?.ToString("C2")}\tLucro total: {ordens.Sum(o => o.Lucro)?.ToString("C2")}\n\nRecebidos: {ordens.Sum(o => o.ValorPagoDecimal)?.ToString("C2")}\tDevidos: {ordens.Sum(o => o.ValorDevidoDecimal)?.ToString("C2")}\tIVA: {ordens.Where(ordens => ordens.IncluirIva).Sum(o => o.ValorTotal - (o.ValorTotal / (decimal)1.23))?.ToString("C2")}\n\nTicket médio: {(ordens.Sum(o => o.ValorTotal) / ordemCount)?.ToString("C2")}")
					.SetFontSize(12)
					.SetTextAlignment(TextAlignment.RIGHT));

				document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

				document.Add(logo);

				document.Add(new Paragraph("FastBox - Setúbal")
					.SetFontSize(16)
					.SetTextAlignment(TextAlignment.LEFT));

				document.Add(new LineSeparator(new SolidLine()));

				document.Add(new Paragraph("\n"));

				document.Add(new Paragraph("Resumo de fornecedores")
					.SetFontSize(12)
					.SetTextAlignment(TextAlignment.LEFT));

				Table table2 = new Table(UnitValue.CreatePercentArray(new float[] { 50, 50 })).UseAllAvailableWidth();
				table2.AddHeaderCell("Fornecedor");
				table2.AddHeaderCell("Custo de peças/serviços");

                var fornecedores = ordens.SelectMany(o => o.Orcamentos).SelectMany(o => o.ItensOrcamento).Where(i => i.Descricao != "Mão de obra").GroupBy(i => i.Fornecedor.Nome);

				foreach (var fornecedor in fornecedores)
                {
					table2.AddCell(fornecedor.Key);
                    table2.AddCell(fornecedor.Sum(i => (i.PrecoUnitario * (decimal)i.Quantidade)).ToString("C2"));
				}

				document.Add(table2);

				document.Add(new AreaBreak(AreaBreakType.NEXT_PAGE));

				document.Add(logo);

				document.Add(new Paragraph("FastBox - Setúbal")
					.SetFontSize(16)
					.SetTextAlignment(TextAlignment.LEFT));

				document.Add(new LineSeparator(new SolidLine()));

				document.Add(new Paragraph("\n"));

				document.Add(new Paragraph("Entradas por meio de pagamento")
					.SetFontSize(12)
					.SetTextAlignment(TextAlignment.LEFT));

				Table table3 = new Table(UnitValue.CreatePercentArray(new float[] { 50, 50 })).UseAllAvailableWidth();
				table3.AddHeaderCell("Meio de pagamento");
				table3.AddHeaderCell("Valor");

                var pagamentos = ordens.SelectMany(o => o.Pagamentos).GroupBy(p => p.MetodoPagamento.Nome);

                foreach (var pagamento in pagamentos)
                {
                    table3.AddCell(pagamento.Key);
                    table3.AddCell(pagamento.Sum(p => p.Valor).ToString("C2"));
				}

                document.Add(table3);

				document.Close();
			}
		}
	}
}
