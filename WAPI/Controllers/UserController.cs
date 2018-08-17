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
    public class UserController : ApiController
    {
        [HttpGet]
        [Route("api/getusers")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetUsers()
        {
            UserService userservice= new UserService();
            List<User> users = userservice.Read();
            string productsJSON = JsonConvert.SerializeObject(users, Formatting.Indented);
            var response = Request.CreateResponse(HttpStatusCode.OK);
            response.Content = new StringContent(productsJSON, Encoding.UTF8, "application/json");
            return response;
        }

        [HttpGet]
        [Route("api/getusers/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage GetUsers(string key)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            UserService userservice = new UserService();
            List<User> user = userservice.Read();
            int id = userservice.GetIndex(key);
            if (id != -1)
            {
                User u = user[id];
                string cartJSON = JsonConvert.SerializeObject(u, Formatting.Indented);
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
        [Route("api/postuser")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage PosUser(Object user)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                String userJSON = user.ToString();
                User u = JsonConvert.DeserializeObject<User>(userJSON);
                UserService us = new UserService();
                if (us.Create(u))
                {
                    response = new HttpResponseMessage(HttpStatusCode.OK);
                }
                else
                {
                    response = new HttpResponseMessage(HttpStatusCode.ExpectationFailed);
                }
            }catch
            {
                response = new HttpResponseMessage(HttpStatusCode.Unused);
            }
            return response;
        }

        [HttpPut]
        [Route("api/updateuser/{key}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage UpdateInfo(Object user, string key)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                User u = JsonConvert.DeserializeObject<User>(user.ToString());
                UserService us = new UserService();
                if (us.Update(key,u))
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
        [Route("api/deleteuser/{id}")]
        [EnableCors(origins: "http://localhost:4200", headers: "*", methods: "*")]
        public HttpResponseMessage DeleteInfo(string id)
        {
            HttpResponseMessage response = new HttpResponseMessage(HttpStatusCode.Unused);
            try
            {
                UserService us = new UserService();
                if (us.Delete(id))
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