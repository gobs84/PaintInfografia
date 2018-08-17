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
    public class CartController: ApiController
    {
        [HttpGet]
        [Route("api/getcart")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetCart()
        {
            CartService cartservice = new CartService();
            List<Cart> cart = cartservice.Read();
            string cartJSON = JsonConvert.SerializeObject(cart, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(cartJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/getcart/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetCart(string key)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            CartService cartservice = new CartService();
            List<Cart> cart = cartservice.Read();
            int id = cartservice.GetIndex(key);
            if (id != -1)
            {
                Cart ca = cart[id];
                string cartJSON = JsonConvert.SerializeObject(ca, Formatting.Indented);
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(cartJSON, Encoding.UTF8, "application/json");
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }
            return response;

        }

        [HttpPost]
        [Route("api/postcart")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage PostCart(Object content)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                String cartJSON = content.ToString();
                Cart cart = JsonConvert.DeserializeObject<Cart>(cartJSON);
                CartService cs = new CartService();
                if (cs.Create(cart))
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
        [Route("api/updatecart/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage UpdateCart(Object content, string key)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                Cart cart = JsonConvert.DeserializeObject<Cart>(content.ToString());
                CartService cs = new CartService();
                if (cs.Update(key, cart))
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
        [Route("api/deletecart/{id}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage DeleteCart(string id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                CartService cs = new CartService();
                if (cs.Delete(id))
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