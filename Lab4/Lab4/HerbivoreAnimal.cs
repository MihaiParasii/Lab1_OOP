namespace Lab4;

/// <summary>
/// Represents a herbivore animal in the ecosystem.
/// Herbivores can only eat plants and follow the general eating rules defined in the base <see cref="Animal"/> class.
/// </summary>
public class HerbivoreAnimal : Animal
{
    /// <summary>
    /// Initializes a new instance of the <see cref="HerbivoreAnimal"/> class.
    /// </summary>
    /// <param name="name">The name of the herbivore animal.</param>
    /// <param name="position">The initial position of the herbivore animal on the map.</param>
    /// <param name="energy">The initial energy level of the herbivore animal.</param>
    /// <param name="surviveRate">The survival rate of the herbivore animal (a value between 0 and 1).</param>
    /// <param name="speed">The speed of the herbivore animal.</param>
    public HerbivoreAnimal(string name, Position position, int energy, float surviveRate, int speed)
        : base(name, position, energy, surviveRate, speed, 'h')
    {
    }

    /// <summary>
    /// Determines whether the herbivore animal can eat a given entity.
    /// </summary>
    /// <param name="entity">The entity to evaluate as potential food.</param>
    /// <returns>
    /// <c>true</c> if the entity is a plant and satisfies the general eating rules of the base class; otherwise, <c>false</c>.
    /// </returns>
    public override bool CanEat(EcosystemEntity entity)
    {
        return entity is Plant && base.CanEat(entity);
    }
}
