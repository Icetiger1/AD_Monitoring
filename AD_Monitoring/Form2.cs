using AD_Monitoring.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AD_Monitoring
{
    public partial class Form2 : Form
    {
        private static ModesReposetory modesReposetory = new();

        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text != null || textBox1.Text != "") && (textBox2.Text != null || textBox2.Text != ""))
            {
                Cursor.Current = Cursors.WaitCursor;
                try
                {
                    modesReposetory.Send_msg(textBox1.Text, textBox2.Text);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString(), "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                Cursor.Current = Cursors.Default;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
