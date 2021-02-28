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
                "\nOne thing I want to implement in the future is a 'Dark' mode\n\nStudent ID: 902416606\n");
        }

        //NEW TAB FROM MENU
        private void newTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tabControl2 webControl = new tabControl2();
            webControl.Dock = DockStyle.Fill;
            TabPage tp = new TabPage();
            tp.Text = "New Tab";
            tp.Controls.Add(webControl);
            this.MasterTabControl.TabPages.Add(tp);
            this.MasterTabControl.SelectTab(tp);
            this.MasterTabControl.Focus();
        }

        private void closeCurrentTabToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var tIndex = MasterTabControl.TabIndex;
            if (tIndex >= 0 && tIndex < MasterTabControl.TabPages.Count)
            {
                var tabIndex = this.MasterTabControl.SelectedIndex;
                this.MasterTabControl.TabPages.Remove(MasterTabControl.SelectedTab);
                if (tabIndex >= 1) // logic to prevent trying to close more tabs than exist
                {
                    this.MasterTabControl.SelectTab(tabIndex - 1);
                }
                else
                {
                    this.MasterTabControl.SelectTab(tabIndex);
                }
                this.MasterTabControl.Focus();
            }
        }

        // new/close tab with key bindings
        public void MasterTabControl_KeyDown(object sender, KeyEventArgs e)
        {
            tabControl2 webControl = new tabControl2();
            webControl.Dock = DockStyle.Fill;
            TabPage tp = new TabPage();
            tp.Text = "New Tab";
            tp.Controls.Add(webControl);
            if (e.Control && (e.KeyCode == Keys.T)) //opens new tab
            {
                this.MasterTabControl.TabPages.Add(tp);
                this.MasterTabControl.SelectTab(tp);
                this.MasterTabControl.Focus(); // keeps tab control focused so we can add/close more tabs
            }
            if (e.Control && (e.KeyCode == Keys.W)) //closes tab
            {
                if (MasterTabControl.TabPages.Count > 1) 
                {
                    var tabIndex = this.MasterTabControl.SelectedIndex;
                    this.MasterTabControl.TabPages.Remove(MasterTabControl.SelectedTab);
                    if (tabIndex >= 1) // logic to prevent trying to close more tabs than exist
                    {
                        this.MasterTabControl.SelectTab(tabIndex - 1);
                    } else
                    {
                        this.MasterTabControl.SelectTab(tabIndex);
                    }
                    this.MasterTabControl.Focus();
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

        private void printPageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //nothing happening yet...
        }

        private void savePageAsHTMLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //nothing happening yet...
        }
    }
}