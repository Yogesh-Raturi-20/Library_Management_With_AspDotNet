using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;

namespace LibraryManagement
{
    public partial class admin_book_inventory : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.ConnectionStrings["con"].ConnectionString;
        static string global_filepath;
        static int global_actual_stock, global_current_stock, global_issued_books;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                FillAuthorPublisherValues();
            }
            GridView1.DataSource = FillGrid2();
            GridView1.DataBind();
        }
        private DataTable FillGrid2()
        {
            SqlConnection con = new SqlConnection(strcon);
            SqlCommand cmd = new SqlCommand("spBookInventoryGridView", con);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;
        }
        // go btn
        protected void btn_Go_Click(object sender, EventArgs e)
        {
            GetBookByID();
        }
        // add btn
        protected void btn_Add_Click(object sender, EventArgs e)
        {
            if (CheckIfBookExists())
            {
                Response.Write("<script>alert('Book Already Exists , try some other ID.........');</script>");
            }
            else
            {
                AddNewBook();
            }
        }
        // update btn
        protected void btn_Update_Click(object sender, EventArgs e)
        {
            UpdateBookByID();
        }
        // delete btn
        protected void btn_Delete_Click(object sender, EventArgs e)
        {
            DeleteBookByID();
        }
        // user defined functions 
        void DeleteBookByID()
        {
            if (CheckIfBookExists())
            {
                try
                {
                    SqlConnection con = new SqlConnection(strcon);
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    SqlCommand cmd = new SqlCommand("spDeleteBook", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@book_id", txt_BookId.Text.Trim());
                    cmd.ExecuteNonQuery();
                    con.Close();
                    Response.Write("<script>alert('Book Deleted successfully.....');</script>");
                    FillGrid2();
                    GridView1.DataBind();
                }
                catch (Exception ex)
                {
                    Response.Write("<script>alert('" + ex.Message + "');</script>");
                }
            }
            else
            {
                Response.Write("<script>alert('Invalid Book ID');</script>");
            }
        }
        void UpdateBookByID()
        {
            //if (CheckIfBookExists())
            //{
            //try
            //{
            int actual_stock = Convert.ToInt32(txt_ActualStock.Text.Trim());
            int current_stock = Convert.ToInt32(txt_CurrentStock.Text.Trim());
            if (global_actual_stock == actual_stock)
            {

            }
            else
            {
                if (actual_stock < global_issued_books)
                {
                    Response.Write("<script>alert('Actual stock value connot be less than the Issued books');</script>");
                    return;
                }
                else
                {
                    current_stock = actual_stock - global_issued_books;
                    txt_CurrentStock.Text = "" + current_stock;
                }
            }
            string genre = "";
            foreach (int i in Lb_Genre.GetSelectedIndices())
            {
                genre = genre + Lb_Genre.Items[i] + ",";
            }
            //genres = Adventure,Self Help,
            //genre = genre.Remove(genre.Length - 1);
            string filepath = "~/book_inventory/books1.png";
            string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
            if (filename == "" || filename == null)
            {
                filepath = global_filepath;
            }
            else
            {
                FileUpload1.SaveAs(Server.MapPath("~/book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;
            }
            SqlConnection con = new SqlConnection(strcon);
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            SqlCommand cmd = new SqlCommand("spUpdateBook", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@book_id", txt_BookId.Text.Trim());
            cmd.Parameters.AddWithValue("@book_name", txt_BookName.Text.Trim());
            cmd.Parameters.AddWithValue("@genre", genre);
            cmd.Parameters.AddWithValue("@author_name", ddl_AuthorName.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@publisher_name", ddl_PublisherName.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@publish_date", txt_PublishDate.Text.Trim());
            cmd.Parameters.AddWithValue("@language", ddl_Language.SelectedItem.Value);
            cmd.Parameters.AddWithValue("@edition", txt_Edition.Text.Trim());
            cmd.Parameters.AddWithValue("@book_cost", txt_BookCost.Text.Trim());
            cmd.Parameters.AddWithValue("@no_of_pages", txt_Pages.Text.Trim());
            cmd.Parameters.AddWithValue("@book_description", txt_BookDescription.Text.Trim());
            cmd.Parameters.AddWithValue("@actual_stock", actual_stock.ToString());
            cmd.Parameters.AddWithValue("@current_stock", current_stock.ToString());
            cmd.Parameters.AddWithValue("@book_img_link", FileUpload1.ToString());
            cmd.ExecuteNonQuery();
            con.Close();
            Response.Write("<script>alert('Book Updated.......');</script>");
            FillGrid2();
            GridView1.DataBind();
            //}
            //catch (Exception ex)
            //{
            //    Response.Write("<script>alert('" + ex.Message + "');</script>");
            //}
            //}
            //else
            //{
            //    Response.Write("<script>alert('Invalid Book ID');</script>");
            //}
        }
        void GetBookByID()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("spGetBookById", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@book_id", txt_BookId.Text.Trim());
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                if (dt.Rows.Count >= 1)
                {
                    txt_BookName.Text = dt.Rows[0]["book_name"].ToString();
                    txt_PublishDate.Text = dt.Rows[0]["publish_date"].ToString();
                    txt_Edition.Text = dt.Rows[0]["edition"].ToString();
                    txt_BookCost.Text = dt.Rows[0]["book_cost"].ToString().Trim();
                    txt_Pages.Text = dt.Rows[0]["no_of_pages"].ToString().Trim();
                    txt_ActualStock.Text = dt.Rows[0]["actual_stock"].ToString().Trim();
                    txt_CurrentStock.Text = dt.Rows[0]["current_stock"].ToString().Trim();
                    txt_IssuedBooks.Text = "" + (Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString()) - Convert.ToInt32(dt.Rows[0]["current_stock"].ToString()));
                    txt_BookDescription.Text = dt.Rows[0]["book_description"].ToString();
                    ddl_Language.SelectedValue = dt.Rows[0]["language"].ToString();
                    ddl_PublisherName.SelectedValue = dt.Rows[0]["publisher_name"].ToString();
                    ddl_AuthorName.SelectedValue = dt.Rows[0]["author_name"].ToString();
                    Lb_Genre.ClearSelection();
                    string[] genre = dt.Rows[0]["genre"].ToString().Trim().Split(',');
                    for (int i = 0; i < genre.Length; i++)
                    {
                        for (int j = 0; j < Lb_Genre.Items.Count; j++)
                        {
                            if (Lb_Genre.Items[j].ToString() == genre[i])
                            {
                                Lb_Genre.Items[j].Selected = true;
                            }
                        }
                    }
                    global_actual_stock = Convert.ToInt32(dt.Rows[0]["actual_stock"].ToString().Trim());
                    global_current_stock = Convert.ToInt32(dt.Rows[0]["current_stock"].ToString().Trim());
                    global_issued_books = global_actual_stock - global_current_stock;
                    global_filepath = dt.Rows[0]["book_img_link"].ToString();
                }
                else
                {
                    Response.Write("<script>alert('Invalid Book Id');</script>");
                }
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            void NewMethod(SqlDataAdapter da, DataTable dt)
            {
                da.Fill(dt);
            }
        }
        void FillAuthorPublisherValues()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("spFillAuthorPublisherValues", con);
                cmd.CommandType = CommandType.StoredProcedure;
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                ddl_AuthorName.DataSource = dt;
                ddl_AuthorName.DataValueField = "author_name";
                ddl_AuthorName.DataBind();
                cmd = new SqlCommand("spFillValues", con);
                cmd.CommandType = CommandType.StoredProcedure;
                da = new SqlDataAdapter(cmd);
                dt = new DataTable();
                NewMethod(da, dt);
                ddl_PublisherName.DataSource = dt;
                ddl_PublisherName.DataValueField = "publisher_name";
                ddl_PublisherName.DataBind();
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
            void NewMethod(SqlDataAdapter da, DataTable dt)
            {
                da.Fill(dt);
            }
        }
        bool CheckIfBookExists()
        {
            try
            {
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("spCheckBookExist", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@book_id", txt_BookId.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", txt_BookName.Text.Trim());
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
        void AddNewBook()
        {
            try
            {
                string genre = "";
                foreach (int i in Lb_Genre.GetSelectedIndices())
                {
                    genre = genre + Lb_Genre.Items[i] + ",";
                }
                //genres = Adventure,Self Help,
                genre = genre.Remove(genre.Length - 1);
                string filepath = "~/book_inventory/books1.png";
                string filename = Path.GetFileName(FileUpload1.PostedFile.FileName);
                FileUpload1.SaveAs(Server.MapPath("~/book_inventory/" + filename));
                filepath = "~/book_inventory/" + filename;
                SqlConnection con = new SqlConnection(strcon);
                if (con.State == ConnectionState.Closed)
                {
                    con.Open();
                }
                SqlCommand cmd = new SqlCommand("spAddNewBook", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@book_id", txt_BookId.Text.Trim());
                cmd.Parameters.AddWithValue("@book_name", txt_BookName.Text.Trim());
                cmd.Parameters.AddWithValue("@genre", genre);
                cmd.Parameters.AddWithValue("@author_name", ddl_AuthorName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publisher_name", ddl_PublisherName.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@publish_date", txt_PublishDate.Text.Trim());
                cmd.Parameters.AddWithValue("@language", ddl_Language.SelectedItem.Value);
                cmd.Parameters.AddWithValue("@edition", txt_Edition.Text.Trim());
                cmd.Parameters.AddWithValue("@book_cost", txt_BookCost.Text.Trim());
                cmd.Parameters.AddWithValue("@no_of_pages", txt_Pages.Text.Trim());
                cmd.Parameters.AddWithValue("@book_description", txt_BookDescription.Text.Trim());
                cmd.Parameters.AddWithValue("@actual_stock", txt_ActualStock.Text.Trim());
                cmd.Parameters.AddWithValue("@current_stock", txt_CurrentStock.Text.Trim());
                cmd.Parameters.AddWithValue("@book_img_link", filepath);
                cmd.ExecuteNonQuery();
                con.Close();
                FillGrid2();
                GridView1.DataBind();
                Response.Write("<script>alert('Book Added Successfully...');</script>");
            }
            catch (Exception ex)
            {
                Response.Write("<script>alert('" + ex.Message + "');</script>");
            }
        }
    }
}