using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Books
/// </summary>
public class Movies
{
    string id;
    string title;
    string category;
    string artists;
    string price;
    string quantity;
    string imdbLink;
    string picture;
  

    public string Id
    {
        get
        {
            return id;
        }

        set
        {
            id = value;
        }
    }

    public string Title
    {
        get
        {
            return title;
        }

        set
        {
            title = value;
        }
    }

    public string Artists
    {
        get
        {
            return artists;
        }

        set
        {
            artists = value;
        }
    }

    public string Quantity
    {
        get
        {
            return quantity;
        }

        set
        {
            quantity = value;
        }
    }

    public string ImdbLink
    {
        get
        {
            return imdbLink;
        }

        set
        {
            imdbLink = value;
        }
    }

    public string Picture
    {
        get
        {
            return picture;
        }

        set
        {
            picture = value;
        }
    }

    public string Price
    {
        get
        {
            return price;
        }

        set
        {
            price = value;
        }
    }

    public string Category
    {
        get
        {
            return category;
        }

        set
        {
            category = value;
        }
    }

    public Movies()
    {
        
    }
    public Movies( string id,string title,string category,string artists,string price,string quantity, string imdbLink, string picture) {
        this.id = id;
        this.title = title;
        this.category = category;
        this.artists = artists;
        this.price = price;
        this.quantity = quantity;
        this.imdbLink = imdbLink;
        this.picture = picture;
      
      
            }
    public Movies( string id, string title,string category, string artists, string price, string quantity)
    {
        this.id = id;
        this.title = title;
        this.category = category;
        this.artists = artists;
        this.price = price;
        this.quantity = quantity;
       

    }
}