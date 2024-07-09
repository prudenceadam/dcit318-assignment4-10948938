using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace AddressBook
{
    public partial class Form1 : Form
    {
        private List<Contact> contacts;

        public Form1()
        {
            InitializeComponent();
            contacts = new List<Contact>();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string email = txtEmail.Text;
            string phone = txtPhone.Text;

            Contact contact = new Contact(name, email, phone);
            contacts.Add(contact);

            RefreshContactList();
            ClearInputFields();
        }

        private void RefreshContactList()
        {
            lstContacts.Items.Clear();
            foreach (Contact contact in contacts)
            {
                lstContacts.Items.Add(contact);
            }
        }

        private void ClearInputFields()
        {
            txtName.Text = "";
            txtEmail.Text = "";
            txtPhone.Text = "";
        }
    }

    public class Contact
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }

        public Contact(string name, string email, string phone)
        {
            Name = name;
            Email = email;
            Phone = phone;
        }

        public override string ToString()
        {
            return $"{Name} - {Email} - {Phone}";
        }
    }
}
