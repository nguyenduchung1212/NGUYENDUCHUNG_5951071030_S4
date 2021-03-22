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

namespace NGUYENDUCHUNG_5951071030_L2_S4
{
    public partial class Form1 : Form
    {
        public int StudentID;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            GetStudentRecord();
        }
        SqlConnection con = new SqlConnection(@"Data Source=.\SQLEXPRESS;Initial Catalog=DemoCrud2;Integrated Security=True");
        private void GetStudentRecord()
        {

            SqlCommand cmd = new SqlCommand("Select * from StudentTb", con);
            DataTable dt = new DataTable();
            con.Open();
            SqlDataReader sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            StudentRecordData.DataSource = dt;
        }
        private void ResetData()
        {
            txtDC.Text = "";
            txtHoSv.Text = "";
            txtSBD.Text = "";
            txtSDT.Text = "";
            txtTenSv.Text = "";
        }
        private bool IsValidData()
        {
            if (txtHoSv.Text == string.Empty
                || txtTenSv.Text == string.Empty
                || txtDC.Text == string.Empty
                || string.IsNullOrEmpty(txtSDT.Text)
                || string.IsNullOrEmpty(txtSBD.Text))
            {
                MessageBox.Show("Có lỗi chưa nhập dữ liệu !!!",
                    "Lỗi dữ liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            return true;
        }

       

        private void StudentRecordData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            StudentID = Convert.ToInt32(StudentRecordData.Rows[0].Cells[0].Value);
            txtHoSv.Text = StudentRecordData.SelectedRows[0].Cells[1].Value.ToString();
            txtTenSv.Text = StudentRecordData.SelectedRows[0].Cells[2].Value.ToString();
            txtSBD.Text = StudentRecordData.SelectedRows[0].Cells[3].Value.ToString();
            txtDC.Text = StudentRecordData.SelectedRows[0].Cells[4].Value.ToString();
            txtSDT.Text = StudentRecordData.SelectedRows[0].Cells[5].Value.ToString();
        }

        

        

        private void btnThem_Click_1(object sender, EventArgs e)
        {
            if (IsValidData())
            {
                SqlCommand cmd = new SqlCommand("insert into StudentTb values" +
                    "(@Name, @FatherName, @RullNumber, @Address, @Mobile)", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtTenSv.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtHoSv.Text);
                cmd.Parameters.AddWithValue("@RullNumber", txtSBD.Text);
                cmd.Parameters.AddWithValue("@Address", txtDC.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtSDT.Text);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                GetStudentRecord();
            }

        }

        private void btnCapNhat_Click_1(object sender, EventArgs e)
        {
            if (StudentID > 0)
            {
                SqlCommand cmd = new SqlCommand("update StudentTb set" +
                    "Name = @Name, FatherName = @FatherName, " +
                    "RullNumber = @RullNumber, Address = @Address" +
                    "Mobile = @Mobile where StudentID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@Name", txtTenSv.Text);
                cmd.Parameters.AddWithValue("@FatherName", txtHoSv.Text);
                cmd.Parameters.AddWithValue("@RullNumber", txtSBD.Text);
                cmd.Parameters.AddWithValue("@Address", txtDC.Text);
                cmd.Parameters.AddWithValue("@Mobile", txtSDT.Text);
                cmd.Parameters.AddWithValue("@ID", this.StudentID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                GetStudentRecord();
                ResetData();
            }
            else
            {
                MessageBox.Show("Cập nhật lỗi !!!", "Lỗi !", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click_1(object sender, EventArgs e)
        {

            if (StudentID > 0)
            {
                SqlCommand cmd = new SqlCommand("delete from StudentTb where StudentID = @ID", con);
                cmd.CommandType = CommandType.Text;
                cmd.Parameters.AddWithValue("@ID", this.StudentID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();
                GetStudentRecord();
                ResetData();

            }
            else
            {
                MessageBox.Show("Delete lỗi !!!", "Lỗi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnThoat_Click(object sender, EventArgs e)
        {

        }
    }
}
