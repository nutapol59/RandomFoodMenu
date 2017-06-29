using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace LearningWindowForm_24_06_2017
{
    public partial class frmRegister : Form
    {
     //   static String strCon = "server=192.168.0.159;database=K2;user id=k2dba;password=kaj5389@!!##$$;timeout=5;"; //Fix Config datasource
        static String con = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;
        //gen datasource config from App.config 
        SqlConnection conn = new SqlConnection(con);
        SqlCommand cmd;
        int ID = 0;
        public frmRegister()
        {
            InitializeComponent();
        }
        
        private void frmRegister_Load(object sender, EventArgs e)
        {
            getListData();
            
            
        }


        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            FormLogin frmLogin = new FormLogin();
            frmLogin.Show();
        }
        private void btnInsert_Click(object sender, EventArgs e)
        {
            DialogResult dlrInsert = MessageBox.Show("Do you want to insert data ?", "Confirm Box", MessageBoxButtons.YesNo);
            if(dlrInsert == DialogResult.Yes)
            {
                if (txbName.Text != "" && txbName.Text != "" && txbAge.Text != "" && txbPassword.Text != "")
                {
                    addData();
                }
                else
                {
                    MessageBox.Show("Please insert data all Field !");
                }
            }
                
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            DialogResult dlrDelete = MessageBox.Show("Do you want to Delete data ?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (dlrDelete == DialogResult.Yes)
            {
                deleteData();
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult dlrUpdate = MessageBox.Show("Do you want to Update Data ?", "Confirm Update", MessageBoxButtons.YesNo);
            if(dlrUpdate == DialogResult.Yes)
            {
                updateData();
            }
        }

        private void dataGridView1_CellMouseClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != dataGridView1.RowCount -1 && e.RowIndex >= 0)
            {
                ID = Convert.ToInt32(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
                txbName.Text = dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString();
                txbAge.Text = dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString();
                txbUsername.Text = dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString();
                txbPassword.Text = dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString();
            }
            else
            {
                MessageBox.Show("Failed Rows");
            }

        }

        public void getListData()
        {
            conn.Open();
            String sql = "SELECT * FROM TBMEMBER_CSHAPE_NUT";
            SqlDataAdapter da = new SqlDataAdapter(sql, conn);
            DataTable dt = new DataTable();
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            conn.Close();
        }

        private void addData()
        {
            cmd = new SqlCommand("insert into TBMEMBER_CSHAPE_NUT values(@name, @age, @username, @password)",conn);
            conn.Open();
            cmd.Parameters.AddWithValue("@name", txbName.Text);
            cmd.Parameters.AddWithValue("@age", txbAge.Text);
            cmd.Parameters.AddWithValue("@username", txbUsername.Text);
            cmd.Parameters.AddWithValue("@password", txbPassword.Text);
            cmd.ExecuteNonQuery();
            conn.Close();
            MessageBox.Show("Insert Data Successful !");
            getListData();
            clearData();
        }

        private void deleteData()
        {
            if(ID != 0)
            {
                cmd = new SqlCommand("delete from TBMEMBER_CSHAPE_NUT where ID=@id", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Delete Data Successful !");
                getListData();
                clearData();
            }
            else
            {
                MessageBox.Show("Please select data to Delete !");
            }
            
        }

        private void updateData()
        {
            if(ID != 0)
            {
                cmd = new SqlCommand("update  TBMEMBER_CSHAPE_NUT SET NAME=@name, AGE=@age, USERNAME=@username, PASSWORD=@password where ID=@id", conn);
                conn.Open();
                cmd.Parameters.AddWithValue("@id", ID);
                cmd.Parameters.AddWithValue("@name", txbName.Text);
                cmd.Parameters.AddWithValue("@age", txbAge.Text);
                cmd.Parameters.AddWithValue("@username", txbUsername.Text);
                cmd.Parameters.AddWithValue("@password", txbPassword.Text);
                cmd.ExecuteNonQuery();
                conn.Close();
                MessageBox.Show("Update Data Successful !");
                getListData();
                clearData();

            }
            else
            {
                MessageBox.Show("Please select data to Update !");
            }
        }
        private void clearData()
        {
            txbName.Text = "";
            txbAge.Text = "";
            txbUsername.Text = "";
            txbPassword.Text = "";
            ID = 0;
        }


      
    }
}
