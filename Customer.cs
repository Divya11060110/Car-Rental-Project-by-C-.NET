using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace carrental
{
    public partial class Customer : Form
    {
        public Customer()
        {
            InitializeComponent();
            Autono();
            Customerload();
        }

        SqlConnection con = new SqlConnection("Data Source=DIVYA-PC\\SQLEXPRESS;Initial Catalog=Carrental;Integrated Security=True;");
        SqlCommand cmd;
        SqlDataReader dr;
        string proid;
        string sql;
        bool Mode = true;
        string id;


        public void Autono()
        {

            sql = "select custid from customer order by custid desc";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();

            if (dr.Read())
            {
                int id = int.Parse(dr[0].ToString()) + 1;
                proid = id.ToString("00000");
            }
            else if (Convert.IsDBNull(dr))
            {
                proid = ("00001");
            }
            else
            {
                proid = ("00001");

            }

            txtid.Text = proid.ToString();
            con.Close();

        }
        public void Customerload()
        {

            sql = "select * from customer";
            cmd = new SqlCommand(sql, con);
            con.Open();
            dr = cmd.ExecuteReader();
            dataGridView1.Rows.Clear();

            while (dr.Read())
            {
                dataGridView1.Rows.Add(dr[0], dr[1], dr[2], dr[3]);

            }


            con.Close();


        }
        private void button1_Click(object sender, EventArgs e)
        {
            string cusid = txtid.Text;
            string custname = txtname.Text;
            string address = txtaddress.Text;
            string mobile = txtmobile.Text;







            //   id = dataGridView1.CurrentRow.Cells[0].Value.ToString();


            if (Mode == true)
            {
                sql = "insert into customer(custid,custname,address,mobile)values(@custid,@custname,@address,@mobile)";
                con.Open();
                cmd = new SqlCommand(sql, con);
                cmd.Parameters.AddWithValue("@custid", cusid);
                cmd.Parameters.AddWithValue("@custname", custname);
                cmd.Parameters.AddWithValue("@address", address);
                cmd.Parameters.AddWithValue("@mobile", mobile);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Adddeddd");

                txtname.Clear();
                txtaddress.Clear();
                txtmobile.Clear();
                txtname.Focus();



            }

            else
            {

                sql = "update carreg set make= @make,model=@model,available = @available where regno = @regno";
                con.Open();
                cmd = new SqlCommand(sql, con);

                //  cmd.Parameters.AddWithValue("@make", make);
                //    cmd.Parameters.AddWithValue("@model", model);
                //    cmd.Parameters.AddWithValue("@available", aval);
                //    cmd.Parameters.AddWithValue("@regno", id);


                cmd.ExecuteNonQuery();
                MessageBox.Show("Record Updateeeddd");
                //    txtregno.Enabled = true;
                //    Mode = true;

                //   txtmake.Clear();
                //   txtmodel.Clear();
                //   txtavl.Items.Clear();
                //   txtmake.Focus();




            }


            con.Close();
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }
    }

    }

