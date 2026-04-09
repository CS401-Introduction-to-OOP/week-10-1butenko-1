using System.Collections;

public class Party : IEnumerable<Character>
{
    private List<Character> characters = new();
    
    public int Count => characters.Count;

    public void Add(Character character) => characters.Add(character);
    public void Remove(Character character) => characters.Remove(character);

    public Character this[int index]
    {
        get => characters[index];
        set => characters[index] = value;
    }

    public IEnumerator<Character> GetEnumerator()
    {
        foreach (var character in characters)
        {
            yield return character;
        }
    }

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    
    public IEnumerable<Character> GetActiveCharacters()
    {
        foreach (var character in characters)
        {
            if (character.Status == Status.Alive)
            {
                yield return character;
            }
        }
    }

    public IEnumerable<Character> GetCharactersUnderThreshold(int threshold)
    {
        foreach (var character in characters)
        {
            if (character.Hp <= threshold)
            {
                yield return character;
            }
        }
    }
}