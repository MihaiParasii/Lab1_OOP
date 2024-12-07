using System.Text;

namespace Lab4;

/// <summary>
/// Represents a map for an ecosystem simulation, including methods for managing entities and the map layout.
/// </summary>
public class Map
{
    /// <summary>
    /// Gets or sets the number of rows in the map.
    /// </summary>
    public static int Rows { get; set; }

    /// <summary>
    /// Gets or sets the number of columns in the map.
    /// </summary>
    public static int Cols { get; set; }

    /// <summary>
    /// Gets the grid representing the map. 
    /// The grid is a two-dimensional array of characters.
    /// </summary>
    public static char[,] Grid { get; private set; } = null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="Map"/> class with the specified number of rows and columns.
    /// The map is initialized with borders marked by '#' and the interior as empty spaces (' ').
    /// </summary>
    /// <param name="rows">The number of rows in the map.</param>
    /// <param name="cols">The number of columns in the map.</param>
    public Map(int rows, int cols)
    {
        Rows = rows;
        Cols = cols;
        Grid = new char[Rows, Cols];

        ClearMap();
    }

    /// <summary>
    /// Clears the map and sets its layout.
    /// The borders of the map are marked with '#' while the interior cells are set to empty spaces (' ').
    /// </summary>
    public static void ClearMap()
    {
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                if ((i == 0 || i == Rows - 1) || (j == 0 || j == Cols - 1))
                {
                    Grid[i, j] = '#';
                    continue;
                }

                Grid[i, j] = ' ';
            }
        }
    }

    /// <summary>
    /// Returns a string representation of the map.
    /// </summary>
    /// <returns>A string that visually represents the map grid.</returns>
    public override string ToString()
    {
        var sb = new StringBuilder();

        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Cols; j++)
            {
                sb.Append($"{Grid[i, j]}  ");
            }

            sb.AppendLine();
        }

        return sb.ToString();
    }

    /// <summary>
    /// Places an <see cref="EcosystemEntity"/> on the map at the specified position.
    /// </summary>
    /// <param name="entity">The entity to place on the map.</param>
    /// <exception cref="InvalidOperationException">
    /// Thrown if there is already an entity or obstacle at the specified position.
    /// </exception>
    public static void SetEntityOnMap(EcosystemEntity entity)
    {
        if (Grid[entity.Position.Y, entity.Position.X] != ' ')
        {
            throw new InvalidOperationException($"There is already an entity on this position. Can't set entity {entity.Name}");
        }

        Grid[entity.Position.Y, entity.Position.X] = entity.Symbol;
    }

    /// <summary>
    /// Determines whether an <see cref="EcosystemEntity"/> can be placed on the map at the specified position.
    /// </summary>
    /// <param name="entity">The entity to check for placement.</param>
    /// <returns>
    /// <c>true</c> if the entity can be placed at the specified position; otherwise, <c>false</c>.
    /// </returns>
    public static bool CanSetEntityOnMap(EcosystemEntity entity)
    {
        return entity.Position.X > 0 && entity.Position.X < Rows - 1 &&
               entity.Position.Y > 0 && entity.Position.Y < Cols - 1 &&
               Grid[entity.Position.Y, entity.Position.X] == ' ';
    }
}

