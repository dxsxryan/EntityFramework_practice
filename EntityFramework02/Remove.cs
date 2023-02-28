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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EntityFramework02
{
    public partial class Remove : Form
    {
        public Remove()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        { 
            ContactsModel context = new ContactsModel();
            var search = context.ContactsTable.Where((x) => x.Id == textBox1.Text.Trim()).ToList();

            foreach(var i in search)
            {
                context.ContactsTable.Remove(i);
            }
            context.SaveChanges();
            MessageBox.Show("它...已經死了");
            textBox1.Clear();

        }

        
    }
}
