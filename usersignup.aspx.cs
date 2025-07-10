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
    public partial class usersignup : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // sign-up btn click event
        protected void btn_Signup_Click(object sender, EventArgs e)
        {
            if(checkMemberExist())
            {
                Response.Write("<script>alert('Member already exist with this id , please try  another id.............. ');</script>");
            }
            else
            {
                signUpNewUser();
            }
        }
        // user defined function
        bool checkMemberExist()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("spCheckMember", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@member_id", txt_CreateId.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if(dt.Rows.Count >= 1)
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
        void signUpNewUser()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("spUserSignup", con);//stored procedure name
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@full_name", txt_MemberName.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", txt_DOB.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", txt_Contact.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txt_Email.Text.Trim());
                cmd.Parameters.AddWithValue("@state", ddl_State.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", txt_City.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", txt_Pincode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", txt_Address.Text.Trim());
                cmd.Parameters.AddWithValue("@member_id", txt_CreateId.Text.Trim());
                cmd.Parameters.AddWithValue("@password", txt_CreatePassword.Text.Trim());
                cmd.Parameters.AddWithValue("@account_status", "pending");
                cmd.ExecuteNonQuery();
                con.Close();
                Response.Write("<script>alert('User Sign-Up successfully . Go to user login to login .......... ');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('"+ex.Message+"');</script>");
            }
        }
    }
}