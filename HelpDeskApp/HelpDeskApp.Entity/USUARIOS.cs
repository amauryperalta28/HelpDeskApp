//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HelpDeskApp.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class USUARIOS
    {
        public USUARIOS()
        {
            this.USER_FOLLOWED_USER = new HashSet<USER_FOLLOWED_USER>();
            this.TICKETS = new HashSet<TICKETS>();
            this.TICKETS1 = new HashSet<TICKETS1>();
        }
    
        public int id { get; set; }
        public string PrimerNombre { get; set; }
        public string SegundoNombre { get; set; }
        public string PrimerApellido { get; set; }
        public string SegundoApellido { get; set; }
        public string Usuario { get; set; }
        public System.DateTime Fecha_creacion { get; set; }
    
        public virtual ICollection<USER_FOLLOWED_USER> USER_FOLLOWED_USER { get; set; }
        public virtual ICollection<TICKETS> TICKETS { get; set; }
        public virtual ICollection<TICKETS1> TICKETS1 { get; set; }
    }
}
