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
    public partial class Grupos
    {
        [DataMember()]
        public Int32 Id { get; set; }

        [DataMember()]
        public String Descripcion { get; set; }

        [DataMember()]
        public DateTime Fecha_Creacion { get; set; }

        public Grupos()
        {
        }

        public Grupos(Int32 id, String descripcion, DateTime fecha_Creacion)
        {
			this.Id = id;
			this.Descripcion = descripcion;
			this.Fecha_Creacion = fecha_Creacion;
        }
    }
}
