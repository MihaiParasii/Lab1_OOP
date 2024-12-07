namespace Lab4;

/// <summary>
/// Represents a plant entity in the ecosystem.
/// Plants have energy and a survival rate and can grow over time.
/// </summary>
public class Plant : EcosystemEntity
{
    /// <summary>
    /// Initializes a new instance of the <see cref="Plant"/> class with the specified parameters.
    /// </summary>
    /// <param name="name">The name of the plant.</param>
    /// <param name="position">The position of the plant on the map.</param>
    /// <param name="energy">The initial energy level of the plant.</param>
    /// <param name="surviveRate">The survival rate of the plant (a value between 0 and 1).</param>
    public Plant(string name, Position position, int energy, float surviveRate)
        : base(name, position, energy, surviveRate, 'p')
    {
    }

    /// <summary>
    /// Increases the energy of the plant as it grows.
    /// This method adds a fixed amount of energy (10 units) to the plant.
    /// </summary>
    public override void GrowEntity()
    {
        Energy += 10;
    }

    /// <summary>
    /// Determines whether the plant dies based on its energy level.
    /// </summary>
    /// <returns>
    /// <c>true</c> if the plant's energy level is greater than or equal to the maximum energy level; otherwise, <c>false</c>.
    /// </returns>
    public override bool IsDie() => Energy >= MaxEnergy;
}
