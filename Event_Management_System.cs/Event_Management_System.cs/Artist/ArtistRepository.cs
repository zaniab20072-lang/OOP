using Event_Management_System.cs.Event;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs.Artist
{
    internal class ArtistRepository
    {
        // Making File path or create file for Artists

        private readonly string _filepath = "artists.txt";

        // Function to save all the details of Artists to file

        public void SaveArtists(List<ArtistModel> artists)
        {
            using ( StreamWriter writer = new StreamWriter("artists.txt", false))
            {
                for(int i =0; i < artists.Count; i++)
                {
                    writer.WriteLine(artists[i].ToString());
                }
            }
        }


        // Function to load or Get all the details of Artists From file

        public List<ArtistModel> LoadArtist()
        {
            List<ArtistModel> artists = new List<ArtistModel>();

            if (!File.Exists("artists.txt"))
            {
                return artists;
            }
            using (StreamReader reader = new StreamReader("artists.txt"))
            {
                string Line;
                while ((Line = reader.ReadLine()) != null)
                {
                    string[] parts = Line.Split(',');
                    ArtistModel at =new ArtistModel(parts[0], parts[1], parts[2], float.Parse(parts[3]) , parts[4]);
                    artists.Add(at);
                }
            }
            return artists;
        }

    }
}
