//------------------------------------------------------------------------------
// <auto-generated>
//    Este código se generó a partir de una plantilla.
//
//    Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//    Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebArtistasSQL.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class artists
    {
        public artists()
        {
            this.tracks = new HashSet<tracks>();
        }
    
        public int id { get; set; }
        public string Nombre { get; set; }
    
        public virtual ICollection<tracks> tracks { get; set; }
    }
}