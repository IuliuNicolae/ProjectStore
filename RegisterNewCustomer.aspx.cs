using System;

public partial class RegisterNewCustomer : System.Web.UI.Page
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
        
      
    }



    protected void Button10_Click(object sender, EventArgs e)
    {
       
            registerUser();
         
        
    }
    private void registerUser()
    {
        firstName = textBoxFName.Text;
        lastName = textBoxLName.Text;
        pass = textBoxPass.Text;
        email = textBoxEmail.Text;
        street = textBoxStreet.Text;
        phone = textBoxPhone.Text;
        System.Diagnostics.Debug.WriteLine("SomeText2 " + pass);

        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
                queryStr = "";
                queryStr = "INSERT INTO customers (email,firstName,lastName,password,address,phone) values('" + email  + "','" + firstName + "','" + lastName + "','" + pass + "','" + street + "','" + phone + "')";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                cmd.ExecuteReader();
                conn.Close();
        clearBoxes();
      
    }
    private void clearBoxes()
    {
        textBoxFName.Text = " ";
        textBoxPass.Text = " ";
        textBoxEmail.Text = " ";
        textBoxPass2.Text = " ";
        textBoxStreet.Text = " ";
        textBoxPhone.Text = " ";
    }
    
}