using System;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class dbConnection
{
    private dbConnection()
    {
    }
    MySqlConnection conn = null;
    private static dbConnection _instance = null;
    public static dbConnection Instance()
    {
        if (_instance == null)
            _instance = new dbConnection();
        return _instance;
    }
    public void connection()
    {
        System.Diagnostics.Debug.WriteLine("connect");
        try
        {
            String connString = System.Configuration.ConfigurationManager.ConnectionStrings["WebbAppConnString"].ToString();
            conn = new MySqlConnection(connString);
            conn.Open();
        }catch(Exception e)
        {
            System.Diagnostics.Debug.WriteLine(e.StackTrace);
        }
    }
    public void close() {
        if(conn != null)
        {
            conn.Close();
            System.Diagnostics.Debug.WriteLine("conn is closed");
        }
    }
    public MySqlDataReader Select(String sqlQuery)
    {
        System.Diagnostics.Debug.WriteLine("SELECT");
        connection();
        System.Diagnostics.Debug.WriteLine("Command: " +sqlQuery);
        MySqlCommand comm = new MySqlCommand(sqlQuery, conn);
        System.Diagnostics.Debug.WriteLine("Reader");
        MySqlDataReader result = comm.ExecuteReader();
        return result;
    }
    public void insert(String sqlQuery)
    {
        connection();
        MySqlCommand comm = new MySqlCommand(sqlQuery, conn);
        close();

    }

    
}