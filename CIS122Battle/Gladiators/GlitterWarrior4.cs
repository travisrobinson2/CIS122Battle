
public class GlitterWarrior4 : Gladiator
{
    private List<string> attackers = new();

    public GlitterWarrior4(int secret) : base("Bob4", secret) { }

    public override Dictionary<string, int> Attack(List<Gladiator> opponents)
    {
        Dictionary<string, int> damageMap = new();
        Random random = new();

        foreach (var opponent in opponents)
        {
            if (opponent.Health > 0)
            {
                int damage = random.Next(5, 15);
                damageMap[opponent.Name] = damage;
            }
        }
        return damageMap;
    }

    protected override int Defense()
    {
        return new Random().Next(3, 8);
    }

    public override void TrackAttacker(string attackerName)
    {
        if (!attackers.Contains(attackerName))
        {
            attackers.Add(attackerName);
        }
    }

    public override string AttackAction(string opponentName, int damage)
    {
        return $"{Name} GlitterBombs {opponentName} for {damage} damage!";
    }
}
