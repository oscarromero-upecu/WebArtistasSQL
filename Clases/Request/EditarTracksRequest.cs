using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebArtistasSQL.Clases.Request
{
    public class EditarTracksRequest
    {
        public string title { get; set; }
        public int artist { get; set; }
    }
}