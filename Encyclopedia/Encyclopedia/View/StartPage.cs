﻿using Encyclopedia.Controller;
using Encyclopedia.Model;
using Encyclopedia.View;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace UI
{
    public partial class StartPage : Form
    {
		// stores the username of the logged-in user
		public static string username = null;

		//a list with all the controls to be hidden when login is successfull
		public List<Control> controlsBeforeLogin = new List<Control>();
        //the new leftpanel 
        public AfterLoginUserControl afterLoginPanel;
        //a public variable to hold everything --- used instead of private Panel leftPanel
        public Panel newLeftPanel;
        //user account
        public Account account;


        //list with filters to be checked
        public List<string> filterList = new List<string>();     
        
        //Opens LemmaOfTheDayUserControl in mainPanel when application starts
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
            mainPanel.Controls.Add(Encyclopedia.View.LemmaViewUserControl.Instance);

            //copy all the controls of private left panel to newLeftPanel
            newLeftPanel = leftPanel;
            //remove the private left panel
            this.Controls.Remove(leftPanel);
            //add the newLeftPanel
            this.Controls.Add(newLeftPanel);
        }

        private void StartPage_Load(object sender, EventArgs e)
        {
            this.FormBorderStyle = FormBorderStyle.Sizable;
            this.WindowState = FormWindowState.Maximized;
            this.MaximumSize = this.Size;
            this.FormBorderStyle = FormBorderStyle.None;
        }

        //Opens SearchResultsUserControl in mainPanel when popularButton is clicked
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

        //Opens LemmaOfTheDayUserControl in mainPanel when Logo is clicked
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

        //Opens SearchResultsUserControl in mainPanel when recentButton is clicked
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
        /*
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
        */
        /*
        private void searchTextbox_OnTextChange(object sender, EventArgs e)
        {
            
            if (!mainPanel.Controls.Contains(Encyclopedia.View.SearchResultsUserControl.Instance))
            {
                mainPanel.Controls.Add(Encyclopedia.View.SearchResultsUserControl.Instance);
                Encyclopedia.View.SearchResultsUserControl.Instance.Dock = DockStyle.Fill;
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();
                Search();

            }
            else
            {
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();
                Search();
                
            }
                
        }
        */
        private void Search()
        {
            //add the the checked items to the filterlist
            foreach (Object ob in filterCheckedListBox.CheckedItems)
            {
                filterList.Add(ob.ToString());
            }

            Encyclopedia.View.SearchResultsUserControl.Instance.AddToTheResults(searchTextBox.Text, filterList);

        }


        //Opens SearchResultsUserControl in mainPanel when we choose a date
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


        private void searchButton_Click(object sender, EventArgs e)
        {
            if (!mainPanel.Controls.Contains(Encyclopedia.View.SearchResultsUserControl.Instance))
            {
                mainPanel.Controls.Add(Encyclopedia.View.SearchResultsUserControl.Instance);
                Encyclopedia.View.SearchResultsUserControl.Instance.Dock = DockStyle.Fill;
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();

            }
            else
                Encyclopedia.View.SearchResultsUserControl.Instance.BringToFront();

            Search();
            //clear the filter list
            filterList.Clear();
        }

        private void newUserLinkLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            RegisterForm registerForm = new RegisterForm();
            registerForm.ShowDialog();
        }

        

        private void minimizePictureBox_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void closePictureBox_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void loginButton_Click(object sender, EventArgs e)
        {
            //Take user input from fields
            string username = usernameTextBox.Text;
            string password = passwordTextBox.Text;

            //crate a handler to validate user information -- returns true if user exists otherwise false
            LoginHandler handler = new LoginHandler(username, password);
            bool doesUserExist = handler.ValidateAccount();

            Console.WriteLine(doesUserExist);

            if (doesUserExist)
            {
                //User Exists
                //change the left panel to the new AfterLoginUserControl
                afterLoginPanel = new AfterLoginUserControl();
                afterLoginPanel.Account = DBConnect.GetAccountByUsername(username);
                afterLoginPanel.SetImage();
                changePanelControls();
            }
            else
            {
                //User doesnt Exists
                //change the feedback label -- just for demo
                feedbackLabel.Text = "USER DOESNT EXISTS";
            }
            
        }

        private void changePanelControls()
        {
            
            foreach (Control x in newLeftPanel.Controls)
            {
                controlsBeforeLogin.Add(x);
                x.Visible = false;
            }

            leftPanel.Controls.Add(afterLoginPanel);
        }

		private void FeedbackPanel_Paint(object sender, PaintEventArgs e)
		{

		}

        private void savePictureBox_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog savefile = new SaveFileDialog();
                // set a default file name
                savefile.FileName = "somelemmma";
                // set filters - this can be done in properties as well
                savefile.Filter = "Pdf Files|*.pdf";

                if (savefile.ShowDialog() == DialogResult.OK)
                {
                    string path = savefile.FileName;
                    string lemmaTitle = "American_Literature_(academic_discipline)";
                    PDF.exportToPDF(lemmaTitle, path);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // show the exception message in order to inform the user
                Console.WriteLine(ex.Message);
            }
        }
    }
}