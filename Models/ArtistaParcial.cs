using WebArtistasSQL.Clases.Request;

namespace WebArtistasSQL.Models
{
    public partial class artists
    {
        //public artists() { }
        public artists (int id, NuevaArtistaRequest nuevoArtista)
        {
            this.id = id;
            Nombre = nuevoArtista.Nombre;

        }
    }
}