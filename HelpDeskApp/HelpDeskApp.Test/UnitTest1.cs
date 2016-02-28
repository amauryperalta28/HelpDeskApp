using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using HelpDeskApp.Library.Helpers;
using HelpDeskApp.Common.Models;
using SimpleRestClient.Http;
using SimpleRestClient.Json;

namespace HelpDeskApp.Test
{
    [TestClass]
    public class UnitTest1
    {
       #region library
        [TestMethod]
        public void updateTicketLibrary()
        {
            Tickets ticketToUpdate = TicketsHelper.GetTicketByPrimaryKey(2);
            ticketToUpdate.Descripcion = "Problemas de Super red";

            bool actual = TicketsHelper.updateTicket(ticketToUpdate);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void CloseTicket()
        {
            Tickets ticketToUpdate = TicketsHelper.GetTicketByPrimaryKey(2);
            

            bool actual = TicketsHelper.CloseTicket(ticketToUpdate);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void FollowUser()
        {

            Usuarios_Seguidos rel = new Usuarios_Seguidos { UserId = 1, UserFollowedId = 2 };


            bool actual = Usuarios_SeguidosHelper.Save(rel);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UnFollowUser()
        {

            Usuarios_Seguidos rel = new Usuarios_Seguidos { UserId = 1, UserFollowedId = 2 };


            bool actual = UsuariosHelper.UnFollowUser(rel);
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void UserIsFollowed()
        {

            Usuarios_Seguidos rel = new Usuarios_Seguidos { UserId = 1, UserFollowedId = 2 };


            bool actual = Usuarios_SeguidosHelper.UserIsFollowed(rel);
            bool expected = false;

            Assert.AreEqual(expected, actual);
        }
       #endregion

        [TestMethod]
        public void updateTicketUsingService()
        {
            Tickets ticketToUpdate = TicketsHelper.GetTicketByPrimaryKey(2);
            ticketToUpdate.Descripcion = "Problemas de Super red2";

            var client = new SimpleRest("http://localhost:14099/api/");
            client.Invoke("/Tickets/UpdateTicket", HttpMethod.PUT, ticketToUpdate);

            bool actual = client.Response.StatusCode == System.Net.HttpStatusCode.Created;
            bool expected = true;

            Assert.AreEqual(expected, actual);
        }

        


    }
}
