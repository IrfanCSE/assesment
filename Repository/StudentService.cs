using Microsoft.EntityFrameworkCore;
using primetechmvc.DbContexts;
using primetechmvc.DTO;
using primetechmvc.Helper;
using primetechmvc.IRepository;
using StoreProcedure;

public class StudentService : IStudent
{
    private readonly Context _context;
    public StudentService(Context context)
    {
        _context = context;
    }

    // I created it so that I could code quickly and easily while working with stored procedures.
    // It appears to be performing some database operations using a stored procedure called "dbo.PostStudentWithSubject" 
    // and passing in parameters such as the student's name and roll, 
    // as well as some JSON data contained in the "Subjects" property of the StudentDto object. 
    // The output parameter "@msg" is used to retrieve the message returned by the stored procedure.
    //  The function then returns a new instance of the "MessageHelper" class, passing in the result as a string.
    // StoredProcedure is the library I used in this case.
    public MessageHelper AssignSubjectWithStudent(StudentDto obj)
    {
        var sp = "dbo.PostStudentWithSubject";

        var param = new Param();
        param.Add("@studentName", obj.Name);
        param.Add("@studentRoll", obj.Roll);

        var json = new Json();
        json.Add("@subjectInfo", obj.Subjects);

        var output = new Output();
        output.Add("@msg"); ;

        var exc_result = _context.Execute(sp, json, param, output);

        var result = exc_result.Find(x => x.Key == "@msg")?.Value;

        return new MessageHelper(result.ToString());
    }

    // The code creates a new dictionary object that has two key-value pairs:
    // "Department" key with a list of "Department" objects as the value.
    // "Subject" key with a list of "Subject" objects as the value.
    // It will return the dictionary object to use as cascading Dropdown.
    // Department does not have a parent ID, but subjects do, and that parent ID is the Department ID.
    // For simplicity i made it static data set

    public Dictionary<string, List<CommonDropdown>> GetDepartmentWithSubject()
    {
        return new Dictionary<string, List<CommonDropdown>>
        {
            {"Department",Department.Departments},
            {"Subject",Subject.Subjects},
        };
    }

    // Some optimization could be done:
    // Create an index on the Roll column if it's unique.
    // Add pagination to the query to limit the number of returned rows and avoid handling a large amount of data at once.
    // For simplicity i did it that way
    public Task<List<StudentDto>> StudentList()
    {
        return _context.Students.Where(x => x.IsActive == true).Select(x => new StudentDto
        {
            Id = x.Id,
            Name = x.Name,
            Roll = x.Roll,
            IsActive = x.IsActive.Value,
        }).ToListAsync();
    }



    // Used AsNoTracking() method while querying the data from database to improve the performance.
    // Instead of looping through the subjects list, i could join the student_info and subjects by using join statement in linq and get the department name and subject name in the same query. For simplicity i did it that way
    public async Task<StudentDto> StudentSubjectById(Guid StudentId)
    {

        var student_info = await _context.Students
        .Where(x => x.Id == StudentId)
        .Select(student => new StudentDto
        {
            Id = student.Id,
            Name = student.Name,
            Roll = student.Roll,
            IsActive = student.IsActive.Value
        }).AsNoTracking().FirstOrDefaultAsync();

        var subjects = await _context.StudentsSubjects.Where(x => x.StudentId == StudentId && x.IsActive == true)
        .Select(sub => new StudentWithSubjectDto
        {
            DepartmentId = sub.DepartmentId,
            SubjectId = sub.SubjectId,
            Credit = sub.Credit,
        }).AsNoTracking().ToListAsync();

        subjects.ForEach(x =>
        {
            x.DepartmentName = Department.Departments.Where(dpt => dpt.Value == x.DepartmentId).Select(dpt => dpt.Label).FirstOrDefault();
            x.SubjectName = Subject.Subjects.Where(sub => sub.Value == x.SubjectId).Select(sub => sub.Label).FirstOrDefault();
        });

        student_info.Subjects.AddRange(subjects);

        return student_info;
    }
}