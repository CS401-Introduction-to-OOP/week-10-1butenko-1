using System.Collections;

public class EventLog : IEnumerable<PartyActions>
{
    private List<PartyActions> events = new();

    public void Log(int move, string description, Event eventType, int stateChange)
    {
        events.Add(new PartyActions(move, description, eventType, stateChange));
    }

    public IEnumerator<PartyActions> GetEnumerator()
    {
        foreach (var ev in events)
        {
            yield return ev;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

    public IEnumerable<PartyActions> GetEventsByType(Event type)
    {
        foreach (var ev in events)
        {
            if (ev.Event == type)
            {
                yield return ev;
            }
        }
    }

    public IEnumerable<PartyActions> GetLastNEvents(int n)
    {
        int start = Math.Max(0, events.Count - n);
        for (int i = start; i < events.Count; i++)
        {
            yield return events[i];
        }
    }
}