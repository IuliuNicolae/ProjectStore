using System;
using System.Web.UI.WebControls;
using System.Data;
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.Collections;

public partial class BookPage : System.Web.UI.Page
{

    String queryStr;
    protected void Page_Load(object sender, EventArgs e)
    {
         queryStr = (String)Session["searchQuerry"];
        
        if (!IsPostBack)
         {
             getData(this.queryStr);
         }
       

    }


    protected void BindData(String myQuerry)
    {


        String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
        DataTable dt = new DataTable();
        using (MySqlConnection cn = new MySqlConnection(connString))
        {


            MySqlDataAdapter adp = new MySqlDataAdapter(myQuerry, cn);
            adp.Fill(dt);
            if (dt.Rows.Count > 0)
            {
                gvBooks.DataSource = dt;
                gvBooks.DataBind();
            }
        }

    }

    protected void gvBooks_SelectedIndexChanged(object sender, EventArgs e)
    {
        Label lb = gvBooks.SelectedRow.FindControl("Label10") as Label;
        Label13.Text = lb.Text;
        Session["ISBN"] = Label13.Text;
        Response.Redirect("SelectedProduct.aspx");
    }
    protected void getData(String myString)
    {
        string querry = "";
        string pattern = ",";
       
        System.Diagnostics.Debug.WriteLine("String" +myString);
        String[] words = Regex.Split(myString, pattern);
        System.Diagnostics.Debug.WriteLine("Lenght" + words.Length);
       // string[] words =(string) myString.split(',');
        if (words.Length == 0)
        {

            querry = "Select * from movies";

        }
        else if (words.Length == 1)
        {
            
                querry = "SELECT * FROM movies WHERE (title LIKE'%" + words[0] + "%') OR (artists LIKE '%" + words[0] + "%') ";
                System.Diagnostics.Debug.WriteLine("SomeText3 " + querry);
                System.Diagnostics.Debug.WriteLine("SomeText4 " + words[0]);
            
        }
        else if (words.Length == 2)
        {
            querry = "SELECT * FROM books WHERE(title LIKE '%" + words[0] + "%') OR(title LIKE '%" + words[1] + "%') OR (artists LIKE '%" + words[0] + "%') OR" +
     "(artists LIKE '%" + words[1] + "%')  ORDER BY((CASE WHEN  title LIKE '%" + words[0] + "' THEN 1 ELSE 0 END )+(CASE WHEN title LIKE '%" + words[1] + "%' THEN 1 ELSE 0  END )+" +
"(CASE WHEN artists LIKE '%" + words[0] + "%' THEN 1 ELSE 0 END )+" +
"+(CASE WHEN artists LIKE '%" + words[1] + "%' THEN 1 ELSE 0 END ))  ASC";

        }


        BindData(querry);
    }


    protected void Button10_Click(object sender, EventArgs e)
    {
        String search = textBoxSearch.Text;
        String advancedQuerry = "select * from movies where title like '%" + search + "%' or artists like '%" + search + "%'";
        string qSup1 = "";
        string qSup2 = "";
        string qSup3 = "";
        Hashtable ht = new Hashtable();
        if (CheckBoxChildren.Checked)
        {
            ht.Add(1, "children");
        }
        if (CheckBoxRomance.Checked)
        {
            ht.Add(2, "romance");
        }
        if (CheckBoxThriller.Checked)
        {
            ht.Add(3, "thriller");
        }
        if (CheckBoxScience.Checked)
        {
            ht.Add(4, "science");

        }

        int size = ht.Count;
        if (size == 4)
        {
            advancedQuerry = "select * from movies where (title like '%" + search + "%' or artists like '%" + search + "%') and category='Romance' or category='Thriller'or category='Science'or category ='Children'";
        }
        else if (size == 0)
        {
            string a = "";
        }
        else if (size == 1)
        {
            for (int i = 1; i <= 4; i++)
            {
                if (ht.Contains(i))
                {
                    qSup1 = (string)ht[i];
                }
            }
            advancedQuerry = "select * from movies where (title like '%" + search + "%' or artists like '%" + search + "%') and category='" + qSup1 + "'";
        }
        else if (size == 2)
        {
            int i;
            for (i = 1; i <= 4; i++)
            {
                if (ht.Contains(i))
                {
                    qSup1 = (string)ht[i];
                    break;
                }
            }
            for (int j = i; j <= 4; j++)
            {
                if (ht.Contains(j))
                {
                    qSup2 = (string)ht[j];

                }

            }


            advancedQuerry = "select * from movies where (title like '%" + search + "%' or artists like '%" + search + "%') and category='" + qSup1 + "' or category ='" + qSup2 + "'";
        }
        else if (size == 3)
        {
            int i;
            int j;
            for (i = 1; i <= 4; i++)
            {
                if (ht.Contains(i))
                {
                    qSup1 = (string)ht[i];
                    break;
                }
            }
            for (j = i; j <= 4; j++)
            {
                if (ht.Contains(j))
                {
                    qSup2 = (string)ht[j];
                    break;
                }
                
            }
            for (int z = j; z <= 4; z++)
            {
                if (ht.Contains(z))
                {
                    qSup3 = (string)ht[z];
                    

                }
                
            }




            advancedQuerry = "select * from movies where (title like '%" + search + "%' or authorName like '%" + search + "%') and category='" + qSup1 + "' or category ='" + qSup2 + "' or category ='"+qSup3+"'";
        }
        BindData(advancedQuerry);

    }
    protected void menuCommando(string commando) {
        if (commando.StartsWith("£££")) {
            if (commando.Equals("£££All")) {
            }

        }
    }


    
    protected void gvBooks_SelectedIndexChanged1(object sender, EventArgs e)
    {
        GridViewRow row = gvBooks.SelectedRow;
        string id = row.Cells[1].Text;
        Label13.Text = id;
        Session["ID"] = id;
        Response.Redirect("SelectedProduct.aspx");
    }
}