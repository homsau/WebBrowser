
namespace WebBrowser.UI
{
    partial class HistoryManagerForm
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
            this.historyList = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // historyList
            // 
            this.historyList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.historyList.FormattingEnabled = true;
            this.historyList.ItemHeight = 16;
            this.historyList.Items.AddRange(new object[] {
            "URL",
            "Title",
            "Date",
            "RepeatFix"});
            this.historyList.Location = new System.Drawing.Point(0, 0);
            this.historyList.Name = "historyList";
            this.historyList.Size = new System.Drawing.Size(800, 450);
            this.historyList.TabIndex = 0;
            // 
            // HistoryManagerForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.historyList);
            this.Name = "HistoryManagerForm";
            this.Text = "History";
            this.Load += new System.EventHandler(this.HistoryManagerForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox historyList;
    }
}