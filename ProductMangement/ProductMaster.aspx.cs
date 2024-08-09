using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;

namespace ProductMangement
{
    public partial class ProductMaster : System.Web.UI.Page
    {
        string strcon = ConfigurationManager.AppSettings["ConnectionString"].ToString();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
               
                Resetsearch();
                
                SearchDetails();
            }
        }

       
        public void Resetsearch()
        {
            txtProductName.Text = string.Empty;
            txtPrice.Text = string.Empty;
            txtDate.Text = string.Empty;
            ddlCategory.SelectedValue = "0";
            ddlSize.SelectedValue = "0";
            SearchDetails();
        }
        public void SearchDetails()
        {
            try
            {


                string ProductName, Size, Catagory, Mfgdate, Price;

                if (txtProductName.Text == "")
                {
                    ProductName = "";
                }
                else
                {
                    ProductName = txtProductName.Text;
                }
                if (ddlSize.SelectedValue == "0")
                {
                    Size = "";
                }
                else
                {
                    Size = ddlSize.SelectedValue;
                }
                if (txtPrice.Text == "")
                {
                    Price = "";
                }
                else
                {
                    Price = txtPrice.Text;
                }
                if (ddlCategory.SelectedValue == "0")
                {
                    Catagory = "";
                }
                else
                {
                    Catagory = ddlCategory.SelectedValue;
                }
                if (txtDate.Text == "")
                {
                    Mfgdate = "";
                }
                else
                {
                    Mfgdate = txtDate.Text;
                }
                SqlConnection con = new SqlConnection(strcon);

                SqlCommand cmd = new SqlCommand();
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.CommandText = "[ProductSearch]";

                cmd.Parameters.Add("@ProductName", SqlDbType.VarChar).Value = ProductName;
                cmd.Parameters.Add("@Size", SqlDbType.VarChar).Value = Size;
                if (string.IsNullOrWhiteSpace(Price))
                {
                    cmd.Parameters.Add("@Price", SqlDbType.Float).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@Price", SqlDbType.Float).Value = Convert.ToDouble(Price);
                }
                if (string.IsNullOrWhiteSpace(Mfgdate))
                {
                    cmd.Parameters.Add("@MfgDate", SqlDbType.VarChar).Value = DBNull.Value;
                }
                else
                {
                    cmd.Parameters.Add("@MfgDate", SqlDbType.VarChar).Value = Convert.ToDateTime(Mfgdate).ToString("yyyy-MM-dd");
                }


                cmd.Parameters.Add("@Category", SqlDbType.VarChar).Value = Catagory;

                cmd.Connection = con;
                con.Open();
                grdProduct.EmptyDataText = "No Records Found";

                SqlDataReader dr = cmd.ExecuteReader();
                grdProduct.DataSource = dr;


                grdProduct.DataBind();
                con.Close();
            }
            catch(Exception e)
            {
                Console.WriteLine(String.Concat(e.Message,e.StackTrace));
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchDetails();
        }

        protected void dtMFG_SelectionChanged(object sender, EventArgs e)
        {
            txtDate.Text = dtMFG.SelectedDate.ToString();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            Resetsearch();
        }
    }
    
}