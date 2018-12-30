﻿using Encyclopedia.Controller;
using Encyclopedia.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Encyclopedia.View
{
    public partial class ProfileForm : Form
    {
        public Account Account { set; get; }
        public bool UpdatedSuccessfully { set; get; }

        public ProfileForm(Account account)
        {
            InitializeComponent();
            string[] educationLevelNames = DBConnect.GetEducationLevels();
            string[] roleNames = DBConnect.GetRoles();
            foreach(string str in educationLevelNames)
            {
                educationLevelCB.Items.Add(str);
            }
            foreach(string str in roleNames)
            {
                roleCB.Items.Add(str);
            }
            this.Account = account;
            SetAccountData();
            UpdatedSuccessfully = false;
        }

        private void imagePathTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void imagePathLabel_Click(object sender, EventArgs e)
        {

        }

        private void descriptionRTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void descriptionLabel_Click(object sender, EventArgs e)
        {

        }

        private void roleCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void professionLabel_Click(object sender, EventArgs e)
        {

        }

        private void educationLevelCB_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void educationLabel_Click(object sender, EventArgs e)
        {

        }

        private void dateOfBirthDTP_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateOfBirthLabel_Click(object sender, EventArgs e)
        {

        }

        private void genderFemaleRB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void genderMaleRB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void closePictureBox_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetAccountData()
        {
            nameTextBox.Text = Account.User.Name;
            surnameTextBox.Text = Account.User.Surname;
            telTexBox.Text = Account.User.Tel;
            emailTextBox.Text = Account.Email;
            usernameTextBox.Text = Account.Username;
            if (Account.User.Gender == 'M')
                genderMaleRB.Checked = true;
            else if (Account.User.Gender == 'F')
                genderFemaleRB.Checked = false;
            dateOfBirthDTP.Value = Account.User.DateOfBirth;

            educationLevelCB.SelectedIndex = Account.User.EducationLevel.Id - 1;
            roleCB.SelectedIndex = Account.User.Role.Id - 1;
            descriptionRTB.Text = Account.User.Description;
            if (Account.User.Image == null)
            {
                //no picture
            }
            else
            {
                imagePB.Image = (Bitmap)((new ImageConverter()).ConvertFrom(Account.User.Image));
            }

        }

        private void editButton_Click(object sender, EventArgs e)
        {
            nameTextBox.Enabled = true;
            surnameTextBox.Enabled = true;
            telTexBox.Enabled = true;
            passwordTextBox.Enabled = true;
            passwordConfirmTextBox.Enabled = true;
            genderGroupBox.Enabled = true;
            dateOfBirthDTP.Enabled = true;
            roleCB.Enabled = true;
            educationLevelCB.Enabled = true;
            descriptionRTB.Enabled = true;
            imagePathTB.Enabled = true;
            saveButton.Visible = true;
            browseButton.Enabled = true;
        }

        private void browseButton_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog1 = new OpenFileDialog();
                openFileDialog1.Title = "Please select an image for your account.";

                // show only image file formats
                openFileDialog1.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG;*.GIF)|*.BMP;*.JPG;*.JPEG;*.PNG;*.GIF|All files (*.*)|*.*";
                if (openFileDialog1.ShowDialog() == DialogResult.OK)
                {
                    // check if the file size isn't bigger than 16 MB approx. (measured in bytes)
                    long imageLength = new FileInfo(openFileDialog1.FileName).Length;
                    if (imageLength > 16250215)
                    {
                        throw new ArgumentOutOfRangeException(nameof(imageLength));
                    }

                    imagePathTB.Text = openFileDialog1.FileName;
                    imagePB.Image = Image.FromFile(openFileDialog1.FileName);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // show the exception message in order to inform the user
                Console.WriteLine(ex.Message);
            }
        }


        private void saveButton_Click_1(object sender, EventArgs e)
        {
            feedbackLabel.Text = "";
            //if 0 then every check is passed | 3 - name empty | 4 - surname empty
            //5 - password empty | 6 - password doesnt match | 7 - password invalid | 8 - something went wrong in database
            int okayToUpdate = 0;
            //take all input from fields
            if (nameTextBox.Text == "" || nameTextBox.Text == null)
                okayToUpdate = 3;
            else
                Account.User.Name = nameTextBox.Text;
            if (surnameTextBox.Text == "" || surnameTextBox.Text == null)
                okayToUpdate = 4;
            else
                Account.User.Surname = surnameTextBox.Text;
            Account.User.Tel = telTexBox.Text;
            Account.User.EducationLevel.Name = educationLevelCB.GetItemText(educationLevelCB.SelectedItem);
            Account.User.EducationLevel.Id = educationLevelCB.SelectedIndex + 1;
            Account.User.Role.Name = roleCB.GetItemText(roleCB.SelectedItem);
            Account.User.Role.Id = roleCB.SelectedIndex + 1;
            Account.User.Description = descriptionRTB.Text;
            //check image
            if(imagePB != null)
            {
                using (var ms = new MemoryStream())
                {
                    imagePB.Image.Save(ms, imagePB.Image.RawFormat);
                    Account.User.Image = ms.ToArray();
                }
            }
            
            
            if (genderMaleRB.Checked)
                Account.User.Gender = 'M';
            else if (genderFemaleRB.Checked)
                Account.User.Gender = 'F';
            Account.User.DateOfBirth = dateOfBirthDTP.Value;

            //check password
           
            string pass = passwordTextBox.Text;
            string passConf = passwordConfirmTextBox.Text;

            if (pass.Equals("") || pass == null)
                okayToUpdate = 5;
            
            if (pass.Equals(passConf))
            {
                

                if (pass.Length < 8 || !pass.Any(char.IsNumber) || !pass.Any(char.IsLetter))
                {
                    //lathos password
                    okayToUpdate = 7;
                }
                else
                {
                    if(okayToUpdate == 0)
                    {
                        //try to update
                        //make password hash and create salt
                        string salt = PasswordUtilities.CreateSalt(16);
                        string passwordHashed = PasswordUtilities.GenerateSHA256Hash(pass, salt);
                        Account.PasswordSalt = salt;
                        Account.SaltedPasswordHash = passwordHashed;
                        int accountAffected = DBConnect.Update(Account);
                        int userAffected = DBConnect.Update(Account.User);
                        if (accountAffected == 1 && userAffected == 1)
                        {
                            UpdatedSuccessfully = true;
                            Console.WriteLine("Debug Account updated succeded");
                            MessageBox.Show("Account updated successfully");
                            feedbackLabel.Text = "";
                            this.Close();
                        }
                            
                        else
                        {
                            Console.WriteLine("Debug Account updated not successfull");
                            okayToUpdate = 8;
                        }
                            
                    }
                  
                    
                }
                
            }
            else
            {
                okayToUpdate = 6;
            }

            updateFeedbackLabel(okayToUpdate);
        }

        private void updateFeedbackLabel(int errorCode)
        {
            switch (errorCode)
            {
                case 3:
                    feedbackLabel.Text = "*Name can't be empty!";
                    break;
                case 4:
                    feedbackLabel.Text = "*Surname can't be empty!";
                    break;
                case 5:
                    feedbackLabel.Text = "*Password can't be empty!";
                    break;
                case 6:
                    feedbackLabel.Text = "*Password doesn't match!";
                    break;
                case 7:
                    feedbackLabel.Text = "*Password must be at least 8 characters long\n with at least one letter and one digit!";
                    break;
                case 8:
                    feedbackLabel.Text = "*Connection error please try again!";
                    break;
            }
        }

    }
}
