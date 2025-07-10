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
    public partial class userprofile : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                getUserBookData();
                if (!Page.IsPostBack)
                {
                    getUserDetails();
                }
            }
        }
        // update btn
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            if (Session["username"].ToString() == "" || Session["username"] == null)
            {
                Response.Write("<script>alert('Session Expired Login Again');</script>");
                Response.Redirect("userlogin.aspx");
            }
            else
            {
                updateUserPersonalDetail();
            }
        }
        //uer defined functions
        void updateUserPersonalDetail()
        {
            string password = "";
            if (txt_NewPassword.Text.Trim() == "")
            {
                password = txt_OldPassword.Text.Trim();
            }
            else
            {
                password = txt_NewPassword.Text.Trim();
            }
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("spUpdateMemberDetails", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@full_name", txt_MemberName.Text.Trim());
                cmd.Parameters.AddWithValue("@dob", txt_DOB.Text.Trim());
                cmd.Parameters.AddWithValue("@contact_no", txt_Contact.Text.Trim());
                cmd.Parameters.AddWithValue("@email", txt_Email.Text.Trim());
                cmd.Parameters.AddWithValue("@state", ddl_State.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@city", txt_City.Text.Trim());
                cmd.Parameters.AddWithValue("@pincode", txt_Pincode.Text.Trim());
                cmd.Parameters.AddWithValue("@full_address", txt_Address.Text.Trim());
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@account_status", "pending");
                int result = cmd.ExecuteNonQuery();
                if (result > 0)
                {
                    Response.Write("<script>alert('Your Details Updated Successfully..');</script>");
                    getUserDetails();
                    getUserBookData();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Entry');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void getUserDetails()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("SELECT * FROM member_master_tbl WHERE member_id='" + Session["username"].ToString() + "'", con);
                //SqlCommand cmd = new SqlCommand("spGetUserDetails1", con);
                //cmd.CommandType = CommandType.StoredProcedure;
                //cmd.Parameters.AddWithValue("@member_id", txt_MemberId.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                txt_MemberName.Text = dt.Rows[0]["full_name"].ToString();
                txt_DOB.Text = dt.Rows[0]["dob"].ToString();
                txt_Contact.Text = dt.Rows[0]["contact_no"].ToString();
                txt_Email.Text = dt.Rows[0]["email"].ToString();
                ddl_State.SelectedValue = dt.Rows[0]["state"].ToString().Trim();
                txt_City.Text = dt.Rows[0]["city"].ToString();
                txt_Pincode.Text = dt.Rows[0]["pincode"].ToString();
                txt_Address.Text = dt.Rows[0]["full_address"].ToString();
                txt_MemberId.Text = dt.Rows[0]["member_id"].ToString();
                txt_OldPassword.Text = dt.Rows[0]["password"].ToString();
                lb_AccountStatus.Text = dt.Rows[0]["account_status"].ToString().Trim();
                if (dt.Rows[0]["account_status"].ToString().Trim() == "active")
                {
                    lb_AccountStatus.Attributes.Add("CssClass", "badge badge-pill badge-success");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "pending")
                {
                    lb_AccountStatus.Attributes.Add("CssClass", "badge badge-pill badge-warning");
                }
                else if (dt.Rows[0]["account_status"].ToString().Trim() == "deactive")
                {
                    lb_AccountStatus.Attributes.Add("CssClass", "badge badge-pill badge-danger");
                }
                else
                {
                    lb_AccountStatus.Attributes.Add("CssClass", "badge badge-pill badge-info");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        void getUserBookData()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                //SqlCommand cmd = new SqlCommand("SELECT * FROM book_issue_tbl WHERE member_id='" + Session["username"].ToString() + "'", con);
                SqlCommand cmd = new SqlCommand("spGetUserBookData", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@member_id", Session["username"].ToString());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                GridView1.DataSource = dt;
                GridView1.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        protected void GridView1_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            try
            {
                if (e.Row.RowType == DataControlRowType.DataRow)
                {
                    // check your condition here
                    DateTime dt = Convert.ToDateTime(e.Row.Cells[5].Text);
                    DateTime today = DateTime.Today;
                    if (today > dt)
                    {
                        e.Row.BackColor = System.Drawing.Color.PaleVioletRed;
                    }
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}