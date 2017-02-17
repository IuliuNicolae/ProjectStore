using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Orders
/// </summary>
public class Orders
{
    int id;
    string customerId;
    string titles;
    string price;

    public int Id
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

    public string CustomerId
    {
        get
        {
            return customerId;
        }

        set
        {
            customerId = value;
        }
    }

    public string Titles
    {
        get
        {
            return titles;
        }

        set
        {
            titles = value;
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

    public Orders()
    {
        
    }
    public Orders(int id, string customerId, string titles, string price) {
        this.id = id;
        this.customerId = customerId;
        this.titles = titles;
        this.price = price;
    }
}