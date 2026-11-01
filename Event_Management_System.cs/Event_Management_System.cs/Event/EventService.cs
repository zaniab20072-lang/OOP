using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs.Event
{
    internal class EventService
    {
        // connecting with the repo of Event
        private readonly EventRepository _repository;

        // Constructor of the Event Service

        public EventService()
        {
            _repository = new EventRepository();
        }

        // Function to get All the Events From the File

        public List<EventModel> GetAllEvents()
        {
            return _repository.LoadEvents();
        }

        //Function To Search Event By it's Name

        public EventModel SearchEvent(string eventName)
        {
            List<EventModel> events = _repository.LoadEvents();
            for(int i =0; i < events.Count; i++)
            {
                if (events[i].EventName == eventName)
                {
                    return events[i];
                }
            }
            return null;
        }

        // Funtion To Add an Event
        public void AddEvent(EventModel newEvent)
        {
            List<EventModel> events = _repository.LoadEvents();
            events.Add(newEvent);
            _repository.SaveEvents(events);
        }

        // Function To Delete An Event 

        public bool DeleteEvent(string eventName)
        {
            List<EventModel> events = _repository.LoadEvents();
            bool found = false;
            for( int i =0; i < events.Count; i++)
            {
                if (events[i].EventName == eventName)
                {
                    events.RemoveAt(i);
                    found = true;
                    break;
                }
            }
            _repository.SaveEvents(events);
            return found;
        }

        // Function To Update an Event
        public bool UpdateEvent(string eventName, EventModel updateEvent)
        {
            List<EventModel> events = _repository.LoadEvents();
            bool found = false;
            for (int i = 0; i < events.Count; i++)
            {
                if (events[i].EventName == eventName)
                {
                    events[i] = updateEvent;
                    found = true;
                    break;
                }
            }
            _repository.SaveEvents(events);
            return found;
        }

        // Function To Sort Event By It's Highest ticketPrice

        public List<EventModel> SortEvent()
        {
            List<EventModel> events = _repository.LoadEvents();
            for(int i =0; i <events.Count -1; i++)
            {
                for( int j = i+1; j < events.Count; j++)
                {
                    if (events[i].TicketPrice < events[j].TicketPrice)
                    {
                        EventModel temp = events[i];
                        events[i] = events[j];
                        events[j] = temp;
                    }
                }
            }
            _repository.SaveEvents(events);
            return events;
        }

        // Function To get Reports 

        public List<string> EventReport()
        {
            List<EventModel> events = _repository.LoadEvents();
            List<string> reports = new List<string>();
            for (int i = 0; i < events.Count; i++)
            {
                int booked = events[i].TotalSeats - events[i].RemainingSeats;
                float revenue = booked * events[i].TicketPrice;
                reports.Add(" Event Name : " + events[i].EventName + "\t Booked Seat : " + booked + "\t Revenue : " + revenue);
            }
            return reports;
        }
    }
}
