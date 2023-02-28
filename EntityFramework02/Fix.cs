using EntityFramework02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityFramework02
{
    public partial class Fix : Form
    {
        public Fix()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            ContactsModel context = new ContactsModel();
            int input = 0;
            int.TryParse(textBox1.Text.Trim(), out input);
            var search = context.ContactsTable.Where((x) => x.Id == textBox1.Text.Trim() || x.Name == textBox1.Text.Trim() || x.Kind == textBox1.Text.Trim()).ToList();
            var search_int = context.ContactsTable.Where((x) => x.Count == input || x.Price == input);

            if (search.Count() == 0 && search_int.Count() == 0)
            {
                MessageBox.Show("沒有找到該資料");
            }
            else
            {
                foreach(var i in search)
                {
                    textBox1.Text = i.Id;
                    textBox2.Text = i.Name;
                    textBox3.Text = Convert.ToString(i.Count);
                    textBox4.Text = Convert.ToString(i.Price);
                    textBox5.Text = i.Kind;
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
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
                context.ContactsTable.AddOrUpdate(data);
                context.SaveChanges();
                MessageBox.Show("修改大成功");
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
    }
}
