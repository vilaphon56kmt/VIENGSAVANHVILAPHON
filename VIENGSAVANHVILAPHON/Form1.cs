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

namespace VIENGSAVANHVILAPHON
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-C51MMUS\SQLSERVER;Initial Catalog=quanlythongtin;Integrated Security=True");
        private void openCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
        }
        private void closeCon()
        {
            if (con.State == ConnectionState.Open)
            {
                con.Close();
            }
        }
        private Boolean Exe(string cmd)
        {
            openCon();
            Boolean check;
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                sc.ExecuteNonQuery();
                check = true;
            }
            catch (Exception ex)
            {
                check = false;
                MessageBox.Show("Error" + ex.Message);
            }
            closeCon();
            return check;
        }
        private DataTable Red(string cmd)
        {
            openCon();
            DataTable dt = new DataTable();
            try
            {
                SqlCommand sc = new SqlCommand(cmd, con);
                SqlDataAdapter sda = new SqlDataAdapter(sc);
                sda.Fill(dt);
            }
            catch (Exception)
            {
                dt = null;
                /*throw;*/
            }
            closeCon();
            return dt;
        }
        private void load()
        {
            DataTable dt = Red("SELECT * FROM quanlythongtin");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            load();
        }

        
        
        private void label3_Click(object sender, EventArgs e)
        {

        }
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            maTT.ResetText();
            hoTen.ResetText();
            namSinh.ResetText();
            queQuan.ResetText();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            Exe("INSERT INTO quanlythongtin(maTT, hoTen, namSinh, queQuan) VALUES(N'" + maTT.Text + "', N'" + hoTen.Text + "', N'" + namSinh.Text + "', N'" + queQuan.Text + "') ");
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            Exe("UPDATE quanlythongtin SET hoTen = N'" + hoTen.Text + "', namsinh = N'" + namSinh.Text + "', quequan = N'" + queQuan.Text + "' WHERE maTT = '" + maTT.Text + "'  ");
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            Exe("DELETE FROM quanlythongtin WHERE maTT = '" + maTT.Text + "' ");
        }

        private void button6_Click_1(object sender, EventArgs e)
        {
            DataTable dt = Red("SELECT * FROM quanlythongtin WHERE maTT = '" + tentimkiem.Text + "' ");
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
            }
        }

        private void button7_Click_1(object sender, EventArgs e)
        {
            load();
        }

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            maTT.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            hoTen.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            namSinh.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            queQuan.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
        }

        private void tentimkiem_TextChanged(object sender, EventArgs e)
        {

        }
    }
}