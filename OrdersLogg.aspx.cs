using System;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Collections;

public partial class OrdersLogg : System.Web.UI.Page
{
 
    MySql.Data.MySqlClient.MySqlConnection conn;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack)
        {
            BindData();
                }

    }
    protected void BindData()
    {


        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        DataTable dt = new DataTable();
        using (MySqlConnection cn = new MySqlConnection(connString))
        {


            MySqlDataAdapter adp = new MySqlDataAdapter("select * from orders", cn);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                ordersTable.DataSource = dt;
                ordersTable.DataBind();
            }
        }

    }
}