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
    public class ShippingAddressController: ApiController
    {
        [HttpGet]
        [Route("api/getshippingaddress")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetShippingAddress()
        {
            ShippingAddressService shippingaddressservice = new ShippingAddressService();
            List<ShippingAddress> shippingaddress = shippingaddressservice.Read();
            string shippingaddressJSON = JsonConvert.SerializeObject(shippingaddress, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(shippingaddressJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/getshippingaddress/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetShippingAddress(string key)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            ShippingAddressService shippingaddressservice = new ShippingAddressService();
            List<ShippingAddress> shippingAddress = shippingaddressservice.Read();
            int id = shippingaddressservice.GetIndex(key);
            if (id != -1)
            {
                ShippingAddress sa = shippingAddress[id];
                string shippingaddressJSON = JsonConvert.SerializeObject(sa, Formatting.Indented);
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(shippingaddressJSON, Encoding.UTF8, "application/json");
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                response.Content = new StringContent("Error", Encoding.UTF8, "application/json");
            }
            return response;

        }

        [HttpPost]
        [Route("api/postshippingaddress")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage PostShippingAddress(Object content)
        {
            HttpResponseMessage ms = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                String shippingaddressJSON = content.ToString();
                ShippingAddress shippingaddress = JsonConvert.DeserializeObject<ShippingAddress>(shippingaddressJSON);
                ShippingAddressService sas = new ShippingAddressService();
                if (sas.Create(shippingaddress))
                {
                    ms = new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    ms = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                }
            }
            catch
            {
                ms = new HttpResponseMessage(HttpStatusCode.Unused);
            }
            return ms;
        }

        [HttpPut]
        [Route("api/updateshippingaddress/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage UpdateShippingAddress(Object content, string key)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                ShippingAddress shippingaddress = JsonConvert.DeserializeObject<ShippingAddress>(content.ToString());
                ShippingAddressService sas = new ShippingAddressService();
                if (sas.Update(key, shippingaddress))
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
                response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }
            return response;
        }

        [HttpDelete]
        [Route("api/deleteshippingaddress/{id}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage DeleteShippingAddress(string id)
        {
            var response = Request.CreateResponse(HttpStatusCode.Unused);
            try
            {
                ShippingAddressService sas = new ShippingAddressService();
                if (sas.Delete(id))
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
                response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
            }
            return response;
        }
    }
}