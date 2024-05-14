using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using CheckWebApi.BILL;
using CheckWebApi.Adapter.DataTableAdapters;

namespace CheckWebApi.BILL
{
    public class Check_BILL
    {
        public DataTable sp_get_productsDB(int in_type, int fld_id, string fld_prod_name, decimal fld_prod_price, int fld_prod_qty)
        {
            try
            {
                return new sp_get_productsTableAdapter().GetData(in_type, fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);
            }
            catch (Exception Ex)
            {
                return new DataTable(Ex.Message);
            }
        }

        public DataTable sp_set_productsDB(int in_type, int fld_id, string fld_prod_name, decimal fld_prod_price, int fld_prod_qty)
        {
            try
            {
                return new sp_set_productsTableAdapter().GetData(in_type, fld_id, fld_prod_name, fld_prod_price, fld_prod_qty);
            }
            catch (Exception Ex)
            {
                return new DataTable(Ex.Message);
            }
        }
    }
}