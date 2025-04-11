using System.Data;
using OfficeOpenXml;

namespace DemoMVC.Models.Process
{
    public class ExcelProcess
    {
        public DataTable ExcelToDataTable(string strPath)
        {
            FileInfo fi = new FileInfo(strPath);
            if (!fi.Exists)
            {
                Console.WriteLine($"❌ Lỗi: File không tồn tại - {strPath}");
                return new DataTable();
            }

            using var excelPackage = new ExcelPackage(fi);
            ExcelWorksheet worksheet = excelPackage.Workbook.Worksheets[0];

            if (worksheet.Dimension == null)
            {
                Console.WriteLine("❌ Lỗi: File rỗng hoặc không đọc được");
                return new DataTable();
            }

            Console.WriteLine("✅ File đọc thành công, đang xử lý dữ liệu...");
            Console.WriteLine($"Số dòng: {worksheet.Dimension.End.Row}, Số cột: {worksheet.Dimension.End.Column}");

            DataTable dt = new DataTable();
            List<string> columnNames = new List<string>();

            foreach (var cell in worksheet.Cells[1, 1, 1, worksheet.Dimension.End.Column])
            {
                string columnName = cell.Text.Trim();
                if (string.IsNullOrEmpty(columnName)) columnName = $"Header_{cell.Start.Column}";
                columnNames.Add(columnName);
                dt.Columns.Add(columnName);
            }

            for (int i = 2; i <= worksheet.Dimension.End.Row; i++)
            {
                var row = worksheet.Cells[i, 1, i, worksheet.Dimension.End.Column];
                DataRow newRow = dt.NewRow();

                foreach (var cell in row)
                {
                    newRow[cell.Start.Column - 1] = cell.Text;
                }

                dt.Rows.Add(newRow);
            }

            Console.WriteLine($"✅ Đọc dữ liệu xong, tổng {dt.Rows.Count} dòng.");
            return dt;
        }
    }
}