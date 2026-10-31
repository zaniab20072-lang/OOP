using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs.Event
{
    internal class EventModel
    {
        //Attributes of Event Model Class or variables
        public string EventID { get; set; }
        public string EventName { get; set; }
        public string EventDate { get; set; }
        public int TotalSeats { get; set; }
        public float TicketPrice { get; set; }
        public int RemainingSeats { get; set; }
        public string FreeThings { get; set; }


        //Default Constructor
        public EventModel() { }


        //Peramiterized Constructor
        public EventModel(string eventID, string eventName, string eventDate, int totalSeats, float ticketPrice, int remainingSeats, string freeThings)
        {
            EventID = eventID;
            EventName = eventName;
            EventDate = eventDate;
            TotalSeats = totalSeats;
            TicketPrice = ticketPrice;
            RemainingSeats = remainingSeats;
            FreeThings = freeThings;
        }


        // ToString Function From Which We Return The details And Then Add them In Files
        public override string ToString()
        {
            return $"{EventID},{EventName},{EventDate},{TotalSeats},{TicketPrice},{RemainingSeats},{FreeThings}";
        }

    }
}
