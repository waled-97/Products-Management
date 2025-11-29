using System;
using System.Collections.Generic;

using System.Text;

using System.Data.SqlClient;
using System.Data;
using Microsoft.Data.SqlClient;

namespace PRODUCTS_Management.DAL
{

    class DataAccessLayer
    {
        SqlConnection sqlconnection;

        // THis Constructor Inisialize the connection object
        public DataAccessLayer()
        {
            sqlconnection = new SqlConnection(@"Server=DESKTOP-7SAEUKK;Product_DB; Integrated Security=true");
        }

        //Method Open the connection
        public void Open()
        {
            if (sqlconnection.State != ConnectionState.Open)
            {
                sqlconnection.Open();
            }
        }
        // Method to close the connection
        public void Close()
        {
            if(sqlconnection.State == ConnectionState.Open)
            {
                sqlconnection.Close(); 
            }
        }

    }
}