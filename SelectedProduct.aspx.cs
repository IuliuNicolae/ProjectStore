using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class SelectedProduct : System.Web.UI.Page
{
    MySql.Data.MySqlClient.MySqlConnection conn;
    MySql.Data.MySqlClient.MySqlCommand cmd;
    MySql.Data.MySqlClient.MySqlDataReader reader;
    string queryStr;
    string id;
    string title;
    string category;
    string artists;
    //string customerRate;
   // string coments;
    string price;
    string quantity;
    string imdbLink;
    string picture;
    int myQuantity;
    int numberOfItems;
    List<Movies> myMovies;
  
    protected void Page_Load(object sender, EventArgs e)
    {

        id= (string)Session["ID"];
        numberOfItems = Convert.ToInt32(Session["nbrOfItems"]);      
       // 
        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        conn = new MySql.Data.MySqlClient.MySqlConnection(connString);
        conn.Open();
        queryStr = "";
        queryStr = "SELECT * from movies where id= '"+id+"'";
        cmd = new MySql.Data.MySqlClient.MySqlCommand(queryStr, conn);
        reader = cmd.ExecuteReader();
        while (reader.Read())
        {
            title = reader.GetString(reader.GetOrdinal("title"));
            artists = reader.GetString(reader.GetOrdinal("artists"));
            category = reader.GetString(reader.GetOrdinal("category"));
           // customerRate = reader.GetString(reader.GetOrdinal("customerRate"));
            //coments = reader.GetString(reader.GetOrdinal("coments"));
            price = reader.GetString(reader.GetOrdinal("price"));
            quantity = reader.GetString(reader.GetOrdinal("quantity"));
            imdbLink = reader.GetString(reader.GetOrdinal("imdbLink"));
            picture = reader.GetString(reader.GetOrdinal("picture"));
        }
        conn.Close();
        labelTitle.Text = title;
        LabelCategory.Text = category;
        labelDistribution.Text = artists;
        LabelIMDB.Text = imdbLink;
       // labelRate.Text = customerRate;
        labelPrice.Text = price;
        labelQuantity.Text = quantity;
        imageBook.ImageUrl = "~/Styles/" + picture + ".gif";
    }






    protected void btnAddCart_Click(object sender, EventArgs e)
    {
        if (boxQuantity.Text != null)
        {
            myQuantity = Convert.ToInt32(boxQuantity.Text);
        }
        else {
            myQuantity = 0;
        }
        int tempQuantity = Convert.ToInt32(quantity);
       double tempPrice = Convert.ToDouble(price, CultureInfo.InvariantCulture);
        if (myQuantity <= 0)
        {
            labelError.Text = "How many movies do you want?";
        }
        else if (myQuantity > tempQuantity)
        {
            labelError.Text = "There are not enough movies";
        }
        else
        {

            Customers actual = new Customers();
            actual = (Customers)Session["myCustomer"];
            string name = "";
            if (actual == null)
            {
                Label7.Text = "You must login first!!!!";
            }
            else
            {

                Label7.Text = "";
                labelDistribution.Text = name;
                int i = tempQuantity - myQuantity;
               
                tempPrice = tempPrice * myQuantity;
                string mySquantity = myQuantity + "";
                price = tempPrice + "";
                updateQuantity(i, id);
                myMovies = (List<Movies>)Session["myMovies"];
                myMovies.Add(new Movies(id, title,category, artists, price, mySquantity));
                Session["myMovies"] = myMovies;
                Response.Redirect("CheckOut.aspx");

            }
        }
    }


    protected void btnBack_Click(object sender, EventArgs e)
    {
        Response.Redirect("BookPage.aspx");
    }

    protected void updateQuantity(int q, string id)
    {
        try
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
        catch (MySql.Data.MySqlClient.MySqlException ex)
        {
            Response.Redirect("Error.aspx");
        }

    }

}