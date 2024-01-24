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
            this.listViewAD.ColumnClick += new ColumnClickEventHandler(this.ListViewAD_ColumnClick);
            label2.Text = "";
            try
            {
                label1.Text = "My domain: " + aDRepository.GetDomain();
                label1.ForeColor = Color.DarkGreen;
                List<TreeAD> treeADs = new List<TreeAD>();
                aDRepository.ADDTree(treeADs, treeView1);
                //TreeAD trees = aDRepository.GetFullTreeAD();

                //foreach (TreeAD tree in trees)
                //{
                //    treeView1.Nodes.Add(tree.GetName());
                //    if (tree.GetChildren().Count != 0)
                //    {
                //        foreach (TreeAD treechild in tree.GetChildren())
                //        {
                //            treeView1.Nodes[tree.GetName()].Nodes.Add(treechild.GetName());
                //        }
                //    }
                //}
            }
            catch (Exception ex)
            {
                label1.Text = "Domain is unavailable";
                label1.ForeColor = Color.RosyBrown;
                MessageBox.Show("Could not get information about the domain of the computer. \\" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //sorting listView1
        private void ListViewAD_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            this.listViewAD.ListViewItemSorter = new ListViewItemComparer(e.Column);
            listViewAD.Sort();
        }

        private void listView1_delete_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            //fake method
        }

        private void TreeViewAD_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Nodes.Count == 0)
            {
                listViewAD.Items.Clear();

                try
                {
                    aDRepository.GetComputers(listViewAD);
                    label2.Text = "Objects count: " + listViewAD.Items.Count;
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

        private void DiscCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewAD.Items.Count; i++)
            {
                if (listViewAD.Items[i].Selected == true)
                {
                    string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
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

        private void RemoteControlToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewAD.Items.Count; i++)
            {
                if (listViewAD.Items[i].Selected == true)
                {
                    string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
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

        private void ComputerManagementToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewAD.Items.Count; i++)
            {
                if (listViewAD.Items[i].Selected == true)
                {
                    string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
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

        private void WhoOnlineToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            for (int i = 0; i < listViewAD.Items.Count; i++)
            {
                var scanInfo = new ScanInfo();
                if (listViewAD.Items[i].Selected == true)
                {
                    string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            scanInfo.Login = modesReposetory.PSLogin(comp_name);
                            if (scanInfo.Login != null)
                            {
                                listViewAD.Items[i].SubItems[6].Text = scanInfo.Login;
                            }
                            else
                            {
                                listViewAD.Items[i].SubItems[6].Text = "Нет данных";
                            }
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            listViewAD.Items[i].SubItems[6].Text = "Нет данных";
                        }
                    }
                    else
                    {

                    }
                }
            }
            Cursor.Current = Cursors.Default;
        }

        private void ShareFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewAD.Items.Count; i++)
            {
                if (listViewAD.Items[i].Selected == true)
                {
                    string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
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

        private void ShutdownToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewAD.Items.Count; i++)
            {
                if (listViewAD.Items[i].Selected == true)
                {
                    string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            var key = " /s /f /c \"Компьютер будет выключен в течении 1 минуты. Во избежании потери данных закройте все открытые файлы и программы.\" /t 60";
                            modesReposetory.ShutDown(comp_name, key);
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

        private void RebootToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewAD.Items.Count; i++)
            {
                if (listViewAD.Items[i].Selected == true)
                {
                    string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            var key = " /r /f /c \"Компьютер будет перезагружен в течении 1 минуты. Во избежании потери данных закройте все открытые файлы и программы.\" /t 60";
                            modesReposetory.ShutDown(comp_name, key);
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

        private void PingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewAD.Items.Count; i++)
            {
                if (listViewAD.Items[i].Selected == true)
                {
                    string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
                    if (comp_name != null)
                    {
                        try
                        {
                            string ip = modesReposetory.Ping(comp_name);
                            if (ip != null)
                            {
                                listViewAD.Items[i].SubItems[5].Text = ip;
                                listViewAD.Items[i].ImageIndex = 3;
                            }
                            else
                            {

                                listViewAD.Items[i].SubItems[5].Text = " ";
                                listViewAD.Items[i].ImageIndex = 4;
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

        private void PrintersToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewAD.Items.Count; i++)
            {
                if (listViewAD.Items[i].Selected == true)
                {
                    string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
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

        private void LocalAdminToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            for (int i = 0; i < listViewAD.Items.Count; i++)
            {
                if (listViewAD.Items[i].Selected == true)
                {
                    string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
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

        private void SentMessageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form2 f2 = new();
            for (int i = 0; i < listViewAD.Items.Count; i++)
            {
                if (listViewAD.Items[i].Selected == true)
                {
                    string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
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
            if (listViewAD.Items != null || listViewAD.Items.Count != 0)
            {
                treeView1.Enabled = false;
                runScanerButton.Enabled = false;
                string start = "Начало выполнения сканирования - " + DateTime.Now;
                richTextBox1.Text += start + Environment.NewLine;
                listViewAD.ColumnClick -= ListViewAD_ColumnClick;
                listViewAD.ColumnClick += new ColumnClickEventHandler(listView1_delete_ColumnClick);
                Zapolnyaem_ip_login();
            }
        }
        private async void Zapolnyaem_ip_login()
        {
            int b = listViewAD.Items.Count;
            var tasks = new List<Task>();
            var tasks2 = new List<Task>();

            for (int i = 0; i < b; i++)
            {
                string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
                tasks.Add(Task.Run(() => AsyncGetIP(comp_name, b)));
            }
            await Task.WhenAll(tasks);

            string end = "Конец выполнения сканирования - " + DateTime.Now;
            richTextBox1.Text += end + Environment.NewLine;
            listViewAD.ColumnClick -= listView1_delete_ColumnClick;
            listViewAD.ColumnClick += new ColumnClickEventHandler(ListViewAD_ColumnClick);
            runScanerButton.Enabled = true;
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
                        if (listViewAD.Items[j].SubItems[0].Text.Contains(cn))
                        {
                            listViewAD.Items[j].ImageIndex = 3;
                            listViewAD.RedrawItems(j, j, true);
                            listViewAD.Items[j].SubItems[5].Text = result_ip;
                            if (result_user != null)
                            {
                                listViewAD.Items[j].SubItems[6].Text = result_user;
                            }
                            else
                            {
                                listViewAD.Items[j].SubItems[6].Text = " ";
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
                        if (listViewAD.Items[j].SubItems[0].Text.Contains(cn))
                        {
                            result_ip = "";
                            listViewAD.Items[j].SubItems[5].Text = result_ip;
                            listViewAD.Items[j].ImageIndex = 4;
                            listViewAD.RedrawItems(j, j, false);
                        }
                    }));
                }
            }
        }

        private void sCCMConnectionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < listViewAD.Items.Count; i++)
            {
                if (listViewAD.Items[i].Selected == true)
                {
                    string comp_name = listViewAD.Items[i].SubItems[0].Text.ToString();
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
            if (listViewAD.Items.Count != 0)
            {
                try
                {
                    Cursor.Current = Cursors.WaitCursor;
                    ExportToExcel.WriteExcelFile(listViewAD);
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