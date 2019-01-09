﻿using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using Encyclopedia.Model;

namespace Encyclopedia.Controller
{
	class ContactAndGroupHandler
	{
		public static int DeleteGroup(ContactGroup group)
		{
			// delete the contact group provided
			int rowsAffected = DBConnect.Delete(group);

			return rowsAffected;
		}

		public static int UpdateGroup(ContactGroup Group, string groupNameInserted, Dictionary<int, bool> groupMembersBefore, Dictionary<int, bool> groupMembersAfter)
		{
			if (!Group.Name.Equals(groupNameInserted))
			{
				Group.Name = groupNameInserted;

				int rowsAffected = DBConnect.Update(Group);
				if (rowsAffected != 1)
				{
					return -1;
				}
			}

			int contactsUpdated = UpdateGroupContacts(Group, groupMembersBefore, groupMembersAfter);

			return contactsUpdated;
		}

		private static int UpdateGroupContacts(ContactGroup Group, Dictionary<int, bool> groupMembersBefore, Dictionary<int, bool> groupMembersAfter)
		{
			int contactsUpdated = 0;
			foreach (int contactId in groupMembersBefore.Keys)
			{
				if (groupMembersBefore[contactId] == false && groupMembersAfter[contactId] == true)
				{
					User contact = new User();
					contact.Id = contactId;

					ContactGroupMember groupMember = new ContactGroupMember(Group, contact);
					int rowsAffected = DBConnect.Insert(groupMember);
					if (rowsAffected == 1)
					{
						contactsUpdated++;
					}
				}
				else if (groupMembersBefore[contactId] == true && groupMembersAfter[contactId] == false)
				{
					User contact = new User();
					contact.Id = contactId;

					ContactGroupMember groupMember = new ContactGroupMember(Group, contact);
					int rowsAffected = DBConnect.Delete(groupMember);
					if (rowsAffected == 1)
					{
						contactsUpdated++;
					}
				}
				else if (groupMembersBefore[contactId] == groupMembersAfter[contactId])
				{
					// this contact remained untouched
					contactsUpdated++;
				}
			}

			return contactsUpdated;
		}

		public static ContactGroup CreateNewGroup(string groupName, int[] groupMembers)
		{
			// configure ContactGroup Object
			ContactGroup group = new ContactGroup(-1, groupName, UI.StartPage.account.User);

			// try to insert the new group and its contact members
			int groupId = DBConnect.InsertNewGroupAndMembers(group, groupMembers);
			// if the returned groupId is anything but -1, the group created successfully
			if (groupId != -1)
			{
				group.Id = groupId;
			}

			return group;
		}

		public static Dictionary<int, bool> CheckContactGroupMembers(ContactGroup group, List<User> contacts)
		{
			Dictionary<int, bool> ifGroupMembers = new Dictionary<int, bool>();

			// get the selected group's members
			List<int> groupMembers = DBConnect.GetContactGroupMembers(group, UI.StartPage.account.User.Id);

			// define which of the user's contacts are in this group
			foreach (User contact in contacts)
			{
				if (groupMembers.Contains(contact.Id))
				{
					ifGroupMembers[contact.Id] = true;
				}
				else
				{
					ifGroupMembers[contact.Id] = false;
				}
			}

			return ifGroupMembers;
		}

		// fills dynamically the parametered ListView with the user's contacts
		public static void FillContacts(ListView listView, List<User> contacts)
		{
			// empty the listview
			//listView.LargeImageList = null;
			listView.Items.Clear();

			// initialize the listview item array
			ListViewItem[] contactNames = new ListViewItem[contacts.Count];

			// adjust image properties
			ImageList contactImages = new ImageList();
			contactImages.ImageSize = new Size(96, 96);
			contactImages.ColorDepth = ColorDepth.Depth16Bit;
			
			int i = 0;
			foreach (User contact in contacts)
			{
				// add contact item
				ListViewItem contactItem = new ListViewItem(contact.Name + " " + contact.Surname);
				contactItem.ImageKey = contactItem.Text;
				contactNames[i++] = contactItem;

				// if an image is specified, add it to the image list
				if (contact.Image != null)
				{
					MemoryStream ms = new MemoryStream(contact.Image);
					contactImages.Images.Add(contactItem.ImageKey, Image.FromStream(ms));
				}
				else
				{
					// otherwise add the default avatar image to the image list
					contactImages.Images.Add(contactItem.ImageKey, Properties.Resources.default_avatar);
				}
			}

			// put in the listview the items and their images
			listView.Items.AddRange(contactNames);
			
			listView.LargeImageList = contactImages;
		}

		// fills dynamically the parametered ListView with the user's contact groups
		public static void FillGroups(ListView listView, List<ContactGroup> groups)
		{
			// empty the listview
			//listView.LargeImageList = null;
			listView.Items.Clear();
			
			// initialize the listview item array
			ListViewItem[] groupNames = new ListViewItem[groups.Count];

			// adjust image properties
			ImageList groupImages = new ImageList();
			groupImages.ImageSize = new Size(90, 90);
			groupImages.ColorDepth = ColorDepth.Depth8Bit;

			int i = 0;
			foreach (ContactGroup group in groups)
			{
				// add group item
				ListViewItem groupItem = new ListViewItem(group.Name, i);
				groupNames[i++] = groupItem;

				// add the default group image to the image list
				groupImages.Images.Add(Properties.Resources.default_group_avatar);
			}

			// put in the listview the items and their images
			listView.Items.AddRange(groupNames);

			listView.LargeImageList = groupImages;
		}

		// fills dynamically the parametered ListView with the matching user accounts based on the search string provided
		public static void FillContactSearchResults(ListView listView, string searchString)
		{
			// empty the listview
			listView.Items.Clear();

			// get the matching user accounts
			List<Account> matchingAccounts = DBConnect.GetSearchMatchingAccounts(searchString);
			
			foreach (Account account in matchingAccounts)
			{
				if (account.User.Id != UI.StartPage.account.User.Id)
				{
					// add user account item name and surname
					ListViewItem accountItem = listView.Items.Add(account.User.Name + " " + account.User.Surname);
					accountItem.UseItemStyleForSubItems = false;

					// add user account subitem username
					ListViewItem.ListViewSubItem accountSubItem = accountItem.SubItems.Add(account.Username);
					accountSubItem.ForeColor = Color.LightSlateGray;
					accountSubItem.Font = new Font("Century Gothic", 12, FontStyle.Regular);

					// add user account subitem email
					accountSubItem = accountItem.SubItems.Add(account.Email);
					accountSubItem.ForeColor = Color.LightSlateGray;
					accountSubItem.Font = new Font("Century Gothic", 12, FontStyle.Regular);
				}
			}
		}
	}
}
