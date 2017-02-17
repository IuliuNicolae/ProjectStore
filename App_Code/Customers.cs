using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Customers
/// </summary>
public class Customers

{
    
    string firstName;
    string lastName;
    string pass;
    string email;
    string adress;
    string phone;
    public Customers() {
    }
    public Customers(string firstName,string lastName,string email,string pass,string adress, string phone) {
        this.firstName = firstName;
        this.lastName = lastName;
        this.pass = pass;
        this.email = email;
        this.adress = adress;
        this.phone = phone;

    }
    public string FirstName
    {
        get
        {
            return firstName;
        }

        set
        {
            firstName = value;
        }
    }

    public string LastName
    {
        get
        {
            return lastName;
        }

        set
        {
            lastName = value;
        }
    }

    public string Pass
    {
        get
        {
            return pass;
        }

        set
        {
            pass = value;
        }
    }

    public string Email
    {
        get
        {
            return email;
        }

        set
        {
            email = value;
        }
    }

    public string Adress
    {
        get
        {
            return adress;
        }

        set
        {
            adress = value;
        }
    }

    public string Phone
    {
        get
        {
            return phone;
        }

        set
        {
            phone = value;
        }
    }
}