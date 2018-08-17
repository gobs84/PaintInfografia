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
    public class CategoryController: ApiController
    {
        [HttpGet]
        [Route("api/getcategory")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetCategory()
        {
            CategoryService categoryservice = new CategoryService();
            List<Category> category = categoryservice.Read();
            string categoryJSON = JsonConvert.SerializeObject(category, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(categoryJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/getcategory/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetCategory(string key)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            CategoryService categoryservice = new CategoryService();
            List<Category> category = categoryservice.Read();
            int id = categoryservice.GetIndex(key);
            if (id != -1)
            {
                Category ct = category[id];
                string categoryJSON = JsonConvert.SerializeObject(ct, Formatting.Indented);
                response = new HttpResponseMessage(HttpStatusCode.OK);
                response.Content = new StringContent(categoryJSON, Encoding.UTF8, "application/json");
            }
            else
            {
                response = new HttpResponseMessage(HttpStatusCode.Unused);
            }
            return response;

        }

        [HttpPost]
        [Route("api/postcategory")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage PostCategory(Object content)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                String categoryJSON = content.ToString();
                Category category = JsonConvert.DeserializeObject<Category>(categoryJSON);
                CategoryService cs = new CategoryService();
                if (cs.Create(category))
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
        [Route("api/updatecategory/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage UpdateCategory(Object content, string key)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                Category category = JsonConvert.DeserializeObject<Category>(content.ToString());
                CategoryService cs = new CategoryService();
                if (cs.Update(key, category))
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
        [Route("api/deletecategory/{id}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage DeleteCategory(string id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                CategoryService cs = new CategoryService();
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
