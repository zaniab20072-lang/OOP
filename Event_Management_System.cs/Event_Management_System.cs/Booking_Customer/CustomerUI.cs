using Event_Management_System.cs.Artist;
using Event_Management_System.cs.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs.Booking_Customer
{
    internal class CustomerUI
    {
         // Connecting With Event Service And Booking Service And Artist Service
         private readonly EventService _eventService;
         private readonly BookingService _bookingService;

        private readonly ArtistService _artistService;

        // making constructor for these services
            public CustomerUI()
            {
                _eventService = new EventService();
                _bookingService = new BookingService();
            _artistService = new ArtistService();
            }
        // function To wrtie the menu 
            private void PrintMenu()
            {
               Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("****************************************************************** ");
               Console.WriteLine("                       Customer Menu                                ");
               Console.WriteLine("****************************************************************** ");
            Console.ForegroundColor = ConsoleColor.White;
               Console.WriteLine();
               Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" 1- View Events");
               Console.WriteLine(" 2- Book Tickets");
               Console.WriteLine(" 3- Generate Ticket");
               Console.WriteLine(" 4- Search Event");
               Console.WriteLine(" 5- Cancel seats");
               Console.WriteLine(" 6- Give Your Feedback");
               Console.WriteLine(" 7- View Event Facilities");
               Console.WriteLine(" 8- View Artist ");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" 9- Logout");
            Console.ForegroundColor = ConsoleColor.White;
        }


        // Function To show the menu to Customers 
            public void ShowCustomerMenu()
            {
               while (true)
               {
                  Console.Clear();
                  PrintMenu();

                    Console.Write("\n Enter your choice: ");
                    string option = Console.ReadLine();

                    if (option == "9") { break; }
                

                  Console.Clear();
                    if (option == "1") { ViewEventsUI(); }
                    else if (option == "2") { BookTicketsUI(); }
                    else if (option == "3") { GenerateTicketUI(); }
                    else if (option == "4") { SearchEventUI(); }
                    else if (option == "5") { CancelSeatsUI(); }
                    else if (option == "6") { GiveFeedbackUI(); }
                    else if (option == "7") { ViewFacilitiesUI(); }
                    else if (option == "8") { ViewArtistUI();  }
                
                    else { Console.ForegroundColor = ConsoleColor.Gray; Console.WriteLine("\n  Invalid option!"); Console.ForegroundColor = ConsoleColor.White; }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine("  Press any key to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
            }
        // Function To View All the Events
            private void ViewEventsUI()
            {
                Console.WriteLine();
                List<EventModel> events = _eventService.GetAllEvents();

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
        // Function to Book Tickets

        private void BookTicketsUI()
            {
                Console.Write("\n  Enter your Name: ");
                string customerName = Console.ReadLine();

                ViewEventsUI();

                Console.Write("\n  Select Event Name: ");
                string eventName = Console.ReadLine();
                Console.Write("  Enter no of seats you want to reserve: ");
                int seats = int.Parse(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.DarkGreen;
                string result = _bookingService.BookTickets(customerName, eventName, seats);
                Console.WriteLine(result);
                Console.ForegroundColor = ConsoleColor.White;
        }
        // Function To Generate Tickets
            private void GenerateTicketUI()
            {
                Console.Write("\n  Enter customer name: ");
                string customerName = Console.ReadLine();

                BookingModel booking = _bookingService.GenerateTicket(customerName);

                if (booking == null)
                {
                    Console.WriteLine("\n  Booking not found");
                }
                else
                {
                    Console.WriteLine("  Your Ticket Details :");
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("\n****************************************************************************************************************");
                    Console.ForegroundColor = ConsoleColor.White;
                    Console.WriteLine("\n  Customer: " + booking.CustomerName + "\t Event: " + booking.BookingEvent
                                      + "\t Seats: " + booking.BookingSeats + "\t Bill: " + booking.TotalBill);
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    Console.WriteLine("****************************************************************************************************************");
                    Console.ForegroundColor = ConsoleColor.White;
            }
            }
        // Function To Search An event
            private void SearchEventUI()
            {
                Console.Write("\n  Enter Event name you want to search: ");
                string name = Console.ReadLine();

                EventModel ev = _eventService.SearchEvent(name);
                if (ev == null)
                {
                    Console.WriteLine("\n  Record not found");
            }
                else
                {
                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n  EventID\t EventName\t EventDate\t TotalSeats\t TicketPrice\t RemainingSeats\t FreeThings");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine("  " + ev.EventID + "\t " + ev.EventName + "\t " + ev.EventDate + "\t "
                        + ev.TotalSeats + "\t " + ev.TicketPrice + "\t " + ev.RemainingSeats + "\t " + ev.FreeThings);
                }
            }


        // function To Cancel Seats 

            private void CancelSeatsUI()
            {
                Console.Write("\n  Enter customer name: ");
                string customerName = Console.ReadLine();
                Console.Write("  Enter event name: ");
                string eventName = Console.ReadLine();
                Console.Write("  Enter seats to cancel: ");
                int cancelSeats = int.Parse(Console.ReadLine());
                 
                Console.ForegroundColor = ConsoleColor.DarkGreen;
            string result = _bookingService.CancelSeats(customerName, eventName, cancelSeats);
                Console.WriteLine(result);
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Fucntion To Give FeedBack
            private void GiveFeedbackUI()
            {
                Console.Write("\n  Enter your feedback: ");
                string feedback = Console.ReadLine();

                _bookingService.AddFeedBack(feedback);

                Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("\n  Thanks for giving your feedback ! ");
            Console.ForegroundColor = ConsoleColor.White;
        }
        // Function To view Facilties Which Are Free
            private void ViewFacilitiesUI()
            {
                List<EventModel> events = _eventService.GetAllEvents();

                Console.ForegroundColor = ConsoleColor.Magenta;
                Console.WriteLine("\n  Event Name\t\t Free Facilities");
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine();
                for (int i = 0; i < events.Count; i++)
                {
                    Console.WriteLine("  " + events[i].EventName + "\t\t " + events[i].FreeThings);
                }
            }

        // Function To View Artists 

        private void ViewArtistUI()
        {
            List<ArtistModel> artists = _artistService.GetAllArtists();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n  Artist Name \t Event Name \t Description ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for(int i =0; i < artists.Count; i++)
            {
                Console.WriteLine("  " + artists[i].ArtistName + "\t " + artists[i].ArtistEvent + "\t " + artists[i].Description);
            }
        }
    }
}

