
namespace WebBrowser.UI
{
    partial class BookmarkManagerForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.bookmarkList = new System.Windows.Forms.ListBox();
            this.searchBox = new System.Windows.Forms.TextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // bookmarkList
            // 
            this.bookmarkList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bookmarkList.FormattingEnabled = true;
            this.bookmarkList.ItemHeight = 16;
            this.bookmarkList.Items.AddRange(new object[] {
            "URL",
            "Title"});
            this.bookmarkList.Location = new System.Drawing.Point(0, 0);
            this.bookmarkList.Name = "bookmarkList";
            this.bookmarkList.Size = new System.Drawing.Size(800, 450);
            this.bookmarkList.TabIndex = 0;
            // 
            // searchBox
            // 
            this.searchBox.Location = new System.Drawing.Point(526, 416);
            this.searchBox.Name = "searchBox";
            this.searchBox.Size = new System.Drawing.Size(100, 22);
            this.searchBox.TabIndex = 8;
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(632, 415);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(75, 23);
            this.searchButton.TabIndex = 7;
            this.searchButton.Text = "Search";
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(713, 415);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(75, 23);
            this.deleteButton.TabIndex = 5;
            this.deleteButton.Text = "Delete";
            this.deleteButton.UseVisualStyleBackColor = true;
            // 
            // BookmarkManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.searchBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.bookmarkList);
            this.Name = "BookmarkManagerForm";
            this.Text = "BookmarkManagerForm";
            this.Load += new System.EventHandler(this.BookmarkManagerForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ListBox bookmarkList;
        private System.Windows.Forms.TextBox searchBox;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Button deleteButton;
    }
}