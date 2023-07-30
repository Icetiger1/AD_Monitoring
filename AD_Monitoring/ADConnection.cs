using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AD_Monitoring
{
    public class ADConnection
    {
        public static string GetDomain()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            string tmp = properties.DomainName.ToString();
            return tmp;
        }
        public static string GetLDAPDomain()
        {
            List<string> t = new();
            string tmp = GetDomain();
            t = tmp.Split('.').ToList();
            string tmp1 = @"LDAP://" + tmp + "/";
            string tmp2 = default;
            string domainName;
            for (int i = 0; i < t.Count; i++)
            {
                tmp2 += "DC=" + t[i] + ",";
            }
            domainName = tmp1 + tmp2;
            domainName = domainName.Remove(domainName.Length - 1, 1);
            return domainName;
        }
        public static string GetLDAPTreeNodes(TreeView tv)
        {
            int level = tv.SelectedNode.Level;
            string? lvl2 = default;
            string? lvl1 = default;
            string? lvl = default;
            if (level == 0)
            {
                lvl2 = "OU=" + tv.SelectedNode.Text + ",";
            }
            if (level == 1)
            {
                lvl2 = "OU=" + tv.SelectedNode.Text + ",";
                lvl1 = "OU=" + tv.SelectedNode.Parent.Text + ",";
            }
            if (level == 2)
            {
                lvl2 = "OU=" + tv.SelectedNode.Text + ",";
                lvl1 = "OU=" + tv.SelectedNode.Parent.Text + ",";
                lvl = "OU=" + tv.SelectedNode.Parent.Parent.Text + ",";
            }
            List<string> t = new();
            string tmp = ADConnection.GetDomain();
            t = tmp.Split('.').ToList();
            string tmp1 = @"LDAP://" + tmp + "/" + lvl2 + lvl1 + lvl;
            string? tmp2 = default;
            for (int a = 0; a < t.Count; a++)
            {
                tmp2 += "DC=" + t[a] + ",";
            }
            string nameOU = tmp1 + tmp2;
            string domain = nameOU.Remove(nameOU.Length - 1, 1);
            return domain;
        }
        public static void GetComputers(string domain, ListView lv)
        {
            try
            {
                DirectorySearcher searcher = null;
                SearchResultCollection res = null;
                DirectoryEntry entry = new DirectoryEntry(domain);
                DirectorySearcher mySearcher = new DirectorySearcher(entry);
                mySearcher.SearchRoot = entry;
                searcher = new DirectorySearcher(mySearcher.SearchRoot, "(objectClass=computer)", null, SearchScope.Subtree);
                res = searcher.FindAll();
                foreach (SearchResult r in res)
                {
                    var cp = new Object();
                    DirectoryEntry ent = r.GetDirectoryEntry();
                    cp.Name = ent.Name.Remove(0, 3);
                    cp.Description = (string)ent.Properties["description"].Value;
                    cp.Location = (string)ent.Properties["location"].Value;
                    cp.OS = (string)ent.Properties["operatingSystem"].Value;
                    cp.Company = (string)ent.Properties["company"].Value;
                    ListViewItem item1 = new ListViewItem(cp.Name);
                    item1.SubItems.Add(cp.Description);
                    item1.SubItems.Add(cp.Location);
                    item1.SubItems.Add(cp.OS);
                    item1.SubItems.Add(cp.Company);
                    item1.SubItems.Add(" ");
                    item1.SubItems.Add(" ");
                    item1.ImageIndex = 4;
                    lv.Items.AddRange(new ListViewItem[] { item1 });
                }
                mySearcher.Dispose();
                searcher.Dispose();
                entry.Dispose();
            }
            catch
            {

            }
            finally
            {

            }
        }
        public static void ADDTree(string domain, List<TreeAD> TreeADs, TreeView tv)
        {
            try
            {
                DirectorySearcher searcher = null;
                SearchResultCollection res = null;
                DirectoryEntry entry = new DirectoryEntry(domain);
                DirectorySearcher mySearcher = new DirectorySearcher(entry);
                mySearcher.SearchRoot = entry;
                searcher = new DirectorySearcher(mySearcher.SearchRoot, "(objectClass=organizationalunit)", null, SearchScope.OneLevel);
                res = searcher.FindAll();
                foreach (SearchResult r in res)
                {
                    TreeAD ad = new();
                    DirectoryEntry ent = r.GetDirectoryEntry();
                    string cn = ent.Name.Remove(0, 3);
                    ad.Name = ent.Name;
                    ad.Path = ent.Path;
                    TreeADs.Add(ad);
                    tv.Nodes.Add(cn, cn);
                    DirectorySearcher searcher1 = null;
                    SearchResultCollection res1 = null;
                    DirectorySearcher mySearcher1 = new DirectorySearcher(ent);
                    mySearcher1.SearchRoot = ent;
                    searcher1 = new DirectorySearcher(mySearcher1.SearchRoot, "(objectClass=organizationalunit)", null, SearchScope.OneLevel);
                    res1 = searcher1.FindAll();
                    foreach (SearchResult r1 in res1)
                    {
                        TreeAD ad1 = new();
                        DirectoryEntry ent1 = r1.GetDirectoryEntry();
                        string cn1 = ent1.Name.Remove(0, 3);
                        ad1.Name = ent1.Name;
                        ad1.Path = ent1.Path;
                        TreeADs.Add(ad1);
                        tv.Nodes[cn].Nodes.Add(cn1, cn1);

                        DirectorySearcher searcher2 = null;
                        SearchResultCollection res2 = null;
                        DirectorySearcher mySearcher2 = new DirectorySearcher(ent1);
                        mySearcher2.SearchRoot = ent1;
                        searcher2 = new DirectorySearcher(mySearcher2.SearchRoot, "(objectClass=organizationalunit)", null, SearchScope.OneLevel);
                        res2 = searcher2.FindAll();
                        foreach (SearchResult r2 in res2)
                        {
                            TreeAD ad2 = new();
                            DirectoryEntry ent2 = r2.GetDirectoryEntry();
                            string cn2 = ent2.Name.Remove(0, 3);
                            ad2.Name = ent2.Name;
                            ad2.Path = ent2.Path;
                            TreeADs.Add(ad2);
                            tv.Nodes[cn].Nodes[cn1].Nodes.Add(cn2, cn2);
                        }
                        mySearcher2.Dispose();
                        searcher2.Dispose();
                        ent1.Dispose();

                    }
                    mySearcher1.Dispose();
                    searcher1.Dispose();
                    ent.Dispose();
                }
                mySearcher.Dispose();
                searcher.Dispose();
                entry.Dispose();
            }
            finally
            {

            }
        }

    }
}
