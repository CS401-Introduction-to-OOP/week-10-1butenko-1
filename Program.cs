using System;
using System.Linq;

class Program
{
    static void Main()
    {
        // 1. Створюємо партію
        Party party = new Party();
        party.Add(new Character("Aragorn", ERoles.A, 10, 100, 150));
        party.Add(new Character("Legolas", ERoles.B, 11, 80, 200));
        party.Add(new Character("Gimli", ERoles.C, 11, 120, 100));
        party.Add(new Character("Boromir", ERoles.A, 9, 0, 50)); // Dead
        party[3].Status = Status.Dead;

        // 2. Створюємо журнал подій
        EventLog eventLog = new EventLog();
        eventLog.Log(1, "Encounter with Orcs", Event.Attack, -10);
        eventLog.Log(2, "Rest by the river", Event.Heal, 20);
        eventLog.Log(3, "Wizard's blessing", Event.Buff, 5);
        eventLog.Log(4, "Ambush!", Event.Attack, -15);

        // 3. Перебір персонажів (IEnumerable)
        Console.WriteLine("=== Party Members ===");
        foreach (var ch in party)
        {
            Console.WriteLine($"{ch.Name} ({ch.Role}) - Lvl: {ch.Level}, HP: {ch.Hp}, Gold: {ch.GoldQuantity}, Status: {ch.Status}");
        }

        // 4. Використання yield return
        Console.WriteLine("\n=== Active Characters (yield) ===");
        foreach (var ch in party.GetActiveCharacters())
        {
            Console.WriteLine(ch.Name);
        }

        Console.WriteLine("\n=== Attack Events (yield) ===");
        foreach (var ev in eventLog.GetEventsByType(Event.Attack))
        {
            Console.WriteLine(ev);
        }

        // 5. LINQ та lambda
        Console.WriteLine("\n=== LINQ Queries ===");

        // Фільтрація: персонажі вище 10 рівня
        var highLevel = party.Where(ch => ch.Level > 10);
        Console.WriteLine($"High level (>10): {string.Join(", ", highLevel.Select(ch => ch.Name))}");

        // Сортування: за HP (спадання)
        var healthiest = party.OrderByDescending(ch => ch.Hp).First();
        Console.WriteLine($"Healthiest: {healthiest.Name} ({healthiest.Hp} HP)");

        // Агрегування: середній рівень
        double avgLevel = party.Average(ch => ch.Level);
        Console.WriteLine($"Average Level: {avgLevel:F2}");

        // Агрегування: максимальне золото
        int maxGold = party.Max(ch => ch.GoldQuantity);
        Console.WriteLine($"Max Gold: {maxGold}");

        // Групування за роллю (класом)
        var groups = party.GroupBy(ch => ch.Role);
        Console.WriteLine("Groups by Role:");
        foreach (var group in groups)
        {
            Console.WriteLine($" - Role {group.Key}: {group.Count()} characters");
        }

        Console.WriteLine("\nAssignment successfully implemented!");
    }
}
