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
    public class TicketsController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage GetAllTickets()
        {
            List<TICKETS1_DTO> ticketsList = TICKETS1Helper.GetAll();

            bool TheresData = ticketsList.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ticketsList);

        }

        [HttpGet]
        public HttpResponseMessage GetAllTicketsDescrip()
        {
            List<Spc_Get_All_Tickets_With_Descrip> ticketsList = TICKETS1Helper.GetAllWithDescrip();

            bool TheresData = ticketsList.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ticketsList);

        }

        [HttpGet]
        public HttpResponseMessage GetAllTicketsUserFollowed(int UsrId)
        {
            List<Spc_Get_Tickets_User_Followed_Result> ticketsList = TICKETS1Helper.GetTicketsFromUsersFollowed(UsrId);

            bool TheresData = ticketsList.Count > 0;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ticketsList);

        }

        [HttpGet]
        public HttpResponseMessage GetTicketByUser(string username)
        {
            List<Spc_Get_Ticket_By_Usr_Request> tickets = TICKETS1Helper.GetTicketByUserRequest(username);

            bool TheresData = tickets != null;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, tickets);

        }


        [HttpGet]
        public HttpResponseMessage GetTicketById(int id)
        {
            TICKETS1_DTO ticket = TICKETS1Helper.GetTicketByPrimaryKey(id);

            bool TheresData = ticket != null;

            if (!TheresData)
            {
                throw new HttpResponseException(HttpStatusCode.NoContent);
            }

            return Request.CreateResponse(HttpStatusCode.OK, ticket);

        }

        [HttpPut]
        public HttpResponseMessage UpdateTicket([FromBody] TICKETS1_DTO Model)
        {
            bool sucessfullUpdate = TICKETS1Helper.updateTicket(Model);

            if (!sucessfullUpdate)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPut]
        public HttpResponseMessage CloseTicket([FromBody] TICKETS1_DTO Model)
        {
            bool sucessfullClose = TICKETS1Helper.CloseTicket(Model);

            if (!sucessfullClose)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPost]
        public HttpResponseMessage SaveTicket([FromBody]TICKETS1_DTO Model)
        {
            bool SuccessfullSave = TICKETS1Helper.Save(Model);

            if (!SuccessfullSave)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);

            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }

        [HttpPost]
        public HttpResponseMessage SaveAnswerQuestionClasificacion([FromBody]Tickets_Respuesta Model)
        {
            bool SuccessfullSave = Tickets_RespuestaHelper.Save(Model);

            if (!SuccessfullSave)
            {
                throw new HttpResponseException(HttpStatusCode.InternalServerError);

            }
            return Request.CreateResponse(HttpStatusCode.Created);
        }



        // PUT api/tickets/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/tickets/5
        public void Delete(int id)
        {
        }
    }
}
