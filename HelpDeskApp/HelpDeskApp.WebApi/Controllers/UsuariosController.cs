using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using HelpDeskApp.Common.Models;
using HelpDeskApp.Library.Helpers;

namespace HelpDeskApp.WebApi.Controllers
{
    public class UsuariosController : ApiController
    {
     
        public HttpResponseMessage GetAllUser()
        {
            List<Usuarios> userList = UsuariosHelper.GetAll();
            
            bool TheresData = userList.Count > 0;

            if (!TheresData)
	        {
                throw new HttpResponseException(HttpStatusCode.NoContent);
	        }

            return Request.CreateResponse(HttpStatusCode.OK, userList);
           
        }

        [HttpGet]
        public HttpResponseMessage GetUserByUserName(string username)
        {
            Usuarios user = UsuariosHelper.GetUsuario(username);

            bool TheresData = user != null;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);

        }

        [HttpGet]
        public HttpResponseMessage GetUserById(int id)
        {
            Usuarios user = UsuariosHelper.GetUsuarioByPrimaryKey(id);
            bool TheresData = user != null;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, user);
        
        }

        [HttpPost]
         public HttpResponseMessage SaveUser([FromBody]Usuarios Model)
        {
             bool SuccessfullSave = UsuariosHelper.Save(Model);

             if (!SuccessfullSave)
	         {
                 throw new HttpResponseException(HttpStatusCode.InternalServerError);
		 
	         }
             return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPost]
         public HttpResponseMessage AddUserToGroup([FromBody]User_Groups Model)
         {
             bool SuccessfullSave = User_GroupsHelper.Save(Model);

             if (!SuccessfullSave)
             {
                 throw new HttpResponseException(HttpStatusCode.InternalServerError);

             }
             return Request.CreateResponse(HttpStatusCode.Created);
         }

        [HttpPost]
        public HttpResponseMessage FollowUser([FromBody]Usuarios_Seguidos rel)
        {
            if (Usuarios_SeguidosHelper.UserIsFollowed(rel))
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }
            
            bool result =  UsuariosHelper.FollowUser(rel);

            if (!result)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);
            }

            return Request.CreateResponse(HttpStatusCode.Created);

        }

        [HttpPost]
        public HttpResponseMessage UnFollowUser([FromBody]Usuarios_Seguidos rel)
        {
            bool result = true; // UsuariosHelper.UnFollowUser(rel);

            if (!result)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }

            return Request.CreateResponse(HttpStatusCode.Created);

        }

        [HttpGet]
        public HttpResponseMessage UserFollowed([FromBody]Usuarios_Seguidos rel)
        {
            bool modelIsNull = rel == null;

            if (modelIsNull)
            {
                 throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

            bool result = Usuarios_SeguidosHelper.UserIsFollowed(rel);

            if (result)
            {
                throw new HttpResponseException(HttpStatusCode.Conflict);
            }

            return Request.CreateResponse(HttpStatusCode.Accepted);

        }
        

        // POST api/usuarios
        public void Post([FromBody]string value)
        {
        }

        // PUT api/usuarios/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/usuarios/5
        public void Delete(int id)
        {
        }

        
        
    }
}
