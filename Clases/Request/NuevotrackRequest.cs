using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebArtistasSQL.Clases.Request
{
    public class NuevotrackRequest
    {
        public string title { get; set; }
        public int artist { get; set; }
        public string Nombre_artist { get; set; }
    }
}