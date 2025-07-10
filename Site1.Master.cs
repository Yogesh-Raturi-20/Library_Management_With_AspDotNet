using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace LibraryManagement
{
    public partial class Site1 : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["role"]!=null)
            {
                if (Session["role"].Equals("admin"))
                {
                    Panel1.Visible = true;
                    Panel2.Visible = true;
                }
                else
                {
                    Panel1.Visible = false;
                    Panel2.Visible = false;
                }
            }
            try
            {
                if (Session["role"]==null)
                {
                    LinkButton1.Visible = false; // View books link btn
                    LinkButton2.Visible = true; // user login link btn
                    LinkButton3.Visible = true; // sign up link btn
                    LinkButton4.Visible = false; // logout link btn
                    LinkButton5.Visible = false; // Hello user link btn
                    LinkButton6.Visible = true; // admin login link btn
                    //LinkButton7.Visible = false; // author mngmt link btn
                    //LinkButton8.Visible = false; // publisher mngmt link btn
                    //LinkButton9.Visible = false; // book inventory link btn
                    //LinkButton10.Visible = false; // book issuing link btn
                    //LinkButton11.Visible = false; // member mngmt link btn
                }
                else if (Session["role"].Equals("user"))
                {
                    LinkButton1.Visible = true; // View books link btn
                    LinkButton2.Visible = false; // user login link btn
                    LinkButton3.Visible = false; // sign up link btn
                    LinkButton4.Visible = true; // logout link btn
                    LinkButton5.Visible = true; // Hello user link btn
                    LinkButton5.Text = "Hello " + Session["username"].ToString();
                    LinkButton6.Visible = false; // admin login link btn
                    //LinkButton7.Visible = false; // author mngmt link btn
                    //LinkButton8.Visible = false; // publisher mngmt link btn
                    //LinkButton9.Visible = false; // book inventory link btn
                    //LinkButton10.Visible = false; // book issuing link btn
                    //LinkButton11.Visible = false; // member mngmt link btn
                }
                else if (Session["role"].Equals("admin"))
                {
                    LinkButton1.Visible = true; // View books link btn
                    LinkButton2.Visible = false; // user login link btn
                    LinkButton3.Visible = false; // sign up link btn
                    LinkButton4.Visible = true; // logout link btn
                    LinkButton5.Visible = false; // Hello user link btn
                    //LinkButton5.Text = "Hello Admin";
                    LinkButton6.Visible = false; // admin login link btn
                    //LinkButton7.Visible = true; // author mngmt link btn
                    //LinkButton8.Visible = true; // publisher mngmt link btn
                    //LinkButton9.Visible = true; // book inventory link btn
                    //LinkButton10.Visible = true; // book issuing link btn
                    //LinkButton11.Visible = true; // member mngmt link btn
                }
            }
            catch(Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
        protected void LinkButton1_Click(object sender, EventArgs e)
        {
            Response.Redirect("view-books.aspx");
        }
        protected void LinkButton2_Click(object sender, EventArgs e)
        {
            Response.Redirect("userlogin.aspx");
        }
        protected void LinkButton3_Click(object sender, EventArgs e)
        {
            Response.Redirect("usersignup.aspx");
        }
        protected void LinkButton5_Click(object sender, EventArgs e)
        {
            Response.Redirect("userprofile.aspx");
        }
        protected void LinkButton6_Click(object sender, EventArgs e)
        {
            Response.Redirect("adminlogin.aspx");
        }
        //protected void LinkButton7_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("admin-author-management.aspx");
        //}
        //protected void LinkButton8_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("admin-publisher-management.aspx");
        //}
        //protected void LinkButton9_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("admin-book-inventory.aspx");
        //}
        //protected void LinkButton10_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("admin-book-issuing.aspx");
        //}
        //protected void LinkButton11_Click(object sender, EventArgs e)
        //{
        //    Response.Redirect("admin-member-managememt.aspx");
        //}
        protected void LinkButton4_Click(object sender, EventArgs e)

        {
            Session.Abandon();
            Session.Clear();
            Response.Redirect("homepage.aspx");
            //Session["username"] = "";
            //Session["fullname"] ="";
            //Session["role"] = "";
            //Session["status"] = "";
            //LinkButton1.Visible = false; // View books link btn
            //LinkButton2.Visible = true; // user login link btn
            //LinkButton3.Visible = true; // sign up link btn
            //LinkButton4.Visible = false; // logout link btn
            //LinkButton5.Visible = false; // Hello user link btn
            //LinkButton6.Visible = true; // admin login link btn
            //LinkButton7.Visible = false; // author mngmt link btn
            //LinkButton8.Visible = false; // publisher mngmt link btn
            //LinkButton9.Visible = false; // book inventory link btn
            //LinkButton10.Visible = false; // book issuing link btn
            //LinkButton11.Visible = false; // member mngmt link btn
        }
    }
}