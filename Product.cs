using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CheckWebApi.Models
{
    public class Product
    {
        public int fld_id { get; set; }
        public String fld_prod_name { get; set; }
        public decimal fld_prod_price { get; set; }
        public int fld_prod_qty { get; set; }

        public int fld_status { get; set; }
    }
}