namespace PartyFinderWEB.Models
{
    public class EventViewModel
    {

    public EventViewModel(string eventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, string description, int profileId)
    {
        EventName = eventName;
        EventCapacity = eventCapacity;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Description = description;
        ProfileId = profileId;
    }

    public int Id { get; set; }
    public string EventName { get; set; } = null!;
    public int EventCapacity { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string? Description { get; set; }
    public int ProfileId { get; set; }
}
}

