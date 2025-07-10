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
    public partial class userlogin : System.Web.UI.Page
    {
        private string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        public object TextBox5 { get; private set; }
        public object TextBox9 { get; private set; }
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // user login btn 
        protected void btn_Login_Click(object sender, EventArgs e)
        {
            if (txt_Captcha.Text == Session["sessionCaptcha"].ToString())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spUserLoginBtn", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@member_id", txt_MemberId.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txt_Password.Text.Trim());
                    SqlDataReader dr = cmd.ExecuteReader();
                    if (dr.HasRows)
                    {
                        while (dr.Read())
                        {
                            Session["username"] = dr.GetValue(8).ToString();
                            Session["Password"] = dr.GetValue(9).ToString();
                            Session["role"] = "user";
                            Session["status"] = dr.GetValue(10).ToString();
                        }
                        Response.Redirect("homepage.aspx", false);
                    }
                    else
                    {
                        //Response.Write("<script>alert('Invalid Id and Password');</script>");
                        lb_ErrorID.Text = "This id does not exist........";
                        lb_ErrorID.ForeColor = System.Drawing.Color.Red;
                        txt_MemberId.BorderColor = System.Drawing.Color.Red;
                        lb_ErrorPassword.Text = "Wrong Password..";
                        lb_ErrorPassword.ForeColor = System.Drawing.Color.Red;
                        txt_Password.BorderColor = System.Drawing.Color.Red;
                    }
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                lb_ErrorMsg.Text = "Captcha code is incorrect . Please enter carefully.";
                lb_ErrorMsg.ForeColor = System.Drawing.Color.Red;
                txt_Captcha.BorderColor = System.Drawing.Color.Red;
            }
        }
    }
}