using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    int numberOfItems = 0;
    string opr;
    protected void Page_Load(object sender, EventArgs e)
    {
        opr = "";
        List<Movies> myMovies = new List<Movies>();
        Session["myMovies"] = myMovies;
        Session["nbrOfItems"] = numberOfItems;

      // opr = Request.QueryString["opr"].ToString();

      
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["searchQuerry"] = textBoxSearch.Text;
        Response.Redirect("BookPage.aspx");
    }
    

}