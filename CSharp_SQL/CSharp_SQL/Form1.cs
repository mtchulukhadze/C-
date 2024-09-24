using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace CSharp_SQL
{
    public partial class Form1 : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-3QJN7S3; Initial Catalog=csharp; Integrated Security=True;");
        SqlCommand cmd;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            con.Open();
            cmd = new SqlCommand("INSERT INTO csharp (Mobile, email) VALUES ('" + textBox1.Text+"', '"+textBox2.Text+"')", con);
            cmd.ExecuteNonQuery();

            con.Close();

        }
    }
}
