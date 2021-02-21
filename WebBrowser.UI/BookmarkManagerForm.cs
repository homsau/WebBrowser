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
    public partial class BookmarkManagerForm : Form
    {
        public BookmarkManagerForm()
        {
            InitializeComponent();
        }

        private void BookmarkManagerForm_Load(object sender, EventArgs e)
        {
            var items = BookmarkManager.GetItems();
            bookmarkList.Items.Clear();
            foreach (var item in items)
            {
                bookmarkList.Items.Add(string.Format("{0} - {1}", item.Title, item.URL));
            }

            // this list below is for the search results
            listcollection.Clear();
            foreach (string str in bookmarkList.Items)
            {
                listcollection.Add(str);
            }
        }

        List<string> listcollection = new List<string>();
        private void searchButton_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(searchBox.Text) == false)
            {
                bookmarkList.Items.Clear();
                foreach (string str in listcollection)
                {
                    if (str.ToLower().StartsWith(searchBox.Text.ToLower())) // Ignore casing
                    {
                        bookmarkList.Items.Add(str);
                    }
                }
            }
            else if (searchBox.Text == "")
            {
                bookmarkList.Items.Clear();
                foreach (string str in listcollection)
                {
                    bookmarkList.Items.Add(str);
                }
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            
            var bm = new BookmarkManager();
            foreach (var item in BookmarkManager.GetItems())
            {
                for (int i = bookmarkList.SelectedIndices.Count - 1; i >= 0; i--)
                {
                bookmarkList.Items.RemoveAt(bookmarkList.SelectedIndices[i]);
                    bm.DeleteItem(item.Id);
                }
            }

            //reload after delete
            listcollection.Clear();
            foreach (string str in bookmarkList.Items)
            {
                listcollection.Add(str);
            }
        }
    }
}
