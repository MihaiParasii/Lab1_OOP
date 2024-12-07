namespace Lab4;

/// <summary>
/// Defines the behavior for movable entities in the ecosystem.
/// Provides methods for moving in all four cardinal directions.
/// </summary>
public interface IMovable
{
    /// <summary>
    /// Moves the entity to the left.
    /// </summary>
    protected void MoveLeft();

    /// <summary>
    /// Moves the entity to the right.
    /// </summary>
    protected void MoveRight();

    /// <summary>
    /// Moves the entity upward.
    /// </summary>
    protected void MoveUp();

    /// <summary>
    /// Moves the entity downward.
    /// </summary>
    protected void MoveDown();
}
