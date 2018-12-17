﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UI
{
    public partial class StartPage : Form
    {

        public StartPage()
        {
            InitializeComponent();
            
            if (!mainPanel.Controls.Contains(Encyclopedia.View.LemmaOfTheDayUserControl.Instance))
            {
                mainPanel.Controls.Add(Encyclopedia.View.LemmaOfTheDayUserControl.Instance);
                Encyclopedia.View.LemmaOfTheDayUserControl.Instance.Dock = DockStyle.Fill;
                Encyclopedia.View.LemmaOfTheDayUserControl.Instance.BringToFront();
                
            }
            else
            {
                Encyclopedia.View.LemmaOfTheDayUserControl.Instance.BringToFront();
                
                
            }
                
            
        }

        private void popularButton_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(Encyclopedia.View.SearchResultsUserControl.Instance))
            {
                mainPanel.Controls.Add(Encyclopedia.View.SearchResultsUserControl.Instance);
                Encyclopedia.View.SearchResultsUserControl.Instance.Dock = DockStyle.Fill;
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();

            }
            else
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();

                


        }

        private void logoLabel_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(Encyclopedia.View.LemmaOfTheDayUserControl.Instance))
            {
                mainPanel.Controls.Add(Encyclopedia.View.LemmaOfTheDayUserControl.Instance);
                Encyclopedia.View.LemmaOfTheDayUserControl.Instance.Dock = DockStyle.Fill;
                Encyclopedia.View.LemmaOfTheDayUserControl.Instance.BringToFront();
                
            }
            else
            {
                Encyclopedia.View.LemmaOfTheDayUserControl.Instance.BringToFront();
                
            }
                

        }

        private void recentButton_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(Encyclopedia.View.SearchResultsUserControl.Instance))
            {
                mainPanel.Controls.Add(Encyclopedia.View.SearchResultsUserControl.Instance);
                Encyclopedia.View.SearchResultsUserControl.Instance.Dock = DockStyle.Fill;
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();

            }
            else
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();
        }

        private void filterCheckedListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(Encyclopedia.View.SearchResultsUserControl.Instance))
            {
                mainPanel.Controls.Add(Encyclopedia.View.SearchResultsUserControl.Instance);
                Encyclopedia.View.SearchResultsUserControl.Instance.Dock = DockStyle.Fill;
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();

            }
            else
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();
        }

        private void searchTextbox_OnTextChange(object sender, EventArgs e)
        {
            
            if (!mainPanel.Controls.Contains(Encyclopedia.View.SearchResultsUserControl.Instance))
            {
                mainPanel.Controls.Add(Encyclopedia.View.SearchResultsUserControl.Instance);
                Encyclopedia.View.SearchResultsUserControl.Instance.Dock = DockStyle.Fill;
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();

            }
            else
            {
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();
                //when searching update the list
                Encyclopedia.View.SearchResultsUserControl.Instance.AddToTheResults(searchTextbox.text);
                
            }
                
        }

        private void dateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(Encyclopedia.View.SearchResultsUserControl.Instance))
            {
                mainPanel.Controls.Add(Encyclopedia.View.SearchResultsUserControl.Instance);
                Encyclopedia.View.SearchResultsUserControl.Instance.Dock = DockStyle.Fill;
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();

            }
            else
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();
        }

        
    }
}