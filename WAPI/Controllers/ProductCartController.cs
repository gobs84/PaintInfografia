using Newtonsoft.Json;
using SuperProject;
using SuperProject.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WAPI.Controllers
{
    public class ProductCartController: ApiController
    {
        [HttpGet]
        [Route("api/getproductcart")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetProductCart()
        {
            ProductCartService productcartservice = new ProductCartService();
            List<ProductCart> productcart = productcartservice.Read();
            string productcartJSON = JsonConvert.SerializeObject(productcart, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productcartJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/getproductcart/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetProductCart(string key)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            ProductCartService productcartservice = new ProductCartService();
            List<ProductCart> productcart = productcartservice.Read();
            int id = productcartservice.GetProductCartIndex(key);
            if (id != -1)
            {
                ProductCart pc = productcart[id];
                string productcartJSON = JsonConvert.SerializeObject(pc, Formatting.Indented);
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(productcartJSON, Encoding.UTF8, "application/json");
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }
            return response;

        }

        [HttpPost]
        [Route("api/postproductart")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage PostCart(Object content)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                String productcartJSON = content.ToString();
                ProductCart productcart = JsonConvert.DeserializeObject<ProductCart>(productcartJSON);
                ProductCartService pcs = new ProductCartService();
                if (pcs.Create(productcart))
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                }
            }
            catch
            {
                response = new HttpResponseMessage(HttpStatusCode.Unused);
            }
            return response;
        }

        [HttpPut]
        [Route("api/updateproductcart/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage UpdateProductCart(Object content, string key)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                ProductCart productcart = JsonConvert.DeserializeObject<ProductCart>(content.ToString());
                ProductCartService pcs = new ProductCartService();
                if (pcs.Update(key, productcart))
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                }
            }
            catch
            {
                response = Request.CreateResponse(HttpStatusCode.Unused);
            }
            return response;
        }

        [HttpDelete]
        [Route("api/deleteproductcart/{id}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage DeleteProductCart(string id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                ProductCartService pcs = new ProductCartService();
                if (pcs.Delete(id))
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                }
            }
            catch
            {
                response = new HttpResponseMessage(HttpStatusCode.Unused);
            }
            return response;
        }
    }
}