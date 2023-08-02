using Microsoft.Office.Interop.Excel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Monitoring
{
    public class ExportToExcel
    {

        public static void Excel(ListView listview)
        {
            int a = listview.Items.Count;
            int b = listview.Columns.Count;

            Microsoft.Office.Interop.Excel.Application app = new();
            app.Visible = false;
            Microsoft.Office.Interop.Excel.Workbook wb = app.Workbooks.Add(1);
            Microsoft.Office.Interop.Excel.Worksheet ws = (Microsoft.Office.Interop.Excel.Worksheet)wb.Worksheets[1];
            Microsoft.Office.Interop.Excel.Range range = null;
            Microsoft.Office.Interop.Excel.Range range1 = null;
            range1 = ws.get_Range("A1", "G1");
            range = ws.get_Range("A2", "G" + a);

            for (int i = 0; i < b; i++)
            {
                ws.Cells[1, i + 1] = listview.Columns[i].Text;
                range1.Font.Size = 12;
                range1.Font.Bold = true;
                range1.Interior.Color = Color.PaleGreen;
            }
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
            range.Columns.AutoFit();
            app.Visible = true;
        }
    }
}
