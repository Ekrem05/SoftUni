using BookingApp.Models.Bookings.Contracts;
using BookingApp.Models.Hotels.Contacts;
using BookingApp.Models.Rooms.Contracts;
using BookingApp.Models.Rooms.Models;
using BookingApp.Repositories.Contracts;
using BookingApp.Repositories.Models;
using BookingApp.Utilities.Messages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Models.Hotels
{
    public class Hotel : IHotel
    {
        private string fullName;
        private int category;

        public Hotel(string fullName, int category)
        {
            FullName = fullName;
            Category = category;
            Rooms = new RoomRepository();
            Bookings = new BookingRepository();
        }

        public string FullName
        {
            get { return fullName; }
            private set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.HotelNameNullOrEmpty));
                }
                fullName = value; }
        }
        public int Category
        {
            get { return category; }
            private set
            {
                if (value<1||value>5)
                {
                    throw new ArgumentException(string.Format(ExceptionMessages.InvalidCategory));
                }
                category = value;
            }
        }
        public double Turnover => Math.Round(Bookings.All().Sum(b=>b.ResidenceDuration*b.Room.PricePerNight),2);
        public IRepository<IRoom> Rooms { get; private set; }
        public IRepository<IBooking> Bookings { get; private set; }
    }
}
