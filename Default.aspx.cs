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
            if (!Page.IsPostBack)
            {
                BindGongSi();
            }

        }

        public void GetMenDian1()
        {
            string strSa = "", strSql = "select * from MenDian where GS_ID in(";
            if (cbl_GongSi.Items[0].Selected)
            {
                strSql = "select * from MenDian";
            }
            else
            {
                for (int i = 0; i < cbl_GongSi.Items.Count; i++)
                {
                    if (this.cbl_GongSi.Items[i].Selected)
                    {
                        strSa = cbl_GongSi.SelectedValue + ",";
                    }

                }
                strSql = strSql + strSa + ")";
            }

            GetMenDian();
        }
        public void GetMenDian()
        {
            string strSql = "select * from MenDian where MD_GSID in (2)";
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString);
            conn.Open();            
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds);
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
            conn.Close();
        }

        public void BindGongSi()
        {
            SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["strConn"].ConnectionString);
            String strSql = "select * from GongSi";
            conn.Open();
            SqlCommand cmd = new SqlCommand(strSql, conn);
            SqlDataAdapter adp = new SqlDataAdapter(cmd);
            DataSet ds = new DataSet();
            adp.Fill(ds,"dsgongsi");
            cbl_GongSi.DataSource=ds.Tables[0];
            cbl_GongSi.DataTextField = "GS_Name";
            cbl_GongSi.DataValueField = "GS_ID";
            cbl_GongSi.DataBind();
            cbl_GongSi.SelectedValue="1";
            conn.Close();

        }

        protected void cbl_GongSi_SelectedIndexChanged(object sender, EventArgs e)
        {
            int i,j=0;
            for (i = 0; i < cbl_GongSi.Items.Count; i++)
            {
                if ( cbl_GongSi.Items[0].Selected == true && cbl_GongSi.Items[i].Selected == true)
                {
                    cbl_GongSi.Items[0].Selected = false;
                }
            }
           
        }
    }
}
