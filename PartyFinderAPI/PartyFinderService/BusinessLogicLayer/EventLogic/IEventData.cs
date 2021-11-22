using PartyFinderData.ModelLayers;
using System.Collections.Generic;

namespace PartyFinderService.BusinessLogicLayer
{
    public interface IEventData
    {

        Event Get(int id);
        List<Event> Get();
        void Add(Event eventToAdd);
        void Put(Event updatedEvent);
        void Delete(Event evenToDelete);

    }

}
