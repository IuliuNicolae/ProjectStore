using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class insertCustomer : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    String queryStr;
    //int count=0;
    string firstName;
    string lastName;
    string pass;
    string email;
    string street;
    string phone;
    protected void Page_Load(object sender, EventArgs e)
    {
       
        firstName = Request.QueryString["fnm"].ToString();
        lastName = Request.QueryString["lnm"].ToString();
        pass = Request.QueryString["pass"].ToString();
        email = Request.QueryString["em"].ToString();
        street = Request.QueryString["adr"].ToString();
        phone = Request.QueryString["ph"].ToString();
        System.Diagnostics.Debug.WriteLine("SomeText2 " + pass);

        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();
        queryStr = "";
        queryStr = "INSERT INTO customers (email,firstName,lastName,password,address,phone) values('" + email + "','" + firstName + "','" + lastName + "','" + pass + "','" + street + "','" + phone + "')";
        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
        cmd.ExecuteReader();
        conn.Close();
    }
}