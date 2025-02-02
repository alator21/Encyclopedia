﻿namespace Encyclopedia.View
{
    partial class SearchResultsUserControl
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.searchResultsLabel = new System.Windows.Forms.Label();
            this.searchResultsListView = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.SuspendLayout();
            // 
            // searchResultsLabel
            // 
            this.searchResultsLabel.AutoSize = true;
            this.searchResultsLabel.Font = new System.Drawing.Font("Century Gothic", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.searchResultsLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.searchResultsLabel.Location = new System.Drawing.Point(27, 0);
            this.searchResultsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.searchResultsLabel.Name = "searchResultsLabel";
            this.searchResultsLabel.Size = new System.Drawing.Size(309, 47);
            this.searchResultsLabel.TabIndex = 2;
            this.searchResultsLabel.Text = "Search Results ";
            // 
            // searchResultsListView
            // 
            this.searchResultsListView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.searchResultsListView.AutoArrange = false;
            this.searchResultsListView.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.searchResultsListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
            this.searchResultsListView.Font = new System.Drawing.Font("Century Gothic", 18.15652F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(161)));
            this.searchResultsListView.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(41)))), ((int)(((byte)(53)))), ((int)(((byte)(65)))));
            this.searchResultsListView.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.None;
            this.searchResultsListView.Location = new System.Drawing.Point(33, 57);
            this.searchResultsListView.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.searchResultsListView.MultiSelect = false;
            this.searchResultsListView.Name = "searchResultsListView";
            this.searchResultsListView.ShowGroups = false;
            this.searchResultsListView.Size = new System.Drawing.Size(961, 396);
            this.searchResultsListView.TabIndex = 1;
            this.searchResultsListView.TileSize = new System.Drawing.Size(500, 70);
            this.searchResultsListView.UseCompatibleStateImageBehavior = false;
            this.searchResultsListView.View = System.Windows.Forms.View.Details;
            this.searchResultsListView.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.listView1_MouseDoubleClick);
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "";
            this.columnHeader1.Width = 1400;
            // 
            // SearchResultsUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Gainsboro;
            this.Controls.Add(this.searchResultsListView);
            this.Controls.Add(this.searchResultsLabel);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "SearchResultsUserControl";
            this.Size = new System.Drawing.Size(1036, 498);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label searchResultsLabel;
        private System.Windows.Forms.ListView searchResultsListView;
		private System.Windows.Forms.ColumnHeader columnHeader1;
	}
}
