using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs.Artist
{
    internal class ArtistModel
    {
        //Attributes of Artist Model Class or variables
        public string ArtistID { get; set; }
        public string ArtistName { get; set; }
        public string ArtistEvent{ get; set; }
        public float Payment { get; set; }
        public string Description { get; set; }


        //Default Constructor
        public ArtistModel() { }


        //Peramiterized Constructor
        public ArtistModel(string artistID, string artistName, string artistEvent, float payment, string description)
        {
            ArtistID = artistID;
            ArtistName = artistName;
            ArtistEvent = artistEvent;
            Payment = payment;
            Description = description;
        }


        // ToString Function From Which We Return The details And Then Add them In Files
        public override string ToString()
        {
            return $"{ArtistID},{ArtistName},{ArtistEvent},{Payment},{Description}";
        }

    }
}
