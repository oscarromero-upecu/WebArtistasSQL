using WebArtistasSQL.Clases.Request;

namespace WebArtistasSQL.Models
{
    public partial class tracks
    {
        //public artists() { }
        public tracks (int id,  NuevotrackRequest nuevotrack , int artista)
        {
            this.tra_id = id;
            title = nuevotrack.title;
            this.artist = artist;


        }
    }
}