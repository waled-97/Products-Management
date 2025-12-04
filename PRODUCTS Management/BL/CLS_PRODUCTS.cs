using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace PRODUCTS_Management.BL
{
    internal class CLS_PRODUCTS
    {
        public DataTable GET_ALL_CATEGORIES()
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
           
                        
            DataTable Dt = new DataTable();
            Dt = DAL.SelectData("GET_ALL_CATEGORIES", null);
            DAL.Close();
            return Dt;

        }
        public void ADD_PRODUCT(int ID_Cat,string label_product,string ID_product,int Qte,string Price,byte[] img)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DAL.Open();
            SqlParameter[] param = new SqlParameter[6];
            param[0] = new SqlParameter("@ID_CAT", SqlDbType.Int);
            param[0].Value = ID_Cat;

            param[1] = new SqlParameter("@ID_PRODUCT", SqlDbType.VarChar,30);
            param[1].Value = ID_product;

            param[2] = new SqlParameter("@LABEL_PRODUCT", SqlDbType.VarChar,30);
            param[2].Value = label_product;

            param[3] = new SqlParameter("@QTE", SqlDbType.Int);
            param[3].Value = Qte;

            param[4] = new SqlParameter("@PRICE", SqlDbType.VarChar,50);
            param[4].Value = Price;

            param[5] = new SqlParameter("@Img", SqlDbType.Image);
            param[5].Value = img;
            DAL.ExecuteCommand("ADD_PRODUCT", param);
            DAL.Close();

        }

        public DataTable verifyProductID(string ID)
        {
            DAL.DataAccessLayer DAL = new DAL.DataAccessLayer();
            DataTable Dt = new DataTable();
            SqlParameter[] param =new SqlParameter[1];
            param[0] = new SqlParameter("@ID",SqlDbType.VarChar,50);
            param[0].Value = ID;
            Dt = DAL.SelectData("GET_ALL_CATEGORIES", param);
            DAL.Close();
            return Dt;

        }
    }
}
