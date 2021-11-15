using PartyFinderData.ModelLayers;
using System.Collections.Generic;

namespace PartyFinderService.BusinessLogicLayer
{
    public interface IEventData
    {

        Event Get(int id);
        List<Event> Get();
        void Add(Event eventToAdd);
        void Put(int id, Event updatedEvent);
        void Delete(int id);

    }

}
