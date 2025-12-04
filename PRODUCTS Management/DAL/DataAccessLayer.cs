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
            sqlconnection = new SqlConnection(@"Server=DESKTOP-C4D8PIL;Database=Produts_Management; Integrated Security=true;TrustServerCertificate=True");
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
        public DataTable SelectData(string stored_procedure, SqlParameter[] param)
        {
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;
            if (param != null)
            {
                for(int i = 0; i < param.Length; i++)
                {
                    sqlcmd.Parameters.Add(param[i]);
                }
            }
            SqlDataAdapter da = new SqlDataAdapter(sqlcmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            return dt;

        }
        
        // Method to Insert , Update and Delete Data from Database

        public void ExecuteCommand(string stored_procedure, SqlParameter[] param)
        {
            
            SqlCommand sqlcmd = new SqlCommand();
            sqlcmd.CommandType = CommandType.StoredProcedure;
            sqlcmd.CommandText = stored_procedure;
            sqlcmd.Connection = sqlconnection;
            if (param != null)
            {
                sqlcmd.Parameters.AddRange(param);

            }
            sqlcmd.ExecuteNonQuery();
        }

    }
}