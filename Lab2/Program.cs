using Lab2.Data;
using Lab2.HelpData;
using Lab2.Repositories;
using Lab2.Services;

namespace Lab2;

internal static class Program
{
    private static readonly AppDbContext DbContext = new();
    private static readonly IUniversityRepository UniversityRepository = new UniversityRepository(DbContext);
    private static readonly IFacultyRepository FacultyRepository = new FacultyRepository(DbContext);
    private static readonly ISpecialityRepository SpecialityRepository = new SpecialityRepository(DbContext);
    private static readonly IStudentRepository StudentRepository = new StudentRepository(DbContext);

    public static async Task Main(string[] args)
    {
        int choice = 0;


        while (choice != (int)MainOptionsEnum.Exit)
        {
            Console.Clear();
            PrintOptions(GetOptionService.GetMainOptions());
            choice = int.Parse(Console.ReadLine()!);
            Console.Clear();

            switch (choice)
            {
                case (int)MainOptionsEnum.ClearScreen:
                    Console.Clear();
                    break;
                case (int)MainOptionsEnum.DisplayGeneralOptions:
                {
                    await GeneralOptionsMethod();
                    break;
                }
                case (int)MainOptionsEnum.DisplayUniversityOptions:
                {
                    await UniversityOptionsMethod();
                    break;
                }
                case (int)MainOptionsEnum.DisplayFacultyOptions:
                {
                    await FacultyOptionsMethod();
                    break;
                }
                case (int)MainOptionsEnum.DisplaySpecialityOptions:
                {
                    await SpecialityOptionsMethod();
                    break;
                }
            }
        }
    }

    private static async Task GeneralOptionsMethod()
    {
        var generalOptionsService = new GeneralOptionsService(UniversityRepository);
        int localChoice = -2;

        while (localChoice != (int)GeneralOptionsEnum.Back)
        {
            PrintOptions(GetOptionService.GetGeneralOptions());
            localChoice = int.Parse(Console.ReadLine()!);
            Console.Clear();


            switch (localChoice)
            {
                case (int)GeneralOptionsEnum.CreateUniversity:
                    await generalOptionsService.CreateUniversityAsync();
                    break;
                case (int)GeneralOptionsEnum.UpdateUniversity:
                    await generalOptionsService.UpdateUniversityAsync();
                    break;
                case (int)GeneralOptionsEnum.DisplayUniversityInfo:
                    await generalOptionsService.DisplayUniversityInfoAsync();
                    break;
                case (int)GeneralOptionsEnum.DisplayALlUniversities:
                    await generalOptionsService.DisplayAllUniversitiesAsync();
                    break;
                case (int)GeneralOptionsEnum.DisplayGraduatedStudents:
                    await generalOptionsService.DisplayGraduatedStudentsAsync();
                    break;
                case (int)GeneralOptionsEnum.DisplayEnrolledStudents:
                    await generalOptionsService.DisplayEnrolledStudentsAsync();
                    break;
                case (int)GeneralOptionsEnum.DisplayAllStudents:
                    await generalOptionsService.DisplayAllStudentsAsync();
                    break;
            }
        }
    }

    private static async Task UniversityOptionsMethod()
    {
        var universityOptionsService = new UniversityOptionsService(FacultyRepository, UniversityRepository);
        int localChoice = -2;

        while (localChoice != (int)UniversityOptionsEnum.Back)
        {
            PrintOptions(GetOptionService.GetUniversityOptions());
            localChoice = int.Parse(Console.ReadLine()!);
            Console.Clear();

            switch (localChoice)
            {
                case (int)UniversityOptionsEnum.CreateFaculty:
                    await universityOptionsService.CreateFacultyAsync();
                    break;
                case (int)UniversityOptionsEnum.DisplayFaculties:
                    await universityOptionsService.DisplayAllFacultiesAsync();
                    break;
                case (int)UniversityOptionsEnum.DisplayFacultyInfo:
                    await universityOptionsService.DisplayFacultyInfoAsync();
                    break;
                case (int)UniversityOptionsEnum.UpdateFaculty:
                    await universityOptionsService.UpdateFacultyAsync();
                    break;
                case (int)UniversityOptionsEnum.RemoveFaculty:
                    await universityOptionsService.RemoveFacultyAsync();
                    break;
                case (int)UniversityOptionsEnum.DisplayGraduatedStudents:
                    await universityOptionsService.DisplayGraduatedStudentsAsync();
                    break;
                case (int)UniversityOptionsEnum.DisplayEnrolledStudents:
                    await universityOptionsService.DisplayEnrolledStudentsAsync();
                    break;
                case (int)UniversityOptionsEnum.DisplayAllStudents:
                    await universityOptionsService.DisplayAllStudentsAsync();
                    break;
            }
        }
    }

