using System;
using System.Collections.Generic;
using System.Globalization;
using System.Web.UI.WebControls;

public partial class CheckOut : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    String queryStr;


    Customers actualCustomer;
    List<Movies>movies;
    private double totalPrice;
    protected void Page_Load(object sender, EventArgs e)
    {
        actualCustomer = new Customers();
        actualCustomer = (Customers)Session["myCustomer"];
        movies = (List<Movies>)Session["myMovies"];
        if (movies.Count == 0)
        {
           labelPrice.Text = "The cart is empty or you are not logged in!!!!";
        }
        else
        {
            showContent.DataSource = movies;
            showContent.DataBind();
            labelPrice.Text = getPrice(movies);
        }
    }


    protected void Button10_Click(object sender, EventArgs e)
    {
        Session["myMovies"] = movies;
        Response.Redirect("BookPage.aspx");
    }



    protected void showContent_RowDeleting(object sender, GridViewDeleteEventArgs e)
    {
      
        labelPrice.Text = "";
        int id = Convert.ToInt32(e.RowIndex);
        string idTemp = movies[id].Id;
        string tempMyQuantity = movies[id].Quantity;
        string allQantity = getAllQuantity(idTemp);
        int tempNewQ = (Convert.ToInt32(allQantity) + Convert.ToInt32(tempMyQuantity));
        updateQuantity(tempNewQ, idTemp);
        movies.RemoveAt(id);
        showContent.DataBind();
        labelPrice.Text = getPrice(movies) + " ";

    }
    protected string getPrice(List<Movies> b)
    {
        totalPrice = 0;
        string price = "";
        if (b.Count > 0)
        {
            for (int i = 0; i < b.Count; i++)
            {
                string tempPrice = b[i].Price;
                double tempPrice1 = Convert.ToDouble(tempPrice, CultureInfo.InvariantCulture);
                totalPrice = totalPrice + tempPrice1;
            }
            price = totalPrice + "";
            labelPrice.Text = totalPrice + "";
            // Session["totalPrice"] = totalPrice + "";
        }
        else
        {
            price = "0";
        }
        return price;
    }
    protected void addOrder()
    {
        string allTitles = null;
        string price = totalPrice + "";
        string emailCustomer = actualCustomer.Email;
        for (int i = 0; i < movies.Count; i++)
        {
            allTitles = allTitles + movies[i].Title + "; ";

        }

        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();
        queryStr = "";
        queryStr = "insert into orders (customerId,titles,totalPrice) values ('" + emailCustomer + "','" + allTitles + "','" + price + "')";
        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
        cmd.ExecuteReader();
        conn.Close();

    }

    protected void buttonPay_Click(object sender, EventArgs e)
    {
        
        addOrder();
        movies.Clear();

        Session["myMovies"] = movies;
        Response.Redirect("Default.aspx");

    }



    protected string getAllQuantity(string s) {
        string q = "0";
       
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "";
            queryStr = "SELECT * from movies where id= '" + s + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            reader = cmd.ExecuteReader();
            while (reader.Read())
            { 
                q = reader.GetString(reader.GetOrdinal("quantity"));
            }
        conn.Close();
        return q;
    }
    protected void updateQuantity(int q, string id)
    {
       
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
            conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
            conn.Open();
            queryStr = "";
            queryStr = "update  movies set quantity = '" + q + "' where id = '" + id + "'";
            cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
            cmd.ExecuteReader();
            conn.Close();

        }
       

    
}
