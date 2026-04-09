public class PartyActions(int move, string description, Event currentEvent, int state)
{
    public int Move { get => move; }
    public string Description { get => description; }
    public Event Event { get => currentEvent; }
    public int State { get => state; }

    public override string ToString()
    {
        return $"{Move} : Event: {Event} - Change: {State} - {Description}";
    }
}