    private static async Task FacultyOptionsMethod()
    {
        var facultyOptionService = new FacultyOptionService(SpecialityRepository, FacultyRepository);
        int localChoice = -2;

        while (localChoice != (int)FacultyOptionsEnum.Back)
        {
            PrintOptions(GetOptionService.GetFacultyOptions());
            localChoice = int.Parse(Console.ReadLine()!);
            Console.Clear();

            switch (localChoice)
            {
                case (int)FacultyOptionsEnum.CreateSpeciality:
                    await facultyOptionService.CreateSpecialityAsync();
                    break;
                case (int)FacultyOptionsEnum.DisplaySpecialities:
                    await facultyOptionService.DisplayAllSpecialitiesAsync();
                    break;
                case (int)FacultyOptionsEnum.DisplaySpecialityInformation:
                    await facultyOptionService.DisplaySpecialityInfoAsync();
                    break;
                case (int)FacultyOptionsEnum.UpdateSpeciality:
                    await facultyOptionService.UpdateSpecialityAsync();
                    break;
                case (int)FacultyOptionsEnum.RemoveSpeciality:
                    await facultyOptionService.RemoveSpecialityAsync();
                    break;
                case (int)FacultyOptionsEnum.DisplayGraduatedStudents:
                    await facultyOptionService.DisplayGraduatedStudentsAsync();
                    break;
                case (int)FacultyOptionsEnum.DisplayEnrolledStudents:
                    await facultyOptionService.DisplayEnrolledStudentsAsync();
                    break;
                case (int)FacultyOptionsEnum.DisplayAllStudents:
                    await facultyOptionService.DisplayAllStudentsAsync();
                    break;
            }
        }
    }

    private static async Task SpecialityOptionsMethod()
    {
        var specialityOptionService = new SpecialityOptionService(StudentRepository, SpecialityRepository);
        int localChoice = -2;

        while (localChoice != (int)SpecialityOptionsEnum.Back)
        {
            PrintOptions(GetOptionService.GetSpecialityOptions());
            localChoice = int.Parse(Console.ReadLine()!);
            Console.Clear();

            switch (localChoice)
            {
                case (int)SpecialityOptionsEnum.CreateStudent:
                    await specialityOptionService.CreateStudentAsync();
                    break;
                case (int)SpecialityOptionsEnum.DisplayStudents:
                    await specialityOptionService.DisplayAllStudentsAsync();
                    break;
                case (int)SpecialityOptionsEnum.DisplayStudentInfo:
                    await specialityOptionService.DisplayStudentInfoAsync();
                    break;
                case (int)SpecialityOptionsEnum.UpdateStudent:
                    await specialityOptionService.UpdateStudentAsync();
                    break;
                case (int)SpecialityOptionsEnum.RemoveStudent:
                    await specialityOptionService.RemoveStudentAsync();
                    break;
                case (int)SpecialityOptionsEnum.EnrollStudentToSpeciality:
                    await specialityOptionService.DisplayGraduatedStudentsAsync();
                    break;
                case (int)SpecialityOptionsEnum.DisEnrollStudentFromSpeciality:
                    await specialityOptionService.DisplayEnrolledStudentsAsync();
                    break;
                case (int)SpecialityOptionsEnum.ChangeStudentSpeciality:
                    await specialityOptionService.ChangeStudentSpecialityAsync();
                    break;
                case (int)SpecialityOptionsEnum.GraduateStudent:
                    await specialityOptionService.GraduateStudentAsync();
                    break;
            }
        }
    }


    private static void PrintOptions(IEnumerable<MenuOption> options)
    {
        Console.WriteLine();
        Console.WriteLine("------------------------------------------------------");

        foreach (var option in options)
        {
            Console.WriteLine($"—>\t {option.Option.ToString("D")} — {option.Label}");
        }

        Console.WriteLine("------------------------------------------------------");
    }
}
