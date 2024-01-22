using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AD_Monitoring.Models
{
    public class TreeAD : IEnumerable<TreeAD>
    {
        private string? Path { get; set; }
        private string? Name { get; set; }

        private List<TreeAD> Children { get; set; } = new();

        public TreeAD() { }

        public TreeAD(string path, string name)
        {
            this.Path = path;
            this.Name = name;
        }

        public string GetName()
        {
            return this.Name;
        }

        public List<TreeAD> GetChildren()
        {
            return this.Children;
        }

        public void AddChildren(TreeAD child)
        {
            this.Children.Add(child);
        }

        public IEnumerator<TreeAD> GetEnumerator() => Children.GetEnumerator();

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
