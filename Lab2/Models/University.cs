using System.ComponentModel.DataAnnotations;

namespace Lab2.Models;

public class University
{
    public University(string name, string address, string abbreviation)
    {
        Name = name;
        Address = address;
        Abbreviation = abbreviation;
    }

    public University()
    {
    }

    public int UniversityId { get; init; }
    public string Name { get; set; }
    public string Abbreviation { get; set; }
    public string Address { get; set; }
    public ICollection<Faculty> Faculties { get; private set; } = [];


    // public void AddFaculty(Faculty faculty)
    // {
        // Faculties.Add(faculty);
    // }

    // public Speciality? SearchSpecialityOfStudent(Student targetStudent)
    // {
        // return Faculties
            // .SelectMany(faculty => faculty.Specialities, (faculty, speciality) => new { faculty, speciality })
            // .SelectMany(t => t.speciality.Students, (t, student) => new { t, student })
            // .Where(t => t.student.Id == targetStudent.Id)
            // .Select(t => t.student.Speciality).FirstOrDefault();
    // }


    public override string ToString()
    {
        return $"ID: {UniversityId} \t Name: \t\t {Name} \n\t Abbreviation: \t {Abbreviation} \n\t Address: \t {Address}\n";
    }

    public string ToStringShortly()
    {
        return $"ID: {UniversityId} \t Name: {Name}\n";
    }
}
