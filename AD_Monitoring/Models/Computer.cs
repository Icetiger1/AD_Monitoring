using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Monitoring.Models
{
    public class Computer
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? OS { get; set; }
        public string? Company { get; set; }

        public void AddToListView(ListView lv)
        {
            ListViewItem item1 = new ListViewItem(this.Name);
            item1.SubItems.Add(this.Description);
            item1.SubItems.Add(this.Location);
            item1.SubItems.Add(this.OS);
            item1.SubItems.Add(this.Company);
            item1.SubItems.Add(" ");
            item1.SubItems.Add(" ");
            item1.ImageIndex = 4;
            lv.Items.AddRange(new ListViewItem[] { item1 });
        }
    }
}
