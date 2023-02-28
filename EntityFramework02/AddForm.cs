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
    public partial class AddForm : Form
    {
        public AddForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContactsTable data = new ContactsTable()
            {
                Id = textBox1.Text.Trim(),
                Name = textBox2.Text.Trim(),
                Count = int.Parse(textBox3.Text.Trim()),
                Price = int.Parse(textBox4.Text.Trim()),
                Kind = textBox5.Text.Trim(),
            };
            try
            {
                ContactsModel context = new ContactsModel();
                context.ContactsTable.Add(data);
                context.SaveChanges();
                MessageBox.Show("存檔完成");
                ClearTextBox();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"發生錯誤 {ex.ToString()}");
            }

        }

        private void ClearTextBox()
        {
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            textBox4.Clear();
            textBox5.Clear();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearTextBox();
        }
    }
}
