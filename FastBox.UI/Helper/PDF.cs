using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using iText.IO.Image;
using FastBox.BLL.DTOs;

namespace FastBox.UI.Helper
{
    internal class PDF
    {
        public static void GenerateOrcamento(OrcamentoViewModel orcamento, string filePath)
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
                    document.Add(new Paragraph("Endereço: Rua Exemplo, 123, Centro, Cidade/UF")
                        .SetTextAlignment(TextAlignment.LEFT));
                    document.Add(new Paragraph("Telefone: (00) 1234-5678")
                        .SetTextAlignment(TextAlignment.LEFT));

                    document.Add(new Paragraph("\n"));

                    document.Add(new Paragraph($"Orçamento - Nº{orcamento.Numero}")
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
    }
}
