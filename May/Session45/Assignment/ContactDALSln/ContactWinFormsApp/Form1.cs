using ContactDALLib.Model;
using ContactDALLib.Repository;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ContactWinFormsApp
{
    public partial class Form1 : Form
    {
        private ContactRepository contactRepository;
        private TextBox txtId;
        private TextBox txtName;
        private TextBox txtMobileNumber;
        private Button btnAdd;
        private Button btnDisplay;
        private DataGridView dataGridView1;
        public Form1()
        {
            InitializeComponent();
            string connectionString = ConfigurationManager.ConnectionStrings["ContactDbContext"].ConnectionString;
            contactRepository = new ContactRepository(connectionString);

            // Instantiate the controls
            txtId = new TextBox();
            txtName = new TextBox();
            txtMobileNumber = new TextBox();
            btnAdd = new Button();
            btnDisplay = new Button();
            dataGridView1 = new DataGridView();

            Form1_Load(this, EventArgs.Empty);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            int id;
            if (!int.TryParse(txtId.Text, out id))
            {
                MessageBox.Show("Invalid ID.");
                return;
            }
            string name = txtName.Text;
            string mobileNumber = txtMobileNumber.Text;

            Contact contact = new Contact
            {
                Id = id,
                Name = name,
                MobileNumber = mobileNumber
            };

            contactRepository.AddContact(contact);
            MessageBox.Show("Contact added successfully.");
        }

        private void btnDisplay_Click(object sender, EventArgs e)
        {
            List<Contact> contacts = contactRepository.GetContacts();
            if (contacts.Count == 0)
            {
                MessageBox.Show("No contacts found.");
            }
            else
            {
                dataGridView1.DataSource = contacts;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Set properties for the controls
            txtId.Location = new System.Drawing.Point(150, 10);
            txtName.Location = new System.Drawing.Point(150, 40);
            txtMobileNumber.Location = new System.Drawing.Point(150, 70);

            Label lblId = new Label();
            lblId.Text = "Serial:";
            lblId.Location = new System.Drawing.Point(10, 10);

            Label lblName = new Label();
            lblName.Text = "Name:";
            lblName.Location = new System.Drawing.Point(10, 40);

            Label lblMobileNumber = new Label();
            lblMobileNumber.Text = "Mobile No:";
            lblMobileNumber.Location = new System.Drawing.Point(10, 70);

            btnAdd.Location = new System.Drawing.Point(150, 100);
            btnAdd.Text = "Add";
            btnAdd.BackColor = System.Drawing.Color.GreenYellow;
            btnAdd.ForeColor = System.Drawing.Color.DarkBlue;
            btnAdd.Click += btnAdd_Click;

            btnDisplay.Location = new System.Drawing.Point(300, 350);
            btnDisplay.Text = "Display";
            btnDisplay.Click += btnDisplay_Click;

            dataGridView1.Location = new System.Drawing.Point(10, 140);
            dataGridView1.Size = new System.Drawing.Size(400, 200);

            // Add the controls to the form
            Controls.Add(lblId);
            Controls.Add(txtId);
            Controls.Add(lblName);
            Controls.Add(txtName);
            Controls.Add(lblMobileNumber);
            Controls.Add(txtMobileNumber);
            Controls.Add(btnAdd);
            Controls.Add(btnDisplay);
            Controls.Add(dataGridView1);
        }
    }
}
