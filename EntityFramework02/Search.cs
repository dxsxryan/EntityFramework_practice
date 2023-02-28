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
    public partial class Search : Form
    {
        public Search()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            ContactsModel context = new ContactsModel();
            int input = 0; 
            int.TryParse(textBox1.Text.Trim(), out input);
            var search = context.ContactsTable.Where((x) => x.Id == textBox1.Text.Trim() || x.Name == textBox1.Text.Trim() || x.Kind == textBox1.Text.Trim());
            var search_int = context.ContactsTable.Where((x) => x.Count == input || x.Price == input);
            if(search.Count() == 0 && search_int.Count() == 0)
            {
                MessageBox.Show("沒有找到該資料");
            }
            else
            {
                var form = new ViewForm();
                form.ShowDialog();
            }
        }
    }
}
