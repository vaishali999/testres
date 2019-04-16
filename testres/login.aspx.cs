using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class login : System.Web.UI.Page
{
    SqlConnection con = new SqlConnection();

    protected void Page_Load(object sender, EventArgs e)
    {
        con.ConnectionString = ConfigurationManager.ConnectionStrings["cn"].ConnectionString;
        if (con.State == ConnectionState.Closed)
        {
            con.Open();
        }
    }

    protected void Button1_Click(object sender, EventArgs e)
    {

        Int32 d = Checkusr(TextBox1.Text, TextBox2.Text);
        if (Session["log"] == null)
        {
            Response.Write("<script>alert(d)</script)");
        }
        if (d == -1)
        {
            Response.Write("<script>alert('wrong username.try again.')</script)");
            TextBox1.Text = String.Empty;
            TextBox2.Text = String.Empty;

        }
        if (d == -2)
        {
            Response.Write("<script>alert('wrong username.try again.')</script)");
            TextBox2.Text = String.Empty;

        }
        if (d == 1)
        {
            if (Session["again"] == null)
            {
                Session["log"] = 1;
                Response.Redirect("dafault.aspx");
            }
            else
            {
                String alpha = Session["again"].ToString();

                Session["log"] = 1;
                Response.Redirect("dafault2.aspx?fid=" + alpha);
            }
        }
    }

    private Int32 Checkusr(String u, String p)
    {
        SqlCommand cmd = new SqlCommand("logincheck", con);
        cmd.CommandType = CommandType.StoredProcedure;
        cmd.Parameters.Add("@un", SqlDbType.VarChar, 50).Value = u;
        cmd.Parameters.Add("@up", SqlDbType.VarChar, 50).Value = p;
        cmd.Parameters.Add("@ret", SqlDbType.Int);
        cmd.Parameters["@ret"].Direction = ParameterDirection.ReturnValue;
        cmd.ExecuteNonQuery();
        Int32 k = Convert.ToInt32(cmd.Parameters["@ret"].Value);
        cmd.Dispose();
        return k;

    }

    protected void Button2_Click(object sender, EventArgs e)
    {
        if (Session["again"] != null)
        {
            Response.Write(Session["again"]);
            //Button2.Enabled = false;
        }
        else
        {
            Response.Redirect("Default.aspx");

        }
    }
}