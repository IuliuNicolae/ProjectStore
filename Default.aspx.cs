using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    int numberOfItems = 0;
    protected void Page_Load(object sender, EventArgs e)
    {
        List<Movies> myMovies= new List<Movies>();
        Session["myMovies"] = myMovies;
        Session["nbrOfItems"] = numberOfItems;
    }

    protected void Button1_Click(object sender, EventArgs e)
    {
        Session["searchQuerry"] = textBoxSearch.Text;
        System.Diagnostics.Debug.WriteLine("SomeText1 " + textBoxSearch.Text);
        Response.Redirect("BookPage.aspx");
    }

}