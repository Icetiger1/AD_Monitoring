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
                MessageBox.Show("Could not get information about the domain of the computer. \\" + ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void listView1_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            // Установка свойства ListViewItemSorter на новый объект
            // ListViewItemComparer.
            this.listView1.ListViewItemSorter = new ListViewItemComparer(e.Column);
            // Вызов метода сортировки для ручной сортировки.
            listView1.Sort();
        }

        private void listView2_delete_ColumnClick(object sender, ColumnClickEventArgs e)
        {

        }

        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            if (treeView1.SelectedNode.Nodes == null)
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
                    MessageBox.Show(ex.ToString(), "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                        catch
                        {
                            MessageBox.Show("Access denied!", "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                            scanInfo.Login = Modes.PSLogin(comp_name, richTextBox1);
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
                            Modes.ShutDown(comp_name, key, richTextBox1);
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
                            Modes.ShutDown(comp_name, key, richTextBox1);
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
                            listView1.Items[i].SubItems[5].Text = Modes.Ping(comp_name);
                            listView1.Items[i].ImageIndex = 3;
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
                            richTextBox1.Text += "Принтеры " + comp_name + ":" + Environment.NewLine;
                            Modes.Printers(comp_name);
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
                            Modes.LocalAdmin(comp_name, richTextBox1);
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

        private async void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (listView1.Items.Count != null)
            {
                string start = "Начало выполнения сканирования - " + DateTime.Now;
                richTextBox1.Text += start + Environment.NewLine;
                listView1.ColumnClick -= listView1_ColumnClick;
                listView1.ColumnClick += new ColumnClickEventHandler(listView2_delete_ColumnClick);
                int b = listView1.Items.Count;
                var tasks = new List<Task>();
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
            }
        }
        private async Task AsyncGetIP(string cn, int count)
        {
            string result = default;
            result = await Task.Run(() => Modes.Ping(cn));

            if (result!= null)
            {
                for (int j = 0; j < count; j++)
                {
                    this.Invoke(new Action(() =>
                    {
                        if (listView1.Items[j].SubItems[0].Text.Contains(cn))
                        {
                            listView1.Items[j].ImageIndex = 4;
                            listView1.RedrawItems(j, j, true);
                            listView1.Items[j].SubItems[5].Text = result;
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
                            result = "";
                            listView1.Items[j].SubItems[5].Text = result;
                            listView1.Items[j].ImageIndex = 3;
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
                            MessageBox.Show(ex.Message, "Ошибка!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    else
                    {

                    }
                }
            }
        }
    }
}