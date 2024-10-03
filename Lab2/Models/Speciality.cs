namespace Lab2.Models;

public class Speciality
{
    public Speciality(string name, string abbreviation, Faculty faculty)
    {
        Name = name;
        Abbreviation = abbreviation;
        Faculty = faculty;
    }

    public Speciality()
    {
    }

    public int SpecialityId { get; init; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public Faculty Faculty { get; private set; }
    public ICollection<Student> Students { get; private set; } = [];
}
