
public abstract class Gladiator
{
    private readonly int _secret;

    public string Name { get; }
    public int Health { get; private set; } = 100;

    public Gladiator(string name, int secret)
    {
        Name = name;
        _secret = secret;
    }

    public abstract Dictionary<string, int> Attack(List<Gladiator> opponents);
    protected abstract int Defense();

    public virtual void TrackAttacker(string attackerName)
    {
        // Default does nothing
    }

    public virtual string AttackAction(string opponentName, int damage)
    {
        return $"{Name} attacks {opponentName} for {damage} damage!";
    }

    public void ApplyDamage(int damage, int secret, string attackerName)
    {
        if (secret == _secret)
        {
            int defenseVal = Defense();
            int reducedDamage = Math.Max(0, damage - defenseVal);
            Health = Math.Max(0, Health - reducedDamage);
            TrackAttacker(attackerName);
            Console.WriteLine($@"{Name} defended {defenseVal} against {damage} damage. {Name} has {Health} Health Remaining!");
        }
    }
}
