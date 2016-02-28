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
    public class UtilsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAllDepartamentos()
        {
            List<Departamentos> DepList = DepartamentosHelper.GetAll();

            bool TheresData = DepList.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, DepList);

        }

        [HttpGet]
        public HttpResponseMessage GetAllDivision()
        {
            List<Division> DivisionList = DivisionHelper.GetAll();

            bool TheresData = DivisionList.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, DivisionList);

        }

        [HttpGet]
        public HttpResponseMessage GetAllGroups()
        {
            List<Division> GroupList = DivisionHelper.GetAll();

            bool TheresData = GroupList.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, GroupList);

        }

        [HttpGet]
        public HttpResponseMessage GetAllIssues()
        {
            List<Issues> IssuesList = IssuesHelper.GetAll();

            bool TheresData = IssuesList.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, IssuesList);

        }

        [HttpGet]
        public HttpResponseMessage GetAllOrganization()
        {
            List<Organizacion> OrgList = OrganizacionHelper.GetAll();

            bool TheresData = OrgList.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, OrgList);

        }

        [HttpGet]
        public HttpResponseMessage GetAllPrioridades()
        {
            List<Prioridad> PrList = PrioridadHelper.GetAll();

            bool TheresData = PrList.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, PrList);

        }

        [HttpGet]
        public HttpResponseMessage GetAllStatus()
        {
            List<Estatus> PrList = EstatusHelper.GetAll();

            bool TheresData = PrList.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, PrList);

        }
        [HttpGet]
        public HttpResponseMessage GetStatusById(int id)
        {
            Estatus est = EstatusHelper.GetEstatusByPrimaryKey(id);
            

            bool TheresData = est != null;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, est);

        }

        [HttpGet]
        public HttpResponseMessage GetUsuario(string userName)
        {
            Usuarios usr = UsuariosHelper.GetUsuario(userName);

            bool TheresData = usr != null;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent); 
            }

            return Request.CreateResponse(HttpStatusCode.OK, usr);

        
        }
        [HttpPost]
        public HttpResponseMessage SaveIssue([FromBody]Issues Model)
        {
            bool SuccessfullSave = IssuesHelper.Save(Model);

            if (!SuccessfullSave)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);

            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpGet]
        public HttpResponseMessage UserFollowed(int UserId, int UserFollowedId)
        {
            Usuarios_Seguidos rel = new Usuarios_Seguidos { UserId = UserId, UserFollowedId = UserFollowedId };
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


    }
}
