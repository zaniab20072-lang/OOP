using Event_Management_System.cs.Artist;
using Event_Management_System.cs.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs.Booking_Customer
{
    internal class BookingService
    {
        // Getting or Linking With Event Serive And Booking Repository

        private readonly BookingRepository _repository;
        private readonly EventService _eventService;

        // making Consturcotr of them now for BookingSerive

        public BookingService()
        {
            _repository = new BookingRepository();
            _eventService = new EventService();
        }

        // Function To Get All the Bookings 
         public List<BookingModel> GetAllBookings()
        {
            return _repository.LoadBookings();
        }

        // Function To Book A Ticket For A customer 

        public string BookTickets(String customerName, string eventName, int seats)
        {
            EventModel ev = _eventService.SearchEvent(eventName);
            if (ev == null)
            {
                return " Event Not Found ";
            }
            if( ev.RemainingSeats < seats)
            {
                return " Not Enough Seats are Avialable ";  
            }
            ev.RemainingSeats -= seats;
            _eventService.UpdateEvent(eventName, ev);
            float totalPrice = seats * ev.TicketPrice;
            BookingModel booking = new BookingModel(customerName, eventName, seats, totalPrice);
            List<BookingModel> bookings = _repository.LoadBookings();
            bookings.Add(booking);
            _repository.SaveBookings(bookings);
            return " Tickets Booked Successfully ! ";
        }

        // Function To Generate Tickets

        public BookingModel GenerateTicket(string customerName)
        {
            List<BookingModel> bookings = _repository.LoadBookings();
            for(int i =0; i< bookings.Count; i++)
            {
                if (bookings[i].CustomerName == customerName)
                {
                    return bookings[i];
                }
            }
            return null;
        }

        // Function to cancel seats 

        public string CancelSeats(string customerName, string eventName, int cancelSeats)
        {
            List<BookingModel> bookings = _repository.LoadBookings();
            int foundIndex = -1;
            for(int i =0; i < bookings.Count; i++)
            {
                if (bookings[i].CustomerName == customerName && bookings[i].BookingEvent == eventName)
                {
                    foundIndex = i;
                    break;
                }
            }
            if(foundIndex == -1)
            {
                return " Booking Not Found ";
            }
            if( cancelSeats > bookings[foundIndex].BookingSeats)
            {
                return " You Cannot Cancel Seats more than Booked Seats ";
            }
            EventModel ev = _eventService.SearchEvent(eventName);
            ev.RemainingSeats += cancelSeats;
            _eventService.UpdateEvent(eventName, ev);
            bookings[foundIndex].BookingSeats -= cancelSeats;
            bookings[foundIndex].TotalBill = bookings[foundIndex].BookingSeats * ev.TicketPrice;
            _repository.SaveBookings(bookings);
            return " Seats Cancel Successfully ! ";
        }
         
        // Fucntion To Add FeedBack 
         
        public void AddFeedBack( string feedBack)
        {
            _repository.SaveFeedBacks(feedBack);
        }

        // Function To Get or see All the Feedbacks

        public List<String> GetAllFeedBack()
        {
            return _repository.LoaadfeedBacks();
        }
    }
}
