using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Search : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    string queryStr;
    
    string artists;


    String q;
    protected void Page_Load(object sender, EventArgs e)
    {
        q= Request.QueryString["q"].ToString();
        System.Diagnostics.Debug.WriteLine("SomeText1 "+q);
        display(q);
    }


     protected void display(string s) {
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();
        queryStr = "";
        queryStr = "SELECT artists from movies where title= '" + s + "'";
        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
        
            artists = reader.GetString(reader.GetOrdinal("artists"));
          
        }
        conn.Close();

        Response.Write(artists);
    }
}