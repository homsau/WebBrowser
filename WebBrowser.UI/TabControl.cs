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
    public partial class tabControl2 : UserControl
    {
        public tabControl2()
        {
            InitializeComponent();
        }

        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                Navigate(toolStripTextBox1.Text);
            }
        }

        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(toolStripTextBox1.Text);
        }

        // navigates to the given url if it's valid
        private void Navigate(String address)
        {
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }
        }

        // refreshes page
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
        }

        // STOP! collaborate and listen... stops the page*
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
        }

        // stacks
        private void backLinks(String address)
        {
            Stack<string> backLinksString = new Stack<String>();
            backLinksString.Push("one");
            return;

        }

        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoBack)
            {
                webBrowser1.GoBack();
            }
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (webBrowser1.CanGoForward)
            {
                webBrowser1.GoForward();
            }
        }
    }
}
