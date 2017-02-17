using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class RegisterNewBook : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    String queryStr;
   // int count = 0;
    String category = "XXX ";
    protected void Page_Load(object sender, EventArgs e)
    {
    }
    protected void DropDownList2_SelectedIndexChanged(object sender, EventArgs e)
    {
        category = ddlCategory.SelectedItem.Text;
        System.Diagnostics.Debug.WriteLine("SomeText " + category);
    }
    protected void Button10_Click(object sender, EventArgs e)
    {
        registerBook();
    }
    private void registerBook()
    {
        
           
                String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
                conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
                conn.Open();
                queryStr = "";
                queryStr = "INSERT INTO movies (id,title,category,artists,price,quantity,imdbLink,picture) " + "values( " +1+ ",'"+ textBoxTitle.Text + "','" + category  + "','"+ textBoxDistribution.Text+"','" + textBoxPrice.Text  + "','"+ textBoxQuantity.Text + "','"+ textBoxIMBD.Text +"','"+textBoxPicture.Text+ "')";
                cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
                cmd.ExecuteReader();
                conn.Close();
            
       
        
        clearBoxes();
    }
    private void clearBoxes()
    {
        textBoxTitle.Text = " ";
        textBoxDistribution.Text = " ";
        textBoxIMBD.Text = " ";
        textBoxPrice.Text = " ";
        textBoxPicture.Text = "";
        textBoxQuantity.Text = "";
        ddlCategory.SelectedIndex = 0;
    }





    protected void Button11_Click(object sender, EventArgs e)
    {
        Response.Redirect("AdminTools.aspx");
    }
}