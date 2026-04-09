public class Character(string name, ERoles role, int level, int hp, int gold)
{
    public string Name {get => name;}
    public ERoles Role {get => role;}
    public int Level {get => level;}
    public int Hp {get => hp;}
    public int GoldQuantity {get => gold;}
    public Status Status = Status.Alive;
}