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
    
    public partial class tracks
    {
        public int tra_id { get; set; }
        public string title { get; set; }
        public Nullable<int> artist { get; set; }
    
        public virtual artists artists { get; set; }
    }
}