using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PAIN1
{
    public partial class MainForm : Form
    {
        Document document = new Document();

        public MainForm()
        {
            InitializeComponent();
            IsMdiContainer = true;
        }

        public void setCounter(string text)
        {
            this.toolStripStatusCount.Text = text;
        }

        private void newWindowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RecordingsForm recordingsForm = new RecordingsForm(document);
            recordingsForm.MdiParent = this;
            recordingsForm.Show();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            RecordingsForm recordingsForm = new RecordingsForm(document);
            recordingsForm.MdiParent = this;
            e.Cancel = false;
            return;
        }

    }
}
