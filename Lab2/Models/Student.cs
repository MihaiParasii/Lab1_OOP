namespace Lab2.Models;

public class Student
{
    public Student(string firstName, string lastName, DateOnly birthDate, Speciality speciality)
    {
        FirstName = firstName;
        LastName = lastName;
        Email = $"{firstName}.{lastName}@{speciality.Abbreviation}.utm.md";
        BirthDate = birthDate;
        Speciality = speciality;
    }

    public Student()
    {
    }

    public int StudentId { get; init; }
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = null!;
    public string Email { get; private set; } = null!;
    public DateOnly BirthDate { get; set; }
    public bool IsGraduated { get; set; }
    public Speciality Speciality { get; set; } = null!;


    public override string ToString()
    {
        return $"{StudentId} | {FirstName} {LastName} {Email} {BirthDate} {Speciality}.";
    }
}
