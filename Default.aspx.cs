using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data.SqlClient;
using System.Configuration;
using System.Data;

namespace mendian
{
    public partial class _Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        public void GetMenDian()
        {
            //读取数据库连接字符串
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString);
            string strSql = "";
            //复制sql语句
            strSql = "select * from MenDian";// where MD_GSID = 3";// + cbl_GongSi.SelectedValue;// +" and Fy_ShangQuan = " + rblSQ.SelectedValue + "
            //执行sql语句
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
            //处理搜索结果
            System.Text.StringBuilder text = new System.Text.StringBuilder();
            if (ds.Tables.Count > 0)
            {
                Response.Write("var MenDians=new Array();");

                for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                {
                    text.AppendFormat("MenDians[{0}]  = '{1}';", i.ToString(), ds.Tables[0].Rows[i]["MD_Name"].ToString() + "," + ds.Tables[0].Rows[i]["MD_BMaps"].ToString());

                }
                text.Remove(text.Length - 1, 1);
                Response.Write(text);
            }
        }
    }
}
