using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Challenge.Utilities.LogParser;
using Challenge.Utilities.LogParser.Models;

namespace Challenge.Utilities.LogParser.Sample
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            DialogResult result = openLogFileDialog.ShowDialog();

            if ( result == DialogResult.OK)
            {
                filepathTextBox.Text = openLogFileDialog.FileName;
            }

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void parseButton_Click(object sender, EventArgs e)
        {
            string LogPath = filepathTextBox.Text;
            LogParser lp = new LogParser();

            lp.ParseLogFile(LogPath);

            uniqueTextBox.Text = lp.TotalUniqueIpAddresses().ToString();


            List<LogItemTotal> totalAddressList = lp.GetTopIpAddresses(5);

            foreach (LogItemTotal item in totalAddressList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.LogItemGroup;
                lvi.SubItems.Add(item.TotalGroup.ToString());
                addressListView.Items.Add(lvi);
            }


            List<LogItemTotal> totalUrlList = lp.GetTopUrls(3);

            foreach (LogItemTotal item in totalUrlList)
            {
                ListViewItem lvi = new ListViewItem();
                lvi.Text = item.LogItemGroup;
                lvi.SubItems.Add(item.TotalGroup.ToString());
                urlListView.Items.Add(lvi);
            }

        }
    }
}
