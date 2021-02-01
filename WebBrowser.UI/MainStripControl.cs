using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
    }
}
