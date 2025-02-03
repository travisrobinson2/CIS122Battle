using System;
using System.Collections.Generic;
using System.Linq;

public class Arena
{
    private List<Gladiator> gladiators = new();
    private Dictionary<string, int> gladiatorSecrets = new();
    private List<string> defeatedGladiators = new();

    public void RegisterGladiator(Gladiator gladiator, int secret)
    {
        gladiatorSecrets[gladiator.Name] = secret;
        gladiators.Add(gladiator);
    }

    public void StartBattle()
    {
        while (gladiators.Count(g => g.Health > 0) > 1)
        {
            foreach (var gladiator in gladiators.Where(g => g.Health > 0))
            {
                var attacks = gladiator.Attack(gladiators);

                foreach (var (opponentName, damage) in attacks)
                {
                    Gladiator opponent = gladiators.FirstOrDefault(g => g.Name == opponentName);
                    if (opponent != null && opponent.Health > 0)
                    {
                        int initialHealth = opponent.Health;
                        Console.WriteLine(gladiator.AttackAction(opponent.Name, damage));
                        opponent.ApplyDamage(damage, gladiatorSecrets[opponent.Name], gladiator.Name);

                        // Check for defeat
                        if (opponent.Health <= 0 && !defeatedGladiators.Contains(opponent.Name))
                        {
                            defeatedGladiators.Add(opponent.Name);
                            PrintDefeatMessage(opponent.Name);
                        }
                    }
                }
            }
        }

        PrintResults();
    }

    private void PrintDefeatMessage(string name)
    {
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine($"{name} has been defeated!");
        Console.ResetColor();
    }

    private void PrintResults()
    {
        Console.WriteLine("Battle Over!");
        Console.WriteLine("Defeat Order:");
        foreach (var name in defeatedGladiators)
        {
            Console.WriteLine(name);
        }

        var winner = gladiators.FirstOrDefault(g => g.Health > 0);
        if (winner != null)
        {
            Console.WriteLine($"Winner: {winner.Name}");
        }
    }
}
