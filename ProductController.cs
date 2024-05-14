using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using CheckWebApi.Models;
using System.Data;
using CheckWebApi.BILL;
using System.Web.Http;
using HttpPostAttribute = System.Web.Http.HttpPostAttribute;
using CheckWebApi.Decode;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace CheckWebApi.Controllers
{
             
    [System.Web.Http.RoutePrefix("api/Product")]
   
    public class ProductController : ApiController
    {
       JObject ReturnObject = new JObject();
        String con = ConfigurationManager.ConnectionStrings["ProductDBConnectionString"].ConnectionString;
        // GET: Product
        Check_BILL obj_bll = new Check_BILL();

        [System.Web.Http.Route("getall")]
        [System.Web.Http.HttpGet]
        public List<Product> GetProducts()
        {
            List<Product> ProductList = new List<Product>();
            //string fld_status = "1";
            //string fld_message = "FAIL";

            int in_type = 2;
            int fld_id = 1;
            string fld_prod_name = "-1";
            decimal fld_prod_price = -1;
            int fld_prod_qty = -1;
            DataTable DT = obj_bll.sp_get_productsDB(in_type, fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);
            //if (DT.Rows.Count > 0)
            //{
            //    if (!DT.Columns.Contains("FLD_ACTION_STATUS"))
            //    {
            //        fld_status = "0";
            //        fld_message = "success";
            //        ProductList = (from DataRow dr in DT.Rows
            //                       select new Product()
            //                       {
            //                           fld_id = Convert.ToInt32(dr["fld_id"]),
            //                           fld_prod_name = Convert.ToString(dr["fld_prod_name"]),
            //                           fld_prod_price = Convert.ToDecimal(dr["fld_prod_price"]),
            //                           fld_prod_qty = Convert.ToInt32(dr["fld_prod_qty"]),
            //                       }).ToList();
            //    }
            //    else
            //    {
            //        fld_status = DT.Rows[0]["FLD_ACTION_STATUS"].ToString();
            //        fld_message = DT.Rows[0]["FLD_ACTION_STATUS"].ToString();
            //    }
            //}
            //else
            //{
            //    ReturnObject["STATUS"] = "1";
            //    ReturnObject["MESSAGE"] = "NO DATA FOUND";
            //}

            //ReturnObject["STATUS"] = fld_status;
            //ReturnObject["MESSAGE"] = fld_message;
            ////ReturnObject["RESULT"] = JsonConvert.SerializeObject(ProductList);
            //string test = ReturnObject.ToString();

            //return test;
            ProductList = (from DataRow dr in DT.Rows
                           select new Product()
                           {
                               fld_id = Convert.ToInt32(dr["fld_id"]),
                               fld_prod_name = Convert.ToString(dr["fld_prod_name"]),
                               fld_prod_price = Convert.ToDecimal(dr["fld_prod_price"]),
                               fld_prod_qty = Convert.ToInt32(dr["fld_prod_qty"]),
                           }).ToList();

            return ProductList;
        }

        // GET: Product/Details/5
        [System.Web.Http.Route("getbyid")]
        [System.Web.Http.HttpGet]
        public Product GetProductId(int id)
        {
            Product Product = new Product();
            int in_type = 1;
            int fld_id = id;
            string fld_prod_name = "-1";
            decimal fld_prod_price = -1;
            int fld_prod_qty = -1;
            DataTable fld_rtn = obj_bll.sp_get_productsDB(in_type, fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);
            if (fld_rtn.Rows.Count == 1)
            {
                Product.fld_id = Convert.ToInt32(fld_rtn.Rows[0]["fld_id"]);
                Product.fld_prod_name = Convert.ToString(fld_rtn.Rows[0]["fld_prod_name"]);
                Product.fld_prod_price = Convert.ToDecimal(fld_rtn.Rows[0]["fld_prod_price"]);
                Product.fld_prod_qty = Convert.ToInt32(fld_rtn.Rows[0]["fld_prod_qty"]);
            }
            return (Product);
        }


        // POST: Product/Create
        [System.Web.Http.Route("add")]
        [System.Web.Http.HttpPost]
        public Product AddProduct(Product product)
        {
           
            int in_type = 1;
            var test = "";
            int fld_id = product.fld_id;
            string fld_prod_name = product.fld_prod_name;
            //string fld_prod_name = EncDec.EncryptString("product.fld_prod_name", "E&N$C@R#",ref test);

            decimal fld_prod_price = product.fld_prod_price;
            int fld_prod_qty = product.fld_prod_qty;
            DataTable fld_rtn = obj_bll.sp_set_productsDB(in_type, fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);
           return product ;
        }

        // POST: Product/Edit/5
        [System.Web.Http.Route("edit")]
        [HttpPost]
        public Product UpdateProduct(Product product)
        {
            
            int in_type = 2;
            int fld_status = 0;
            int fld_id = product.fld_id;
            string fld_prod_name = product.fld_prod_name;
            decimal fld_prod_price = product.fld_prod_price;
            int fld_prod_qty = product.fld_prod_qty;
            DataTable fld_rtn = obj_bll.sp_set_productsDB(in_type, fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);
            return product;
        }


         //POST: Product/Delete/5
         [System.Web.Http.Route("delete")]
        [HttpPost]
        public String DeleteProduct(Product product)
        {
        
            int in_type = 3;
            int fld_id = product.fld_id;
            string fld_prod_name = "-1";
            decimal fld_prod_price = -1;
            int fld_prod_qty = -1;
            DataTable fld_rtn = obj_bll.sp_set_productsDB(in_type, fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);
           
            return ("success");

        }
    }
}
