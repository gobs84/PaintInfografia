using Newtonsoft.Json;
using SuperProject;
using SuperProject.Services;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Web.Http;
using System.Web.Http.Cors;

namespace WAPI.Controllers
{
    public class ProductController : ApiController
    {
        [HttpGet]
        [Route("api/getproducts")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetProducts()
        {
            ProductService ps = new ProductService();
            List<Product> products = ps.Read();
            String productsJSON = JsonConvert.SerializeObject(products, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productsJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/getproducts/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetCategory(string key)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            ProductService productservice = new ProductService();
            List<Product> product = productservice.Read();
            int id = productservice.GetIndex(key);
            if (id != -1)
            {
                Product ct = product[id];
                string categoryJSON = JsonConvert.SerializeObject(ct, Formatting.Indented);
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(categoryJSON, Encoding.UTF8, "application/json");
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }
            return response;

        }

        [HttpPost]
        [Route("api/postproducts")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage PostProducts(Object product)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                String productJSON = product.ToString();

                Product p = JsonConvert.DeserializeObject<Product>(productJSON);
                ProductService ps = new ProductService();
                if (ps.Create(p))
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
        [Route("api/updateproduct/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage UpdateProduct(Object producto, string key)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                Product p = JsonConvert.DeserializeObject<Product>(producto.ToString());
                ProductService ps = new ProductService();
                if (ps.Update(key, p))
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

        [HttpDelete]
        [Route("api/deleteproduct/{id}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage DeleteProduct(string id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                ProductService ps = new ProductService();
                if (ps.Delete(id))
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