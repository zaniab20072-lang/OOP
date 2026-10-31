using Event_Management_System.cs.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs.Artist
{
    internal class ArtistService
    {
        // Linking With EventService And Artist repository

        private readonly ArtistRepository _repository;
        private readonly EventService _eventService;

        // Constructor for them

        public ArtistService()
        {
            _repository = new ArtistRepository();
            _eventService = new EventService();
        }

        // function To get All the Artist from Files

        public List<ArtistModel> GetAllArtists()
        {
            return _repository.LoadArtist();
        }

        //Function To Search An Artist By Name

        public ArtistModel SearchArtist(string artistName)
        {
            List<ArtistModel> artists = _repository.LoadArtist();
            for (int i = 0; i < artists.Count; i++)
            {
                if (artists[i].ArtistName == artistName)
                {
                    return artists[i];
                }
            }
            return null;
        }
        
        // Function To Add An Artist 

        public void AddArtist(ArtistModel NewArtist)
        {
            EventModel ev = _eventService.SearchEvent(NewArtist.ArtistEvent);
            if (ev == null)
            {
                Console.WriteLine(" Event Not Found In Which You Wanna Add An Artist ");
            }
            List<ArtistModel> artists = _repository.LoadArtist();
            artists.Add(NewArtist);
            _repository.SaveArtists(artists);
        }

        // Function TO Delete An Artist 

        public bool DeleteArtist(string artistName)
        {
            List<ArtistModel> artists = _repository.LoadArtist();
            bool found = false;
            for (int i = 0; i < artists.Count; i++)
            {
                if (artists[i].ArtistName == artistName)
                {
                    artists.RemoveAt(i);
                    found = true;
                    break;
                }
            }
            _repository.SaveArtists(artists);
            return found;
        }

        // Function To Update an Artist

        public bool UpdateArtist(string artistName, ArtistModel updateArtist)
        {
            List<ArtistModel> artists = _repository.LoadArtist();
            bool found = false;
            for (int i = 0; i < artists.Count; i++)
            {
                if (artists[i].ArtistName == artistName)
                {
                    artists[i] = updateArtist;
                    found = true;
                    break;
                }
            }
            _repository.SaveArtists(artists);
            return found;
        }

        //  Function To Generate the Report of the Total Payment We Are Giving to All Artists

        public List<string> ArtistReport()
        {
            List<ArtistModel> artists = _repository.LoadArtist();
            List<string> report = new List<string>();
            float Total = 0;
            for( int i =0; i < artists.Count; i++)
            {
                report.Add(" Artist Name : " + artists[i].ArtistName + "\t Payment : " + artists[i].Payment);
                Total = Total + artists[i].Payment;
            }
            report.Add("'Total Payment : " + Total);
            return report;
        }

    }
}
