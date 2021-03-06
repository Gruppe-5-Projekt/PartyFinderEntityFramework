using PartyFinderData.ModelLayers;
using System.Collections.Generic;

namespace PartyFinderService.BusinessLogicLayer
{
    public interface IEventData
    {

        Event Get(int id);
        List<Event> Get();
        int Add(Event eventToAdd);
        bool Put(Event updatedEvent);
        bool Delete(Event evenToDelete);

    }

}
