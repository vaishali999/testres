using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

public partial class Default3 : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (Session["ss"] == null)
        {
            DataTable ord = new DataTable("table");
            DataColumn c = new DataColumn();
            c.ColumnName = "ordmnuitmcod";
            c.DataType = Type.GetType("system.int32");
            ord.Columns.Add(c);
            ord.Columns.Add(new DataColumn("ordmnuitmnam", Type.GetType("System.String")));
            ord.Columns.Add(new DataColumn("ordmnuitmdsc", Type.GetType("System.String")));
            ord.Columns.Add(new DataColumn("ordmnuitmprc", Type.GetType("System.String")));
            ord.Columns.Add(new DataColumn("ordmnuitmrescod", Type.GetType("System.String")));
            ord.Columns.Add(new DataColumn("ordmnuitmamt", Type.GetType("System.String")));

            Session["ss"] = ord;

            if (Page.IsPostBack == false)
            {
                String qry = "select * from tbmnuitm where mnuitmcod=" + Request.QueryString["mcod"].ToString();
                SqlDataAdapter adp = new SqlDataAdapter(qry, ConfigurationManager.ConnectionStrings["cn"].ConnectionString);
                DataSet ds = new DataSet();
                adp.Fill(ds);
                DataRowView r = ds.Tables[0].DefaultView[0];
                DataTable tb = (DataTable)(Session["ss"]);

                DataRow datarow = tb.AsEnumerable().FirstOrDefault(p => Convert.ToInt32(p["ordmnuitmcod"]) == Convert.ToInt32(Request.QueryString["mcod"]));
                if (datarow == null)
                {
                    DataRow r1 = tb.NewRow();
                    r1[0] = Convert.ToInt32(r["mnuitmcod"]);
                    r1[1] = r["mnuitmnam"].ToString();
                    r1[2] = r["mnuitmdsc"].ToString();
                    r1[3] = Convert.ToInt32(r["mnuitmprc"]);
                    r1[4] = Convert.ToInt32(r["mnuitmrescod"]);
                    r1[5] = 1;
                    tb.Rows.Add(r1);
                }
                    GridView1.DataSource = tb;
                    GridView1.DataBind();


                    Label1.Text = "Amount Total  " + tb.Compute("sum(ordmnuamt)", "").ToString();

                }
            }
}

    private void grd_bind()
    {

        DataTable tb = (DataTable)(Session["ss"]);
        Label1.Text = tb.Compute("sum(ordmnuamt)", "").ToString();

        GridView1.DataSource = tb;
        GridView1.DataBind();

    }
}

    
    
    
