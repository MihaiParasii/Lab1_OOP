using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Lab2.Models;

public class Faculty
{
    // public Faculty(string name, University university, string abbreviation)
    // {
    //     Name = name;
    //     University = university;
    //     Abbreviation = abbreviation;
    // }
    //
    // public Faculty()
    // {
    // }

    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public int FacultyId { get; init; }

    public required string Name { get; set; }
    public required string Abbreviation { get; set; }
    public required University University { get; init; }

    public ICollection<Speciality> Specialities { get; private set; } = [];
    
    public override string ToString()
    {
        return $"ID: {FacultyId} \t Name: \t\t {Name} \n\t Abbreviation: \t {Abbreviation} \n\t University: \t {University.Abbreviation}\n";

        return $"Faculty ID: {FacultyId}, Name: {Name}, Abbreviation: {Abbreviation}, University: {University.Name}";
    }
}
