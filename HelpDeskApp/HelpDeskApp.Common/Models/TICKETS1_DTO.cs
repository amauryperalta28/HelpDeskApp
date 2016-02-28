//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/27 - 23:42:39
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
    public partial class TICKETS1_DTO
    {
        [DataMember()]
        public Int32 Id { get; set; }

        [DataMember()]
        public String Titulo { get; set; }

        [DataMember()]
        public String Descripcion { get; set; }

        [DataMember()]
        public Int32 IssueId { get; set; }

        [DataMember()]
        public Int32 UserRequestId { get; set; }

        [DataMember()]
        public Int32 RequestDepartamentId { get; set; }

        [DataMember()]
        public Int32 DestinationDivisionId { get; set; }

        [DataMember()]
        public Int32 Estatus { get; set; }

        [DataMember()]
        public Int32 OrganizacionId { get; set; }

        [DataMember()]
        public Int32 UserAssigned { get; set; }

        [DataMember()]
        public DateTime Fecha_Solicitud { get; set; }

        [DataMember()]
        public Nullable<DateTime> Fecha_Correcion { get; set; }

        [DataMember()]
        public Nullable<DateTime> Fecha_Modificacion { get; set; }

        [DataMember()]
        public DateTime Fecha_Vencimiento { get; set; }

        public TICKETS1_DTO()
        {
        }

        public TICKETS1_DTO(Int32 issueId, Int32 userRequestId, Int32 requestDepartamentId, Int32 destinationDivisionId, Int32 estatus, Int32 organizacionId, String titulo, String descripcion, Int32 userAssigned)
        {

            this.IssueId = issueId;
            this.UserRequestId = userRequestId;
            this.RequestDepartamentId = requestDepartamentId;
            this.DestinationDivisionId = destinationDivisionId;
            this.Estatus = estatus;
            this.Fecha_Solicitud = DateTime.Now;
            this.Fecha_Vencimiento = DateTime.Now.AddDays(3);
            this.OrganizacionId = organizacionId;
            this.Titulo = titulo;
            this.Descripcion = descripcion;
            this.UserAssigned = userAssigned;
        }
    }
}
