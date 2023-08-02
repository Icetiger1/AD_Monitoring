using OfficeOpenXml;
using System.Diagnostics;
using System.DirectoryServices;
using System.DirectoryServices.ActiveDirectory;
using System.Net.NetworkInformation;

namespace AD_Monitoring
{
    public partial class Form1 : Form
    {
        public static List<TreeAD> TreeADs = new List<TreeAD>();

        public Form1()
        {
            InitializeComponent();
            this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
            label2.Text = "";
            try
            {
                string top = ADConnection.GetDomain();
                label1.Text = "My domain: " + top;
                label1.ForeColor = Color.DarkGreen;
                string ldap = ADConnection.GetLDAPDomain();
                ADConnection.ADDTree(ldap, TreeADs, treeView1);
            }
            catch (Exception ex)
            {
                label1.Text = "Domain is unavailable";
                label1.ForeColor = Color.RosyBrown;
                MessageBox.Show("Could not get information about the domain of the computer. " + ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //sorting listView1
        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            listView1.Sort();
        }

        private void listView2_delete_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //fake method
        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {

            if (treeView1.SelectedNode.Nodes.Count == 0)
            {
                listView1.Items.Clear();

                string domain = ADConnection.GetLDAPTreeNodes(treeView1);
                try
                {
                    ADConnection.GetComputers(domain, listView1);
                    label2.Text = "Objects count: " + listView1.Items.Count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                treeView1.SelectedNode.Expand();
            }


        }

        private void discCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            Modes.Open_disk(comp_name);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void remoteControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            Modes.mstsc(comp_name);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void computerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        Modes.compmgmt(comp_name);
                    }
                    else
                    {

                    }
                }
            }
        }

        private void whoOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            for (int i = 0; i < listView1.Items.Count; i++)
            {
                var scanInfo = new ScanInfo();
                if (listView1.Items[i].Selected == true)
                {
                    string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            scanInfo.Login = Modes.PSLogin(comp_name);
                            if (scanInfo.Login != null)
                            {
                                listView1.Items[i].SubItems[6].Text = scanInfo.Login;
                            }
                            else
                            {
                                listView1.Items[i].SubItems[6].Text = "Нет данных";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            listView1.Items[i].SubItems[6].Text = "Нет данных";
                        }
                    }
                    else
                    {

                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void shareFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            Modes.Share_Folders(comp_name);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void shutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            var key = " /s /f /c \"Компьютер будет выключен в течении 1 минуты. Во избежании потери данных закройте все открытые файлы и программы.\" /t 60";
                            Modes.ShutDown(comp_name, key, richTextBox1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void rebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            var key = " /r /f /c \"Компьютер будет перезагружен в течении 1 минуты. Во избежании потери данных закройте все открытые файлы и программы.\" /t 60";
                            Modes.ShutDown(comp_name, key, richTextBox1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void pingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            string ip = Modes.Ping(comp_name);
                            if (ip != null)
                            {
                                listView1.Items[i].SubItems[5].Text = ip;
                                listView1.Items[i].ImageIndex = 3;
                            }
                            else
                            {

                                listView1.Items[i].SubItems[5].Text = " ";
                                listView1.Items[i].ImageIndex = 4;
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void printersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            Modes.Printers(comp_name, richTextBox1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void localAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            Modes.LocalAdmin(comp_name, richTextBox1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {

                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void sentMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2();
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        f2.textBox1.Text = comp_name;
                        f2.Show();
                    }
                }
            }
        }

        private void ScanButton1_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != 0)
            {
                treeView1.Enabled = false;
                toolStripButton1.Enabled = false;
                string start = "Start of the scan - " + DateTime.Now;
                richTextBox1.Text += start + Environment.NewLine;
                listView1.ColumnClick -= listView1_ColumnClick;
                listView1.ColumnClick += new ColumnClickEventHandler(listView2_delete_ColumnClick);
                Zapolnyaem_ip_login();
            }
            else
            {
                richTextBox1.Text += "There is no data for scanning. Select an item in the treeview to display the data." + Environment.NewLine;
            }
        }

        private async void Zapolnyaem_ip_login()
        {
            int b = listView1.Items.Count;
            var tasks = new List<Task>();
            var tasks2 = new List<Task>();
            for (int i = 0; i < b; i++)
            {
                string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                tasks.Add(Task.Run(() => AsyncGetIP(comp_name, b)));
            }
            await Task.WhenAll(tasks);
            string end = "End of scan execution - " + DateTime.Now;
            richTextBox1.Text += end + Environment.NewLine;
            listView1.ColumnClick -= listView2_delete_ColumnClick;
            listView1.ColumnClick += new ColumnClickEventHandler(listView1_ColumnClick);
            toolStripButton1.Enabled = true;
            treeView1.Enabled = true;
        }

        private async Task AsyncGetIP(string cn, int count)
        {
            string? result_ip = null;
            string? result_user = null;
            result_ip = await Task.Run(() => Modes.Ping(cn));
            if (result_ip != null)
            {
                result_user = await Task.Run(() => Modes.PSLogin(cn));
                for (int j = 0; j < count; j++)
                {
                    this.Invoke(new Action(() =>
                    {
                        if (listView1.Items[j].SubItems[0].Text.Contains(cn))
                        {
                            listView1.Items[j].ImageIndex = 3;
                            listView1.RedrawItems(j, j, true);
                            listView1.Items[j].SubItems[5].Text = result_ip;
                            if (result_user != null)
                            {
                                listView1.Items[j].SubItems[6].Text = result_user;
                            }
                            else
                            {
                                listView1.Items[j].SubItems[6].Text = " ";
                            }
                        }
                    }));
                }

            }
            else
            {
                for (int j = 0; j < count; j++)
                {
                    this.Invoke(new Action(() =>
                    {
                        if (listView1.Items[j].SubItems[0].Text.Contains(cn))
                        {
                            result_ip = "";
                            listView1.Items[j].SubItems[5].Text = result_ip;
                            listView1.Items[j].ImageIndex = 4;
                            listView1.RedrawItems(j, j, false);
                        }
                    }));
                }
            }
        }

        private void sCCMConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listView1.Items.Count; i++)
            {
                if (listView1.Items[i].Selected == true)
                {
                    string comp_name = listView1.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            Modes.CmRcViewer(comp_name);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            //Export to excel information from listView1
            if (listView1.Items.Count != 0)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ExportToExcel.Excel(listView1);
                    Cursor.Current = Cursors.Default;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

        }
    }
}