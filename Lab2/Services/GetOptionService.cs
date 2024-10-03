using Lab2.HelpData;

namespace Lab2.Services;

public static class GetOptionService
{
    public static IEnumerable<MenuOption> GetMainOptions()
    {
        return
        [
            new MenuOption("Quit Program", MainOptionsEnum.Exit),
            new MenuOption("Clean Screen", MainOptionsEnum.ClearScreen),
            new MenuOption("Display General Options", MainOptionsEnum.DisplayGeneralOptions),
            new MenuOption("Display University Options", MainOptionsEnum.DisplayUniversityOptions),
            new MenuOption("Display Faculty Options", MainOptionsEnum.DisplayFacultyOptions),
            new MenuOption("Display Speciality Options", MainOptionsEnum.DisplaySpecialityOptions)
        ];
    }

    public static IEnumerable<MenuOption> GetGeneralOptions()
    {
        return
        [
            new MenuOption("Go Back", GeneralOptionsEnum.Back),
            new MenuOption("Create University", GeneralOptionsEnum.CreateUniversity),
            new MenuOption("Update University Information", GeneralOptionsEnum.UpdateUniversity),
            new MenuOption("Display University Information", GeneralOptionsEnum.DisplayUniversityInfo),
            new MenuOption("Display All Universities", GeneralOptionsEnum.DisplayALlUniversities),
            new MenuOption("Display Graduated Students", GeneralOptionsEnum.DisplayGraduatedStudents),
            new MenuOption("Display Enrolled Students", GeneralOptionsEnum.DisplayEnrolledStudents),
            new MenuOption("Display All Students", GeneralOptionsEnum.DisplayAllStudents),
        ];
    }

    public static IEnumerable<MenuOption> GetUniversityOptions()
    {
        return
        [
            new MenuOption("Go Back", UniversityOptionsEnum.Back),
            new MenuOption("Create Faculty", UniversityOptionsEnum.CreateFaculty),
            new MenuOption("Display All Faculties", UniversityOptionsEnum.DisplayFaculties),
            new MenuOption("Display Faculty Information", UniversityOptionsEnum.DisplayFacultyInfo),
            new MenuOption("Update Faculty", UniversityOptionsEnum.UpdateFaculty),
            new MenuOption("Remove Faculty", UniversityOptionsEnum.RemoveFaculty),
            new MenuOption("Display Graduated Students", UniversityOptionsEnum.DisplayGraduatedStudents),
            new MenuOption("Display Enrolled Students", UniversityOptionsEnum.DisplayEnrolledStudents),
            new MenuOption("Display All Students", UniversityOptionsEnum.DisplayAllStudents),
        ];
    }

    public static IEnumerable<MenuOption> GetFacultyOptions()
    {
        return
        [
            new MenuOption("Go Back", FacultyOptionsEnum.Back),
            new MenuOption("Create Speciality", FacultyOptionsEnum.CreateSpeciality),
            new MenuOption("Display All Speciality", FacultyOptionsEnum.DisplaySpecialities),
            new MenuOption("Display Speciality Information", FacultyOptionsEnum.DisplaySpecialityInformation),
            new MenuOption("Update Speciality", FacultyOptionsEnum.UpdateSpeciality),
            new MenuOption("Remove Speciality", FacultyOptionsEnum.RemoveSpeciality),
            new MenuOption("Display Graduated Students", FacultyOptionsEnum.DisplayGraduatedStudents),
            new MenuOption("Display Enrolled Students", FacultyOptionsEnum.DisplayEnrolledStudents),
            new MenuOption("Display All Students", FacultyOptionsEnum.DisplayAllStudents),
        ];
    }

    public static IEnumerable<MenuOption> GetSpecialityOptions()
    {
        return
        [
            new MenuOption("Go Back", SpecialityOptionsEnum.Back),
            new MenuOption("Create Student", SpecialityOptionsEnum.CreateStudent),
            new MenuOption("Display All Students", SpecialityOptionsEnum.DisplayStudents),
            new MenuOption("Display Student Information", SpecialityOptionsEnum.DisplayStudentInfo),
            new MenuOption("Update Student", SpecialityOptionsEnum.UpdateStudent),
            new MenuOption("Remove Student", SpecialityOptionsEnum.RemoveStudent),
            new MenuOption("Enroll Student To Speciality", SpecialityOptionsEnum.EnrollStudentToSpeciality),
            new MenuOption("Dis Enroll Student From Speciality", SpecialityOptionsEnum.DisEnrollStudentFromSpeciality),
            new MenuOption("Change Student Speciality", SpecialityOptionsEnum.ChangeStudentSpeciality),
            new MenuOption("Graduate Student", SpecialityOptionsEnum.GraduateStudent),
        ];
    }
}
