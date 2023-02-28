using EntityFramework02.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace EntityFramework01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var form = new AddForm();
            form.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var form = new Search();
            form.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            var form = new ViewForm();
            form.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog open = new OpenFileDialog();
                string path = " ";
                if (open.ShowDialog() == DialogResult.OK)
                {
                    string filename = open.FileName;
                    path = Path.GetFullPath(filename);
                }
                using (StreamReader sr = new StreamReader(path))
                {
                    List<string> read = new List<string>();
                    //先讓product第一行的種類被讀掉
                    string line = sr.ReadLine();

                    while ((line = sr.ReadLine()) != null)
                    {
                        var product = line.Split(',');
                        ContactsTable data = new ContactsTable()
                        {
                            Id = product[0],
                            Name = product[1],
                            Count = int.Parse(product[2]),
                            Price = int.Parse(product[3]),
                            Kind = product[4],
                        };
                        ContactsModel context = new ContactsModel();
                        context.ContactsTable.Add(data);
                        context.SaveChanges();
                    }
                }
            }
            catch (Exception) 
            {
                MessageBox.Show($"不要重複匯入csv檔");
            }
                

            
        }
    }
}
