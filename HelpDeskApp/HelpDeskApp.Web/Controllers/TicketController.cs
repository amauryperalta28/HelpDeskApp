using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleRestClient.Http;
using SimpleRestClient.Json;
using HelpDeskApp.Common.Models;
using HelpDeskApp.Web.Models;
using System.Web.Security;

namespace HelpDeskApp.Web.Controllers
{
    public class TicketController : BaseController
    {
        //
        // GET: /Ticket/

        public ActionResult Index()
        {

            var client = new SimpleRest(UrlBase);
            List<Spc_Get_All_Tickets_With_Descrip> list = client.Invoke<List<Spc_Get_All_Tickets_With_Descrip>>("/Tickets/GetAllTicketsDescrip", HttpMethod.GET);

            var usuarios = GetUserDropdown();
            usuarios.Insert(0, new Models.DropDownListModel("-1", "Seleccione un tipo de producto"));
            ViewBag.usuarios = usuarios;

            return View(list);
        }

        public ActionResult IndexAnonimous()
        {
            var client = new SimpleRest(UrlBase);
            List<Spc_Get_All_Tickets_With_Descrip> list = client.Invoke<List<Spc_Get_All_Tickets_With_Descrip>>("/Tickets/GetAllTicketsDescrip", HttpMethod.GET);

            var usuarios = GetUserDropdown();
            usuarios.Insert(0, new Models.DropDownListModel("-1", "Seleccione un tipo de producto"));
            ViewBag.usuarios = usuarios;

            return View(list);
        }


        public PartialViewResult GetTicketByUserName(string UserId)
        {
            SimpleRest client = new SimpleRest(UrlBase);
            var users = client.Invoke<List<Spc_Get_All_Tickets_With_Descrip>>(String.Format("/Tickets/GetTicketByUser?username={0}", UserId), HttpMethod.GET);

            return PartialView("_TicketList", users);
        }

        public ActionResult Create()
        {
            var issues = GetIssuesDropdown();
            issues.Insert(0, new Models.DropDownListModel(-1, "Seleccione un tipo de Incidente")); 
            ViewBag.Issues = issues;

            var depart = GetDepartamentosDropdown();
            depart.Insert(0, new Models.DropDownListModel(-1, "Seleccione un Departamento"));
            ViewBag.Departamentos = depart;

            var div = GetDivisionDropdown();
            div.Insert(0, new Models.DropDownListModel(-1, "Seleccione una división"));
            ViewBag.Division = div;

            var org = GetOrganizationDropdown();
            org.Insert(0, new Models.DropDownListModel(-1, "Seleccione una organización"));
            ViewBag.Organizacion = org;

            var usr = GetUserDropdown();
            usr.Insert(0, new Models.DropDownListModel(-1, "Seleccione un usuario"));
            ViewBag.Usuarios = usr;

            var est = GetStatusDropdown();
            est.Insert(0, new Models.DropDownListModel(-1, "Seleccione un estado"));

            ViewBag.Estatus = est;

            return View(new Tickets());
        }


