//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2016/02/20 - 17:52:50
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
    public partial class Division
    {
        [DataMember()]
        public Int32 Id { get; set; }

        [DataMember()]
        public String Descripcion { get; set; }

        [DataMember()]
        public Int32 departamentoId { get; set; }

        [DataMember()]
        public DateTime Fecha_Creacion { get; set; }

        [DataMember()]
        public Int32 DEPARTAMENTOS_Id { get; set; }

        [DataMember()]
        public List<Int32> TICKETS_Id { get; set; }

        public Division()
        {
        }

        public Division(Int32 id, String descripcion, Int32 departamentoId, DateTime fecha_Creacion, Int32 dEPARTAMENTOS_Id, List<Int32> tICKETS_Id)
        {
			this.Id = id;
			this.Descripcion = descripcion;
			this.departamentoId = departamentoId;
			this.Fecha_Creacion = fecha_Creacion;
			this.DEPARTAMENTOS_Id = dEPARTAMENTOS_Id;
			this.TICKETS_Id = tICKETS_Id;
        }
    }
}
