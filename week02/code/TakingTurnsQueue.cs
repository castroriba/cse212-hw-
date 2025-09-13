using System;
using System.Collections.Generic;

public class TakingTurnsQueue
{
    private List<Person> _players = new List<Person>();
    private int _currentIndex = 0;

    public int Length => _players.Count;

    public void AddPerson(string name, int turns)
    {
        _players.Add(new Person(name, turns));
    }

    public Person GetNextPerson()
    {
        if (_players.Count == 0)
            throw new InvalidOperationException("No one in the queue.");

        Person current = _players[_currentIndex];

        // Handle turns for positive numbers
        if (current.Turns > 0)
        {
            current.Turns--;
            if (current.Turns == 0)
            {
                _players.RemoveAt(_currentIndex);
                if (_players.Count == 0)
                    return current;
                // Keep currentIndex at same position because list shifted
                _currentIndex %= _players.Count;
                return current;
            }
        }

        // Advance to next player
        _currentIndex = (_currentIndex + 1) % _players.Count;

        return current;
    }
}

public class Person
{
    public string Name { get; }
    public int Turns { get; set; }

    public Person(string name, int turns)
    {
        Name = name;
        Turns = turns;
    }
}

