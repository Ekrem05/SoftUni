using FrontDeskApp;
using NUnit.Framework;
using System;
using System.Linq;

namespace BookigApp.Tests
{
    public class Tests
    {
        private Hotel hotel;
        private Room room;
        [SetUp]
        public void Setup()
        {
            
        }

        [Test]
        public void ConstructorTest()
        {
            hotel = new Hotel("Mimoza", 2);
            Assert.That(hotel.Category, Is.EqualTo(2));
            Assert.That(hotel.FullName, Is.EqualTo("Mimoza"));

        }
        [Test]
        public void ConstructorTestExceptions()
        {
            Assert.Throws<ArgumentNullException>(() => { hotel = new Hotel(" ", 2); });
            Assert.Throws<ArgumentException>(() => { hotel = new Hotel("Mimoza", 6); });
            Assert.Throws<ArgumentException>(() => { hotel = new Hotel("Mimoza", 0); });

        }
        [Test]
        public void AddRoom()
        {
            hotel = new Hotel("Mimoza", 2);
            hotel.AddRoom(room = new(10, 10));
            Assert.That(hotel.Rooms.Count, Is.EqualTo(1));
            Assert.That(hotel.Rooms.First().BedCapacity, Is.EqualTo(10));
            Assert.That(hotel.Rooms.First().PricePerNight, Is.EqualTo(10));
        }
        [Test]
        public void BookRoom()
        {
            hotel = new Hotel("Mimoza", 2);
           
            hotel.AddRoom(room = new(10, 10));
            hotel.AddRoom(room = new(5, 50));
            hotel.BookRoom(2,2, 10, 200);
            Assert.That(hotel.Bookings.Count, Is.EqualTo(1));
            Assert.That(hotel.Turnover, Is.EqualTo(100));          
        }
        [Test]
        public void BookRoomExceptions()
        {
            hotel = new Hotel("Mimoza", 2);

            hotel.AddRoom(room = new(10, 10));
           
            Assert.Throws<ArgumentException>(() => { hotel.BookRoom(-1, 2, 10, 200); });
            Assert.Throws<ArgumentException>(() => { hotel.BookRoom(0, 2, 10, 200); });
            Assert.Throws<ArgumentException>(() => { hotel.BookRoom(5, -1, 10, 200); });
            Assert.Throws<ArgumentException>(() => { hotel.BookRoom(5, 2, -1, 200); });

        }



    }
}