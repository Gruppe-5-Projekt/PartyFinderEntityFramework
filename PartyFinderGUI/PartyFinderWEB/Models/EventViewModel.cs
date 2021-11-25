namespace PartyFinderWEB.Models
{
    public class EventViewModel
    {

    public EventViewModel(string eventName, int eventCapacity, DateTime startDateTime, DateTime endDateTime, string description, string userIdValue, int profileId)
    {
        EventName = eventName;
        EventCapacity = eventCapacity;
        StartDateTime = startDateTime;
        EndDateTime = endDateTime;
        Description = description;
        UserIdValue = userIdValue;
        ProfileId = profileId;
    }

    public int Id { get; set; }
    public string EventName { get; set; } = null!;
    public int EventCapacity { get; set; }
    public DateTime StartDateTime { get; set; }
    public DateTime EndDateTime { get; set; }
    public string? Description { get; set; }
    public string? UserIdValue { get; set; }
    public int ProfileId { get; set; }
}
}

