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
    public partial class adminlogin : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        // admin login btn
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
                    SqlCommand cmd = new SqlCommand("spAdminLoginBtn", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@username", txt_AdminId.Text.Trim());
                    cmd.Parameters.AddWithValue("@password", txt_Password.Text.Trim());
                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    //SqlDataReader dr = cmd.ExecuteReader();
                    if (dt.Rows.Count > 0)
                    {
                        Session["username"] = dt.Rows[0][0].ToString();
                        Session["fullname"] = dt.Rows[0][2].ToString();
                        Session["role"] = "admin";
                        Response.Redirect("homepage.aspx");
                    }
                    else
                    {
                        lb_ErrorID.Text = "This id does not exist........";
                        lb_ErrorID.ForeColor = System.Drawing.Color.Red;
                        txt_AdminId.BorderColor = System.Drawing.Color.Red;
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