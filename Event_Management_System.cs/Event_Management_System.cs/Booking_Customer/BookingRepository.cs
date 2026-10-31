using Event_Management_System.cs.Event;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs.Booking_Customer
{
    internal class BookingRepository
    {

        // Making the file path or creating a file for Bookings
        private readonly string _filepath = "bookings.txt";


        // Function to Save the details of Bookings in Bookings File
        public void SaveBookings(List<BookingModel> bookings)
        {
            using (StreamWriter writer = new StreamWriter("bookings.txt", false))
            {
                for (int i = 0; i < bookings.Count; i++)
                {
                    writer.WriteLine(bookings[i].ToString());
                }
            }
        }


        // Function to Load or get all the details of that Bookings From bookings File

        public List<BookingModel> LoadBookings()
        {
            List<BookingModel> bookings = new List<BookingModel>();

            if (!File.Exists("bookings.txt"))
            {
                return bookings;
            }
            using (StreamReader reader = new StreamReader("bookings.txt"))
            {
                string Line;
                while ((Line = reader.ReadLine()) != null)
                {
                    string[] parts = Line.Split(',');
                    BookingModel booking = new BookingModel(parts[0], parts[1], int.Parse(parts[2]), float.Parse(parts[3]));
                    bookings.Add(booking);
                }
            }
            return bookings;
        }


         //                         code for Feedbacks Files


        // Creating or making file path for feedbacks

        private readonly string _filepaths = "feedbacks.txt";


        // Functions To save FeedBacks To files 

        public void SaveFeedBacks(string feedBack)
        {
            using (StreamWriter writer = new StreamWriter("feedbacks.txt", true))
            {
                writer.WriteLine(feedBack);
            }
        }


        // Functions To Load or get all the Feedbacks From files 

        public List<string> LoaadfeedBacks()
        {
            List<string> feedbacklist = new List<string>();

            if (!File.Exists("feedbacks.txt"))
            {
                return feedbacklist;
            }
            using (StreamReader reader = new StreamReader("feedbacks.txt"))
            {
                string Line;
                while((Line = reader.ReadLine())!= null)
                {
                    feedbacklist.Add(Line);
                }
            }
            return feedbacklist;
        }

    }
}
