using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;
using DAL;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using System.IO;
using System.Diagnostics;



namespace BLL
{
    public class TKHoaDonBLL
    {
        public CTHoaDonDAL ct = new CTHoaDonDAL();
        public TKHoaDonDAL tk = new TKHoaDonDAL();
       public DataTable BaoCaoTKBLL(DateTime ngaystart, DateTime ngayend)
       {
            return tk.BaoCaoThang(ngaystart, ngayend);
       }
        public DataTable BaoCaoTLBLL(DateTime ngaystart, DateTime ngayend)
        {
            return tk.ThongKeTheoTheLoai(ngaystart, ngayend);
        }
        public void ExportDataToExcel(DateTime ngaystart, DateTime ngayend, string filePath)
        {
            DataTable dataTable = tk.BaoCaoThang(ngaystart, ngayend);
           
         
               ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.InsertRow(1, 1);
                worksheet.Cells["A1"].Value = "Thống kê doanh thu";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["A1"].Style.Border.BorderAround(ExcelBorderStyle.Thick, System.Drawing.Color.Black);
                worksheet.Cells["A1:B1"].Merge = true;
                // Ghi dữ liệu từ DataTable vào worksheet
                worksheet.Cells["A2"].LoadFromDataTable(dataTable, true);
                // Định dạng phông chữ và tiêu đề
                using (var range = worksheet.Cells["A1:Z1"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 12;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                }

                // Bôi đen bảng
                for (int row = 1; row <= worksheet.Dimension.Rows; row++)
                {
                    for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                    {
                        ExcelRange cell = worksheet.Cells[row, col];
                        if (!string.IsNullOrEmpty(cell.Text))
                        {
                            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }
                    }
                }

                // Căn giữa chữ trong bảng
                worksheet.Cells[worksheet.Dimension.Address].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                // Lưu tệp Excel
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
            Process.Start(filePath);
        }
        public void ExportDataToExcelTheLoai(DateTime ngaystart, DateTime ngayend, string filePath)
        {
            DataTable dataTable = tk.ThongKeTheoTheLoai(ngaystart, ngayend);


            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.InsertRow(1, 1);
                worksheet.Cells["A1"].Value = "Thống kê doanh thu";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["A1"].Style.Border.BorderAround(ExcelBorderStyle.Thick, System.Drawing.Color.Black);
                worksheet.Cells["A1:E1"].Merge = true;
                // Ghi dữ liệu từ DataTable vào worksheet
                worksheet.Cells["A2"].LoadFromDataTable(dataTable, true);
                // Định dạng phông chữ và tiêu đề
                worksheet.Column(2).Width = 13;
                worksheet.Column(3).Width = 13;
                worksheet.Column(4).Width = 13;
                worksheet.Column(5).Width = 14;


                using (var range = worksheet.Cells["A1:Z1"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 12;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                 
                }

                // Bôi đen bảng
                for (int row = 1; row <= worksheet.Dimension.Rows; row++)
                {
                    for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                    {
                        ExcelRange cell = worksheet.Cells[row, col];
                        if (!string.IsNullOrEmpty(cell.Text))
                        {
                            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }
                    }
                }

                // Căn giữa chữ trong bảng
                worksheet.Cells[worksheet.Dimension.Address].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                // Lưu tệp Excel
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
            Process.Start(filePath);
        }
        public void ExportDataToExcelHD(string mahd, string filePath)
        {
            DataTable dataTable = ct.GetDSInHoaDon(mahd);


            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;
            using (ExcelPackage package = new ExcelPackage())
            {
                ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Sheet1");
                worksheet.InsertRow(1, 1);
                worksheet.Cells["A1"].Value = "Thống kê doanh thu";
                worksheet.Cells["A1"].Style.Font.Size = 16;
                worksheet.Cells["A1"].Style.Font.Bold = true;
                worksheet.Cells["A1"].Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;
                worksheet.Cells["A1"].Style.VerticalAlignment = ExcelVerticalAlignment.Center;
                worksheet.Cells["A1"].Style.Border.BorderAround(ExcelBorderStyle.Thick, System.Drawing.Color.Black);
                worksheet.Cells["A1:E1"].Merge = true;
                // Ghi dữ liệu từ DataTable vào worksheet
                worksheet.Cells["A2"].LoadFromDataTable(dataTable, true);
                // Định dạng phông chữ và tiêu đề
                worksheet.Column(2).Width = 13;
                worksheet.Column(3).Width = 13;
                worksheet.Column(4).Width = 13;
                worksheet.Column(5).Width = 14;


                using (var range = worksheet.Cells["A1:Z1"])
                {
                    range.Style.Font.Bold = true;
                    range.Style.Font.Size = 12;
                    range.Style.HorizontalAlignment = ExcelHorizontalAlignment.Center;

                }

                // Bôi đen bảng
                for (int row = 1; row <= worksheet.Dimension.Rows; row++)
                {
                    for (int col = 1; col <= worksheet.Dimension.Columns; col++)
                    {
                        ExcelRange cell = worksheet.Cells[row, col];
                        if (!string.IsNullOrEmpty(cell.Text))
                        {
                            cell.Style.Border.BorderAround(ExcelBorderStyle.Thin, System.Drawing.Color.Black);
                        }
                    }
                }

                // Căn giữa chữ trong bảng
                worksheet.Cells[worksheet.Dimension.Address].Style.VerticalAlignment = ExcelVerticalAlignment.Center;


                // Lưu tệp Excel
                File.WriteAllBytes(filePath, package.GetAsByteArray());
            }
            Process.Start(filePath);
        }
    }
}
