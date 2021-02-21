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
    public partial class HistoryManagerForm : Form
    {
        public HistoryManagerForm()
        {
            InitializeComponent();
        }

        private void HistoryManagerForm_Load(object sender, EventArgs e)
        {
            var items = HistoryManager.GetItems();
            historyList.Items.Clear();
            foreach(var item in items) {
                historyList.Items.Add(string.Format("{0} - {1} - {2}", item.Title, item.URL, item.Date));
            }

            // this list below is for the search results
            listcollection.Clear();
            foreach (string str in historyList.Items)
            {
                listcollection.Add(str);
            }
        }
        
        private void deleteButton_Click(object sender, EventArgs e)
        {
            var hm = new HistoryManager();
            foreach(var item in HistoryManager.GetItems())
            {
                for (int i = historyList.SelectedIndices.Count - 1; i >= 0; i--)
                {
                    historyList.Items.RemoveAt(historyList.SelectedIndices[i]);
                    hm.DeleteItem(item.Id);
                }
            }

            //reload after delete
            listcollection.Clear();
            foreach (string str in historyList.Items)
            {
                listcollection.Add(str);
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            var hm = new HistoryManager();
            foreach (var item in HistoryManager.GetItems())
            {
                hm.DeleteItem(item.Id); //deletes from db
            }
            historyList.Items.Clear();
        }

        List<string> listcollection = new List<string>();
        private void searchButton_Click(object sender, EventArgs e) // This one updates the filter when you hit the button
        {
            if (string.IsNullOrEmpty(searchBox.Text) == false)
            {
                historyList.Items.Clear();
                foreach (string str in listcollection)
                {
                    if (str.ToLower().StartsWith(searchBox.Text.ToLower())) // Ignore casing
                    {
                        historyList.Items.Add(str);
                    }
                }
            }
            else if (searchBox.Text == "")
            {
                historyList.Items.Clear();
                foreach (string str in listcollection)
                {
                    historyList.Items.Add(str);
                }
            }
        }
    }
}
