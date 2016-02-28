using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using SimpleRestClient.Http;
using SimpleRestClient.Json;
using HelpDeskApp.Common.Models;

namespace HelpDeskApp.Web.Controllers
{
    public class UserController : BaseController
    {
        //
        // GET: /User/

        public ActionResult Index(int id)
        {
            string userLogged = User.Identity.Name;
            var client = new SimpleRest(UrlBase);
            Usuarios usuario = client.Invoke<Usuarios>(string.Format("/Usuarios/GetUserById?id={0}", id), HttpMethod.GET);
            

            Usuarios_Seguidos rel = new Usuarios_Seguidos{ UserId = usuario.id, UserFollowedId = id};
            client.Invoke(string.Format("/Utils/UserFollowed?UserId={0}&UserFollowedId={1}",rel.UserId,rel.UserFollowedId), HttpMethod.GET,2);
            
            bool BlockFollowButton = client.Response.StatusCode == System.Net.HttpStatusCode.Conflict;

            ViewBag.BlockButton = BlockFollowButton;

            return View(usuario);
        }

        public JsonResult Follow(Usuarios userToFollow)
        {
            string userLogged = User.Identity.Name;
            var client = new SimpleRest(UrlBase);
            Usuarios userLoggedObj = client.Invoke<Usuarios>(string.Format("/Utils/GetUsuario?username={0}", userLogged), HttpMethod.GET);

            Usuarios_Seguidos rel = new Usuarios_Seguidos { UserId = userLoggedObj.id, UserFollowedId = userToFollow.id };
            client.Invoke("/Usuarios/FollowUser", HttpMethod.POST, rel);

            bool followActionCorrect = client.Response.StatusCode == System.Net.HttpStatusCode.Created;

            if (!followActionCorrect)
            {
                return Json(new { message = "Ocurrió un error interno al momento de seguir el Usuario, por favor intente de nuevo.", success = false, title = "Solicitud de Seguir Usuario" }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new { message = "Usuario agregado a la lista de seguidos con éxito.", success = true, title = "Solicitud de Seguir Usuario" }, JsonRequestBehavior.AllowGet);
            }

        }

        //
        // GET: /User/Details/5

        public ActionResult Details(int id)
        {
            return View();
        }

        //
        // GET: /User/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /User/Create

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
        // GET: /User/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /User/Edit/5

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
        // GET: /User/Delete/5

        public ActionResult Delete(int id)
        {
            return View();
        }

        //
        // POST: /User/Delete/5

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
