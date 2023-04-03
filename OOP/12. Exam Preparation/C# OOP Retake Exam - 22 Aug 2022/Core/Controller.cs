using BookingApp.Core.Contracts;
using BookingApp.Models.Bookings;
using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Repositories;
using BookingApp.Repositories.Contracts;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Core
{
    public class Controller : IController
    {
        private string[] roomTypes = new string[3] { "Apartment", "DoubleBed", "Studio" };
        private IRepository<IHotel> hotelRepository;
         
        public Controller() { hotelRepository = new HotelRepository(); } 
        public string AddHotel(string hotelName, int category)
        {
            IHotel hotel;
            if(hotelRepository.All().FirstOrDefault(x=>x.FullName==hotelName) != null)
            {
                return string.Format(OutputMessages.HotelAlreadyRegistered, hotelName);
            }
            hotelRepository.AddNew(hotel=new Hotel(hotelName,category));
            return string.Format(OutputMessages.HotelSuccessfullyRegistered, category,hotelName);
        }

        public string BookAvailableRoom(int adults, int children, int duration, int category)
        {
            List<IHotel> hotels = hotelRepository.All().Where(x=>x.Category==category)
                  .OrderBy(x => x.FullName).ToList();
            if (!hotels.Any(x=>x.Category==category))
            {
                return string.Format(OutputMessages.CategoryInvalid, category);
            }
           
           bool empty=true;
            
            foreach (var item in hotels)
            {
                
                foreach (IRoom room in item.Rooms.All().Where(x=>x.PricePerNight>0).OrderBy(x=>x.BedCapacity))
                { 
                        if (room.BedCapacity >= adults + children)
                        {   
                            int bookingNumber = hotelRepository.All().Sum(x => x.Bookings.All().Count) + 1;                     
                            empty = false;
                            hotelRepository.Select(item.FullName).Bookings.AddNew(new Booking(room, duration, adults, children, bookingNumber));
                            return string.Format(OutputMessages.BookingSuccessful, bookingNumber, item.FullName);
                        }
                }
                
             }

             
            
                return string.Format(OutputMessages.RoomNotAppropriate);
        }

        public string HotelReport(string hotelName)
        {
            IHotel hotel = hotelRepository.Select(hotelName);
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);

            }
            StringBuilder sb=new StringBuilder();
            sb.AppendLine($"Hotel name: {hotelName}");
            sb.AppendLine($"--{hotel.Category} star hotel");
            sb.AppendLine($"--Turnover: {hotel.Turnover:f2} $");
            sb.AppendLine($"--Bookings:");
            sb.AppendLine();
            if (hotel.Bookings.All().Count>0)
            {
                foreach (var item in hotel.Bookings.All())
                {
                    sb.AppendLine(item.BookingSummary());
                    sb.AppendLine();
                }

            }
            else
            {
                sb.AppendLine("none");
            }
            
            return sb.ToString().TrimEnd();   
        }

        public string SetRoomPrices(string hotelName, string roomTypeName, double price)
        {
            IHotel hotel = hotelRepository.Select(hotelName);
            IRoom room;
            if (hotel == null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }         
            if (!roomTypes.Contains(roomTypeName))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            if (hotel.Rooms.Select(roomTypeName).PricePerNight!=0)
            {
                throw new ArgumentException(ExceptionMessages.PriceAlreadySet);
            }
            room = hotel.Rooms.Select(roomTypeName);
            if (room==null)
            {
                return string.Format(OutputMessages.RoomTypeNotCreated);

            }

          hotel.Rooms.Select(roomTypeName).SetPrice(price);
          
            return string.Format(OutputMessages.PriceSetSuccessfully,roomTypeName,hotelName);
        }

        public string UploadRoomTypes(string hotelName, string roomTypeName)
        {
            IHotel hotel = hotelRepository.Select(hotelName);
            IRoom room;
            if (hotel==null)
            {
                return string.Format(OutputMessages.HotelNameInvalid, hotelName);
            }
            if (hotel.Rooms.All().FirstOrDefault(x => x.GetType().Name == roomTypeName) != null)
            {
                return string.Format(OutputMessages.RoomTypeAlreadyCreated);
            }
            if (!roomTypes.Contains(roomTypeName))
            {
                throw new ArgumentException(ExceptionMessages.RoomTypeIncorrect);
            }
            if (roomTypeName== "Apartment")
            {
                room = new Apartment();
            }
            else if (roomTypeName == "Studio")
            {
                room = new Studio();
            }
            else
            {
                room = new DoubleBed();
            }
            hotel.Rooms.AddNew(room);
            return string.Format(OutputMessages.RoomTypeAdded,roomTypeName,hotelName);
        }
    }
}
