using Event_Management_System.cs.Booking_Customer;
using Event_Management_System.cs.Event;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Event_Management_System.cs.Artist
{
    internal class ArtistUI
    {
        // connecting with the services of booking and event
        private readonly ArtistService _artistService;
        private readonly EventService _eventService;

        // making constructor for them

        public ArtistUI()
        {
            _artistService = new ArtistService();
            _eventService = new EventService();
        }

        // Function For Makiing Event Menu Or To Print Event Menu

        private void PrintMenu()
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("****************************************************************** ");
            Console.WriteLine("                        Artist Menu                                ");
            Console.WriteLine("****************************************************************** ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" 1- Show All Artist");
            Console.WriteLine(" 2- Search Artist");
            Console.WriteLine(" 3- Add Artist");
            Console.WriteLine(" 4- Delete Artist");
            Console.WriteLine(" 5- Update Artist");
            Console.WriteLine(" 6- Report of Artists");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" 7- Logout");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Function For Artist Menu

        public void ShowArtistMenu()
        {
            while(true)
            {
                Console.Clear();
                PrintMenu();
                Console.Write("\n  Enter your Choice : ");
                int Choice = int.Parse(Console.ReadLine());

                if (Choice == 7) { break;  }

                Console.Clear();

                if (Choice == 1)  { ShowAllArtistsUI(); }
                else if (Choice == 2) { SearchArtistUI(); }
                else if (Choice == 3) { AddArtistUI(); }
                else if (Choice == 4) { DeleteArtistUI();  }
                else if (Choice == 5) { UpdateArtistUI(); }
                else if (Choice == 6) { ReportOfArtistsUI(); }
                
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                    Console.WriteLine("\n Invalid Choice ");
                    Console.ForegroundColor = ConsoleColor.White;
                }

                Console.WriteLine();
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine(" Press any key to continue...");
                Console.ForegroundColor = ConsoleColor.White;
                Console.ReadKey();
            }
        }

        // Function To Show All Artist 
        private void ShowAllArtistsUI()
        {
            List<ArtistModel> artists = _artistService.GetAllArtists();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n  ArtistID\t Artist Name\t\t Event Name\t\t Payment\t Description");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for(int i =0;  i < artists.Count; i++)
            {
                Console.WriteLine("  " +artists[i].ArtistID + "\t\t " + artists[i].ArtistName + "\t\t " + artists[i].ArtistEvent + "\t\t " + artists[i].Payment + "\t\t " + artists[i].Description);
            }
        }

        // Function To Search Artists

        private void SearchArtistUI()
        {
            Console.Write("\n  Enter Artist Name You wanna Search : ");
            string artistName = Console.ReadLine();
            ArtistModel at = _artistService.SearchArtist(artistName);
            if (at == null)
            {
                Console.WriteLine("\n  Artist Not Found ");
            }
            else 
            {
                Console.WriteLine("\n  Artist Name : " + at.ArtistName + "\t Artist ID : " + at.ArtistID + "\t Event Name : " + at.ArtistEvent + "\t Payment : " + at.Payment + "\t Artist Description : " + at.Description );
            }
        }

        // Function To Add An Artist

        private void AddArtistUI()
        {
            Console.Write("\n  Enter Artist ID : ");
            string artistID = Console.ReadLine();
            Console.Write("  Enter Artist Name : ");
            string artistName = Console.ReadLine();
            Console.Write("  Enter Event Name : ");
            string eventName = Console.ReadLine();
            Console.Write("  Enter Payment : ");
            int payment = int.Parse(Console.ReadLine());
            Console.Write("  Enter Description : ");
            string description = Console.ReadLine();

            ArtistModel newArtist = new ArtistModel(artistID, artistName, eventName, payment, description);
            _artistService.AddArtist(newArtist);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  Artist Added Successfully !");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Function To Delete An Artist

        private void DeleteArtistUI()
        {
            Console.Write("\n  Enter Artist Name You want to Delete : ");
            string artistName = Console.ReadLine();
            bool found = _artistService.DeleteArtist(artistName);
            if (found)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n  Artist Deleted Successfully !");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.WriteLine("\n  Artist Not Found ");
            }
        }

        // Function To Update An Artist

        private void UpdateArtistUI()
        {
            Console.Write("\n  Enter Artist Name You want to Update : ");
            string name = Console.ReadLine();

            ArtistModel existing = _artistService.SearchArtist(name);

            if (existing == null)
            {
                Console.WriteLine("\n  Artist Not Found ");
                return;
            }

            Console.Write("\n  Enter Artist ID : ");
            string artistID = Console.ReadLine();
            Console.Write("  Enter Artist Name : ");
            string artistName = Console.ReadLine();
            Console.Write("  Enter Event Name : ");
            string eventName = Console.ReadLine();
            Console.Write("  Enter Payment : ");
            int payment = int.Parse(Console.ReadLine());
            Console.Write("  Enter Description : ");
            string description = Console.ReadLine();

            ArtistModel updatedArtist = new ArtistModel(artistID, artistName, eventName, payment, description);
            _artistService.UpdateArtist(name, updatedArtist);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\n  Artist Updated Successfully !");
            Console.ForegroundColor = ConsoleColor.White;
        }

        // Function To Generate Report Of Artists
        private void ReportOfArtistsUI()
        {
            List<ArtistModel> artists = _artistService.GetAllArtists();
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\n  Artist Name \t Event Name \t Payment ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine();
            for (int i = 0; i < artists.Count; i++)
            {
                Console.WriteLine("  " + artists[i].ArtistName + "\t " + artists[i].ArtistEvent + "\t " + artists[i].Payment);
            }
        }

    }
}
