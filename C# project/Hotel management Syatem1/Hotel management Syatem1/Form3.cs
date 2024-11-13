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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void btnback_Click(object sender, EventArgs e)
        {
            Form2 F2 = new Form2();
            F2.Show();
            this.Hide();


        }

        private void btnbook_Click(object sender, EventArgs e)
        {
           

            String cs="Data Source=DESKTOP-99J19EI;Initial Catalog=Hotel1;Integrated Security=True;Encrypt=False";
            SqlConnection con = new SqlConnection(cs);
            con.Open();

            String sql="INSERT INTO table11(Cus_ID,Room_Type,Name,NIC,E_mail,Mo_num,Date)VALUES(@Cus_ID,@Room_Type,@Name,@NIC,@E_mail,@Mo_num,@Date)";
            SqlCommand com = new SqlCommand(sql, con);
            string room = "";
            if (this.rd1.Checked == true)
            {
                room = "Family room";

            }
            else if (this.rd2.Checked == true)
            {
                room = "Couple room";

            }
            else
            {
                room = "Single Room";
            }
            com.Parameters.AddWithValue("Cus_ID", this.textBox1.Text);
            com.Parameters.AddWithValue("@Room_Type", room);
            com.Parameters.AddWithValue("@Name", this.texname.Text);
            com.Parameters.AddWithValue("@NIC", this.texnic.Text);
            com.Parameters.AddWithValue("@E_mail", this.texemail.Text);
            com.Parameters.AddWithValue("@Mo_num", this.texnum.Text);
            com.Parameters.AddWithValue("@Date", this.date.Text);



            com.ExecuteNonQuery();
            Form4 F4 = new Form4();
            F4.Show();


            con.Close();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string cs2="Data Source=DESKTOP-99J19EI;Initial Catalog=Hotel1;Integrated Security=True;Encrypt=False";
            SqlConnection con2 = new SqlConnection(cs2);
            con2.Open();

            string sql2="SELECT MAX(Cus_ID) FROM table11";

            SqlCommand com2 = new SqlCommand(sql2, con2);

            SqlDataReader dr2 = com2.ExecuteReader();
            string current_id, new_id = "";
            if (dr2.Read() == true)
            {
                current_id = dr2.GetValue(0).ToString();
                int id = Convert.ToInt32(current_id);
                id++;
                new_id = ""+
                    id;

                this.textBox1.Text = new_id.ToString();

                con2.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Clear all TextBoxes except Book ID
            texname.Clear();
            texnic.Clear();
            texemail.Clear();
            texnum.Clear();

            // Clear the selected Room Type
            rd1.Checked = false;
            rd2.Checked = false;
            rd3.Checked = false;

            
        }
    }
}
