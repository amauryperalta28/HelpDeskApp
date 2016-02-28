using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using HelpDeskApp.Web.Models;
using System.Web.Mvc;
using HelpDeskApp.Common.Models;
using System.Configuration;
using SimpleRestClient.Http;
using SimpleRestClient.Json;


namespace HelpDeskApp.Web.Controllers
{
    public class BaseController : Controller
    {
        //
        // GET: /Base/
        protected static string UrlBase
        {
            get
            {
                return ConfigurationManager.AppSettings["urlBase"].ToString();
            }
        }

        protected static List<DropDownListModel> GetIssuesDropdown()
        {
            var dropDown = new List<DropDownListModel>();

            var client = new SimpleRest(UrlBase);

            var issues = client.Invoke<List<Issues>>("/Utils/GetAllIssues", SimpleRestClient.Http.HttpMethod.GET);
            bool dataLoadedSuccesfully = (int)client.Response.StatusCode == 200;

            if (dataLoadedSuccesfully)
            {
                dropDown = issues.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
            }

            return dropDown;
        }

        protected static List<DropDownListModel> GetPrioridadDropdown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);

            var issues = client.Invoke<List<Prioridad>>("/Utils/GetAllPrioridades", SimpleRestClient.Http.HttpMethod.GET);
            bool dataLoadedSuccesfully = (int)client.Response.StatusCode == 200;

            if (dataLoadedSuccesfully)
            {
                dropDown = issues.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
            }

            return dropDown;
        }

        protected static List<DropDownListModel> GetDivisionDropdown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);

            var issues = client.Invoke<List<Division>>("/Utils/GetAllDivision", SimpleRestClient.Http.HttpMethod.GET);
            bool dataLoadedSuccesfully = (int)client.Response.StatusCode == 200;

            if (dataLoadedSuccesfully)
            {
                dropDown = issues.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
            }

            return dropDown;
        }

        protected static List<DropDownListModel> GetDepartamentosDropdown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);

            var issues = client.Invoke<List<Departamentos>>("/Utils/GetAllDepartamentos", SimpleRestClient.Http.HttpMethod.GET);
            bool dataLoadedSuccesfully = (int)client.Response.StatusCode == 200;

            if (dataLoadedSuccesfully)
            {
                dropDown = issues.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
            }


            return dropDown;
        }

        protected static List<DropDownListModel> GetOrganizationDropdown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);

            var issues = client.Invoke<List<Organizacion>>("/Utils/GetAllOrganization", SimpleRestClient.Http.HttpMethod.GET);
            bool dataLoadedSuccesfully = (int)client.Response.StatusCode == 200;

            if (dataLoadedSuccesfully)
            {
                dropDown = issues.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
            }

            return dropDown;
        }

        protected static List<DropDownListModel> GetUserDropdown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);

            var issues = client.Invoke<List<Usuarios>>("/Usuarios/GetAllUser", SimpleRestClient.Http.HttpMethod.GET);
            bool dataLoadedSuccesfully = (int)client.Response.StatusCode == 200;

            if (dataLoadedSuccesfully)
            {
                dropDown = issues.Select(x => new DropDownListModel(x.id, x.Usuario)).ToList();
            }

            return dropDown;
        }

        protected static List<DropDownListModel> GetStatusDropdown()
        {
            var dropDown = new List<DropDownListModel>();
            var client = new SimpleRest(UrlBase);

            var issues = client.Invoke<List<Estatus>>("/Utils/GetAllStatus", SimpleRestClient.Http.HttpMethod.GET);
            bool dataLoadedSuccesfully = (int)client.Response.StatusCode == 200;

            if (dataLoadedSuccesfully)
            {
                dropDown = issues.Select(x => new DropDownListModel(x.Id, x.Descripcion)).ToList();
            }

            return dropDown;
        }


    }
}
