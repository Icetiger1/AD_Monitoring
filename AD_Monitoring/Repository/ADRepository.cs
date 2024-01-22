using AD_Monitoring.Models;
using System;
using System.Collections.Generic;
using System.DirectoryServices;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace AD_Monitoring.Repository
{
    public class ADRepository
    {
        private string Domain { get; set; }
        private string LDAP { get; set; }
        private DirectoryEntry Entry { get; set; }


        public ADRepository()
        {
            Domain = GetDomain();
            LDAP = GetLDAPDomain();
            Entry = new DirectoryEntry(LDAP);
        }

        public string GetDomain()
        {
            IPGlobalProperties properties = IPGlobalProperties.GetIPGlobalProperties();
            string domainName = properties.DomainName.ToString();
            return domainName;
        }

        public string GetLDAPDomain()
        {
            List<string> tmpList = this.Domain.Split('.').ToList();
            string tmp2 = @"LDAP://" + this.Domain + "/";
            string? tmp3 = default;
            string domainName;
            for (int i = 0; i < tmpList.Count; i++)
            {
                tmp2 += "DC=" + tmpList[i] + ",";
            }
            domainName = tmp2 + tmp3;
            domainName = domainName.Remove(domainName.Length - 1, 1);
            return domainName;
        }

        public void GetComputers(ListView lv)
        {
            DirectorySearcher? mySearcher = new(Entry)
            {
                SearchRoot = this.Entry
            };

            try
            {
                DirectorySearcher searcher = new
                    (
                        mySearcher.SearchRoot, 
                        "(objectClass=computer)", 
                        null, 
                        SearchScope.Subtree
                    );
                SearchResultCollection? res = searcher.FindAll();
                foreach (SearchResult r in res)
                {
                    DirectoryEntry ent = r.GetDirectoryEntry();

                    Computer cp = new()
                    {
                        Name = ent.Name.Remove(0, 3),
                        Description = (string)ent.Properties["description"].Value,
                        Location = (string)ent.Properties["location"].Value,
                        OS = (string)ent.Properties["operatingSystem"].Value,
                        Company = (string)ent.Properties["company"].Value
                    };

                    cp.AddToListView(lv);
                }
                mySearcher.Dispose();
                searcher.Dispose();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        public static TreeAD GetFullTreeAD(DirectoryEntry entry, ref TreeAD tree)
        {
            DirectorySearcher mySearcher = new(entry)
            {
                SearchRoot = entry
            };

            DirectorySearcher searcher = new
                (
                     mySearcher.SearchRoot,
                     "(objectClass=organizationalunit)",
                     null,
                     SearchScope.OneLevel
                );

            SearchResultCollection? res = searcher.FindAll();
            if (res != null)
            {
                foreach (SearchResult r in res)
                {
                    DirectoryEntry ent = r.GetDirectoryEntry();

                    DirectorySearcher mySearcher2 = new(ent)
                    {
                        SearchRoot = ent
                    };
                    DirectorySearcher searcher2 = new
                        (
                            mySearcher2.SearchRoot,
                            "(objectClass=computer)",
                            null,
                            SearchScope.Subtree
                        );

                    SearchResult? res2 = searcher2.FindOne();
                    if (res2 != null)
                    {
                        //string cn = ent.Name.Remove(0, 3);
                        TreeAD node = new(ent.Name, ent.Path);
                        tree.AddChildren(node);

                    }
                }
            }
            return tree;
        }

        public TreeAD GetFullTreeAD()
        {
            TreeAD tree = new();
            GetFullTreeAD(this.Entry, ref tree);

            return tree;
        }

        public string GetLDAPTreeNodes(TreeView tv)
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

            List<string> tmp = this.Domain.Split('.').ToList();
            string tmp1 = @"LDAP://" + this.Domain + "/" + lvl2 + lvl1 + lvl;
            string? tmp2 = default;

            for (int a = 0; a < tmp.Count; a++)
            {
                tmp2 += "DC=" + tmp[a] + ",";
            }

            string nameOU = tmp1 + tmp2;
            string domain = nameOU.Remove(nameOU.Length - 1, 1);
            return domain;
        }

        public void Dispose()
        {
            this.Entry.Dispose();
        }
    }
}
