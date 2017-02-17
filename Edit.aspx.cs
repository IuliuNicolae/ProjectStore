using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class Edit : System.Web.UI.Page
{
    Administrator actualAdminNew;
    Administrator newAdministrator;
    Customers actualCustomerNew;
    Customers newCustomer;
    string user = "";
    

    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    string queryStr;

    protected void Page_Load(object sender, EventArgs e)
    {
        actualAdminNew = new Administrator();
        actualAdminNew = (Administrator)Session["myAdministrator"];
        actualCustomerNew = new Customers();
        actualCustomerNew = (Customers)Session["myCustomer"];
        
            if (actualAdminNew != null)  
            {
                user = "admin";
               
            }
            else if (actualCustomerNew != null)
            {
                user = "customer";
               

            }
           
        if (!IsPostBack) {

            if (user.Equals("admin"))
            {

                lbEm.Text = actualAdminNew.Email;
                textBoxName.Text = actualAdminNew.Name;
              
                textBoxPass.Text = actualAdminNew.Pass;
              
                textBoxPass2.Text = actualAdminNew.Pass;
                textBoxPhone.Visible = false;
                textBoxStreet.Visible = false;
          
            }
            else
            {
                lbEm.Text = actualCustomerNew.Email;
             
                textBoxName.Text = actualCustomerNew.FirstName;
              
                textBoxPass.Text = actualCustomerNew.Pass;
          
                textBoxPass2.Text = actualCustomerNew.Pass;
                textBoxStreet.Text = actualCustomerNew.Adress;
            
                textBoxPhone.Text = actualCustomerNew.Phone;
          
                
            }

          
          
        }
        }
    protected void Button10_Click(object sender, EventArgs e)
    {

      

            queryStr = "";
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();
        if (user.Equals("customer"))
            {
            System.Diagnostics.Debug.WriteLine(actualCustomerNew.Email + "      userrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrrr   " + user);
            queryStr = "update  customers set customerName='" + textBoxName.Text + "', customerPass='" + textBoxPass.Text + "', custommerStreet='" + textBoxStreet.Text + "', customerPhone='" + textBoxPhone.Text + "' where customerEmail='" + actualCustomerNew.Email + "'";
                newCustomer = new Customers(actualCustomerNew.Email,textBoxName.Text,textBoxPass.Text,actualCustomerNew.Pass,textBoxStreet.Text,textBoxPhone.Text);
                Session["myCustomer"] = newCustomer;
               
            }
            else if (user.Equals("admin"))
            {
                queryStr = "update administrator set administratorName='" + textBoxName.Text + "', administratorPass='" + textBoxPass.Text + "' where administratorEmail='" + actualAdminNew.Email + "'";
               newAdministrator = new Administrator(actualAdminNew.Id,textBoxName.Text,actualAdminNew.Email,textBoxPass.Text);
                Session["myAdministrator"] = newAdministrator;
            }
           

            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.ExecuteReader();
            conn.Close();
        Response.Redirect("Default.aspx");

    }
    protected void Button11_Click(object sender, EventArgs e)
    {
        Response.Redirect("Default.aspx");
    }

}