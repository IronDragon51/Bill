using Bill.Definition;
using OfficeOpenXml;
using System.Diagnostics;

namespace Bill.Backend
{
    public static class ExcelDataExporter
    {
        public static void ExportDataToExcel(Receipt receipt)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            Console.Clear();
            Console.WriteLine("Do you want to export it to Excel file? (press 'y' if yes)");

            if (Console.ReadLine() == "y")
            {
                string filePath = @"C:\VS\Bill_Full\Bill\ExcelData\Output_" + Groups.groups[0].Name + DateTime.Now.ToString("yyyyMMdd_HHmm") + ".xlsx";

                if (IsExcelFileEmpty(filePath))
                {
                    try
                    {
                        using (FileStream stream = new(filePath, FileMode.Open, FileAccess.Read, FileShare.None))
                        {
                            stream.Close();
                        }

                        using ExcelPackage excelPackage = new();
                    }
                    catch (IOException)
                    {
                        Console.WriteLine("The Excel file is currently open. Please close it before proceeding.");
                    }
                }

                try
                {
                    using (ExcelPackage excelPackage = new())
                    {
                        ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.Add("Sheet1");

                        worksheet.Cells[1, 1].Value = "Group/Person Name";
                        worksheet.Cells[1, 2].Value = "Total";
                        worksheet.Cells[1, 3].Value = "Total with fee";

                        worksheet.Column(2).Style.Numberformat.Format = "$#,##0.00";
                        worksheet.Column(3).Style.Numberformat.Format = "$#,##0.00";

                        int row = 2;
                        foreach (Group currGroup in Groups.groups)
                        {

                            Currency currencyEnum = Enum.Parse<Currency>(receipt.Currency);
                            string currencyFormat = currencyEnum switch
                            {
                                Currency.USD => "$#,##0.00",
                                Currency.EUR => "€#,##0.00",
                                Currency.HUF => "#,##0.00 \"HUF\"",
                                _ => "#,##0.00"
                            };

                            string currency = receipt.Currency;
                            worksheet.Cells[row, 1].Value = currGroup.Name;
                            worksheet.Cells[row, 2].Value = currGroup.Total;
                            worksheet.Cells[row, 3].Value = currGroup.TotalWithFee;

                            worksheet.Cells[row, 1].Style.Numberformat.Format = currencyFormat;
                            worksheet.Cells[row, 2].Style.Numberformat.Format = currencyFormat;
                            worksheet.Cells[row, 3].Style.Numberformat.Format = currencyFormat;

                            row++;
                        }

                        worksheet.Cells[worksheet.Dimension.Address].AutoFitColumns();

                        FileInfo excelFile = new(filePath);
                        excelPackage.SaveAs(excelFile);
                    }

                    Console.Clear();
                    Console.WriteLine("Data exported to Excel successfully.");
                    Console.WriteLine("\nDo you want to open it? (press 'y' if yes)");

                    if (Console.ReadLine() == "y")
                    {
                        Process.Start(new ProcessStartInfo { FileName = filePath, UseShellExecute = true });
                        Environment.Exit(0);
                    }
                }
                catch (IOException)
                {
                    Console.WriteLine("The Excel file is currently open. Please close it before proceeding.");
                }
            }
        }

        private static bool IsExcelFileEmpty(string filePath)
        {
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            using ExcelPackage excelPackage = new();
            try
            {
                FileInfo excelFile = new(filePath);
                if (!excelFile.Exists)
                {
                    return true;
                }

                using (FileStream stream = excelFile.OpenRead())
                {
                    excelPackage.Load(stream);
                }

                ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets.FirstOrDefault();

                if (worksheet == null || worksheet.Dimension == null)
                {
                    return true;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{ex.Message}");
            }

            return false;
        }
    }
}
