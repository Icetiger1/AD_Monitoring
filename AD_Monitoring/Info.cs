using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Monitoring
{
    public class Object
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Location { get; set; }
        public string? OS { get; set; }
        public string? Company { get; set; }
    }
    public class TreeAD
    {
        public string? Path { get; set; }
        public string? Name { get; set; }

    }
    public class ScanInfo
    {
        public string? IP { get; set; }
        public string? Login { get; set; }
        public string? FIO { get; set; }
    }
}
