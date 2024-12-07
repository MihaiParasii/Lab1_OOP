namespace Lab4;

/// <summary>
/// Represents a 2D position with X and Y coordinates.
/// </summary>
public struct Position
{
    /// <summary>
    /// Gets the X-coordinate of the position.
    /// </summary>
    public int X { get; private set; }

    /// <summary>
    /// Gets the Y-coordinate of the position.
    /// </summary>
    public int Y { get; private set; }

    /// <summary>
    /// Initializes a new instance of the <see cref="Position"/> struct with the specified X and Y coordinates.
    /// </summary>
    /// <param name="x">The X-coordinate of the position.</param>
    /// <param name="y">The Y-coordinate of the position.</param>
    public Position(int x, int y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Adds two <see cref="Position"/> instances together and returns a new <see cref="Position"/> with the summed coordinates.
    /// </summary>
    /// <param name="position1">The first position to add.</param>
    /// <param name="position2">The second position to add.</param>
    /// <returns>A new <see cref="Position"/> that is the sum of the two positions.</returns>
    public static Position operator +(Position position1, Position position2)
    {
        position1.X += position2.X;
        position1.Y += position2.Y;
        return position1;
    }

    /// <summary>
    /// Determines whether two <see cref="Position"/> instances are equal by comparing their coordinates.
    /// </summary>
    /// <param name="position1">The first position to compare.</param>
    /// <param name="position2">The second position to compare.</param>
    /// <returns><c>true</c> if the X and Y coordinates are equal; otherwise, <c>false</c>.</returns>
    public static bool operator ==(Position position1, Position position2)
    {
        return position1.X == position2.X && position1.Y == position2.Y;
    }

    /// <summary>
    /// Determines whether two <see cref="Position"/> instances are not equal by comparing their coordinates.
    /// </summary>
    /// <param name="position1">The first position to compare.</param>
    /// <param name="position2">The second position to compare.</param>
    /// <returns><c>true</c> if the X or Y coordinates are not equal; otherwise, <c>false</c>.</returns>
    public static bool operator !=(Position position1, Position position2)
    {
        return !(position1 == position2);
    }
}
