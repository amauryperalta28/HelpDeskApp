//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/27 - 19:25:08
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace HelpDeskApp.Common.Models
{
    [DataContract()]
    public partial class Spc_Get_Tickets_User_Followed_Result
    {
        [DataMember()]
        public Int32 Id { get; set; }

        [DataMember()]
        public String Titulo { get; set; }

        [DataMember()]
        public String TicketDescrip { get; set; }

        [DataMember()]
        public String IssueDescrip { get; set; }

        [DataMember()]
        public Int32 userRequestId { get; set; }

        [DataMember()]
        public String UsuarioRequest { get; set; }

        [DataMember()]
        public Int32 userAssignedId { get; set; }

        [DataMember()]
        public String UsuarioAsignado { get; set; }

        [DataMember()]
        public String DepartamentoDescrip { get; set; }

        [DataMember()]
        public String DivisionDescrip { get; set; }

        [DataMember()]
        public Int32 Estatus { get; set; }

        [DataMember()]
        public DateTime Fecha_Solicitud { get; set; }

        [DataMember()]
        public Nullable<DateTime> Fecha_Correcion { get; set; }

        [DataMember()]
        public Nullable<DateTime> Fecha_Modificacion { get; set; }

        [DataMember()]
        public String OrganizacionDescrip { get; set; }

        public Spc_Get_Tickets_User_Followed_Result()
        {
        }

        public Spc_Get_Tickets_User_Followed_Result(Int32 id, String titulo, String ticketDescrip, String issueDescrip, Int32 userRequestId, String usuarioRequest, Int32 userAssignedId, String usuarioAsignado, String departamentoDescrip, String divisionDescrip, Int32 estatus, DateTime fecha_Solicitud, Nullable<DateTime> fecha_Correcion, Nullable<DateTime> fecha_Modificacion, String organizacionDescrip)
        {
			this.Id = id;
			this.Titulo = titulo;
			this.TicketDescrip = ticketDescrip;
			this.IssueDescrip = issueDescrip;
			this.userRequestId = userRequestId;
			this.UsuarioRequest = usuarioRequest;
			this.userAssignedId = userAssignedId;
			this.UsuarioAsignado = usuarioAsignado;
			this.DepartamentoDescrip = departamentoDescrip;
			this.DivisionDescrip = divisionDescrip;
			this.Estatus = estatus;
			this.Fecha_Solicitud = fecha_Solicitud;
			this.Fecha_Correcion = fecha_Correcion;
			this.Fecha_Modificacion = fecha_Modificacion;
			this.OrganizacionDescrip = organizacionDescrip;
        }
    }
}