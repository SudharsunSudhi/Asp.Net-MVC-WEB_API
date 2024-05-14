using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Web;
using System.Net.Http.Formatting;

namespace Mvc.Models
{
    public class Common
    {
        public HttpResponseMessage Getmethod(string url)
        {
            HttpResponseMessage message = new HttpResponseMessage();
            try
            {
                HttpClient client = new HttpClient();
                message = client.GetAsync(url).Result;
            }
            catch (Exception exe)
            {
                var msg = exe.Message;
            }
            return message;
        }
        public HttpResponseMessage Postmethod(string url, Product model)
        {
            HttpResponseMessage message = new HttpResponseMessage();         

            try
            {
                HttpClient client = new HttpClient();
                message = client.PostAsJsonAsync(url, model).Result;
            }
            catch (Exception exe)
            {
                var msg = exe.Message;
            }
            return message;
        }
    }
}