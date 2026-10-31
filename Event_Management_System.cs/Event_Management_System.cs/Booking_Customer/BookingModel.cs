using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs.Booking_Customer
{
    internal class BookingModel
    {
        //Attributes of Booking Model Class or variables
        public string CustomerName { get; set; }
        public string BookingEvent { get; set; }
        public int BookingSeats { get; set; }
        public float TotalBill { get; set; }


        //Default Constructor
        public BookingModel() { }


        //Peramiterized Constructor
        public BookingModel(string customerName, string bookingEvent, int bookingSeats, float totalBill)
        {
            CustomerName = customerName;
            BookingEvent = bookingEvent;
            BookingSeats = bookingSeats;
            TotalBill = totalBill;
        }


        // ToString Function From Which We Return The details And Then Add them In Files
        public override string ToString()
        {
            return $"{CustomerName},{BookingEvent},{BookingSeats},{TotalBill}";
        }


    }
}
