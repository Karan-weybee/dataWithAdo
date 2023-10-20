using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Data;
using System.Web.UI.WebControls.Adapters;
using System.Windows.Forms;

namespace AdoCourse1
{
    public partial class DataRetrive : System.Web.UI.Page
    {
        public void addDataGrid()
        {
            string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=AdoCoursePrac; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            string getAllEmp = "select * from emp";
            SqlDataAdapter da = new SqlDataAdapter(getAllEmp, con);

            DataSet ds = new DataSet();
            da.Fill(ds);
            GridView1.DataSource = ds;

            GridView1.DataBind();
            con.Close();

        }

        public void deleteEmp(string id)
        {

            string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=AdoCoursePrac; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(ConStr);

            string query = "delete from [dbo].[emp] where id=@id";


            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            con.Open();
            int rowCount = cmd.ExecuteNonQuery();


            addDataGrid();
            con.Close();
        }

        public void editEmp(string id, string name)
        {
            string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=AdoCoursePrac; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(ConStr);

            string query = "update [dbo].[emp] set name=@name where id=@id";


            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", id);
            cmd.Parameters.AddWithValue("@name", name);
            con.Open();
            int rowCount = cmd.ExecuteNonQuery();


            addDataGrid();
            con.Close();
        }
        protected void Page_Load(object sender, EventArgs e)
        {

            string id = Request.QueryString["idEdit"];
            string name = Request.QueryString["nameEdit"];
            if (id != null && name != null)
            {
                editEmp(id, name);
            }


        }

        protected void dataSelect_Click(object sender, EventArgs e)
        {
            string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=AdoCoursePrac; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(ConStr);

            string query = "select * from [dbo].[emp]";

            SqlCommand cmd = new SqlCommand(query, con);
            con.Open();
            SqlDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {

                TextBox1.Text = TextBox1.Text + reader.GetString(0) + " ";
            }

            addDataGrid();
            con.Close();
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            string ConStr = @"Data Source=DESKTOP-9IJS7NM; Initial Catalog=AdoCoursePrac; Integrated Security=SSPI;";
            SqlConnection con = new SqlConnection(ConStr);

            string query = "insert into [dbo].[emp] (id,name) values (@id,@name)";


            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@id", TextBox2.Text);
            cmd.Parameters.AddWithValue("@name", TextBox3.Text);
            con.Open();
            int rowCount = cmd.ExecuteNonQuery();


            addDataGrid();
            con.Close();
        }

        protected void Button2_Click(object sender, EventArgs e)
        {

            deleteEmp(TextBox4.Text);
        }

        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

            string ids = (string)GridView1.DataKeys[e.RowIndex].Value;
            deleteEmp(ids);
        }

        protected void GridView1_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            //string ids = (string)GridView1.DataKeys[e.RowIndex].Value;
            Response.Redirect("editData.aspx");



        }
    }
}