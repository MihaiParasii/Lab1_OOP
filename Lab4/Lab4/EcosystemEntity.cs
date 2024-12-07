namespace Lab4;

public abstract class EcosystemEntity(string name, Position position, int energy, float surviveRate, char symbol)
{
    public string Name { get; } = name;
    public Position Position { get; protected set; } = position;
    public int Energy { get; protected set; } = energy;
    public const int MaxEnergy = 100;
    public float SurviveRate { get; } = surviveRate;
    public readonly char Symbol = symbol;

    public abstract void GrowEntity();
    public virtual bool IsDie() => Energy <= 0;
}
