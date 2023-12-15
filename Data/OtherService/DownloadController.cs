using DocumentFormat.OpenXml.Spreadsheet;
using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OMS.Entities;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

public class DownloadController : ControllerBase
{
    [HttpPost("~/download")]
    public async Task<IActionResult> Download([FromBody] List<Product> products)
    {
        products = products.OrderBy(p => p.ProductName).ToList();
        // Create a new Excel package
        using (var package = new ExcelPackage())
        {
            // Add a new worksheet
            var worksheet = package.Workbook.Worksheets.Add("Sheet1");


            string[] columnHeaders = {"Product", "Brand", "Category","Unit Price", "Initial Quantity", "Threshold", "Description" };
            // Add column headers
            var properties = typeof(Product).GetProperties();
            for (int i = 0; i < columnHeaders.Length; i++)
            {
                worksheet.Cells[1, i + 1].Value = columnHeaders[i];
                worksheet.Cells[1, i + 1].Style.Font.Color.SetColor(System.Drawing.Color.DarkGreen);
            }

            // Add data rows
            for (int row = 0; row < products.Count; row++)
            {
                for (int col = 0; col < columnHeaders.Length; col++)
                {
                    // You can customize how you retrieve the property value based on the column header
                    switch (columnHeaders[col])
                    {
                        case "Product":
                            worksheet.Cells[row + 2, col + 1].Value = products[row].ProductName;
                            break;
                        case "Brand":
                            worksheet.Cells[row + 2, col + 1].Value = products[row].BrandName;
                            break;
                        case "Category":
                            worksheet.Cells[row + 2, col + 1].Value = products[row].CategoryName;
                            break;
                        case "Unit Price":
                            worksheet.Cells[row + 2, col + 1].Value = products[row].UnitPrice;
                            break;
                        case "Initial Quantity":
                            worksheet.Cells[row + 2, col + 1].Value = products[row].InitialQuantity;
                            break;
                        case "Threshold":
                            worksheet.Cells[row + 2, col + 1].Value = products[row].Threshold;
                            break;
                        case "Description":
                            worksheet.Cells[row + 2, col + 1].Value = products[row].Description;
                            break;
                    }
                }
            }
            worksheet.Cells.AutoFitColumns();

            // Save the package to a stream
            var stream = new MemoryStream(package.GetAsByteArray());

            // Set the stream position to the beginning
            stream.Position = 0;

            // Set the content type and download file name
            var result = new FileStreamResult(stream, "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
            result.FileDownloadName = $"products_{DateTime.Now}.xlsx";

            return result;
        }
    }
}