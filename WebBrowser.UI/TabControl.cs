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
        bool started = false;

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
                if (started)
                {
                    statusLabel.Text = "Done";
                    timer1.Stop();
                } else if (!started)
                {
                    statusLabel.Text = "Loading...";
                    timer1.Start();
                    toolStripProgressBar1.Value += 1;
                }
                started = !started;
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
            if (started)
            {
                statusLabel.Text = "Done";
                timer1.Stop();
            }
            else
            {
                statusLabel.Text = "Loading...";
                timer1.Start();
                toolStripProgressBar1.Value += 1;
            }
            started = !started;
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

        private void webBrowser1_Navigated_1(object sender, WebBrowserNavigatedEventArgs e)
        {
            //toolStripTextBox1.Text = webBrowser1.Url.ToString();
            this.webBrowser1.Document.MouseOver += new HtmlElementEventHandler(this.Browser_Mouse_Moved);
        }
        // MOUSEOVER LABEL
        private void Browser_Mouse_Moved(object sender, HtmlElementEventArgs e)
        {
            HtmlElement element = webBrowser1.Document.GetElementFromPoint(e.ClientMousePosition); // make html element from mouse position
            string hoverUrl = element.GetAttribute("href").ToString(); // make a string from element's href
            if (element.GetAttribute("href").ToString() == null)
            {
                if (element.Parent != null)
                {
                    hoverUrl = element.Parent.GetAttribute("href").ToString();
                }
            }
            //richTextBox1.Clear();
            //richTextBox1.Text = hoverUrl;
            //hoverLinkLabel.Text = richTextBox1.Text;
            hoverLinkLabel.Text = hoverUrl;
            Console.WriteLine("url: " + hoverUrl + "\n");
        }

        // refreshes page
        private void toolStripButton3_Click(object sender, EventArgs e)
        {
            webBrowser1.Refresh();
            if (started)
            {
                statusLabel.Text = "Done";
                timer1.Stop();
            }
            else
            {
                statusLabel.Text = "Loading...";
                timer1.Start();
                toolStripProgressBar1.Value += 1;
            }
            started = !started;
        }

        // STOP! collaborate and listen... stops the page*
        private void toolStripButton7_Click(object sender, EventArgs e)
        {
            webBrowser1.Stop();
            timer1.Stop();
            statusLabel.Text = "Stopped";
            started = !started;
        }

        private void toolStripButton8_Click(object sender, EventArgs e)
        {
            var itemsForm = new HistoryManagerForm();
            itemsForm.ShowDialog();
        }

        private void toolStripButton6_Click(object sender, EventArgs e) //bookmark button
        {
            var itemsForm = new BookmarkManagerForm();
            currentStateUrl = toolStripTextBox1.Text;
            var item = new BookmarkItem();
            item.URL = toolStripTextBox1.Text;
            item.Title = webBrowser1.DocumentTitle;
            BookmarkManager.AddItem(item);
            itemsForm.ShowDialog();
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e) //history bit
        {
            if (e.Url.Equals(webBrowser1.Url) && webBrowser1.ReadyState == WebBrowserReadyState.Complete)
            {
                var item = new HistoryItem();
                var now = DateTime.Now;
                item.URL = toolStripTextBox1.Text;
                item.Title = webBrowser1.DocumentTitle;
                item.Date = now;
                Console.WriteLine(item.Date);
                HistoryManager.AddItem(item);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if(this.toolStripProgressBar1.Value == 100)
            {
                timer1.Stop();
                this.started = false;
                statusLabel.Text = "Done";
            }
            this.toolStripProgressBar1.Value = 0;
        }

        private void webBrowser1_ProgressChanged(object sender, WebBrowserProgressChangedEventArgs e)
        {
            //if current value and max are ex
            try
            {
                toolStripProgressBar1.Value = Convert.ToInt32(e.CurrentProgress);
                toolStripProgressBar1.Maximum = Convert.ToInt32(e.MaximumProgress);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void toolStripButton4_Click(object sender, EventArgs e) //home button
        {
            var home = "google.com";
            toolStripTextBox1.Text = home;
            if (currentStateUrl != "")
            {
                backStack.Push(currentStateUrl);
            }
            if (started)
            {
                statusLabel.Text = "Done";
                timer1.Stop();
            }
            else
            {
                statusLabel.Text = "Loading...";
                timer1.Start();
                toolStripProgressBar1.Value += 1;
            }
            started = !started;
            Navigate(home);
            currentStateUrl = toolStripTextBox1.Text; // stores current url
            currUrl.Text = currentStateUrl; // stores current url in label i will delete later
        }

       
    }
}
