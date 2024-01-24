using AD_Monitoring.Repository;
using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace AD_Monitoring.Infrastructure
{
    public class ExportToExcel
    {
        private static ExcelRepository excel;

        public static void WriteExcelFile(ListView listview)
        {
            using (excel = new ExcelRepository())
            {            
                int rowsCount = listview.Items.Count;
                int columnsCount = listview.Columns.Count;

                Workbook wbToWrite = excel.AddWorkbook();
                Worksheet wsToWrite = excel.AddWorksheet(wbToWrite);
                Range range = excel.GetRangeHeadlines(wsToWrite);

                excel.SetHeadlines(wsToWrite, listview, columnsCount);
                excel.FormatHeadlines(wsToWrite, range);

                excel.Write(wsToWrite, listview);

                range.Columns.AutoFit();
                excel.Visible();
            }
        }
    }
}
