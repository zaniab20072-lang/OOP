using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs.Event
{
    internal class EventRepository
    {
        // Making the file path or creating a file for Events
        private readonly string _filepath = "events.txt";


        // Function to Save the details of Events in Events File
        public void SaveEvents(List<EventModel> events)
        {
            using(StreamWriter writer = new StreamWriter("events.txt",false))
            {
                for(int i =0; i < events.Count; i++)
                {
                    writer.WriteLine(events[i].ToString());
                }
            }
        }

        // Function to Load or get all the details of that Events From events File
        public List<EventModel> LoadEvents()
        {
            List<EventModel> events = new List<EventModel>();

            if (!File.Exists("events.txt"))
            {
                return events;
            }

            using (StreamReader reader = new StreamReader("events.txt"))
            {
                string Line;
                while((Line = reader.ReadLine()) != null)
                {
                    string[] parts = Line.Split(',');
                    EventModel ev = new EventModel(parts[0], parts[1], parts[2], int.Parse(parts[3]), float.Parse(parts[4]), int.Parse(parts[5]), parts[6]);
                    events.Add(ev);
                }

            }
            return events;
        }
    }
}
