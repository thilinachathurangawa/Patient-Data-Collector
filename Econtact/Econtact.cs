using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
using Econtact.econtactClasses;

namespace Econtact
{
    public partial class Econtact : Form
    {
        
        public Econtact()
        {
            InitializeComponent();
           
        }
        contactClass c = new contactClass();
        private void add_Click(object sender, EventArgs e)
        {
            c.id = id.Text;
            c.name = name.Text;
            c.email = email.Text;
            c.gender = gender.Text;
            c.address = address.Text;
            c.phone = phone.Text;

            bool sucess = c.insert(c);
            if (sucess = true)
            {
                MessageBox.Show("insert sucess...!");
            }
            else {
                MessageBox.Show("faild to insert...!");
            }

            DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
            

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Econtact_Load(object sender, EventArgs e)
        {
  DataTable dt = c.Select();
            dgvContactList.DataSource = dt;
        }
    }
}
