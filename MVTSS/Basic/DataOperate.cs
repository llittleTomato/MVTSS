using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace MainProject
{
    class DataOperate
    {
        DataCon datacon = new DataCon();
        SqlConnection oledbcon;
        SqlCommand oledbcom;
        SqlDataAdapter oledbda;
        DataSet ds;

        public void getCom(string strCon)
        {
            oledbcon = datacon.getCon();
            oledbcom = new SqlCommand(strCon, oledbcon);
            oledbcon.Open();
            oledbcom.ExecuteNonQuery();
            oledbcon.Close();
        }

        public DataSet getDs(string strCon, string tbname)
        {
            oledbcon = datacon.getCon();
            oledbda = new SqlDataAdapter(strCon, oledbcon);
            ds = new DataSet();
            oledbda.Fill(ds, tbname);
            return ds;
        }

        public DataSet getComDs(string strCon,string tb, string tbname)
        {
            oledbcon = datacon.getCon();
            oledbcom = new SqlCommand(strCon, oledbcon);
            oledbcon.Open();
            oledbcom.ExecuteNonQuery();
            strCon = "select * from " + tb;
            oledbda = new SqlDataAdapter(strCon, oledbcon);
            ds = new DataSet();
            oledbda.Fill(ds, tbname);
            return ds;
        }
    }
}
