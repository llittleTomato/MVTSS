using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlClient;

namespace MainProject
{
    class DataCon
    {
        public SqlConnection getCon()
        {
            string dataDir = AppDomain.CurrentDomain.BaseDirectory;
            //SqlConnection oledbCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=F:\科研\项目\基于机器视觉技术的曳引轮绳槽参数测量研究\程序\MVTSS-2017.11.30\MVTSS\MainProject\bin\Debug\MVTSS.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            SqlConnection oledbCon = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=|DataDirectory|MVTSS.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
            return oledbCon;
        }
    }
}