        [HttpPost]
        public JsonResult Create(TICKETS1_DTO ticket)
        {
            TICKETS1_DTO model = new TICKETS1_DTO(ticket.IssueId, ticket.UserRequestId, ticket.RequestDepartamentId, ticket.DestinationDivisionId, ticket.Estatus, ticket.OrganizacionId, ticket.Titulo, ticket.Descripcion, ticket.UserAssigned);
            var client = new SimpleRest(UrlBase);
            client.Invoke("/Tickets/SaveTicket", HttpMethod.POST, model);

            bool internalServerErrorHappen = client.Response.StatusCode == System.Net.HttpStatusCode.InternalServerError;
           
            if (internalServerErrorHappen)
            {
                return Json(new { message = "Ocurrió un error interno al momento de guardar, por favor intente de nuevo.", success = false, title = "Creación de Solicitud" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { message = "Solicitud creada con éxito.", success = true, title = "Creación de Solicitud" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult Edit(int id)
        {

            var ticket = GetTicketsById(id);

            var issues = GetIssuesDropdown();
            issues.Insert(0, new Models.DropDownListModel(-1, "Seleccione un tipo de Incidente"));
            ViewBag.Issues = issues;

            var depart = GetDepartamentosDropdown();
            depart.Insert(0, new Models.DropDownListModel(-1, "Seleccione un Departamento"));
            ViewBag.Departamentos = depart;

            var div = GetDivisionDropdown();
            div.Insert(0, new Models.DropDownListModel(-1, "Seleccione una división"));
            ViewBag.Division = div;

            var org = GetOrganizationDropdown();
            org.Insert(0, new Models.DropDownListModel(-1, "Seleccione una organización"));
            ViewBag.Organizacion = org;

            var usr = GetUserDropdown();
            usr.Insert(0, new Models.DropDownListModel(-1, "Seleccione un usuario"));
            ViewBag.Usuarios = usr;
            var status = GetStatusDropdown();
            status.Insert(0, new Models.DropDownListModel(-1,"Seleccione un Estatus"));
            ViewBag.Estatus = status;

            return View(ticket);
        }

        private TICKETS1_DTO GetTicketsById(int id)
        {
            TICKETS1_DTO ticketAEditar;
            var client = new SimpleRest(UrlBase);
            ticketAEditar = client.Invoke<TICKETS1_DTO>(string.Format("/Tickets/GetTicketById?Id={0}", id), HttpMethod.GET);

            return ticketAEditar;
        
        
        }
        //
        // POST: /Ticket/Edit/5

        [HttpPost]
        public JsonResult Edit(Tickets Model)
        {
            var client = new SimpleRest(UrlBase);
            client.Invoke("/Tickets/UpdateTicket", HttpMethod.PUT, Model);
            bool updateWasSuccesfull = client.Response.StatusCode == System.Net.HttpStatusCode.Created;
            

            if (updateWasSuccesfull)
            {
                return Json(new { message = "Solicitud actualizada con éxito.", success = true, title = "Actualización de Solicitud", edit = true }, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return Json(new { message = "Ocurrió un error interno al momento de actualizar. Por favor intente de nuevo", success = false, title = "Actualización de Solicitud" }, JsonRequestBehavior.AllowGet);
            }
        }

        [HttpGet]
        public ActionResult CloseTicket(int id)
        {

            var ticket = GetTicketsById(id);

            var issues = GetIssuesDropdown();
            issues.Insert(0, new Models.DropDownListModel(-1, "Seleccione un tipo de Incidente"));
            ViewBag.Issues = issues;

            var depart = GetDepartamentosDropdown();
            depart.Insert(0, new Models.DropDownListModel(-1, "Seleccione un Departamento"));
            ViewBag.Departamentos = depart;

            var div = GetDivisionDropdown();
            div.Insert(0, new Models.DropDownListModel(-1, "Seleccione una división"));
            ViewBag.Division = div;

            var org = GetOrganizationDropdown();
            org.Insert(0, new Models.DropDownListModel(-1, "Seleccione una organización"));
            ViewBag.Organizacion = org;

            var usr = GetUserDropdown();
            usr.Insert(0, new Models.DropDownListModel(-1, "Seleccione un usuario"));
            ViewBag.Usuarios = usr;
            //var status = GetStatusDropdown();
           // status.Insert(0, new Models.DropDownListModel(-1, "Seleccione un Estatus"));
            

            var est = new List<DropDownListModel>();
            est.Insert(0, new Models.DropDownListModel(ticket.Estatus, GetStatusById(ticket.Estatus)));
            ViewBag.Estatus = est;

            return View(ticket);
        }

        private string GetStatusById(int id)
        {
            Estatus est;
            var client = new SimpleRest(UrlBase);
            est = client.Invoke<Estatus>(string.Format("/Utils/GetStatusById?Id={0}", id), HttpMethod.GET);
            
            return est != null? est.Descripcion: "";


        }

        [HttpPost]
        public JsonResult CloseTicket(Tickets Model)
        {
            var client = new SimpleRest(UrlBase);
            client.Invoke("/Tickets/CloseTicket", HttpMethod.PUT, Model);
            bool updateWasSuccesfull = client.Response.StatusCode == System.Net.HttpStatusCode.Created;

            
            if (updateWasSuccesfull)
            {
                return Json(new { message = "La Solicitud fue cerrada con éxito.", success = true, title = "Cierre de Solicitud", edit = true }, JsonRequestBehavior.AllowGet);
            }

            else
            {
                return Json(new { message = "Ocurrió un error interno al momento de cerrar la solicitud. Por favor intente de nuevo", success = false, title = "Cierre de Solicitud" }, JsonRequestBehavior.AllowGet);
            }
        }

        //
        // GET: /Ticket/Delete/5

      
    }
}
