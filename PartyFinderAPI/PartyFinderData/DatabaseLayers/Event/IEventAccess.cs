using PartyFinderData.ModelLayers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyFinderData.DatabaseLayers
{
    public interface IEventAccess
    {
        Event GetEventByID(int id);
        List<Event> GetEventAll();
        bool CreateEvent(Event eventToAdd);
        bool UpdateEvent(Event updatedEvent);
        bool DeleteEventById(Event eventToDelete);
    }
}
