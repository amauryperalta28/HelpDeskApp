using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HelpDeskApp.Common.Models;
using SimpleRestClient.Http;
using SimpleRestClient.Json;

namespace HelpDeskApp.Web.Controllers
{
    public class UserFollowedController : BaseController
    {
        //
        // GET: /UserFollowed/

        public ActionResult Index()
        {
            string userLogged = User.Identity.Name;
            var client = new SimpleRest(UrlBase);
            Usuarios usuario = client.Invoke<Usuarios>(string.Format("/Usuarios/GetUserByUserName?username={0}", userLogged), HttpMethod.GET);

            //var client = new SimpleRest(UrlBase);
            List<Spc_Get_Tickets_User_Followed_Result> list = client.Invoke<List<Spc_Get_Tickets_User_Followed_Result>>(string.Format("/Tickets/GetAllTicketsUserFollowed?UsrId={0}", usuario.id), HttpMethod.GET);

            //var usuarios = GetUserDropdown();
            //usuarios.Insert(0, new Models.DropDownListModel("-1", "Seleccione un tipo de producto"));
            //ViewBag.usuarios = usuarios;

            return View(list);
            
        }

        public PartialViewResult GetTicketFromUsersFollowed(int UserId)
        {
            SimpleRest client = new SimpleRest(UrlBase);
            var tickets = client.Invoke<List<Spc_Get_All_Tickets_With_Descrip>>(String.Format("/Tickets/GetAllTicketsUserFollowed?UsrId={0}", UserId), HttpMethod.GET);

            return PartialView("_TicketList", tickets);
        }

        //
        // GET: /UserFollowed/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /UserFollowed/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /UserFollowed/Create

        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UserFollowed/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /UserFollowed/Edit/5

        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /UserFollowed/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /UserFollowed/Delete/5

        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
