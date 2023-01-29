namespace primetechmvc.DTO
{
    public class StudentDto
    {
        public StudentDto()
        {
            Subjects = new List<StudentWithSubjectDto>();
        }

        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }
        public bool IsActive { get; set; }

        public List<StudentWithSubjectDto> Subjects { get; set; }
    }
    public class StudentWithSubjectDto
    {
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public decimal Credit { get; set; }
    }

    public class StudentSubjectFromSPDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Roll { get; set; }
        public int DepartmentId { get; set; }
        public string DepartmentName { get; set; }
        public int SubjectId { get; set; }
        public string SubjectName { get; set; }
        public decimal Credit { get; set; }
    }
}