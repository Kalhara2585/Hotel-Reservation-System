using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_management_Syatem1
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form1 F1 = new Form1();
            F1.Show();
            this.Hide();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string cs = "Data Source=DESKTOP-99J19EI;Initial Catalog=Hotel1;Integrated Security=True";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            string sql = "SELECT * FROM table2 WHERE Name=@un AND Password=@pw";
            SqlCommand com = new SqlCommand(sql, con);
            com.Parameters.AddWithValue("@un", this.textBox1.Text);
            com.Parameters.AddWithValue("@pw", this.textBox2.Text);

            SqlDataReader dr = com.ExecuteReader();
            if (dr.Read() == true)
            {
                Form6 f6 = new Form6();
                f6.Show();
                this.Hide();
            }
            else
            {
                Form1 f1 = new Form1();
                f1.Show();
                this.Hide();
            }

            con.Close();
        }
    }
}
