using Microsoft.EntityFrameworkCore;
using PartyFinderData.DatabaseLayers;
using PartyFinderData.ModelLayers;
using System;
using System.Collections.Generic;
using Xunit;
using Xunit.Abstractions;

namespace APIUnitTest
{
    public class EventAccessTest
    {
        private readonly ITestOutputHelper extraOutput;
        readonly private IEventAccess _eventAccess;
        public EventAccessTest(ITestOutputHelper output)
        {
            this.extraOutput = output;
            _eventAccess = new EventAccess();

        }

        // Test p� at alle events kan findes.
        [Fact]
        public void GetAllEventsTest()
        {
            // Arrange

            // Act
            List<Event> readEvents = _eventAccess.GetEventAll();
            bool eventsWereRead = (readEvents.Count > 0);

            // Print additional output
            extraOutput.WriteLine("Number of events: " + readEvents.Count);

            // Assert
            Assert.True(eventsWereRead);

        }

        // Test p� at et Event kan findes p� en specifik Id.
        [Fact]
        public void GetEventByIdTest()
        {
            // Arrange

            Event testEvent = new Event("Test", 1, new DateTime(2008, 5, 1, 8, 30, 52), new DateTime(2009, 5, 1, 8, 30, 52), "Test", 1);

            // Act

            int id = _eventAccess.CreateEvent(testEvent);
            Event testEventOnDB = _eventAccess.GetEventByID(id);

            Event readEvent = _eventAccess.GetEventByID(id);

            bool eventWasRead = (readEvent != null);

            // Print additional output
            extraOutput.WriteLine("Number of events: " + readEvent);

            // Assert
            Assert.True(eventWasRead);


            _eventAccess.DeleteEventById(testEventOnDB);
        }

        // Test p� at man kan slette Events, og at et Event ikke bliver slettet, hvis et andet Event har (n�sten, med undtagelse af id) samme indhold.
        [Fact]
        public void DeleteEventTest()
        {
            // Arrange
            Event testEvent1 = new Event("Test", 1, new DateTime(2008, 5, 1, 8, 30, 52), new DateTime(2009, 5, 1, 8, 30, 52), "Test", 1);
            Event testEvent2 = new Event("Test", 1, new DateTime(2008, 5, 1, 8, 30, 52), new DateTime(2009, 5, 1, 8, 30, 52), "Test", 1);

            // Act

            int id1 = _eventAccess.CreateEvent(testEvent1);
            int id2 = _eventAccess.CreateEvent(testEvent2);
            _eventAccess.DeleteEventById(testEvent1);
            Event testEventOnDB1 = _eventAccess.GetEventByID(id1);
            Event testEventOnDB2 = _eventAccess.GetEventByID(id2);

            // Assert

            Assert.Equal(testEventOnDB1, null);
            Assert.Equal(testEventOnDB2.Id, id2);

            _eventAccess.DeleteEventById(testEventOnDB2);
        }

        // Test p� at et Event kan oprettes og tilf�jes til db.
        [Fact]
        public void CreateEventTest()
        {
            // Arrange
            Event testEvent = new Event("Test", 1, new DateTime(2008, 5, 1, 8, 30, 52), new DateTime(2009, 5, 1, 8, 30, 52), "Test", 1);
            // ProfileAccesTest - N�dvendig for at kunne s�tte en dummy profile p� TestEventet, lige nu tilf�jes profil 1, Admin@Adminson.dk.

            // Act

            int id = _eventAccess.CreateEvent(testEvent);
            Event testEventOnDB = _eventAccess.GetEventByID(id);

            // Assert

            Assert.Equal(id, testEventOnDB.Id);

            _eventAccess.DeleteEventById(testEventOnDB);
        }

    }
}