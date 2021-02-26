using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebBrowser.Logic;

/*
 * Future Features:
 * make sure url updates each text box per tab
 * hold down mouse on back/forward buttons to show multiple pages (up to 5 maybe?)
 */
namespace WebBrowser.UI
{
    public partial class MainStripControl : Form
    {
        public MainStripControl()
        {
            InitializeComponent();
        }

        private void exitWebBrowserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void aboutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hey there, my name is James Cowart and this is my first browser!\n" +
                "I've made a lot of websites and a few apps before, so I'm excited about this.\n" +
                "\nOne thing I want to be sure to implement is a 'Dark' mode\n\nStudent ID: 902416606\n");
        }

        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tp = new TabPage();
            tp.Text = "New Tab";
            tp.Controls.Add(new tabControl2());
            MasterTabControl.TabPages.Add(tp);
            MasterTabControl.SelectTab(MasterTabControl.TabPages.Count - 1);
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // this isn't done but I feel like this section will help me later
            // was thinking of ways to get my tabs to go to the properly selected one upon open/close
            var tIndex = MasterTabControl.TabIndex;
            MasterTabControl.TabPages.Remove(MasterTabControl.SelectedTab);
            if (tIndex >= 0 && tIndex <= MasterTabControl.TabPages.Count)
            {
                //MasterTabControl.SelectTab(tIndex);
                this.MasterTabControl.TabPages.Remove(MasterTabControl.SelectedTab);
            } 
        }

        private void MasterTabControl_KeyDown(object sender, KeyEventArgs e)
        {
            var tp = new TabPage();
            tp.Text = "New Tab";
            tp.Controls.Add(new tabControl2());
            if (e.Control && (e.KeyCode == Keys.T)) //opens new tab
            {
                this.MasterTabControl.TabPages.Add(tp);
            }
            if (e.Control && (e.KeyCode == Keys.W)) //closes tab
            {
                this.MasterTabControl.TabPages.Remove(MasterTabControl.SelectedTab);
                if (MasterTabControl.TabPages.Count > 1) 
                // I THINK THIS CODE WILL LATER HELP ME AUTO SELECT THE CORRECT TAB AFTER CLOSING
                // AT LEAST HELP WITH BRAINSTORMING
                {
                   // MasterTabControl.SelectTab(MasterTabControl.TabPages.Count - 1);
                }
            }
        }

        private void manageHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemsForm = new HistoryManagerForm();
            itemsForm.ShowDialog();
        }

        private void manageBoomarksToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var itemsForm = new BookmarkManagerForm();
            itemsForm.ShowDialog();
        }

        private void clearHistoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var hm = new HistoryManager();
            foreach (var item in HistoryManager.GetItems())
            {
                hm.DeleteItem(item.Id); //deletes from db
            }
        }
    }
}