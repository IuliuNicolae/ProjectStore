using MySql.Data.MySqlClient;
using System;
using System.Data;
using System.Web.UI.WebControls;

public partial class AllCustomers : System.Web.UI.Page
{
    MySqlConnection conn;
    MySqlCommand cmd;

    String queryStr;
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!IsPostBack) {
            BindData();

        }
    }

    protected void BindData()
    {


        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        DataTable dt = new DataTable();
        using (MySqlConnection cn = new MySqlConnection(connString))
        {


            MySqlDataAdapter adp = new MySqlDataAdapter("select email,firstName,lastName,address,phone from customers", cn);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
               allCustomersTable.DataSource = dt;
                allCustomersTable.DataBind();
            }
        }

    }

   
    private void DeleteRecord(string email)
    {
       
        
        try
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
            conn = new MySqlConnection(connString);
            conn.Open();
            queryStr = "";
            queryStr = "delete from customers where email='" + email + "'";
            cmd = new MySqlCommand(queryStr, conn);
            cmd.ExecuteReader();
            conn.Close();
        }
        catch (System.Data.SqlClient.SqlException ex)
        {
            string msg = "Deletion Error:";
            msg += ex.Message;
            throw new Exception(msg);

        }
        
    }

    protected void allCustomersTable_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
        string email = allCustomersTable.Rows[e.RowIndex].Cells[1].Text;
        DeleteRecord(email);
        BindData();
    }
}