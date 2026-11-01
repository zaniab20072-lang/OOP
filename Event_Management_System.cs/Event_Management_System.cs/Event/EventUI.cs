using Event_Management_System.cs.Artist;
using Event_Management_System.cs.Booking_Customer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs.Event
{
    internal class EventUI
    {
        // connecting with the services of booking and event
        private readonly EventService _eventService;
        private readonly BookingService _bookingService;

        // making constructor for them

        public EventUI()
        {
            _eventService = new EventService();
            _bookingService = new BookingService();
        }

        // Function For Makiing Event Menu Or To Print Event Menu

        private void PrintMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("********************************************************************************");
            Console.WriteLine("                         Event Management System                                ");
            Console.WriteLine("********************************************************************************");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" 1- Show All Events");
            Console.WriteLine(" 2- Search Event");
            Console.WriteLine(" 3- Add Event");
            Console.WriteLine(" 4- Delete Event");
            Console.WriteLine(" 5- Update Record of Event");
            Console.WriteLine(" 6- Report of Events");
            Console.WriteLine(" 7- View Customers");
            Console.WriteLine(" 8- View Bookings");
            Console.WriteLine(" 9- Sort Events By Highest Price");
            Console.WriteLine(" 10- View feedbacks of Customers");
            Console.WriteLine(" 11- Manage Artists");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" 12- Logout");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Function To Show Menu For Event Organizer 

        public void ShowEventMenu()
        {
            
            while (true)
            { 
                Console.Clear();

                PrintMenu();

                Console.ForegroundColor = ConsoleColor.Gray;
                Console.Write("\n Choose option: ");
                string option = Console.ReadLine();
                Console.ForegroundColor = ConsoleColor.White;

                if (option == "12") { break; }

                Console.Clear();


                if (option == "1") { ShowAllEventsUI(); }
                else if (option == "2") { SearchEventUI(); }
                else if (option == "3") { AddEventUI(); }
                else if (option == "4") { DeleteEventUI(); }
                else if (option == "5") { UpdateEventUI(); }
                else if (option == "6") { ReportUI(); }
                else if (option == "7") { ViewCustomersUI(); }
                else if (option == "8") { ViewBookingsUI(); }
                else if (option == "9") { SortEventsUI(); }
                else if (option == "10") { ViewFeedbackUI(); }
                else if (option == "11") 
                { ArtistUI artistUI = new ArtistUI();
                    artistUI.ShowArtistMenu();
                }
                
                else { Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine(" Invalid option!"); Console.ForegroundColor = ConsoleColor.White; }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" Press any key to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }

        // Function To show All Event 

        private void ShowAllEventsUI()
        {
            List<EventModel> events = _eventService.GetAllEvents();
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("  EventID\t EventName\t EventDate\t TotalSeats\t TicketPrice\t RemainingSeats\t FreeThings");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine("  " + events[i].EventID + "\t\t " + events[i].EventName + "\t " + events[i].EventDate + "\t "
                    + events[i].TotalSeats + "\t\t " + events[i].TicketPrice + "\t\t " + events[i].RemainingSeats + "\t\t " + events[i].FreeThings);
            }
        }

        // Function To Search An Event 

        private void SearchEventUI()
        {
            Console.WriteLine();
            Console.Write("  Enter Event Name to search : ");
            string name = Console.ReadLine();

            EventModel ev = _eventService.SearchEvent(name);

            if (ev == null)
            {
                Console.WriteLine(" Record not found ");
            }
            else
            {
                Console.WriteLine("\n  " + ev.EventID + "\t " + ev.EventName + "\t " + ev.EventDate + "\t "
                    + ev.TotalSeats + "\t " + ev.TicketPrice + "\t " + ev.RemainingSeats + "\t " + ev.FreeThings);
            }
        }

        // Function To Add An Event 

        private void AddEventUI()
        {
            Console.WriteLine(); 
            Console.Write("  Enter Event ID: ");
            string eventID = Console.ReadLine();
            Console.Write("  Enter Event Name: ");
            string eventName = Console.ReadLine();
            Console.Write("  Enter Event Date: ");
            string eventDate = Console.ReadLine();
            Console.Write("  Enter Total Seats: ");
            int totalSeats = int.Parse(Console.ReadLine());
            Console.Write("  Enter Ticket Price: ");
            int ticketPrice = int.Parse(Console.ReadLine());
            Console.Write("  Enter Remaining Seats: ");
            int remainingSeats = int.Parse(Console.ReadLine());
            Console.Write("  Enter Free Facilities: ");
            string freeThings = Console.ReadLine();

            EventModel newEvent = new EventModel(eventID, eventName, eventDate, totalSeats, ticketPrice, remainingSeats, freeThings);
            _eventService.AddEvent(newEvent);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  Event added successfully!");
            Console.ForegroundColor = ConsoleColor.White;
        }


        // Function To Delete An Event

        private void DeleteEventUI()
        {
            Console.Write("\n  Enter event name to delete: ");
            string name = Console.ReadLine();

            bool found = _eventService.DeleteEvent(name);
             if(found)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n   Record Deleted Successfully ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("\n   Event Not Found ");
            }
        }

        // Function To Update An Event 

        private void UpdateEventUI()
        {
            Console.Write("\n  Enter event name to update : ");
            string name = Console.ReadLine();

            EventModel existing = _eventService.SearchEvent(name);

            if (existing == null)
            {
                Console.WriteLine("  Record not found");
                return;
            }

            Console.WriteLine("  Now enter the details \n");

            Console.Write("  Enter Event ID: ");
            string eventID = Console.ReadLine();
            Console.Write("  Enter Event Name: ");
            string eventName = Console.ReadLine();
            Console.Write("  Enter Event Date: ");
            string eventDate = Console.ReadLine();
            Console.Write("  Enter Total Seats: ");
            int totalSeats = int.Parse(Console.ReadLine());
            Console.Write("  Enter Ticket Price: ");
            int ticketPrice = int.Parse(Console.ReadLine());
            Console.Write("  Enter Remaining Seats: ");
            int remainingSeats = int.Parse(Console.ReadLine());
            Console.Write("  Enter Free Facilities: ");
            string freeThings = Console.ReadLine();

            EventModel updateEvent = new EventModel(eventID, eventName, eventDate, totalSeats, ticketPrice, remainingSeats, freeThings);
            _eventService.UpdateEvent(name, updateEvent);      

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  Event updated successfully!");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Function To Show reports 

        private void ReportUI()
        {
            Console.WriteLine();
            List<string> report = _eventService.EventReport();
            for (int i = 0; i < report.Count; i++)
            {
                Console.WriteLine("  " + report[i]);
            }
        }

        // Function To Sort Event 

        private void SortEventsUI()
        {
            List<EventModel> events = _eventService.SortEvent();

            Console.WriteLine("\n Events sorted by highest ticket price:");
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n  Event Name\tTicket Price\n");
            Console.ForegroundColor = ConsoleColor.White;
            for (int i = 0; i < events.Count; i++)
            {
                Console.WriteLine("  " +events[i].EventName + "\t " + events[i].TicketPrice);
            }
        }

        // Function To See Customers

        private void ViewCustomersUI()
        {
            Console.WriteLine();

            List<BookingModel> bookings = _bookingService.GetAllBookings();
            for (int i = 0; i < bookings.Count; i++)
            {
                Console.WriteLine("  " + (i + 1) + "  Customer Name: " + bookings[i].CustomerName);
            }
        }

        // Function To View Bookings 
        private void ViewBookingsUI()
        {
            Console.WriteLine();
            List<BookingModel> bookings = _bookingService.GetAllBookings();
            for (int i = 0; i < bookings.Count; i++)
            {
                Console.WriteLine("  Customer: " + bookings[i].CustomerName + "\t Event: " + bookings[i].BookingEvent
                    + "\t Seats: " + bookings[i].BookingSeats + "\t Bill: " + bookings[i].TotalBill);
            }
        }

        // View FeedBacks From Customers
        private void ViewFeedbackUI()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("****************************************************************** ");
            Console.WriteLine("                 Feedback from Customers:                          ");
            Console.WriteLine("****************************************************************** ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            List<string> feedbackList = _bookingService.GetAllFeedBack();
            for (int i = 0; i < feedbackList.Count; i++)
            {
                Console.WriteLine(" * " + feedbackList[i]);
            }
        }

    }
}
