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

namespace WebBrowser.UI
{
    public partial class tabControl2 : UserControl
    {
        static String currentStateUrl = "";
        static Stack<string> backStack = new Stack<string>();
        static Stack<string> forwardStack = new Stack<string>();

        public tabControl2()
        {
            InitializeComponent();
        }

        // HITTING ENTER TO 'GO'
        private void toolStripTextBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                if (currentStateUrl != "")
                {
                    backStack.Push(currentStateUrl);
                }
                Navigate(toolStripTextBox1.Text);
                currentStateUrl = toolStripTextBox1.Text; // stores current url
                currUrl.Text = currentStateUrl; // stores current url in label i will delete later
            }
        }

        // PRESSING GO BUTTON
        private void toolStripButton5_Click(object sender, EventArgs e)
        {
            if (currentStateUrl != "")
            {
                backStack.Push(currentStateUrl);
            }
            Navigate(toolStripTextBox1.Text);
            currentStateUrl = toolStripTextBox1.Text; // stores current url
            currUrl.Text = currentStateUrl; // stores current url in label i will delete later
        }

        // BACK BUTTON
        private void toolStripButton2_Click(object sender, EventArgs e)
        {
            if (backStack.Count == 0 || currentStateUrl == backStack.Peek())
            {
                Console.Write("Not Available\n");
                return;
            }
            else
            {
                forwardStack.Push(currentStateUrl);
                FS.Text = currentStateUrl; // stores current url in label i will delete later
                currentStateUrl = backStack.Peek();
                currUrl.Text = currentStateUrl; // stores current url in label i will delete later
                Navigate(currentStateUrl);
                backStack.Pop();
            }
            /*
            if (webBrowser1.CanGoBack)
            {
                backStack.Push(currentStateUrl);
                BS.Text = currentStateUrl;
                webBrowser1.GoBack();
            }*/
        }

        // FORWARD BUTTON
        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            if (forwardStack.Count == 0 || currentStateUrl == forwardStack.Peek())
            {
                Console.Write("Not Available\n");
                return;
            } else
            {
                backStack.Push(currentStateUrl);
                BS.Text = currentStateUrl; // stores current url in label i will delete later
                currentStateUrl = forwardStack.Peek();
                currUrl.Text = currentStateUrl; // stores current url in label i will delete later
                Navigate(currentStateUrl);
                forwardStack.Pop();
            }
            /*
            if (webBrowser1.CanGoForward)
            {
                backStack.Push(currentStateUrl);
                FS.Text = currentStateUrl;
                webBrowser1.GoForward();
            }*/
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

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            var itemsForm = new HistoryManagerForm();
            itemsForm.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e)
        {
            var itemsForm = new BookmarkManagerForm();
            currentStateUrl = toolStripTextBox1.Text;
            //MessageBox.Show(currentStateUrl);
            var item = new BookmarkItem();
            item.URL = toolStripTextBox1.Text;
            item.Title = webBrowser1.DocumentTitle;
            BookmarkManager.AddItem(item);
            itemsForm.ShowDialog();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            var item = new HistoryItem();
            DateTime now = DateTime.Now;
            item.URL = toolStripTextBox1.Text;
            item.Title = webBrowser1.DocumentTitle;
            item.Date = now;
            HistoryManager.AddItem(item);
        }
    }
}
