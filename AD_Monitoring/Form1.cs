using AD_Monitoring.Infrastructure;
using AD_Monitoring.Models;
using AD_Monitoring.Repository;

namespace AD_Monitoring
{
    public partial class Form1 : Form
    {
        private static ADRepository aDRepository = new();
        private static ModesReposetory modesReposetory = new();

        public Form1()
        {
            InitializeComponent();
            this.listView1.ColumnClick += new ColumnClickEventHandler(this.listView1_ColumnClick);
            label2.Text = "";
            try
            {
                label1.Text = "My domain: " + aDRepository.GetDomain();
                label1.ForeColor = Color.DarkGreen;

                TreeAD trees = aDRepository.GetFullTreeAD();

                foreach (TreeAD tree in trees)
                {
                    treeView1.Nodes.Add(tree.GetName());

                    foreach (TreeAD treechild in tree.GetChildren())
                    {
                        treeView1.Nodes[tree.GetName()].Nodes.Add(treechild.GetName());
                    }
                }
            }
            catch (Exception ex)
            {
                label1.Text = "Domain is unavailable";
                label1.ForeColor = Color.RosyBrown;
                MessageBox.Show("Could not get information about the domain of the computer. \\" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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

                string domain = aDRepository.GetLDAPTreeNodes(treeView1);
                try
                {
                    aDRepository.GetComputers(listView1);
                    label2.Text = "Objects count: " + listView1.Items.Count;
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                            modesReposetory.Open_disk(comp_name);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.ToString(), "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            modesReposetory.Mstsc(comp_name);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                        modesReposetory.Compmgmt(comp_name);
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
                            scanInfo.Login = modesReposetory.PSLogin(comp_name);
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
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            modesReposetory.Share_Folders(comp_name);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            modesReposetory.ShutDown(comp_name, key, richTextBox1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            modesReposetory.ShutDown(comp_name, key, richTextBox1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            string ip = modesReposetory.Ping(comp_name);
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
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            modesReposetory.Printers(comp_name, richTextBox1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            modesReposetory.LocalAdmin(comp_name, richTextBox1);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
            Form2 f2 = new();
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
            if (listView1.Items != null || listView1.Items.Count != 0)
            {
                treeView1.Enabled = false;
                toolStripButton1.Enabled = false;
                string start = "Начало выполнения сканирования - " + DateTime.Now;
                richTextBox1.Text += start + Environment.NewLine;
                listView1.ColumnClick -= listView1_ColumnClick;
                listView1.ColumnClick += new ColumnClickEventHandler(listView2_delete_ColumnClick);
                Zapolnyaem_ip_login();
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

            string end = "Конец выполнения сканирования - " + DateTime.Now;
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
            result_ip = await Task.Run(() => modesReposetory.Ping(cn));
            if (result_ip != null)
            {
                result_user = await Task.Run(() => modesReposetory.PSLogin(cn));
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
                            modesReposetory.CmRcViewer(comp_name);
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
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