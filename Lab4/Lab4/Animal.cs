namespace Lab4;

public abstract class Animal(string name, Position position, int energy, float surviveRate, int speed, char symbol)
    : EcosystemEntity(name, position, energy, surviveRate, symbol), IMovable
{
    public int Speed { get; set; } = speed;
    
    public override void GrowEntity()
    {
        Energy += 10;
    }

    public virtual bool CanEat(EcosystemEntity entity)
    {
        return entity.Position == Position;
    }

    public void Move()
    {
        Random rand = new Random();
        int direction = rand.Next(5);
        Energy -= 5;

        switch (direction)
        {
            case 0:
                MoveUp();
                return;
            case 1:
                MoveDown();
                return;
            case 2:
                MoveLeft();
                return;
            case 3:
                MoveRight();
                return;
        }
    }

    public void MoveLeft()
    {
        if (Position.X - 1 <= 0)
        {
            return;
        }

        Position += new Position(-1, 0);
    }

    public void MoveRight()
    {
        if (Position.X + 1 >= Map.Cols - 1)
        {
            return;
        }

        Position += new Position(1, 0);
    }

    public void MoveUp()
    {
        if (Position.Y - 1 <= 0)
        {
            return;
        }

        Position += new Position(0, -1);
    }

    public void MoveDown()
    {
        if (Position.Y + 1 >= Map.Rows - 1)
        {
            return;
        }

        Position += new Position(0, 1);
    }
}
