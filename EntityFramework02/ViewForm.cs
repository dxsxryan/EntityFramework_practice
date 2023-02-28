using EntityFramework02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework01
{
    public partial class ViewForm : Form
    {
        public ViewForm()
        {
            InitializeComponent();
            Binddata();
        }

        private void Binddata()
        {
            var context = new ContactsModel();
            var list = context.ContactsTable.ToList();
            dataGridView1.DataSource = list;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
