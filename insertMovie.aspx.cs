using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class insertMovie : System.Web.UI.Page
{
     MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    String queryStr;
    //int count=0;
    string title;
    string category;
    string artists;
    string price;
    string quantity;
    string imdbLink;
    string picture;
    string opr;
    protected void Page_Load(object sender, EventArgs e)
    {
        System.Diagnostics.Debug.WriteLine("SomeText1 " );

       
        opr= Request.QueryString["opr"].ToString();

        if (opr == "insert")
        {
            title = Request.QueryString["title"].ToString();
            category = Request.QueryString["cat"].ToString();
            artists = Request.QueryString["artists"].ToString();
            price = Request.QueryString["price"].ToString();
            quantity = Request.QueryString["quan"].ToString();
            imdbLink = Request.QueryString["link"].ToString();
            picture = Request.QueryString["pict"].ToString();
            System.Diagnostics.Debug.WriteLine("SomeText2 " + category);
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "";
            queryStr = "INSERT INTO movies (title,category,artists,price,quantity,imdbLink,picture) values( '" + title + "','" + category + "','" + artists + "','" + price + "','" + quantity + "','" + imdbLink + "','" + picture + "')";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.ExecuteReader();
            conn.Close();
        }
     /*   else if (opr == "display") {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
            DataTable dt = new DataTable();
            using (MySqlConnection cn = new MySqlConnection(connString))
            {


                MySqlDataAdapter adp = new MySqlDataAdapter("select * from movies", cn);
                adp.Fill(dt);
                if (dt.Rows.Count > 0)
                {
                    gridMovie.DataSource = dt;
                    gridMovie.DataBind();
                }
            }
        }*/
        
    }
}
