using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace mendian
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
                  GetHouse();
            Response.Write("111");
        }



        public void GetHouse()
        {
            string strConn = ConfigurationManager.ConnectionStrings["strConn"].ConnectionString;
            SqlConnection sqlConn = new SqlConnection(strConn);
            string strSql = "select * from User";
            SqlCommand sqlCmd = new SqlCommand(strSql, sqlConn);
            sqlConn.Open();
            SqlDataReader sqlRed = sqlCmd.ExecuteReader();
            strSql = sqlRed["User_Name"].ToString();
            Response.Write(strSql);
            sqlConn.Close();
            }
        }
    }