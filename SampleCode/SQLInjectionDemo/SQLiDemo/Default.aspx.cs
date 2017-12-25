using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace SQLiDemo
{
    public partial class _Default : Page
    {

        private SqlConnection sqlConn;
        private SqlCommand cmd;

        private readonly DBConnector objDBConnector;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadProduct();
            }

        }




        /// <summary>
        /// Constructor
        /// </summary>
        public _Default()
        {
            objDBConnector = new DBConnector();
            sqlConn = objDBConnector.GetConn();
            cmd = objDBConnector.GetCommand();
        }


        private void LoadProductInlineSQL()
        {
            DataTable tblEmpInfo = new DataTable();
            SqlDataReader rdr = null;
            string searchText = txtSearch.Text.Trim();

            //Basic fixing
            //searchText = Regex.Replace(searchText, "[^a-zA-Z0-9]", "");

            string query = string.Format(@"SELECT Name, Description, KeyWords FROM Product
                Where Name like '%{0}%' OR KeyWords like '%{0}%'", searchText);

            Trace.Write(String.Format("Query is: {0}", query));

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                rdr = cmd.ExecuteReader();
                tblEmpInfo.Load(rdr);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            this.gvProducts.DataSource = tblEmpInfo;
            this.gvProducts.DataBind();
            //return tblEmpInfo;
        }


        private void LoadParamQuery()
        {
            DataTable tblEmpInfo = new DataTable();
            SqlDataReader rdr = null;
            string searchText = txtSearch.Text.Trim();

            //Basic fixing
            //searchText = Regex.Replace(searchText, "[^a-zA-Z0-9]", "");

            string query = @"SELECT Name, Description, KeyWords FROM Product
                Where Name like '%' + @ProductName + '%'
                OR KeyWords like '%' + @ProductName + '%'";

            Trace.Write(String.Format("Query is: {0}", query));

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;
            cmd.Parameters.Add(new SqlParameter("@ProductName", searchText));

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                rdr = cmd.ExecuteReader();
                tblEmpInfo.Load(rdr);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            this.gvProducts.DataSource = tblEmpInfo;
            this.gvProducts.DataBind();
            //return tblEmpInfo;
        }


        private void LoadProductBySP()
        {
            DataTable tblEmpInfo = new DataTable();
            SqlDataReader rdr = null;
            string searchText = txtSearch.Text.Trim();

            //Basic fixing
            //searchText = Regex.Replace(searchText, "[^a-zA-Z0-9]", "");

            string query = "fsp_search_product";

            Trace.Write(String.Format("Query is: {0}", query));

            cmd.CommandType = CommandType.StoredProcedure;
            cmd.CommandText = query;
            cmd.Parameters.Add(new SqlParameter("@productName", searchText));

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                rdr = cmd.ExecuteReader();
                tblEmpInfo.Load(rdr);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            this.gvProducts.DataSource = tblEmpInfo;
            this.gvProducts.DataBind();
            //return tblEmpInfo;
        }


        protected void btnSearchBad_Click(object sender, EventArgs e)
        {
            LoadProductInlineSQL();
        }


        private void LoadProduct()
        {
            DataTable tblEmpInfo = new DataTable();
            SqlDataReader rdr = null;

            string query = string.Format(@"SELECT Name, Description, KeyWords FROM Product");

            Trace.Write(String.Format("Query is: {0}", query));

            cmd.CommandType = CommandType.Text;
            cmd.CommandText = query;

            try
            {
                if (sqlConn.State == ConnectionState.Closed)
                    sqlConn.Open();

                rdr = cmd.ExecuteReader();
                tblEmpInfo.Load(rdr);
            }
            catch (Exception exp)
            {
                throw (exp);
            }
            finally
            {
                if (sqlConn.State == ConnectionState.Open)
                    sqlConn.Close();
            }

            this.gvProducts.DataSource = tblEmpInfo;
            this.gvProducts.DataBind();
            //return tblEmpInfo;
        }

        protected void btnSearchBetter_Click(object sender, EventArgs e)
        {
            LoadParamQuery();
        }

        protected void btnSerachBest_Click(object sender, EventArgs e)
        {
            LoadProductBySP();
        }

    }
}