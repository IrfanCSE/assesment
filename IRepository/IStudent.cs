using primetechmvc.DTO;

namespace primetechmvc.IRepository
{
    public interface IStudent
    {
         public MessageHelper AssignSubjectWithStudent(StudentDto obj);
         public Task<List<StudentDto>> StudentList();
         public Task<StudentDto> StudentSubjectById(Guid StudentId);

         // Dropdown

         public Dictionary<string,List<CommonDropdown>> GetDepartmentWithSubject();
    }
}