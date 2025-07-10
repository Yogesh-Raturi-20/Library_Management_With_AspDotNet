using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class admin_member_managememt : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            GridView1.DataSource = FillGrid4();
            GridView1.DataBind();
        }
        private DataTable FillGrid4()
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("spMemberGridView", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        // go btn
        protected void btn_Go_Click1(object sender, EventArgs e)
        {
            getMemberById();
        }
        // check btn
        protected void btn_Active_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("active");
        }
        // pause btn
        protected void btn_Pending_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("pending");
        }
        // stop btn
        protected void btn_Deactive_Click(object sender, EventArgs e)
        {
            updateMemberStatusById("deactive");
        }
        // delete user permanently btn
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            deleteMemberById();
        }
        // user defined function
        bool CheckIfMemberExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("spCheckIfMemberExist", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@member_id", txt_MemberId.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
                return false;
            }
        }
        void deleteMemberById()
        {
            if (CheckIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spDeleteMemberById", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@member_id", txt_MemberId.Text.Trim());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member Deleted successfully.....');</script>");
                    clearform();
                    FillGrid4();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }
        void getMemberById()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("spCheckIfMemberExist", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@member_id", txt_MemberId.Text.Trim());
                SqlDataReader dr = cmd.ExecuteReader();
                if (dr.HasRows)
                {
                    while (dr.Read())
                    {
                        txt_MemberName.Text = dr.GetValue(0).ToString();
                        txt_AccountStatus.Text = dr.GetValue(10).ToString();
                        txt_DOB.Text = dr.GetValue(1).ToString();
                        txt_Contact.Text = dr.GetValue(2).ToString();
                        txt_Email.Text = dr.GetValue(3).ToString();
                        txt_State.Text = dr.GetValue(4).ToString();
                        txt_City.Text = dr.GetValue(5).ToString();
                        txt_Pincode.Text = dr.GetValue(6).ToString();
                        txt_Address.Text = dr.GetValue(7).ToString();
                    }
                }
                else
                {
                    Response.Write("<script>alert('Invalid ID and Password Check Caraefully........');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void updateMemberStatusById(string status)
        {
            if (CheckIfMemberExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spUpdateMemberById", con);  
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@member_id", txt_MemberId.Text.Trim());
                    cmd.Parameters.AddWithValue("@account_status", status);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Member Updated.......');</script>");
                    FillGrid4();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Member ID');</script>");
            }
        }
        void clearform()
        {
            txt_MemberName.Text = "";
            txt_AccountStatus.Text = "";
            txt_DOB.Text = "";
            txt_Contact.Text = "";
            txt_Email.Text = "";
            txt_State.Text = "";
            txt_City.Text = "";
            txt_Pincode.Text = "";
            txt_Address.Text = "";
        }
    }
}