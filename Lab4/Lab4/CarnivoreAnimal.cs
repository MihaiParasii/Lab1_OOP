namespace Lab4;

public class CarnivoreAnimal(string name, Position position, int energy, float surviveRate, int speed)
    : Animal(name, position, energy, surviveRate, speed, 'c')
{
    public override bool CanEat(EcosystemEntity entity)
    {
        return entity is Animal && base.CanEat(entity);
    }
}
