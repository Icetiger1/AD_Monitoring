using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Office.Interop.Excel;
using Application = Microsoft.Office.Interop.Excel.Application;
using Range = Microsoft.Office.Interop.Excel.Range;

namespace AD_Monitoring.Repository
{
    public class ExcelRepository : IDisposable
    {
        Application app = new();

        public ExcelRepository()
        {
            this.app.Visible = false;
            this.app.DisplayAlerts = false;
        }

        public Workbook AddWorkbook()
        {
            Workbook wb = app.Workbooks.Add(1);
            return wb;
        }

        public Workbook OpenWorkbook(string fileName)
        {
            Workbook wb = app.Workbooks.Open(fileName);
            return wb;
        }

        public Worksheet AddWorksheet(Workbook wb)
        {
            Worksheet ws = (Worksheet)wb.Worksheets[1];
            return ws;
        }

        public int WsRowCount(Worksheet ws)
        {
            int rowCount = ws.Rows.CurrentRegion.EntireRow.Count;
            return rowCount;
        }

        public Range GetRangeHeadlines(Worksheet ws)
        {
            Range range = ws.get_Range("A1", "G1");
            return range;
        }

        public void SetHeadlines(Worksheet ws, ListView lv, int columnsCount)
        {
            for (int i = 0; i < columnsCount; i++)
            {
                ws.Cells[1, i + 1] = lv.Columns[i].Text;
            }
        }

        public void FormatHeadlines(Worksheet ws, Range range)
        {
            range.Font.Size = 12;
            range.Interior.Color = Color.LightGray;
            range.Font.Bold = true;
        }

        public void Write(Worksheet ws, ListView listview)
        {
            int i1 = 1;
            int i2 = 2;
            foreach (ListViewItem lv in listview.Items)
            {
                i1 = 1;
                foreach (ListViewItem.ListViewSubItem lvs in lv.SubItems)
                {
                    ws.Cells[i2, i1] = lvs.Text;
                    i1++;
                }
                i2++;
            }
        }

        public void Visible()
        {
            this.app.Visible = true;
            this.app.DisplayAlerts = true;
        }

        public void Quit(Workbook wb, Worksheet ws)
        {
            if (ws != null) Marshal.ReleaseComObject(ws);
            if (wb != null) Marshal.ReleaseComObject(wb);
            if (app != null) Marshal.ReleaseComObject(app);
        }

        public void Dispose()
        {
            if (this.app != null) Marshal.ReleaseComObject(app);
        }
    }
}
